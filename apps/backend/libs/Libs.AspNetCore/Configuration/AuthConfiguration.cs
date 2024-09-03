﻿using FwksLab.Libs.AspNetCore.Configuration.Options;
using FwksLab.Libs.Core.Security.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FwksLab.Libs.AspNetCore.Configuration;

public static class AuthConfiguration
{
    public static IServiceCollection OverrideAuthOptions(this IServiceCollection services, AuthServerOptions authOptions)
    {
        return services
            .AddSingleton(authOptions)
            .AddTransient<IConfigureOptions<AuthenticationOptions>, CustomAuthenticationOptions>()
            .AddTransient<IConfigureOptions<JwtBearerOptions>, CustomJwtBearerOptions>()
            .AddTransient<IConfigureOptions<AuthorizationOptions>, CustomAuthorizationOptions>();
    }

    public static IServiceCollection OverrideAuthOptions<TAuthentication, TJwtBearer, TAuthorization>(this IServiceCollection services)
        where TAuthentication : class, IConfigureOptions<AuthenticationOptions>
        where TJwtBearer : class, IConfigureOptions<JwtBearerOptions>
        where TAuthorization : class, IConfigureOptions<AuthorizationOptions>
    {
        return services
            .AddTransient<IConfigureOptions<AuthenticationOptions>, TAuthentication>()
            .AddTransient<IConfigureOptions<JwtBearerOptions>, TJwtBearer>()
            .AddTransient<IConfigureOptions<AuthorizationOptions>, TAuthorization>();
    }
}
