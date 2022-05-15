using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    class SAOnLeaveParent : StateAction {

        public StateAction Action { get; set; }

        private int reg;
        internal SAOnLeaveParent(BulkSerializeReader reader) : base(reader)
        {
            Action = Read(reader);
        }

        public override void Write(BulkSerializeWriter writer) {
            base.Write(writer);
            writer.Write(Action);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAOnLeaveParent";

            ret.Items.Add(Action.toTreeViewNode("Action"));

            return ret;
        }
    }
}
