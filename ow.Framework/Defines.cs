﻿namespace ow.Framework
{
    public static class Defines
    {
        public const byte MaxChannelSessions = 96;
        public const byte Channels = 32;
        public const byte FashionRows = 14;
        public const byte ClothesWithBoochesCount = 5;
        public const byte BoochesPerItem = 3;
        public const byte StatsPerItem = 5;
        public const byte PartyMembersCount = 4;
        public const byte SquadMembersCount = 8;
        public const byte QuickSlotsCount = 6;
        public const byte SkillsInSequenceQuickSlotsCount = 3;
        public const byte SkillsInQuickSlotsCount = QuickSlotsCount * SkillsInSequenceQuickSlotsCount;
        public const byte CharactersCount = 8;
        public const byte CharactersSlotsCount = 8;
        public const byte MinCharacterNameLength = 2;
        public const byte MaxCharacterNameLength = 12;

        public const byte CubeQuickSlotCount = 4;

        public const byte EquipableFashionStorageMaxCapacity = 14;
        public const byte EquipableGearStorageMaxCapacity = 10;

        internal const byte PacketHeaderSize = 7;
        internal const byte PacketEncryptedHeaderSize = 5;
    }
}