using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Coursework_Ado.Net.Pages
{
    public interface IPage
    {
         void OnHiding(EventHandler remover);
    }
}
