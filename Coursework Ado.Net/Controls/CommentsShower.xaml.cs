using Coursework_Ado.Net.DataBaseEntities;
using System;
using System.Collections.Generic;
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
	/// Interaction logic for CommentsShower.xaml
	/// </summary>
	public partial class CommentsShower : UserControl
	{
		public CommentsShower()
		{
			this.InitializeComponent();
		}

        public void Add(Comment c)
        {
            XComments.Items.Add(new CommentBox(c));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Comment c;
			if(XCommentText.Text.Length<10)
			{
				MessageBox.Show("Невозможно отправить комментарий, комментарий слишком короткий");
				return;
			}
            if (OnAddComment != null)
            {
                c = OnAddComment(XCommentText.Text);
            }
            else
            {
                c = new Comment();
                c.Text = XCommentText.Text;
                c.Time = DateTime.Now;
                c.Author = DataSaver.CurrentUser;
            }
            if(c!=null)
            {
                XComments.Items.Add(new CommentBox(c));
            }
			XCommentText.Text="";
        }
        public event OnAddCommentEvent OnAddComment;
	}
    public delegate Comment OnAddCommentEvent(string comment);
}