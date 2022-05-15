using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAMapAnimationSimple : StateAction
    {

        public List<MapPoint> Map { get; private set; } = new List<MapPoint>();

        public bool RootAnim { get; set; }
        public string AnimId { get; set; }

        public SAMapAnimationSimple()
        {
        }

        internal SAMapAnimationSimple(BulkSerializeReader reader) : base(reader) {
            AnimId = reader.ReadString();
            RootAnim = reader.ReadBool();
            Map = reader.ReadList(r => new MapPoint(r));
        }

        public override void Write(BulkSerializeWriter writer) {
            base.Write(writer);
            writer.Write(AnimId);
            writer.Write(RootAnim);
            writer.Write(Map);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAMapAnimationSimple";

            foreach (MapPoint mp in Map)
                ret.Items.Add(mp.toTreeViewNode("Map"));

            ret.data.Add("RootAnim", RootAnim.ToString());
            ret.data.Add("AnimId", AnimId);

            return ret;
        }

        public class MapPoint : ISerializable, ITreeViewNode
		{

            public FloatSource offsetFrame { get; set; }
            public FloatSource animFrame { get; set; }

            public MapPoint()
            {
            }

            internal MapPoint(BulkSerializeReader reader)
            {
                _ = reader.ReadInt();
                offsetFrame = FloatSource.Read(reader);
                animFrame = FloatSource.Read(reader);
            }

            public void Write(BulkSerializeWriter writer) {
                writer.Write(0);
                writer.Write(offsetFrame);
                writer.Write(animFrame);
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
                ret.Header = "MapPoint";

                ret.Items.Add(offsetFrame.toTreeViewNode("offsetFrame"));
                ret.Items.Add(animFrame.toTreeViewNode("animFrame"));

                return ret;
            }

            public virtual Dictionary<string, Type> requisites()
            {
                throw new NotImplementedException();
            }
        }
    }
}
