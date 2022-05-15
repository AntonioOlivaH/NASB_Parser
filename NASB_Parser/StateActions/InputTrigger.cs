using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class InputTrigger : ISerializable, ITreeViewNode
    {
        public int SniffFrames { get; set; }
        public GIEV BlockedByEvent { get; set; }
        public GIEV AddEventOnTrigger { get; set; }
        public StateAction Action { get; set; }
        public InputValidator Validator { get; set; }

        public InputTrigger()
        {
        }

        public InputTrigger(BulkSerializeReader reader)
        {
            _ = reader.ReadInt();
            SniffFrames = reader.ReadInt();
            BlockedByEvent = (GIEV)reader.ReadInt();
            AddEventOnTrigger = (GIEV)reader.ReadInt();
            Action = StateAction.Read(reader);
            Validator = new InputValidator(reader);
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(0);
            writer.Write(SniffFrames);
            writer.Write(BlockedByEvent);
            writer.Write(AddEventOnTrigger);
            writer.Write(Action);
            writer.Write(Validator);
        }

        public NASBTreeViewNode toTreeViewNode(string label)
        {
            NASBTreeViewNode ret = this.toTreeViewNode();
            ret.Header = label + "_" + ret.Header;
            return ret;
        }
        public NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "InputTrigger";

            ret.data.Add("SniffFrames", SniffFrames.ToString());
            ret.data.Add("BlockedByEvent", Enum.GetName(typeof(GIEV), BlockedByEvent));
            ret.data.Add("AddEventOnTrigger", Enum.GetName(typeof(GIEV), AddEventOnTrigger));
            ret.Items.Add(Action.toTreeViewNode("Action"));
            ret.Items.Add(Validator.toTreeViewNode("Validator"));

            return ret;
        }
        public virtual Dictionary<string, Type> requisites()
        {
            throw new NotImplementedException();
        }
    }
}