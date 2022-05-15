using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAConfigHitbox : StateAction
    {
        public int Hitbox { get; set; }
        public bool ForceZ0 { get; set; }
        public float Radius { get; set; }
        public Vector3 LocalOffset { get; set; }
        public Vector3 WorldOffset { get; set; }
        public string Prop { get; set; }
        public string Bone { get; set; }
        public string FxId { get; set; }
        public string SfxId { get; set; }
        public bool SecondTrack { get; set; }
        public string Bone2 { get; set; }
        public Vector3 LocalOffset2 { get; set; }
        public Vector3 WorldOffset2 { get; set; }

        public SAConfigHitbox()
        {
        }

        internal SAConfigHitbox(BulkSerializeReader reader) : base(reader)
        {
            Hitbox = reader.ReadInt();
            ForceZ0 = reader.ReadBool();
            Radius = reader.ReadFloat();
            LocalOffset = reader.ReadVector3();
            WorldOffset = reader.ReadVector3();
            Prop = reader.ReadString();
            Bone = reader.ReadString();
            FxId = reader.ReadString();
            SfxId = reader.ReadString();
            if (Version != 0)
            {
                SecondTrack = reader.ReadBool();
                if (SecondTrack)
                {
                    Bone2 = reader.ReadString();
                    LocalOffset2 = reader.ReadVector3();
                    WorldOffset2 = reader.ReadVector3();
                } else {
                    Bone2 = "";
                    LocalOffset2 = Vector3.newVector();
                    WorldOffset2 = Vector3.newVector();
                }
            }
        }

        public override void Write(BulkSerializeWriter writer)
        {
            writer.Write(TID);
            writer.Write(1);
            writer.Write(Hitbox);
            writer.Write(ForceZ0);
            writer.Write(Radius);
            writer.Write(LocalOffset);
            writer.Write(WorldOffset);
            writer.Write(Prop);
            writer.Write(Bone);
            writer.Write(FxId);
            writer.Write(SfxId);
            writer.Write(SecondTrack);
            if (SecondTrack)
            {
                writer.Write(Bone2);
                writer.Write(LocalOffset2);
                writer.Write(WorldOffset2);
            }
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAConfigHitbox";

            ret.data.Add("Hitbox", Hitbox.ToString());
            ret.data.Add("ForceZ0", ForceZ0.ToString());
            ret.data.Add("Radius", Radius.ToString());
            ret.data.Add("LocalOffset", LocalOffset.ToString());
            ret.data.Add("WorldOffset", WorldOffset.ToString());
            ret.data.Add("Prop", Prop);
            ret.data.Add("Bone", Bone);
            ret.data.Add("FxId", FxId);
            ret.data.Add("SfxId", SfxId);
            ret.data.Add("SecondTrack", SecondTrack.ToString());
            ret.data.Add("Bone2", Bone2);
            ret.data.Add("LocalOffset2", LocalOffset2.ToString());
            ret.data.Add("WorldOffset2", WorldOffset2.ToString());

            return ret;
        }
    }
}