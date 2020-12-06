﻿using Core.Systems.GameSystem.Extensions;
using System.Xml;

namespace Core.Systems.GameSystem.Datas.World.Table.EventBox
{
    public sealed class VCheckSectorBox : VEntity
    {
        /// <summary>
        ///
        /// </summary>
        public uint CheckSector { get; }

        /// <summary>
        ///
        /// </summary>
        public string Lua { get; }

        /// <summary>
        ///
        /// </summary>
        public uint CheckGate { get; }

        internal VCheckSectorBox(XmlNode xml) : base(xml)
        {
            CheckSector = xml.GetUInt32("m_iCheckSector");
            Lua = xml.GetString("m_szLua");
            CheckGate = xml.GetUInt32("m_iCheckGate");
        }
    }
}