using Polly;
using System.Net;

namespace API.Configurations
{
    public static class HttpClientConfiguration
    {
        public static Func<HttpMessageHandler> ConfigurePrimaryHttpMessageHandler() => () => new SocketsHttpHandler
        {
            AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
            PooledConnectionLifetime = TimeSpan.FromMinutes(5),       // rotaciona conexões para respeitar DNS changes
            PooledConnectionIdleTimeout = TimeSpan.FromMinutes(2),    // tempo para conexões ociosas
            MaxConnectionsPerServer = 100
        };

        public static Func<PolicyBuilder<HttpResponseMessage>, IAsyncPolicy<HttpResponseMessage>> ConfigureHttpErrorPolicyOrResult(int retryCount) => options =>
            options.OrResult(response => !response.IsSuccessStatusCode).WaitAndRetryAsync(retryCount, retry => TimeSpan.FromSeconds(Math.Pow(2, retry)) + TimeSpan.FromMilliseconds(GenerareMilliseconds()));

        public static Func<PolicyBuilder<HttpResponseMessage>, IAsyncPolicy<HttpResponseMessage>> ConfigureHttpErrorPolicyCircuitBreaker(int retryCount, double fromSeconds) => options =>
            options.CircuitBreakerAsync(handledEventsAllowedBeforeBreaking: retryCount, durationOfBreak: TimeSpan.FromSeconds(fromSeconds));

        private static int GenerareMilliseconds() =>
            new Random().Next(0, 100);
    }
}
