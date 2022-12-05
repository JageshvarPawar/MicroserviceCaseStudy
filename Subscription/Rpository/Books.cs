using Polly;
using System.Net.Http.Headers;

namespace Subscription.Rpository
{
    public class Books
    {
        private static HttpClient _httpClient=new HttpClient();
        static Policy _circuitBreakerPolicy;
        static Policy _retryPolicy;
        public Books()
        {
            InitClient();
            InitPolicy();

        }

        private static void InitPolicy()
        {
            _circuitBreakerPolicy = Policy.Handle<AggregateException>(x =>
            {
                var result = x.InnerException is HttpRequestException;
                return result;
            })
                .CircuitBreaker(5, TimeSpan.FromSeconds(10));

            _retryPolicy = Policy.Handle<AggregateException>(x =>
            {
                var result = x.InnerException is HttpRequestException;
                return result;
            })
                .RetryForever();
        }

        private static void InitClient()
        {
            _httpClient.BaseAddress = new Uri("https://host.docker.internal:5111/gateway/books/getavailablecopies/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public int GetAvailableCopies(string bookId)
        {
            _retryPolicy.Wrap(_circuitBreakerPolicy)
                .Execute<int>(() =>
                {
                   return GetIntAsync(bookId).Result;
                });
            return 0;
        }

        static async Task<int> GetIntAsync(string bookId)
        {
            int result = 0;
            var response = await _httpClient.GetAsync($"{bookId}");
            if(response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<int>();
            }
            return result;
        }
    }
}
