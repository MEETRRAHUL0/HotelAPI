namespace OrderingAPI.Model
{
    public class Responce
    {
        public class HttpErrorResponce
        {
            public string status { get; set; }
            public string message { get; set; }
        }

        public class HttpResponce
        {
            public string HttpStatusCode { get; set; }
            public bool Status { get; set; }
            public string HttpMessage { get; set; }

            public object result { get; set; }
        }
        public class ConfigurationResponce
        {
            public string status { get; set; }
            public string message { get; set; }
            public string reference { get; set; }
        }

        // Put and Post webhook Responce
        public class WebHookResponce
        {
            public string status { get; set; }
            public string message { get; set; }
            public int webhook_id { get; set; }
        }
    }
}