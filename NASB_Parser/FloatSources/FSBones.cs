using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.FloatSources
{
    public class FSBones : FloatSource
    {
        public Attributes Attribute { get; set; }
        public string bone = null;

        public FSBones()
        { }

        internal FSBones(BulkSerializeReader reader) : base(reader)
        {
            Attribute = (Attributes)reader.ReadInt();
            if (this.Version > 0 && Attribute == Attributes.BoneActive)
                bone = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            writer.Write(2);
            writer.Write(1);
            writer.Write(Attribute);
            if (Attribute == Attributes.BoneActive)
                writer.Write(bone);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "FSBones";

            ret.data.Add("Attribute", Enum.GetName(typeof(Attributes), Attribute));
            return ret;
        }

        public enum Attributes
        {
            RotationAngle,
            LookAngle,
            TiltAngle,
            MirrorByDirection,
            OffsetX,
            OffsetY,
            BoneActive
        }
    }
}