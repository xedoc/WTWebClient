using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WTWebClient
{
    public enum IconType
    {
        None,
        Fighter,
        Player,
        Ship,
        Wheeled,
        Airdefence
    }
    public class ObjectIcon
    {
        public ObjectIcon (IconType value )
        {
            IconType = value;
        }
        public static implicit operator ObjectIcon( String value )
        {
            IconType type;
            switch (value.ToLower() )
            {
                case "fighter":
                     type = IconType.Fighter;
                    break;
                case "player":
                     type = IconType.Player;
                    break;
                case "ship":
                     type = IconType.Ship;
                    break;
                case "wheeled":
                     type = IconType.Wheeled;
                    break;
                case "airdefence":
                     type = IconType.Airdefence;
                    break;
                default:
                    type = IconType.None;
                    break;                
            }
            return new ObjectIcon(type);
        }
        public IconType IconType
        {
            get;set;
        }
    }
}
