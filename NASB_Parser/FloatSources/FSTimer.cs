using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.FloatSources
{
    public class FSTimer : FloatSource
    {
        public string Id { get; set; }

        public FSTimer()
        {
        }

        internal FSTimer(BulkSerializeReader reader) : base(reader)
        {
            Id = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Id);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "FSTimer";
            ret.data.Add("Id", Id.ToString());

            return ret;
        }
    }
}