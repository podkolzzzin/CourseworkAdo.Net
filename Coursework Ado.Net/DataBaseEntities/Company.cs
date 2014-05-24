using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coursework_Ado.Net.DataBaseEntities
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public System.Windows.Media.Imaging.BitmapImage Logo { get; set; }

        public string Address { get; set; }

        public string Specialization { get; set; }

        public List<Contact> Contacts { get; set; }

        public string Founded { get; set; }
    }
}
