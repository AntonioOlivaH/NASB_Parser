using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.FloatSources
{
    public class FSEffects : FloatSource
    {
        public string LocalFxId { get; set; }
        public ManipAspect Masp { get; set; }

        public FSEffects()
        {
        }

        internal FSEffects(BulkSerializeReader reader) : base(reader)
        {
            LocalFxId = reader.ReadString();
            Masp = (ManipAspect)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(LocalFxId);
            writer.Write(Masp);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "FSEffects";
            ret.data.Add("LocalFxId", LocalFxId);
            ret.data.Add("Masp", Enum.GetName(typeof(ManipAspect), Masp));
            return ret;
        }
        public enum ManipAspect
        {
            TimeElapsed,
            Length,
            AddToElapsed
        }
    }
}