using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAEventKO : StateAction
    {
        public KOType KO { get; set; }

        public SAEventKO()
        {
        }

        internal SAEventKO(BulkSerializeReader reader) : base(reader)
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
            ret.Header = "SAEventKO";

            ret.data.Add("KO", Enum.GetName(typeof(KOType), KO));

            return ret;
        }

        public enum KOType
        {
            Top,
            Left,
            Right,
            Bottom,
            Box,
            Enemy,
            Grabbed,
            Critical
        }
    }
}