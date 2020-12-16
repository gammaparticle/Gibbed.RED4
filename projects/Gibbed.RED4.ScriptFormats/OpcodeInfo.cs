﻿/* Copyright (c) 2020 Rick (rick 'at' gibbed 'dot' us)
 *
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System;
using System.Collections.Generic;

namespace Gibbed.RED4.ScriptFormats
{
    public class OpcodeInfo
    {
        public int ChainCount { get; }

        public OpcodeInfo(int chainCount)
        {
            this.ChainCount = chainCount;
        }

        public static OpcodeInfo Get(Opcode opcode)
        {
            if (_Lookup.TryGetValue(opcode, out var info) == false || info == null)
            {
                throw new ArgumentOutOfRangeException($"no info for {opcode}", nameof(opcode));
            }
            return info;
        }

        static OpcodeInfo()
        {
            _Lookup = new Dictionary<Opcode, OpcodeInfo>()
            {
                { Opcode.Nop, new OpcodeInfo(0) },
                { Opcode.Null, new OpcodeInfo(0) },
                { Opcode.Int32One, new OpcodeInfo(0) },
                { Opcode.Int32Zero, new OpcodeInfo(0) },
                { Opcode.Int8Const, new OpcodeInfo(0) },
                { Opcode.Int16Const, new OpcodeInfo(0) },
                { Opcode.Int32Const, new OpcodeInfo(0) },
                { Opcode.Int64Const, new OpcodeInfo(0) },
                { Opcode.Uint8Const, new OpcodeInfo(0) },
                { Opcode.Uint16Const, new OpcodeInfo(0) },
                { Opcode.Uint32Const, new OpcodeInfo(0) },
                { Opcode.Uint64Const, new OpcodeInfo(0) },
                { Opcode.FloatConst, new OpcodeInfo(0) },
                { Opcode.DoubleConst, new OpcodeInfo(0) },
                { Opcode.NameConst, new OpcodeInfo(0) },
                { Opcode.EnumConst, new OpcodeInfo(0) },
                { Opcode.StringConst, new OpcodeInfo(0) },
                { Opcode.TweakDBIdConst, new OpcodeInfo(0) },
                { Opcode.ResourceConst, new OpcodeInfo(0) },
                { Opcode.BoolTrue, new OpcodeInfo(0) },
                { Opcode.BoolFalse, new OpcodeInfo(0) },
                { (Opcode)21, new OpcodeInfo(1) },
                { Opcode.Assign, new OpcodeInfo(2) },
                { Opcode.Target, new OpcodeInfo(0) },
                { Opcode.LocalVar, new OpcodeInfo(0) },
                { Opcode.ParamVar, new OpcodeInfo(0) },
                { Opcode.ObjectVar, new OpcodeInfo(0) },
                { (Opcode)27, new OpcodeInfo(0) },
                { Opcode.Switch, new OpcodeInfo(-1) }, // special
                { Opcode.SwitchLabel, new OpcodeInfo(-1) }, // special
                { Opcode.SwitchDefault, new OpcodeInfo(-1) }, // special
                { Opcode.Jump, new OpcodeInfo(0) },
                { Opcode.JumpIfFalse, new OpcodeInfo(1) },
                { Opcode.Skip, new OpcodeInfo(1) },
                { Opcode.Conditional, new OpcodeInfo(2) },
                { Opcode.Constructor, new OpcodeInfo(-1) }, // special
                { Opcode.FinalFunc, new OpcodeInfo(-1) }, // special
                { Opcode.VirtualFunc, new OpcodeInfo(-1) }, // special
                { Opcode.ParamEnd, new OpcodeInfo(0) },
                { Opcode.Return, new OpcodeInfo(1) },
                { Opcode.StructMember, new OpcodeInfo(1) },
                { Opcode.Context, new OpcodeInfo(2) },
                { Opcode.TestEqual, new OpcodeInfo(2) },
                { Opcode.TestNotEqual, new OpcodeInfo(2) },
                { (Opcode)44, new OpcodeInfo(0) },
                { (Opcode)45, new OpcodeInfo(0) },
                { Opcode.This, new OpcodeInfo(0) },
                { (Opcode)47, new OpcodeInfo(0) },
                { (Opcode)48, new OpcodeInfo(1) },
                { (Opcode)49, new OpcodeInfo(1) },
                { (Opcode)50, new OpcodeInfo(2) },
                { (Opcode)51, new OpcodeInfo(2) },
                { (Opcode)52, new OpcodeInfo(2) },
                { (Opcode)53, new OpcodeInfo(2) },
                { (Opcode)54, new OpcodeInfo(2) },
                { (Opcode)55, new OpcodeInfo(2) },
                { (Opcode)56, new OpcodeInfo(2) },
                { (Opcode)57, new OpcodeInfo(2) },
                { (Opcode)58, new OpcodeInfo(2) },
                { (Opcode)59, new OpcodeInfo(2) },
                { (Opcode)60, new OpcodeInfo(1) },
                { (Opcode)61, new OpcodeInfo(3) },
                { (Opcode)62, new OpcodeInfo(2) },
                { (Opcode)63, new OpcodeInfo(2) },
                { (Opcode)64, new OpcodeInfo(2) },
                { (Opcode)65, new OpcodeInfo(2) },
                { (Opcode)66, new OpcodeInfo(2) },
                { (Opcode)67, new OpcodeInfo(1) },
                { (Opcode)68, new OpcodeInfo(2) },
                { (Opcode)69, new OpcodeInfo(1) },
                { (Opcode)70, new OpcodeInfo(2) },
                { (Opcode)71, new OpcodeInfo(2) },
                { (Opcode)72, new OpcodeInfo(2) },
                { (Opcode)73, new OpcodeInfo(2) },
                { (Opcode)74, new OpcodeInfo(2) },
                { (Opcode)75, new OpcodeInfo(2) },
                { (Opcode)76, new OpcodeInfo(2) },
                { (Opcode)77, new OpcodeInfo(2) },
                { (Opcode)78, new OpcodeInfo(1) },
                { (Opcode)79, new OpcodeInfo(2) },
                { (Opcode)80, new OpcodeInfo(1) },
                { (Opcode)81, new OpcodeInfo(1) },
                { Opcode.EnumToInt, new OpcodeInfo(1) },
                { Opcode.IntToEnum, new OpcodeInfo(1) },
                { Opcode.DynamicCast, new OpcodeInfo(1) },
                { (Opcode)85, new OpcodeInfo(1) },
                { (Opcode)86, new OpcodeInfo(1) },
                { (Opcode)87, new OpcodeInfo(1) },
                { (Opcode)88, new OpcodeInfo(1) },
                { (Opcode)89, new OpcodeInfo(1) },
                { (Opcode)90, new OpcodeInfo(1) },
                { (Opcode)91, new OpcodeInfo(1) },
                { (Opcode)92, new OpcodeInfo(1) },
                { (Opcode)93, new OpcodeInfo(1) },
                { (Opcode)94, new OpcodeInfo(1) },
                { (Opcode)95, new OpcodeInfo(0) },
                { (Opcode)96, new OpcodeInfo(1) },
                { (Opcode)97, new OpcodeInfo(1) },
                { (Opcode)98, new OpcodeInfo(0) },
            };
        }

        private static readonly Dictionary<Opcode, OpcodeInfo> _Lookup;
    }
}
