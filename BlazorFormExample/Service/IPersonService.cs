using BlazorFormExample.ViewModels;

namespace BlazorFormExample.Service
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonViewModel>> GetPeople();
        Task SubmitPerson(PersonViewModel person);
    }
}