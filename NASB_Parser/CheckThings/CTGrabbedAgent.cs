using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.CheckThings
{
    public class CTGrabbedAgent : CheckThing
    {
        public List<string> MatchTags { get; private set;  } = new List<string>();

        public CTGrabbedAgent()
        {
        }

        internal CTGrabbedAgent(BulkSerializeReader reader) : base(reader)
        {
            MatchTags = reader.ReadList(r => r.ReadString());
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(MatchTags);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "CTGrabbedAgent";

            ret.data.Add("MatchTags", String.Join("\n", MatchTags));

            return ret;
        }
    }
}