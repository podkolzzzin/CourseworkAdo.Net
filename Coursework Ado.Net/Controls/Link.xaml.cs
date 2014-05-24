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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Coursework_Ado.Net
{
    /// <summary>
    /// Interaction logic for Link.xaml
    /// </summary>
    public partial class Link : UserControl
    {
        public Link(string text)
        {
            InitializeComponent();
            XButton.Content = text;
        }
        public Link()
        {
            InitializeComponent();
        }
        public string Text { 
            get { return XButton.Content.ToString(); } 
            set { XButton.Content = value;XButton.FontSize=this.FontSize;} 
        }
        private string _hrefText;
        public string Href
        {
            get { return _hrefText; }
            set 
            { 
                if(_textToHref(value))
                    _hrefText = value; 
            }
        }
        private bool _textToHref( string value)
        {
            var t = value.Split('?');
            value = t[0];
            switch (value)
            { 
                case "PManagerListForm.xaml":
                    HREF = new PManagerListForm();
                    break;
                case "PManagerForm.xaml":
                    HREF = new PManagerForm();
                    break;
                case "PAddVacancyForm.xaml":
                    HREF = new PAddVacancyForm();
                    break;
                case "PCompanyInfoForm.xaml":
                    HREF = new PCompanyInfoForm(Convert.ToInt32(t[1]));
                    break;
                case "PUserInfoForm.xaml":
                    HREF = new PUserInfoForm(Convert.ToInt32(t[1]));
                    break;
                case "PReferencesForm.xaml":
                    HREF = new PUserReferences(t[1][0], Convert.ToInt32(t[1].Substring(1)));
                    break;
                case "PResumeForm.xaml":
                    HREF = new PResumeForm(Convert.ToInt32(t[1]));
                    break;
                case "PResumeEditForm.xaml":
                    HREF = new PResumeEditForm();
                    break;
                case "PLikedForm.xaml":
                    break;
                case "PMailForm.xaml":
                    HREF = new PMailForm();
                    break;
                case "PSearchForm.xaml":
                    HREF=new PSearchForm(t[1][0], Convert.ToInt32(t[1].Substring(1)));
                    break;
                case "PSettingsForm.xaml":
                    HREF = new PSettingsForm();
                    break;
                case "PWriteMessageForm.xaml":
                    try
                    {
                        HREF = new PWriteMessageForm(Convert.ToInt32(t[1]));
                    }
                    catch
                    {
                        HREF = new PWriteMessageForm();
                    }
                    break;
                default:
                    return false;
            }
			return true;
        }
        public UIElement HREF;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Navigate();
        }
        public void Navigate()
        {
            if (HREF != null)
                ((MainWindow)Application.Current.MainWindow).Navigate(HREF);        
        }
    }
}
