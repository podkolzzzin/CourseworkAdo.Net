using Coursework_Ado.Net.Pages;
using System;
using System.Collections.Generic;
using System.IO;
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
	/// Interaction logic for PResumeForm.xaml
	/// </summary>
	public partial class PResumeForm : System.Windows.Controls.UserControl, IPage
	{
		public PResumeForm(int id)
		{
			this.InitializeComponent();
            string resumeCode = DataBaseInterface.GetUserResume(DataSaver.UId, DataSaver.PasswordHash, id);
            XResumePresenter.NavigateToString(resumeCode);
		}
        public void OnHiding(EventHandler remover)
        {
            Storyboard a = (Storyboard)TryFindResource("OnUnloaded1");
            a.Completed += remover;
            a.Begin();
        }
	}
}