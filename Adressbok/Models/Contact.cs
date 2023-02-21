using Adressbok.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbok.Models
{
    public class Contact : IContact
    {
        public string UserName { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public string Email { get; set; } = null!;
    }
}
