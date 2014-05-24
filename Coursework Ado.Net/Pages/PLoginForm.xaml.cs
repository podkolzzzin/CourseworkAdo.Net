using Coursework_Ado.Net.Pages;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;

namespace Coursework_Ado.Net
{
    /// <summary>
    /// Interaction logic for PLoginForm.xaml
    /// </summary>
    public partial class PLoginForm : UserControl, IPage
    {
        public PLoginForm()
        {
            InitializeComponent();
        }

        private void OnSignUpBtn(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Navigate(new PRegisterForm());
        }
        public void OnHiding(EventHandler remover)
        {
            Storyboard a = (Storyboard)TryFindResource("OnUnloaded1");
            a.Completed += remover;
            a.Begin();
        }
        private void OnLoginBtn(object sender, RoutedEventArgs e)
        {
            var user = DataBaseInterface.Login(XloginBox.Text, XpasswordBox.Password);
            if (user != null)
            {
                DataSaver.CurrentUser = user;
                ((MainWindow)Application.Current.MainWindow).Navigate(new PPersonalForm());
            }
            else
            {
                MessageBox.Show("Введенные данные не верны");
            }
        }
    }

}
