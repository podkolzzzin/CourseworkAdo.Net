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
	/// Interaction logic for ManagerCornerItem.xaml
	/// </summary>
	public partial class ManagerCornerItem : UserControl
	{
		public ManagerCornerItem(string text,string linkText,UIElement linkHref)
		{
			this.InitializeComponent();
            Link t = new Link(linkText);
            t.HREF = linkHref;
            this.LayoutRoot.Children.Add(t);
            TextBlock b = new TextBlock();
            b.Text = text;
            this.LayoutRoot.Children.Add(b);
            Grid.SetColumn(t, 1);

		}
	}
}