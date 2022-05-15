using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SASnapAnimWeights : StateAction
    {
        public bool ForceSample { get; set; }

        public SASnapAnimWeights()
        {
        }

        internal SASnapAnimWeights(BulkSerializeReader reader) : base(reader)
        {
            ForceSample = reader.ReadBool();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(ForceSample);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SASnapAnimWeights";

            ret.data.Add("ForceSample", ForceSample.ToString());

            return ret;
        }
    }
}