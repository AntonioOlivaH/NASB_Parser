﻿using NASB_Parser.FloatSources;
using NASB_Parser.WFPControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SATimingTweak : StateAction
    {
        public string AnimId { get; set; }
        public string RootAnimId { get; set; }
        public AnimConfig AnimCfg { get; set; }
        public FloatSource AnimFrames { get; set; }
        public FloatSource StateFrames { get; set; }
        public FloatSource FramesToA { get; set; }
        public FloatSource FramesToB { get; set; }
        public StateAction ActionA { get; set; }
        public StateAction ActionB { get; set; }
        public StateAction ActionEnd { get; set; }

        public SATimingTweak()
        {
        }

        internal SATimingTweak(BulkSerializeReader reader) : base(reader)
        {
            AnimId = reader.ReadString();
            RootAnimId = reader.ReadString();
            AnimCfg = new AnimConfig(reader);
            AnimFrames = FloatSource.Read(reader);
            StateFrames = FloatSource.Read(reader);
            FramesToA = FloatSource.Read(reader);
            FramesToB = FloatSource.Read(reader);
            ActionA = Read(reader);
            ActionB = Read(reader);
            ActionEnd = Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(AnimId);
            writer.Write(RootAnimId);
            writer.Write(AnimCfg);
            writer.Write(AnimFrames);
            writer.Write(StateFrames);
            writer.Write(FramesToA);
            writer.Write(FramesToB);
            writer.Write(ActionA);
            writer.Write(ActionB);
            writer.Write(ActionEnd);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SATimingTweak";

            ret.data.Add("AnimId", AnimId);
            ret.data.Add("RootAnimId", RootAnimId);
            ret.Items.Add(AnimCfg.toTreeViewNode("AnimCfg"));
            ret.Items.Add(AnimFrames.toTreeViewNode("AnimFrames"));
            ret.Items.Add(StateFrames.toTreeViewNode("StateFrames"));
            ret.Items.Add(FramesToA.toTreeViewNode("FramesToA"));
            ret.Items.Add(FramesToB.toTreeViewNode("FramesToB"));
            ret.Items.Add(ActionA.toTreeViewNode("ActionA"));
            ret.Items.Add(ActionB.toTreeViewNode("ActionB"));
            ret.Items.Add(ActionEnd.toTreeViewNode("ActionEnd"));

            return ret;
        }
    }
}