using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Assignemnt01
{
    public class StudentAdmin : BaseClass, CommonFunctions
    {
        public StudentAdmin()
        {
        }

		
		public void ChangeCourseIDTimetable (string oldone, string newone)
		{
			Student stu;
			
			IEnumerator iterator = objectList.GetEnumerator ();
			while (iterator.MoveNext ()) {
				stu = iterator.Current as Student;
				stu.ChangeCoureIDTimeTable (oldone, newone);
				
			}
			
		}
		
		public void ChangeCourseEnrolledID (string oldone, string newone)
		{
			Student stu;
			
			IEnumerator iterator = objectList.GetEnumerator ();
			while (iterator.MoveNext ()) {
				stu = iterator.Current as Student;
				stu.ChangeEnrolledCourseID (oldone, newone);
				
			}
			
		}

        public bool CheckUniqueID(string id)
            {
            Student stu;
            foreach (object element in objectList)
                {
                stu = element as Student;
                if (string.Compare(stu.Id, id) == 0)
                    {
                    return false;
                    }
                }
            return true;
            }




        public Student GetStudentFromIndex(int index)
            {
            if (index <= 0 || index > objectList.Count)
                {
                throw new Exception("Wrong index");
                }
            index -= 1;
            Student stu;
            foreach (object element in objectList)
                {
                if (0 == index)
                    {
                    stu = element as Student;

                    return stu;
                    }
                index--;
                }
            return null;
            }

        

    }
}
