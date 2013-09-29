using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WTWebClient
{

    public abstract class MapObject
    {
        public MapObject(String value)
        {
            Type = value;
        }
        public ObjectType Type
        {
            get;
            set;
        }
        public HtmlColor Color
        {
            get;
            set;
        }
        public bool Blink
        {
            get;
            set;
        }
        public ObjectIcon IconType
        {
            get;
            set;
        }
        public ObjectPosition Position
        {
            get;
            set;
        }
    }


}
