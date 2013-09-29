using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WTWebClient
{
    public enum ModelType
    {
        Airfield,
        Aircraft,
        GroundModel,
        Unknown
    }
    public class ObjectType
    {
        private ModelType _type;
        public ObjectType( ModelType value)
        {
            _type = value;
        }
        public static implicit operator ObjectType(ModelType value)
        {
            return new ObjectType(value);
        }
        public static implicit operator ObjectType(String value)        
        {           
            ModelType type;
            switch (value.ToLower())
            {
                case "airfield":
                    type = ModelType.Airfield;
                    break;
                case "aircraft":
                    type = ModelType.Aircraft;
                    break;
                case "ground_model":
                    type = ModelType.GroundModel;
                    break;
                default:
                    type = ModelType.Unknown;
                    break;
            }
            return new ObjectType( type );
        }
        public static explicit operator ModelType( ObjectType value)
        {
            return value._type;
        }
        public static bool operator != (ObjectType x, ModelType y)
        {
            return x._type != y;
        }
        public static bool operator ==(ObjectType x, ModelType y)
        {
            return x._type == y;
        }
        public static bool operator !=(ModelType y, ObjectType x)
        {
            return x._type != y;
        }
        public static bool operator ==(ModelType y, ObjectType x)
        {
            return x._type == y;
        }
        public override bool Equals(object obj)
        {
            try
            {
                return this == (ObjectType)obj;
            }
            catch {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
