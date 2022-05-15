using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SASetCommandGrab : StateAction
    {
        public string State { get; set; }

        public SASetCommandGrab()
        {
        }

        internal SASetCommandGrab(BulkSerializeReader reader) : base(reader)
        {
            State = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(State);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SASetFloatTarget";

            ret.data.Add("State", State);

            return ret;
        }
    }
}