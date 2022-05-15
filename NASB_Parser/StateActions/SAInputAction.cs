using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAInputAction : StateAction
    {
        public float Frames { get; set; }
        public string Id { get; set; }
        public InputTrigger Trigger { get; set; }

        public SAInputAction()
        {
        }

        internal SAInputAction(BulkSerializeReader reader) : base(reader)
        {
            Frames = reader.ReadFloat();
            Id = reader.ReadString();
            Trigger = new InputTrigger(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Frames);
            writer.Write(Id);
            writer.Write(Trigger);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAInputAction";

            ret.data.Add("Frames", Frames.ToString());
            ret.data.Add("Id", Id);
            ret.Items.Add(Trigger.toTreeViewNode("Trigger"));

            return ret;
        }
    }
}