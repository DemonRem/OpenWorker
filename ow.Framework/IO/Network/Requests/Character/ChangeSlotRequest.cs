﻿using System.IO;
using ow.Framework.IO.Network.Attributes;

namespace ow.Framework.IO.Network.Requests.Character
{
    [Request]
    public readonly struct ChangeSlotRequest
    {
        private readonly ulong _1;
        private readonly ulong _2;
        public byte FirstSlot { get; }
        public byte SecondSlot { get; }

        public ChangeSlotRequest(BinaryReader br)
        {
            _1 = br.ReadUInt64();
            _2 = br.ReadUInt64();
            FirstSlot = br.ReadByte();
            SecondSlot = br.ReadByte();
        }
    }
}