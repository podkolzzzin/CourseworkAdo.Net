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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Coursework_Ado.Net.DataBaseEntities;

namespace Coursework_Ado.Net
{
    /// <summary>
    /// Interaction logic for AddContactForm.xaml
    /// </summary>
    public partial class AddContactForm : Window
    {
        public AddContactForm()
        {
            InitializeComponent();
        }

        public Contact Contact;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Contact = new Contact();
            Contact.Value = XContactValue.Text;
            Contact.Type = XContactName.Text;
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Contact = null;
            this.Close();
        }

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
