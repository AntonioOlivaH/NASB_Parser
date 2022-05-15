﻿using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.Jumps
{
    public class AirDashJump : Jump
    {
        public Ease EaseSpeed { get; set; }
        public FloatSource XDir { get; set; }
        public FloatSource YDir { get; set; }
        public FloatSource SpeedStart { get; set; }
        public FloatSource SpeedEnd { get; set; }
        public FloatSource SpeedUpMult { get; set; }
        public FloatSource SpeedDownMult { get; set; }
        public FloatSource Frames { get; set; }
        public FloatSource RedirectFrames { get; set; }

        public AirDashJump()
        {
        }

        internal AirDashJump(BulkSerializeReader reader) : base(reader)
        {
            EaseSpeed = (Ease)reader.ReadInt();
            XDir = FloatSource.Read(reader);
            YDir = FloatSource.Read(reader);
            SpeedStart = FloatSource.Read(reader);
            SpeedEnd = FloatSource.Read(reader);
            SpeedUpMult = FloatSource.Read(reader);
            if (Version > 0)
            {
                SpeedDownMult = FloatSource.Read(reader);
            }
            Frames = FloatSource.Read(reader);
            RedirectFrames = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            writer.Write(TID);
            writer.Write(1);
            writer.Write(EaseSpeed);
            writer.Write(XDir);
            writer.Write(YDir);
            writer.Write(SpeedStart);
            writer.Write(SpeedEnd);
            writer.Write(SpeedUpMult);
            writer.Write(SpeedDownMult);
            writer.Write(Frames);
            writer.Write(RedirectFrames);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "AirDashJump";
            ret.data.Add("EaseSpeed", Enum.GetName(typeof(Ease), EaseSpeed));

            ret.Items.Add(XDir.toTreeViewNode("XDir"));
            ret.Items.Add(YDir.toTreeViewNode("YDir"));
            ret.Items.Add(SpeedStart.toTreeViewNode("SpeedStart"));
            ret.Items.Add(SpeedEnd.toTreeViewNode("SpeedEnd"));
            ret.Items.Add(SpeedUpMult.toTreeViewNode("SpeedUpMult"));
            ret.Items.Add(SpeedDownMult.toTreeViewNode("SpeedDownMult"));
            ret.Items.Add(Frames.toTreeViewNode("Frames"));
            ret.Items.Add(RedirectFrames.toTreeViewNode("RedirectFrames"));

            return ret;
        }
    }
}