using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngoingQuestInfoListMaker
{
    class Item : IComparable<Item>
    {
        public override int GetHashCode()
        {
            return this.id.GetHashCode() ^ this.title.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            // asでは、objがnullでも例外は発生せずにnullが入ってくる
            var other = obj as Item;
            if (other == null) return false;

            // 何が同じときに、「同じ」と判断してほしいかを記述する
            return this.title.Replace("\\", "").CompareTo(other.title.Replace("\\", "")) == 0 && this.id == other.id;
        }
        int IComparable<Item>.CompareTo(Item obj)
        {
            return this.id.CompareTo(obj.id);
        }
        public Item(int addid,string addtitle)
        {
            id = addid;
            title = addtitle;
            description = new List<string>();
            summary = "";
        }

        public int id { get; set; }
        public string title { get; set; }
        public List<string> description { get; set; }
        public string summary { get; set; }
    }
}
