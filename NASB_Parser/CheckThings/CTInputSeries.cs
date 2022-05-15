using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.CheckThings
{
    public class CTInputSeries : CheckThing
    {
        public int CheckFrames { get; set; }
        public List<LookForInput> InputSeries { get; private set; } = new List<LookForInput>();
        public List<LookForInput> StopLooking { get; private set; } = new List<LookForInput>();

        public CTInputSeries()
        {
        }

        internal CTInputSeries(BulkSerializeReader reader) : base(reader)
        {
            CheckFrames = reader.ReadInt();
            InputSeries = reader.ReadList(r => new LookForInput(r));
            StopLooking = reader.ReadList(r => new LookForInput(r));
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(CheckFrames);
            writer.Write(InputSeries);
            writer.Write(StopLooking);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "CTInputSeries";

            ret.data.Add("CheckFrames", CheckFrames.ToString());
            foreach (LookForInput l in InputSeries)
                ret.Items.Add(l.toTreeViewNode("InputSeries"));
            foreach (LookForInput l in StopLooking)
                ret.Items.Add(l.toTreeViewNode("StopLooking"));

            return ret;
        }
    }
}