using Coursework_Ado.Net.DataBaseEntities;
using Coursework_Ado.Net.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Coursework_Ado.Net
{
	/// <summary>
	/// Interaction logic for PUserReferences.xaml
	/// </summary>
	public partial class PUserReferences : UserControl,IPage
	{
        List<Comment> _comments;
		public PUserReferences(char type,int id)
		{
			this.InitializeComponent();
            if (type == 'c')
            {
                _comments = DataBaseInterface.GetCompanyReferences(DataSaver.UId, DataSaver.PasswordHash,id);
            }
            else
            {
                _comments = DataBaseInterface.GetUserReferences(DataSaver.UId, DataSaver.PasswordHash,id);
            }

            foreach (Comment c in _comments)
            {
                XCommentsShower.Add(c);
            }
		}

        private DataBaseEntities.Comment commentsShower_OnAddComment_1(string comment)
        {
            Comment c = new Comment();
            c.Author = DataSaver.CurrentUser;
            c.Text = comment;
            c.Time = DateTime.Now;
            DataBaseInterface.AddCommentToUser(DataSaver.UId, DataSaver.PasswordHash, c);
            return c;
        }
        public void OnHiding(EventHandler remover)
        {
            Storyboard a = (Storyboard)TryFindResource("OnUnloaded1");
            a.Completed += remover;
            a.Begin();
        }
	}
}