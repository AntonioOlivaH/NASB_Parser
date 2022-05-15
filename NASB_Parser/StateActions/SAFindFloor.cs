using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.FloatSources;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAFindFloor : StateAction
    {
        public float SeekRange { get; set; }
        public FloatSource range;

        public SAFindFloor()
        {
        }

        internal SAFindFloor(BulkSerializeReader reader) : base(reader)
        {
            SeekRange = 0;
            if (this.Version < 1)
                SeekRange = reader.ReadFloat();
            else
                range = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            writer.Write(41);
            writer.Write(1);
            if (this.Version == 0)
                writer.Write(new FSValue(SeekRange));
            else
                writer.Write(range);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAFindFloor";

            ret.data.Add("SeekRange", SeekRange.ToString());
            if (range != null)
                ret.Items.Add(range.toTreeViewNode("range"));

            return ret;
        }
    }
}