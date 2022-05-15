using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.FloatSources
{
    public class FSColors : FloatSource
    {
        public string ColorId { get; set; }
        public bool Permanent { get; set; }

        public FSColors()
        {
        }

        internal FSColors(BulkSerializeReader reader) : base(reader)
        {
            ColorId = reader.ReadString();
            Permanent = reader.ReadBool();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(ColorId);
            writer.Write(Permanent);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "FSColors";

            ret.data.Add("ColorId", ColorId);
            ret.data.Add("Permanent", Permanent.ToString());
            return ret;
        }
    }
}