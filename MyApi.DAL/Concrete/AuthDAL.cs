using Microsoft.EntityFrameworkCore;
using MyApi.Core;
using MyApi.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.DAL.Concrete
{
    public class AuthDAL : IAuthDAL
    {
        private readonly MyAppDbContext _db;
        public AuthDAL(MyAppDbContext db)
        {
            _db = db;

        }
        public async Task<User> Login(string username, string password)
        {
            User user = _db.User.FirstOrDefault(a => a.UserName == username.Trim());

            if (user == null)
            {
                return null;
            }

            if (!ControlPassword(password, user.PassSalt, user.PasswordHash))
            {
                return null;

            }
            return user;
        }

        private bool ControlPassword(string password, byte[] passSalt, byte[] passHash)
        {
            using (var hmac = new HMACSHA512(passSalt))
            {
                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                             

                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (passwordHash[i] != passHash[i])
                    {
                        return false;

                    }
                }
            }
            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            
            if(! await UserExist(user.UserName))
            {
                byte[] passHash, passSalt;
                CreatePassword(password, out passHash, out passSalt);

                user.PassSalt = passSalt;
                user.PasswordHash = passHash;

                await _db.User.AddAsync(user);
                await _db.SaveChangesAsync();
                return user;
            }
            return null;
           

        }

        private void CreatePassword(string password, out byte[] passHash, out byte[] passSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                passSalt = hmac.Key;
            }
        }

        public async Task<bool> UserExist(string username)
        {
            if (! await _db.User.AnyAsync(a => a.UserName == username))
            {
                return false;
            }
            return true;
        }
    }
}
