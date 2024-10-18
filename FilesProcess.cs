using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EplanCleanner
{
    internal class FilesProcess
    {
        public string md_parts = "$(MD_PARTS)";
        public string md_macro = "$(MD_MACROS)";
        public string md_img = "$(MD_IMG)";
        public string md_documents = "$(MD_DOCUMENTS)";

        public List<string> macroFiles = new List<string>();
        public List<string> picFiles = new List<string>();
        public List<string> docFiles = new List<string>();

        public FilesProcess()
        {

        }

        public bool IsValidPath(string path)
        {
            // 检查路径是否为空或null
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }

            // 检查路径是否包含无效字符
            char[] invalidPathChars = Path.GetInvalidPathChars();
            if (path.IndexOfAny(invalidPathChars) != -1)
            {
                return false;
            }

            // 如果所有检查都通过，则路径有效
            return true;
        }

        public string[] GetFiles(String dir, String filesType)
        {
            if(!IsValidPath(dir))
            {
                return null;
            }
            try
            {
                // 获取目录下的所有文件，包括子目录中的文件
                return Directory.GetFiles(dir, filesType, SearchOption.AllDirectories);               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        public void GetMDBFiles()
        {
            //获取文件夹内宏文件
            string[] temp = GetFiles(md_macro, "*.ema");
            if (temp != null)
                macroFiles.AddRange(temp);

            //获取文件夹内图片文件
            temp = GetFiles(md_img, "*.png");
            if (temp != null)
                picFiles.AddRange(temp);

            temp = GetFiles(md_img, "*.bmp");
            if (temp != null)
                picFiles.AddRange(temp);

            temp = GetFiles(md_img, "*.jpg");
            if (temp != null)
                picFiles.AddRange(temp);

            //获取文件夹内文档文件
            temp = GetFiles(md_documents, "*.pdf");
            if (temp != null)
                docFiles.AddRange(temp);

            DateTime now = DateTime.Now;
            string currentDateTime = now.ToString("yyyy-MM-dd-HH-mm-ss");
            //文件夹里搜到的文件作日志记录
            using (StreamWriter writer = new StreamWriter("./log/File_macroFilesList" + currentDateTime + ".txt"))
            {
                foreach (string line in macroFiles)
                {
                    writer.WriteLine(line);
                }
            }
            using (StreamWriter writer = new StreamWriter("./log/File_picFilesList" + currentDateTime + ".txt"))
            {
                foreach (string line in picFiles)
                {
                    writer.WriteLine(line);
                }
            }
            using (StreamWriter writer = new StreamWriter("./log/File_docFilesList" + currentDateTime + ".txt"))
            {
                foreach (string line in docFiles)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
