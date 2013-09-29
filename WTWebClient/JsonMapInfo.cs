using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dot.Json;
using dot.Json.Linq;
using System.Drawing;
namespace WTWebClient
{
    public class JsonMapInfo
    {
        public float StepX
        {
            get;
            set;
        }
        public float StepY
        {
            get;
            set;
        }
        public PointF ZeroPoint
        {
            get;
            set;
        }
        public UInt32 MapGen
        {
            get;
            set;
        }
        public PointF MaxPoint
        {
            get;
            set;
        }
        public PointF MinPoint
        {
            get;
            set;
        }
        public bool FromJsonString( String json )
        {
            try
            {
                var mapInfo = JObject.Parse(json);
                if (mapInfo.Count < 5)
                    return false;

                var mapGen = (UInt32)mapInfo["map_generation"];
                var stepX = (float)((JArray)mapInfo["grid_steps"])[0];
                var stepY = (float)((JArray)mapInfo["grid_steps"])[1];
                var zeroPoint = new PointF(
                    (float)((JArray)mapInfo["grid_zero"])[0],
                    (float)((JArray)mapInfo["grid_zero"])[1]);
                var maxPoint = new PointF(
                    (float)((JArray)mapInfo["map_max"])[0],
                    (float)((JArray)mapInfo["map_max"])[1]);
                var minPoint = new PointF(
                    (float)((JArray)mapInfo["map_min"])[0],
                    (float)((JArray)mapInfo["map_min"])[1]);

                MapGen = mapGen;
                StepX = stepX;
                StepY = stepY;
                ZeroPoint = zeroPoint;
                MaxPoint = maxPoint;
                MinPoint = minPoint;
            }
            catch
            {
                return false;
            }
            return true;
        }

    }

}
