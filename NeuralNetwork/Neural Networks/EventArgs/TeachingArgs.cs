using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Networks
{
    /// <summary>
    /// Arguments for event (when user wants to teaach network using his datas or datas from MNIST)
    /// </summary>
    public class TeachingArgs : EventArgs
    {
        /// <summary>
        /// Gets a value indicating whether is user data using to teaching network
        /// </summary>
        /// <value>
        ///   <c>true</c> if user wants to teach network his data (user data); otherwise (when user wants to use MNIST data), <c>false</c>.
        /// </value>
        public bool IsUserData { get; private set; }

        /// <summary>
        /// Prevents a default instance of the <see cref="TeachingArgs"/> class from being created.
        /// </summary>
        /// <param name="isUserData">if set to <c>true</c> network should learn using datas from user.</param>
        public TeachingArgs(bool isUserData)
        {
            IsUserData = isUserData;
        }
    }
}
