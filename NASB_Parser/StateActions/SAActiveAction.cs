using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAActiveAction : StateAction
    {
        public StateAction Action { get; set; }
        public FloatSource FloatSource { get; set; }
        public string Id { get; set; }
        public Phases Phase { get; set; }

        public SAActiveAction()
        {
        }

        internal SAActiveAction(BulkSerializeReader reader) : base(reader)
        {
            Action = Read(reader);
            FloatSource = FloatSource.Read(reader);
            Id = reader.ReadString();
            Phase = (Phases)reader.ReadInt();
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAActiveAction";

            ret.data.Add("Id", Id);
            ret.data.Add("Phase", Enum.GetName(typeof(Phases), Phase));
            ret.Items.Add(Action.toTreeViewNode("Action"));
            ret.Items.Add(FloatSource.toTreeViewNode("FloatSource"));

            return ret;
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Action);
            writer.Write(FloatSource);
            writer.Write(Id);
            writer.Write(Phase);
        }

        public enum Phases
        {
            PreInputTrigger,
            PreStateUpd,
            PostStateUpd,
            PostAnimUpd
        }
    }
}