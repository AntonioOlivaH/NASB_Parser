using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SASampleAnim : StateAction
    {
        public SASampleAnim()
        {
        }

        internal SASampleAnim(BulkSerializeReader reader) : base(reader)
        {
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SASampleAnim";

            return ret;
        }
    }
}