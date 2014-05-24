using Coursework_Ado.Net.DataBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Coursework_Ado.Net
{
    public class User
    {
        /*public tEducation Education;
        public tCompanyManager Manager;
        public tProfile P;
        public tCompany Company;*/
        //public List<tContact> Contacts;
        public Company Company;
        public User(object user, object profile, object contact, object education, object manager,object Company)
        {
            /*U = user;
            P = profile;
            Contacts = contact;
            Education = education;
            Manager = manager;
            this.Company = Company;*/
        }

        public User()
        {
            // TODO: Complete member initialization
        }
        public string Login { get; set;}
        public string PasswordHash { get; set;}        

        public string FIO { get { return "Подколзин Андрей Юрьевич"; } }

        public System.Windows.Media.ImageSource Avatar { get; set; }

        public int Id { get; set; }

        public object FirstName { get; set; }

        public object Position { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }
    }
}
