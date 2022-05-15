using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.FloatSources
{
    public class FSCollision : FloatSource
    {
        public CollisionAttributes Attribute { get; set; }

        public FSCollision()
        {
        }

        internal FSCollision(BulkSerializeReader reader) : base(reader)
        {
            Attribute = (CollisionAttributes)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Attribute);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "FSCollision";

            ret.data.Add("Attribute", Enum.GetName(typeof(CollisionAttributes), Attribute));
            return ret;
        }

        public enum CollisionAttributes
        {
            TouchBottom,
            TouchTop,
            TouchLeft,
            TouchRight,
            ParentOrderAdded
        }
    }
}