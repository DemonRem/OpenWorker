﻿using System;
using System.Collections.Generic;
using System.Xml;

namespace TrinigyVisionEngine.Vision.Runtime.EnginePlugins.Game.World.Batch.EventBox
{
    public sealed class VMonsterSpawnBox : VEntity
    {
        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<VMonster> Monsters { get; }

        /// <summary>
        /// Creation Position Type.
        /// </summary>
        public CreationPositionType CreationPositionType { get; }

        /// <summary>
        /// Move Type.
        /// </summary>
        public MoveType MoveType { get; }

        /// <summary>
        /// Condition of Creation.
        /// </summary>
        public CreationConditionType CreationCondition { get; }

        /// <summary>
        /// EffectFile.
        /// </summary>
        public string CreationEffectFile { get; }

        /// <summary>
        /// If Condition of Creation is 'WaitSignal', Determine whether the signal being generated in a few seconds.
        /// </summary>
        public float WaitCreationDelayTime { get; }

        /// <summary>
        /// If Condition of Creation is 'WaitSignal', Determines whether every few seconds sequentially generated.
        /// </summary>
        public float WaitCreationSequenceTime { get; }

        /// <summary>
        /// If Condition of Creation is 'WaitSignal', Not waiting for the signal to determine the maximum of times.
        /// </summary>
        public byte WaitCreationMaxWave { get; }

        /// <summary>
        /// The maximum number of objects that can be created. If Condition of Creation is 'WaitSignal', And let not exceed more than the maximum number of objects when creating objects.
        /// </summary>
        public byte MaxEntityCount { get; }

        /// <summary>
        /// Whether the spins in order from 1 to 3 monsters that spawn at a time set when you create a sequence generated.
        /// </summary>
        public WaitCreationSequenceType WaitCreationSequenceType { get; }

        /// <summary>
        /// Waypoint ID.
        /// </summary>
        public int Waypoint { get; }

        /// <summary>
        /// AggroGroupID.
        /// </summary>
        public ushort AggroGroup { get; }

        /// <summary>
        /// AggroDistance.
        /// </summary>
        public int AggroDistance { get; }

        /// <summary>
        /// AggroMaxCount.
        /// </summary>
        public ushort AggroMaxCount { get; }

        /// <summary>
        /// Multiplying the value of Sight.
        /// </summary>
        public float LookRatio { get; }

        /// <summary>
        /// View the sight will be displayed?
        /// </summary>
        public bool ShowSight { get; }

        /// <summary>
        /// ObjectKey
        /// </summary>
        public string ObjectKey { get; }

        /// <summary>
        /// Scene script call type.
        /// </summary>
        public ScriptType ScriptType { get; }

        /// <summary>
        /// if Scene script call type is HP, the event box being run. HP(100 = 100%).
        /// </summary>
        public IReadOnlyList<byte> CheckScriptHp { get; }

        /// <summary>
        /// ID of the associated sectors(auto editable)
        /// </summary>
        public ushort Sector { get; }

        /// <summary>
        /// Enter the name you used when creating the spawn action.
        /// </summary>
        public string ChangeSpawnAction { get; }

        /// <summary>
        /// Specifies the ID of the destination specified by the box spawn protected.
        /// </summary>
        public ushort ProtectionTarget { get; }

        /// <summary>
        /// Unit [ms] (Specifies whether to create a monster, who died after a few seconds. Value of 0 is not used for the responder.)
        /// </summary>
        public float RespawnTime { get; }

        /// <summary>
        /// Step index of monster spawn.
        /// </summary>
        public byte Step { get; }

        /// <summary>
        /// Monster Respawn Type.
        /// </summary>
        public RespawnType RespawnType { get; }

        /// <summary>
        /// Respawn Condition ID.
        /// </summary>
        public int RespawnCondition { get; }

        /// <summary>
        /// GroupID
        /// </summary>
        public int GroupId { get; }

        internal VMonsterSpawnBox(XmlNode xml) : base(xml)
        {
            Monsters = new List<VMonster>(10)
            {
                new VMonster(
                    int.Parse(xml.SelectSingleNode("m_iMonsterID1").Attributes.GetNamedItem("value").Value),
                    (MonsterSpawnType)Enum.Parse(typeof(MonsterSpawnType), xml.SelectSingleNode("m_eType1").Attributes.GetNamedItem("value").Value, true),
                    int.Parse(xml.SelectSingleNode("m_iChance1").Attributes.GetNamedItem("value").Value)),
                new VMonster(
                    int.Parse(xml.SelectSingleNode("m_iMonsterID2").Attributes.GetNamedItem("value").Value),
                    (MonsterSpawnType)Enum.Parse(typeof(MonsterSpawnType), xml.SelectSingleNode("m_eType2").Attributes.GetNamedItem("value").Value, true),
                    int.Parse(xml.SelectSingleNode("m_iChance2").Attributes.GetNamedItem("value").Value)),
                new VMonster(
                    int.Parse(xml.SelectSingleNode("m_iMonsterID3").Attributes.GetNamedItem("value").Value),
                    (MonsterSpawnType)Enum.Parse(typeof(MonsterSpawnType), xml.SelectSingleNode("m_eType3").Attributes.GetNamedItem("value").Value, true),
                    int.Parse(xml.SelectSingleNode("m_iChance3").Attributes.GetNamedItem("value").Value)),
                new VMonster(
                    int.Parse(xml.SelectSingleNode("m_iMonsterID4").Attributes.GetNamedItem("value").Value),
                    (MonsterSpawnType)Enum.Parse(typeof(MonsterSpawnType), xml.SelectSingleNode("m_eType4").Attributes.GetNamedItem("value").Value, true),
                    int.Parse(xml.SelectSingleNode("m_iChance4").Attributes.GetNamedItem("value").Value)),
                new VMonster(
                    int.Parse(xml.SelectSingleNode("m_iMonsterID5").Attributes.GetNamedItem("value").Value),
                    (MonsterSpawnType)Enum.Parse(typeof(MonsterSpawnType), xml.SelectSingleNode("m_eType5").Attributes.GetNamedItem("value").Value, true),
                    int.Parse(xml.SelectSingleNode("m_iChance5").Attributes.GetNamedItem("value").Value)),
                new VMonster(
                    int.Parse(xml.SelectSingleNode("m_iMonsterID6").Attributes.GetNamedItem("value").Value),
                    (MonsterSpawnType)Enum.Parse(typeof(MonsterSpawnType), xml.SelectSingleNode("m_eType6").Attributes.GetNamedItem("value").Value, true),
                    int.Parse(xml.SelectSingleNode("m_iChance6").Attributes.GetNamedItem("value").Value)),
                new VMonster(
                    int.Parse(xml.SelectSingleNode("m_iMonsterID7").Attributes.GetNamedItem("value").Value),
                    (MonsterSpawnType)Enum.Parse(typeof(MonsterSpawnType), xml.SelectSingleNode("m_eType7").Attributes.GetNamedItem("value").Value, true),
                    int.Parse(xml.SelectSingleNode("m_iChance7").Attributes.GetNamedItem("value").Value)),
                new VMonster(
                    int.Parse(xml.SelectSingleNode("m_iMonsterID8").Attributes.GetNamedItem("value").Value),
                    (MonsterSpawnType)Enum.Parse(typeof(MonsterSpawnType), xml.SelectSingleNode("m_eType8").Attributes.GetNamedItem("value").Value, true),
                    int.Parse(xml.SelectSingleNode("m_iChance8").Attributes.GetNamedItem("value").Value)),
                new VMonster(
                    int.Parse(xml.SelectSingleNode("m_iMonsterID9").Attributes.GetNamedItem("value").Value),
                    (MonsterSpawnType)Enum.Parse(typeof(MonsterSpawnType), xml.SelectSingleNode("m_eType9").Attributes.GetNamedItem("value").Value, true),
                    int.Parse(xml.SelectSingleNode("m_iChance9").Attributes.GetNamedItem("value").Value)),
                new VMonster(
                    int.Parse(xml.SelectSingleNode("m_iMonsterID10").Attributes.GetNamedItem("value").Value),
                    (MonsterSpawnType)Enum.Parse(typeof(MonsterSpawnType), xml.SelectSingleNode("m_eType10").Attributes.GetNamedItem("value").Value, true),
                    int.Parse(xml.SelectSingleNode("m_iChance10").Attributes.GetNamedItem("value").Value)),
            };
            CreationPositionType = (CreationPositionType)Enum.Parse(typeof(CreationPositionType), xml.SelectSingleNode("m_eCreationPositionType").Attributes.GetNamedItem("value").Value, true);
            MoveType = (MoveType)Enum.Parse(typeof(MoveType), xml.SelectSingleNode("m_eMoveType").Attributes.GetNamedItem("value").Value, true);
            CreationCondition = (CreationConditionType)Enum.Parse(typeof(CreationConditionType), xml.SelectSingleNode("m_eCreationCondition").Attributes.GetNamedItem("value").Value, true);
            CreationEffectFile = xml.SelectSingleNode("m_CreationEffectFile").Attributes.GetNamedItem("value").Value;
            WaitCreationDelayTime = float.Parse(xml.SelectSingleNode("m_fWaitCreationDelayTime").Attributes.GetNamedItem("value").Value);
            WaitCreationSequenceTime = float.Parse(xml.SelectSingleNode("m_fWaitCreationSequenceTime").Attributes.GetNamedItem("value").Value);
            WaitCreationMaxWave = byte.Parse(xml.SelectSingleNode("m_iWaitCreationMaxWave").Attributes.GetNamedItem("value").Value);
            MaxEntityCount = byte.Parse(xml.SelectSingleNode("m_iMaxEntityCount").Attributes.GetNamedItem("value").Value);
            WaitCreationSequenceType = (WaitCreationSequenceType)Enum.Parse(typeof(WaitCreationSequenceType), xml.SelectSingleNode("m_eWaitCreationSequenceType").Attributes.GetNamedItem("value").Value, true);
            Waypoint = int.Parse(xml.SelectSingleNode("m_iWaypoint").Attributes.GetNamedItem("value").Value);
            AggroGroup = ushort.Parse(xml.SelectSingleNode("m_iAggroGroupID").Attributes.GetNamedItem("value").Value);
            AggroDistance = int.Parse(xml.SelectSingleNode("m_iAggroDistance").Attributes.GetNamedItem("value").Value);
            AggroMaxCount = ushort.Parse(xml.SelectSingleNode("m_iAggroMaxCount").Attributes.GetNamedItem("value").Value);
            LookRatio = float.Parse(xml.SelectSingleNode("m_fLookRatio").Attributes.GetNamedItem("value").Value);
            ShowSight = bool.Parse(xml.SelectSingleNode("m_bShowSight").Attributes.GetNamedItem("value").Value);
            ObjectKey = xml.SelectSingleNode("m_szObjectKey").Attributes.GetNamedItem("value").Value;
            ScriptType = (ScriptType)Enum.Parse(typeof(ScriptType), xml.SelectSingleNode("m_eScriptType").Attributes.GetNamedItem("value").Value, true);
            CheckScriptHp = new List<byte>(5)
            {
                byte.Parse(xml.SelectSingleNode("m_iCheckScriptHP1").Attributes.GetNamedItem("value").Value),
                byte.Parse(xml.SelectSingleNode("m_iCheckScriptHP2").Attributes.GetNamedItem("value").Value),
                byte.Parse(xml.SelectSingleNode("m_iCheckScriptHP3").Attributes.GetNamedItem("value").Value),
                byte.Parse(xml.SelectSingleNode("m_iCheckScriptHP4").Attributes.GetNamedItem("value").Value),
                byte.Parse(xml.SelectSingleNode("m_iCheckScriptHP5").Attributes.GetNamedItem("value").Value),
            };

            Sector = ushort.Parse(xml.SelectSingleNode("m_iSectorID").Attributes.GetNamedItem("value").Value);
            ChangeSpawnAction = xml.SelectSingleNode("m_ChangeSpawnAction").Attributes.GetNamedItem("value").Value;
            ProtectionTarget = ushort.Parse(xml.SelectSingleNode("m_ProtectionTarget").Attributes.GetNamedItem("value").Value);
            RespawnTime = float.Parse(xml.SelectSingleNode("m_RespawnTime").Attributes.GetNamedItem("value").Value);
            Step = byte.Parse(xml.SelectSingleNode("m_iStep").Attributes.GetNamedItem("value").Value);
            RespawnType = (RespawnType)Enum.Parse(typeof(RespawnType), xml.SelectSingleNode("m_eRespawnType").Attributes.GetNamedItem("value").Value, true);
            RespawnCondition = int.Parse(xml.SelectSingleNode("m_iRespawnCondition").Attributes.GetNamedItem("value").Value);
            GroupId = int.Parse(xml.SelectSingleNode("m_iGroupID").Attributes.GetNamedItem("value").Value);
        }
    }
}
