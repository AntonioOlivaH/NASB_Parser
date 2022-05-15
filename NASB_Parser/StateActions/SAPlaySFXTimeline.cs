using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAPlaySFXTimeline : StateAction
    {
        public ManipType Manip { get; set; }
        public bool Loop { get; set; }
        public FloatSource Source { get; set; }
        public string Timeline { get; set; }

        public SAPlaySFXTimeline()
        {
        }

        internal SAPlaySFXTimeline(BulkSerializeReader reader) : base(reader)
        {
            Manip = (ManipType)reader.ReadInt();
            Loop = reader.ReadBool();
            Source = FloatSource.Read(reader);
            Timeline = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Manip);
            writer.Write(Loop);
            writer.Write(Source);
            writer.Write(Timeline);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAPlaySFXTimeline";

            ret.data.Add("Manip", Enum.GetName(typeof(ManipType), Manip));
            ret.data.Add("Loop", Loop.ToString());
            ret.Items.Add(Source.toTreeViewNode("Source"));
            ret.data.Add("Timeline", Timeline);

            return ret;
        }

        public enum ManipType
        {
            Play,
            Rate,
            Position
        }
    }
}