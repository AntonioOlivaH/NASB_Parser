using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SpawnMovement : ISerializable, ITreeViewNode
    {
        public string ToBone { get; set; }
        public Vector3 LocalOffset { get; set; }
        public Vector3 WorldOffset { get; set; }
        public MovementConfig Config { get; set; }

        public SpawnMovement()
        {
        }

        internal SpawnMovement(BulkSerializeReader reader)
        {
            _ = reader.ReadInt();
            ToBone = reader.ReadString();
            LocalOffset = reader.ReadVector3();
            WorldOffset = reader.ReadVector3();
            Config = new MovementConfig(reader);
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(0);
            writer.Write(ToBone);
            writer.Write(LocalOffset);
            writer.Write(WorldOffset);
            writer.Write(Config);
        }

        public NASBTreeViewNode toTreeViewNode(string label)
        {
            NASBTreeViewNode ret = this.toTreeViewNode();
            ret.Header = label + "_" + ret.Header;
            return ret;
        }
        public NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SpawnMovement";
            ret.data.Add("ToBone", ToBone);
            ret.data.Add("LocalOffset", LocalOffset.ToString());
            ret.data.Add("WorldOffset", WorldOffset.ToString());
            ret.Items.Add(Config.toTreeViewNode("Config"));
            return ret;
        }
        public virtual Dictionary<string, Type> requisites()
        {
            throw new NotImplementedException();
        }
    }
}