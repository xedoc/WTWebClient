using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;
namespace WTWebClient
{
    /// <summary>
    /// Interaction logic for WTMap.xaml
    /// </summary>
    public partial class WTMap : UserControl
    {
        private Point origin;
        private Point start;

        public WTMap()
        {
            InitializeComponent();

            TransformGroup group = new TransformGroup();

            ScaleTransform xform = new ScaleTransform();
            group.Children.Add(xform);

            TranslateTransform tt = new TranslateTransform();
            group.Children.Add(tt);

            mapimage.RenderTransform = group;

            mapimage.MouseWheel += mapimage_MouseWheel;
            mapimage.MouseLeftButtonDown += mapimage_MouseLeftButtonDown;
            mapimage.MouseLeftButtonUp += mapimage_MouseLeftButtonUp;
            mapimage.MouseMove += mapimage_MouseMove;
        }
        private void mapimage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mapimage.ReleaseMouseCapture();
        }

        private void mapimage_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mapimage.IsMouseCaptured) return;

            var tt = (TranslateTransform)((TransformGroup)mapimage.RenderTransform).Children.First(tr => tr is TranslateTransform);
            Vector v = start - e.GetPosition(border);
           
            var newX = origin.X - v.X;
            var newY = origin.Y - v.Y;            


            //Rect mapBounds = mapimage.RenderTransform.TransformBounds(new Rect(mapimage.RenderSize));
            //Rect borderBounds = border.RenderTransform.TransformBounds(new Rect(border.RenderSize));
            //Debug.Print("xy:{0}, offset: {1}", mapBounds.TopLeft, v);

            var p = mapimage.TranslatePoint(new Point(0, 0) - v, border);

            if (p.X > 0)
            {
                tt.X = -p.X;
            }
            else
            {
                tt.X = newX;
            }
            Debug.Print("xy:{0}", newX);

            tt.Y = newY;


        }

        private void mapimage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mapimage.CaptureMouse();
            var tt = (TranslateTransform)((TransformGroup)mapimage.RenderTransform).Children.First(tr => tr is TranslateTransform);
            start = e.GetPosition(border);
            origin = new Point(tt.X, tt.Y);
        }

        private void mapimage_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            TransformGroup transformGroup = (TransformGroup)mapimage.RenderTransform;
            ScaleTransform transform = (ScaleTransform)transformGroup.Children[0];

            double zoom = e.Delta > 0 ? .2 : -.2;
            if (transform.ScaleX + zoom < 1 || transform.ScaleY + zoom < 1)
                zoom = 0;

            transform.ScaleX += zoom;
            transform.ScaleY += zoom;
            
            Debug.Print("{0}x{1}", transform.ScaleX, transform.ScaleY);
        }

        public static Size GetActualSize(FrameworkElement control)
        {
            Size startSize = new Size(control.ActualWidth, control.ActualHeight);

            // go up parent tree until reaching root
            var parent = LogicalTreeHelper.GetParent(control);
            while (parent != null && parent as FrameworkElement != null && parent.GetType() != typeof(Window))
            {
                // try to find a scale transform
                FrameworkElement fp = parent as FrameworkElement;
                ScaleTransform scale = FindScaleTransform(fp.RenderTransform);
                if (scale != null)
                {
                    startSize.Width *= scale.ScaleX;
                    startSize.Height *= scale.ScaleY;
                }
                parent = LogicalTreeHelper.GetParent(parent);
            }
            // return new size
            return startSize;
        }

        public static ScaleTransform FindScaleTransform(Transform hayStack)
        {
            if (hayStack is ScaleTransform)
            {
                return (ScaleTransform)hayStack;
            }
            if (hayStack is TransformGroup)
            {
                TransformGroup group = hayStack as TransformGroup;
                foreach (var child in group.Children)
                {
                    if (child is ScaleTransform)
                    {
                        return (ScaleTransform)child;
                    }
                }
            }
            return null;
        }
    }
}
