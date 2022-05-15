using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SASetAttackProp : StateAction
    {
        public int Hitbox { get; set; }
        public string Prop { get; set; }

        public SASetAttackProp()
        {
        }

        internal SASetAttackProp(BulkSerializeReader reader) : base(reader)
        {
            Hitbox = reader.ReadInt();
            Prop = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Hitbox);
            writer.Write(Prop);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SASetFloatTarget";

            ret.data.Add("Hitbox", Hitbox.ToString());
            ret.data.Add("Prop", Prop);

            return ret;
        }
    }
}