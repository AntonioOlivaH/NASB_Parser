using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;
using System.Numerics;

namespace NASB_Parser.Jumps
{
    public class ClampMomentumJump : Jump
    {
        public Vector2 speedStart { get; set; }
        public Vector2 speedClamp { get; set; }
        private Vector2 speedResist { get; set; }
        private float sign;
        private float damage;
        private float timer;
        private float timerEnd;

        public ClampMomentumJump()
        {
        }

        internal ClampMomentumJump(BulkSerializeReader reader) : base(reader) {
            
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "ClampMomentumJump";

            return ret;
        }
    }
}