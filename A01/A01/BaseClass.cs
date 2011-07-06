using System;
using System.Collections;
namespace Assignemnt01
{
	public class BaseClass : IEnumerable
	{

		public ArrayList objectList;
		public BaseClass ()
		{
			objectList = new ArrayList ();
		}

		public bool Adds (object o)
		{
			objectList.Add (o);
			return true;
		}

		public void List ()
		{
			int counter = 0;
			foreach (object element in objectList) {
				Object ob = element as Object;
				if (null != ob) {
					counter++;
					Console.WriteLine ("+" + counter + ob.ToString ());
				}
				
			}
		}

		public IEnumerator GetEnumerator ()
		{
			foreach (object item in objectList) {
				yield return item;
			}
		}
		
		
		
	}
}

