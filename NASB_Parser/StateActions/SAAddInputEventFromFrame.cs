using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAAddInputEventFromFrame : StateAction
    {
        public GIEV AddEvent { get; set; }

        public SAAddInputEventFromFrame()
        {
        }

        internal SAAddInputEventFromFrame(BulkSerializeReader reader) : base(reader)
        {
            AddEvent = (GIEV)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(AddEvent);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAAddInputEventFromFrame";

            ret.data.Add("AddEvent", Enum.GetName(typeof(GIEV), AddEvent));
            return ret;
        }
    }
}