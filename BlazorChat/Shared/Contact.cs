using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorChat.Shared
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Contact()
        {

        }
        public Contact(int Id, string FirstName, string LastName)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
    }
}
