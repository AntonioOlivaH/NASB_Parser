using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAOrderedSensitive : StateAction
    {
        public List<StateAction> Actions { get; private set; } = new List<StateAction>();

        public SAOrderedSensitive()
        {
        }

        internal SAOrderedSensitive(BulkSerializeReader reader) : base(reader)
        {
            Actions = reader.ReadList(r => Read(r));
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Actions);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAOrderedSensitive";

            foreach(StateAction a in Actions)
                ret.Items.Add(a.toTreeViewNode("Actions"));

            ret.baseobject = this;

            return ret;
        }

        public override Dictionary<string, Type> requisites() {
            return new Dictionary<string, Type> {};
        }
    }
}