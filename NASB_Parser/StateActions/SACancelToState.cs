using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SACancelToState : StateAction
    {
        public string ToState { get; set; }
        public bool Soft { get; set; }

        public SACancelToState()
        {
        }

        internal SACancelToState(BulkSerializeReader reader) : base(reader)
        {
            ToState = reader.ReadString();
            Soft = reader.ReadBool();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(ToState);
            writer.Write(Soft);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SACancelToState";

            ret.data.Add("ToState", ToState);
            ret.data.Add("Soft", Soft.ToString());

            return ret;
        }
    }
}