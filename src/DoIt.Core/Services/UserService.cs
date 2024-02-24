using DoIt.Core.DTOs;
using DoIt.Core.Interfaces;
using DoIt.Core.Utilities;
using DoIt.Data.Context;
using DoIt.Data.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoIt.Core.Services
{
    public class UserService : IUserService
    {
        // Database context
        private readonly DoItDbContext _db;

        public UserService(DoItDbContext dbContext)
        {
            // Inject and initialize db context instance
            _db = dbContext;
        }

        public int RegisterUser(RegisterViewModel viewModel)
        {
            // Create new user by using view model data
            User user = new()
            {
                Name = viewModel.Name,
                Username = viewModel.Username.Trim(),
                Password = HashHelper.GetSha256(viewModel.Password)
            };

            // Add new user into database
            _db.Users.Add(user);
            return _db.SaveChanges();
        }

        public bool UsernameExist(string username)
        {
            // check usernames in database is match with input username 
            return _db.Users.Any(x => x.Username == username.Trim());
        }
    }
}
