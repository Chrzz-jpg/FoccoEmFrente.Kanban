using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoccoEmFrente.Kanban.Application.Services.Extensions
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// container de injeção de dependências de serviços
        /// </summary>
        /// <param name="services"></param>
        public static void AddApplicationServices(this IServiceCollection services) 
        {
            services.AddScoped<IActivityService, ActivityService>();
        }
    }
}
