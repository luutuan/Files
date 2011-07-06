using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignemnt01
{
	public class Timetable
	{
		public Dictionary<string, Daytimetable> weektimetable;
		public Timetable ()
		{
			weektimetable = new Dictionary<string, Daytimetable> ();
			
			string[] days = { "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday" };
			
			for (int i = 0; i < days.Length; i++) {
				weektimetable.Add (days[i], new Daytimetable ());
			}
			
			
		}

		public void ChangeCourseIDInDayTimeTable (string oldCourseID, string newCourseID)
		{
			
			foreach (KeyValuePair<string, Daytimetable> entry in weektimetable) {
				entry.Value.ChangeCourseID (oldCourseID, newCourseID);
			}
		}
		
		public void ChnageCourseNameComplexInTimeTable (string oldCourseName, string newCourseName)
		
		{
			foreach (KeyValuePair<string, Daytimetable> entry in weektimetable) {
				entry.Value.ChangeCourseNameComplex (oldCourseName, newCourseName);
			}
		}
		
		public void ChnageLecturerNameComplexInTimeTable (string oldLecName, string newLecName)
		{
			foreach (KeyValuePair<string, Daytimetable> entry in weektimetable) {
				entry.Value.ChangeLecturerNameComplex (oldLecName, newLecName);
			}
		}
		

		public bool CheckTime (string day, double beginTime, double endTime)
		{
			if (!weektimetable.ContainsKey (day)) {
				throw new Exception ("Wrong day");
				
			}
			
			if (endTime < beginTime) {
				throw new Exception ("Endtime < Begintime");
			}
			
			if (beginTime < 8.0 || beginTime > 18.0 || beginTime == 18) {
				throw new Exception ("Begin time out of range");
			}
			
			if (endTime < 8.0 || endTime > 18.0 || endTime == 8) {
				throw new Exception ("End time out of range");
			}
			
			Daytimetable dtb = weektimetable[day];
			for (double i = beginTime; i < endTime; i += 0.5) {
				string valueCheck = dtb.daytimetable[i];
				if (string.Compare (valueCheck, "-") != 0) {
					throw new Exception ("Time clashed");
				}
			}
			
			return true;
			
		}

		public bool ReserveTime (string info, string day, double beginTime, double endTime)
		{
			
			CheckTime (day, beginTime, endTime);
			
			
			Daytimetable dtb = weektimetable[day];
			
			for (double i = beginTime; i < endTime; i += 0.5) {
				dtb.daytimetable[i] = info;
			}
			return true;
		}


		public bool ReserveTimeWithoutCheck (string info, string day, double beginTime, double endTime)
		{
			
			
			Daytimetable dtb = weektimetable[day];
			
			for (double i = beginTime; i < endTime; i += 0.5) {
				dtb.daytimetable[i] = info;
			}
			return true;
		}

		public void Printme ()
		{
			Converter conv = new Converter ();
			Daytimetable dtb;
			int counter;
			Console.WriteLine (String.Format ("              {0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"));
			for (double i = 8; i < 18; i += 0.5) {
				Console.Write ((conv.d2s (i)) + "-" + (conv.d2s (i + 0.5))+"   ");
				counter = 0;
				foreach (KeyValuePair<string, Daytimetable> element in weektimetable) {
					dtb = element.Value;
					Console.Write (String.Format("{"+counter+",-15}", conv.FormatResult(dtb.daytimetable[i])));
				
				}
				Console.WriteLine();
			
			}
			
		}
		
	}

	public class Daytimetable
	{
		public SortedDictionary<double, string> daytimetable = new SortedDictionary<double, string> ();
		public Daytimetable ()
		{
			for (double i = 18; i >= 8; i -= (0.5)) {
				daytimetable.Add (i, "-");
			}
		}
		
		public void ChangeCourseNameComplex (string oldcourseid, string newcourseid)
		{
			
			List<double> keysToChange = new List<double> ();
			foreach (KeyValuePair<double, string> entry in daytimetable) {
				
				string[] parts = entry.Value.Split ('-');
				if (string.Compare (parts[0].Trim (), oldcourseid) == 0) {
					
					keysToChange.Add (entry.Key);
				}
			}
			
			foreach (double key in keysToChange) {
				string[] parts = daytimetable[key].Split ('-');
				daytimetable[key] = newcourseid + "-" + parts[1];
			}
		}
		
		public void ChangeLecturerNameComplex (string oldlecname, string newlecname)
		{
			
			List<double> keysToChange = new List<double> ();
			foreach (KeyValuePair<double, string> entry in daytimetable) {
				
				string[] parts = entry.Value.Split ('-');
				if (string.Compare (parts[1].Trim (), oldlecname) == 0) {
					
					keysToChange.Add (entry.Key);
				}
			}
			
			foreach (double key in keysToChange) {
				string[] parts = daytimetable[key].Split ('-');
				daytimetable[key] = parts[0]+"-"+newlecname;
			}
		}


		public void ChangeCourseID (string oldcourseid, string newcourseid)
		{
			List<double> keysToChange = new List<double> ();
			foreach (KeyValuePair<double, string> entry in daytimetable) {
				if (string.Compare (entry.Value, oldcourseid) == 0) {
					keysToChange.Add (entry.Key);
				}
			}
			
			foreach (double key in keysToChange) {
				daytimetable[key] = newcourseid;
			}
		}
		
	}
}
