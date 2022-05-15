using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.CheckThings
{
    public class CTCheckTech : CheckThing
    {
        public string TechTimerId { get; set; }

        public CTCheckTech()
        {
        }

        internal CTCheckTech(BulkSerializeReader reader) : base(reader)
        {
            TechTimerId = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(TechTimerId);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "CTCheckTech";

            ret.data.Add("TechTimerId", TechTimerId.ToString());

            return ret;
        }
    }
}