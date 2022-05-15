using NASB_Parser.CheckThings;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SACheckThing : StateAction
    {
        public CheckThing CheckThing { get; set; }
        public StateAction Action { get; set; }
        public bool Else { get; set; }
        public StateAction ElseAction { get; set; }

        public SACheckThing()
        {
        }

        internal SACheckThing(BulkSerializeReader reader) : base(reader)
        {
            CheckThing = CheckThing.Read(reader);
            Action = Read(reader);
            Else = reader.ReadBool();
            ElseAction = Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(CheckThing);
            writer.Write(Action);
            writer.Write(Else);
            writer.Write(ElseAction);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SACheckThing";

            ret.data.Add("Else", Else.ToString());

            ret.Items.Add(CheckThing.toTreeViewNode("CheckThing"));
            ret.Items.Add(Action.toTreeViewNode("Action"));
            ret.Items.Add(ElseAction.toTreeViewNode("ElseAction"));

            return ret;
        }
    }
}