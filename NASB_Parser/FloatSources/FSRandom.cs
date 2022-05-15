using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.FloatSources
{
    public class FSRandom : FloatSource
    {
        public bool Ratio { get; set; }
        public FloatSource A { get; set; }
        public FloatSource B { get; set; }

        public FSRandom()
        {
        }

        internal FSRandom(BulkSerializeReader reader) : base(reader)
        {
            Ratio = reader.ReadBool();
            A = Read(reader);
            B = Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Ratio);
            writer.Write(A);
            writer.Write(B);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "FSRandom";
            ret.data.Add("Ratio", Ratio.ToString());

            ret.Items.Add(A.toTreeViewNode("A"));
            ret.Items.Add(B.toTreeViewNode("B"));

            return ret;
        }
    }
}