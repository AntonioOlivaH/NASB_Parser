using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAOnHit : StateAction
    {
        public bool Hitbox { get; set; }
        public int Box { get; set; }
        public StateAction Action { get; set; }

        public SAOnHit()
        {
        }

        internal SAOnHit(BulkSerializeReader reader) : base(reader)
        {
            Hitbox = reader.ReadBool();
            Box = reader.ReadInt();
            Action = Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Hitbox);
            writer.Write(Box);
            writer.Write(Action);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAOnHit";

            ret.data.Add("Hitbox", Hitbox.ToString());
            ret.data.Add("Box", Box.ToString());
            ret.Items.Add(Action.toTreeViewNode("Action"));

            return ret;
        }
    }
}