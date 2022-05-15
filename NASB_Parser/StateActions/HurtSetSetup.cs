using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class HurtSetSetup : ISerializable, ITreeViewNode
    {
        public List<HurtBone> HurtBones { get; private set; } = new List<HurtBone>();

        public HurtSetSetup()
        {
        }

        internal HurtSetSetup(BulkSerializeReader reader)
        {
            _ = reader.ReadInt();
            HurtBones = reader.ReadList(r => new HurtBone(r));
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(0);
            writer.Write(HurtBones);
        }

        public NASBTreeViewNode toTreeViewNode(string label)
        {
            NASBTreeViewNode ret = this.toTreeViewNode();
            ret.Header = label + "_" + ret.Header;
            return ret;
        }

        public NASBTreeViewNode toTreeViewNode() {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "HurtSetSetup";

            foreach (HurtBone b in HurtBones) {
                ret.Items.Add(b.toTreeViewNode("HurtBones"));
            }

            return ret;
        }
        public virtual Dictionary<string, Type> requisites()
        {
            throw new NotImplementedException();
        }
    }
}