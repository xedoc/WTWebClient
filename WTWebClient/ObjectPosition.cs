using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WTWebClient
{
    public class ObjectPosition
    {
        public ObjectPosition()
        {
            Position = PointF.Empty;
            Direction = PointF.Empty;
            SouthPoint = PointF.Empty;
            EastPoint = Point.Empty;
        }
        public ObjectPosition(PointF position):this()
        {
            Position = position;
        }
        public ObjectPosition(PointF position, PointF direction):this(position)
        {
            Direction = direction;
        }
        public ObjectPosition(PointF position, PointF direction, PointF southPoint, PointF eastPoint):this(position,direction)
        {
            SouthPoint = southPoint;
            EastPoint = eastPoint;
        }
        public PointF Position
        {
            get;
            set;
        }
        public PointF Direction
        {
            get;
            set;
        }
        public PointF SouthPoint
        {
            get;
            set;
        }
        public PointF EastPoint
        {
            get;
            set;
        }
        
    }
}
