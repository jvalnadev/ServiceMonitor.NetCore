﻿using System;
using System.Threading.Tasks;

namespace ServiceMonitor.Common
{
    public class HttpRequestWatcher : IWatcher
    {
        public String ActionName
            => "HttpRequest";
        
        public async Task<WatchResponse> WatchAsync(WatcherParameter parameter)
        {
            var response = new WatchResponse();

            try
            {
                var restClient = new RestClient();

                await restClient.GetAsync(parameter.Values["Url"]);

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.StackTrace = ex.ToString();
            }

            return response;
        }
    }
}
