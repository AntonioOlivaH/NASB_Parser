﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatStates
{
    public class FSCpuHelp : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSCpuHelp()
        {
        }

        internal FSCpuHelp(BulkSerializer reader)
        {
            _ = reader.ReadInt();
            _ = reader.ReadInt();
            Attribute = (Attributes)reader.ReadInt();
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