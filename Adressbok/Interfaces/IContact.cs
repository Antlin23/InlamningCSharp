using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbok.Interfaces
{
    internal interface IContact
    {
        string UserName { get; set; }
        int PhoneNumber { get; set; }
        string Email { get; set; }
    }
}
