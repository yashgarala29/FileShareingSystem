using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileShareingSystem.Class
{
    
    [DataContract]
    public class listOfAllFile
    {
        //private int id;
        //private DateTime UplodeDate;
        //private string FileName;

        //private int UserId;

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime UplodeDate { get; set; }
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string ComonId { get; set; }

    }
}
