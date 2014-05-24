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
	/// Interaction logic for PMailForm.xaml
	/// </summary>
	public partial class PMailForm : UserControl,IPage
	{
		public PMailForm()
		{
			this.InitializeComponent();
            List<Message> messages = DataBaseInterface.GetMail(DataSaver.UId,DataSaver.PasswordHash);
            foreach (Message m in messages)
            {
                XMailList.Items.Add(m);
            }
            XMailList.MouseDoubleClick += XMailList_MouseDoubleClick;
		}

        void XMailList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Navigate(
                new PMessageForm(
                (Message)XMailList.SelectedItem));
        }
        public void OnHiding(EventHandler remover)
        {
            Storyboard a = (Storyboard)TryFindResource("OnUnloaded1");
            a.Completed += remover;
            a.Begin();
        }
	}
}