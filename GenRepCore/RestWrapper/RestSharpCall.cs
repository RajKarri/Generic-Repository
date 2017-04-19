using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace RestWrapper
{
    public static class RestSharpCall
    {
        private static IRestClient client;
        private static IRestRequest request;

        public static void Init(string url, RestSharpMethod method)
        {
            client = new RestClient(url);
            request = new RestRequest((Method)Enum.Parse(typeof(Method), method.ToString()));
        }

        public static object MakeAsync()
        {
            var response = ExecuteAsync();
            var res = (RestResponse)response.Result;

            if (res.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<object>(res.ToString());
            }
            else
                throw new Exception(res.Content);
        }

        public static object MakeAsync(
                             IDictionary<string, string> parameters = null,
                             IDictionary<string, string> headers = null,
                             IDictionary<string, string> urlSegments = null,
                             object objectForUri = null,
                             object objectForBody = null,
                             object objectForJsonBody = null)
        {
            SetRequest(parameters, headers, urlSegments, objectForUri, objectForBody, objectForJsonBody);
            object response = MakeAsync();
            return response;
        }

        public static TResponse MakeAsync<TResponse>() where TResponse : new()
        {
            var response = ExecuteAsync();
            var res = (RestResponse)response.Result;

            if (res.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<TResponse>(res.Content);
            }
            else
                throw new Exception(res.Content);
        }

        public static TResponse MakeAsync<TResponse>(
                                IDictionary<string, string> parameters = null,
                                IDictionary<string, string> headers = null,
                                IDictionary<string, string> urlSegments = null,
                                object objectForUri = null,
                                object objectForBody = null,
                                object objectForJsonBody = null)
                                where TResponse : new()
        {
            SetRequest(parameters, headers, urlSegments, objectForUri, objectForBody, objectForJsonBody);
            TResponse response = MakeAsync<TResponse>();
            return response;
        }

        private static void SetRequest(
                            IDictionary<string, string> parameters,
                            IDictionary<string, string> headers,
                            IDictionary<string, string> urlSegments,
                            object objectForUri,
                            object objectForBody,
                            object objectForJsonBody)
        {
            if (parameters != null)
            {
                foreach (KeyValuePair<string, string> param in parameters)
                {
                    request.AddParameter(param.Key, param.Value);
                }
            }

            if (urlSegments != null)
            {
                foreach (KeyValuePair<string, string> segment in urlSegments)
                {
                    request.AddUrlSegment(segment.Key, segment.Value);
                }
            }

            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }

            if (objectForUri != null)
            {
                request.AddObject(objectForUri);
            }

            if (objectForBody != null)
            {
                request.AddBody(objectForBody);
            }

            if (objectForJsonBody != null)
            {
                request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(objectForJsonBody), ParameterType.RequestBody);
                request.RequestFormat = DataFormat.Json;
            }
        }

        private static Task<object> ExecuteAsync()
        {
            try
            {
                var completionTask = new TaskCompletionSource<object>();

                if (client == null || request == null)
                {
                    throw new Exception("Initialize method call must happen before this call");
                }

                client.ExecuteAsync(request, response =>
                {
                    completionTask.SetResult(response);
                });

                return completionTask.Task;
            }
            catch (Exception ex)
            {
                throw new Exception("Bad request", ex);
            }
        }
    }
}
