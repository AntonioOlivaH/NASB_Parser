using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.CheckThings
{
    public class CTGrabId : CheckThing
    {
        public CheckTypes CheckType { get; set; }

        public CTGrabId()
        {
        }

        internal CTGrabId(BulkSerializeReader reader) : base(reader)
        {
            CheckType = (CheckTypes)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(CheckType);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "CTGrabId";

            ret.data.Add("CheckType", Enum.GetName(typeof(CheckTypes), CheckType));

            return ret;
        }

        public enum CheckTypes
        {
            InGrab,
            IsGrabber,
            IsGrabbed,
            AllowedToEscape
        }
    }
}