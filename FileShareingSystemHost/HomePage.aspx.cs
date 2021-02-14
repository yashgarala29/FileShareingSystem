using FileShareingSystemHost.FileUploadeService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileShareingSystemHost
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {



            FileUploadeService.FileUploadeClient fileUploadeClient =
                new FileUploadeService.FileUploadeClient("BasicHttpBinding_IFileUploade");
            if (FileUpload1.HasFile)
            {

                string commonid = Guid.NewGuid().ToString("N");
                string folder = "~/AllUploadedFile/"+commonid;
                var path = System.Web.HttpContext.Current.Server.MapPath(folder);
                if (Directory.Exists(path))
                {
                    return;
                }
                else
                {
                    Directory.CreateDirectory(path);
                }
                foreach (var singleFile in FileUpload1.PostedFiles)
                {
                    //string file_name = commonid + "_" + singleFile.FileName;
                    string file_name =  singleFile.FileName;
                    singleFile.SaveAs(Server.MapPath(folder+"/") + file_name);
                requestFile requestFile = new requestFile
                {
                    FileName = file_name,
                    UserId = 10,
                    ComonId=commonid,
                    
                };
                fileUploadeClient.SaveFile(requestFile);
                }
                HyperLink1.Text = "Your File Url";
                HyperLink1.NavigateUrl = "https://localhost:44337/File_List.aspx?FileID=" + commonid;
            }
            //FileUploadeService.requestFile requestFile =
            //         fileUploadeClient.

        }
    }
}