using System;
namespace Assignemnt01
{
	public class ClassPeriod
	{
		
		public string WeekDay { get; set; }
		public double StartTime { get; set; }
		public double EndTime{get; set;}
        public string RoomName { get; set; }
        public string Courseid { get; set; }
        public string Lecturerid { get; set; }
		
		public ClassPeriod ()
		{
		
		}
		
		public ClassPeriod (string weekdayt, double stime, double etime, string rname,string courseidt,string lectureridt)
		{
            
			WeekDay = weekdayt;
			StartTime = stime;
			EndTime = etime;
            RoomName = rname;
            Courseid = courseidt;
            Lecturerid = lectureridt;
			
		}
	}
}

