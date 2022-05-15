using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAHurtGrabbed : StateAction
    {
        public string AtkProp { get; set; }

        public SAHurtGrabbed()
        {
        }

        internal SAHurtGrabbed(BulkSerializeReader reader) : base(reader)
        {
            AtkProp = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(AtkProp);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAHurtGrabbed";

            ret.data.Add("AtkProp", AtkProp);

            return ret;
        }
    }
}