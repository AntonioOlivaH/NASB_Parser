using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.FloatSources
{
    public class FSScratch : FloatSource
    {
        public int Scratch { get; set; }

        public FSScratch()
        {
        }

        internal FSScratch(BulkSerializeReader reader) : base(reader)
        {
            Scratch = reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Scratch);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "FSScratch";
            ret.data.Add("Scratch", Scratch.ToString());

            return ret;
        }
    }
}