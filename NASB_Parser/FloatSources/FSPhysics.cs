using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.FloatSources
{
    public class FSPhysics : FloatSource
    {
        public PhysicsAttributes Attribute { get; set; }

        public FSPhysics()
        {
        }

        internal FSPhysics(BulkSerializeReader reader) : base(reader)
        {
            Attribute = (PhysicsAttributes)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Attribute);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "FSPhysics";
            ret.data.Add("Attribute", Enum.GetName(typeof(PhysicsAttributes), Attribute));

            return ret;
        }

        public enum PhysicsAttributes
        {
            Gravity
        }
    }
}