using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Networks
{
    /// <summary>
    /// Arguments for event (when user wants to add number to teaching network or recognize a number)
    /// </summary>
    public class AddNumberOrRecognizeArgs : EventArgs
    {
        /// <summary>
        /// Gets a value indicating whether is needed adding number to teaching of network.
        /// </summary>
        /// <value>
        ///   <c>true</c> if was selected teaching option of network (user wants to add number to teaching network); otherwise, <c>false</c>.
        /// </value>
        public bool IsNeededAddingNumber { get; private set; }

        /// <summary>
        /// Gets the what number was selected for teaching.
        /// </summary>
        /// <value>
        /// Number - number for teaching with teacher. If was selected Recognize option, number should be equal -1
        /// </value>
        public int WhatNumber { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddNumberOrRecognizeArgs"/> class.
        /// </summary>
        /// <param name="isNeededAddingNumber">if set to <c>true</c>, user wants to add number to teaching network.</param>
        /// <param name="number">The number.</param>
        public AddNumberOrRecognizeArgs(bool isNeededAddingNumber, int number)
        {
            IsNeededAddingNumber = isNeededAddingNumber;
            WhatNumber = number;
        }
    }
}
