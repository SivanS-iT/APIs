using API_forXmlDoc.Service;
using API_forXmlDoc.XmlDocumentClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_forXmlDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XmlDocumentController : ControllerBase
    {
        #region Currently I am not goint to be using this endpoints just POST (For the sake of training)
        // GET: api/<XmlDocumentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<XmlDocumentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<XmlDocumentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<XmlDocumentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion

        private readonly ILogger<XmlDocumentController> _logger;

        public XmlDocumentController(ILogger<XmlDocumentController> logger)
        {
            _logger = logger;
        }

        // POST api/<XmlDocumentController>
        [HttpPost("Test")]
        public async Task<ActionResult<XmlDocResponse>> PostTest(XmlDocRequest request, string filePath)
        {

            _logger.LogInformation($"ReilhoferRequest called - {request}");
            try
            {
                var response = GetXmlDocumentValues.GetValues(request, filePath);
                _logger.LogInformation($"PostTestAsync finished - {response}");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateProduct failed");
                return BadRequest();
            }

        }
    }
}
