﻿using Microsoft.AspNetCore.Mvc;
using RestApiTemplate.BussinesLogic.Interface;
using RestApiTemplate.Models.Domain;
using RestApiTemplate.Models.DTO;

namespace RestApiTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MestoController : Controller
    {
        private readonly IRestApiTemplateBussinesLogic _apiTemplateBussinesLogic;
        private readonly ILogger<FakultetController> _logger;


        public MestoController(IRestApiTemplateBussinesLogic apiTemplateBussinesLogic, ILogger<FakultetController> logger)
        {
            _apiTemplateBussinesLogic = apiTemplateBussinesLogic;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMesta()
        {

            var mesta = await _apiTemplateBussinesLogic.GetAllMesta();
            return Ok(mesta);

        }

        [HttpPost]
        public async Task<IActionResult> InsertNewMesto([FromBody] Mesto mesto)
        {
            var response = await _apiTemplateBussinesLogic.InsertNewMesto(mesto);
            if (response.StatusCode == 200)
                return Ok(response);
            else
                return StatusCode(response.StatusCode, response.Message);
        }
    }
}
