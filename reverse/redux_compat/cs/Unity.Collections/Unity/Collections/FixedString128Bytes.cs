/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Properties;
using UnityEngine;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[Serializable]
	[GenerateTestsForBurstCompatibility]
	public struct FixedString128Bytes : INativeList<byte>, IUTF8Bytes, IComparable<string>, IEquatable<string>, IComparable<Unity.Collections.FixedString32Bytes>, IEquatable<Unity.Collections.FixedString32Bytes>, IComparable<Unity.Collections.FixedString64Bytes>, IEquatable<Unity.Collections.FixedString64Bytes>, IComparable<Unity.Collections.FixedString128Bytes>, IEquatable<Unity.Collections.FixedString128Bytes>, IComparable<Unity.Collections.FixedString512Bytes>, IEquatable<Unity.Collections.FixedString512Bytes>, IComparable<Unity.Collections.FixedString4096Bytes>, IEquatable<Unity.Collections.FixedString4096Bytes> // TypeDefIndex: 11531
	{
		// Fields
		internal const ushort utf8MaxLengthInBytes = 125; // Metadata: 0x006A1BF1
		[SerializeField]
		internal ushort utf8LengthInBytes; // 0x00
		[SerializeField]
		internal FixedBytes126 bytes; // 0x02
	
		// Properties
		public static int UTF8MaxLengthInBytes { get; } // 0x0000000181C91530-0x0000000181C91540 
		[CreateProperty]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ExcludeFromBurstCompatTesting("Returns managed string")]
		public string Value { get; } // 0x0000000181C91320-0x0000000181C91360 
		public int Length { [IsReadOnly] get; set; } // 0x000000018123AD30-0x000000018123AD40 0x0000000181C91910-0x0000000181C91920
		public int Capacity { [IsReadOnly] get; set; } // 0x0000000181C91530-0x0000000181C91540 0x00000001802E76C0-0x00000001802E76D0
		public bool IsEmpty { [IsReadOnly] get; } // 0x000000018123ACC0-0x000000018123ACD0 
		public byte this[int index] { [IsReadOnly] get => default; set {} } // 0x0000000181C91540-0x0000000181C91550 0x0000000181C91900-0x0000000181C91910
	
		// Nested types
		public struct Enumerator : IEnumerator // TypeDefIndex: 11532
		{
			// Fields
			private FixedString128Bytes target; // 0x00
			private int offset; // 0x80
			private Unicode.Rune current; // 0x84
	
			// Properties
			public Unicode.Rune Current { get; } // 0x0000000180BE5CE0-0x0000000180BE5CF0 
			object IEnumerator.Current { get; } // 0x0000000181C906B0-0x0000000181C90700 
	
			// Constructors
			public Enumerator(FixedString128Bytes other); // 0x0000000181C90860-0x0000000181C908B0
	
			// Methods
			public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			public bool MoveNext(); // 0x0000000181C90520-0x0000000181C90570
			public void Reset(); // 0x0000000181C90570-0x0000000181C90580
		}
	
		// Constructors
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public FixedString128Bytes(string source); // 0x0000000181C914A0-0x0000000181C914D0
		public FixedString128Bytes(Unicode.Rune rune, int count = 1 /* Metadata: 0x006A1BEF */); // 0x0000000181C912F0-0x0000000181C91320
		public FixedString128Bytes(NativeText.ReadOnly other); // 0x0000000181C914D0-0x0000000181C91530
		public FixedString128Bytes([IsReadOnly] in UnsafeText other); // 0x0000000181C91420-0x0000000181C914A0
		public FixedString128Bytes([IsReadOnly] in FixedString32Bytes other); // 0x0000000181C913E0-0x0000000181C91420
		public FixedString128Bytes([IsReadOnly] in FixedString64Bytes other); // 0x0000000181C913E0-0x0000000181C91420
		public FixedString128Bytes([IsReadOnly] in FixedString128Bytes other); // 0x0000000181C913E0-0x0000000181C91420
		public FixedString128Bytes([IsReadOnly] in FixedString512Bytes other); // 0x0000000181C913E0-0x0000000181C91420
		public FixedString128Bytes([IsReadOnly] in FixedString4096Bytes other); // 0x0000000181C913E0-0x0000000181C91420
	
		// Methods
		[IsReadOnly]
		public unsafe byte* GetUnsafePtr(); // 0x00000001812417F0-0x0000000181241800
		public bool TryResize(int newLength, NativeArrayOptions clearOptions = NativeArrayOptions.ClearMemory /* Metadata: 0x006A1BEE */); // 0x0000000181C91360-0x0000000181C913E0
		public ref byte ElementAt(int index); // 0x0000000181C90DA0-0x0000000181C90DB0
		public void Clear(); // 0x0000000181C90D10-0x0000000181C90D20
		public void Add([IsReadOnly] in byte value); // 0x0000000181C908D0-0x0000000181C908F0
		public Enumerator GetEnumerator(); // 0x0000000181C911D0-0x0000000181C91240
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public int CompareTo(string other); // 0x0000000181C90D40-0x0000000181C90DA0
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public bool Equals(string other); // 0x0000000181C90DE0-0x0000000181C90E50
		public ref FixedList128Bytes<byte> AsFixedList(); // 0x0000000180370C60-0x0000000180370C70
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		internal CopyError Initialize(string source); // 0x0000000181C912E0-0x0000000181C912F0
		internal FormatError Initialize(Unicode.Rune rune, int count = 1 /* Metadata: 0x006A1BF0 */); // 0x0000000181C912F0-0x0000000181C91320
		internal unsafe FormatError Initialize(byte* srcBytes, int srcLength); // 0x0000000181C91260-0x0000000181C912E0
		public int CompareTo(FixedString32Bytes other); // 0x0000000181C90D20-0x0000000181C90D40
		internal FormatError Initialize([IsReadOnly] in FixedString32Bytes other); // 0x0000000181C91250-0x0000000181C91260
		public static bool operator ==([IsReadOnly] in FixedString128Bytes a, [IsReadOnly] in FixedString32Bytes b); // 0x0000000181C90DB0-0x0000000181C90DE0
		public static bool operator !=([IsReadOnly] in FixedString128Bytes a, [IsReadOnly] in FixedString32Bytes b); // 0x0000000181C917E0-0x0000000181C91810
		public bool Equals(FixedString32Bytes other); // 0x0000000181C90DB0-0x0000000181C90DE0
		public int CompareTo(FixedString64Bytes other); // 0x0000000181C90D20-0x0000000181C90D40
		internal FormatError Initialize([IsReadOnly] in FixedString64Bytes other); // 0x0000000181C91250-0x0000000181C91260
		public static bool operator ==([IsReadOnly] in FixedString128Bytes a, [IsReadOnly] in FixedString64Bytes b); // 0x0000000181C90DB0-0x0000000181C90DE0
		public static bool operator !=([IsReadOnly] in FixedString128Bytes a, [IsReadOnly] in FixedString64Bytes b); // 0x0000000181C917E0-0x0000000181C91810
		public bool Equals(FixedString64Bytes other); // 0x0000000181C90DB0-0x0000000181C90DE0
		public int CompareTo(FixedString128Bytes other); // 0x0000000181C90D20-0x0000000181C90D40
		internal FormatError Initialize([IsReadOnly] in FixedString128Bytes other); // 0x0000000181C91250-0x0000000181C91260
		public static bool operator ==([IsReadOnly] in FixedString128Bytes a, [IsReadOnly] in FixedString128Bytes b); // 0x0000000181C90DB0-0x0000000181C90DE0
		public static bool operator !=([IsReadOnly] in FixedString128Bytes a, [IsReadOnly] in FixedString128Bytes b); // 0x0000000181C917E0-0x0000000181C91810
		public bool Equals(FixedString128Bytes other); // 0x0000000181C90DB0-0x0000000181C90DE0
		public int CompareTo(FixedString512Bytes other); // 0x0000000181C90D20-0x0000000181C90D40
		internal FormatError Initialize([IsReadOnly] in FixedString512Bytes other); // 0x0000000181C91250-0x0000000181C91260
		public static bool operator ==([IsReadOnly] in FixedString128Bytes a, [IsReadOnly] in FixedString512Bytes b); // 0x0000000181C90DB0-0x0000000181C90DE0
		public static bool operator !=([IsReadOnly] in FixedString128Bytes a, [IsReadOnly] in FixedString512Bytes b); // 0x0000000181C917E0-0x0000000181C91810
		public bool Equals(FixedString512Bytes other); // 0x0000000181C90DB0-0x0000000181C90DE0
		public static implicit operator FixedString512Bytes([IsReadOnly] in FixedString128Bytes fs); // 0x0000000181C91670-0x0000000181C916E0
		public int CompareTo(FixedString4096Bytes other); // 0x0000000181C90D20-0x0000000181C90D40
		internal FormatError Initialize([IsReadOnly] in FixedString4096Bytes other); // 0x0000000181C91250-0x0000000181C91260
		public static bool operator ==([IsReadOnly] in FixedString128Bytes a, [IsReadOnly] in FixedString4096Bytes b); // 0x0000000181C90DB0-0x0000000181C90DE0
		public static bool operator !=([IsReadOnly] in FixedString128Bytes a, [IsReadOnly] in FixedString4096Bytes b); // 0x0000000181C917E0-0x0000000181C91810
		public bool Equals(FixedString4096Bytes other); // 0x0000000181C90DB0-0x0000000181C90DE0
		public static implicit operator FixedString4096Bytes([IsReadOnly] in FixedString128Bytes fs); // 0x0000000181C916E0-0x0000000181C917A0
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public static bool operator ==([IsReadOnly] in FixedString128Bytes a, string b); // 0x0000000181C91550-0x0000000181C91670
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public static bool operator !=([IsReadOnly] in FixedString128Bytes a, string b); // 0x0000000181C91810-0x0000000181C91900
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public static implicit operator FixedString128Bytes(string b); // 0x0000000181C917A0-0x0000000181C917E0
		[ExcludeFromBurstCompatTesting("Returns managed string")]
		public override string ToString(); // 0x0000000181C91320-0x0000000181C91360
		public override int GetHashCode(); // 0x0000000181C91240-0x0000000181C91250
		[ExcludeFromBurstCompatTesting("Takes managed object")]
		public override bool Equals(object obj); // 0x0000000181C90E50-0x0000000181C911D0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		[IsReadOnly]
		private void CheckIndexInRange(int index); // 0x0000000181C90AB0-0x0000000181C90BE0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckLengthInRange(int length); // 0x0000000181C90BE0-0x0000000181C90D10
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckCapacityInRange(int capacity); // 0x0000000181C908F0-0x0000000181C909B0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckCopyError(CopyError error, string source); // 0x0000000181C909B0-0x0000000181C90A50
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckFormatError(FormatError error); // 0x0000000181C90A50-0x0000000181C90AB0
	}
}
