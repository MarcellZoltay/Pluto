using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto.BLL.Model
{
    public class Period : MyBindableBase
    {
        private static DateTime defaultDate = new DateTime();

        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                if (endDate != defaultDate && value > endDate)
                    throw new InvalidOperationException("Start date cannot be greater, than end date.");

                SetProperty(ref startDate, value);
            }
        }

        private DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                if (startDate != defaultDate && value < startDate)
                    throw new InvalidOperationException("End date cannot be smaller, than start date.");

                SetProperty(ref endDate, value);
            }
        }

        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
