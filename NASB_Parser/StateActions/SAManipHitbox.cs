using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAManipHitbox : StateAction
    {
        public List<HBM> Manips { get; private set; } = new List<HBM>();

        public SAManipHitbox()
        {
        }

        internal SAManipHitbox(BulkSerializeReader reader) : base(reader)
        {
            Manips = reader.ReadList(r => new HBM(r));
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Manips);
        }
        public NASBTreeViewNode toTreeViewNode(string label)
        {
            NASBTreeViewNode ret = this.toTreeViewNode();
            ret.Header = label + "_" + ret.Header;
            return ret;
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAManipHitbox";

            foreach (HBM mp in Manips)
                ret.Items.Add(mp.toTreeViewNode("Manips"));

            return ret;
        }

        public enum Manip
        {
            Radius,
            InteractWithHurtsets,
            WorldOffsetX,
            WorldOffsetY,
            WorldOffsetZ,
            LocalOffsetX,
            LocalOffsetY,
            LocalOffsetZ,
            WorldOffsetX2nd,
            WorldOffsetY2nd,
            WorldOffsetZ2nd,
            LocalOffsetX2nd,
            LocalOffsetY2nd,
            LocalOffsetZ2nd,
            bone,
            bone2
        }

        public class HBM : ISerializable
        {
            public Manip Manip { get; set; }
            public int Hitbox { get; set; }
            public FloatSource Source { get; set; }

            public string bone;

            public string bone2;

            private int livebone = -1;

            private int livebone2 = -1;

            public HBM()
            {
            }

            internal HBM(BulkSerializeReader reader)
            {
                int version = reader.ReadInt();
                Manip = (Manip)reader.ReadInt();
                Hitbox = reader.ReadInt();
                Source = FloatSource.Read(reader);
                if (version > 0 && (Manip == Manip.bone || Manip == Manip.bone2)) {
                    bone = reader.ReadString();
                    if (Manip == Manip.bone2)
                        bone2 = reader.ReadString();
                }
            }

            public void Write(BulkSerializeWriter writer)
            {
                writer.Write(1);
                writer.Write(Manip);
                writer.Write(Hitbox);
                writer.Write(Source);
                if (Manip == Manip.bone || Manip == Manip.bone2) {
                    writer.Write(bone);
                    if (Manip == Manip.bone2)
                        writer.Write(bone2);
                }
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
                ret.Header = "HBM";

                ret.data.Add("Manip", Manip.ToString());
                ret.data.Add("Hurtbox", Hitbox.ToString());
                ret.data.Add("Source", Source.ToString());
                ret.data.Add("bone1", bone);
                ret.data.Add("bone2", bone2);

                return ret;
            }
        }
    }
}