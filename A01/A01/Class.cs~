using System;
using System.Collections.Generic;
namespace Assignemnt01
{
    public class Class
    {
        public string LecturerID { get; set; }
        public string CourseID { get; set; }
        public List<string> studentID = new List<string>();
        public List<ClassPeriod> classPeriod = new List<ClassPeriod>();

        public Class (string lid, string cid)
        {
        	LecturerID = lid;
        	CourseID = cid;
        }
		
		
		public void ChangeRoomNameClassPeriod (string oldone, string newone)
		
		{
			for (int i = 0; i < classPeriod.Count; i++) {
				if (string.Compare (classPeriod[i].RoomName, oldone) == 0) {
					classPeriod[i].RoomName = newone;
				}
			}
		}
		
		public void ChangeCourseIDClassPeriod (string oldone, string newone)
		
		{
			for (int i = 0; i < classPeriod.Count; i++) {
				if (string.Compare (classPeriod[i].Courseid, oldone) == 0) {
					classPeriod[i].Courseid = newone;
				}
			}
		}
		
		public void ChangeLecturerIDClassPeriod (string oldone, string newone)
		{
			for (int i = 0; i < classPeriod.Count; i++) {
				if (string.Compare (classPeriod[i].Courseid, oldone) == 0) {
					classPeriod[i].RoomName = newone;
				}
			}
		}
		
		public void ChangeStudentID (string oldone, string newone)
		{
			for (int i = 0; i < studentID.Count; i++) {
				if (string.Compare (studentID[i], oldone) == 0) {
					studentID[i] = newone;
				}
				
			}
		}
		
		
		
        public void AddClassPeriod(Room ro, string weekday, double starttime, double endtime)
        {
            if (!ro.timetable.ReserveTime(CourseID, weekday, starttime, endtime))
            {
                throw new Exception("Create new class period faild");
            }
            classPeriod.Add(new ClassPeriod(weekday, starttime, endtime, ro.Name, CourseID,LecturerID));

        }

        public void EnrollStudent(Student stu)
        {
            ClassPeriod cpe;

            foreach (object element in classPeriod)
            {
                cpe = element as ClassPeriod;
                if (!stu.timetable.CheckTime(cpe.WeekDay, cpe.StartTime, cpe.EndTime))
                {

                    throw new Exception("Time clashed");
                }
            }

            foreach (object element in classPeriod)
            {
                cpe = element as ClassPeriod;
                if (!stu.Enroll(cpe.Courseid, cpe.WeekDay, cpe.StartTime, cpe.EndTime))
                {
                    throw new Exception("Cannot enroll");
                }
            }
            studentID.Add(stu.Id);
        }

        public override string ToString()
        {
            return ("Class Detail: CourseID: "+ CourseID + " " + " LecturerID: "+ LecturerID);
        }
    }
}

