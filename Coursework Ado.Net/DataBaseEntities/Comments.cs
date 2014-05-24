using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Coursework_Ado.Net.DataBaseEntities
{
    public class Comment
    {
        public User Author;
        public string Text;
        public DateTime Time;
        public BitmapImage UserAvatar { get { return new BitmapImage(new Uri(DataSaver.Path + "camera_a.png")); } }
        public string AuthorName { get { return "Podkolzin Andrey"; } }
        public string Date { get { return "3 ареля в 16:27"; } }
    }
}
