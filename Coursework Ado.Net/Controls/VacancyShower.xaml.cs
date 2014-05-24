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
	/// Interaction logic for VacancyShower.xaml
	/// </summary>
	public partial class VacancyShower : UserControl
	{
        private Coursework_Ado.Net.Vacancy v;
		public VacancyShower()
		{
			this.InitializeComponent();
		}
		public VacancyShower(Vacancy v)
		{
			this.v=v;
			this.InitializeComponent();
			_construct();
		}

		public Vacancy Vacancy { get { return v;} set {v=value; _construct();}}
		private void _construct()
		{
            XCompanyImg.Source = v.CompanyImg;
            XDescription.Text = v.Description+"\r\n\r\nЗарплата от "+v.MinPay+" до " + v.MaxPay;
            XLink.Href = "PVacancyForm.xaml?" + v.Id;
            XLink.FontSize = 18;
            XLink.Text = v.Name;
            XAuthor.Href = "PUserInfoForm.xaml?" + v.AuthorId;
            XAuthor.Text = v.AuthorName;
            XTypeBlock.Text = v.TypeStr;
            XTypeBlock.Background = v.TypeColor;
		}

        private void XCompanyImg_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Navigate(new PCompanyInfoForm(v.CompanyId));
        }
	}
}