using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem
{
    internal interface IObserver
    {
        void update(AppointmentRecord appointmentRecord);
    }
}
