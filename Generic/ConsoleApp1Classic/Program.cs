using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ConsoleApp1Classic
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new TestSerialObject();
            test.Start();
            Console.ReadKey();
        }
    }

    public class TestSerialObject
    {
        public void Start()
        {
            var ds = InitTestDataSet();
            IFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, ds);
            var buffer_all = stream.ToArray();
            stream.Close();
            Console.WriteLine(buffer_all.Length);
            byte[] bytes_c = Compression(buffer_all, CompressionMode.Compress);
            Console.WriteLine(bytes_c.Length);
            stream = new MemoryStream(bytes_c);
            stream.Position = 0;
            var remain_length = stream.Length;
            Console.WriteLine(remain_length);
            //压缩比
            var percent = (double)remain_length / (double)buffer_all.Length;
            Console.WriteLine(percent * 100);
        }

        private DataSet InitTestDataSet()
        {
            DataSet ds = new DataSet("test");
            DataTable table = new DataTable("test");
            DataColumn column = new DataColumn("test");
            column.DataType = Type.GetType("System.String");
            table.Columns.Add(column);
            DataRow row;
            for (int i = 0; i < 100000; i++)
            {
                row = table.NewRow();
                row["test"] = "测试数据 !";
                table.Rows.Add(row);
            }
            ds.Tables.Add(table);
            return ds;
        }

        private byte[] Compression(byte[] data, CompressionMode mode)
        {
            DeflateStream zip = null;
            try
            {
                if (mode == CompressionMode.Compress)
                {
                    MemoryStream ms = new MemoryStream();
                    zip = new DeflateStream(ms, mode, true);
                    zip.Write(data, 0, data.Length);
                    zip.Close();
                    return ms.ToArray();
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(data, 0, data.Length);
                    ms.Flush();
                    ms.Position = 0;
                    zip = new DeflateStream(ms, mode, true);
                    MemoryStream os = new MemoryStream();
                    int SIZE = 1024;
                    byte[] buf = new byte[SIZE];
                    int l = 0;
                    do
                    {
                        l = zip.Read(buf, 0, SIZE);
                        if (l == 0) l = zip.Read(buf, 0, SIZE);
                        os.Write(buf, 0, l);
                    } while (l != 0);
                    zip.Close();
                    return os.ToArray();
                }
            }
            catch
            {
                if (zip != null) zip.Close();
                return null;
            }
            finally
            {
                if (zip != null) zip.Close();
            }
        }
    }
}
