using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

public static class CustomAuthentication {
    public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration) {
        byte[] key = System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
        services.AddAuthentication(options => {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options => {
            options.TokenValidationParameters = new TokenValidationParameters {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                ClockSkew = TimeSpan.FromMinutes(5),
                RequireExpirationTime = true,
                ValidateLifetime = true,
            };
        });
        return services;
    }
}