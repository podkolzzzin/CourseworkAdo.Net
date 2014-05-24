using Coursework_Ado.Net.Pages;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<UIElement> _prevPages;
        private int _currentNavigatePosition;
        public MainWindow()
        {
            _prevPages = new List<UIElement>();
            InitializeComponent();
            this.textBox.Visibility = Visibility.Hidden;
        }
        private UIElement _toRemove;
        private void _navigate(UIElement element)
        {
            try
            {
                try
                {
                    ((IPage)XMain.Children[0]).OnHiding(_remover);
                    _toRemove = XMain.Children[0];
                }
                catch { }
                //XMain.Children.Clear();
                XMain.Children.Add(element);
            }
            catch { }
        }
        private void _remover(object sender, EventArgs args)
        {
            XMain.Children.Remove(_toRemove);
        }
        public void Navigate(UIElement element)
        {
            if (DataSaver.CurrentUser != null)
            {
                this.textBox.Visibility = Visibility.Visible;
            }
            _navigate(element);
            if (_prevPages.Count - 1 == _currentNavigatePosition)
            {
                _prevPages.Add(element);
            }
            else
            {
                for (int i = _currentNavigatePosition + 1; i < _prevPages.Count; i++)
                {
                    _prevPages.RemoveAt(i);
                }             
                _prevPages.Add(element);

            }
            _currentNavigatePosition = _prevPages.Count - 1;
            _updButtons();
        }
        private void _updPage()
        {
            _navigate(_prevPages[_currentNavigatePosition]);
        }
        private void _updButtons()
        {
            XBackButton.IsEnabled = CanNavigateBack;
            XForwardButton.IsEnabled = CanNavigateForward;
        }
        public void NavigateForward()
        {
            if (CanNavigateForward)
            {
                _currentNavigatePosition++;
                _updPage();
            }
            _updButtons();
        }
        public void NavigateBack()
        {
            if (CanNavigateBack)
            {
                _currentNavigatePosition--;
                _updPage();
            }
            _updButtons();
        }

        public bool CanNavigateBack { get { return (_currentNavigatePosition != 0 && _prevPages.Count > 0); } }
        public bool CanNavigateForward { get { return (_currentNavigatePosition < _prevPages.Count - 1); } }

        private void XBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateBack();
        }

        private void XForwardButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateForward();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Navigate(new PLoginForm());
        }

        private void XMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void XMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void XClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch { }
        }

        private void textBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (textBox.Text.Length > 0)
                {
                    Navigate(new PSearchForm(textBox.Text));
                }
            }
        }
    }
}
