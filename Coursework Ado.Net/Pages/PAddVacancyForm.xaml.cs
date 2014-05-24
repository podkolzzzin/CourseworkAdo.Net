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
	/// Interaction logic for PAddVacancyForm.xaml
	/// </summary>
	public partial class PAddVacancyForm : UserControl,IPage
	{
		public PAddVacancyForm()
		{
			this.InitializeComponent();
		}
        public void OnHiding(EventHandler remover)
        {
            Storyboard a = (Storyboard)TryFindResource("OnUnloaded1");
            a.Completed += remover;
            a.Begin();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Vacancy v = new Vacancy();
            v.Description = XVacancyDescription.PValue.ToString();
            v.MaxPay = Convert.ToInt32(XMaxPay.Text);
            v.MinPay = Convert.ToInt32(XMinPay.Text);
            v.CompanyId = DataSaver.CurrentUser.Company.Id;
            DataBaseInterface.AddVacancy(DataSaver.UId, DataSaver.PasswordHash, v);
        }
	}
}