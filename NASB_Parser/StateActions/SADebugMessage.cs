using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SADebugMessage : StateAction
    {
        public string Message { get; set; }

        public SADebugMessage()
        {
        }

        public SADebugMessage(BulkSerializeReader reader) : base(reader)
        {
            Message = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Message);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SADebugMessage";

            ret.data.Add("Message", Message);

            ret.baseobject = this;

            return ret;
        }
    }
}