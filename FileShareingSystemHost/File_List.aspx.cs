using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileShareingSystemHost
{
    public partial class File_List : System.Web.UI.Page
    {
        public string fileid;
        protected void Page_Load(object sender, EventArgs e)
        {
             fileid=Request.QueryString["FileID"];
            Label1.Text = fileid;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("File Name", typeof(string));
            dataTable.Columns.Add("Upload Date", typeof(string));
            dataTable.Columns.Add("User ID", typeof(string));
        //DataRow dataRow;
        //https://localhost:44337/File_List.aspx?FileID=15207f4e3a9c4e1481d096b610cd292b
            FileUploadeService.FileUploadeClient fileUploadeClient =
                new FileUploadeService.FileUploadeClient("BasicHttpBinding_IFileUploade");
            try
            {
               var arr =fileUploadeClient.GetFile(fileid);
                DataTable dt = new DataTable();
                dt.Columns.Add("File Name");
                dt.Columns.Add("Date");
                dt.Columns.Add("user id");
                foreach (var temp in arr)
                {


                    dt.Rows.Add(temp.FileName, temp.UplodeDate.ToShortDateString(), temp.UserId.ToString());
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
                
            }
            catch (Exception )
            {

            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(fileid==null  )
            {
                return;
            }
            if(e.CommandName== "Download")
            {
                Response.Clear();
                Response.ContentType = "application/octect-stream";
                Label1.Text = e.CommandArgument.ToString();
                Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument);
                Response.TransmitFile(Server.MapPath("~/AllUploadedFile/"+ fileid+"/") +e.CommandArgument);
                Response.End();
            }
        }
    }
}