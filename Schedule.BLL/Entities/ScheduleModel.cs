using System;

namespace ScheduleProject.DAL.Entities
{
    public partial class ScheduleModel
    {
        public int Id { get; set; }
        public TimeSpan SubjectStart { get; set; }
        public TimeSpan SubjectEnd { get; set; }
        public int Day { get; set; }
        public string Class { get; set; }
        public string Group { get; set; }
        public string Subject { get; set; }
        public int Teacher { get; set; }
    }
}