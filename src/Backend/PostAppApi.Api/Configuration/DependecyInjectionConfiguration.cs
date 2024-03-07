using PostAppApi.Application.Implementations;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Application.Interfaces.Repositories;
using PostAppApi.Infrastructure.Repositories;

namespace PostAppApi.Api.Configuration
{
    public static class DependecyInjectionConfiguration
    {
        public static void UseDependecyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserManager, UserManager>();

            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostManager, PostManager>();

            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IRatingManager, RatingManager>();

            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupManager, GroupManager>();
        }
    }
}
