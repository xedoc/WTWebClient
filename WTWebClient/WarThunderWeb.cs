using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using dotWebClient;
namespace WTWebClient
{
    public class WarThunderWeb
    {
        private const int WebPort = 8111;
        private const String mapPath = "map.img?gen={0}";
        private const String objectsPath = "map_obj.json";
        private const String missionPath = "mission.json";
        private const String infoPath = "map_info.json";
        private const String chatPath = "gamechat?lastId={0}";

        private Timer timerInfo, timerObjects, timerChat, timerMission, timerMapImage;
        private CookieAwareWebClient wcInfo, wcObjects, wcChat, wcMission, wcMapImage;
        private Object lockInfo, lockObjects, lockChat, lockMission, lockMapImage;
        public event EventHandler<StringEventArgs> OnError;
        public event EventHandler<EventArgs> OnStart;
        public event EventHandler<EventArgs> OnMapImage;
        public WarThunderWeb()
        {
            wcInfo = new CookieAwareWebClient();
            wcObjects = new CookieAwareWebClient();
            wcChat = new CookieAwareWebClient();
            wcMission = new CookieAwareWebClient();
            wcMapImage = new CookieAwareWebClient();
            LastChatId = 0;
            MapInfo = new JsonMapInfo();

            lockInfo = lockObjects = lockChat = lockMission = lockMapImage = new Object();
            timerInfo = new Timer(new TimerCallback(infoDownload_Tick), null, Timeout.Infinite, Timeout.Infinite);
            timerObjects = new Timer(new TimerCallback(objectsDownload_Tick), null, Timeout.Infinite, Timeout.Infinite);
            timerChat = new Timer(new TimerCallback(chatDownload_Tick), null, Timeout.Infinite, Timeout.Infinite);
            timerMission = new Timer(new TimerCallback(missionDownload_Tick), null, Timeout.Infinite, Timeout.Infinite);

        }
        public JsonMapInfo MapInfo
        {
            get;
            set;
        }
        public Uri Url
        {
            get;
            set;
        }
        public Int32 LastChatId
        {
            get;
            set;
        }
        public Bitmap MapImage
        {
            get;
            set;
        }
        public void Start()
        {            
            var testUrl = new CookieAwareWebClient();
            try
            {
                var content = testUrl.DownloadString(Url);
            }
            catch {
                if (OnError != null)
                    OnError(this, new StringEventArgs("Game isn't running or wrong host specified!"));

                return;
            }

            timerInfo.Change(0, 1000);
            timerObjects.Change(0, 50);
            //timerChat.Change(0, 1000);
            timerMission.Change(0, 1000);

            if( OnStart != null)
                OnStart(this, EventArgs.Empty);
        }

        public void Stop()
        {
            timerInfo.Change(Timeout.Infinite, Timeout.Infinite);
            timerObjects.Change(Timeout.Infinite, Timeout.Infinite);
            timerChat.Change(Timeout.Infinite, Timeout.Infinite);
            timerMission.Change(Timeout.Infinite, Timeout.Infinite);
        }
        private void infoDownload_Tick(object o)
        {
            downloadInfo();

        }
        private void objectsDownload_Tick(object o)
        {
            downloadObjects();
        }

        private void chatDownload_Tick(object o)
        {
            downloadChat();
        }

        private void missionDownload_Tick(object o)
        {
            downloadMission();
        }

        private void downloadMapImage()
        {
            lock (lockMapImage)
            {
                try
                {
                    var imageData = wcMapImage.DownloadData(String.Format("http://{0}:{1}/{2}", Url.Host, WebPort,
                        String.Format(mapPath, MapInfo.MapGen)));
                    if (imageData == null)
                        return;

                    MemoryStream instream = new MemoryStream(imageData);
                    MapImage = (Bitmap)Image.FromStream(instream);
                    if (OnMapImage != null)
                        OnMapImage(this, EventArgs.Empty);
                }
                catch { }
            }
        }
        private void downloadObjects()
        {
            lock (lockObjects)
            {
                try
                {
                    var jsonString = wcObjects.DownloadString(String.Format("http://{0}:{1}/{2}", Url.Host, WebPort,
                        objectsPath));
                    if (String.IsNullOrEmpty(jsonString))
                        return;

                    var mapObjects = new JsonMapObjects();
                    mapObjects.FromJsonString(jsonString);
                }
                catch { }


            }
        }
        private void downloadMission()
        {
            lock (lockMission)
            {
                try
                {
                    var jsonString = wcObjects.DownloadString(String.Format("http://{0}:{1}/{2}", Url.Host, WebPort,
                        missionPath));
                }
                catch { }
            }
        }
        private void downloadChat()
        {
            lock (lockChat)
            {
                try
                {
                    var jsonString = wcObjects.DownloadString(String.Format("http://{0}:{1}/{2}", Url.Host, WebPort,
                        String.Format(chatPath, LastChatId)));

                    if( !String.IsNullOrEmpty(jsonString) )
                        Debug.Print(jsonString);
                }
                catch
                {
                }
            }
        }
        private void downloadInfo()
        {
            lock (lockInfo)
            {
                try
                {
                    var jsonString = wcObjects.DownloadString(String.Format("http://{0}:{1}/{2}", Url.Host, WebPort,
                       infoPath));
                    if (String.IsNullOrEmpty(jsonString))
                        return;

                    var oldMapGen = MapInfo.MapGen;

                    if (MapInfo.FromJsonString(jsonString))
                    {
                        if (oldMapGen != MapInfo.MapGen && MapInfo.MapGen > 0)
                            ThreadPool.QueueUserWorkItem(f => downloadMapImage());
                    }
                }
                catch { }
            }
        }
    }
    public class StringEventArgs : EventArgs
    {
        public StringEventArgs(String arg)
        {
            Message = arg;
        }

        public String Message { get; private set; }
    }    

}
