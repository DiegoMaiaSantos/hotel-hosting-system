using Api.Src.Domain.Interfaces.Repositories;
using Api.Src.Domain.Interfaces.Services;
using Api.Src.Infra.Data.Entities;
using Api.Src.Application.Errors;
using Serilog;
using System;

namespace Api.Src.Services
{
    public class PersonHotelSystemService : IPersonHotelSystemService
    {
        private readonly IPersonHotelSystemRepository _personHotelSystemRepository;

        public PersonHotelSystemService(IPersonHotelSystemRepository personHotelSystemRepository)
        {
            _personHotelSystemRepository = personHotelSystemRepository;
        }

        public async Task<List<Person>> GetAll()
        {
            try
            {
                List<Person> result = await _personHotelSystemRepository.FindAll();

                if (result == null)
                    throw new AppException("A lista de pessoas não foi encontrada no sistema.", 
                        StatusCodes.Status404NotFound);

                return result;
            }
            catch(Exception ex)
            {
                Log.Error($"Erro ao executar serviço que mostra lista de pessoas: {ex.Message}");
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Person> GetByName(Person namePerson)
        {
            try
            {
                Person result = await _personHotelSystemRepository.FindByName(namePerson.Name);

                if (result.Name == null || result.CPF == null)
                    throw new AppException($"O nome: {namePerson} não existe no sistema.", 
                        StatusCodes.Status404NotFound);

                return result;
            }
            catch (Exception ex)
            {
                Log.Error($"Erro ao executar serviço que mostra a pessoa pelo nome: {ex.Message}");
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Person> NewPerson(Person person)
        {
            try
            {
                Person result = await _personHotelSystemRepository.FindByName(person.Name);

                if (result.Name == person.Name)
                    throw new AppException($"O nome: {person.Name} informado já existe em nosso sistema", 
                        StatusCodes.Status409Conflict);

                string? cpfBefore = person.CPF;
                string? formattedCpf = string.Format(@"{0:000\.000\.000\-00}", cpfBefore);
                person.CPF = formattedCpf;

                if (result.CPF == person.CPF)
                    throw new AppException($"O CPF: {person.CPF} informado já existe em nosso sistema",
                        StatusCodes.Status409Conflict);

                result = await _personHotelSystemRepository.RegisterPerson(person);

                if (result == null)
                    throw new AppException("Solicitação para criar novo cadastro inválida.",
                        StatusCodes.Status400BadRequest);

                return result;

            }
            catch (Exception ex)
            {
                Log.Error($"Erro ao executar serviço que registra uma pessoa no sistema: {ex.Message}");
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Person> ChangePerson(Person person)
        {
            try
            {
                Person result = await _personHotelSystemRepository.FindByName(person.Name);                

                if (result.Name != person.Name && result.CPF != person.CPF)
                    throw new AppException($"O nome: {person.Name} informado não existe em nosso sistema",
                        StatusCodes.Status404NotFound);

                person.Name = result.Name ?? person.Name;
                person.CPF = result.CPF ?? person.CPF;
                person.HostedSuiteId = result.HostedSuiteId ?? person.HostedSuiteId;

                return await _personHotelSystemRepository.UpdatePerson(result);
            }
            catch (Exception ex)
            {
                Log.Error($"Erro ao executar serviço que atualiza os dados da pessoa: {ex.Message}");
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Person> DeletePerson(Person namePerson)
        {
            try
            {
                Person result = await _personHotelSystemRepository.FindByName(namePerson.Name);

                if (result.Name != namePerson.Name && result.CPF != namePerson.CPF)
                    throw new AppException($"O nome: {person.Name} informado não existe em nosso sistema",
                        StatusCodes.Status404NotFound);

                return await _personHotelSystemRepository.DeleteByName(namePerson.Name);

            }
            catch (Exception ex)
            {
                Log.Error($"Erro ao executar serviço que deleta uma pessoa do sistema: {ex.Message}");
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
