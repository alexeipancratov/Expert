using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Expert.Data;
using Expert.Data.Repositories;
using Expert.DomainEntities.ServiceContracts;

namespace Expert.WebApi.Infrastructure
{
    public class DependencyBuilder
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<ExpertContext>();
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>));

            return builder.Build();
        }
    }
}