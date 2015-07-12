using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neural_Networks
{
    /// <summary>
    /// Part of GUI (initialize and event handlers)
    /// </summary>
    public partial class NeuralNetworkGUI : Form, INeuralNetworkGUI
    {
        /// <summary>
        /// Occurs when left mouse button was pressed.
        /// </summary>
        public event EventHandler<MouseArgs> LeftMouseButtonWasPressedEvent = null;
        
        /// <summary>
        /// Occurs when left mouse button was released.
        /// </summary>
        public event EventHandler<MouseArgs> LeftMouseButtonWasReleasedEvent = null;
        
        /// <summary>
        /// Occurs when mouse was moved (with Left Button pressed).
        /// </summary>
        public event EventHandler<MouseArgs> MouseWasMovedEvent = null;

        /// <summary>
        /// Occurs when user wants to add number to teaching network or recognize number.
        /// </summary>
        public event EventHandler<AddNumberOrRecognizeArgs> AddNumberOrRecognizeEvent = null;
        
        /// <summary>
        /// Occurs when button Clear was pressed.
        /// </summary>
        public event EventHandler ClearPressedEvent = null;

        /// <summary>
        /// Occurs when button Teach was pressed (using datas from user).
        /// </summary>
        public event EventHandler<TeachingArgs> TeachByUserOrByMnistPressedEvent = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="NeuralNetworkGUI"/> class.
        /// </summary>
        public NeuralNetworkGUI()
        {
            InitializeComponent();
            pictureBoxDrawingArea.Image = new Bitmap(pictureBoxDrawingArea.Size.Width, pictureBoxDrawingArea.Size.Height);
            radioButtonTeaching.Checked = true;
            for (int i = 0; i < 10; i++)
            {
                listBoxForChosingNumbers.Items.Add(i);
            }
        }

        /// <summary>
        /// Refreshes the drawing area.
        /// </summary>
        public void RefreshDrawingArea()
        {
            pictureBoxDrawingArea.Refresh();
        }

        /// <summary>
        /// Gives the image from drawing area.
        /// </summary>
        /// <returns></returns>
        public Image GiveImageFromDrawingArea()
        {
            return pictureBoxDrawingArea.Image;
        }

        /// <summary>
        /// Selects the number (result of recognizing number by network).
        /// </summary>
        /// <param name="index">The index.</param>
        public void SelectNumber(int index)
        {
            listBoxForChosingNumbers.SelectedIndex = index;
        }

        /// <summary>
        /// Handles the MouseDown event of the pictureBoxDrawingArea control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void pictureBoxDrawingArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (LeftMouseButtonWasPressedEvent != null)
                {
                    MouseArgs mouseArgs = new MouseArgs(e.Location);
                    LeftMouseButtonWasPressedEvent(this, mouseArgs);
                }
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the pictureBoxDrawingArea control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void pictureBoxDrawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (MouseWasMovedEvent != null)
                {
                    MouseArgs mouseArgs = new MouseArgs(e.Location);
                    MouseWasMovedEvent(this, mouseArgs);
                }
            }
        }

        /// <summary>
        /// Handles the MouseUp event of the pictureBoxDrawingArea control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void pictureBoxDrawingArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (LeftMouseButtonWasReleasedEvent != null)
                {
                    MouseArgs mouseArgs = new MouseArgs(e.Location);
                    LeftMouseButtonWasReleasedEvent(this, mouseArgs);
                }
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the radioButtonTeaching control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radioButtonTeaching_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTeaching.Checked)
            {
                labelDrawingNumber.Text = "Narysuj cyfrę do nauki";
                labelTypeOfNumber.Text = "Wybierz liczbę, którą będziesz wprowadzał";
                buttonAddNumberOrRecognize.Text = "Dodaj wzorzec do nauki";
                listBoxForChosingNumbers.Enabled = true;
                buttonTeachWithUserData.Enabled = true;
                buttonTeachWithUserData.Visible = true;
                buttonTeachWithMNISTData.Enabled = true;
                buttonTeachWithMNISTData.Visible = true;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the radioButtonRecognition control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radioButtonRecognition_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRecognition.Checked)
            {
                labelDrawingNumber.Text = "Narysuj cyfrę, którą sieć postara się rozpoznać";
                labelTypeOfNumber.Text = "Tu zostanie zaznaczona rozpoznana liczba";
                buttonAddNumberOrRecognize.Text = "Rozpoznaj";
                listBoxForChosingNumbers.Enabled = false;
                buttonTeachWithUserData.Enabled = false;
                buttonTeachWithUserData.Visible = false;
                buttonTeachWithMNISTData.Enabled = false;
                buttonTeachWithMNISTData.Visible = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (ClearPressedEvent != null)
            {
                ClearPressedEvent(this, e);
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonAddNumberOrRecognize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonAddNumberOrRecognize_Click(object sender, EventArgs e)
        {
            if (AddNumberOrRecognizeEvent != null)
            {
                AddNumberOrRecognizeArgs args;
                if (radioButtonTeaching.Checked)
                {
                    int index = -1;
                    index = listBoxForChosingNumbers.SelectedIndex;
                    args = new AddNumberOrRecognizeArgs(true, index);
                }
                else
                {
                    args = new AddNumberOrRecognizeArgs(false, -1);
                }

                AddNumberOrRecognizeEvent(this, args);
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonTeachWithUserData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonTeachWithUserData_Click(object sender, EventArgs e)
        {
            if (TeachByUserOrByMnistPressedEvent != null)
            {
                TeachingArgs args = new TeachingArgs(true);
                TeachByUserOrByMnistPressedEvent(this, args);
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonTeachWithMNISTData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonTeachWithMNISTData_Click(object sender, EventArgs e)
        {
            if (TeachByUserOrByMnistPressedEvent != null)
            {
                TeachingArgs args = new TeachingArgs(false);
                TeachByUserOrByMnistPressedEvent(this, args);
            }
        }
    }
}
