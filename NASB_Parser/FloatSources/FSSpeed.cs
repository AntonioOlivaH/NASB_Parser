using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.FloatSources
{
    public class FSSpeed : FloatSource
    {
        public FSSpeedType SpeedType { get; set; }

        public FSSpeed()
        {
        }

        internal FSSpeed(BulkSerializeReader reader) : base(reader)
        {
            SpeedType = (FSSpeedType)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(SpeedType);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "FSSpeed";
            ret.data.Add("SpeedType", Enum.GetName(typeof(FSSpeedType), SpeedType));

            return ret;
        }

        public enum FSSpeedType
        {
            GameSpeed,
            StateDT,
            MovementDT,
            StateDTF,
            MovementDTF,
            GameSeconds
        }
    }
}