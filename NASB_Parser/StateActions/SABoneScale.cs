using NASB_Parser.FloatSources;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SABoneScale : StateAction
    {
        public string Bone { get; set; }
        public FloatSource Source { get; set; }

        public SABoneScale()
        {
        }

        internal SABoneScale(BulkSerializeReader reader) : base(reader)
        {
            Bone = reader.ReadString();
            Source = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Bone);
            writer.Write(Source);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SABoneScale";

            ret.data.Add("Bone", Bone);
            ret.Items.Add(Source.toTreeViewNode("Source"));

            return ret;
        }
    }
}