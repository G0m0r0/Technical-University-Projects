using System;

namespace WindowsFormsApp4.Coordinates
 {
    [Serializable]
     public class MyPoint
     {
         public MyPoint(int x, int y)
         {
             this.XCenter = x;
             this.YCenter = y;
         }
         private int xCenter;
         private int yCenter;

         public int YCenter
         {
             get { return yCenter; }
             private set
             {
                 if (value < 0)
                 {
                     throw new Exception("Y coordinate can not be negative");
                 }
                 //to check
                 yCenter = value;
             }
         }


         public int XCenter
         {
             get { return xCenter; }
             private set
             {
                 if (value < 0)
                 {
                     throw new Exception("X coordinate can not be negative");
                 }                
                 xCenter = value;
             }
         }
     }
 }
