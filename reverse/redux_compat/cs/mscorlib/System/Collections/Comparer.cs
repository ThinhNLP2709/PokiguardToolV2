/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections
{
	[Serializable]
	public sealed class Comparer : IComparer, ISerializable // TypeDefIndex: 3487
	{
		// Fields
		private CompareInfo _compareInfo; // 0x10
		public static readonly Comparer Default; // 0x00
		public static readonly Comparer DefaultInvariant; // 0x08
	
		// Constructors
		public Comparer(CultureInfo culture); // 0x0000000181593530-0x00000001815935D0
		private Comparer(SerializationInfo info, StreamingContext context); // 0x00000001815933B0-0x0000000181593530
		static Comparer(); // 0x0000000181593190-0x00000001815933B0
	
		// Methods
		public void GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001815930F0-0x0000000181593190
		public int Compare(object a, object b); // 0x0000000181592F50-0x00000001815930F0
	}
}
