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
	/// Interaction logic for PCompanyInfoForm.xaml
	/// </summary>
	public partial class PCompanyInfoForm : UserControl,IPage
	{
        private int _id;
		public PCompanyInfoForm(int id)
		{
            _id = id;
			this.InitializeComponent();
            Company c = DataBaseInterface.GetCompanyById(DataSaver.UId, DataSaver.PasswordHash, id);
            XCompanyAvatar.Source = c.Logo;
            XCompanyInfoList.Items.Add(new PropertyShower("Название", c.Name));
            XCompanyInfoList.Items.Add(new PropertyShower("Специализация",c.Specialization));
            foreach (Contact t in c.Contacts)
            {
                XCompanyInfoList.Items.Add(new PropertyShower(t.Type, t.Value));
            }
            XComments.Href = "PReferencesForm.xaml?c" + c.Id;
            XVacancies.Href = "PSearchForm.xaml?c" + c.Id;
            if (DataBaseInterface.HasSubscribe(DataSaver.UId, DataSaver.PasswordHash, _id))
                XSubscribeButton.Content = "Отписаться";
		}
        public void OnHiding(EventHandler remover)
        {
            Storyboard a = (Storyboard)TryFindResource("OnUnloaded1");
            a.Completed += remover;
            a.Begin();
        }

        private void XSubscribeButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (XSubscribeButton.Content.ToString() == "Подписаться")
            {
                DataBaseInterface.AddSubscribe(DataSaver.UId, DataSaver.PasswordHash, _id);
                XSubscribeButton.Content = "Отписаться";
            }
            else
            {
                DataBaseInterface.RemoveSubscribe(DataSaver.UId, DataSaver.PasswordHash, _id);
                XSubscribeButton.Content = "Подписаться";
            }
        }
	}
}