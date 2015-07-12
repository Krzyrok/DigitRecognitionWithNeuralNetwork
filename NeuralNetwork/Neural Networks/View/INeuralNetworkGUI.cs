using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neural_Networks
{
    /// <summary>
    /// Interface for GUI
    /// </summary>
    public interface INeuralNetworkGUI
    {
        /// <summary>
        /// Refreshes the drawing area.
        /// </summary>
        void RefreshDrawingArea();

        /// <summary>
        /// Gives the image from drawing area.
        /// </summary>
        /// <returns></returns>
        Image GiveImageFromDrawingArea();

        /// <summary>
        /// Selects the number (result of recognizing number by network).
        /// </summary>
        /// <param name="index">The index.</param>
        void SelectNumber(int index);


        /// <summary>
        /// Occurs when left mouse button was pressed.
        /// </summary>
        event EventHandler<MouseArgs> LeftMouseButtonWasPressedEvent;

        /// <summary>
        /// Occurs when left mouse button was released.
        /// </summary>
        event EventHandler<MouseArgs> LeftMouseButtonWasReleasedEvent;

        /// <summary>
        /// Occurs when mouse was moved (with Left Button pressed).
        /// </summary>
        event EventHandler<MouseArgs> MouseWasMovedEvent;

        /// <summary>
        /// Occurs when user wants to add number to teaching network or recognize number.
        /// </summary>
        event EventHandler<AddNumberOrRecognizeArgs> AddNumberOrRecognizeEvent;

        /// <summary>
        /// Occurs when button Clear was pressed.
        /// </summary>
        event EventHandler ClearPressedEvent;

        /// <summary>
        /// Occurs when button Teach was pressed (using datas from user or from MNIST).
        /// </summary>
        event EventHandler<TeachingArgs> TeachByUserOrByMnistPressedEvent;
    }
}
