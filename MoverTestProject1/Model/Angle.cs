using System;
using System.Threading.Tasks;

namespace MoverTestApp.Model
{
    public class Angle
    {
       // hour - minutes : Angle
        // 12 : 30 - 165 Degree
        // 3 : 30 - 75 Degree
        // 3: 15 - 7.5 Degree
        // 4:50 - 155 Degree
        // 12:00 - 0 Degree
        public static Task<double> AngleClock(int hour, int minutes)
        {
            double minAngle = minutes * 360 / 60;
            double hourAnglePart1 = 0;
            if (hour != 12)
                hourAnglePart1 = (hour * 360) / 12;

            double hourAnglePart2 = (30 * minutes) / (double)60;
            double hourAngle = hourAnglePart1 + hourAnglePart2;

            double angleEnclosed = Math.Abs(minAngle - hourAngle);
            if (angleEnclosed > 180)
                angleEnclosed = 360 - angleEnclosed;
            return Task.FromResult(angleEnclosed);
        }
    }
}
