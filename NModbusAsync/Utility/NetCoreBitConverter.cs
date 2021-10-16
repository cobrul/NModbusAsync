﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NModbusAsync.Utility
{
    internal static class NetCoreBitConverter
    {
        internal static bool TryWriteBytes(Span<byte> destination, short value)
        {
            if (destination.Length < sizeof(short))
            {
                return false;
            }

            Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);
            return true;
        }

        internal static bool TryWriteBytes(Span<byte> destination, ushort value)
        {
            return TryWriteBytes(destination, (short)value);
        }

        internal static short ToInt16(ReadOnlySpan<byte> value)
        {
            if (value.Length < sizeof(short))
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            return Unsafe.ReadUnaligned<short>(ref MemoryMarshal.GetReference(value));
        }

        internal static ushort ToUInt16(ReadOnlySpan<byte> value)
        {
            return (ushort)ToInt16(value);
        }
    }
}