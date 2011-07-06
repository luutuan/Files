using System;
using System.Collections.Generic;
using System.Collections;
namespace Assignemnt01
{
	public class Student
	{


		public string Id { get; set; }

		public string FirstName { get; set; }

		public string MiddleName { get; set; }

		public string LastName { get; set; }

        public Timetable timetable;

        public List<string> courseEnrolled;
		public Student ()
		{
		}
		
		public void ChangeEnrolledCourseID (string oldone, string newone)
		{
			for(int i = 0; i<courseEnrolled.Count;i++){
				if(string.Compare(courseEnrolled[i],oldone)==0){
					courseEnrolled[i] = newone;
				}
			}
			
		}
		
		
		public void ChangeCoureIDTimeTable (string oldone, string newone)
		{
			timetable.ChangeCourseIDInDayTimeTable (oldone, newone);
		}

		public Student (string idt, string firstNamet, string middleNamet, string lastNamet)
		{
			Id = idt;
			FirstName = firstNamet;
			MiddleName = middleNamet;
			LastName = lastNamet;
            timetable = new Timetable();
            courseEnrolled = new List<string>();
		}

        public bool Enroll(string courseID, string day, double beginTime, double endTime)
        {
            if (courseEnrolled.Count >= 4)
            {
                throw new Exception("Reach enroll limit");

            }
            if (timetable.ReserveTimeWithoutCheck(courseID, day, beginTime, endTime))
            {
                courseEnrolled.Add(courseID);
                return true;
            }

            return false;

        }

        public override string ToString()
        {
            return ("Student Detail: Student ID " + Id + " Student name: "+ FirstName + " " + MiddleName + " "+ " " + LastName); ;
        }
		
		
		
	}
}

