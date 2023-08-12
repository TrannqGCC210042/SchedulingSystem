using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal interface IManagement
    {
        void Add();
        void Update();
        void Delete();
        void Search();
        void DisplayInfor();
        bool IsEmpty();
        bool Confirm(string message);
        Object InputInformation();
    }
}
