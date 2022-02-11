using Microsoft.EntityFrameworkCore;
using SingleAgenda.Application.Base;
using SingleAgenda.Dtos.Contact;
using SingleAgenda.Dtos.Location;
using SingleAgenda.Dtos.Messages;
using SingleAgenda.EFPersistence.Configuration;
using SingleAgenda.Entities.Contact;
using SingleAgenda.Entities.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleAgenda.Application.Contact
{
    public class ContactBusiness
        : BusinessBase
    {

        #region Constructor

        public ContactBusiness(SingleAgendaDbContext context)
            : base(context)
        {
        }

        #endregion

        #region Public Methods

        public IEnumerable<PersonDto> ListAllAsync(PersonSearchParameter personSearchParameter)
        {
            return this.dbContext.Persons
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
            var person = await this.dbContext.Persons
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

            if (person != null)
            {
                person.Addresses = this.dbContext.Addresses
                    .Where(ad => ad.PersonId == person.Id)
                    .Select(ad => new AddressDto()
                    {
                        ZipCode = ad.ZipCode,
                        City = ad.City,
                        Country = ad.Country,
                        Description = ad.Description,
                        State = ad.State
                    })
                    .ToList();
            }

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
                    this.dbContext.Persons.Add(newPerson);
                    result.InsertedId = await this.dbContext.SaveChangesAsync();
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
                    var currentPerson = await this.dbContext.Persons
                        .Include(p => p.Addresses)
                        .Where(p => p.Id == person.Id)
                        .FirstOrDefaultAsync();

                    if (currentPerson != null)
                    {
                        this.dbContext.Addresses
                            .RemoveRange(currentPerson.Addresses);

                        PopulateThePersonForEdit(person, currentPerson);
                        await this.dbContext.SaveChangesAsync();
                        result.Success = true;
                    }
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
                var currentPerson = await this.dbContext.Persons
                    .Where(fr => fr.Id == id)
                    .FirstOrDefaultAsync();

                if (currentPerson != null)
                {
                    currentPerson.UpdatedAt = DateTime.Now;
                    currentPerson.Removed = true;
                    await this.dbContext.SaveChangesAsync();
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                result.Messages.Add(ex.ToString());
            }

            return result;
        }

        #endregion

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
            return await this.dbContext.Persons.AnyAsync(p =>
                p.Id != person.Id &&
                p.Name == person.Name &&
                p.Document == person.Document);
        }

        #endregion

    }
}
