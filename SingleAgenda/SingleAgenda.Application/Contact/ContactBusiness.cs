using Microsoft.EntityFrameworkCore;
using SingleAgenda.Application.Base;
using SingleAgenda.Dtos.Contact;
using SingleAgenda.Dtos.Location;
using SingleAgenda.Dtos.Messages;
using SingleAgenda.EFPersistence.Configuration;
using SingleAgenda.EFPersistence.Repositories;
using SingleAgenda.Entities.Contact;
using SingleAgenda.Entities.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleAgenda.Application.Contact
{
    public class ContactBusiness
        : IBusiness
    {

        private readonly PersonRepository _personRepository;
        private readonly UserRepository _addressRepository;

        public ContactBusiness(PersonRepository personRepository,
            UserRepository addressRepository)
        {
            this._personRepository = personRepository;
            this._addressRepository = addressRepository;
        }

        public IEnumerable<PersonDto> ListAllAsync(PersonSearchParameter personSearchParameter)
        {
            return this._personRepository.All
                .Where(p => p.Removed == personSearchParameter.ShowRemoved)
                .Select(p => new PersonDto()
                {
                    Birthday = p.Birthday,
                    Document = p.Document,
                    Gender = p.Gender,
                    Id = p.Id,
                    Name = p.Name,
                    PersonType = p.PersonType,
                    TradeName = p.TradeName,
                    Email = p.Email,
                    CreatedAt = p.CreatedAt,
                    Removed = p.Removed
                })
                .ToArray();
        }

        public async Task<PersonDto> GetByIdAsync(int id)
        {
            var person = await this._personRepository.All
                .Include(p => p.Addresses)
                .Where(p => p.Id == id)
                .Select(p => new PersonDto()
                {
                    Birthday = p.Birthday,
                    Document = p.Document,
                    Gender = p.Gender,
                    Id = p.Id,
                    Name = p.Name,
                    PersonType = p.PersonType,
                    TradeName = p.TradeName,
                    Email = p.Email,
                    CreatedAt = p.CreatedAt,
                    Removed = p.Removed
                })
                .SingleOrDefaultAsync();

            return person;
        }

        public async Task<ResultDto> CreateAsync(PersonDto person)
        {
            var result = new ResultDto();
            if (!await this.EnsureNotExistsAsync(person))
            {
                try
                {
                    var newPerson = PopulateThePersonEntityFromDto(person);
                    result.InsertedId = await this._personRepository.AddAsync(newPerson);
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Messages.Add(ex.ToString());
                }
            }
            else
                result.Messages.Add("Not allowed to insert. Register duplicated.");

            return result;
        }

        public async Task<ResultDto> UpdateAsync(PersonDto person)
        {
            var result = new ResultDto();
            if (!await this.EnsureNotExistsAsync(person))
            {
                try
                {
                    var currentPerson = await this._personRepository.All
                        .Include(p => p.Addresses)
                        .Where(p => p.Id == person.Id)
                        .FirstOrDefaultAsync();

                    PopulateThePersonForEdit(person, currentPerson);
                    await this._personRepository.UpdateAsync(currentPerson);
                }
                catch (Exception ex)
                {
                    result.Messages.Add(ex.ToString());
                }
            }
            else
                result.Messages.Add("Not allowed to update. Register duplicated.");

            return result;
        }

        public async Task<ResultDto> DeleteAsync(int id)
        {
            var result = new ResultDto();

            try
            {
                var currentPerson = await this._personRepository.All
                    .Where(fr => fr.Id == id)
                    .FirstOrDefaultAsync();

                if (currentPerson != null)
                    await this._personRepository.DeleteAsync(currentPerson);
                else
                    result.Messages.Add("Not found");
            }
            catch (Exception ex)
            {
                result.Messages.Add(ex.ToString());
            }

            return result;
        }

        #region Private Methods

        private Person PopulateThePersonEntityFromDto(PersonDto dto)
        {
            var person = new Person()
            {
                Birthday = dto.Birthday,
                Document = dto.Document,
                Gender = dto.Gender,
                Name = dto.Name,
                Email = dto.Email,
                PersonType = dto.PersonType,
                Id = dto.Id,
                TradeName = dto.TradeName,
                Addresses = dto.Addresses
                    .Select(ad => new Address()
                    {
                        City = ad.City,
                        Country = ad.Country,
                        Description = ad.Description,
                        PersonId = ad.PersonId,
                        State = ad.State,
                        ZipCode = ad.ZipCode
                    }).ToList()
            };

            return person;
        }

        private void PopulateThePersonForEdit(PersonDto dto, Person currentPerson)
        {
            currentPerson.Birthday = dto.Birthday;
            currentPerson.Document = dto.Document;
            currentPerson.Gender = dto.Gender;
            currentPerson.Name = dto.Name;
            currentPerson.Email = dto.Email;
            currentPerson.PersonType = dto.PersonType;
            currentPerson.Id = dto.Id;
            currentPerson.TradeName = dto.TradeName;

            dto.Addresses
                .ForEach(ad => IncludeAddresses(ad, currentPerson.Addresses));
             
            if (dto.Id > 0)
                currentPerson.UpdatedAt = DateTime.Now;
        }

        private void IncludeAddresses(AddressDto dto, List<Address> current)
        {
            var address = new Address();
            address.City = dto.City;
            address.Country = dto.Country;
            address.Description = dto.Description;
            address.PersonId = dto.PersonId;
            address.State = dto.State;
            address.ZipCode = dto.ZipCode;
            current.Add(address);
        }

        private async Task<bool> EnsureNotExistsAsync(PersonDto person)
        {
            return await this._personRepository.All.AnyAsync(p =>
                p.Id != person.Id &&
                p.Name == person.Name &&
                p.Document == person.Document);
        }

        #endregion

    }
}
