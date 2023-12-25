using PostAppApi.Application.ModelViews.Post;
using PostAppApi.Application.ModelViews.User;

namespace PostAppApi.Api.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void UseAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserGetRequestBody), typeof(UserPostRequestBody), typeof(UserPutRequestBody));
            services.AddAutoMapper(typeof(PostPostRequestBody), typeof(PostPutRequestBody));
        }
    }
}
