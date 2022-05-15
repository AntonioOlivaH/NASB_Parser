using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.CheckThings
{
    public class CTMultiple : CheckThing
    {
        public CheckMatch Match { get; set; } = CheckMatch.All;
        public List<CheckThing> Checklist { get; private set; } = new List<CheckThing>();

        public CTMultiple()
        {
        }

        internal CTMultiple(BulkSerializeReader reader) : base(reader)
        {
            Match = (CheckMatch)reader.ReadInt();
            Checklist = reader.ReadList(r => Read(r));
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Match);
            writer.Write(Checklist);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "CTMultiple";

            ret.data.Add("CheckMatch", Enum.GetName(typeof(CheckMatch), Match));
            foreach (CheckThing c in Checklist)
                ret.Items.Add(c.toTreeViewNode("Checklist"));

            return ret;
        }

        public enum CheckMatch
        {
            Any,
            All,
            One,
            None
        }
    }
}