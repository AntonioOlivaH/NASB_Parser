using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SADeactivateAction : StateAction
    {
        public int Index { get; set; }
        public string Id { get; set; }

        public SADeactivateAction()
        {
        }

        internal SADeactivateAction(BulkSerializeReader reader) : base(reader)
        {
            Index = reader.ReadInt();
            Id = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Index);
            writer.Write(Id);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SADeactivateAction";

            ret.data.Add("Index", Index.ToString());
            ret.data.Add("Id", Id);

            return ret;
        }
    }
}