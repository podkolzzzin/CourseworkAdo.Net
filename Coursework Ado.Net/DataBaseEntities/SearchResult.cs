using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coursework_Ado.Net.DataBaseEntities;

namespace Coursework_Ado.Net
{
    public class SearchResult
    {
        public List<User> Users;
        public List<Vacancy> Vacancies;
        public List<Company> Companies;
        public SearchResult()
        {
            Users = new List<User>();
            Vacancies = new List<Vacancy>();
            Companies = new List<Company>();
        }
        public SearchResult(List<User> users, List<Vacancy> vacancies, List<Company> companies)
        {
            Users = users;
            Vacancies = vacancies;
            Companies = companies;
        }
    }
}
