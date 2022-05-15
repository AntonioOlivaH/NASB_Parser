using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SADeactivateInputAction : StateAction
    {
        public string Id { get; set; }

        public SADeactivateInputAction()
        {
        }

        internal SADeactivateInputAction(BulkSerializeReader reader) : base(reader)
        {
            Id = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Id);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SADeactivateInputAction";

            ret.data.Add("Id", Id);

            return ret;
        }
    }
}