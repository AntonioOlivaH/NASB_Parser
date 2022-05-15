using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.FloatSources
{
    public class FSLag : FloatSource
    {
        public LagTypes LagType { get; set; }
        public ManipLags ManipLag { get; set; }

        public FSLag()
        {
        }

        internal FSLag(BulkSerializeReader reader) : base(reader)
        {
            LagType = (LagTypes)reader.ReadInt();
            ManipLag = (ManipLags)reader.ReadInt();
        }
        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(LagType);
            writer.Write(ManipLag);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "FSLag";
            ret.data.Add("LagType", Enum.GetName(typeof(LagTypes), LagType));
            ret.data.Add("ManipLag", Enum.GetName(typeof(ManipLags), ManipLag));

            return ret;
        }

        public enum LagTypes
        {
            StateLag,
            MoveLag,
            Both
        }

        public enum ManipLags
        {
            Set,
            Add,
            Max
        }
    }
}