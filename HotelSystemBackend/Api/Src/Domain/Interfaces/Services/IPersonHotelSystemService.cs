using Api.Src.Infra.Data.Entities;
using System;

namespace Api.Src.Domain.Interfaces.Services
{
    public interface IPersonHotelSystemService
    {
        Task<List<Person>> GetAll();
        Task<Person> GetByName(Person namePerson);
        Task<Person> NewPerson(Person person);
        Task<Person> ChangePerson(Person person);
        Task<Person> DeletePerson(Person namePerson);
    }
}
