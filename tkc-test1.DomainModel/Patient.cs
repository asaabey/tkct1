using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tkc_test1.DomainModel;

namespace tkct1.DomainModel
{
    public class Patient
    {
        public int Id { get; set; }
        public int Source_id { get; set; }
        public int Sex { get; set; }
        public int Indigenous_status { get; set; }
        public DateTime Date_of_birth { get; set; }
        public Nullable<DateTime> Date_of_death { get; set; }
        public string Post_code { get; set; }
        public Nullable<int> Age { get; set; }
        
        public bool IsValid { get; set; }

        public Status Status { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public ICollection<TSDataPoint> TSDataPoints { get; set; }

        override public string  ToString()
        {
            return String.Format("Id : {0}, Dob : {1}, Dod : {2}",Id,Date_of_birth,Date_of_death);
        }

        public Patient()
        {
            Status = new Status();
            TSDataPoints = new List<TSDataPoint>();
            Notifications = new List<Notification>();
            IsValid = true;
        }

        public bool HasComponent(string component)
        {
            bool _r = false;

            if (TSDataPoints.Count>0)
            {
                var c = TSDataPoints.Where(o => o.Component == component).Count();

                if (c>0)
                {
                    _r = true;
                }
            }

            return _r;
        }

        public TSDataPoint GetLastTimeSeriesDataPoint(string component)
        {
            TSDataPoint _t = new TSDataPoint();

            if (TSDataPoints.Count>0)
            {
                var c = TSDataPoints.Where(o => o.Component == component).LastOrDefault();

                if (c!=null)
                {
                    _t = c;
                }
            }
            return _t;
        }

        public TSDataPoint GetNthTimeSeriesDataPointWithOffset(string component, int dayoffset, int rank)
        {
            TSDataPoint _t = new TSDataPoint();

            IList<TSDataPoint> _tsdps = TSDataPoints.Where(o=>o.Component==component).ToList();

            if (_tsdps.Count>0)
            {
                int _lastIndex = _tsdps.Count - 1;

                for (int i = 0; i < _lastIndex; i++)
                {
                    int _ts = ((TimeSpan)(_tsdps[_lastIndex].Date - _tsdps[i].Date)).Days;
                    if (_ts>dayoffset)
                    {
                        _t = _tsdps[i];
                        break;
                    }
                }

            }

            return _t;
        }

        public int GetComponentCount(string component)
        {
            return TSDataPoints.Where(o => o.Component == component).Count();
        }
    }
}
