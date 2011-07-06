using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Assignemnt01
{
	public class ClassAdmin : BaseClass
	{
		CourseAdmin ca;
		LecturerAdmin la;
		public ClassAdmin ()
		{
		}

		
		public void ChangeLecturerID (string oldone, string newone)
		{
			Class cla;
			IEnumerator iterator = objectList.GetEnumerator ();
			while (iterator.MoveNext())
			{
				cla = iterator.Current as Class;
				if (string.Compare (cla.LecturerID, oldone) == 0) {
					cla.LecturerID = newone;
				}
				
			}
			
		}

		public void ChangeCourseID (string oldone, string newone)
		{
			Class cla;
			
			IEnumerator iterator = objectList.GetEnumerator ();
			while (iterator.MoveNext ()) {
				cla = iterator.Current as Class;
				if (string.Compare (cla.CourseID, oldone) == 0) {
					cla.CourseID = newone;
				}
				
			}
			
		}

		public void ChangeStudentID (string oldone, string newone)
		{
			Class cla;
			
			IEnumerator iterator = objectList.GetEnumerator ();
			while (iterator.MoveNext ()) {
				cla = iterator.Current as Class;
				cla.ChangeStudentID (oldone, newone);
			}
		}

		public void ChangeRoomNameCP (string oldone, string newone)
		{
			Class cla;
			
			IEnumerator iterator = objectList.GetEnumerator ();
			while (iterator.MoveNext ()) {
				cla = iterator.Current as Class;
				cla.ChangeRoomNameClassPeriod (oldone, newone);
			}
		}

		public void ChangeCourseIDCP (string oldone, string newone)
		{
			Class cla;
			
			IEnumerator iterator = objectList.GetEnumerator ();
			while (iterator.MoveNext ()) {
				cla = iterator.Current as Class;
				cla.ChangeCourseIDClassPeriod (oldone, newone);
			}
		}

		public void ChangeLecturerIDCP (string oldone, string newone)
		{
			Class cla;
			
			IEnumerator iterator = objectList.GetEnumerator ();
			while (iterator.MoveNext ()) {
				cla = iterator.Current as Class;
				cla.ChangeLecturerIDClassPeriod (oldone, newone);
			}
		}



		public void InitCourseAdmin (CourseAdmin cat)
		{
			ca = cat;
		}
		public void InitLecturerAdmin (LecturerAdmin lat)
		{
			la = lat;
		}

		public void Reportenrolmentrecords ()
		{
			
			Course cou;
			Class cla;
			int c1 = 1, c2 = 1;
			foreach (object element in ca.objectList) {
				cou = element as Course;
				Console.WriteLine ("+ Course: " + cou.Id + " - " + cou.Name);
				foreach (object element1 in objectList) {
					cla = element1 as Class;
					if (string.Compare (cou.Id, cla.CourseID) == 0) {
						Console.WriteLine ("     + Class " + c1 + " of LID: " + cla.LecturerID);
						foreach (object element2 in cla.studentID) {
							Console.WriteLine ("       + " + c2 + " StudentID: " + element2);
							c2++;
						}
						c1++;
						c2 = 1;
					}
				}
				
			}
		}

		public ArrayList ReturnClassPreriodOfCourse (string courseid)
		{
			Class cla;
			ClassPeriod clap;
			ArrayList resultList = new ArrayList ();
			foreach (object element1 in objectList) {
				cla = element1 as Class;
				if (string.Compare (courseid, cla.CourseID) == 0) {
					foreach (object element2 in cla.classPeriod) {
						clap = element1 as ClassPeriod;
						resultList.Add (clap);
					}
				}
				
			}
			
			
			
			
			return resultList;
		}

		public void Printtimetable ()
		{
			Course cou;
			ArrayList result;
			Timetable timetable;
			ClassPeriod clap;
			string tmp;
			foreach (object element in ca.objectList) {
				cou = element as Course;
				result = ReturnClassPreriodOfCourse (cou.Id);
				timetable = new Timetable ();
				foreach (object element1 in result) {
					clap = element1 as ClassPeriod;
					tmp = ca.GetNameFromID (clap.Courseid) + " - " + la.GetNameFromID (clap.Lecturerid);
					timetable.ReserveTime (tmp, clap.WeekDay, clap.StartTime, clap.EndTime);
				}
				Console.WriteLine ("Time table for: " + cou.Name);
				timetable.Printme ();
				timetable = null;
			}
			
			
		}


		public Class GetClassFromIndex (int index)
		{
			if (index <= 0 || index > objectList.Count) {
				throw new Exception ("Wrong index");
			}
			index -= 1;
			Class cla;
			foreach (object element in objectList) {
				if (0 == index) {
					cla = element as Class;
					
					return cla;
				}
				index--;
			}
			return null;
		}


		
	}
}
