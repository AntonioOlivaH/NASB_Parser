using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAManageAirJump : StateAction
    {
        public ManageType Manage { get; set; }

        public SAManageAirJump()
        {
        }

        internal SAManageAirJump(BulkSerializeReader reader) : base(reader)
        {
            Manage = (ManageType)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Manage);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAManageAirJump";

            ret.data.Add("Manage", Enum.GetName(typeof(ManageType), Manage));

            return ret;
        }

        public enum ManageType
        {
            ExpendAirJump,
            ResetAirJumps,
            ExpendAirDash,
            ResetAirDashes
        }
    }
}