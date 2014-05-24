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
	/// Interaction logic for PUserInfoForm.xaml
	/// </summary>
	public partial class PUserInfoForm : UserControl,IPage
	{
		public PUserInfoForm(int id)
		{
			this.InitializeComponent();
            User u = DataBaseInterface.GetUserById(DataSaver.UId, DataSaver.PasswordHash, id);
            XUserInfoList.Items.Insert(XUserInfoList.Items.Count-1,new PropertyShower("login",u.Login));
            XUserInfoList.Items.Insert(XUserInfoList.Items.Count-1, new PropertyShower("ФИО", u.FIO));
            foreach (Contact t in u.Contacts)
            {
                XUserInfoList.Items.Insert(XUserInfoList.Items.Count-1, new PropertyShower(t.Type, t.Value));
            }
            if (u.Company != null)
            {
                XUserCompanyLink.Href = "PCompanyInfoForm.xaml?" + u.Company.Id;
            }
            else
            {
                XUserIfManager.Visibility = Visibility.Hidden;
            }
            if (u.Avatar != null)
            {
                XUserAvatar.Source = u.Avatar;
            }
            else
            {
                XUserAvatar.Source = new BitmapImage(new Uri(DataSaver.Path + "camera_a.png"));
            }
            XResumeLink.Href = "PResumeForm.xaml?" + id;
            XCommentsLink.Href = "PReferencesForm.xaml?u" + id;
            XWriteMessage.Href = "PWriteMessageForm.xaml?" + id;
		}
        public void OnHiding(EventHandler remover)
        {
            Storyboard a = (Storyboard)TryFindResource("OnUnloaded1");
            a.Completed += remover;
            a.Begin();
        }
	}
}