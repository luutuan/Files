using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Assignemnt01
{
    public class RoomAdmin : BaseClass, CommonFunctions
    {
        public RoomAdmin ()
        {

        }

		public void ChangeCourseID (string oldone, string newone)
		
		{
			Room ro;
			
			IEnumerator iterator = objectList.GetEnumerator ();
			while (iterator.MoveNext ()) {
				ro = iterator.Current as Room;
				ro.ChangeCoureIDTimeTable (oldone, newone);
					
			}
			
		}

        public bool CheckUniqueID (string id)
        {
        	Room ro;
   
			IEnumerator iterator = objectList.GetEnumerator ();
        	while (iterator.MoveNext ()) {
        		ro = iterator.Current as Room;
				if (string.Compare (ro.Name, id) == 0) {
					return false;
				}
				
			}
			
			
            return true;
        }


        public Room GetRoomFromIndex(int index)
        {
            if (index <= 0 || index > objectList.Count)
            {
                throw new Exception("Wrong index");
            }
            index -= 1;
            Room ro;
            foreach (object element in objectList)
            {
                if (0 == index)
                {
                    ro = element as Room;

                    return ro;
                }
                index--;
            }
            return null;
        }

        

    }
}
