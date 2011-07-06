using System;
namespace Assignemnt01
{
	public class TestHN
	{
		static CourseAdmin courseAdmin = new CourseAdmin ();
		static LecturerAdmin lecturerAdmin = new LecturerAdmin ();
		static RoomAdmin roomAdmin = new RoomAdmin ();
		static ClassAdmin classAdmin = new ClassAdmin ();
		static StudentAdmin studentAdmin = new StudentAdmin ();

		public TestHN ()
		{
			classAdmin.InitCourseAdmin (courseAdmin);
			classAdmin.InitLecturerAdmin (lecturerAdmin);
		}


		public void AddCourseCheck ()
		{
			
			Console.WriteLine ("\n//////////////////////////////////////////////////////////////////////////////////");
			Console.WriteLine ("Add new Course: COSC0001");
			courseAdmin.Adds (new Course ("COSC0001", "Computer Sicense", "Organizing Computer Syatem"));
			
			
			Console.WriteLine ("Add new Course: COSC0002");
			courseAdmin.Adds (new Course ("COSC0002", "Net Sicense", "Organizing Computer Syatem"));
			
			Console.WriteLine ("Add new Course: COSC0004");
			courseAdmin.Adds (new Course ("COSC0004", "Database", "Organizing database Syatem"));
			
			Console.Write ("Add new Course: COSC0002 | Duplicated Course ID");
			if (!courseAdmin.CheckUniqueID ("COSC0001")) {
				Console.WriteLine ("  Unable to Add: Duplicated ID");
			}
			Console.WriteLine ("//////////////////////////////////////////////////////////////////////////////////");
			
		}


		public void ModifyCoursesCheck ()
		{
			Console.WriteLine ("\n//////////////////////////////////////////////////////////////////////////////////");
			Course cou1 = (Course)courseAdmin.objectList[0];
			Course cou2 = (Course)courseAdmin.objectList[1];
			
			Console.Write ("Change course ID COSC0001 to COSC0002");
			if (!courseAdmin.CheckUniqueID ("COSC0002")) {
				Console.WriteLine ("   Duplicatied ID");
			}
			Console.Write ("Change course ID COSC0001 to COSC0003");
			if (!courseAdmin.CheckUniqueID ("COSC0003")) {
				Console.WriteLine ("Duplicatied ID");
			} else
			{
				Console.WriteLine("Success");
			}
			studentAdmin.ChangeCourseEnrolledID (cou1.Id, "COSC0003");
			studentAdmin.ChangeCourseIDTimetable (cou1.Id, "COSC0003");
			
			
			
			roomAdmin.ChangeCourseID (cou1.Id, "COSC0003");
			
			classAdmin.ChangeCourseID (cou1.Id, "COSC0003");
			classAdmin.ChangeCourseIDCP (cou1.Id, "COSC0003");
			cou1.Id = "COSC0003";
			
			Console.WriteLine ("Change Course COSC 0002 name from Net sicense to Data Communication ");
			cou2.timetable.ChnageCourseNameComplexInTimeTable (cou2.Name, "Data Communication");
			cou2.Name = "Data Communication";
			Console.WriteLine ("//////////////////////////////////////////////////////////////////////////////////");
		}


		public void ListAllCourseCheck ()
		{
			Console.WriteLine ("\n//////////////////////////////////////////////////////////////////////////////////");
			courseAdmin.List ();
			Console.WriteLine ("//////////////////////////////////////////////////////////////////////////////////");
		}


		public void AddLecturerCheck ()
		{
			Console.WriteLine ("\n//////////////////////////////////////////////////////////////////////////////////");
			Console.WriteLine ("Add lecturer ID V0001 Name: A B C");
			lecturerAdmin.Adds (new Lecturer ("V0001", "A", "B", "C"));
			
			Console.WriteLine ("Add lecturer ID V0002 Name: X Y Z");
			lecturerAdmin.Adds (new Lecturer ("V0002", "X", "Y", "Z"));
			
			Console.Write ("Add lecturer ID V0001 Name: M N O");
			if (!lecturerAdmin.CheckUniqueID ("V0001")) {
				Console.WriteLine ("     Duplicated ID");
			}
			Console.WriteLine ("//////////////////////////////////////////////////////////////////////////////////");
			
		}
		
		public void ModifyLecturerCheck ()
		{
			Console.WriteLine ("\n//////////////////////////////////////////////////////////////////////////////////");
			Lecturer lec1 = (Lecturer)lecturerAdmin.objectList[0];
			Lecturer lec2 = (Lecturer)lecturerAdmin.objectList[1];
			
			Console.Write ("Modify Lecturer ABC ID from V0001 to V0002");
			if (!lecturerAdmin.CheckUniqueID ("V0002")) {
				Console.WriteLine ("    Duplicated ID");
			}
			Console.WriteLine ("Modify Lecturer ABC ID from V0001 to V0003");
			classAdmin.ChangeLecturerID (lec1.Id, "V00003");
			classAdmin.ChangeLecturerIDCP (lec1.Id, "V0003");
			lec1.Id = "V0003";
			
			Console.WriteLine ("Modify Lecturer name X Y Z to 1 2 3");
			string oldinfo = lecturerAdmin.GetNameFromID (lec2.Id);
			lec2.FirstName = "1";
			lec2.MiddleName = "2";
			lec2.LastName = "3";
			string newinfo = (lecturerAdmin.GetNameFromID (lec2.Id));
			Course cou;
			foreach (object item in courseAdmin.objectList) {
				
				cou = item as Course;
				cou.timetable.ChnageLecturerNameComplexInTimeTable (oldinfo, newinfo);
			
			}
			Console.WriteLine ("//////////////////////////////////////////////////////////////////////////////////");
		}
		
		public void ListAllLecturerCheck ()
		
		{
			Console.WriteLine ("\n//////////////////////////////////////////////////////////////////////////////////");
			lecturerAdmin.List ();
			Console.WriteLine ("//////////////////////////////////////////////////////////////////////////////////");
		}
		
		public void AddRoomCheck ()
		
		{
			Console.WriteLine ("\n//////////////////////////////////////////////////////////////////////////////////");
			Console.WriteLine ("Add room 1.11");
			roomAdmin.Adds (new Room ("1.11"));
			Console.WriteLine ("Add room 1.12");
			roomAdmin.Adds (new Room ("1.12"));
			Console.Write ("Add room 1.11 - Duplicated room");
			if (!roomAdmin.CheckUniqueID ("1.11")) {
				Console.WriteLine ("  Unable to add - Duplicated room name");
			}
			Console.WriteLine ("//////////////////////////////////////////////////////////////////////////////////");
		
		}
		
		public void ModifyRoomCheck ()
		{
			Console.WriteLine ("\n//////////////////////////////////////////////////////////////////////////////////");
			Room ro1 = (Room)roomAdmin.objectList[0];
			Room ro2 = (Room)roomAdmin.objectList[1];
			Console.WriteLine ("Change room name 1.11 to Bowen");
			classAdmin.ChangeRoomNameCP (ro1.Name, "Bowen");
			ro1.Name = "Bowen";
			
			Console.WriteLine ("Change room name 1.12 to Bowen");
			if (!roomAdmin.CheckUniqueID ("Bowen")) {
				Console.WriteLine ("Unable to Change Duplicated Room Name");
			}
			
			Console.WriteLine ("Change room name 1.12 to Mel");
			classAdmin.ChangeRoomNameCP (ro2.Name, "Mel");
			ro2.Name = "Mel";
			Console.WriteLine ("//////////////////////////////////////////////////////////////////////////////////");
		}
		
		public void ListRoomCheck ()
		{
			Console.WriteLine ("\n//////////////////////////////////////////////////////////////////////////////////");
			roomAdmin.List ();
			Console.WriteLine ("//////////////////////////////////////////////////////////////////////////////////");
		}
		
		public void AddClassCheck ()
		
		{
			Console.WriteLine ("\n//////////////////////////////////////////////////////////////////////////////////");
			Lecturer lec1 = (Lecturer)lecturerAdmin.objectList[0];
			Lecturer lec2 = (Lecturer)lecturerAdmin.objectList[1];
			Course cou1 = (Course)courseAdmin.objectList[0];
			Course cou2 = (Course)courseAdmin.objectList[1];
			Course cou3 = (Course)courseAdmin.objectList[2];
			
			Console.WriteLine ("Create new Class Course: " + cou1.Name + " Lecturer: " + lec1.Id);
			classAdmin.Adds (new Class (lec1.Id, cou1.Id));
			
			Console.WriteLine ("Create new Class Course: " + cou2.Name + " Lecturer: " + lec2.Id);
			classAdmin.Adds (new Class (lec2.Id, cou2.Id));
			
			Console.WriteLine ("Create new Class Course: " + cou3.Name + " Lecturer: " + lec2.Id);
			classAdmin.Adds (new Class (lec2.Id, cou3.Id));
			Console.WriteLine ("//////////////////////////////////////////////////////////////////////////////////");
		}
		
		public void AddClassPeriodToClass ()
		{
			Console.WriteLine ("\n//////////////////////////////////////////////////////////////////////////////////");
			Class cla1 = (Class)classAdmin.objectList[0];
			Class cla2 = (Class)classAdmin.objectList[1];
			Class cla3 = (Class)classAdmin.objectList[2];
			
			Room ro1 = (Room)roomAdmin.objectList[0];
			Room ro2 = (Room)roomAdmin.objectList[1];
			
			
			Course cou1 = (Course)courseAdmin.objectList[0];
			Course cou2 = (Course)courseAdmin.objectList[1];
			Course cou3 = (Course)courseAdmin.objectList[2];
			
			Lecturer lec1 = lecturerAdmin.GetLecturerFromID (cla1.LecturerID);
			Lecturer lec2 = lecturerAdmin.GetLecturerFromID (cla2.LecturerID);
			
			
			Console.WriteLine ("Add Class period for class 1 of Course: " + courseAdmin.GetNameFromID (cla1.CourseID) + " Lecturer ID" + lec1.Id + " in Monday from 8:00 to 9:30");
			cla1.AddClassPeriod (ro1, "monday", 8.00, 9.50);
			string info = courseAdmin.GetNameFromID (cla1.CourseID) + "-" + lecturerAdmin.GetNameFromID (cla1.LecturerID);
			cou1.timetable.ReserveTime (info, "monday", 8.00, 9.50);
			lec1.timetable.ReserveTime (cla1.CourseID, "monday", 8.00, 9.50);
			
			Console.WriteLine ("Add Class period for class 1 of Course: " + courseAdmin.GetNameFromID (cla1.CourseID) + " Lecturer ID" + lec1.Id + " in Thursday from 8:00 to 9:30");
			cla1.AddClassPeriod (ro1, "thursday", 8.00, 9.50);
			info = courseAdmin.GetNameFromID (cla1.CourseID) + "-" + lecturerAdmin.GetNameFromID (cla1.LecturerID);
			cou1.timetable.ReserveTime (info, "thursday", 8.00, 9.50);
			lec1.timetable.ReserveTime (cla1.CourseID, "thursday", 8.00, 9.50);
			
			Console.WriteLine ("Add Class period for class 2 of Course: " + courseAdmin.GetNameFromID (cla2.CourseID) + " Lecturer ID" + lec2.Id + " in Tuesday from 12:00 to 13:30");
			cla2.AddClassPeriod (ro2, "tuesday", 12.00, 13.50);
			info = courseAdmin.GetNameFromID (cla2.CourseID) + "-" + lecturerAdmin.GetNameFromID (cla2.LecturerID);
			cou2.timetable.ReserveTime (info, "tuesday", 12.00, 13.50);
			lec2.timetable.ReserveTime (cla2.CourseID, "tuesday", 12.00, 13.50);
			
			Console.WriteLine ("Add Class period for class 2 of Course: " + courseAdmin.GetNameFromID (cla2.CourseID) + " Lecturer ID" + lec2.Id + " in Friday from 15:00 to 16:30");
			cla2.AddClassPeriod (ro2, "friday", 15.00, 16.50);
			info = courseAdmin.GetNameFromID (cla2.CourseID) + "-" + lecturerAdmin.GetNameFromID (cla2.LecturerID);
			cou2.timetable.ReserveTime (info, "friday", 15.00, 16.50);
			lec2.timetable.ReserveTime (cla2.CourseID, "friday", 15.00, 16.50);
			
			Console.WriteLine ("Add Class period for class 3 of Course: " + courseAdmin.GetNameFromID (cla3.CourseID) + " Lecturer ID" + lec1.Id + " in Tuesday from 13:00 to 15:30");
			cla3.AddClassPeriod (ro1, "tuesday", 13.00, 15.50);
			info = courseAdmin.GetNameFromID (cla3.CourseID) + "-" + lecturerAdmin.GetNameFromID (cla3.LecturerID);
			cou3.timetable.ReserveTime (info, "tuesday", 13.00, 15.50);
			lec1.timetable.ReserveTime (cla3.CourseID, "tuesday", 13.00, 15.50);
			
			Console.WriteLine ("Add Class period for class 3 of Course: " + courseAdmin.GetNameFromID (cla3.CourseID) + " Lecturer ID" + lec2.Id + " in Saturday from 15:00 to 16:30");
			cla3.AddClassPeriod (ro2, "saturday", 15.00, 16.50);
			info = courseAdmin.GetNameFromID (cla3.CourseID) + "-" + lecturerAdmin.GetNameFromID (cla3.LecturerID);
			cou3.timetable.ReserveTime (info, "saturday", 15.00, 16.50);
			lec2.timetable.ReserveTime (cla3.CourseID, "saturday", 15.00, 16.50);
			
			Console.Write ("Add Class period for class 2 of Course: " + courseAdmin.GetNameFromID (cla2.CourseID) + " Lecturer ID" + lec2.Id + " in Monday from 9:00 to 10:30 -- Room already used: ");
			try 
			{
				cla2.AddClassPeriod (ro1, "monday", 9.00, 10.50);
			} catch (Exception ex) {
				Console.WriteLine (ex.Message);
			}
			
			Console.Write ("Add Class period for class 2 of Course: " + courseAdmin.GetNameFromID (cla2.CourseID) + " Lecturer ID" + lec1.Id + " in Monday from 9:00 to 10:30 -- Teacher already used: ");
			try {
				lec1.timetable.ReserveTime (cla2.CourseID, "monday", 9.00, 10.50);
			} catch (Exception ex) {
				Console.WriteLine (ex.Message);
			}
			Console.WriteLine ("//////////////////////////////////////////////////////////////////////////////////");
			
		}
		
		public void ListAllClassCheck ()
		{
			Console.WriteLine ("\n//////////////////////////////////////////////////////////////////////////////////");
			classAdmin.List ();
			Console.WriteLine ("//////////////////////////////////////////////////////////////////////////////////");
		}
		
		public void AddStudentCheck ()
		{
			Console.WriteLine ("\n//////////////////////////////////////////////////////////////////////////////////");
			Console.WriteLine ("Add student ID S0001 name S D F");
			studentAdmin.Adds (new Student ("S0001", "S", "D", "F"));
			
			Console.WriteLine ("Add student ID S0002 name H J K");
			studentAdmin.Adds (new Student ("S0001", "H", "J", "K"));
			
			Console.WriteLine ("Add student ID S0004 name R T U");
			studentAdmin.Adds (new Student ("S0004", "R", "T", "U"));
			
			Console.Write ("Add student ID S0001 - Duplicated ID");
			if (!studentAdmin.CheckUniqueID ("S0001")) {
				Console.WriteLine ("    Unable to add - Duplicated ID");
			}
			Console.WriteLine ("//////////////////////////////////////////////////////////////////////////////////");
		}
		
		public void ModifyStudentCheck ()
		{
			Console.WriteLine ("\n//////////////////////////////////////////////////////////////////////////////////");
			Student stu1 = (Student)studentAdmin.objectList[0];
			Student stu2 = (Student)studentAdmin.objectList[1];
			
			Console.Write ("Change student ID S0001 to S0002");
			if (!studentAdmin.CheckUniqueID ("S0002")) {
				Console.WriteLine ("   This ID already existed");
			}
			Console.WriteLine ("Change student ID S0001 to S0003");
			classAdmin.ChangeStudentID (stu1.Id, "S0003");
			stu1.Id = "S0003";
			
			Console.WriteLine ("Change student ID S0002 name HJK to UIO");
			stu2.FirstName = "U";
			stu2.MiddleName = "I";
			stu2.LastName = "O";
			Console.WriteLine ("//////////////////////////////////////////////////////////////////////////////////");
		}
		
		public void ListStudentCheck ()
		{
			Console.WriteLine ("\n//////////////////////////////////////////////////////////////////////////////////");
			studentAdmin.List ();
			Console.WriteLine ("//////////////////////////////////////////////////////////////////////////////////");
		}
		
		public void EnrollStudentToCourseCheck ()
		{
			Console.WriteLine ("\n//////////////////////////////////////////////////////////////////////////////////");
			Student stu1 = (Student)studentAdmin.objectList[0];
			Student stu2 = (Student)studentAdmin.objectList[1];
			Student stu3 = (Student)studentAdmin.objectList[2];
			
			Class cla1 = (Class)classAdmin.objectList[0];
			Class cla2 = (Class)classAdmin.objectList[1];
			Class cla3 = (Class)classAdmin.objectList[2];
			
			Console.WriteLine ("Enroll student: " + stu1.Id + " to course : " + cla1.CourseID + " of lecturer" + cla1.LecturerID);
			cla1.EnrollStudent (stu1);
			
			Console.WriteLine ("Enroll student: " + stu2.Id + " to course : " + cla2.CourseID + " of lecturer" + cla2.LecturerID);
			cla2.EnrollStudent (stu2);
			
			Console.WriteLine ("Enroll student: " + stu3.Id + " to course : " + cla1.CourseID + " of lecturer" + cla1.LecturerID);
			cla1.EnrollStudent (stu3);
			
			Console.WriteLine ("Enroll student: " + stu3.Id + " to course : " + cla2.CourseID + " of lecturer" + cla2.LecturerID);
			cla2.EnrollStudent (stu3);
			
			Console.WriteLine ("Enroll student: " + stu1.Id + " to course : " + cla3.CourseID + " of lecturer" + cla3.LecturerID);
			cla3.EnrollStudent (stu1);
			
			Console.Write ("Enroll student: " + stu3.Id + " to course : " + cla3.CourseID + " of lecturer" + cla3.LecturerID);
			try {
				cla3.EnrollStudent (stu3);
			} catch (Exception ex) {
				Console.WriteLine (ex.Message);
			}
			Console.WriteLine ("//////////////////////////////////////////////////////////////////////////////////");
			
			
		
			
		}
		
		public void ReportEnrollmentRecords ()
		{
			Console.WriteLine ("\n//////////////////////////////////////////////////////////////////////////////////");
			classAdmin.Reportenrolmentrecords ();
			Console.WriteLine ("//////////////////////////////////////////////////////////////////////////////////");
		}
		public void ReportTimeTable ()
		{
			Console.WriteLine ("\n//////////////////////////////////////////////////////////////////////////////////");
			courseAdmin.PrintTimeTable ();
			Console.WriteLine ("//////////////////////////////////////////////////////////////////////////////////");
		}
		
		public void RunTest ()
		
		{
			AddCourseCheck ();
			ListAllCourseCheck ();
			ModifyCoursesCheck ();
			ListAllCourseCheck ();
			
			AddLecturerCheck ();
			ListAllLecturerCheck ();
			ModifyLecturerCheck ();
			ListAllLecturerCheck ();
			
			AddRoomCheck ();
			ListRoomCheck ();
			ModifyRoomCheck ();
			ListRoomCheck ();
			
			AddClassCheck ();
			ListAllClassCheck ();
			AddClassPeriodToClass ();
			
			AddStudentCheck ();
			ListStudentCheck ();
			ModifyStudentCheck ();
			ListStudentCheck ();
			
			EnrollStudentToCourseCheck ();
			
			ReportEnrollmentRecords ();
			ReportTimeTable();
			
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
	}
}

