using System.Collections;
using System;
using System.Text;
using System.Globalization;
using System.IO;
namespace Assignemnt01
{
	public class LecturerAdmin : BaseClass, CommonFunctions
	{
		
		public LecturerAdmin ()
		{
			
		}

		
		public bool CheckUniqueID (string id)
		{
			Lecturer lec;
			
			IEnumerator iterator = objectList.GetEnumerator ();
			while (iterator.MoveNext ()) {
				lec = iterator.Current as Lecturer;
				if (string.Compare (lec.Id, id) == 0) {
					return false;
				}
				
			}
			return true;
		}

		public string GetNameFromID (string lecturerID)
		{
			Lecturer lec;
			
			IEnumerator iterator = objectList.GetEnumerator ();
			while (iterator.MoveNext ()) {
				lec = iterator.Current as Lecturer;
				if (string.Compare (lec.Id, lecturerID) == 0) {
					return (lec.FirstName + lec.MiddleName + lec.LastName);
				}
			
			}
			
			return null;
		
			
		}
		
		public void ChangeCourseIDTB (string oldcourse, string newcourse)
		
		{
			Lecturer lec;
			
			IEnumerator iterator = objectList.GetEnumerator ();
			while (iterator.MoveNext ()) {
				lec = iterator.Current as Lecturer;
				lec.timetable.ChangeCourseIDInDayTimeTable(oldcourse,newcourse);
				
			}
		}
		
		public Lecturer GetLecturerFromID (string lecturerID)
		{
			Lecturer lec;
			
			IEnumerator iterator = objectList.GetEnumerator ();
			while (iterator.MoveNext ()) {
				lec = iterator.Current as Lecturer;
				if (string.Compare (lec.Id, lecturerID) == 0) {
					return lec;
				}
				
			}
			
			return null;
		}
		


		public Lecturer GetLecturerFromIndex (int index)
		{
			if (index <= 0 || index > objectList.Count) {
				throw new Exception ("Wrong index");
			}
			index -= 1;
			Lecturer lec;
			foreach (object element in objectList) {
				if (0 == index) {
					lec = element as Lecturer;
					
					return lec;
				}
				index--;
			}
			return null;
		}




	}
	
}

