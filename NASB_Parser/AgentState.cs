using System;
using System.Collections.Generic;
using NASB_Parser.WFPControl;

namespace NASB_Parser
{
    public class AgentState : ISerializable, ITreeViewNode
    {
        public string CustomCall { get; set; }
        // Needed for system.text.json
        public List<TimedAction> Timeline { get; private set; } = new List<TimedAction>();

        public AgentState()
        {
        }

        internal static AgentState Read(BulkSerializeReader reader)
        {
            int tid = reader.ReadInt();
            if (tid != 0)
                throw new ReadException(reader, $"Cannot read an AgentState from tid: {tid}");
            return new AgentState(reader);
        }

        private AgentState(BulkSerializeReader reader)
        {
            _ = reader.ReadInt();
            CustomCall = reader.ReadString();
            Timeline = reader.ReadList(r => new TimedAction(r));
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(0);
            writer.Write(0);
            writer.Write(CustomCall);
            writer.Write(Timeline);
        }

        public NASBTreeViewNode toTreeViewNode(string label)
        {
            NASBTreeViewNode ret = this.toTreeViewNode();
            ret.Header = label + "_" + ret.Header;
            return ret;
        }

        public NASBTreeViewNode toTreeViewNode() {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "AgentState";
            ret.data.Add("CustomCall", CustomCall);
            foreach(TimedAction t in Timeline)
                ret.Items.Add(t.toTreeViewNode("Timeline"));
            return ret;
        }
        public virtual Dictionary<string, Type> requisites()
        {
            throw new NotImplementedException();
        }
    }
}