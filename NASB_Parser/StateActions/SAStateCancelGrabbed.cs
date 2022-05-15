using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAStateCancelGrabbed : StateAction
    {
        public string ToState { get; set; }
        public bool Proxy;

        public SAStateCancelGrabbed()
        {
        }

        internal SAStateCancelGrabbed(BulkSerializeReader reader) : base(reader)
        {
            if(Version > 0) {
                Proxy = reader.ReadBool();
            }
            ToState = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            writer.Write(TID);
            writer.Write(1);
            writer.Write(Proxy);
            writer.Write(ToState);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAStateCancelGrabbed";

            ret.data.Add("ToState", ToState);
            ret.data.Add("Proxy", Proxy.ToString());

            return ret;
        }
    }
}