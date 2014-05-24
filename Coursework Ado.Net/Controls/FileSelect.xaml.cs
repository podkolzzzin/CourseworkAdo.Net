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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Coursework_Ado.Net
{
	/// <summary>
	/// Interaction logic for FileSelect.xaml
	/// </summary>
    public delegate void PropertyChanged(string name,object value);
	public partial class FileSelect : UserControl
	{
        public string PName { get { return XName.Text; } set { XName.Text = value; } }
        public string PPath { get; set; }
		public FileSelect()
		{
			this.InitializeComponent();
		}
        public event PropertyChanged OnPropertyChanged;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            System.Windows.Forms.DialogResult result = ofd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                PPath = ofd.FileName;
                XFilePath.Text = "Выберите файл: " + new FileInfo(PPath).Name;
                if (OnPropertyChanged != null)
                    OnPropertyChanged(PName, PPath);
            }
        }
	}
}