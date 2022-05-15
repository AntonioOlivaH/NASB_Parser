using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.CheckThings
{
    public class CTDoubleTapId : CheckThing
    {
        public SimpleControlDir TapDir { get; set; }
        public int Window { get; set; }

        public CTDoubleTapId()
        {
        }

        internal CTDoubleTapId(BulkSerializeReader reader) : base(reader)
        {
            TapDir = (SimpleControlDir)reader.ReadInt();
            Window = reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(TapDir);
            writer.Write(Window);
        }

        public enum SimpleControlDir
        {
            Neutral,
            Right,
            Left,
            Up,
            Down,
            Forward,
            Backward
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "CTCompareFloat";

            ret.data.Add("TapDir", Enum.GetName(typeof(SimpleControlDir), TapDir));
            ret.data.Add("Window", Window.ToString());

            return ret;
        }
    }
}