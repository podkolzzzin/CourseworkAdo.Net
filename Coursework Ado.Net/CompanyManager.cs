using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coursework_Ado.Net
{
    public class CompanyManager
    {
        private User _manager;
        public string ManagerLogin { get { return _manager.Login;}  }
        public string ManagerFIO { get { return "Подколзин Андрей Юрьевич"; /*todo: getting fio*/ } }
        public string ManagerIfMainStr { get { if (true) return "admin"; else return "manager"; /*todo checking main*/ } }
        public CompanyManager(User manager)
        {
            _manager = manager;
        }
    }
}
