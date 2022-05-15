using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAMapAnimation : StateAction
    {
        public List<MapPoint> Map { get; private set; } = new List<MapPoint>();

        public SAMapAnimation()
        {
        }

        internal SAMapAnimation(BulkSerializeReader reader) : base(reader)
        {
            Map = reader.ReadList(r => new MapPoint(r));
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Map);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAMapAnimation";

            foreach (MapPoint mp in Map)
                ret.Items.Add(mp.toTreeViewNode("Map"));

            return ret;
        }

        public class MapPoint : ISerializable, ITreeViewNode
        {
            public bool RootAnim { get; set; }
            public string AnimId { get; set; }
            public FloatSource AtFrames { get; set; }
            public FloatSource Frames { get; set; }
            public FloatSource StartAnimFrame { get; set; }
            public FloatSource EndAnimFrame { get; set; }

            public MapPoint()
            {
            }

            internal MapPoint(BulkSerializeReader reader)
            {
                _ = reader.ReadInt();
                RootAnim = reader.ReadBool();
                AnimId = reader.ReadString();
                AtFrames = FloatSource.Read(reader);
                Frames = FloatSource.Read(reader);
                StartAnimFrame = FloatSource.Read(reader);
                EndAnimFrame = FloatSource.Read(reader);
            }

            public void Write(BulkSerializeWriter writer)
            {
                writer.Write(0);
                writer.Write(RootAnim);
                writer.Write(AnimId);
                writer.Write(AtFrames);
                writer.Write(Frames);
                writer.Write(StartAnimFrame);
                writer.Write(EndAnimFrame);
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

                ret.data.Add("RootAnim", RootAnim.ToString());
                ret.data.Add("AnimId", AnimId);

                ret.Items.Add(AtFrames.toTreeViewNode("AtFrames"));
                ret.Items.Add(Frames.toTreeViewNode("Frames"));
                ret.Items.Add(StartAnimFrame.toTreeViewNode("StartAnimFrame"));
                ret.Items.Add(EndAnimFrame.toTreeViewNode("EndAnimFrame"));

                return ret;
            }
            public virtual Dictionary<string, Type> requisites()
            {
                throw new NotImplementedException();
            }
        }
    }
}