using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;

namespace Expert.WebApi.Infrastructure
{
    public class DependencyBuilder
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            return builder.Build();
        }
    }
}