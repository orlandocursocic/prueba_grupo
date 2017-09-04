using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using prueba_grupo.Models;
using System.Collections.Generic;
using System.Web.Http;
using Unity.WebApi;
using System;
using prueba_grupo.Exceptions;
using prueba_grupo.Services;
using prueba_grupo.Repositories;

namespace prueba_grupo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.AddNewExtension<Interception>();

            container.RegisterType<ICampoService, CampoService>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<DBInterceptor>());
            container.RegisterType<ICampoRepository, CampoRepository>();

            container.RegisterType<IPerfilService, PerfilService>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<DBInterceptor>());
            container.RegisterType<IPerfilRepository, PerfilRepository>();

            container.RegisterType<ITareaService, TareaService>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<DBInterceptor>());
            container.RegisterType<ITareaRepository, TareaRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        public class DBInterceptor : IInterceptionBehavior
        {
            public IMethodReturn Invoke(IMethodInvocation input,
              GetNextInterceptionBehaviorDelegate getNext)
            {
                IMethodReturn result;
                if (ApplicationDbContext.applicationDbContext == null)
                {
                    using (var context = new ApplicationDbContext())
                    {
                        ApplicationDbContext.applicationDbContext = context;
                        using (var dbContextTransaction = context.Database.BeginTransaction())
                        {
                            try
                            {

                                result = getNext()(input, getNext);


                                if (result.Exception != null)
                                {
                                    throw result.Exception;
                                }
                                context.SaveChanges();

                                dbContextTransaction.Commit();
                            }
                            catch (NoEncontradoException e)
                            {
                                dbContextTransaction.Rollback();
                                ApplicationDbContext.applicationDbContext = null;
                                throw e;
                            }
                            catch (Exception e)
                            {
                                dbContextTransaction.Rollback();
                                ApplicationDbContext.applicationDbContext = null;
                                throw new Exception("He hecho rollback de la transacci�n", e);
                            }
                        }
                    }
                    ApplicationDbContext.applicationDbContext = null;
                }
                else
                {

                    result = getNext()(input, getNext);


                    if (result.Exception != null)
                    {
                        throw result.Exception;
                    }
                }
                return result;
            }

            public IEnumerable<Type> GetRequiredInterfaces()
            {
                return Type.EmptyTypes;
            }

            public bool WillExecute
            {
                get { return true; }
            }

            private void WriteLog(string message)
            {

            }
        }
    }
}