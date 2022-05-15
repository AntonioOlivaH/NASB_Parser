using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SABoneState : StateAction
    {
        public bool State { get; set; }
        public string Bone { get; set; }

        public SABoneState()
        {
        }

        internal SABoneState(BulkSerializeReader reader) : base(reader)
        {
            State = reader.ReadBool();
            Bone = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(State);
            writer.Write(Bone);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SABoneState";

            ret.data.Add("State", State.ToString());

            return ret;
        }
    }
}