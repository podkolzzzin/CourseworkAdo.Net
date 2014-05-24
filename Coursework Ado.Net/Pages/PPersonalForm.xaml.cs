using Coursework_Ado.Net.DataBaseEntities;
using Coursework_Ado.Net.Pages;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for PPersonalForm.xaml
    /// </summary>
    public partial class PPersonalForm : UserControl, IPage
    {
        Button CAddContactButton;
        int _lastContactIndex;
        public PPersonalForm()
        {
            this.InitializeComponent();
            XAvatarImage.Source = new BitmapImage(new Uri(DataSaver.Path+"camera_a.png",UriKind.Absolute));
            //==initialize personal properties
            this.XPersonalListBox.Items.Add(new PersonalProperyShower(
                new PersonalProperty("Фамилия", DataSaver.CurrentUser.FirstName,PropertyType.Name), this));
            this.XPersonalListBox.Items.Add(new PersonalProperyShower(
                new PersonalProperty("Имя", DataSaver.CurrentUserLastName, PropertyType.Name), this));
            this.XPersonalListBox.Items.Add(new PersonalProperyShower(
                new PersonalProperty("Отчество", DataSaver.CurrentUserMidleName, PropertyType.Name), this));
            this.XPersonalListBox.Items.Add(new PersonalProperyShower(
                new PersonalProperty("Дата рождения", DataSaver.CurrentUserBirthDate, PropertyType.Birthdate), this));
            this.XPersonalListBox.Items.Add(new PersonalProperyShower(
                new PersonalProperty("Адрес", DataSaver.CurrentUser.Position,PropertyType.Address), this));
            foreach (Contact contact in DataSaver.CurrentUser.Contacts)
            {
                _lastContactIndex = XPersonalListBox.Items.Count + 1;
                this.XPersonalListBox.Items.Add(new PersonalProperyShower(
                    new PersonalProperty(contact.Type, contact.Value,PropertyType.Contact), this));
            }
            CAddContactButton = new Button();
            CAddContactButton.FontSize = 18;
            CAddContactButton.Content = "Добавить контакт";
            CAddContactButton.Click += CAddContactButton_Click;
            XPersonalListBox.Items.Add(CAddContactButton);
            XAvatarImage.MouseLeftButtonDown += XAvatarImage_MouseLeftButtonDown;
            XPersonalListBox.KeyDown += XPersonalListBox_KeyDown;
            //===initialize manager's corner
            int num = DataBaseInterface.GetNumNewMessages(DataSaver.UId, DataSaver.PasswordHash);
            if (num > 0)
            {
                XNumNewMessages.Text = "("+num+")";
            }
        }

        void XPersonalListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                try
                {
                    var t = ((PersonalProperyShower)XPersonalListBox.SelectedItem).Property;
                    if (t.Type == PropertyType.Contact)
                    {
                        DataBaseInterface.RemoveContact(t);
                        XPersonalListBox.Items.Remove(XPersonalListBox.SelectedItem);
                    }
                }
                catch { }
            }
        }

        void XAvatarImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataBaseInterface.SetAvatar(DataSaver.UId, DataSaver.PasswordHash, ofd.FileName);
                XAvatarImage.Source = new BitmapImage(new Uri(ofd.FileName));
            }
        }

        void CAddContactButton_Click(object sender, RoutedEventArgs e)
        {
            AddContactItem aci = new AddContactItem();
            aci.Width = 450;
            aci.KeyDown += aci_KeyDown;
            this.XPersonalListBox.Items.Insert(this.XPersonalListBox.Items.Count-1,aci);
        }

        void aci_KeyDown(object sender, KeyEventArgs e)
        {
            AddContactItem aci=(AddContactItem)sender;
            if (e.Key == Key.Enter)
            { 
                Contact t=new Contact();
                t.Value=aci.XContactValue.Text;
                t.Type=aci.XContactName.Text;
                DataBaseInterface.AddContact(DataSaver.UId, DataSaver.PasswordHash, t);
                this.XPersonalListBox.Items.Remove(aci);
                this.XPersonalListBox.Items.Insert(this.XPersonalListBox.Items.Count-1,
                    new PersonalProperyShower(
                    new PersonalProperty(t.Type, t.Value,PropertyType.Contact),this));
            }
            else if (e.Key == Key.Escape)
            {
                this.XPersonalListBox.Items.Remove(aci);
            }
        }
        public void OnHiding(EventHandler remover)
        {
            Storyboard a = (Storyboard)TryFindResource("OnUnloaded1");
            a.Completed += remover;
            a.Begin();
        }
        public void PropertyChanged(PersonalProperty prop)
        {
            DataBaseInterface.SetPersonalProperty(
                DataSaver.UId,
                DataSaver.PasswordHash,
                prop.Name, prop.Value);
        }
    }
}