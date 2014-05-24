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
	/// Interaction logic for PResumeEditForm.xaml
	/// </summary>
	public partial class PResumeEditForm : UserControl, IPage
	{
		public PResumeEditForm()
		{
			this.InitializeComponent();
            var code = DataBaseInterface.GetUserResume(DataSaver.UId, DataSaver.PasswordHash, DataSaver.UId);
            XResumeCode.OnProperyChanged += XResumeCode_OnProperyChanged;
		}

        void XResumeCode_OnProperyChanged(string name, object value)
        {
            DataBaseInterface.SetUserResume(DataSaver.UId, DataSaver.PasswordHash);
            MessageBox.Show("Резюме успешно сохранено");
        }

        public void OnHiding(EventHandler remover)
        {
            Storyboard a = (Storyboard)TryFindResource("OnUnloaded1");
            a.Completed += remover;
            a.Begin();
        }
	}
}