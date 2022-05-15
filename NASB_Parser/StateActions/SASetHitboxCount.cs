using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SASetHitboxCount : StateAction
    {
        public int HitboxCount { get; set; }

        public SASetHitboxCount()
        {
        }

        internal SASetHitboxCount(BulkSerializeReader reader) : base(reader)
        {
            HitboxCount = reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(HitboxCount);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SASetHitboxCount";

            ret.data.Add("HitboxCount", HitboxCount.ToString());

            return ret;
        }
    }
}