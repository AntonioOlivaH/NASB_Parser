using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.FloatSources
{
    public class FSCpuHelp : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSCpuHelp()
        {
        }

        internal FSCpuHelp(BulkSerializeReader reader) : base(reader)
        {
            Attribute = (Attributes)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Attribute);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "FSCpuHelp";

            ret.data.Add("Attribute", Enum.GetName(typeof(Attributes), Attribute));
            return ret;
        }

        public enum Attributes
        {
            AntiMixup,
            AntiHang,
            AntiBlock,
            AntiDown,
            AntiVulnerable,
            AntiStun,
            QuirkOpportunity,
            Dead,
            Helpless = 14,
            Launched,
            DoingAttack = 8,
            DoingStrongAttack,
            DoingSpecialAttack,
            DoingAttackUp,
            DoingAttackMid,
            DoingAttackDown
        }
    }
}