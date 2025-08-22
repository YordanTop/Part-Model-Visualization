using PartModelVis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;
using Point = System.Windows.Point;

namespace PartModelVis.Core.Helper
{
    public static class MouseHelper
    {

        public static Point DragImage(Point originalSelectedElementPoint, Point currentMousePoint, Point originalSelectedMousePoint)
        {
            Point DragPosition = new Point();

            DragPosition.X = originalSelectedElementPoint.X + (currentMousePoint.X - originalSelectedMousePoint.X);
            DragPosition.Y = originalSelectedElementPoint.Y + (currentMousePoint.Y - originalSelectedMousePoint.Y);

            return DragPosition;    
        }

        public static Point DragBoundaries(Point elementPoint, int elementHeight, int elementWidth, Canvas canvas)
        {
            Point Boundary = new Point();

            Boundary.X = Math.Max(0, Math.Min(canvas.ActualWidth - elementWidth, elementPoint.X));
            Boundary.Y = Math.Max(0, Math.Min(canvas.ActualHeight - elementHeight, elementPoint.Y));



            return Boundary;
        }

        public static void RotateImage(MouseEventArgs mouseEvent)
        {
            throw new NotImplementedException();
        }

        public static void ScaleImage(MouseEventArgs mouseEvent)
        {
            throw new NotImplementedException();
        }

    }
}
