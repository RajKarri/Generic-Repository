using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

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

        public static object Make()
        {
            IRestResponse<object> response = Execute();
            return JsonConvert.DeserializeObject<object>(response.Content);
        }

        public static object Make(
                             IDictionary<string, string> parameters = null,                             
                             IDictionary<string, string> headers = null,
                             IDictionary<string, string> urlSegments = null,
                             object objectForUri = null,
                             object objectForBody = null,
                             object objectForJsonBody = null)
        {
            SetRequest(parameters, headers, urlSegments, objectForUri, objectForBody, objectForJsonBody);
            object response = Make();
            return response;
        }

        public static object MakeAsync()
        {
            IRestResponse<object> response = ExecuteAsync();
            return JsonConvert.DeserializeObject<object>(response.Content);
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

        public static TResponse Make<TResponse>() where TResponse : new()
        {
            IRestResponse<object> response = Execute();
            return JsonConvert.DeserializeObject<TResponse>(response.Content);
        }

        public static TResponse Make<TResponse>(
                                IDictionary<string, string> parameters = null,
                                IDictionary<string, string> headers = null,
                                IDictionary<string, string> urlSegments = null,                                
                                object objectForUri = null,
                                object objectForBody = null,
                                object objectForJsonBody = null)
                                where TResponse : new()
        {
            SetRequest(parameters, headers, urlSegments, objectForUri, objectForBody, objectForJsonBody);
            TResponse response = Make<TResponse>();
            return response;
        }

        public static TResponse MakeAsync<TResponse>() where TResponse : new()
        {
            IRestResponse<object> response = ExecuteAsync();
            return JsonConvert.DeserializeObject<TResponse>(response.Content);
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

            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }

            if (urlSegments != null)
            {
                foreach (KeyValuePair<string, string> segment in urlSegments)
                {
                    request.AddUrlSegment(segment.Key, segment.Value);
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

        private static IRestResponse<object> Execute()
        {
            try
            {
                if (client == null || request == null)
                {
                    throw new Exception("Initialize method call must happen before this call");
                }

                IRestResponse<object> response = client.Execute<object>(request);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Bad request", ex);
            }
        }

        private static IRestResponse<object> ExecuteAsync()
        {
            try
            {
                if (client == null || request == null)
                {
                    throw new Exception("Initialize method call must happen before this call");
                }

                var response = client.ExecuteTaskAsync<object>(request);
                return response.Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Bad request", ex);
            }
        }
    }
}
