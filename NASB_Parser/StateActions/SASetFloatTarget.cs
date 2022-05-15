using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SASetFloatTarget : StateAction
    {
        public List<SetFloat> Sets { get; private set; } = new List<SetFloat>();

        public SASetFloatTarget()
        {
        }

        internal SASetFloatTarget(BulkSerializeReader reader) : base(reader)
        {
            Sets = reader.ReadList(r => new SetFloat(r));
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Sets);
        }

        public override NASBTreeViewNode toTreeViewNode() {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SASetFloatTarget";

            foreach (SetFloat s in Sets) {
                ret.Items.Add(s.toTreeViewNode("Sets"));
            }

            return ret;
        }

        public class SetFloat : ISerializable, ITreeViewNode
        {
            public FloatSource Target { get; set; }
            public FloatSource Source { get; set; }
            public ManipWay Way { get; set; }

            public SetFloat()
            {
            }

            internal SetFloat(BulkSerializeReader reader)
            {
                _ = reader.ReadInt();
                Target = FloatSource.Read(reader);
                Source = FloatSource.Read(reader);
                Way = (ManipWay)reader.ReadInt();
            }

            public void Write(BulkSerializeWriter writer)
            {
                writer.Write(0);
                writer.Write(Target);
                writer.Write(Source);
                writer.Write(Way);
            }
            public NASBTreeViewNode toTreeViewNode(string label)
            {
                NASBTreeViewNode ret = this.toTreeViewNode();
                ret.Header = label + "_" + ret.Header;
                return ret;
            }
            public NASBTreeViewNode toTreeViewNode() {
                NASBTreeViewNode ret = new NASBTreeViewNode();
                ret.Header = "SetFloat";

                ret.Items.Add(Target.toTreeViewNode("Target"));
                ret.Items.Add(Source.toTreeViewNode("Source"));

                ret.data.Add("Way", Enum.GetName(typeof(ManipWay), Way));

                return ret;
            }
            public virtual Dictionary<string, Type> requisites()
            {
                throw new NotImplementedException();
            }

            public enum ManipWay
            {
                Set,
                Add,
                Mult
            }
        }
    }
}