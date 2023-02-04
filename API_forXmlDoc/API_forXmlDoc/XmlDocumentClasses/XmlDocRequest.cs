namespace API_forXmlDoc.XmlDocumentClasses
{
    public class XmlDocRequest
    {
        public string FilePath { get; set; }
        public List<ChannelRequest> ChannelRequest { get; set; }

        public XmlDocRequest()
        {
            this.ChannelRequest = new List<ChannelRequest>();
        }
    }

    public class ChannelRequest
    {
        public string ChannelName { get; set; }
        public bool GetTestResult { get; set; }
        public bool GetSpectralAnalysisResult { get; set; }
        public bool GetKurtosisResult { get; set; }
        public bool GetOrderTrackDefinitionResult { get; set; }
        public List<int> GetOrderTrackDefinitionResultByName { get; set; }

        public ChannelRequest()
        {
            this.GetOrderTrackDefinitionResultByName = new List<int>();
        }
    }
}
