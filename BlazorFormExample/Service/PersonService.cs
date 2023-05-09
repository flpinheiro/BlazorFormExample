using BlazorFormExample.Exceptions;
using BlazorFormExample.ViewModels;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorFormExample.Service
{
    public class PersonService : IPersonService
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<PersonService> logger;

        public PersonService( ILogger<PersonService> logger)
        {
            this.httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7189/"),
            };

            this.logger = logger;
        }

        public async Task<IEnumerable<PersonViewModel>> GetPeople()
        {
            logger.LogInformation("receive people data from the api");
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://localhost:7189/api/person"),
            };
            var response = await httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode) { return Enumerable.Empty<PersonViewModel>(); }
            var responseStream = await response.Content.ReadAsStreamAsync();
            var people = await JsonSerializer.DeserializeAsync<IEnumerable<PersonViewModel>>(responseStream);
            await Task.Delay(100);
            return new List<PersonViewModel>()
            {
                new ()
                {
                    Id = "test",
                    Name = "Test",
                    Email = "test@tes.com",
                    Surname = "Test",
                    Gender = Enums.Gender.Male,
                },
                new ()
                {
                    Id = "test2",
                    Name = "Test 2",
                    Email = "test2@tes.com",
                    Surname = "Test 2",
                    Gender = Enums.Gender.Female,
                }
            };
        }

        public async Task SubmitPerson(PersonViewModel person)
        {
            await Task.Delay(100);
            if (person is null)
            {
                logger.LogInformation("invalid data passed to the sistem");
                throw new InvalidPersonException();
            }
            if (person.Id is null)
            {
                logger.LogInformation("save a new person to the api");
            }
            else
            {
                logger.LogInformation("update a person at the api");
            }
        }
    }
}
