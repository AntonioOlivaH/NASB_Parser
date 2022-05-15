using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class MovementConfig : ISerializable, ITreeViewNode
    {
        public bool GetParented { get; set; }
        public bool LeaveEdges { get; set; }
        public bool PassThrough { get; set; }
        public bool FallThrough { get; set; }
        public bool IgnoreMovingStage { get; set; }
        public bool Bounce { get; set; }
        public bool Stop { get; set; }
        public bool LeaveParent { get; set; }
        public StageLayer IgnoreStageLayer { get; set; }
        public float InheritParentVel { get; set; }
        public float LeaveEdgeRestrict { get; set; }
        public bool SimpleFreeMovement { get; set; }
        public float SimpleRadius { get; set; }

        public MovementConfig()
        {
        }

        internal MovementConfig(BulkSerializeReader reader)
        {
            bool hasSimple = reader.ReadBool();
            GetParented = reader.ReadBool();
            LeaveEdges = reader.ReadBool();
            PassThrough = reader.ReadBool();
            FallThrough = reader.ReadBool();
            IgnoreMovingStage = reader.ReadBool();
            Bounce = reader.ReadBool();
            Stop = reader.ReadBool();
            LeaveParent = reader.ReadBool();
            IgnoreStageLayer = (StageLayer)reader.ReadInt();
            InheritParentVel = reader.ReadFloat();
            LeaveEdgeRestrict = reader.ReadFloat();
            if (hasSimple)
            {
                SimpleFreeMovement = reader.ReadBool();
                SimpleRadius = reader.ReadFloat();
            }
        }

        public void Write(BulkSerializeWriter writer)
        {
            writer.Write(1);
            writer.Write(GetParented);
            writer.Write(LeaveEdges);
            writer.Write(PassThrough);
            writer.Write(FallThrough);
            writer.Write(IgnoreMovingStage);
            writer.Write(Bounce);
            writer.Write(Stop);
            writer.Write(LeaveParent);
            writer.Write(IgnoreStageLayer);
            writer.Write(InheritParentVel);
            writer.Write(LeaveEdgeRestrict);
            writer.Write(SimpleFreeMovement);
            writer.Write(SimpleRadius);
        }

        public NASBTreeViewNode toTreeViewNode(string label)
        {
            NASBTreeViewNode ret = this.toTreeViewNode();
            ret.Header = label + "_" + ret.Header;
            return ret;
        }
        public NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "MovementConfig";

            ret.data.Add("GetParented", GetParented.ToString());
            ret.data.Add("LeaveEdges", LeaveEdges.ToString());
            ret.data.Add("PassThrough", PassThrough.ToString());
            ret.data.Add("FallThrough", FallThrough.ToString());
            ret.data.Add("IgnoreMovingStage", IgnoreMovingStage.ToString());
            ret.data.Add("Bounce", Bounce.ToString());
            ret.data.Add("Stop", Stop.ToString());
            ret.data.Add("LeaveParent", LeaveParent.ToString());
            ret.data.Add("IgnoreMovingStage", IgnoreMovingStage.ToString());
            ret.data.Add("IgnoreStageLayer", Enum.GetName(typeof(StageLayer), IgnoreStageLayer));
            ret.data.Add("InheritParentVel", IgnoreMovingStage.ToString());
            ret.data.Add("LeaveEdgeRestrict", LeaveEdgeRestrict.ToString());
            ret.data.Add("SimpleFreeMovement", SimpleFreeMovement.ToString());
            ret.data.Add("SimpleRadius", SimpleRadius.ToString());
        
            return ret;
        }
        public virtual Dictionary<string, Type> requisites()
        {
            throw new NotImplementedException();
        }

        public enum StageLayer
        {
            General,
            IgnoreProjectiles,
            None
        }
    }
}