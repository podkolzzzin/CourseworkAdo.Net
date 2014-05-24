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
using Coursework_Ado.Net.Pages;
using System.Windows.Media.Animation;
using Coursework_Ado.Net.DataBaseEntities;

namespace Coursework_Ado.Net
{
	/// <summary>
	/// Interaction logic for PSearchForm.xaml
	/// </summary>
	public partial class PSearchForm : UserControl,IPage
	{
		public PSearchForm(string keyWord)
		{
			this.InitializeComponent();
            SearchResult result = DataBaseInterface.Search(DataSaver.UId,DataSaver.PasswordHash,keyWord);
            XSearchResultList.Items.Add(new Separator("Вакансии: "+result.Vacancies.Count));
            foreach (Vacancy v in result.Vacancies)
            {
                XSearchResultList.Items.Add(new VacancyShower(v));
            }

            XSearchResultList.Items.Add(new Separator("Пользователи: "+result.Users.Count));
            Link t;
            foreach (User u in result.Users)
            {
                t=new Link();
                t.Margin = new Thickness(30, 0, 0, 0);
                t.Text=u.Login+": "+ u.FIO;
                t.Href = "PUserInfoForm.xaml?" + u.Id;
                XSearchResultList.Items.Add(t);
            }

            XSearchResultList.Items.Add(new Separator("Компании: " + result.Companies.Count));
            foreach (Company c in result.Companies)
            {
                t = new Link();
                t.Margin = new Thickness(30, 0, 0, 0);
                t.Text = c.Name;
                t.Href = "PCompanyInfoForm.xaml?" + c.Id;
                XSearchResultList.Items.Add(t);
            }
		}
        public PSearchForm(char type, int id)
        {
            InitializeComponent();
            List<Vacancy> result;
            if (type == 'c')
            {
                result = DataBaseInterface.GetCompanyVacancies(DataSaver.UId, DataSaver.PasswordHash, id);
            }
            else
            {
                result = DataBaseInterface.GetUserSubscribeNews(DataSaver.UId, DataSaver.PasswordHash);
            }

            foreach (Vacancy v in result)
            {
                XSearchResultList.Items.Add(new VacancyShower(v));
            }
        }
        public void OnHiding(EventHandler remover)
        {
            Storyboard a = (Storyboard)TryFindResource("OnUnloaded1");
            a.Completed += remover;
            a.Begin();
        }

        private void XSearchResultList_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            Type t = XSearchResultList.SelectedItem.GetType();
            if (t == typeof(VacancyShower))
            {
                ((MainWindow)Application.Current.MainWindow).Navigate(
                    new PVacancyForm(
                        (Convert.ToInt32(
                        ((VacancyShower)XSearchResultList.SelectedItem).Vacancy.Id))));
            }
            else if (t == typeof(Link))
            {
                Link link = (Link)XSearchResultList.SelectedItem;
                link.Navigate();
            }
        }
	}
}