using Newtonsoft.Json;
using OrderingAPI.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static OrderingAPI.Model.Responce;

namespace OrderingAPI.Model
{
    public class Headers
    {
        [System.ComponentModel.DisplayName("content-type")]
        [JsonProperty("content-type")]
        public string ContentType { get; set; }

        public string x_api_token { get; set; }
    }

    public class WebHookRequest
    {
        public bool active { get; set; }
        public string event_type { get; set; }
        public string retrial_interval_units { get; set; }

        [Required]
        public string url { get; set; }

        public Headers headers { get; set; }
    }

    public class Meta
    {
        public int limit { get; set; }
        public object next { get; set; }
        public int offset { get; set; }
        public object previous { get; set; }
        public int total_count { get; set; }
    }

    public class WebHook
    {
        public bool active { get; set; }
        public WebHookEvent? event_type { get; set; }
        public string headers { get; set; }
        public string retrial_interval_units { get; set; }
        public string url { get; set; }
        public int webhook_id { get; set; }
    }

    public class WebHooks
    {
        public Meta meta { get; set; }
        public List<WebHook> webhooks { get; set; }
    }

    public class WebHookGetResponce : HttpResponce
    {
        public WebHook webhook { get; set; }
    }

    public class WebHookGetAllResponce : HttpResponce
    {
        public WebHooks webhooks { get; set; }
    }

}