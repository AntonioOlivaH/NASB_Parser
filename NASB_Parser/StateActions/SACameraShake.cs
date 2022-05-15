using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SACameraShake : StateAction
    {
        public float Shake { get; set; }
        public float Intensity { get; set; } = 1;

        public SACameraShake()
        {
        }

        internal SACameraShake(BulkSerializeReader reader) : base(reader)
        {
            Shake = reader.ReadFloat();
            if (Version != 0)
            {
                Intensity = reader.ReadFloat();
            }
        }

        public override void Write(BulkSerializeWriter writer)
        {
            writer.Write(TID);
            writer.Write(1);
            writer.Write(Shake);
            writer.Write(Intensity);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SACameraShake";

            ret.data.Add("Shake", Shake.ToString());
            ret.data.Add("Intensity", Intensity.ToString());

            return ret;
        }
    }
}