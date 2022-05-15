using NASB_Parser.StateActions;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.CheckThings
{
    public class CTInput : CheckThing
    {
        public InputValidator InputValidator { get; set; }
        public int Frames { get; set; }
        public GIEV BlockedBy { get; set; }

        public CTInput()
        {
        }

        internal CTInput(BulkSerializeReader reader) : base(reader)
        {
            InputValidator = new InputValidator(reader);
            Frames = reader.ReadInt();
            BlockedBy = (GIEV)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(InputValidator);
            writer.Write(Frames);
            writer.Write(BlockedBy);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "CTInput";

            ret.data.Add("BlockedBy", Enum.GetName(typeof(GIEV), BlockedBy));
            ret.data.Add("Frames", Frames.ToString());
            ret.Items.Add(InputValidator.toTreeViewNode("InputValidator"));

            return ret;
        }
    }
}