﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rockfast.Dependencies
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDependenicesServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
