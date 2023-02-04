using API_forXmlDoc.XmlDocumentClasses;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace API_forXmlDoc.Service
{
    public class GetXmlDocumentValues
    {
        public static XmlDocResponse GetValues(XmlDocRequest request, string filePath)
        {

            
            var xmlDocResponse = new XmlDocResponse();
            
            if (System.IO.File.Exists(filePath) && Path.GetExtension(filePath) == ".xml")
            {
                // Test is true if you selected file path as well as right doc type
                xmlDocResponse.TestPassed = true;

                // Defining witch xml document is going to be used
                XmlDocument docXML = new XmlDocument();
                docXML.Load(filePath);

                // Selection of nodeList that is going to be used
                XmlNodeList xmlNodeListMeasurementChannels = docXML.SelectNodes("//MeasurementChannels/MeasurementChannel");

                // Getting Text from TestResultId
                var xmlNodeListTestResultId = docXML.SelectSingleNode("//Trainging/TestResultId").InnerText;
                xmlDocResponse.TestResultId = Convert.ToInt32(xmlNodeListTestResultId);

                // Displaying all TestResult values of each MeasurementChannel
                #region Displaying all values from xml file

                for (int i = 0; i < request.ChannelRequest.Count; i++)
                {
                    foreach (XmlNode node in xmlNodeListMeasurementChannels)
                    {
                        var xmlDocResponseAdd = new MeasurementChannel();
                        var nodeAtribut = node.Attributes.GetNamedItem("ChannelName").Value.ToString();
                        if (request.ChannelRequest[i].ChannelName.ToLower() == nodeAtribut.ToLower())
                        {
                            // If you wrote "channelName" that exists than response gets back that name
                            xmlDocResponseAdd.ChannelName = nodeAtribut;

                            // Calling methode that checks if the Test Results are true or false
                            xmlDocResponseAdd.TestResult = GetReilhoferResult(request.ChannelRequest[i].GetTestResult, node.SelectSingleNode("TestResult").InnerText, xmlDocResponseAdd.TestResult);
                            xmlDocResponseAdd.SpectralAnalysisResult = GetReilhoferResult(request.ChannelRequest[i].GetKurtosisResult, node.SelectSingleNode("SpectralAnalysis/TestResult").InnerText, xmlDocResponseAdd.SpectralAnalysisResult);
                            if (request.ChannelRequest[i].GetSpectralAnalysisResult == true && node.SelectSingleNode("SpectralAnalysis/Peak") != null)
                            {
                                xmlDocResponseAdd.Peak = Convert.ToInt32(node.SelectSingleNode("SpectralAnalysis/Peak").InnerText);
                                xmlDocResponseAdd.KurtosisResult = GetReilhoferResult(request.ChannelRequest[i].GetSpectralAnalysisResult, node.SelectSingleNode("Kurtosis/TestResult").InnerText, xmlDocResponseAdd.KurtosisResult);
                            }
                            xmlDocResponse.MeasurementChannel.Add(xmlDocResponseAdd);

                            // Getting back orderTrackDefinition List that with requested numbers!
                            if (request.ChannelRequest[i].GetOrderTrackDefinitionResult == true)
                            {
                                GetOrderTrackDefinitions(node, request, xmlDocResponse, i);
                            }
                        }
                    }
                }
                #endregion
            }
            return xmlDocResponse;
        }

        public static bool GetReilhoferResult(bool testResult, string selectedNode, bool xmlDocResponseAdd)
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

        public static XmlDocResponse GetOrderTrackDefinitions(XmlNode node, XmlDocRequest request, XmlDocResponse xmlDocResponse, int i)
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
