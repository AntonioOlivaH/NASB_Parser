using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.CheckThings
{
    public class CTSkin : CheckThing
    {
        public string MatchSkin { get; set; }
        public bool MatchColor { get; set; }
        public int MatchAgainstColor { get; set; }

        public CTSkin()
        {
        }

        internal CTSkin(BulkSerializeReader reader) : base(reader)
        {
            MatchSkin = reader.ReadString();
            MatchColor = reader.ReadBool();
            MatchAgainstColor = reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(MatchSkin);
            writer.Write(MatchColor);
            writer.Write(MatchAgainstColor);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "CTSkin";

            ret.data.Add("MatchSkin", MatchSkin);
            ret.data.Add("MatchColor", MatchColor.ToString());
            ret.data.Add("MatchAgainstColor", MatchAgainstColor.ToString());

            return ret;
        }
    }
}