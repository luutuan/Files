using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignemnt01
{
	public class Course
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Timetable timetable = new Timetable();
		

		public Course ()
		{
		}
		
		

		public Course (string idt, string namet, string dest)
		{
			Id = idt;
			Name = namet;
			Description = dest;
		}
		
		override public string ToString ()
		
		{
			return ("Course Detail: Course ID "+Id + " Course Name: "+Name);
		}
	}
}
