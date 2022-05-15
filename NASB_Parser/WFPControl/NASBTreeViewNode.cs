using System.Collections.Generic;
using System.Windows.Controls;

namespace NASB_Parser.WFPControl
{
    public class NASBTreeViewNode : TreeViewItem {

        public Dictionary<string, string> data;
        public object baseobject;

        public NASBTreeViewNode() {
            data = new Dictionary<string, string>();
        }
    }
}
