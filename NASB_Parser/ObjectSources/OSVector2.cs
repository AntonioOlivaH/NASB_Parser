using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.ObjectSources
{
    public class OSVector2 : ObjectSource
    {
        public FloatSource X { get; set; }
        public FloatSource Y { get; set; }

        public OSVector2()
        {
        }

        internal OSVector2(BulkSerializeReader reader) : base(reader)
        {
            X = FloatSource.Read(reader);
            Y = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(X);
            writer.Write(Y);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "OSVector2";

            ret.Items.Add(X.toTreeViewNode("X"));
            ret.Items.Add(Y.toTreeViewNode("Y"));

            return ret;
        }
    }
}