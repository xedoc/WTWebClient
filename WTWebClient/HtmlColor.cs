using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WTWebClient
{
    public class HtmlColor
    {
        private String _htmlcolor;
        private Color _color;

        public HtmlColor(String value)
        {
            Color = ColorTranslator.FromHtml(value);
        }
        public HtmlColor(Color value)
        {
            Color = value;
        }
        public static implicit operator HtmlColor(Color value)
        {
            return new HtmlColor(value);
        }
        public static implicit operator HtmlColor(String value)
        {
            return new HtmlColor(value);
        }
        public Color Color
        {
            get;
            set;
        }
    }
}
