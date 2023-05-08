using ECommerce.Domain.AggregateModels.BasketAggregate;
using ECommerce.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.AggregateModels.UserModels
{
    public class User : BaseEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string City { get; private set; }
        public bool Status { get; private set; }

        public virtual ICollection<Basket> Baskets { get; set; }

        public User(string firstName, string lastName, string email, string password, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            City = city;
            Status = true;
        }
    }
}