using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.ObjectSources;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAGUAMessageObject : ISerializable, ITreeViewNode
    {
        public string PlainMessage { get; set; }
        public List<MessageDynamic> Dynamics { get; private set; } = new List<MessageDynamic>();

        public SAGUAMessageObject()
        {
        }

        internal SAGUAMessageObject(BulkSerializeReader reader)
        {
            _ = reader.ReadInt();
            PlainMessage = reader.ReadString();
            Dynamics = reader.ReadList(r => new MessageDynamic(r));
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(0);
            writer.Write(PlainMessage);
            writer.Write(Dynamics);
        }
        public NASBTreeViewNode toTreeViewNode(string label)
        {
            NASBTreeViewNode ret = this.toTreeViewNode();
            ret.Header = label + "_" + ret.Header;
            return ret;
        }
        public NASBTreeViewNode toTreeViewNode() {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            NASBTreeViewNode aux;
            ret.Header = "SAGUAMessageObject";

            ret.data.Add("PlainMessage", PlainMessage);

            foreach (MessageDynamic s in Dynamics) {
                aux = s.toTreeViewNode();
                aux.Header += "_Dynamics";
                ret.Items.Add(aux);
            }

            return ret;
        }
        public virtual Dictionary<string, Type> requisites()
        {
            throw new NotImplementedException();
        }

        public class MessageDynamic : ISerializable, ITreeViewNode
        {
            public string Id { get; set; }
            public ObjectSource ObjectSource { get; set; }

            public MessageDynamic()
            {
            }

            internal MessageDynamic(BulkSerializeReader reader)
            {
                _ = reader.ReadInt();
                Id = reader.ReadString();
                ObjectSource = ObjectSource.Read(reader);
            }

            public void Write(BulkSerializeWriter writer)
            {
                writer.Write(0);
                writer.Write(Id);
                writer.Write(ObjectSource);
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
                ret.Header = "MessageDynamic";

                ret.data.Add("Id", Id);

                NASBTreeViewNode aux = ObjectSource.toTreeViewNode();
                aux.Header += "_ObjectSource";

                return ret;
            }
            public virtual Dictionary<string, Type> requisites()
            {
                throw new NotImplementedException();
            }
        }
    }
}