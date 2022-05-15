using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.FloatSources
{
    public class FSInput : FloatSource
    {
        public CheckInput Input { get; set; }

        public FSInput()
        {
        }

        internal FSInput(BulkSerializeReader reader) : base(reader)
        {
            Input = (CheckInput)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Input);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "FSInput";
            ret.data.Add("CheckInput", Enum.GetName(typeof(CheckInput), Input));

            return ret;
        }

        public enum CheckInput
        {
            CtrlX,
            CtrlXRaw,
            CtrlY,
            Attack,
            Strong,
            Special,
            Jump,
            Defend,
            Fun,
            Grabmacro
        }
    }
}