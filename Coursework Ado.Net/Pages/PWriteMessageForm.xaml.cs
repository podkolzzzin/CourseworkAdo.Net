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
	/// Interaction logic for PWriteMessageForm.xaml
	/// </summary>
	public partial class PWriteMessageForm : UserControl,IPage
	{
        List<User> contacts;
		public PWriteMessageForm()
		{
			this.InitializeComponent();
            contacts = DataBaseInterface.GetContacts(DataSaver.UId, DataSaver.PasswordHash);
            
		}
        public PWriteMessageForm(int id)
        {
            this.InitializeComponent();
            User u=DataBaseInterface.GetUserById(DataSaver.UId,DataSaver.PasswordHash,id);
            XTo.Items.Add(u.Login + ":" + u.FIO);
            XTo.SelectedIndex = 0;
            XTo.IsEnabled = false;
            XTo.IsReadOnly = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Message m = new Message();
            m.Text = XText.Text;
            m.Topic = XTopic.Text;
            m.From = DataSaver.CurrentUser;
            try
            {
                m.To = GetAddresant();
            }
            catch
            {
                MessageBox.Show("Невозможно отправить письмо без адресата");
            }
            if (m.Text.Length == 0 && m.Topic.Length == 0)
            {
                MessageBox.Show("Невозможно отправить пустое письмо");
                return;
            }
            DataBaseInterface.SendMessage(DataSaver.UId, DataSaver.PasswordHash, m);
            ((MainWindow)Application.Current.MainWindow).Navigate(new PMailForm());
        }

        private User GetAddresant()
        {
            return null;
        }

        public void OnHiding(EventHandler remover)
        {
            Storyboard a = (Storyboard)TryFindResource("OnUnloaded1");
            a.Completed += remover;
            a.Begin();
        }
	}
}