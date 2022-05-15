using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SACustomCall : StateAction
    {
        public string CallId { get; set; }

        public SACustomCall()
        {
        }

        internal SACustomCall(BulkSerializeReader reader) : base(reader)
        {
            CallId = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(CallId);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SACustomCall";

            ret.data.Add("CallId", CallId);

            return ret;
        }
    }
}