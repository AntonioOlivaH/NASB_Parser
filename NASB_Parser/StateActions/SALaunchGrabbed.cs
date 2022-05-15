using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SALaunchGrabbed : StateAction
    {
        public string AtkProp { get; set; }

        public SALaunchGrabbed()
        {
        }

        internal SALaunchGrabbed(BulkSerializeReader reader) : base(reader)
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
            ret.Header = "SALaunchGrabbed";

            ret.data.Add("AtkProp", AtkProp);

            return ret;
        }
    }
}