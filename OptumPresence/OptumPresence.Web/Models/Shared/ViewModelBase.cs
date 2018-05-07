using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using OptumPresence.Domain.Entities;

namespace OptumPresence.Models.Shared
{
    /// <summary>
    /// Base Class for View Models
    /// </summary>
    public class ViewModelBase
    {
        private UserEntity _currentUser;

        /// <summary>
        /// Current Date for timestamping and other uses.
        /// </summary>
        public DateTime CurrentDate
        {
            get { return DateTime.Now; }
        }

        /// <summary>
        /// Currently logged in user.
        /// </summary>
        public UserEntity CurrentUser
        {
            set { this._currentUser = value; }
            get { return this._currentUser; }
        }
    }
}