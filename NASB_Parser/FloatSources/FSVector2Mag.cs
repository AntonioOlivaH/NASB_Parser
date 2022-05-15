using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.FloatSources
{
    public class FSVector2Mag : FloatSource
    {
        public FloatSource X { get; set; }
        public FloatSource Y { get; set; }

        public FSVector2Mag()
        {
        }

        internal FSVector2Mag(BulkSerializeReader reader) : base(reader)
        {
            X = Read(reader);
            Y = Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(X);
            writer.Write(Y);
        }

        public override NASBTreeViewNode toTreeViewNode() {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "FSVector2Mag";

            ret.Items.Add(X.toTreeViewNode("X"));
            ret.Items.Add(Y.toTreeViewNode("Y"));

            return ret;
        }
    }
}