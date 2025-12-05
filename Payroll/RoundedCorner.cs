using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class RoundedCorner
    {
        private void RoundPanelCorners(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int w = panel.Width;
            int h = panel.Height;

            path.StartFigure();

            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddLine(radius, 0, w - radius, 0);

            path.AddArc(w - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddLine(w, radius, w, h - radius);

            path.AddArc(w - radius * 2, h - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddLine(w - radius, h, radius, h);

            path.AddArc(0, h - radius * 2, radius * 2, radius * 2, 90, 90);
            path.AddLine(0, h - radius, 0, radius);

            path.CloseFigure();

            panel.Region = new Region(path);
        }
    }
}
