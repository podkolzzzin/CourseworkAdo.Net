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
    /// Interaction logic for PMessageForm.xaml
    /// </summary>
    public partial class PMessageForm : UserControl,IPage
    {
        public Message Message { get; set; }
        public string Topic
        {
            get
            {
                return Message.Topic;
            }
        }
        public string Author
        {
            get
            {
                return Message.Author;
            }
        }
        public string Text
        {
            get
            {
                return Message.Text;
            }
        }
        public PMessageForm()
        {
            this.InitializeComponent();
        }

        public PMessageForm(Message message)
        {
            Message = message;
            this.InitializeComponent();
            XAuthor.Text = Author;
            XTopic.Text = Topic;
            XText.Text = Text;
        }
        public void OnHiding(EventHandler remover)
        {
            Storyboard a = (Storyboard)TryFindResource("OnUnloaded1");
            a.Completed += remover;
            a.Begin();
        }
    }
}