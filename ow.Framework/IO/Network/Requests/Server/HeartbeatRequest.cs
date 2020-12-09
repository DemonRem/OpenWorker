﻿using System.IO;
using ow.Framework.IO.Network.Attributes;

namespace ow.Framework.IO.Network.Requests.Server
{
    [Request]
    public readonly struct HeartbeatRequest
    {
        public ulong Tick { get; }
        private ulong Unknown1 { get; }
        private uint Unknown2 { get; }

        public HeartbeatRequest(BinaryReader br)
            => (Tick, Unknown1, Unknown2) = (br.ReadUInt64(), br.ReadUInt64(), br.ReadUInt32());
    }
}