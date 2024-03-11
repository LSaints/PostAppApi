using Prometheus;

namespace PostAppApi.Api.Configuration
{
    public static class PrometheusConfiguration
    {
        public static void UsePrometheus(this IApplicationBuilder app)
        {
            var counter = Metrics.CreateCounter("PosAppApi", "conta a solicitação para os endpoints da API PostApp",
                new CounterConfiguration
                {
                    LabelNames = new[] { "method", "endpoint" }
                });

            app.Use((context, next) =>
            {
                counter.WithLabels(context.Request.Method, context.Request.Path).Inc();
                return next();
            });

            app.UseMetricServer();
            app.UseHttpMetrics();
        }
    }
}
