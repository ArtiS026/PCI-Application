using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaCabinInc.Model
{
    public class ScheduleModel
    {
        public class ScheduleResponse
        {
            public TeamSchedule ScheduleResult { get; set; }
        }
        public class Schedule
        {
            public int ContractTimeMinutes { get; set; }
            public DateTimeOffset Date { get; set; }
            public bool IsFullDayAbsence { get; set; }
            public string Name { get; set; }
            public string PersonId { get; set; }
            public List<Projection> Projection { get; set; }
        }

        public class Projection
        {
            public string Color { get; set; }
            public string Description { get; set; }
            public DateTimeOffset Start { get; set; }
            public int Minutes { get; set; }
        }

        public class TeamSchedule
        {
            public List<Schedule> Schedules { get; set; }
        }

    }
}
