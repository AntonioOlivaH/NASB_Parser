using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAResetOnHits : StateAction
    {
        public SAResetOnHits()
        {
        }

        internal SAResetOnHits(BulkSerializeReader reader) : base(reader)
        {
        }

        public override NASBTreeViewNode toTreeViewNode() {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAResetOnHits";

            return ret;
        }
    }
}