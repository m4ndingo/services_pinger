namespace Pinger
{
    public class ServiceConfig
    {
        public ServiceConfig()
        {
        }

        public bool ssl { get; set; }
        public bool hide_button { get; internal set; }
        public string closed_tip { get; internal set; }
        public string closed_cmd { get; internal set; }
        public string[] closed_instructions { get; internal set; }
        public string closed_url { get; internal set; }
    }
}
