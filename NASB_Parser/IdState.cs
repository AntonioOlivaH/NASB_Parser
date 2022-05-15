using System;
using System.Collections.Generic;
using NASB_Parser.WFPControl;

namespace NASB_Parser
{
    public class IdState : ISerializable, ITreeViewNode
    {
        public string Id { get; set; }
        public List<string> Tags { get; private set; } = new List<string>();
        public AgentState State { get; set; }

        public IdState()
        {
        }

        internal IdState(BulkSerializeReader reader)
        {
            // Throwaway unused id
            _ = reader.ReadInt();
            Id = reader.ReadString();
            Tags = reader.ReadList(r => r.ReadString());
            State = AgentState.Read(reader);
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(0);
            writer.Write(Id);
            writer.Write(Tags);
            writer.Write(State);
        }

        public NASBTreeViewNode toTreeViewNode(string label)
        {
            NASBTreeViewNode ret = this.toTreeViewNode();
            ret.Header = label + "_" + ret.Header;
            return ret;
        }

        public NASBTreeViewNode toTreeViewNode() {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "IdState: " + Id;
            ret.data.Add("Id", Id);
            ret.data.Add("Tags", String.Join("\n", Tags));
            ret.Items.Add(State.toTreeViewNode("State"));

            ret.baseobject = this;

            return ret;
        }
        public virtual Dictionary<string, Type> requisites()
        {
            throw new NotImplementedException();
        }
    }
}