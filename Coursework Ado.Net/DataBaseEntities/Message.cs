using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Coursework_Ado.Net
{
    public class Message
    {
        public string Topic { get; set; }
        public string Text { get; set; }
        public User From;
        public string AuthorStr { get { return From.Login+": "; } }
        public string Author { get { return From.Login; } }
        public FontWeight FontWeight
        {
            get 
            {
                if (IsRead)
                    return FontWeights.Normal;
                else
                    return FontWeights.Bold;
            }
        }
        public bool IsRead;
        public BitmapImage ImageSource
        {
            get
            {
                if (IsRead)
                    return new BitmapImage(new Uri(DataSaver.Path + "read.jpg"));
                else
                    return new BitmapImage(new Uri(DataSaver.Path + "unread.jpg"));
            }
        }

        public User To { get; set; }
    }
}
