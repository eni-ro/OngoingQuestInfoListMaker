using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OngoingQuestInfoListMaker
{
    class Writer
    {
        public string filename;

        public Writer(string readfile )
        {
            filename = readfile;
        }
        public void Write(Dictionary<int, Item> dic, bool escape)
        {
            StreamWriter sw = new StreamWriter(filename, false, Encoding.GetEncoding("Shift_JIS"));

            sw.WriteLine("QuestInfoList = {");
            foreach (Item item in dic.Values)
            {
                sw.WriteLine("\t[" + AddEscape(item.id.ToString(), escape) + "] = {");
                string itemname = AddEscape(item.title, escape);
                sw.WriteLine("\t\tTitle = \"" + itemname + "\",");
                sw.WriteLine("\t\tDescription = {");
                foreach (string description in item.description)
                {
                    sw.WriteLine("\t\t\t\"" + AddEscape(description, escape) + "\",");
                }
                sw.WriteLine("\t\t},");
                string summary = AddEscape(item.summary, escape);
                sw.WriteLine("\t\tSummary = \"" + summary + "\"");
                sw.WriteLine("\t},");
            }
            sw.WriteLine("}");
            sw.Close();
        }
        private string AddEscape(string buff, bool enable)
        {
            if (buff == null)
            {
                return "";
            }
            if (enable)
            {
                char[] ch = buff.ToCharArray();
                for (int i = ch.Length - 1; i >= 0; i--)
                {
                    Encoding encoding = Encoding.GetEncoding("Shift_JIS");
                    byte[] data = encoding.GetBytes(ch, i, 1);
                    if (data.Length == 2)   //2バイト文字で
                    {
                        if (data[1] == 0x5C)  //5C問題が発生する場合
                        {
                            if ((i >= ch.Length - 1) || (ch[i + 1] != '\\')) //後ろに￥がついていなければ挿入する
                            {
                                buff = buff.Insert(i + 1, "\\");
                            }
                        }
                    }
                }
            }
            buff = buff.Replace("\"", "\\034");
            return buff;
        }
    }
}
