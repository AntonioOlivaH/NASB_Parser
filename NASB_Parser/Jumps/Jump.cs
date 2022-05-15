using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.Jumps
{
    public class Jump : ISerializable, ITreeViewNode
    {
        public TypeId TID { get; private set; }
        public int Version { get; private set; }

        public Jump()
        {
        }

        internal Jump(BulkSerializeReader reader)
        {
            TID = (TypeId)reader.ReadInt();
            Version = reader.ReadInt();
        }

        public virtual void Write(BulkSerializeWriter writer)
        {
            writer.Write(TID);
            writer.Write(Version);
        }

        internal static Jump Read(BulkSerializeReader reader)
        {
            return (TypeId)reader.PeekInt() switch
            {
                TypeId.HeightId => new HeightJump(reader),
                TypeId.HoldId => new HoldJump(reader),
                TypeId.AirdashId => new AirDashJump(reader),
                TypeId.KnockbackId => new KnockbackJump(reader),
                TypeId.DelayedId => new DelayedJump(reader),
                TypeId.ClampMomentumId => new ClampMomentumJump(reader),
                TypeId.BaseIdentifier => new Jump(reader),
                // This is more aggressive than the game parser for better error detection.
                _ => throw new ReadException(reader, $"Could not parse valid {nameof(Jump)} type from: {reader.PeekInt()}!"),
            };
        }

        public NASBTreeViewNode toTreeViewNode(string label)
        {
            NASBTreeViewNode ret = this.toTreeViewNode();
            ret.Header = label + "_" + ret.Header;
            return ret;
        }

        public virtual NASBTreeViewNode toTreeViewNode()
        {
            throw new NotImplementedException();
        }
        public virtual Dictionary<string, Type> requisites()
        {
            throw new NotImplementedException();
        }

        public enum TypeId
        {
            BaseIdentifier,
            HeightId,
            HoldId,
            AirdashId,
            KnockbackId,
            DelayedId,
            ClampMomentumId
        }
    }
}