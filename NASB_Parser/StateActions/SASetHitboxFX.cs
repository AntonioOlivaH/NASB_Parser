using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SASetHitboxFX : StateAction
    {
        public int Hitbox { get; set; }
        public string FxId { get; set; }

        public SASetHitboxFX()
        {
        }

        internal SASetHitboxFX(BulkSerializeReader reader) : base(reader)
        {
            Hitbox = reader.ReadInt();
            FxId = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Hitbox);
            writer.Write(FxId);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SASetHitboxFX";

            ret.data.Add("Hitbox", Hitbox.ToString());
            ret.data.Add("FxId", FxId);

            return ret;
        }
    }
}