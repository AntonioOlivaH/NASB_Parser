using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAAlterMoveVel : StateAction
    {
        public bool ClearAMV { get; set; }
        public FloatSource AlterX { get; set; }
        public FloatSource AlterY { get; set; }
        public FloatSource FalloffX { get; set; }
        public FloatSource FalloffY { get; set; }

        public SAAlterMoveVel()
        {
        }

        internal SAAlterMoveVel(BulkSerializeReader reader) : base(reader)
        {
            ClearAMV = reader.ReadBool();
            AlterX = FloatSource.Read(reader);
            AlterY = FloatSource.Read(reader);
            FalloffX = FloatSource.Read(reader);
            FalloffY = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(ClearAMV);
            writer.Write(AlterX);
            writer.Write(AlterY);
            writer.Write(FalloffX);
            writer.Write(FalloffY);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAAlterMoveVel";

            ret.data.Add("ClearAMV", ClearAMV.ToString());
            ret.Items.Add(AlterX.toTreeViewNode("AlterX"));
            ret.Items.Add(AlterY.toTreeViewNode("AlterY"));
            ret.Items.Add(FalloffX.toTreeViewNode("FalloffX"));
            ret.Items.Add(FalloffY.toTreeViewNode("FalloffY"));

            return ret;
        }
    }
}