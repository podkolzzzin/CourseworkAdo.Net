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
	/// Interaction logic for PersonalProperyShower.xaml
	/// </summary>
	public partial class PersonalProperyShower : UserControl
	{
        private PPersonalForm _parent;
		public PersonalProperyShower(PersonalProperty prop,PPersonalForm parent)
		{         
			this.InitializeComponent();
            XPropertyValue.IsReadOnly = true;
            Property = prop;
            _parent = parent;
		}
        public string PName { get { return Property.Name; } set { Property.Name = value; } }
        public object PValue { get { return Property.Value; } set { Property.Value = value; } }
        public PropertyType PType { get { return Property.Type; } set { Property.Type = value; } }

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
            if (makeReadable && e.Key!=Key.Enter)
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
                _parent.PropertyChanged(_property);

            }
        }
	}
}