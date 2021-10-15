﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAOrderedSensitive : StateAction
    {
        public List<StateAction> Actions { get; } = new List<StateAction>();

        public SAOrderedSensitive()
        {
        }

        internal SAOrderedSensitive(BulkSerializer reader) : base(reader)
        {
            Actions = reader.ReadList(r => Read(r));
        }
    }
}