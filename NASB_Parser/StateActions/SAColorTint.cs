using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAColorTint : StateAction
    {
        public string Id { get; set; }
        public bool Activate { get; set; }
        public bool Permanent { get; set; }
        public FloatSource RunForTime { get; set; }

        public SAColorTint()
        {
        }

        internal SAColorTint(BulkSerializeReader reader) : base(reader)
        {
            Id = reader.ReadString();
            Activate = reader.ReadBool();
            Permanent = reader.ReadBool();
            RunForTime = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Id);
            writer.Write(Activate);
            writer.Write(Permanent);
            writer.Write(RunForTime);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAColorTint";

            ret.data.Add("Id", Id);
            ret.data.Add("Activate", Activate.ToString());
            ret.data.Add("Permanent", Permanent.ToString());

            ret.Items.Add(RunForTime.toTreeViewNode("RunForTime"));

            return ret;
        }
    }
}