using FileShareingSystem.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FileShareingSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFileUploade" in both code and config file together.
    [ServiceContract]
    public interface IFileUploade
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        void SaveFile(requestFile r_file);
        [OperationContract]
        List<listOfAllFile> GetFile(string fileid);

        [OperationContract]
        void Register(userDetail r_user);

        [OperationContract]
        int Login(string username ,string password);

    }
}
