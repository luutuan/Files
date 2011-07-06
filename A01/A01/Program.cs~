using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Assignemnt01
{

	public class Program
	{
		static AdminControl admin = new AdminControl ();

		public Program ()
		{
			
		}

		
		public void ProgramControl ()
		{
			Console.WriteLine ("||||||||||||||||||||||||||| Main Control |||||||||||||||||||||||||||");
			bool runCheck = true;
			while (runCheck) {
				Console.WriteLine ("1 - Course Admin");
				Console.WriteLine ("2 - Lecturer Admin");
				Console.WriteLine ("3 - Class Admin");
				Console.WriteLine ("4 - Student Admin");
				Console.WriteLine ("5 - Room Admin");
				Console.WriteLine ("6 - Report enrolment records");
				Console.WriteLine ("7 - Print time table");
				Console.WriteLine ("9 - Quit");
				int choice = Convert.ToInt32 (Console.ReadLine ());
				Console.Clear ();
				switch (choice) {
				
				case 1:
					
					admin.RunCourseAdmin ();
					break;
				case 2:
					admin.RunLecturerAdmin ();
					break;
				case 3:
					admin.RunClassAdmin ();
					break;
				case 4:
					admin.RunStudentAdmin ();
					break;
				case 5:
					admin.RunRoomAdmin ();
					break;
				case 6:
					admin.ReportEnrollmentRecords ();
					break;
				case 7:
					admin.ReportTimeTable ();
					break;
				case 9:
					runCheck = false;
					break;
				default:
					break;
				}
			}
		}
		
	}
}
