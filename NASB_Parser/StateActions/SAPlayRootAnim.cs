using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAPlayRootAnim : StateAction
    {
        public string Anim { get; set; }
        public float Rate { get; set; }
        public bool SetRateOnly { get; set; }
        public float Frame { get; set; }
        public bool SetFrame { get; set; }

        public SAPlayRootAnim()
        {
        }

        internal SAPlayRootAnim(BulkSerializeReader reader) : base(reader)
        {
            Anim = reader.ReadString();
            Rate = reader.ReadFloat();
            SetRateOnly = reader.ReadBool();
            Frame = reader.ReadFloat();
            SetFrame = reader.ReadBool();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Anim);
            writer.Write(Rate);
            writer.Write(SetRateOnly);
            writer.Write(Frame);
            writer.Write(SetFrame);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAPlayRootAnim";

            ret.data.Add("Anim", Anim);
            ret.data.Add("Rate", Rate.ToString());
            ret.data.Add("SetRateOnly", SetRateOnly.ToString());
            ret.data.Add("Frame", Frame.ToString());
            ret.data.Add("SetFrame", SetFrame.ToString());

            return ret;
        }
    }
}