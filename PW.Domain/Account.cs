using System;

namespace PW.Domain
{
    public class Account
    {
        public Guid AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}