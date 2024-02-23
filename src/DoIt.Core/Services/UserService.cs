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
        private readonly DoItDbContext _db;

        public UserService(DoItDbContext dbContext)
        {
            _db = dbContext;
        }

        public int RegisterUser(RegisterViewModel viewModel)
        {
            User user = new()
            {
                Name = viewModel.Name,
                Username = viewModel.Username.Trim(),
                Password = HashHelper.GetSha256(viewModel.Password)
            };

            _db.Users.Add(user);
            return _db.SaveChanges();
        }

        public bool UsernameExist(string username)
        {
            return _db.Users.Any(x => x.Username == username.Trim());
        }
    }
}
