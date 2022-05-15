﻿using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.FloatSources
{
    public class FSOnHit : FloatSource
    {
        public OnHitParam Param { get; set; }

        public FSOnHit()
        {
        }

        internal FSOnHit(BulkSerializeReader reader) : base(reader)
        {
            Param = (OnHitParam)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Param);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "FSOnHit";
            ret.data.Add("OnHitParam", Enum.GetName(typeof(OnHitParam), Param));

            return ret;
        }

        public enum OnHitParam
        {
            Hitpos_x,
            Hitpos_y,
            Hitpos_z,
            Hitwasinvincible,
            Hitwasblock,
            Hitwellblocked = 6,
            Hitperfectblocked,
            Hurtdamage = 5,
            Hurtknockback = 12,
            Hitdamage = 9,
            Hurtwellblocked = 11,
            Hurtperfectblocked = 8,
            Hurtattacktype = 10
        }
    }
}