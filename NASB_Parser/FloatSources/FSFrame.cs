using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.FloatSources
{
    public class FSFrame : FSValue
    {
        public FSFrame() {
        }

        public FSFrame(float x) : base(x)
        {
        }

        internal FSFrame(BulkSerializeReader reader) : base(reader)
        {
        }

        public override void Write(BulkSerializeWriter writer) {
            base.Write(writer);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = base.toTreeViewNode();
            ret.Header = "FSFrame";
            return ret;
        }
    }
}