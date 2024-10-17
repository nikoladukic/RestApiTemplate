using RestApiTemplate.CommandResponse;
using RestApiTemplate.Controllers;
using RestApiTemplate.Models.Domain;
using RestApiTemplate.Models.DTO;

namespace RestApiTemplate.BussinesLogic.Interface
{
    public interface IRestApiTemplateBussinesLogic
    {
        Task<List<Fakultet>> GetInformtionAboutFakultet();
        Task<CommandResponse<Fakultet>> GetFakultetById(int id);
        Task<CommandResponse<Fakultet>> InsertNewFakultet(AddNewFakultet fakultet);
    }
}
