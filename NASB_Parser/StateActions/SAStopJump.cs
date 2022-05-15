using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAStopJump : StateAction
    {
        public bool StopAll { get; set; }
        public string JumpId { get; set; }

        public List<string> jumpids { get; set; }

        public SAStopJump()
        {
        }

        internal SAStopJump(BulkSerializeReader reader) : base(reader)
        {
            StopAll = reader.ReadBool();
            JumpId = reader.ReadString();
            if (this.Version > 0)
                jumpids = reader.ReadList(r => r.ReadString());
            else
                jumpids = new List<string>();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            writer.Write(61);
            writer.Write(1);
            writer.Write(StopAll);
            writer.Write(JumpId);
            writer.Write(jumpids);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAStopJump";

            ret.data.Add("StopAll", StopAll.ToString());
            ret.data.Add("JumpId", JumpId);
            ret.Items.Add(jumpids);

            return ret;
        }
    }
}