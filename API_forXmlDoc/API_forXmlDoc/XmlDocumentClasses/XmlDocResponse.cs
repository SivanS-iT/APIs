namespace API_forXmlDoc.XmlDocumentClasses
{
    public class XmlDocResponse
    {
        public bool TestPassed { get; set; }
        public int TestResultId { get; set; }
        public List<MeasurementChannel> MeasurementChannel { get; set; }

        public XmlDocResponse()
        {
            this.MeasurementChannel = new List<MeasurementChannel>();

        }
    }

    public class MeasurementChannel
    {
        public string ChannelName { get; set; }
        public bool TestResult { get; set; }
        public bool SpectralAnalysisResult { get; set; }
        public int Peak { get; set; }
        public bool KurtosisResult { get; set; }
        public List<OrderTrackDefinition> OrderTrackDefinition { get; set; }
        public MeasurementChannel()
        {
            this.OrderTrackDefinition = new List<OrderTrackDefinition>();
        }
    }

    public class OrderTrackDefinition
    {
        public string OrderTrackDefinitionName { get; set; }
        public bool OrderTrackDefinitionResultOk { get; set; }
    }
}
