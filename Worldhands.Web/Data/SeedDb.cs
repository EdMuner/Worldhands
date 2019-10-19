using System.Linq;
using System.Threading.Tasks;
using Worldhands.Web.Data.Entities;
using Worldhands.Web.Helpers;

namespace Worldhands.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;


        public SeedDb(DataContext context,
            IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }
        public async Task SeedAsync()
        {

            await _context.Database.EnsureCreatedAsync();
            await CheckRoles();
            var manager = await CheckUserAsync("71219843", "Edison", "Munera", "edisonmunera72@gmail.com", "314 718 79 53", "Manager");
            var visitor = await CheckUserAsync("43155024", "Daniela", "Munera", "danielamunera@gmail.com", "310 654 12 53", "Visitor");
            await CheckVisitorAsync(visitor);
            await CheckManagerAsync(manager);
        }

        private async Task CheckManagerAsync(User user)
        {
            if (!_context.Managers.Any())
            {
                _context.Managers.Add(new Manager { User = user });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Manager");
            await _userHelper.CheckRoleAsync("Visitor");
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
             string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Document = document,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);
            }

            return user;
        }
        private async Task CheckVisitorAsync(User user)
        {
            if (!_context.Visitors.Any())
            {
                _context.Visitors.Add(new Visitor { User = user });
                await _context.SaveChangesAsync();
            }
        }



    }
}
