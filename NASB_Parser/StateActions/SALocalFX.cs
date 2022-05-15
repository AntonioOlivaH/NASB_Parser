using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SALocalFX : StateAction
    {
        public LocalFXAction ActionType { get; set; }
        public string Id { get; set; }

        public SALocalFX()
        {
        }

        internal SALocalFX(BulkSerializeReader reader) : base(reader)
        {
            ActionType = (LocalFXAction)reader.ReadInt();
            Id = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(ActionType);
            writer.Write(Id);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SALocalFX";

            ret.data.Add("Id", Id);
            ret.data.Add("ActionType", Enum.GetName(typeof(LocalFXAction), ActionType));

            return ret;
        }

        public enum LocalFXAction
        {
            TurnOn,
            TurnOff,
            Restart,
            RestartAll,
            RestartAndOn,
            RestartAndOff
        }
    }
}