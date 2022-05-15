using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SAProxyMove : StateAction
    {
        public string MoveId { get; set; }

        public SAProxyMove()
        {
        }

        internal SAProxyMove(BulkSerializeReader reader) : base(reader)
        {
            MoveId = reader.ReadString();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(MoveId);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SAProxyMove";

            ret.data.Add("MoveId", MoveId);

            ret.baseobject = this;

            return ret;
        }

        public override Dictionary<string, Type> requisites() {
            return new Dictionary<string, Type> { { "MoveId", typeof(string) } };
        }

        public override StateAction GenerateFromRequisites(Dictionary<string, object> input) {
            if (!input.TryGetValue("MoveId", out object data)){
                return null;
            }

            if (data is string) {
                this.MoveId = (string)data;
                return this;
            }

            return null;
        }
    }
}