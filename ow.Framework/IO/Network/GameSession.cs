﻿using Microsoft.Extensions.Logging;
using NetCoreServer;
using ow.Framework.Game;
using ow.Framework.Game.Enums;
using ow.Framework.IO.Network.Opcodes;
using ow.Framework.IO.Network.Providers;
using ow.Framework.IO.Network.Requests;
using ow.Framework.IO.Network.Responses;
using ow.Framework.IO.Network.Responses.Shared;
using ow.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ow.Framework.IO.Network
{
    public abstract partial class GameSession : TcpSession
    {
        #region Send Characters

        public GameSession SendCharacterDbLoadSync() =>
            SendAsync(ClientOpcode.CharacterDbLoadSync, (PacketWriter writer) =>
            {
            });

        public GameSession SendAsync(CharacterToggleWeaponRequest request) =>
            SendAsync(ClientOpcode.CharacterToggleWeapon, (PacketWriter writer) =>
            {
                writer.Write(request.CharacterId);
                writer.WriteVector3(request.Position);
                writer.Write(request.Rotation);
                writer.Write(request.Toggle);
                writer.Write(request.Unknown1);
            });

        public GameSession SendAsync(NpcOthersInfosResponse value) =>
            SendAsync(ClientOpcode.NpcOtherInfos, (PacketWriter writer) =>
            {
                writer.Write((ushort)value.Values.Count);
                foreach (NpcOthersInfosResponse.Entity entity in value.Values)
                {
                    writer.Write(entity.Id);
                    writer.WriteVector3(entity.Position);
                    writer.Write(entity.Rotation);
                    writer.Write(uint.MinValue);
                    writer.Write(entity.Waypoint);
                    writer.Write(uint.MinValue);
                    writer.WriteNpcVisability(NpcVisablity.Visible);
                    writer.Write(entity.NpcId);
                }
            });

        public GameSession SendCharacterInfo() =>
            SendAsync(ClientOpcode.CharacterInfo, (PacketWriter writer) =>
            {
            });

        public GameSession SendAsync(CharacterStatsUpdateResponse value) =>
            SendAsync(ClientOpcode.CharacterStatsUpdate, ((PacketWriter writer) =>
            {
                writer.Write((byte)0);

                writer.Write(value.Character);
                writer.Write((byte)value.Values.Count);

                foreach (CharacterStatsUpdateResponse.Entity stat in value.Values)
                {
                    writer.Write(stat.Value);
                    writer.WriteCharacterStat(stat.Id);
                }
            }));

        public GameSession SendAsync(CharacterProfileResponse value) =>
            SendAsync(ClientOpcode.CharacterProfileInfo, (PacketWriter writer) =>
            {
                writer.WriteProfileStatus(value.Status);
                writer.WriteByteLengthUnicodeString(value.About);
                writer.WriteByteLengthUnicodeString(value.Note);
            });

        public GameSession SendAsync(GestureLoadResponse value) =>
            SendAsync(ClientOpcode.GestureLoad, (PacketWriter writer) =>
            {
                foreach (uint gesture in value.Values)
                    writer.Write(gesture);
            });

        public GameSession SendCharacterPostInfo() =>
            SendAsync(ClientOpcode.PostInfo, (PacketWriter writer) =>
            {
            });

        #endregion Send Characters

        #region Send Chat

        public GameSession SendAsync(ChatResponse value) =>
            SendAsync(ClientOpcode.ChatMessage, (PacketWriter writer) =>
            {
                writer.Write(value.Character);
                writer.WriteChatType(value.Chat);
                writer.WriteByteLengthUnicodeString(value.Message);
            });

        #endregion Send Chat

        #region Send Maze

        public GameSession SendAsync(DayEventBoosterResponse value) =>
            SendAsync(ClientOpcode.EventDayEventBoosterList, (PacketWriter writer) =>
            {
                writer.Write((ushort)value.Values.Count);
                foreach (DayEventBoosterResponse.Entity booster in value.Values)
                {
                    writer.Write(booster.Maze);
                    writer.Write(booster.Id);
                }
            });

        #endregion Send Maze

        #region Send Service

        public GameSession SendAsync(ServiceHeartbeatRequest value) =>
            SendAsync(ClientOpcode.Heartbeat, (PacketWriter writer) =>
            {
                writer.Write(value.Tick);
            });

        public GameSession SendAsync(DistrictLogOutResponse value) =>
            SendAsync(ClientOpcode.LogOut, (PacketWriter writer) =>
            {
                writer.Write(value.Account);
                writer.Write(value.Character);
                writer.WriteNumberLengthUtf8String(value.Ip);
                writer.Write(value.Port);
                writer.WriteDistrictLogOutWay(DistrictLogOutWay.GoToGateService);
                writer.WriteDistrictLogOutStatus(DistrictLogOutStatus.Success);
            });

        #endregion Send Service

        #region Send World

        public GameSession SendAsync(DistrictEnterResponse value) =>
            SendAsync(ClientOpcode.WorldEnter, (PacketWriter writer) =>
            {
                writer.Write(uint.MinValue);
                writer.WriteDistrictConnectResult(value.Result);
                writer.WritePlace(value.Place);
                writer.Write(byte.MinValue);
            });

        public GameSession SendAsync(WorldVersionResponse value) =>
            SendAsync(ClientOpcode.WorldVersion, (PacketWriter writer) =>
            {
                writer.Write(value.Id);
                writer.Write(value.Main);
                writer.Write(value.Sub);
                writer.Write(value.Data);
            });

        #endregion Send World

        #region Send Boosters

        public GameSession SendAsync(BoosterRemoveResponse value) =>
            SendAsync(ClientOpcode.BoosterRemove, (PacketWriter writer) =>
            {
                writer.Write(value.Id);
            });

        public GameSession SendAsync(BoosterAddResponse value) =>
            SendAsync(ClientOpcode.BoosterAdd, (PacketWriter writer) =>
            {
                writer.Write(value.Id);
                writer.Write(value.PrototypeId);
                writer.Write(value.Duration);
            });

        #endregion Send Boosters

        public GameSession SendAsync(GestureUpdateSlotsResponse value) =>
            SendAsync(ClientOpcode.GestureUpdateSlots, (PacketWriter writer) =>
            {
                foreach (uint id in value.Values)
                    writer.Write(id);
            });

        public GameSession SendAsync(GateEnterResponse value) =>
            SendAsync(ClientOpcode.GateEnter, (PacketWriter writer) =>
            {
                writer.WriteGateEnterResult(value.Result);
                writer.Write(value.AccountId);
            });

        public GameSession SendAsync(GateCharacterMarkAsFavoriteResponse value) =>
            SendAsync(ClientOpcode.CharacterMarkAsFavorite, (PacketWriter writer) =>
            {
                writer.Write(value.AccountId);
                writer.Write(value.CharacterId);
                writer.Write(ushort.MinValue);
                writer.WriteByteLengthUnicodeString(value.CharacterName);
                writer.Write(value.PhotoId);
                writer.Write(uint.MinValue);
                writer.Write(uint.MinValue);
                writer.Write(uint.MinValue);
            });

        public GameSession SendAsync(GateCharacterListResponse value) =>
            SendAsync(ClientOpcode.CharactersList, (PacketWriter writer) =>
            {
                writer.Write((byte)value.Characters.Count);
                foreach (CharacterShared character in value.Characters)
                    writer.WriteCharacter(character);

                writer.Write(value.LastSelected);
                writer.Write(byte.MinValue);
                writer.Write((byte)1);
                writer.Write(value.InitializeTime);
                writer.Write(uint.MinValue);
                writer.Write((ulong)1262271600); // dec/31/2009
                writer.Write((byte)17);
                writer.Write(byte.MinValue);
                writer.Write(byte.MinValue);
                writer.Write(byte.MinValue);
            });

        public GameSession SendAsync(GateCharacterChangeBackgroundResponse value) =>
            SendAsync(ClientOpcode.CharacterChangeBackground, (PacketWriter writer) =>
            {
                writer.Write(value.AccountId);
                writer.Write(value.BackgroundId);
                writer.Write(uint.MinValue);
            });

        public GameSession SendAsync(GateCharacterSelectResponse value) =>
            SendAsync(ClientOpcode.CharacterSelect, (PacketWriter writer) =>
            {
                writer.Write(value.CharacterId);
                writer.Write(value.AccountId);
                writer.Write(new byte[28]);
                writer.WriteNumberLengthUtf8String(value.EndPoint.Ip);
                writer.Write(value.EndPoint.Port);
                writer.Write(value.Place);
                writer.Write(new byte[12]);
            });

        public GameSession SendAsync(AuthGateConnectionEndPointResponse endPoint) =>
            SendAsync(ClientOpcode.GateConnect, (PacketWriter writer) =>
            {
                writer.WriteNumberLengthUtf8String(endPoint.Ip);
                writer.Write(endPoint.Port);
            });

        public GameSession SendAsync(IReadOnlyList<AuthPersonalGateResponse> gates) =>
            SendAsync(ClientOpcode.GateList, (PacketWriter writer) =>
            {
                writer.Write(byte.MinValue);
                writer.Write((byte)gates.Count);

                foreach (AuthPersonalGateResponse gate in gates)
                {
                    writer.Write(gate.Gate.Id);
                    writer.Write(gate.Gate.EndPoint.Port);
                    writer.WriteNumberLengthUtf8String(gate.Gate.Name);
                    writer.WriteNumberLengthUtf8String(gate.Gate.EndPoint.Ip);
                    writer.WriteGateStatus(gate.Gate.Status);
                    writer.Write(byte.MinValue);
                    writer.Write(byte.MinValue);
                    writer.Write(byte.MinValue);
                    writer.Write(gate.Gate.PlayersOnlineCount);
                    writer.Write(ushort.MinValue);
                    writer.Write(gate.CharactersCount);
                }
            });

        public GameSession SendAsync(Features value) =>
            SendAsync(ClientOpcode.OptionLoad, (PacketWriter writer) =>
            {
                writer.Write(new byte[64]);

                foreach (FeatureStatus option in value)
                    writer.WriteOptionStatus(option);
            });

        public GameSession SendAsync(AuthLoginResponse value) =>
            SendAsync(ClientOpcode.LoginResult, (PacketWriter writer) =>
            {
                writer.Write(value.AccountId);

                writer.WriteAuthLoginStatus(value.Response);
                writer.Write(Encoding.ASCII.GetBytes(value.Mac));

                writer.Write(byte.MinValue);
                writer.WriteByteLengthUnicodeString(string.Empty);
                writer.WriteAuthLoginErrorMessageCode(value.ErrorMessageCode);

                writer.Write((byte)1);
                writer.WriteByteLengthUnicodeString("134006893");

                writer.Write(value.SessionKey);
                writer.Write(byte.MinValue);
                writer.Write(uint.MinValue);
                writer.Write(byte.MinValue);
            });

        public GameSession SendAsync(ServiceCurrentDataResponse value) =>
            SendAsync(ClientOpcode.CurrentDate, (PacketWriter writer) =>
            {
                writer.Write(value.UnixTimeSeconds);
                writer.Write(value.Year);
                writer.Write(value.Month);
                writer.Write(value.Day);
                writer.Write(value.Hour);
                writer.Write(value.Minute);
                writer.Write(value.Second);
                writer.Write(value.IsDaylightSavingTime);
            });
    }

    public abstract partial class GameSession : TcpSession
    {
        private readonly HandlerProvider _provider;
        private readonly ILogger _logger;

        public GameSession SendAsync(ClientOpcode opcode, Action<PacketWriter> func)
        {
            using PacketWriter pw = new(opcode);
            func(pw);

            if (!SendAsync(PacketUtils.Pack(pw), 0, pw.BaseStream.Length))
#if !DEBUG
                throw new NetworkException();
#else
                Debug.Assert(false);
#endif // !DEBUG

            return this;
        }

        protected GameSession(GameServer server, HandlerProvider provider, ILogger logger) : base(server) =>
            (_provider, _logger) = (provider, logger);

        protected override void OnDisconnected() =>
            _logger.LogDebug($"{Id} disconnected");

        protected override void OnConnected() =>
            _logger.LogDebug($"{Id} connected");

        protected override void OnError(SocketError error) =>
            _logger.LogError($"{error}");

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            using MemoryStream ms = new(buffer, (int)offset, (int)size, false);
            using BinaryReader br = new(ms);

            try
            {
                do
                {
                    // SoulWorker Magic
                    ms.Position += sizeof(ushort);

                    // Packet Length
                    int length = br.ReadUInt16() - Defines.PacketEncryptedHeaderSize;

                    // ???
                    ms.Position += sizeof(byte);

                    ProcessPacket(br.ReadBytes(length));
                } while (br.BaseStream.Position < br.BaseStream.Length);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                _logger.LogError(ex, "Shit happened");
#if !DEBUG
                Disconnect();
#endif
                return;
            }
        }

        private void ProcessPacket(byte[] raw)
        {
            PacketUtils.Exchange(ref raw);

            using MemoryStream ms = new(raw, false);
            using BinaryReader br = new(ms);

            ushort opcode = br.ReadUInt16();
            DebugLogOpcode(opcode);

            _provider[opcode].Invoke(this, br);
        }

        [Conditional("DEBUG")]
        private void DebugLogOpcode(ushort opcode)
        {
            ServerOpcode o = (ServerOpcode)ConvertUtils.LeToBeUInt16(opcode);

            if (o != ServerOpcode.Heartbeat)
                _logger.LogDebug($"@event [{(ServerOpcode)ConvertUtils.LeToBeUInt16(opcode)}]");
        }
    }
}