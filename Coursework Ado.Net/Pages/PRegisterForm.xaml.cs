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

namespace Coursework_Ado.Net
{
    /// <summary>
    /// Interaction logic for PRegisterForm.xaml
    /// </summary>
    public partial class PRegisterForm : UserControl, IPage
    {
        public PRegisterForm()
        {
            InitializeComponent();
        }
        public void OnHiding(EventHandler remover)
        {
            Storyboard a = (Storyboard)TryFindResource("OnUnloaded1");
            a.Completed += remover;
            a.Begin();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(XSignPasswordBox.Password!=XSignRepeatBox.Password)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            else if (XSignPasswordBox.Password.Length < 5)
            {
                MessageBox.Show("Пароль слишком короткий");
                return;
            }
            User u = DataBaseInterface.Registrate(XSignLoginBox.Text, Hasher.GetHash(XSignPasswordBox.Password));
            if (u == null)
            {
                MessageBox.Show("Логин уже занят");
            }
            else
            {
                DataSaver.CurrentUser = u;
                ((MainWindow)Application.Current.MainWindow).Navigate(new PPersonalForm());
            }
        }
    }
}
