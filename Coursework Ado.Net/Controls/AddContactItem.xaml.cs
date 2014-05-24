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
	/// Interaction logic for AddContactItem.xaml
	/// </summary>
	public partial class AddContactItem : UserControl
	{
		public AddContactItem()
		{
			this.InitializeComponent();
            XContactValue.GotFocus += XContactValue_GotFocus;
            XContactValue.LostFocus += XContactValue_LostFocus;
            XContactValue.Text = "Value";
            XContactValue.Foreground = Brushes.Silver;

            XContactName.Text = "Contact";
            XContactName.Foreground = Brushes.Silver;
            XContactName.GotFocus += XContactName_MouseEnter;
            XContactName.LostFocus += XContactName_MouseLeave;
		}

        void XContactName_MouseLeave(object sender, RoutedEventArgs e)
        {
            if (XContactName.Text == "")
            {
                XContactName.Text = "Contact";
                XContactName.Foreground = Brushes.Silver;
            }
        }

        void XContactName_MouseEnter(object sender, RoutedEventArgs e)
        {
            if (XContactName.Text == "Contact")
            {
                XContactName.Text = "";
                XContactName.Foreground = Brushes.Black;
            }
        }

        void XContactValue_LostFocus(object sender, RoutedEventArgs e)
        {
            if (XContactValue.Text == "")
            {
                XContactValue.Text = "Value";
                XContactValue.Foreground = Brushes.Silver;
            }
        }

        void XContactValue_GotFocus(object sender, RoutedEventArgs e)
        {
            if (XContactValue.Text == "Value")
            {
                XContactValue.Text = "";
                XContactValue.Foreground = Brushes.Black;
            }
        }
	}
}