using System;
using System.Text.RegularExpressions;
namespace Assignemnt01
{
	public class AdminControl
	{
		public static CourseAdmin courseAdmin = new CourseAdmin ();
		public static LecturerAdmin lecturerAdmin = new LecturerAdmin ();
		public static RoomAdmin roomAdmin = new RoomAdmin ();
		public static ClassAdmin classAdmin = new ClassAdmin ();
		public static StudentAdmin studentAdmin = new StudentAdmin ();
		public AdminControl ()
		{
			classAdmin.InitCourseAdmin (courseAdmin);
			classAdmin.InitLecturerAdmin (lecturerAdmin);
		}

		public void RunLecturerAdmin ()
		{
			int choice;
			Console.WriteLine ("||||||||||||||||||| Lecturer Control |||||||||||||||||||");
			bool cont = true;
			while (cont) {
				try {
					Console.WriteLine ("1 - Add Lecturer");
					Console.WriteLine ("2 - Modify Lecturer");
					Console.WriteLine ("3 - List Lecturer");
					Console.WriteLine ("4 - Quit");
					choice = Convert.ToInt32 (Console.ReadLine ());
					Console.Clear ();
					switch (choice) {
					case 1:
						
						{
							Console.Write ("Lectuere ID: ");
							string lid = Console.ReadLine ();
							if (!lecturerAdmin.CheckUniqueID (lid)) {
								throw new Exception ("Duplicatied ID");
							}
							Console.Write ("Lectuere First Name: ");
							string fname = Console.ReadLine ();
							Console.Write ("Lectuere Middle Name: ");
							string mname = Console.ReadLine ();
							
							Console.Write ("Lectuere Last Name: ");
							string lname = Console.ReadLine ();
							lecturerAdmin.Adds (new Lecturer (lid, fname, mname, lname));
							break;
						}

					case 2:
						{
							lecturerAdmin.List ();
							Console.Write ("Lecturer index: ");
							int lid = Convert.ToInt32 (Console.ReadLine ());
							
							
							Lecturer lec = lecturerAdmin.GetLecturerFromIndex (lid);
							string oldinfo = lecturerAdmin.GetNameFromID (lec.Id);
							Console.WriteLine ("Old value: " + ((lec).ToString ()));
							Console.WriteLine ("1 - Modify Lecturer ID");
							Console.WriteLine ("2 - Modify Lecturer First Name");
							Console.WriteLine ("3 - Modify Lecturer Middle Name");
							Console.WriteLine ("4 - Modify Lecturer Last Name");
							string newValue;
							int modifychoice = Convert.ToInt32 (Console.ReadLine ());
							Console.Clear ();
							switch (modifychoice) {
							case 1:
								Console.Write ("New Lecturer ID value: ");
								newValue = Console.ReadLine ();
								if (!lecturerAdmin.CheckUniqueID (newValue)) {
									throw new Exception ("Duplicatied ID");
								}
								classAdmin.ChangeLecturerID (lec.Id, newValue);
								classAdmin.ChangeLecturerIDCP (lec.Id, newValue);
								
								lec.Id = newValue;
								break;
							
							case 2:
								Console.Write ("New Lecturer First Name value: ");
								newValue = Console.ReadLine ();
								lec.FirstName = newValue;
								break;
							
							case 3:
								Console.Write ("New Lecturer Middle Name value: ");
								newValue = Console.ReadLine ();
								lec.MiddleName = newValue;
								break;
							
							case 4:
								Console.Write ("New Lecturer Last Name value: ");
								newValue = Console.ReadLine ();
								lec.LastName = newValue;
								break;
								
							}
							Console.Clear ();
							string newinfo = (lecturerAdmin.GetNameFromID (lec.Id));
							Course cou;
							foreach (object item in courseAdmin.objectList) {
								
								cou = item as Course;
								cou.timetable.ChnageLecturerNameComplexInTimeTable (oldinfo, newinfo);
								
							}
							break;
						}
					case 3:
						lecturerAdmin.List ();
						
						break;
					
					case 4:
						cont = false;
						break;
					default:
						Console.WriteLine ("Wrong choice");
						break;
						
					}
				} catch (Exception e) {
					Console.WriteLine ("Exception: " + e.Message);
				}
			}
		}

		public void RunCourseAdmin ()
		{
			int choice;
			Console.WriteLine ("||||||||||||||||||| Course Control |||||||||||||||||||");
			bool cont = true;
			while (cont) {
				try {
					Console.WriteLine ("1 - Add Course");
					Console.WriteLine ("2 - Modify Course");
					Console.WriteLine ("3 - List Course");
					Console.WriteLine ("4 - Quit");
					choice = Convert.ToInt32 (Console.ReadLine ());
					Console.Clear ();
					switch (choice) {
					case 1:
						{
							Console.Write ("Course ID: ");
							string cid = Console.ReadLine ();
							if (!courseAdmin.CheckUniqueID (cid)) {
								throw new Exception ("Duplicatied ID");
							}
							Console.Write ("Course Name: ");
							string cname = Console.ReadLine ();
							Console.Write ("Course decritption: ");
							string cdes = Console.ReadLine ();
							Course newCourse = new Course (cid, cname, cdes);
							courseAdmin.Adds (newCourse);
							break;
						}
					case 2:
						{
							courseAdmin.List ();
							Console.Write ("Course ID: ");
							int cid = Convert.ToInt32 (Console.ReadLine ());
							Course cou = courseAdmin.GetCourseFromIndex (cid);
							Console.WriteLine ("Old value: " + ((cou).ToString ()));
							Console.WriteLine ("1 - Modify Course ID");
							Console.WriteLine ("2 - Modify Course Name");
							Console.WriteLine ("3 - Modify Course Des");
							string newValue;
							int modifychoice = Convert.ToInt32 (Console.ReadLine ());
							Console.Clear ();
							switch (modifychoice) {
							case 1:
								Console.Write ("New Course ID value: ");
								newValue = Console.ReadLine ();
								if (!courseAdmin.CheckUniqueID (newValue)) {
									throw new Exception ("Duplicatied ID");
								}
								studentAdmin.ChangeCourseEnrolledID (cou.Id, newValue);
								studentAdmin.ChangeCourseIDTimetable (cou.Id, newValue);
								
								
								
								roomAdmin.ChangeCourseID (cou.Id, newValue);
								
								classAdmin.ChangeCourseID (cou.Id, newValue);
								classAdmin.ChangeCourseIDCP (cou.Id, newValue);
								lecturerAdmin.ChangeCourseIDTB (cou.Id, newValue);
								cou.Id = newValue;
								
								break;
							
							case 2:
								Console.Write ("New Course Name value: ");
								newValue = Console.ReadLine ();
								cou.timetable.ChnageCourseNameComplexInTimeTable (cou.Name, newValue);
								cou.Name = newValue;
								break;
							
							case 3:
								Console.Write ("New Course Descirption value: ");
								newValue = Console.ReadLine ();
								cou.Description = newValue;
								break;
								
							}
							Console.Clear ();
							
							
							break;
						}
					case 3:
						courseAdmin.List ();
						
						break;
					
					case 4:
						cont = false;
						break;
					default:
						Console.WriteLine ("Wrong choice");
						break;
						
					}
				} catch (Exception e) {
					Console.WriteLine ("Exception: " + e.Message);
				}
			}
			
			
		}

		public void RunRoomAdmin ()
		{
			int choice;
			Console.WriteLine ("||||||||||||||||||| Room Control |||||||||||||||||||");
			bool cont = true;
			while (cont) {
				try {
					Console.WriteLine ("1 - Add Room");
					Console.WriteLine ("2 - Modify Room");
					Console.WriteLine ("3 - List Room");
					Console.WriteLine ("4 - Quit");
					choice = Convert.ToInt32 (Console.ReadLine ());
					Console.Clear ();
					switch (choice) {
					case 1:
						
						{
							Console.Write ("Room name: ");
							string rid = Console.ReadLine ();
							if (!roomAdmin.CheckUniqueID (rid)) {
								throw new Exception ("Duplicatied name");
							}
							
							roomAdmin.Adds (new Room (rid));
							break;
						}
					case 2:
						{
							roomAdmin.List ();
							Console.Write ("Room index: ");
							int rid = Convert.ToInt32 (Console.ReadLine ());
							Room ro = roomAdmin.GetRoomFromIndex (rid);
							Console.WriteLine ("Old value: " + ((ro).ToString ()));
							string newValue;
							Console.Write ("New Room Name value: ");
							newValue = Console.ReadLine ();
							if (!roomAdmin.CheckUniqueID (newValue)) {
								throw new Exception ("Duplicatied Name");
							}
							classAdmin.ChangeRoomNameCP (ro.Name, newValue);
							ro.Name = newValue;
							break;
						}
					case 3:
						roomAdmin.List ();
						
						break;
					
					case 4:
						cont = false;
						break;
					default:
						Console.WriteLine ("Wrong choice");
						break;
						
					}
				} catch (Exception e) {
					Console.WriteLine ("Exception: " + e.Message);
				}
			}
			
		}

		public void RunClassAdmin ()
		{
			int choice;
			Console.WriteLine ("||||||||||||||||||| Class Control |||||||||||||||||||");
			bool cont = true;
			while (cont) {
				try {
					Console.WriteLine ("1 - Add Class");
					Console.WriteLine ("2 - Modify Class");
					Console.WriteLine ("3 - List Class");
					Console.WriteLine ("4 - Quit");
					choice = Convert.ToInt32 (Console.ReadLine ());
					Console.Clear ();
					switch (choice) {
					case 1:
						{
							Console.Write ("Course ID: ");
							string cid = Console.ReadLine ();
							if (courseAdmin.CheckUniqueID (cid)) {
								throw new Exception ("Course ID not Existed");
								
							}
							Console.Write ("Lecturer ID: ");
							string lid = Console.ReadLine ();
							if (lecturerAdmin.CheckUniqueID (lid)) {
								throw new Exception ("Lecturer ID not Existed");
							}
							
							
							classAdmin.Adds (new Class (lid, cid));
							break;
						}
					case 2:
						{
							classAdmin.List ();
							String timeFormat = "^([0][8-9]|[1][0-8]):(00|30)$";
							Console.Write ("Class index: ");
							int cid = Convert.ToInt32 (Console.ReadLine ());
							Class cla = classAdmin.GetClassFromIndex (cid);
							Console.WriteLine ("Old value: " + ((cla).ToString ()));
							
							Console.WriteLine ("1 - Modify Lecturer ID");
							Console.WriteLine ("2 - Modify Course ID");
							Console.WriteLine ("3 - Add class period to class");
							string newValue;
							int modifychoice = Convert.ToInt32 (Console.ReadLine ());
							Console.Clear ();
							switch (modifychoice) {
							
							case 1:
								{
									Console.Write ("New Lecturer ID value: ");
									newValue = Console.ReadLine ();
									cla.LecturerID = newValue;
									break;
								}
							case 2:
								{
									Console.Write ("New Course ID value: ");
									newValue = Console.ReadLine ();
									cla.CourseID = newValue;
									break;
								}
							case 3:
								{
									Converter conv = new Converter ();
									roomAdmin.List ();
									Console.Write ("Choose A room by index");
									
									int chosenRoom = Convert.ToInt32 (Console.ReadLine ());
									Room cr = roomAdmin.GetRoomFromIndex (chosenRoom);
									
									Console.Write ("Week day: ");
									string cd = Console.ReadLine ();
									Match match;
									double st=0;
									while (true) {
										Console.Write ("Start time HH:MM");
										string sstime = Console.ReadLine ();
										match = Regex.Match (sstime, timeFormat);
										if (match.Success) {
											st = conv.s2d (sstime);
											break;
										}
									}
									
									double et=0;
									while (true) {
										Console.Write ("End time HH:MM");
										string setime = Console.ReadLine ();
										match = Regex.Match (setime, timeFormat);
										if (match.Success) {
											et = conv.s2d (setime);
											break;
										}
									}
									Lecturer lec = lecturerAdmin.GetLecturerFromID (cla.LecturerID);
									lec.timetable.ReserveTime (cla.CourseID, cd, st, et);
									cla.AddClassPeriod (cr, cd, st, et);
									Course cou = courseAdmin.GetCourseFromID (cla.CourseID);
									string info = courseAdmin.GetNameFromID (cla.CourseID) + "-" + lecturerAdmin.GetNameFromID (cla.LecturerID);
									cou.timetable.ReserveTime (info, cd, st, et);
									
									break;
								}

							default:
								break;
								
							}
							Console.Clear ();
							
							break;
						}
					case 3:
						classAdmin.List ();
						
						break;
					
					case 4:
						cont = false;
						break;
					default:
						Console.WriteLine ("Wrong choice");
						break;
						
					}
				} catch (Exception e) {
					Console.WriteLine ("Exception: " + e.Message);
				}
			}
			
		}

		public void RunStudentAdmin ()
		{
			int choice;
			Console.WriteLine ("||||||||||||||||||| Student Control |||||||||||||||||||");
			bool cont = true;
			while (cont) {
				try {
					Console.WriteLine ("1 - Add Student");
					Console.WriteLine ("2 - Modify Student");
					Console.WriteLine ("3 - List Student");
					Console.WriteLine ("4 - Quit");
					choice = Convert.ToInt32 (Console.ReadLine ());
					Console.Clear ();
					switch (choice) {
					case 1:
						
						{
							Console.Write ("Student ID: ");
							string sid = Console.ReadLine ();
							if (!studentAdmin.CheckUniqueID (sid)) {
								throw new Exception ("Duplicatied ID");
							}
							Console.Write ("Student First Name: ");
							string fname = Console.ReadLine ();
							Console.Write ("Student Middle Name: ");
							string mname = Console.ReadLine ();
							
							Console.Write ("Student Last Name: ");
							string lname = Console.ReadLine ();
							studentAdmin.Adds (new Student (sid, fname, mname, lname));
							break;
						}
					case 2:
						{
							studentAdmin.List ();
							Console.Write ("Student index: ");
							int sid = Convert.ToInt32 (Console.ReadLine ());
							Student stu = studentAdmin.GetStudentFromIndex (sid);
							Console.WriteLine ("Old value: " + ((stu).ToString ()));
							Console.WriteLine ("1 - Modify Student ID");
							Console.WriteLine ("2 - Modify Student First Name");
							Console.WriteLine ("3 - Modify Student Middle Name");
							Console.WriteLine ("4 - Modify Student Last Name");
							Console.WriteLine ("5 - Enroll this student to a class");
							string newValue;
							int modifychoice = Convert.ToInt32 (Console.ReadLine ());
							Console.Clear ();
							switch (modifychoice) {
							case 1:
								Console.Write ("New Student ID value: ");
								newValue = Console.ReadLine ();
								if (!studentAdmin.CheckUniqueID (newValue)) {
									throw new Exception ("Duplicatied ID");
								}
								classAdmin.ChangeStudentID (stu.Id, newValue);
								stu.Id = newValue;
								break;
							
							case 2:
								Console.Write ("New Student First Name value: ");
								newValue = Console.ReadLine ();
								stu.FirstName = newValue;
								break;
							
							case 3:
								Console.Write ("New Student Middle Name value: ");
								newValue = Console.ReadLine ();
								stu.MiddleName = newValue;
								break;
							
							case 4:
								Console.Write ("New Student Last Name value: ");
								newValue = Console.ReadLine ();
								stu.LastName = newValue;
								break;
							case 5:
								Console.Write ("Available class: ");
								classAdmin.List ();
								Console.Write ("Choose class index: ");
								int cid = Convert.ToInt32 (Console.ReadLine ());
								Class cl = classAdmin.GetClassFromIndex (cid);
								cl.EnrollStudent (stu);
								break;
							}
							Console.Clear ();
							break;
						}
					case 3:
						studentAdmin.List ();
						
						break;
					
					case 4:
						cont = false;
						break;
					default:
						Console.WriteLine ("Wrong choice");
						break;
						
					}
				} catch (Exception e) {
					Console.WriteLine ("Exception: " + e.Message);
				}
			}
			
		}


		public void ReportEnrollmentRecords ()
		{
			classAdmin.Reportenrolmentrecords ();
		}
		public void ReportTimeTable ()
		{
			courseAdmin.PrintTimeTable ();
		}
		
	}
}

