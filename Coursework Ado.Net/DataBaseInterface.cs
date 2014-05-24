using Coursework_Ado.Net.DataBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Coursework_Ado.Net
{
    public class DataBaseInterface
    {
        public static User Login(string login, string password)
        {
            string tLogin = login;
            string tPassword = Hasher.GetHash(password);
            /*tUser t;
            t = new tUser();
            t.cId = 0;
            t.cLogin = tLogin;
            t.cPassword = tPassword;
            tProfile p=new tProfile();
            p.cBirthDate=DateTime.Now;
            p.cFirstName="Андрей";
            p.cLastName="Подколзин";
            p.cMidleName="Юрьевич";
            p.cPosition = "Луганск";
            tContact contact = new tContact();
            contact.cContactType = "Skype";
            contact.cContact = "podkolzzzin";
            List<tContact> contacts = new List<tContact>();
            contacts.Add(contact);*/
            return new User(null,null,null, null, null,null);
        }
        public static bool ChangePassword(int uId, string oldPasswordHash, string newPassword)
        {
            if (DataSaver.CurrentUser.PasswordHash == oldPasswordHash)
            {
                return true;
            }
            return false;
        }
        public static void SetPersonalProperty(int uId, string passwordHash, string property, object value)
        {
        }

        public static void AddContact(int uId, string passwordHash, Contact tContact)
        {
            
        }

        public static void SetAvatar(int uId, string passwordHash, string pathToImage)
        {
            
        }

        public static void RemoveContact(PersonalProperty personalProperty)
        {
            
        }

        public static List<Message> GetMail(int uId, string password)
        {
            Message m = new Message();
            m.Text = "dfgddgdfgdgdg";
            m.Topic = "Important";
            m.IsRead = false;
            m.From = new User();
            m.From.Login = "Admin";
            List<Message> t = new List<Message>();
            t.Add(m);
            m = new Message();
            m.Text = "dfgddgdfgdgdg";
            m.Topic = "Another";
            m.From = new User();
            m.From.Login = "WORLDking";
            m.IsRead = true;
            t.Add(m);
            return t;
        }

        public static void SendMessage(int uId, string password, Message m)
        {
            
        }

        public static List<User> GetContacts(int uId, string password)
        {
            User t = new User();
            t.Id = 1;
            t.Login = "login1";
            List<User> result = new List<User>();
            result.Add(t);
            
            t = new User();
            t.Id = 2;
            t.Login = "login2";
            result.Add(t);

            return result;
        }

        public static int GetNumNewMessages(int uId, string password)
        {
            return 4;
        }

        public static Company GetUserCompany(int uId, string password)
        {
            return null;
        }

        public static Company RegistrateCompany(int uid, string password, string name, int founded, string spec, string address, string logo, string about)
        {
            Company t = new Company();
            t.Founded = founded.ToString();
            t.Name = name;
            //todo: spec
            /*tCompanyOffice office=new tCompanyOffice();
            office.cAddress=address;
            t.tCompanyOffices.Add(office);*/
            //todo: logo
            //todo: about
            return t;
        }

        public static List<CompanyManager> GetCompanyManagers(int uId, string password, int companyId)
        {
            List<CompanyManager> result = new List<CompanyManager>();
            User t=new User();
            t.Login="podkolzzzin";

            result.Add(new CompanyManager(t));
            return result;
        }

        public static void RemoveManager(int uId, string password, CompanyManager companyManager)
        {
          
        }

        public static User GetUserByLogin(int uId, string password, string userLoginForFind)
        {
            User t=new User();
            t.Login="Worldking";
            return new User(t, null, null, null, null, null);
        }

        public static void AddCompanyManager(int uId, string password, int uManagerId)
        {
            
        }

        public static void AddVacancy(int uId, string password, Vacancy v)
        {
            
        }

        public static SearchResult Search(int uId, string passwordHash, string keyWord)
        {
            var t = new SearchResult();
            Company c = new Company();
            c.Name = "jacobs";
            t.Companies.Add(c);
            User tuser = new User();
            tuser.Login = "podkolzzzin";
            tuser.Id = 147;
            t.Users.Add(new User(tuser, null, null, null, null, null));
            Vacancy v = new Vacancy();
            v.AuthorName = "Подколзин Андрей Юрьевич";
            v.Description = "Being an amazing combination of professionalism, creativity, inspiration and success Just Eat features as the biggest online takeaway marketplace in the world!";
            v.MinPay = 1000; 
            v.Name = "Being an amazing combination";
            v.MaxPay = int.MaxValue;
            t.Vacancies.Add(v);
            return t;
        }

        public static System.Windows.Media.Imaging.BitmapImage GetCompanyLogo()
        {
            return new System.Windows.Media.Imaging.BitmapImage(
                new Uri(DataSaver.Path + "camera_a.png"));
        }

        public static User GetUserById(int uId, string password, int idForSearch)
        {
            User t=new User();
            t.Login="WORLDking";
            t.Id=idForSearch;
            Company c = new Company();
            c.Name = "Sony";
            c.Id = 17;
            User u = new User(t,null,null,null,null,c);
            return u;
        }

        public static Company GetCompanyById(int uId, string password, int idForSearch)
        {
            Company c = new Company();
            c.Name = "Sony";
            c.Id = idForSearch;
            c.Logo = new BitmapImage(new Uri(DataSaver.Path + "camera_a.png"));
            c.Address = "Набережная 140";
            c.Specialization = "телефоны, приставки";
            c.Contacts = new List<Contact>();
            Contact t = new Contact();
            t.Value = "vcs_sony";
            t.Type = "skype";
            c.Contacts.Add(t);
            return c;
        }

        public static Vacancy GetVavancyById(int uId, string password, int idForSearch)
        {
            Vacancy v = new Vacancy();
            v.AuthorName = "Подколзин Андрей Юрьевич";
            v.Description = "Being an amazing combination of professionalism, creativity, inspiration and success Just Eat features as the biggest online takeaway marketplace in the world!";
            v.MinPay = 1000;
            v.MaxPay = int.MaxValue;
            v.Name = "Being an amazing combination";
            return v;
        }

        public static void AddCommentToVacancy(int uId, string password, Comment c)
        {
            
        }

        public static void AddCommentToUser(int uId, string password, Comment c)
        {
            
        }

        public static List<Comment> GetCompanyReferences(int uId, string password,int idForSearch)
        {
            return new List<Comment>();
        }

        public static List<Comment> GetUserReferences(int uId, string password, int idForSearch)
        {
            return new List<Comment>();
        }

        public static string GetUserResume(int uId, string password, int idForSearch)
        {
            return "<html><head><meta http-equiv='Content-Type' content='text/html;charset=UTF-8'></head><body>Пользователь еще не заполнил резюме</body></html>";
        }

        public static void SetUserResume(int uId, string password)
        {
            
        }

        public static void AddSubscribe(int uId, string password, int companyId)
        {
            
        }

        public static void RemoveSubscribe(int uId, string password, int companyId)
        { 
            
        }

        public static bool HasSubscribe(int uId, string password, int companyId)
        {
            return true;
        }

        public static List<Vacancy> GetCompanyVacancies(int uId, string password, int companyId)
        {
            return new List<Vacancy>();
        }

        public static List<Vacancy> GetUserSubscribeNews(int uId, string password)
        {
            return new List<Vacancy>();
        }

        public static User Registrate(string login, string passworHash)
        {
            return null;
        }
    }
}
