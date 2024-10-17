using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiTemplate.BussinesLogic.Interface;
using RestApiTemplate.Models.Domain;
using RestApiTemplate.Models.DTO;

namespace RestApiTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakultetController : ControllerBase
    {
        private readonly IRestApiTemplateBussinesLogic _apiTemplateBussinesLogic;
        private readonly ILogger<FakultetController> _logger;

     
        public FakultetController(IRestApiTemplateBussinesLogic apiTemplateBussinesLogic, ILogger<FakultetController> logger)
        {
            _apiTemplateBussinesLogic = apiTemplateBussinesLogic;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetFakultet()
        {
           
            var fakulteti = await _apiTemplateBussinesLogic.GetInformtionAboutFakultet();
            return Ok(fakulteti);
            
        }

        [HttpPost]
        public async Task<IActionResult> InsertNewFakultet([FromBody] AddNewFakultet fakultet)
        {
            var response = await _apiTemplateBussinesLogic.InsertNewFakultet(fakultet);
            if (response.StatusCode == 200)
                return Ok(response);
            else 
                return StatusCode (response.StatusCode,response.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetFakultetByID([FromQuery] long fakultetID)
        {

            var fakulteti = await _apiTemplateBussinesLogic.GetFakultetById();
            return Ok(fakulteti);

        }

    }
}
