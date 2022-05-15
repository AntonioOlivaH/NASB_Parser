using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;
using System.Numerics;

namespace NASB_Parser.Jumps
{
    public class DelayedJump : Jump {

        public FloatSource height;
        public FloatSource autoHoldFrames;
        public FloatSource yVelMaxOnRelease;

        public DelayedJump()
        {
        }

        internal DelayedJump(BulkSerializeReader reader) : base(reader)
        {
            height = FloatSource.Read(reader);
            autoHoldFrames = FloatSource.Read(reader);
            yVelMaxOnRelease = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer) {
            base.Write(writer);
            height.Write(writer);
            autoHoldFrames.Write(writer);
            yVelMaxOnRelease.Write(writer);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "DelayedJump";

            ret.Items.Add(height.toTreeViewNode("height"));
            ret.Items.Add(autoHoldFrames.toTreeViewNode("autoHoldFrames"));
            ret.Items.Add(yVelMaxOnRelease.toTreeViewNode("yVelMaxOnRelease"));

            return ret;
        }
    }
}