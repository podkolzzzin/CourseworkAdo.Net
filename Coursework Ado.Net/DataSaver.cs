using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Coursework_Ado.Net
{
    class DataSaver
    {
        public static User CurrentUser;
        public static int UId { get { return CurrentUser.Id; } }
        public static string PasswordHash { get; set; }
        public static string Path = Directory.GetCurrentDirectory()+"\\";
        public static Dictionary<string,string> NavigationParameter=new Dictionary<string,string>();

        public static object CurrentUserLastName { get; set; }

        public static object CurrentUserMidleName { get; set; }

        public static object CurrentUserBirthDate { get; set; }
    }
}
