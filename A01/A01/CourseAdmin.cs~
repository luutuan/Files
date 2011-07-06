using System.Collections;
using System.Collections.Generic;

using System;
using System.Text;
using System.Globalization;
using System.IO;
namespace Assignemnt01
{
	public class CourseAdmin : BaseClass, CommonFunctions
	{

		public CourseAdmin ()
		{
		}



		public bool CheckUniqueID (string id)
		{
			Course cou;
			
			IEnumerator iterator = objectList.GetEnumerator ();
			while (iterator.MoveNext ()) {
				cou = iterator.Current as Course;
				if (string.Compare (cou.Id, id) == 0) {
					return false;
				}
				
			}
			return true;
		}

		public string GetNameFromID (string courseid)
		{
			
			Course cou;
			
			IEnumerator iterator = objectList.GetEnumerator ();
			while (iterator.MoveNext ()) {
				cou = iterator.Current as Course;
				if (string.Compare (cou.Id, courseid) == 0) {
					return cou.Name;
				}
				
			}
			
			return null;
		}

		public Course GetCourseFromID (string courseIDt)
		{
			Course cou;			
			IEnumerator iterator = objectList.GetEnumerator ();
			while (iterator.MoveNext ()) {
				cou = iterator.Current as Course;
				if (string.Compare (cou.Id, courseIDt) == 0) {
					return cou;
				}
			}
			return null;
		}



		public Course GetCourseFromIndex (int index)
		{
			if (index <= 0 || index > objectList.Count) {
				throw new Exception ("Wrong index");
			}
			index -= 1;
			Course cou;
			foreach (object element in objectList) {
				if (0 == index) {
					cou = element as Course;
					
					return cou;
				}
				index--;
			}
			return null;
		}

		
		public void PrintTimeTable ()
		{
			Course cou;
			foreach (object item in objectList) {
				cou = item as Course;
				cou.timetable.Printme ();
			}
		}
		
		
		
		
	}
	
}

