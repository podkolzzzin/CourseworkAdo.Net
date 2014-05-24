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
    /// Interaction logic for OmniBox.xaml
    /// </summary>
    public partial class OmniBox : UserControl
    {
        public string Placeholder
        {
            get
            {
                return _placeholder;
            }
            set
            {
                _setPlaceHolder(value);
            }
        }
        public string Text
        {
            get
            {
                if (_t.Foreground != Brushes.Silver)
                    return _t.Text;
                return "";
            }
            set
            {
                _t.Text = value;
                _t.FontStyle = FontStyles.Normal;
                _t.Foreground = Brushes.Black;
            }
        }
        public TextWrapping TextWrapping { get { return _t.TextWrapping; } set { _t.TextWrapping = value; } }
        public bool AcceptsReturn { get { return _t.AcceptsReturn; } set { _t.AcceptsReturn = value; } }
        public OmniBox()
        {
            this.InitializeComponent();
            GotFocus += OmniBox_GotFocus;
            LostFocus += OmniBox_LostFocus;
        }

        void OmniBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_t.Text == "")
            {
                _t.Text = _placeholder;
                _t.FontStyle = FontStyles.Italic;
                _t.Foreground = Brushes.Silver;
            }
        }

        void OmniBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_t.Text == _placeholder && _t.Foreground == Brushes.Silver)
            {
                _t.Text = "";
                _t.FontStyle = FontStyles.Normal;
                _t.Foreground = Brushes.Black;
            }
        }
        private string _placeholder;
        private void _setPlaceHolder(string value)
        {
            _placeholder = value;
            if (_t.Text == "")
            {
                _t.Text = value;
                _t.FontStyle = FontStyles.Italic;
                _t.Foreground = Brushes.Silver;
            }
        }
    }
}