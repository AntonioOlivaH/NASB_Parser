using NASB_Parser.FloatSources;
using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.StateActions
{
    public class SASpawnAgent2 : StateAction
    {
        public string Bank { get; set; }
        public string Id { get; set; }
        public string Bone { get; set; }
        public Vector3 LocalOffset { get; set; }
        public Vector3 WorldOffset { get; set; }
        public bool CustomSpawnMovement { get; set; }
        public List<SpawnMovement> Movements { get; private set; } = new List<SpawnMovement>();
        public string SpawnedAgentDataId { get; set; }
        public FloatSource SpawnedAgentDataSetValue { get; set; }
        public FloatSource ResultOrderAdded { get; set; }
        public bool SetPlayerIndex { get; set; }
        public bool SetAttackTeam { get; set; }
        public bool SetDefendTeam { get; set; }
        public bool SetProjectileLevel { get; set; }
        public bool SetDirection { get; set; }
        public bool SetRedirect { get; set; }
        public FloatSource PlayerIndex { get; set; }
        public FloatSource AttackTeam { get; set; }
        public FloatSource DefendTeam { get; set; }
        public FloatSource ProjectileLevel { get; set; }
        public FloatSource Direction { get; set; }
        public FloatSource RedirectX { get; set; }
        public FloatSource RedirectY { get; set; }
        public bool ExactSpawn { get; set; }
        public List<AddedSpawnData> AddedSpawns { get; private set; } = new List<AddedSpawnData>();

        public SASpawnAgent2()
        {
        }

        internal SASpawnAgent2(BulkSerializeReader reader) : base(reader)
        {
            Bank = reader.ReadString();
            Id = reader.ReadString();
            Bone = reader.ReadString();
            LocalOffset = reader.ReadVector3();
            WorldOffset = reader.ReadVector3();
            CustomSpawnMovement = reader.ReadBool();
            Movements = reader.ReadList(r => new SpawnMovement(r));
            SpawnedAgentDataId = reader.ReadString();
            SpawnedAgentDataSetValue = FloatSource.Read(reader);
            ResultOrderAdded = FloatSource.Read(reader);
            byte dat = (byte)reader.ReadInt();
            SetPlayerIndex = BitUtil.GetBit(dat, 0);
            SetAttackTeam = BitUtil.GetBit(dat, 1);
            SetDefendTeam = BitUtil.GetBit(dat, 2);
            SetProjectileLevel = BitUtil.GetBit(dat, 3);
            SetDirection = BitUtil.GetBit(dat, 4);
            SetRedirect = BitUtil.GetBit(dat, 5);
            PlayerIndex = FloatSource.Read(reader);
            AttackTeam = FloatSource.Read(reader);
            DefendTeam = FloatSource.Read(reader);
            ProjectileLevel = FloatSource.Read(reader);
            Direction = FloatSource.Read(reader);
            RedirectX = FloatSource.Read(reader);
            RedirectY = FloatSource.Read(reader);
            if (Version > 0)
            {
                ExactSpawn = reader.ReadBool();
                if (Version > 1)
                {
                    AddedSpawns = reader.ReadList(r => new AddedSpawnData(r));
                }
            }
        }

        public override void Write(BulkSerializeWriter writer)
        {
            writer.Write(TID);
            writer.Write(2);
            writer.Write(Bank);
            writer.Write(Id);
            writer.Write(Bone);
            writer.Write(LocalOffset);
            writer.Write(WorldOffset);
            writer.Write(CustomSpawnMovement);
            writer.Write(Movements);
            writer.Write(SpawnedAgentDataId);
            writer.Write(SpawnedAgentDataSetValue);
            writer.Write(ResultOrderAdded);
            byte b = 0;
            b = BitUtil.SetBit(b, 0, SetPlayerIndex);
            b = BitUtil.SetBit(b, 1, SetAttackTeam);
            b = BitUtil.SetBit(b, 2, SetDefendTeam);
            b = BitUtil.SetBit(b, 3, SetProjectileLevel);
            b = BitUtil.SetBit(b, 4, SetDirection);
            b = BitUtil.SetBit(b, 5, SetRedirect);
            writer.Write(b);
            writer.Write(PlayerIndex);
            writer.Write(AttackTeam);
            writer.Write(DefendTeam);
            writer.Write(ProjectileLevel);
            writer.Write(Direction);
            writer.Write(RedirectX);
            writer.Write(RedirectY);
            writer.Write(ExactSpawn);
            writer.Write(AddedSpawns);
        }

        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "SASpawnAgent2";

            ret.data.Add("Bank", Bank);
            ret.data.Add("Id", Id);
            ret.data.Add("Bone", Bone);
            ret.data.Add("LocalOffset", LocalOffset.ToString());
            ret.data.Add("WorldOffset", WorldOffset.ToString());
            ret.data.Add("CustomSpawnMovement", CustomSpawnMovement.ToString());
            ret.data.Add("SpawnedAgentDataId", SpawnedAgentDataId);
            ret.data.Add("SetPlayerIndex", SetPlayerIndex.ToString());
            ret.data.Add("SetAttackTeam", SetAttackTeam.ToString());
            ret.data.Add("SetDefendTeam", SetDefendTeam.ToString());
            ret.data.Add("SetProjectileLevel", SetProjectileLevel.ToString());
            ret.data.Add("SetDirection", SetDirection.ToString());
            ret.data.Add("SetRedirect", SetRedirect.ToString());
            ret.data.Add("ExactSpawn", ExactSpawn.ToString());

            foreach (SpawnMovement s in Movements){
                ret.Items.Add(s.toTreeViewNode("Movements"));
            }

            ret.Items.Add(SpawnedAgentDataSetValue.toTreeViewNode("SpawnedAgentDataSetValue"));
            ret.Items.Add(ResultOrderAdded.toTreeViewNode("ResultOrderAdded"));
            ret.Items.Add(PlayerIndex.toTreeViewNode("PlayerIndex"));
            ret.Items.Add(AttackTeam.toTreeViewNode("AttackTeam"));
            ret.Items.Add(DefendTeam.toTreeViewNode("DefendTeam"));
            ret.Items.Add(ProjectileLevel.toTreeViewNode("ProjectileLevel"));
            ret.Items.Add(Direction.toTreeViewNode("Direction"));
            ret.Items.Add(RedirectX.toTreeViewNode("RedirectX"));
            ret.Items.Add(RedirectY.toTreeViewNode("RedirectY"));

            foreach (AddedSpawnData s in AddedSpawns) {
                ret.Items.Add(s.toTreeViewNode("AddedSpawns"));
            }

            return ret;
        }

        public struct AddedSpawnData : ISerializable, ITreeViewNode
        {
            public string SpawnedAgentDataId { get; set; }
            public FloatSource SpawnedAgentDataSetValue { get; set; }

            public AddedSpawnData(BulkSerializeReader reader)
            {
                SpawnedAgentDataId = reader.ReadString();
                SpawnedAgentDataSetValue = FloatSource.Read(reader);
            }

            public void Write(BulkSerializeWriter writer)
            {
                writer.Write(SpawnedAgentDataId);
                writer.Write(SpawnedAgentDataSetValue);
            }
            public NASBTreeViewNode toTreeViewNode(string label)
            {
                NASBTreeViewNode ret = this.toTreeViewNode();
                ret.Header = label + "_" + ret.Header;
                return ret;
            }
            public NASBTreeViewNode toTreeViewNode() {
                NASBTreeViewNode ret = new NASBTreeViewNode();
                ret.Header = "AddedSpawnData";

                ret.data.Add("SpawnedAgentDataId", SpawnedAgentDataId.ToString());

                ret.Items.Add(SpawnedAgentDataSetValue.toTreeViewNode("SpawnedAgentDataSetValue"));

                return ret;
            }
            public Dictionary<string, Type> requisites()
            {
                throw new NotImplementedException();
            }
        }

        private static class BitUtil
        {
            private static readonly uint[] ors = new uint[]
            {
                1,
                2,
                4,
                8,
                16,
                32,
                64,
                128
            };

            internal static bool GetBit(byte b, int bit)
            {
                return (b & ors[bit]) > 0;
            }

            internal static byte SetBit(byte b, int bit, bool val)
            {
                if (val)
                {
                    return (byte)(b | ors[bit]);
                }
                return (byte)(b & (255u ^ ors[bit]));
            }
        }
    }
}