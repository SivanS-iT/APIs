using API_forXmlDoc.XmlDocumentClasses;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace API_forXmlDoc.Service
{
    public class GetXmlDocumentValues
    {
        private readonly ILogger<GetXmlDocumentValues> logger;
        private readonly XmlDocHelper helper;
        public GetXmlDocumentValues( XmlDocHelper helper, ILogger<GetXmlDocumentValues> logger)
        {
            this.helper = helper;
            this.logger = logger;
        }

        public XmlDocResponse GetValues(XmlDocRequest request, string filePath)
        {
            var xmlDocResponse = new XmlDocResponse();
            
            if (System.IO.File.Exists(filePath) && Path.GetExtension(filePath) == ".xml")
            {
                // Test is true if you selected file path as well as right doc type
                xmlDocResponse.TestPassed = true;

                // Defining witch xml document is going to be used
                XmlDocument docXML = new XmlDocument();
                docXML.Load(filePath);

                // Getting GetTestResultId
                helper.GetTestResultId(docXML, xmlDocResponse);

                // Getting all MeasurementChannel results
                helper.GetAllTestResultInMeasurementChannel(request, docXML, xmlDocResponse);
            }
            return xmlDocResponse;
        }

       
    }
}
