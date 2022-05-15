using NASB_Parser.StateActions;
using NASB_Parser.WFPControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser
{
    public class TimedAction : ISerializable, ITreeViewNode
    {
        public float AtFrame { get; set; }
        public StateAction Action { get; set; }

        public TimedAction() { }

        internal TimedAction(BulkSerializeReader reader)
        {
            _ = reader.ReadInt();
            AtFrame = reader.ReadFloat();
            Action = StateAction.Read(reader);
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(0);
            writer.Write(AtFrame);
            writer.Write(Action);
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
            ret.Header = "TimedAction";
            ret.data.Add("AtFrame", AtFrame.ToString());
            ret.Items.Add(Action.toTreeViewNode("Action"));
            return ret;
        }
        public virtual Dictionary<string, Type> requisites()
        {
            throw new NotImplementedException();
        }
    }
}