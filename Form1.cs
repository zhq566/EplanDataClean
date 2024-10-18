using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EplanCleanner
{
    public partial class Form1 : Form
    {
        public int ExcEplanClean()
        {
            FilesProcess fileObj = new FilesProcess();

            //处理宏路径
            string logDirectoryPath = @".\log";

            // 检查目录是否存在
            if (!Directory.Exists(logDirectoryPath))
            {
                // 如果目录不存在，则创建它
                Directory.CreateDirectory(logDirectoryPath);
            }


            fileObj.md_parts = textParts.Text;
            fileObj.md_macro = textMacro.Text;
            fileObj.md_img = textIMG.Text;
            fileObj.md_documents = textDoc.Text;

            Console.WriteLine("[INFO]宏处理完成!");
            //获取*.mdb文件
            List<string> mdbFilesList = new List<string>();
            string[] temp = fileObj.GetFiles(fileObj.md_parts, "*.mdb");
            if (temp != null)
            {
                mdbFilesList.AddRange(temp);
            }

            using (StreamWriter writer = new StreamWriter("MDB_List.txt"))
            {
                foreach (string line in mdbFilesList)
                {
                    writer.WriteLine(line);
                }
            }

            //获取mdb文件内关联文件路径
            MdbProcess mdb = new MdbProcess();
            foreach (string item in mdbFilesList)
            {
                //Console.WriteLine(item);
                mdb.GetInMdbFiles(item);
            }

            if (mdbFilesList.Count == 0)
            {
                MessageBox.Show("无*.mdb文件！");
                return -1;
            }
            else
            {
                fileObj.GetMDBFiles();
                mdb.ProcessPath(fileObj.md_macro, fileObj.md_img, fileObj.md_documents);
                //MessageBox.Show("mdb数据库内文件信息获取完成！");
            }

            //文件不存在mdb内，移入回收站
            DateTime now = DateTime.Now;
            string currentDateTime = now.ToString("yyyy-MM-dd-HH-mm-ss");

            List<string> recycleBin_macro = new List<string>();
            foreach (string item in fileObj.macroFiles)
            {
                if (!mdb.macroFilesList.Exists(i => i == item))
                {
                    FileSystem.DeleteFile(item, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    recycleBin_macro.Add(item);
                }
            }
            using (StreamWriter writer = new StreamWriter("./log/recycleBin_macro" + currentDateTime + ".txt"))
            {
                foreach (string line in recycleBin_macro)
                {
                    writer.WriteLine(line);
                }
            }

            List<string> recycleBin_img = new List<string>();
            foreach (string item in fileObj.picFiles)
            {
                if (!mdb.picFilesList.Exists(i => i == item))
                {
                    FileSystem.DeleteFile(item, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    recycleBin_img.Add(item);
                }
            }
            using (StreamWriter writer = new StreamWriter("./log/recycleBin_img" + currentDateTime + ".txt"))
            {
                foreach (string line in recycleBin_img)
                {
                    writer.WriteLine(line);
                }
            }

            List<string> recycleBin_doc = new List<string>();
            foreach (string item in fileObj.docFiles)
            {
                if (!mdb.picFilesList.Exists(i => i == item))
                {
                    FileSystem.DeleteFile(item, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    recycleBin_doc.Add(item);
                }
            }
            using (StreamWriter writer = new StreamWriter("./log/recycleBin_doc" + currentDateTime + ".txt"))
            {
                foreach (string line in recycleBin_doc)
                {
                    writer.WriteLine(line); // 写入一行并自动添加换行符
                }
            }

            //FileSystem.DeleteFile(filePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            return 0;
        }


        private FolderBrowserDialog folderBrowserDialog;
        public Form1()
        {
            InitializeComponent();
            // 初始化文件夹浏览对话框
            folderBrowserDialog = new FolderBrowserDialog();
            textParts.Text = "C:\\Users\\Public\\EPLAN\\Data\\部件\\Zero";
            textMacro.Text = "C:\\Users\\Public\\EPLAN\\Data\\宏\\Zero";
            textIMG.Text = "C:\\Users\\Public\\EPLAN\\Data\\图片\\Zero";
            textDoc.Text = "C:\\Users\\Public\\EPLAN\\Data\\文档\\Zero";

            // 设置窗体的边框样式为固定单行大小，这将禁止用户调整大小
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // 禁止显示最大化按钮
            this.MaximizeBox = false;

            this.Text = "This my frist Form test Code!";
        }

        private void GetPartsPath(object sender, EventArgs e)
        {
            // 显示文件夹浏览对话框
            DialogResult result = folderBrowserDialog.ShowDialog();
            // 检查用户是否选择了一个文件夹
            if (result == DialogResult.OK && !string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
            {
                textParts.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void GetMacroPath(object sender, EventArgs e)
        {
            // 显示文件夹浏览对话框
            DialogResult result = folderBrowserDialog.ShowDialog();
            // 检查用户是否选择了一个文件夹
            if (result == DialogResult.OK && !string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
            {
                textMacro.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void GetImgPath(object sender, EventArgs e)
        {
            // 显示文件夹浏览对话框
            DialogResult result = folderBrowserDialog.ShowDialog();
            // 检查用户是否选择了一个文件夹
            if (result == DialogResult.OK && !string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
            {
                textIMG.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void GetDocPath(object sender, EventArgs e)
        {
            // 显示文件夹浏览对话框
            DialogResult result = folderBrowserDialog.ShowDialog();
            // 检查用户是否选择了一个文件夹
            if (result == DialogResult.OK && !string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
            {
                textDoc.Text = folderBrowserDialog.SelectedPath;
            }
        }
        private void ClickBtnClean(object sender, EventArgs e)
        {
            if (textParts.Text.Length > 0 &&
                textMacro.Text.Length > 0 &&
                textIMG.Text.Length > 0 &&
                textDoc.Text.Length > 0)
            {
                ExcEplanClean();
                MessageBox.Show("清理完成，请去回收站查看！");
            }
            else
                MessageBox.Show("检查路径是否已经选择！");
        }
    }
}
