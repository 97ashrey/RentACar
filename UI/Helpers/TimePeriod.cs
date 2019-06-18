using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Helpers
{
    public class TimePeriod
    {
        public enum TimePeriodRelation
        {
            After,
            StartTouching,
            StartInside,
            InsideStartTouching,
            EnclosingStartTouching,
            Enclosing,
            Before,
            EnclosingEndTouching,
            ExactMatch,
            Inside,
            InsideEndTouching,
            EndInside,
            EndTouching,
            NoRelation
        }

        private DateTime start;
        private DateTime end;

        public DateTime Start { get => start; set => start = value.Date; }
        public DateTime End { get => end; set => end = value.Date; }

        public TimePeriod(DateTime start, DateTime end)
        {
            if(end < start)
            {
                throw new ArgumentException();
            }
            Start = start;
            End = end;
        }

        public int GetDaySpan()
        {
            return (int)(End - Start).TotalDays;
        }

        public TimePeriodRelation GetRelation(TimePeriod other)
        {
            TimePeriodRelation relation = TimePeriodRelation.NoRelation;
            if (this.IsAfter(other))
            {
                relation = TimePeriodRelation.After;
            }
            else if (this.IsStartTouching(other))
            {
                relation = TimePeriodRelation.StartTouching;
            }
            else if (this.StartsInside(other))
            {
                relation = TimePeriodRelation.StartInside;
            }
            else if (this.IsInsideStartTouching(other))
            {
                relation = TimePeriodRelation.InsideStartTouching;
            }
            else if (this.IsEnclosingStartTouching(other))
            {
                relation = TimePeriodRelation.EnclosingStartTouching;
            }
            else if (this.IsEnclosing(other))
            {
                relation = TimePeriodRelation.Enclosing;
            }
            else if (this.IsEnclosingEndTouching(other))
            {
                relation = TimePeriodRelation.EnclosingEndTouching;
            }
            else if (this.IsExactMatch(other))
            {
                relation = TimePeriodRelation.ExactMatch;
            }
            else if (this.IsInside(other))
            {
                relation = TimePeriodRelation.Inside;
            }
            else if (this.IsInsideEndTouching(other))
            {
                relation = TimePeriodRelation.InsideEndTouching;
            }
            else if(this.EndsInside(other))
            {
                relation = TimePeriodRelation.EndInside;
            }
            else if (this.IsEndTouching(other))
            {
                relation = TimePeriodRelation.EndTouching;
            }
            else if (this.IsBefore(other))
            {
                relation = TimePeriodRelation.Before;
            }


            return relation;
        }

        public bool IsAfter(TimePeriod other)
        {
            return other.End < Start;
        }

        public bool IsStartTouching(TimePeriod other)
        {
            //int dayDiff = (int)(Start - other.End).TotalDays;
            //return dayDiff == 1? true:false;
            return other.start < Start && other.end == Start;
        }

        public bool StartsInside(TimePeriod other)
        {
            return other.Start < Start && Start < other.End;
        }

        public bool IsInsideStartTouching(TimePeriod other)
        {
            return other.Start == Start && End < other.End;
        }

        public bool IsEnclosingStartTouching(TimePeriod other)
        {
            return Start == other.Start && other.End < End;
        }

        public bool IsEnclosing(TimePeriod other)
        {
            return Start < other.Start && other.Start < End && other.End > Start && other.End < End;
        }

        public bool IsEnclosingEndTouching(TimePeriod other)
        {
            return Start < other.start && End == other.End;
        }

        public bool IsExactMatch(TimePeriod other)
        {
            return Start == other.Start && End == other.End;
        }

        public bool IsInside(TimePeriod other)
        {
            return other.Start <= Start && Start <= other.End && End >= other.Start && End <= other.End;
        }

        public bool IsInsideEndTouching(TimePeriod other)
        {
            return other.Start < Start && End == other.End;
        }

        public bool EndsInside(TimePeriod other)
        {
            return Start < other.start && other.Start <= End && End < other.End;
        }

        public bool IsEndTouching(TimePeriod other)
        {
            //int dayDiff = (int)(other.Start - End).TotalDays;
            //return dayDiff == 1 ? true : false;
            return other.Start == End && other.end > End;
        }

        public bool IsBefore(TimePeriod other)
        {
            return other.Start > End;
        }

        // special cases
        public bool HasInside(TimePeriod other)
        {
            return (IsEnclosingStartTouching(other) || 
                    IsEnclosing(other) ||
                    IsEnclosingEndTouching(other) ||
                    IsExactMatch(other));
        }

        public bool OverlapsWith(TimePeriod other)
        {
            return (StartsInside(other) ||
                    IsInsideStartTouching(other) ||
                    HasInside(other) ||
                    IsInside(other) ||
                    IsInsideEndTouching(other) ||
                    EndsInside(other)
                    ); 
        }

        public bool IntersectsWith(TimePeriod other)
        {
            return (IsStartTouching(other) ||
                    OverlapsWith(other) ||
                    IsEndTouching(other)
                     );
        }

        public bool IsBefore(DateTime date)
        {
            return End < date;
        }

        public bool IsAfter(DateTime date)
        {
            return Start > date;
        }

        public bool HasInside(DateTime date)
        {
            return Start <= date && date <= End;
        }

        public static TimePeriod[] GetFreePeriods(TimePeriod range, TimePeriod[] reservedPeriods)
        {
            List<TimePeriod> output = new List<TimePeriod>();
            // subtract one day from range start to count that day while searching
            reservedPeriods = reservedPeriods.Where(
                    period => range.IntersectsWith(period)
                    )
                .OrderBy(period => period.Start).ToArray();

            TimePeriod newPeriod = new TimePeriod(range.Start, range.Start);
            foreach (TimePeriod period in reservedPeriods)
            {
                TimePeriod.TimePeriodRelation relation = period.GetRelation(newPeriod);
                if (!period.IntersectsWith(newPeriod))
                {
                    // calc the free period
                    int dayDiff = (int)(period.Start - newPeriod.End).TotalDays;
                    //dayDiff += dayDiff == 1 ? 0:1; 
                    TimePeriod freePeriod = new TimePeriod(period.Start.AddDays(-dayDiff), period.Start.AddDays(-1));
                    output.Add(freePeriod);
                }

                // move the period to the end of current reserved period
                newPeriod.Start = newPeriod.End = period.End.AddDays(1);
            }
            // get the last period
            TimePeriod last = reservedPeriods.Last();
            // check if range period is not enclosing end touching last reserved period
            if (!range.IsEnclosingEndTouching(last))
            {
                // add the last free period
                output.Add(new TimePeriod(last.End.AddDays(1), range.End));
            }

            return output.ToArray();
        }

        public override string ToString()
        {
            return $"From {Start.ToShortDateString()} To {End.ToShortDateString()}";
        }
    }
}
