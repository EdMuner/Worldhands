using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Worldhands.Web.Data
{

    public class SeeDb
   {
        private readonly DataContext _dataContext;

        public SeeDb(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckVisitorAsync();
        }

        private async Task CheckVisitorAsync()
        {
           if (!_dataContext.Visitors.Any())
            {
                AddVisitor("43155024", "Daniela", "Munera", "310 654 12 53");
                AddVisitor("71219844", "Alejandro", "Munera", "310 699 99 88");
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddVisitor(string document, string firstName, string lastName, string phoneNumber)
        {
            _dataContext.Visitors.Add(new Entities.Visitor
            {
                Document = document,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber
            });
        }
    }
}
