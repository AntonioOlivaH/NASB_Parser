using NASB_Parser.StateActions;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.CheckThings
{
    public class LookForInput : ISerializable, ITreeViewNode
    {
        public int MatchMinFrames { get; set; }
        public InputValidator InputValidator { get; set; }

        public LookForInput()
        {
        }

        internal LookForInput(BulkSerializeReader reader)
        {
            _ = reader.ReadInt();
            MatchMinFrames = reader.ReadInt();
            InputValidator = new InputValidator(reader);
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(0);
            writer.Write(MatchMinFrames);
            writer.Write(InputValidator);
        }

        public NASBTreeViewNode toTreeViewNode(string label)
        {
            NASBTreeViewNode ret = this.toTreeViewNode();
            ret.Header = label + "_" + ret.Header;
            return ret;
        }

        public NASBTreeViewNode toTreeViewNode() {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "LookForInput";

            ret.data.Add("MatchMinFrames", MatchMinFrames.ToString());
            ret.Items.Add(InputValidator.toTreeViewNode("InputValidator"));

            return ret;
        }
        public virtual Dictionary<string, Type> requisites()
        {
            throw new NotImplementedException();
        }
    }
}