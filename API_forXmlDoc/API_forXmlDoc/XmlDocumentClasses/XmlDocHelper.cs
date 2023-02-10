using System.Xml;

namespace API_forXmlDoc.XmlDocumentClasses
{
    public class XmlDocHelper
    {
        public bool GetReilhoferResult(bool testResult, string selectedNode, bool xmlDocResponseAdd)
        {
            // getKurtosisResult
            if (testResult == true)
            {
                if (selectedNode.Contains("Failed"))
                    xmlDocResponseAdd = false;
                else xmlDocResponseAdd = true;
            }
            else xmlDocResponseAdd = false;

            return xmlDocResponseAdd;
        }

        public XmlDocResponse GetOrderTrackDefinitions(XmlNode node, XmlDocRequest request, XmlDocResponse xmlDocResponse, int i)
        {
            // Getting back orderTrackDefinition List that with requested numbers!
            XmlNodeList orderTrackingDefinicions = node.SelectNodes("OrderTracking/OrderTrackDefinition");

            for (int j = 0; j < request.ChannelRequest[i].GetOrderTrackDefinitionResultByName.Count; j++)
            {
                foreach (XmlNode nodeOrderTrack in orderTrackingDefinicions)
                {
                    var orderTrackDefinitionList = new OrderTrackDefinition();

                    string nameOrderTrack = nodeOrderTrack.SelectSingleNode("Name").InnerText.ToString();
                    string requestNameOrderTrack = request.ChannelRequest[i].GetOrderTrackDefinitionResultByName[j].ToString();

                    // Checking if the "getOrderTrackDefinitionResultByName" has same value as JSON int
                    if (nameOrderTrack == requestNameOrderTrack && request.ChannelRequest[i].GetOrderTrackDefinitionResult == true)
                    {
                        orderTrackDefinitionList.OrderTrackDefinitionName = nameOrderTrack;
                        if (nodeOrderTrack.SelectSingleNode("TestResult").InnerText.Contains("Failed"))
                            orderTrackDefinitionList.OrderTrackDefinitionResultOk = false;
                        else orderTrackDefinitionList.OrderTrackDefinitionResultOk = true;

                        xmlDocResponse.MeasurementChannel[i].OrderTrackDefinition.Add(orderTrackDefinitionList);

                    }
                }
            }
            return xmlDocResponse;
        }
    }
}
