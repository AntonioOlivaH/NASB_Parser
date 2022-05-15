using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class HurtBone : ISerializable, ITreeViewNode
    {
        public HurtType Type { get; set; }
        public int Armor { get; set; }
        public int KnockbackArmor { get; set; }
        public bool ignoregrab { get; set; }
        public string BoneA { get; set; }
        public string BoneB { get; set; }
        public float Radius { get; set; }
        public Vector3 LocalOffsetA { get; set; }
        public Vector3 WorldOffsetA { get; set; }
        public Vector3 LocalOffsetB { get; set; }
        public Vector3 WorldOffsetB { get; set; }

        public HurtBone()
        {
        }

        internal HurtBone(BulkSerializeReader reader)
        {
            int version = reader.ReadInt();
            Type = (HurtType)reader.ReadInt();
            Armor = reader.ReadInt();
            if (version > 0)
            {
                KnockbackArmor = reader.ReadInt();
            } else {
                KnockbackArmor = 0;
            }
            ignoregrab = reader.ReadBool();
            BoneA = reader.ReadString();
            BoneB = reader.ReadString();
            Radius = reader.ReadFloat();
            LocalOffsetA = reader.ReadVector3();
            WorldOffsetA = reader.ReadVector3();
            LocalOffsetB = reader.ReadVector3();
            WorldOffsetB = reader.ReadVector3();
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(1);
            writer.Write(Type);
            writer.Write(Armor);
            writer.Write(KnockbackArmor);
            writer.Write(ignoregrab);
            writer.Write(BoneA);
            writer.Write(BoneB);
            writer.Write(Radius);
            writer.Write(LocalOffsetA);
            writer.Write(WorldOffsetA);
            writer.Write(LocalOffsetB);
            writer.Write(WorldOffsetB);
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
            ret.Header = "Hurtbone";

            ret.data.Add("Type", Enum.GetName(typeof(HurtType),Type));
            ret.data.Add("Armor", Armor.ToString());
            ret.data.Add("KnockbackArmor", KnockbackArmor.ToString());
            ret.data.Add("ignoregrab", ignoregrab.ToString());
            ret.data.Add("BoneA", BoneA.ToString());
            ret.data.Add("BoneB", BoneB.ToString());
            ret.data.Add("Radius", Radius.ToString());
            ret.data.Add("LocalOffsetA", LocalOffsetA.ToString());
            ret.data.Add("WorldOffsetA", WorldOffsetA.ToString());
            ret.data.Add("LocalOffsetB", LocalOffsetB.ToString());
            ret.data.Add("WorldOffsetB", WorldOffsetB.ToString());

            return ret;
        }
        public virtual Dictionary<string, Type> requisites()
        {
            throw new NotImplementedException();
        }
    }
}