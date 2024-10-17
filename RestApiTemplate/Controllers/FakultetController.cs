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
                return StatusCode(response.StatusCode, response.Message);
        }

        [HttpDelete] 
        public async Task<IActionResult> DeleteFakultet([FromQuery] long id)
        {
            var response = await _apiTemplateBussinesLogic.DeleteFakultetById(id);
            if (response.StatusCode == 200)
                return Ok(response);
            else
                return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateFakultet(long id,[FromBody] UpdateFakultet fakultet)
        {
            var response = await _apiTemplateBussinesLogic.UpdateFakultet(id,fakultet);
            if (response.StatusCode == 200)
                return Ok(response);
            else
                return StatusCode(response.StatusCode, response.Message);
        }

    }
}
