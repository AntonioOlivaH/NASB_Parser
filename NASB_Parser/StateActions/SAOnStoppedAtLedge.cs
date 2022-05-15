using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAOnStoppedAtLedge : StateAction
    {
        public StateAction Action { get; set; }

        public SAOnStoppedAtLedge()
        {
        }

        internal SAOnStoppedAtLedge(BulkSerializeReader reader) : base(reader)
        {
            Action = Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Action);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAOnStoppedAtLedge";

            ret.Items.Add(Action.toTreeViewNode("Action"));

            return ret;
        }
    }
}