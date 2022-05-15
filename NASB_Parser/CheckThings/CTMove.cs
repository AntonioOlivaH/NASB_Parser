using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.CheckThings
{
    public class CTMove : CheckThing
    {
        public string MovesetId { get; set; }
        public bool Previous { get; set; }
        public bool not { get; set; }
        public List<string> Extras { get; private set; } = new List<string>();

        public CTMove()
        {
        }

        internal CTMove(BulkSerializeReader reader) : base(reader)
        {
            MovesetId = reader.ReadString();
            Previous = reader.ReadBool();
            if (this.Version > 0) {
                not = reader.ReadBool();
            }
            Extras = reader.ReadList(r => r.ReadString());
        }

        public override void Write(BulkSerializeWriter writer)
        {
            writer.Write(10);
            writer.Write(1);
            writer.Write(MovesetId);
            writer.Write(Previous);
            writer.Write(not);
            writer.Write(Extras);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "CTMove";

            ret.data.Add("MovesetId", MovesetId);
            ret.data.Add("Previous", Previous.ToString());
            ret.data.Add("Extras", String.Join("\n", Extras));

            return ret;
        }
    }
}