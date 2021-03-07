using Microsoft.EntityFrameworkCore;
using SingleAgenda.Application.Base;
using SingleAgenda.Dtos.Contact;
using SingleAgenda.Dtos.Messages;
using SingleAgenda.Entities.Contact;
using SingleAgenda.Entities.Location;
using SingleAgenda.Infra.Configuration;
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

        public async Task<IEnumerable<PersonDto>> ListAllAsync()
        {
            return await this.dbContext.Persons
                .Select(p => new PersonDto()
                {
                    Birthday = p.Birthday,
                    Document = p.Document,
                    Gender = p.Gender,
                    Id = p.Id,
                    Name = p.Name,
                    PersonType = p.PersonType,
                    TradeName = p.TradeName
                })
                .ToArrayAsync();
        }

        public async Task<PersonDto> GetByIdAsync(int id)
        {
            return await this.dbContext.Persons
                .Where(p => p.Id == id)
                .Select(p => new PersonDto()
                {
                    Birthday = p.Birthday,
                    Document = p.Document,
                    Gender = p.Gender,
                    Id = p.Id,
                    Name = p.Name,
                    PersonType = p.PersonType,
                    TradeName = p.TradeName
                })
                .SingleOrDefaultAsync();
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

                        currentPerson = PopulateThePersonEntityFromDto(person);
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

            if (dto.Id > 0)
                person.UpdatedAt = DateTime.Now;

            return person;
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
