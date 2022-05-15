using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SALaunchGrabbedCustom : StateAction
    {
        public string AtkProp { get; set; }
        public FloatSource X { get; set; }
        public FloatSource Y { get; set; }

        public SALaunchGrabbedCustom()
        {
        }

        internal SALaunchGrabbedCustom(BulkSerializeReader reader) : base(reader)
        {
            AtkProp = reader.ReadString();
            X = FloatSource.Read(reader);
            Y = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(AtkProp);
            writer.Write(X);
            writer.Write(Y);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SALaunchGrabbedCustom";

            ret.data.Add("AtkProp", AtkProp);
            ret.Items.Add(X.toTreeViewNode("X"));
            ret.Items.Add(Y.toTreeViewNode("Y"));

            return ret;
        }
    }
}