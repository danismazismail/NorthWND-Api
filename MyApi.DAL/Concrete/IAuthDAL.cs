﻿using MyApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.DAL.Interfaces
{
    public interface IAuthDAL
    {
        Task<User> Register(User user, string password);

        Task<User> Login(string username,string password);

        Task<bool> UserExist(string username);

        
    }
}
