﻿using System;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConsultaMedica.Startup))]
namespace ConsultaMedica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
