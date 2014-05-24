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
    /// Interaction logic for PropertyShower.xaml
    /// </summary>
    public partial class PropertyShower : UserControl
    {
        public event PropertyChanged OnProperyChanged;
        public PropertyShower()
        {
            _property = new PersonalProperty();
            this.InitializeComponent();
        }
        public PropertyShower(string name, object value)
        {
            _property = new PersonalProperty(name,value,PropertyType.Unknown);
            this.InitializeComponent();
            PName = name;
            PValue = value;
        }
        public string PName { get { return XPropertyName.Text; } set { Property.Name = value; XPropertyName.Text = Property.Name; } }
        public object PValue { get { return XPropertyValue.Text; } set { Property.Value = value; XPropertyValue.Text = Property.Value.ToString(); } }
        public PropertyType PType { get { return Property.Type; } set { Property.Type = value; } }
        private bool _isAlwaysReadable;
        public bool AlwaysReadable
        {
            get { return _isAlwaysReadable; }
            set
            {
                if (!value)
                {
                    _property.Value = XPropertyValue.Text;
                    XPropertyValue.IsReadOnly = true;
                    XPropertyValue.Background = Brushes.Transparent;
                    XPropertyValue.BorderThickness = new Thickness(0);
                }
                else
                {
                    XPropertyValue.IsReadOnly = false;
                    makeReadable = true;
                    XPropertyValue.Background = Brushes.White;
                    XPropertyValue.BorderThickness = new Thickness(1);
                    XPropertyValue.Focus();                   
                }
                _isAlwaysReadable = value;
            }
        }
        private PersonalProperty _property;
        public PersonalProperty Property
        {
            get { return _property; }
            set
            {
                try
                {
                    _property = value;
                    this.XPropertyValue.Text = _property.Value.ToString();
                    this.XPropertyName.Text = _property.Name;
                }
                catch { }
            }
        }
        bool makeReadable = false;
        private void XPropertyValue_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (AlwaysReadable) return;
            if (makeReadable && e.Key != Key.Enter)
            {
                XPropertyValue.IsReadOnly = false;
                makeReadable = false;
            }
            if (e.Key == Key.T && XPropertyValue.IsReadOnly == true)
            {
                makeReadable = true;
                XPropertyValue.Background = Brushes.White;
                XPropertyValue.BorderThickness = new Thickness(1);
                XPropertyValue.Focus();
            }
            else if (e.Key == Key.Enter && XPropertyValue.IsReadOnly == false)
            {
                _property.Value = XPropertyValue.Text;
                XPropertyValue.IsReadOnly = true;
                XPropertyValue.Background = Brushes.Transparent;
                XPropertyValue.BorderThickness = new Thickness(0);
                if (OnProperyChanged != null)
                    OnProperyChanged(_property.Name, _property.Value);
            }
        }
    }
}