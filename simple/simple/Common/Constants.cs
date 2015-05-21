using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple.Common
{
    public static class Constants
    {
        private static bool _isLoggedin = false;

        public static bool LoggedIn
        {
            get { return _isLoggedin; }
            set { _isLoggedin = value; }
        }

        private static object _accessToken = false;

        public static object AccessToken
        {
            get { return _accessToken; }
            set { _accessToken = value; }
        }

    }
}
