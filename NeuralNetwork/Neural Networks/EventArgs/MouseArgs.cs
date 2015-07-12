using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Networks
{
    /// <summary>
    /// Arguments for event (when LMB was pressed, released or mouse was moved in draving area)
    /// </summary>
    public class MouseArgs : EventArgs
    {
        /// <summary>
        /// Gets the mouse position.
        /// </summary>
        /// <value>
        /// The mouse position.
        /// </value>
        public Point MousePosition { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseArgs"/> class.
        /// </summary>
        /// <param name="point">POsition of Mouse</param>
        public MouseArgs(Point point)
        {
            MousePosition = point;
        }
    }
}
