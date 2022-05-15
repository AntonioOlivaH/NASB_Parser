using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.CheckThings
{
    public class CTCompareFloat : CheckThing
    {
        public CheckWay Way { get; set; }
        public FloatSource A { get; set; }
        public FloatSource B { get; set; }

        public CTCompareFloat()
        {
        }

        internal CTCompareFloat(BulkSerializeReader reader) : base(reader)
        {
            Way = (CheckWay)reader.ReadInt();
            A = FloatSource.Read(reader);
            B = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Way);
            writer.Write(A);
            writer.Write(B);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "CTCompareFloat";

            ret.data.Add("Way", Enum.GetName(typeof(CheckWay), Way));
            ret.Items.Add(A.toTreeViewNode("A"));
            ret.Items.Add(B.toTreeViewNode("B"));

            return ret;
        }
    }
}