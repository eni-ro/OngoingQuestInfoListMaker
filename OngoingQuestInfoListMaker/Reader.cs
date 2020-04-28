using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OngoingQuestInfoListMaker
{
    abstract class Reader
    {
        public string filename;

        public Reader(string readfile)
        {
            filename = readfile;
        }
        public abstract void AddInfo(Dictionary<int, Item> dic);
    }
    class questid2displayReader : Reader
    {
        public questid2displayReader(string readfile) : base(readfile)
        {

        }
        public override void AddInfo(Dictionary<int, Item> dic)
        {
            StreamReader sr = new StreamReader(filename, Encoding.GetEncoding("Shift_JIS"));
            int id=-1;

            while (sr.Peek() != -1)
            {
                string buff = sr.ReadLine();

                if (buff.Contains("//"))
                {
                    buff = buff.Substring(0, buff.Length - buff.IndexOf("//"));
                }
                string[] word = buff.Split('#');
                if (word.Length == 5)
                {
                    if (Int32.TryParse(word[0].Trim(), out id))
                    {
                        if (dic.ContainsKey(id)) {
                            dic.Remove(id);
                        }
                        dic.Add(id, new Item(id, word[1].Trim()));
                    }
                }
                else if(word.Length == 2 && dic.ContainsKey(id))
                {
                    dic[id].description.Add(word[0].Trim().Replace("　", ""));
                }
            }
            sr.Close();
        }
    }
}
