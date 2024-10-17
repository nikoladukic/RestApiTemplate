using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestApiTemplate.BussinesLogic.Interface;
using RestApiTemplate.CommandResponse;
using RestApiTemplate.Controllers;
using RestApiTemplate.Database;
using RestApiTemplate.Models.Domain;
using RestApiTemplate.Models.DTO;

namespace RestApiTemplate.BussinesLogic
{
    public class RestApiTemplateBussinesLogic : IRestApiTemplateBussinesLogic
    {
        private readonly RestApiTemplateDbContext _dbContext;
        private readonly ILogger<FakultetController> _logger;
        private readonly IMapper _mapper;


        public RestApiTemplateBussinesLogic(RestApiTemplateDbContext dbContext, ILogger<FakultetController> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

       

        public async Task<List<Fakultet>> GetInformtionAboutFakultet()
        {
            List<Fakultet> fakultets = null;
            try
            {
                 fakultets =  _dbContext.Fakultet.ToList();
                _logger.LogInformation("Response metode GetInformtionAboutFakultet {@fakultet}", fakultets);
            }
            catch (Exception ex)
            {
                _logger.LogError("Desila se greska pri izvrsavanju metode GetInformtionAboutFakultet {@error}", ex.StackTrace);
            }
            return fakultets;
        }
        
        public async Task<CommandResponse<Fakultet>> InsertNewFakultet(AddNewFakultet fakultet)
        {
            CommandResponse<Fakultet> response = new CommandResponse<Fakultet>(200,null,null);

            Fakultet newFakultet = _mapper.Map<Fakultet>(fakultet);
            newFakultet.FakultetId = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            try
            {
                if (fakultet != null)
                {
                    await _dbContext.Fakultet.AddAsync(newFakultet);
                    await _dbContext.SaveChangesAsync();
                    response.Body = newFakultet;
                    response.Message = "Uspesno dodat fakultet";
                    
                    
                }
            }
            catch (Exception ex)
            {
                
                _logger.LogError("Desila se greska u metodi InsertNewFakultet {@error}",ex.StackTrace);
                response.StatusCode = 500;
                response.Message = "Desila se greska u metodi InsertNewFakultet";
                response.Body = null;
            }

            return response;
        }

        public async Task<CommandResponse<Fakultet>> GetFakultetById(int id)
        {
            CommandResponse<Fakultet> response = new CommandResponse<Fakultet>(200, null, null);

            

            try
            {
                
                    await _dbContext.Database.ExecuteSqlAsync(_);
                    await _dbContext.SaveChangesAsync();
                    response.Body = newFakultet;
                    response.Message = "Uspesno dodat fakultet";


                
            }
            catch (Exception ex)
            {

                _logger.LogError("Desila se greska u metodi InsertNewFakultet {@error}", ex.StackTrace);
                response.StatusCode = 500;
                response.Message = "Desila se greska u metodi InsertNewFakultet";
                response.Body = null;
            }

            return response;
        }


    }
}
