﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankAPI.Models;

namespace BankAPI
{
    public class UserService
    {
        private Models.BankAPI _context { get; set; }

        public UserService(Models.BankAPI context)
        {
            _context = context;
        }

        public User GetUser(string Name)
        {
            return _context.Users.FirstOrDefault(u => u.Name == Name);
        }
    }
}