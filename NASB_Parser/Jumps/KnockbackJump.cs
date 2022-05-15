using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;
using System.Numerics;

namespace NASB_Parser.Jumps
{
    public class KnockbackJump : Jump
    {
        public FloatSource XDir { get; set; }
        public FloatSource YDir { get; set; }
        public FloatSource LaunchDist { get; set; }
        public FloatSource Frames { get; set; }
        public bool doLaunch;
        public FloatSource bounceMinVel { get; set; }
        public float travelDist;
        private Vector2 baseVel;
        private Vector2 flyVel;
        private Vector2 trueVel;
        private float timerEnd;
        private float timer;
        private bool didDI;
        private int diType;
        private float diIn;
        private float diOut;
        private float minVel;
        private bool memGrounded;
        private float memFallSpeed;
        private float memGravity;
        private float actFallSpeed;
        private float actGravity;
        private float rate = 1f;
        private float targetRate = 1f;
        private float changeRate;
        private Vector2 approxDestination;
        private const float distGateLow = 5f;
        private const float distGateHigh = 15f;
        private const float increaseGravityAfterFrames = 15f;

        public KnockbackJump()
        {
        }

        internal KnockbackJump(BulkSerializeReader reader) : base(reader)
        {
            XDir = FloatSource.Read(reader);
            YDir = FloatSource.Read(reader);
            LaunchDist = FloatSource.Read(reader);
            Frames = FloatSource.Read(reader);
            if (this.Version <= 2)
            {
                _ = FloatSource.Read(reader);
                _ = FloatSource.Read(reader);
                _ = FloatSource.Read(reader);
            }
            if (this.Version == 0)
                return;
            doLaunch = reader.ReadBool();
            if (this.Version == 1)
                return;
            bounceMinVel = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            writer.Write(TID); // ID
            writer.Write(3); // Version
            writer.Write(XDir);
            writer.Write(YDir);
            writer.Write(LaunchDist);
            writer.Write(Frames);
            writer.Write(doLaunch);
            bounceMinVel.Write(writer);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "KnockbackJump";

            ret.Items.Add(XDir.toTreeViewNode("XDir"));
            ret.Items.Add(YDir.toTreeViewNode("YDir"));
            ret.Items.Add(LaunchDist.toTreeViewNode("LaunchDist"));
            ret.Items.Add(Frames.toTreeViewNode("Frames"));
            ret.Items.Add(bounceMinVel.toTreeViewNode("bounceMinVel"));

            return ret;
        }
    }
}