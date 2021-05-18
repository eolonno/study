using System;
using System.Collections.Generic;
using System.Text;

namespace Dormitory.Models
{
    public class User
    {
        public User(string login, string password, string nickname)
        {
            Login = login;
            Password = password;
            Nickname = nickname;
            Status = Status.User;
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public Status Status { get; set; }
    }
    public enum Status
    {
        Admin,
        User
    }
}

