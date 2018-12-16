using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace HorseRace14.Shit
{
    public class ApiClient
    {
        private readonly ApiClientParameterCollection _headers;
        private readonly IRestClient _restClient;

        internal ApiClient(IRestClient restClient, string baseUri, ApiClientParameterCollection headers = null, int timeoutInMilliseconds = 20000)
            : this(baseUri, headers, timeoutInMilliseconds)
        {
            _restClient = restClient;
        }

        public ApiClient(string baseUri, ApiClientParameterCollection headers = null, int timeoutInMilliseconds = 20000)
        {
            _headers = headers;
            _restClient = new RestClient(baseUri)
            {
                Authenticator = new NtlmAuthenticator(),
                Timeout = timeoutInMilliseconds
            };
        }

        public ApiClientResponse<T> Get<T>(string uri, ApiClientParameterCollection urlSegments = null, ApiClientParameterCollection queryParameters = null)
        {
            return ExecuteRequest<T>(Method.GET, uri, urlSegments, queryParameters);
        }

        public ApiClientResponse<T> Post<T>(string uri, JObject body, ApiClientParameterCollection urlSegments = null)
        {
            return ExecuteRequest<T>(Method.POST, uri, urlSegments, null, body);
        }

        public ApiClientResponse<T> Post<T>(string uri, JArray body, ApiClientParameterCollection urlSegments = null)
        {
            return ExecuteRequest<T>(Method.POST, uri, urlSegments, null, body);
        }

        public ApiClientResponse<T> Put<T>(string uri, JObject body, ApiClientParameterCollection urlSegments = null)
        {
            return ExecuteRequest<T>(Method.PUT, uri, urlSegments, null, body);
        }

        public ApiClientResponse<T> Put<T>(string uri, JArray body, ApiClientParameterCollection urlSegments = null)
        {
            return ExecuteRequest<T>(Method.PUT, uri, urlSegments, null, body);
        }

        public ApiClientResponse<object> Delete(string uri, ApiClientParameterCollection urlSegments = null)
        {
            return ExecuteRequest<object>(Method.DELETE, uri, urlSegments);
        }

        private ApiClientResponse<T> ExecuteRequest<T>(Method method, string uri, ApiClientParameterCollection urlSegments = null, ApiClientParameterCollection queryParameters = null, object body = null)
        {
            var request = new RestRequest(uri, method);

            AddHeaders(request, _headers);
            AddBody(request, body);
            AddUrlSegments(request, urlSegments);
            AddQueryParameters(request, queryParameters);

            var response = _restClient.Execute(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return new ApiClientResponse<T>
                {
                    StatusCode = response.StatusCode,
                    Content = default(T)
                };

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var content = JObject.Parse(response.Content);
                var messageObject = content["message"];
                var message = messageObject?.ToString() ?? response.Content;

                return new ApiClientResponse<T>
                {
                    StatusCode = response.StatusCode,
                    Message = message
                };
            }

            if (response.StatusCode == 0 && response.ResponseStatus == ResponseStatus.TimedOut)
                return new ApiClientResponse<T>
                {
                    StatusCode = HttpStatusCode.RequestTimeout
                };

            if ((int)response.StatusCode < 200 || (int)response.StatusCode > 299)
            {
                string message = null;

                if (!string.IsNullOrWhiteSpace(response.Content))
                {
                    var content = JObject.Parse(response.Content);
                    var messageObject = content["message"];
                    message = messageObject?.ToString() ?? response.Content;
                }

                if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
                    message = response.ErrorMessage;

                return new ApiClientResponse<T>
                {
                    StatusCode = response.StatusCode,
                    Message = message
                };
            }

            return new ApiClientResponse<T>
            {
                StatusCode = response.StatusCode,
                Content = JsonConvert.DeserializeObject<T>(response.Content)
            };
        }

        private static void AddHeaders(IRestRequest request, ApiClientParameterCollection headers)
        {
            if (headers == null) return;

            foreach (var header in headers)
                request.AddHeader(header.Key, header.Value);
        }

        private static void AddBody(IRestRequest request, object body)
        {
            if (body == null) return;

            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", body.ToString(), ParameterType.RequestBody);
        }

        private static void AddUrlSegments(IRestRequest request, ApiClientParameterCollection urlSegments)
        {
            if (urlSegments == null) return;

            foreach (var segment in urlSegments)
                request.AddUrlSegment(segment.Key, segment.Value);
        }

        private static void AddQueryParameters(IRestRequest request, ApiClientParameterCollection queryParameters)
        {
            if (queryParameters == null) return;

            foreach (var parameter in queryParameters)
                request.AddQueryParameter(parameter.Key, parameter.Value);
        }

        public static ApiClientParameterCollection CreateParameterCollection(string key, string value)
        {
            return new ApiClientParameterCollection { { key, value } };
        }
    }
}
