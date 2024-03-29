﻿using PostAppApi.Comunicacao.ModelViews.Group;
using PostAppApi.Comunicacao.ModelViews.Post;
using PostAppApi.Comunicacao.ModelViews.Rating;
using PostAppApi.Comunicacao.ModelViews.User;

namespace PostAppApi.Api.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void UseAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(UserGetRequestBody),
                typeof(UserPostRequestBody),
                typeof(UserPutRequestBody),
                typeof(UserLoginRequestBody));

            services.AddAutoMapper(
                typeof(PostPostRequestBody),
                typeof(PostPutRequestBody),
                typeof(PostGetRequestBody));

            services.AddAutoMapper(
                typeof(PostRatingRequestBody),
                typeof(GetNumericsRatingsBody));

            services.AddAutoMapper(
                typeof(GroupGetRequestBody),
                typeof(GroupPostRequestBody),
                typeof(GroupPutRequestBody));
        }
    }
}
