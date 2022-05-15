using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.ObjectSources
{
    public class OSFloat : ObjectSource
    {
        public FloatSource Source { get; set; }

        public OSFloat()
        {
        }

        internal OSFloat(BulkSerializeReader reader) : base(reader)
        {
            Source = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Source);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "OSFloat";

            ret.Items.Add(Source.toTreeViewNode("Source"));

            return ret;
        }
    }
}