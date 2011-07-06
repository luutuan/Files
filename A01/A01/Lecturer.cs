using System;
namespace Assignemnt01
{
	public class Lecturer
		
	{
		
		public string Id { get; set; }

		public string FirstName { get; set; }

		public string MiddleName { get; set; }

		public string LastName { get; set; }
		
		public Timetable timetable;


		public Lecturer ()
		{
			timetable = new Timetable();
		}
		
		public Lecturer (string idt, string firstNamet, string middleNamet, string lastNamet)
		{
			Id = idt;
			FirstName = firstNamet;
			MiddleName = middleNamet;
			LastName = lastNamet;
            timetable = new Timetable();
		}
		
		override public string ToString ()
		
		{
			return ("Lecturer Detail: Lecturer ID "+Id + " Lecturer Name: "+ FirstName + " " +MiddleName +" " + LastName);
		}
		
		
	}
}

