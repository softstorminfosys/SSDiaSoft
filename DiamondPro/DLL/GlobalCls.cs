using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondPro.DLL
{
    public class GlobalCls
    {
        private static int _user_id;
        public static int UserID
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

        private static string _user_pass;
        public static string UserPass
        {
            get { return _user_pass; }
            set { _user_pass = value; }
        }

        private static int _user_typeid;
        public static int UserTypeID
        {
            get { return _user_typeid; }
            set { _user_typeid = value; }
        }

        private static string _user_type;
        public static string UserType
        {
            get { return _user_type; }
            set { _user_type = value; }
        }

        private static String _user_name;
        public static String UserName
        {
            get { return _user_name; }
            set { _user_name = value; }
        }
    }
}
