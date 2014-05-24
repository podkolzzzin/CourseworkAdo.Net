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
    /// Interaction logic for PManagerForm.xaml
    /// </summary>
    public partial class PManagerForm : UserControl, IPage
    {
        public Company _company;
        public PManagerForm()
        {
            _company = DataBaseInterface.GetUserCompany(DataSaver.UId, DataSaver.PasswordHash);
            this.InitializeComponent();
            XCompanyLogo.Source = new BitmapImage(new Uri(DataSaver.Path + "camera_a.png", UriKind.Absolute));
            if (_company == null)
            {
                XCompanyInfo.Visibility = Visibility.Hidden;
                XCompanyReg.Visibility = Visibility.Visible;
               
            }
            else
            {
                _init();
            }
        }

        private void _init()
        {
            XCompanyInfo.Visibility = Visibility.Visible;
            XCompanyReg.Visibility = Visibility.Hidden;

            var temp = new PropertyShower("Название: ", _company.Name);
            temp.OnProperyChanged += _OnProperyChanged;
            XCompanyInfoList.Items.Add(temp);

            temp = new PropertyShower("Год основание: ", _company.Founded);
            temp.OnProperyChanged += _OnProperyChanged;
            XCompanyInfoList.Items.Add(temp);

            temp = new PropertyShower("Адрес: ", _company.Name);
            temp.OnProperyChanged += _OnProperyChanged;
            XCompanyInfoList.Items.Add(temp);

            var tem = new PropertyShowerMultiline("Название: ", _company.Name);
            tem.OnProperyChanged += _OnProperyChanged;
            XCompanyInfoList.Items.Add(tem);
        }
        void _OnProperyChanged(string name, object value)
        {
            
        }
        public void OnHiding(EventHandler remover)
        {
            Storyboard a = (Storyboard)TryFindResource("OnUnloaded1");
            a.Completed += remover;
            a.Begin();
        }

        private void ButtonRegistration(object sender, EventArgs e)
        {
            try
            {
                _company = DataBaseInterface.RegistrateCompany(DataSaver.UId, DataSaver.PasswordHash,
                    XCompanyName.PValue.ToString(),
                    Convert.ToInt32(XCompanyFoundated.PValue.ToString()),
                    XCompanySpecializing.PValue.ToString(),
                    XCompanyAddress.PValue.ToString(),
                    XCompanyLogoR.PPath,
                    XCompanyAbout.PValue.ToString());
                XCompanyReg.Visibility = Visibility.Hidden;
                XCompanyInfo.Visibility = Visibility.Visible;
                _init();
            }
            catch
            {
                MessageBox.Show("Не все данные верны");
            }
        }

        private void XCompanyLogo_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataBaseInterface.SetAvatar(DataSaver.UId, DataSaver.PasswordHash, ofd.FileName);
                XCompanyLogo.Source = new BitmapImage(new Uri(ofd.FileName));
            }
        }
    }
}