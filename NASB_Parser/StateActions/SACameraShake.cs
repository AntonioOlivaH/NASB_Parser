﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SACameraShake : StateAction
    {
        public float Shake { get; set; }
        public float Intensity { get; set; } = 1;

        public SACameraShake()
        {
        }

        internal SACameraShake(BulkSerializer reader) : base(reader)
        {
            Shake = reader.ReadFloat();
            if (Version != 0)
            {
                Intensity = reader.ReadFloat();
            }
        }
    }
}