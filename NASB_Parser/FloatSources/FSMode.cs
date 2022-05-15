using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.FloatSources
{
    public class FSMode : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSMode()
        {
        }

        internal FSMode(BulkSerializeReader reader) : base(reader)
        {
            Attribute = (Attributes)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Attribute);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "FSMode";
            ret.data.Add("Attribute", Enum.GetName(typeof(Attributes), Attribute));

            return ret;
        }

        public enum Attributes
        {
            InputAllowed
        }
    }
}