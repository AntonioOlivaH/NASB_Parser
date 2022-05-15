using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.Jumps
{
    public class HeightJump : Jump
    {
        public FloatSource Height { get; set; }

        public HeightJump()
        {
        }

        internal HeightJump(BulkSerializeReader reader) : base(reader)
        {
            Height = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Height);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "HeightJump";

            ret.Items.Add(Height.toTreeViewNode("Height"));

            return ret;
        }
    }
}