using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Coursework_Ado.Net.DataBaseEntities;

namespace Coursework_Ado.Net
{
    public class Vacancy
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinPay {get; set; }
        public int MaxPay {get; set; }
        public int CompanyId { get; set; }
        public string AuthorName { get; set; }
        public int AuthorId { get; set; }
        public string TypeStr { get { return "Фултайм";} set { ;} }
        public Brush TypeColor
        {
            get
            {
                switch (TypeStr)
                { 
                    case "Фултайм":
                        return Brushes.Orange;
                    case "Хавтайм":
                        return Brushes.Green;
                    case "Фриланс":
                        return Brushes.Blue;
                    default:
                        return Brushes.Black;
                }
            }
        }
        private BitmapImage _companyImg;
        public BitmapImage CompanyImg { get { return DataBaseInterface.GetCompanyLogo(); } set { _companyImg = value; } }

        public List<Comment> Comments = new List<Comment>();
        public string Id { get; set; }
    }

}
