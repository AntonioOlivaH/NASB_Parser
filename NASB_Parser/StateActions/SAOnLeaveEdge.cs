using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAOnLeaveEdge : StateAction
    {
        public StateAction Action { get; set; }

        public SAOnLeaveEdge()
        {
        }

        internal SAOnLeaveEdge(BulkSerializeReader reader) : base(reader)
        {
            Action = Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Action);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAOnLeaveEdge";

            ret.Items.Add(Action.toTreeViewNode("Action"));

            return ret;
        }
    }
}