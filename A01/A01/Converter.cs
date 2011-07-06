using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignemnt01
{
    class Converter
    {
        public double s2d (string time)
        {
        	//slpit the string hh:mm to double hh,mm
        	string[] parts = time.Split (':');
        	if (parts.Length != 2)
            {
        		throw new Exception ("Wrong format - hh:mm");
        	}
        	if (String.Compare (parts[1], "00") != 0)
            {
        		if (String.Compare (parts[1], "30") != 0)
                {
        			throw new Exception ("Wrong format - hh:MM");
        		}
        	}

            if (string.Compare (parts[1], "30") == 0)
            {
        		parts[1] = "5";
        	} else {
        		parts[1] = "0";
        	}
        	string stringtime = parts[0] + "." + parts[1];
        	double doubletime = Convert.ToDouble (stringtime);
            return doubletime;
        }

        public string d2s (double time)
        {
			int check = (int)(time/0.5);
			
			if((check%2)==0){
				return (String.Format("{0:00}",(check / 2)) + ":00");
			}else{
				return (String.Format ("{0:00}", (check-1)/2) + ":30");
			}
        }
		
		public string FormatResult (string str)
		{
			if (string.Compare (str, "-") == 0) {
				return str;
			}
			
			string[] parts = str.Split ('-');
			StringBuilder rstr = new StringBuilder ();
			rstr.Append (DoFormat (parts[0])+"-"+DoFormat (parts[1]));
			return rstr.ToString();
			
		
		}
		
		string DoFormat (string str)
		{
			StringBuilder rstr = new StringBuilder ();
			if (str.Length > 7) {
				rstr.Append (str.Substring (0, 5) + "..");
				return rstr.ToString ();
			} else {
				return str;
			}
			
			
			
		}
		
		
		
    }
}
