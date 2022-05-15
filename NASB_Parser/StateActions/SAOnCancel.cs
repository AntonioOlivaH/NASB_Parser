using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAOnCancel : StateAction
    {
        public string Id { get; set; }
        public StateAction Action { get; set; }

        public SAOnCancel()
        {
        }

        internal SAOnCancel(BulkSerializeReader reader) : base(reader)
        {
            Id = reader.ReadString();
            Action = Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Id);
            writer.Write(Action);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAOnCancel";

            ret.data.Add("Id", Id);
            ret.Items.Add(Action.toTreeViewNode("Action"));

            return ret;
        }
    }
}