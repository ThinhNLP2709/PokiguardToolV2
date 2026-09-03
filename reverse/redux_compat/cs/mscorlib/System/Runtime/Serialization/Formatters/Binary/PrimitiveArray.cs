/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Serialization.Formatters.Binary
{
	internal sealed class PrimitiveArray // TypeDefIndex: 3113
	{
		// Fields
		private InternalPrimitiveTypeE code; // 0x10
		private bool[] booleanA; // 0x18
		private char[] charA; // 0x20
		private double[] doubleA; // 0x28
		private short[] int16A; // 0x30
		private int[] int32A; // 0x38
		private long[] int64A; // 0x40
		private sbyte[] sbyteA; // 0x48
		private float[] singleA; // 0x50
		private ushort[] uint16A; // 0x58
		private uint[] uint32A; // 0x60
		private ulong[] uint64A; // 0x68
	
		// Constructors
		internal PrimitiveArray(InternalPrimitiveTypeE code, Array array); // 0x0000000181512B80-0x0000000181512BC0
	
		// Methods
		internal void Init(InternalPrimitiveTypeE code, Array array); // 0x00000001815121D0-0x0000000181512790
		internal void SetValue(string value, int index); // 0x0000000181512790-0x0000000181512B80
	}
}
