using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.POCO
{
    public class LogInOutEvent
    {
        #region ActionType (enum)
        public enum ActionType
        {
            LOGIN_SUCCESSFUL,
            LOGIN_FAILURE,
            LOGOUT
        }
        #endregion

        #region Constructors
        public LogInOutEvent()
        {
        }

        public LogInOutEvent(UserAccount account, String ipAddress, ActionType type)
        {
            this.UserAccount = account;
            this.IpAddress = ipAddress;
            this.GeneratedOn = DateTime.Now;
            this.Type = type;
        }
        #endregion

        #region Properties
        public virtual long Id { get; set; }

        public virtual UserAccount UserAccount { get; set; }

        public virtual string IpAddress { get; set; }

        public virtual DateTime GeneratedOn { get; set; }

        public virtual ActionType Type { get; set; }
        #endregion
    }
}