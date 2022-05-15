using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public struct AnimConfig : ISerializable, ITreeViewNode
    {
        public float Rate { get; set; }
        public float Weight { get; set; }
        public WrapMode Wrap { get; set; }
        public bool ClingToFrames { get; set; }

        public AnimConfig(BulkSerializeReader reader)
        {
            _ = reader.ReadInt();
            Rate = reader.ReadFloat();
            Weight = reader.ReadFloat();
            Wrap = (WrapMode)reader.ReadInt();
            ClingToFrames = reader.ReadBool();
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(0);
            writer.Write(Rate);
            writer.Write(Weight);
            writer.Write(Wrap);
            writer.Write(ClingToFrames);
        }

        public enum WrapMode
        {
            Once = 1,
            Loop,
            PingPong = 4,
            Default = 0,
            ClampForever = 8,
            Clamp = 1
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
            ret.Header = "AnimConfig";
            ret.data.Add("Rate", Rate.ToString());
            ret.data.Add("Weight", Weight.ToString());
            ret.data.Add("Wrap", Enum.GetName(typeof(WrapMode), Wrap));
            ret.data.Add("ClingToFrames", ClingToFrames.ToString());
            return ret;
        }
        public Dictionary<string, Type> requisites()
        {
            throw new NotImplementedException();
        }
    }
}
