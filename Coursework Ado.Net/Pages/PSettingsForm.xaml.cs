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
	/// Interaction logic for PSettingsForm.xaml
	/// </summary>
	public partial class PSettingsForm : UserControl,IPage
	{
		public PSettingsForm()
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
            if (DataSaver.PasswordHash != Hasher.GetHash(XOldPassword.Password))
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }
            if (XNewPassword.Password == XNewPasswordRepeat.Password)
            {
                DataBaseInterface.ChangePassword(DataSaver.UId, DataSaver.PasswordHash, XNewPassword.Password);
                DataSaver.PasswordHash = Hasher.GetHash(XNewPassword.Password);
            }
            else
                MessageBox.Show("Пароли не совпадают!");
        }
	}
}