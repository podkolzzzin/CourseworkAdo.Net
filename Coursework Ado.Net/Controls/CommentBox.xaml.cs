using Coursework_Ado.Net.DataBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Coursework_Ado.Net
{
    /// <summary>
    /// Interaction logic for CommentBox.xaml
    /// </summary>
    public partial class CommentBox : UserControl
    {
        public CommentBox(Comment c)
        {
            InitializeComponent();
            XLink.Text = c.Author.FIO;
            XLink.Href = "PUserInfoForm.xaml?"+c.Author.Id;
            XAvatar.Source = c.UserAvatar;
            XDate.Text = c.Date;
            XComment.Text = c.Text;
        }
    }
}
