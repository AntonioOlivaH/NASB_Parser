using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SATimedAction : StateAction
    {
        public FloatSource Source { get; set; }
        public bool Repeat { get; set; }
        public StateAction Action { get; set; }

        public SATimedAction()
        {
        }

        internal SATimedAction(BulkSerializeReader reader) : base(reader)
        {
            Source = FloatSource.Read(reader);
            Repeat = reader.ReadBool();
            Action = Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Source);
            writer.Write(Repeat);
            writer.Write(Action);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SATimedAction";

            ret.data.Add("Repeat", Repeat.ToString());
            ret.Items.Add(Source.toTreeViewNode("Source"));
            ret.Items.Add(Action.toTreeViewNode("Action"));

            return ret;
        }
    }
}