using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SASetStagePart : StateAction
    {
        public bool SetTo { get; set; }
        public string PartId { get; set; }

        public SASetStagePart()
        {
        }

        internal SASetStagePart(BulkSerializeReader reader) : base(reader)
        {
            SetTo = reader.ReadBool();
            PartId = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(SetTo);
            writer.Write(PartId);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SASetStagePart";

            ret.data.Add("SetTo", SetTo.ToString());
            ret.data.Add("PartId", PartId);

            return ret;
        }
    }
}