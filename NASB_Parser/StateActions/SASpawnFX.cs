using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SASpawnFX : StateAction
    {
        public bool Dynamic { get; set; }
        public bool Track { get; set; }
        public bool BoneDir { get; set; }
        public string Id { get; set; }
        public string Bone { get; set; }
        public Vector3 LocalOffset { get; set; }
        public Vector3 GlobalOffset { get; set; }
        public FloatSource DirX { get; set; }
        public FloatSource DirY { get; set; }
        public FloatSource DirZ { get; set; }
        public FloatSource DynamicX { get; set; }
        public FloatSource DynamicY { get; set; }
        public FloatSource DynamicZ { get; set; }
        public FloatSource Scale { get; set; }

        public SASpawnFX()
        {
        }

        internal SASpawnFX(BulkSerializeReader reader) : base(reader)
        {
            Dynamic = reader.ReadBool();
            Track = reader.ReadBool();
            BoneDir = reader.ReadBool();
            Id = reader.ReadString();
            Bone = reader.ReadString();
            LocalOffset = reader.ReadVector3();
            GlobalOffset = reader.ReadVector3();
            DirX = FloatSource.Read(reader);
            DirY = FloatSource.Read(reader);
            DirZ = FloatSource.Read(reader);
            DynamicX = FloatSource.Read(reader);
            DynamicY = FloatSource.Read(reader);
            DynamicZ = FloatSource.Read(reader);
            Scale = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Dynamic);
            writer.Write(Track);
            writer.Write(BoneDir);
            writer.Write(Id);
            writer.Write(Bone);
            writer.Write(LocalOffset);
            writer.Write(GlobalOffset);
            writer.Write(DirX);
            writer.Write(DirY);
            writer.Write(DirZ);
            writer.Write(DynamicX);
            writer.Write(DynamicY);
            writer.Write(DynamicZ);
            writer.Write(Scale);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SASpawnFX";

            ret.data.Add("Dynamic", Dynamic.ToString());
            ret.data.Add("Track", Track.ToString());
            ret.data.Add("BoneDir", BoneDir.ToString());
            ret.data.Add("Id", Id);
            ret.data.Add("Bone", Bone);
            ret.data.Add("LocalOffset", LocalOffset.ToString());
            ret.data.Add("GlobalOffset", GlobalOffset.ToString());


            ret.Items.Add(DirX.toTreeViewNode("DirX"));
            ret.Items.Add(DirY.toTreeViewNode("DirY"));
            ret.Items.Add(DirZ.toTreeViewNode("DirZ"));
            ret.Items.Add(DynamicX.toTreeViewNode("DynamicX"));
            ret.Items.Add(DynamicY.toTreeViewNode("DynamicY"));
            ret.Items.Add(DynamicZ.toTreeViewNode("DynamicZ"));
            ret.Items.Add(Scale.toTreeViewNode("Scale"));

            return ret;
        }
    }
}