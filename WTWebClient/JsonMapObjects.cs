using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dot.Json;
using dot.Json.Linq;
using System.Drawing;

namespace WTWebClient
{
    public class JsonMapObjects
    {
        private JArray Objects
        {
            get;
            set;
        }
        public bool FromJsonString(String json)
        {
            try
            {
                var mapObjects = JArray.Parse(json);
                if (mapObjects.Count < 1)
                    return false;

                Objects = mapObjects;
            }
            catch
            {
                return false;
            }
            return true;
        }
        public int Count
        {
            get
            {
                if (Objects == null)
                    return 0;
                else
                    return Objects.Count;
            }
        }
        public PointF PlayerDirection
        {
            get
            {
                if (Count > 0)
                {
                    var player = Objects.FirstOrDefault(o => (String)o["icon"] == "Player");
                    if (player != null)
                    {
                        return new PointF((float)player["dx"], (float)player["dy"]);
                    }
                }
                return new PointF(0.0f, 0.0f);
            }

        }
        public PointF PlayerPosition
        {
            get
            {
                if (Count > 0)
                {
                    var player = Objects.FirstOrDefault(o => (String)o["icon"] == "Player");
                    if (player != null)
                    {
                        return new PointF((float)player["x"], (float)player["y"]);
                    }
                }
                return new PointF(0.5f, 0.5f);
            }
        }
    }
}
