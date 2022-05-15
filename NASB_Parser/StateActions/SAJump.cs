using NASB_Parser.Jumps;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAJump : StateAction
    {
        public string JumpId { get; set; }
        public Jump Jump { get; set; }

        public SAJump()
        {
        }

        internal SAJump(BulkSerializeReader reader) : base(reader)
        {
            JumpId = reader.ReadString();
            Jump = Jump.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(JumpId);
            writer.Write(Jump);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAJump";

            ret.data.Add("JumpId", JumpId);
            ret.Items.Add(Jump.toTreeViewNode("Jump"));

            return ret;
        }
    }
}