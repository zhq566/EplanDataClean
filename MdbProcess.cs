using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EplanCleanner
{
    internal class MdbProcess
    {
        public List<string> macroFilesList;
        public List<string> picFilesList;
        public List<string> docFilesList;

        public MdbProcess()
        {
            // 在构造函数中初始化List
            macroFilesList = new List<string>();
            picFilesList = new List<string>();
            docFilesList = new List<string>();
        }

        public void ProcessPath(string md_macro, string md_img, string md_documents)
        {
            for (int i = 0; i < macroFilesList.Count; i++)
            {
                macroFilesList[i] = macroFilesList[i].Replace("$(MD_MACROS)", md_macro);
            }
            for (int i = 0; i < picFilesList.Count; i++)
            {
                picFilesList[i] = picFilesList[i].Replace("$(MD_IMG)", md_img);
            }
            for (int i = 0; i < docFilesList.Count; i++)
            {
                docFilesList[i] = docFilesList[i].Replace("$(MD_DOCUMENTS)", md_documents);
            }

            DateTime now = DateTime.Now;
            string currentDateTime = now.ToString("yyyy-MM-dd-HH-mm-ss");
            //日志
            using (StreamWriter writer = new StreamWriter("./log/DB_macroFilesList" + currentDateTime +".txt"))
            {
                foreach (string line in macroFilesList)
                {
                    writer.WriteLine(line); // 写入一行并自动添加换行符
                }
            }
            using (StreamWriter writer = new StreamWriter("./log/DB_picFilesList" + currentDateTime + ".txt"))
            {
                foreach (string line in picFilesList)
                {
                    writer.WriteLine(line);
                }
            }
            using (StreamWriter writer = new StreamWriter("./log/DB_docFilesList" + currentDateTime + ".txt"))
            {
                foreach (string line in docFilesList)
                {
                    writer.WriteLine(line);
                }
            }
        }

        public void GetInMdbFiles(String Dir)
        {
            //宏
            GetFilesFromTbl(Dir, "tblpart", "graphicmacro", macroFilesList);
            GetFilesFromTbl(Dir, "tblpart", "groupsymbolmacro", macroFilesList);
            //图片
            GetFilesFromTbl(Dir, "tblpart", "picturefile", picFilesList);
            //文档
            GetFilesFromTbl(Dir, "tblQuerytext", "qtext", docFilesList);
        }

        public void GetFilesFromTbl(String mdbDir, String tableName, String columnName, List<string> list)
        {
            string connectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={mdbDir};Persist Security Info=False;";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // 创建SQL查询
                    string query = $"SELECT {columnName} FROM {tableName}";

                    // 创建OleDbCommand
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // 读取列信息
                                object columnValue = reader[columnName];
                                if (columnValue != DBNull.Value)
                                {
                                    //Console.WriteLine(columnValue);
                                    list.Add(columnValue.ToString());
                                }
                             }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

    }
}
