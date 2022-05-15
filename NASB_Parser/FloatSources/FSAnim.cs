using NASB_Parser.FloatSources;
using NASB_Parser.WFPControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSAnim : FloatSource
    {
        public string Anim { get; set; }
        public AnimAttr Attribute { get; set; }

        public FSAnim()
        {
        }

        internal FSAnim(BulkSerializeReader reader) : base(reader)
        {
            Anim = reader.ReadString();
            Attribute = (AnimAttr)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Anim);
            writer.Write(Attribute);
        }

        public override NASBTreeViewNode toTreeViewNode() {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "FSAnim";

            ret.data.Add("Anim", Anim);
            ret.data.Add("Attribute", Enum.GetName(typeof(AnimAttr),Attribute));
            return ret;
        }

        public enum AnimAttr
        {
            Rate,
            Weight,
            AtTime,
            AtFrame,
            RealWeight,
            Exists,
            FrameLength
        }
    }
}