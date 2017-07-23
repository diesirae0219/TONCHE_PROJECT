using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TonChe_Operation_Cneter.Utility;

namespace TonChe_Operation_Cneter
{
    public partial class frmDesignFormList : Form
    {
        private string ART_NO = "";
        private string ART_ONLY_NO = "";
        private string FileFolderUrl = "";
        public frmDesignFormList(string _ART_NO)
        {
            InitializeComponent();
            ART_NO = _ART_NO;
            this.lbART_NO.Text = ART_NO;  
            if (GlobalVar.sMode == GlobalVar.SysMode.Web)
            {
                getFileString();
            }
            else
            {
                LoadLocalFile();
            }
        }

        private void LoadLocalFile()
        {
            //DirectoryInfo d = new DirectoryInfo(DesginFormPath);

            //FileInfo[] Files = d.GetFiles("*" + tb_ART_NAME.Text + ".xls"); //Getting Text files
            //if (Files.Length > 0)
            //{
            //    string path = DesginFormPath + Files[0].Name;
            //    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excel.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            //    excel.Visible = true;
            //    //Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //    //Microsoft.Office.Interop.Excel.Workbook xlWorkBook = (Microsoft.Office.Interop.Excel.Workbook)excel.Workbooks.Open(path);
            //    //Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


            //}
            //else
            //{
            //    MessageBox.Show("沒有相關設計表資料!");
            //}
        }

        private void getFileString()
        {
            //  \\114.33.130.81\統麒共用\設計表\織物分析圖\ART300\織物設計表ART330.xls
            //1~100
            string FolderName = "";
            if (ART_NO.Contains("ART"))
            {
                //System.Text.RegularExpressions.Regex
                ART_ONLY_NO = Regex.Match(ART_NO, @"\d+").Value;
                int num = Int32.Parse(ART_ONLY_NO);
                if (num < 100)
                {
                    FolderName = "001-ART099";
                }
                else
                {
                    int FolderNo = num / 100;
                    FolderName = FolderNo + "00";
                }
            }
            else
            { 
                
            }

            if (!string.IsNullOrEmpty(FolderName))
            {
                FileFolderUrl = @"\\114.33.130.81\統麒共用\設計表\織物分析圖\ART" + FolderName;
                string[] FileList = Directory.GetFiles(FileFolderUrl);
                for (int i = 0; i < FileList.Length; i++)
                {
                    if (FileList[i].Contains(ART_ONLY_NO))
                    {
                        string FileName = "";
                        string[] urlParse = FileList[i].Split('\\');
                        FileName = urlParse[urlParse.Length-1];
                        listFile.Items.Add(FileName);
                    }
                }
            }
        }
        private void listFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listFile.IndexFromPoint(e.Location);
            ListBox lb = (ListBox)sender;
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                string FileName = (string)lb.Items[index];
                string FileUrl = FileFolderUrl + "\\" + FileName;
                FileInfo fileInfo = new FileInfo(FileUrl);

                // Delete the file if it exists.
                if (fileInfo.Exists)
                {
                    try
                    {
                        //fileInfo.Open(FileMode.Open);
                        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                        //excel.Workbooks.Open(path);
                        Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excel.Workbooks.Open(FileUrl);
                        excel.Visible = true;
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("檔案開啟錯誤!");
                    }
                   
                    //MessageBox.Show(index.ToString());
                }
            }
        }

            //FileInfo[] Files = d.GetFiles("*"); //Getting Text files
            //FileInfo fileInfo = new FileInfo(url);
            //FileWebRequest request = (FileWebRequest)WebRequest.Create(url);
            //request.Credentials = CredentialCache.DefaultNetworkCredentials;
            //request.Credentials.GetCredential(request.RequestUri, "Basic").UserName = "diesirae";
            //request.Credentials.GetCredential(request.RequestUri, "Basic").Password = "rR09197845233";
            //using (FileWebResponse response = (FileWebResponse)request.GetResponse())
            //{
            //    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            //    {
            //        string html = reader.ReadToEnd();
            //        Regex regex = new Regex(GetDirectoryListingRegexForUrl(url));
            //        MatchCollection matches = regex.Matches(html);
            //        if (matches.Count > 0)
            //        {
            //            foreach (Match match in matches)
            //            {
            //                if (match.Success)
            //                {
            //                    listBox1.Items.Add(match.Groups["name"]);
            //                }
            //            }
            //        }
            //    }
            //}

        

        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
