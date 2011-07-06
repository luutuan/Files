using System;
using System.Collections.Generic;
namespace Assignemnt01
{
	public class Room 
	{
		public string Name { get; set; }
        public Timetable timetable;
		
		public Room (string namet)
		
		{
            
			Name = namet;
            timetable = new Timetable();
		}

        public void ChangeCoureIDTimeTable (string oldone, string newone)
        {
			timetable.ChangeCourseIDInDayTimeTable(oldone,newone);
        }
		

        public override string ToString()
        {
            return ("Room Detail: Room name " + Name ); ;
        }
	}
}



