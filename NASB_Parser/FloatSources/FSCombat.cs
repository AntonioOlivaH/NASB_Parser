using System;
using System.Collections.Generic;
using System.Text;
using NASB_Parser.WFPControl;

namespace NASB_Parser.FloatSources
{
    public class FSCombat : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSCombat()
        {
        }

        internal FSCombat(BulkSerializeReader reader) : base(reader)
        {
            Attribute = (Attributes)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Attribute);
        }
        public override NASBTreeViewNode toTreeViewNode()
        {
            NASBTreeViewNode ret = new NASBTreeViewNode();
            ret.Header = "FSCombat";

            ret.data.Add("Attribute", Enum.GetName(typeof(Attributes), Attribute));
            return ret;
        }
        public enum Attributes
        {
            Weight,
            Getgrabbed,
            Grabinvulnerability,
            BlockPush,
            BlockHoldVertical = 8,
            BlockHoldHorizontal,
            CheckBlastzones = 14,
            CheckTopBlastzone,
            AlwaysLaunch = 24,
            PreventHitstunTurn = 28,
            PreventLaunches,
            DamageTaken = 4,
            InvincibleBoonFrames,
            RespawnInvincibleFrames,
            IsProjectile = 25,
            Projectilelevel = 7,
            LastDIType = 10,
            LastDIIn,
            LastDIOut,
            LastBlastzone,
            LastTurn = 16,
            LastRedirectX,
            LastRedirectY,
            LaunchedByPlayerIndex,
            LaunchedByTeam,
            LaunchedByGameTeam = 26,
            LastHitType = 21,
            LastHitDirection,
            LastHitForceJabReset = 27,
            LastHitForward = 23,
			chainCount = 30,
			comboCount = 31,
			altLaunch = 32,
			directionX = 33,
			directionY = 34,
			distanceTotal = 35,
			distanceX = 36,
			distanceY = 37,
			travelTotal = 38,
			travelX = 39,
			travelY = 40,
			travelAbsoluteTotal = 41,
			travelAbsoluteX = 42,
			travelAbsoluteY = 43,
			launchRate = 44,
			launchVelocityX = 45,
			launchVelocityY = 46,
			launchVelocityTrueX = 47,
			launchVelocityTrueY = 48,
			launchLastFrameX = 50,
			launchLastFrameY = 51,
			travelAngle = 49,
			lastAttackType = 52,
			lastAttackDamageBase = 53,
			lastAttackDamageMult = 54,
			lastAttackKnockbackMult = 55,
			lastAttackDamageTotal = 56,
			lastAttackAngle = 57,
			lastAttackDirection = 58,
			lastAttackDiType = 59,
			lastAttackDiIn = 60,
			lastAttackDiOut = 61,
			lastAttackReversible = 62,
			lastAttackKnockbackType = 63,
			lastAttackKnockbackBase = 64,
			lastAttackKnockbackGain = 65,
			lastAttackExtraKbAboveKb = 66,
			lastAttackExtraKbMult = 67,
			lastAttackStunCalc = 68,
			lastAttackStunBase = 69,
			lastAttackStunGain = 70,
			lastAttackHitOpponent = 71,
			lastAttackInteractDirection = 72,
			lastAttackBlockstun = 73,
			lastAttackBlockpush = 74,
			lastAttackBlocklag = 75,
			lastAttackHitlag = 76,
			lastAttackHitlagSelf = 77,
			lastAttackLauncher = 78,
			lastAttackLaunchAboveKb = 79,
			lastAttackLaunchArmorLevel = 80,
			lastAttackForceJabReset = 81,
			lastAttackGrablevel = 82,
			lastAttackGrabtype = 83,
			lastAttackKillshot = 84,
			lastAttackDirectionalfx = 85,
			lastAttackUnblockable = 86,
			lastAttackPierceinvincible = 87,
			lastAttackUninterruptible = 88,
			lastAttackAerial = 89
		}
    }
}