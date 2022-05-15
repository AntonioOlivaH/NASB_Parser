using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAPlaySFX : StateAction
    {
        public string SfxId { get; set; }

        public SAPlaySFX()
        {
        }

        internal SAPlaySFX(BulkSerializeReader reader) : base(reader)
        {
            SfxId = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(SfxId);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAPlaySFX";

            ret.data.Add("SfxId", SfxId);

            return ret;
        }
    }
}