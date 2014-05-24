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
	/// Interaction logic for PVacancyForm.xaml
	/// </summary>
	public partial class PVacancyForm : UserControl,IPage
	{
		public PVacancyForm(int id)
		{
			this.InitializeComponent();
            Vacancy v = DataBaseInterface.GetVavancyById(DataSaver.UId, DataSaver.PasswordHash, id);
            XVacancyBox.Vacancy = v;
           
		}
        public void OnHiding(EventHandler remover)
        {
            Storyboard a = (Storyboard)TryFindResource("OnUnloaded1");
            a.Completed += remover;
            a.Begin();
        }

        private Comment XComments_OnAddComment_1(string comment)
        {
            Comment c = new Comment();
            c.Author = DataSaver.CurrentUser;
            c.Time = DateTime.Now;
            c.Text = comment;
            DataBaseInterface.AddCommentToVacancy(DataSaver.UId,DataSaver.PasswordHash,c);
            return c;
        }
	}
}