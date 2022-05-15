﻿using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAAlterMoveDT : StateAction
    {
        public bool ClearAMDT { get; set; }
        public FloatSource After { get; set; }
        public FloatSource Falloff { get; set; }

        public SAAlterMoveDT()
        {
        }

        internal SAAlterMoveDT(BulkSerializeReader reader) : base(reader)
        {
            ClearAMDT = reader.ReadBool();
            After = FloatSource.Read(reader);
            Falloff = FloatSource.Read(reader);
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(ClearAMDT);
            writer.Write(After);
            writer.Write(Falloff);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAAlterMoveVel";

            ret.data.Add("ClearAMDT", ClearAMDT.ToString());
            ret.Items.Add(After.toTreeViewNode("After"));
            ret.Items.Add(Falloff.toTreeViewNode("Falloff"));

            return ret;
        }
    }
}