using RestApiTemplate.CommandResponse;
using RestApiTemplate.Controllers;
using RestApiTemplate.Models.Domain;
using RestApiTemplate.Models.DTO;

namespace RestApiTemplate.BussinesLogic.Interface
{
    public interface IRestApiTemplateBussinesLogic
    {
        Task<List<Fakultet>> GetInformtionAboutFakultet();
        Task<CommandResponse<Fakultet>> GetFakultetById(long id);
        Task<CommandResponse<Fakultet>> InsertNewFakultet(AddNewFakultet fakultet);
        Task<CommandResponse<Fakultet>> DeleteFakultetById(long id);
        Task<CommandResponse<Fakultet>> UpdateFakultet(long id, UpdateFakultet fakultet);
    }
}
