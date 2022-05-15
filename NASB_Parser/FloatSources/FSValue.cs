using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.FloatSources
{
    public class FSValue : FloatSource
    {
        public float Value { get; set; }

        public FSValue()
        {
        }

        public FSValue(float x)
        {
            Value = x;
        }

        internal FSValue(BulkSerializeReader reader) : base(reader)
        {
            Value = reader.ReadFloat();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Value);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "FSValue";
            ret.data.Add("Value", Value.ToString());

            return ret;
        }
    }
}