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

        public static int RotateImage(int originalRotatetion, Point currentMousePoint, Point elementCenter)
        {

            double angleDiffrence = Math.Atan2(currentMousePoint.Y - elementCenter.Y, currentMousePoint.X - elementCenter.X);

            int newRotation = (int)(originalRotatetion + angleDiffrence * (180 / Math.PI));

            return newRotation;
        }

        public static int RotateImage(int originalRotatetion, Point currentMousePoint, Point elementCenter, float rotatingSpeed)
        {

            double angleDiffrence = Math.Atan2(currentMousePoint.Y - elementCenter.Y, currentMousePoint.X - elementCenter.X);

            int newRotation = (int)(originalRotatetion + angleDiffrence * (180 / Math.PI) * rotatingSpeed);

            return newRotation;
        }

        public static void ScaleImage(MouseEventArgs mouseEvent)
        {
            throw new NotImplementedException();
        }

    }
}
