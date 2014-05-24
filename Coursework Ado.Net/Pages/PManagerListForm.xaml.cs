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
    /// Interaction logic for PManagerListForm.xaml
    /// </summary>
    public partial class PManagerListForm : UserControl,IPage
    {
        public PManagerListForm()
        {
            this.InitializeComponent();
            this.KeyDown += PManagerListForm_KeyDown;
            DataSaver.CurrentUser.Company = new Company();
            DataSaver.CurrentUser.Company.Id = 0;//todo: dalate this str
            var managers = DataBaseInterface.GetCompanyManagers(DataSaver.UId, DataSaver.PasswordHash, DataSaver.CurrentUser.Company.Id);
            foreach (CompanyManager item in managers)
            {
                XManagersList.Items.Insert(XManagersList.Items.Count,item);
            }
        }

        void PManagerListForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete) //todo: check if user is admin of the company
            {
                try
                {
                    DataBaseInterface.RemoveManager(DataSaver.UId, DataSaver.PasswordHash, (CompanyManager)XManagersList.SelectedItem);
                    XManagersList.Items.Remove(XManagersList.SelectedItem);
                }
                catch
                { }
            }
        }

        private void XAddButton_Click_1(object sender, RoutedEventArgs e)
        {
            var t = DataBaseInterface.GetUserByLogin(DataSaver.UId, DataSaver.PasswordHash, XNewManagerLogin.Text);
            if (t != null && t.Company==null)
            {
                DataBaseInterface.AddCompanyManager(DataSaver.UId, DataSaver.PasswordHash, t.Id);
                XManagersList.Items.Add(new CompanyManager(t));
            }
            else if (t == null)
            {
                MessageBox.Show("Пользователя с таким логином не существует");
            }
            else
            {
                MessageBox.Show("Пользователь уже является менеджером компании, пользователь не может быть менеджером более чем одной компании");
            }
        }  
        public void OnHiding(EventHandler remover)
        {
            Storyboard a = (Storyboard)TryFindResource("OnUnloaded1");
            a.Completed += remover;
            a.Begin();
        }
    }
}