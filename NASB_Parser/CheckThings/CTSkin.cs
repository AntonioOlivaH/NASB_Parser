﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.CheckThings
{
    public class CTSkin : CheckThing
    {
        public string MatchSkin { get; set; }
        public bool MatchColor { get; set; }
        public int MatchAgainstColor { get; set; }

        public CTSkin()
        {
        }

        internal CTSkin(BulkSerializer reader) : base(reader)
        {
            MatchSkin = reader.ReadString();
            MatchColor = reader.ReadBool();
            MatchAgainstColor = reader.ReadInt();
        }
    }
}