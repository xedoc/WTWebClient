using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dotUtilities;

namespace WTWebClient
{
    public partial class MainForm : Form
    {
        private WarThunderWeb wtWeb;
        public MainForm()
        {
            InitializeComponent();
            wtWeb = new WarThunderWeb();
            wtWeb.OnMapImage += new EventHandler<EventArgs>(wtWeb_OnMapImage);
            wtWeb.OnError += new EventHandler<StringEventArgs>(wtWeb_OnError);
            wtWeb.Url = new Uri("http://localhost:8111");
            wtWeb.Start();

            //pictureMap.Width = panelMap.Size.Width;
            //pictureMap.Height = panelMap.Size.Height;
            //mapPane.Scale(new SizeF(15.1f, 15.1f));
        }

        void wtWeb_OnError(object sender, StringEventArgs e)
        {
            Debug.Print(e.Message);
        }

        void wtWeb_OnMapImage(object sender, EventArgs e)
        {
            //Utils.SetProperty<PictureBox, Image>( mapPane, "BackgroundImage", wtWeb.MapImage );
            //wtWeb.MapImage.Save(
        }

        private void panelMap_SizeChanged(object sender, EventArgs e)
        {
            //mapPane.Width = panelMap.Size.Width;
            //mapPane.Height = panelMap.Size.Height;
        }

    }
}
