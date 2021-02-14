using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileShareingSystem.Class
{
    [DataContract]
    public class  userDetail
    {
        //private int id;
        //private string username;
        //private string email;

        //private string password;

        [DataMember]
        public int id { get ; set ; }
        [DataMember]
        public string Username { get; set ; }
        [DataMember]
        public string email { get ; set ; }
        [DataMember]
        public string password { get; set ; }

    }
}
