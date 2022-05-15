using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.CheckThings
{
    public class CheckThing : ISerializable, ITreeViewNode
    {
        public TypeId TID { get; private set; }
        public int Version { get; private set; }

        public CheckThing()
        {
        }

        internal CheckThing(BulkSerializeReader reader)
        {
            TID = (TypeId)reader.ReadInt();
            Version = reader.ReadInt();
        }

        public virtual void Write(BulkSerializeWriter writer)
        {
            writer.Write(TID);
            writer.Write(Version);
        }

        public static CheckThing Read(BulkSerializeReader reader)
        {
            return (TypeId)reader.PeekInt() switch
            {
                TypeId.MultipleId => new CTMultiple(reader),
                TypeId.CompareId => new CTCompareFloat(reader),
                TypeId.DoubleTapId => new CTDoubleTapId(reader),
                TypeId.InputId => new CTInput(reader),
                TypeId.InputSeriesId => new CTInputSeries(reader),
                TypeId.TechId => new CTCheckTech(reader),
                TypeId.GrabId => new CTGrabId(reader),
                TypeId.GrabAgentId => new CTGrabbedAgent(reader),
                TypeId.SkinId => new CTSkin(reader),
                TypeId.MoveId => new CTMove(reader),
                TypeId.BaseIdentifier => new CheckThing(reader),
                _ => throw new ReadException(reader, $"Could not parse valid {nameof(CheckThing)} type from: {reader.PeekInt()}!"),
            };
        }
        public virtual NASBTreeViewNode toTreeViewNode()
        {
            throw new NotImplementedException();
        }

        public NASBTreeViewNode toTreeViewNode(string label)
        {
            NASBTreeViewNode ret = this.toTreeViewNode();
            ret.Header = label + "_" + ret.Header;
            return ret;
        }
        public virtual Dictionary<string, Type> requisites()
        {
            throw new NotImplementedException();
        }

        public enum TypeId
        {
            BaseIdentifier,
            MultipleId,
            CompareId,
            DoubleTapId,
            InputId,
            InputSeriesId,
            TechId,
            GrabId,
            GrabAgentId,
            SkinId,
            MoveId
        }

        public enum CheckWay
        {
            Equal,
            NotEqual,
            Less,
            Larger,
            EOLess,
            EOLarger
        }
    }
}