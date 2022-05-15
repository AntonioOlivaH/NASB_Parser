using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAUpdateHitboxes : StateAction
    {
        public SAUpdateHitboxes()
        {
        }

        internal SAUpdateHitboxes(BulkSerializeReader reader) : base(reader)
        {
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAUpdateHitboxes";
            return ret;
        }
    }
}