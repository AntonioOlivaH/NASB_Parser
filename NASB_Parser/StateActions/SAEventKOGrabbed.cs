using System;
using System.Collections.Generic;
using System.Text;
using static NASB_Parser.StateActions.SAEventKO;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAEventKOGrabbed : StateAction
    {
        public KOType KO { get; set; }

        public SAEventKOGrabbed()
        {
        }

        internal SAEventKOGrabbed(BulkSerializeReader reader) : base(reader)
        {
            KO = (KOType)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(KO);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAEventKOGrabbed";

            ret.data.Add("KO", Enum.GetName(typeof(KOType), KO));

            return ret;
        }
    }
}