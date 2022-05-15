using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAPlayAnim : StateAction
    {
        public bool FromStart { get; set; }
        public string Anim { get; set; }
        public AnimConfig Cfg { get; set; }

        public SAPlayAnim()
        {
        }

        internal SAPlayAnim(BulkSerializeReader reader) : base(reader)
        {
            FromStart = reader.ReadBool();
            Anim = reader.ReadString();
            Cfg = new AnimConfig(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(FromStart);
            writer.Write(Anim);
            writer.Write(Cfg);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAPlayAnim";

            ret.data.Add("FromStart", FromStart.ToString());
            ret.data.Add("Anim", Anim);

            ret.Items.Add(Cfg.toTreeViewNode("Cfg"));

            return ret;
        }
    }
}