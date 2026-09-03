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
	public struct FixedString64Bytes : INativeList<byte>, IUTF8Bytes, IComparable<string>, IEquatable<string>, IComparable<Unity.Collections.FixedString32Bytes>, IEquatable<Unity.Collections.FixedString32Bytes>, IComparable<Unity.Collections.FixedString64Bytes>, IEquatable<Unity.Collections.FixedString64Bytes>, IComparable<Unity.Collections.FixedString128Bytes>, IEquatable<Unity.Collections.FixedString128Bytes>, IComparable<Unity.Collections.FixedString512Bytes>, IEquatable<Unity.Collections.FixedString512Bytes>, IComparable<Unity.Collections.FixedString4096Bytes>, IEquatable<Unity.Collections.FixedString4096Bytes> // TypeDefIndex: 11528
	{
		// Fields
		internal const ushort utf8MaxLengthInBytes = 61; // Metadata: 0x006A1BEC
		[SerializeField]
		internal ushort utf8LengthInBytes; // 0x00
		[SerializeField]
		internal FixedBytes62 bytes; // 0x02
	
		// Properties
		public static int UTF8MaxLengthInBytes { get; } // 0x00000001817C2DB0-0x00000001817C2DC0 
		[CreateProperty]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ExcludeFromBurstCompatTesting("Returns managed string")]
		public string Value { get; } // 0x0000000181C94F40-0x0000000181C94F80 
		public int Length { [IsReadOnly] get; set; } // 0x000000018123AD30-0x000000018123AD40 0x0000000181C91910-0x0000000181C91920
		public int Capacity { [IsReadOnly] get; set; } // 0x00000001817C2DB0-0x00000001817C2DC0 0x00000001802E76C0-0x00000001802E76D0
		public bool IsEmpty { [IsReadOnly] get; } // 0x000000018123ACC0-0x000000018123ACD0 
		public byte this[int index] { [IsReadOnly] get => default; set {} } // 0x0000000181C91540-0x0000000181C91550 0x0000000181C91900-0x0000000181C91910
	
		// Nested types
		public struct Enumerator : IEnumerator // TypeDefIndex: 11529
		{
			// Fields
			private FixedString64Bytes target; // 0x00
			private int offset; // 0x40
			private Unicode.Rune current; // 0x44
	
			// Properties
			public Unicode.Rune Current { get; } // 0x000000018033D780-0x000000018033D790 
			object IEnumerator.Current { get; } // 0x0000000181C90610-0x0000000181C90660 
	
			// Constructors
			public Enumerator(FixedString64Bytes other); // 0x0000000181C90830-0x0000000181C90860
	
			// Methods
			public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			public bool MoveNext(); // 0x0000000181C904E0-0x0000000181C90520
			public void Reset(); // 0x0000000181C905A0-0x0000000181C905B0
		}
	
		// Constructors
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public FixedString64Bytes(string source); // 0x0000000181C951C0-0x0000000181C951E0
		public FixedString64Bytes(Unicode.Rune rune, int count = 1 /* Metadata: 0x006A1BEA */); // 0x0000000181C94F20-0x0000000181C94F40
		public FixedString64Bytes(NativeText.ReadOnly other); // 0x0000000181C95120-0x0000000181C951C0
		public FixedString64Bytes([IsReadOnly] in UnsafeText other); // 0x0000000181C95000-0x0000000181C950C0
		public FixedString64Bytes([IsReadOnly] in FixedString32Bytes other); // 0x0000000181C950C0-0x0000000181C95120
		public FixedString64Bytes([IsReadOnly] in FixedString64Bytes other); // 0x0000000181C950C0-0x0000000181C95120
		public FixedString64Bytes([IsReadOnly] in FixedString128Bytes other); // 0x0000000181C950C0-0x0000000181C95120
		public FixedString64Bytes([IsReadOnly] in FixedString512Bytes other); // 0x0000000181C950C0-0x0000000181C95120
		public FixedString64Bytes([IsReadOnly] in FixedString4096Bytes other); // 0x0000000181C950C0-0x0000000181C95120
	
		// Methods
		[IsReadOnly]
		public unsafe byte* GetUnsafePtr(); // 0x00000001812417F0-0x0000000181241800
		public bool TryResize(int newLength, NativeArrayOptions clearOptions = NativeArrayOptions.ClearMemory /* Metadata: 0x006A1BE9 */); // 0x0000000181C94F80-0x0000000181C95000
		public ref byte ElementAt(int index); // 0x0000000181C90DA0-0x0000000181C90DB0
		public void Clear(); // 0x0000000181C90D10-0x0000000181C90D20
		public void Add([IsReadOnly] in byte value); // 0x0000000181C908D0-0x0000000181C908F0
		public Enumerator GetEnumerator(); // 0x0000000181C94DF0-0x0000000181C94E20
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public int CompareTo(string other); // 0x0000000181C94A10-0x0000000181C94A70
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public bool Equals(string other); // 0x0000000181C90DE0-0x0000000181C90E50
		public ref FixedList64Bytes<byte> AsFixedList(); // 0x0000000180370C60-0x0000000180370C70
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		internal CopyError Initialize(string source); // 0x0000000181C94F10-0x0000000181C94F20
		internal FormatError Initialize(Unicode.Rune rune, int count = 1 /* Metadata: 0x006A1BEB */); // 0x0000000181C94F20-0x0000000181C94F40
		internal unsafe FormatError Initialize(byte* srcBytes, int srcLength); // 0x0000000181C94E20-0x0000000181C94E90
		public int CompareTo(FixedString32Bytes other); // 0x0000000181C90D20-0x0000000181C90D40
		internal FormatError Initialize([IsReadOnly] in FixedString32Bytes other); // 0x0000000181C94E90-0x0000000181C94F10
		public static bool operator ==([IsReadOnly] in FixedString64Bytes a, [IsReadOnly] in FixedString32Bytes b); // 0x0000000181C90DB0-0x0000000181C90DE0
		public static bool operator !=([IsReadOnly] in FixedString64Bytes a, [IsReadOnly] in FixedString32Bytes b); // 0x0000000181C917E0-0x0000000181C91810
		public bool Equals(FixedString32Bytes other); // 0x0000000181C90DB0-0x0000000181C90DE0
		public int CompareTo(FixedString64Bytes other); // 0x0000000181C90D20-0x0000000181C90D40
		internal FormatError Initialize([IsReadOnly] in FixedString64Bytes other); // 0x0000000181C94E90-0x0000000181C94F10
		public static bool operator ==([IsReadOnly] in FixedString64Bytes a, [IsReadOnly] in FixedString64Bytes b); // 0x0000000181C90DB0-0x0000000181C90DE0
		public static bool operator !=([IsReadOnly] in FixedString64Bytes a, [IsReadOnly] in FixedString64Bytes b); // 0x0000000181C917E0-0x0000000181C91810
		public bool Equals(FixedString64Bytes other); // 0x0000000181C90DB0-0x0000000181C90DE0
		public int CompareTo(FixedString128Bytes other); // 0x0000000181C90D20-0x0000000181C90D40
		internal FormatError Initialize([IsReadOnly] in FixedString128Bytes other); // 0x0000000181C94E90-0x0000000181C94F10
		public static bool operator ==([IsReadOnly] in FixedString64Bytes a, [IsReadOnly] in FixedString128Bytes b); // 0x0000000181C90DB0-0x0000000181C90DE0
		public static bool operator !=([IsReadOnly] in FixedString64Bytes a, [IsReadOnly] in FixedString128Bytes b); // 0x0000000181C917E0-0x0000000181C91810
		public bool Equals(FixedString128Bytes other); // 0x0000000181C90DB0-0x0000000181C90DE0
		public static implicit operator FixedString128Bytes([IsReadOnly] in FixedString64Bytes fs); // 0x0000000181C92610-0x0000000181C92660
		public int CompareTo(FixedString512Bytes other); // 0x0000000181C90D20-0x0000000181C90D40
		internal FormatError Initialize([IsReadOnly] in FixedString512Bytes other); // 0x0000000181C94E90-0x0000000181C94F10
		public static bool operator ==([IsReadOnly] in FixedString64Bytes a, [IsReadOnly] in FixedString512Bytes b); // 0x0000000181C90DB0-0x0000000181C90DE0
		public static bool operator !=([IsReadOnly] in FixedString64Bytes a, [IsReadOnly] in FixedString512Bytes b); // 0x0000000181C917E0-0x0000000181C91810
		public bool Equals(FixedString512Bytes other); // 0x0000000181C90DB0-0x0000000181C90DE0
		public static implicit operator FixedString512Bytes([IsReadOnly] in FixedString64Bytes fs); // 0x0000000181C91670-0x0000000181C916E0
		public int CompareTo(FixedString4096Bytes other); // 0x0000000181C90D20-0x0000000181C90D40
		internal FormatError Initialize([IsReadOnly] in FixedString4096Bytes other); // 0x0000000181C94E90-0x0000000181C94F10
		public static bool operator ==([IsReadOnly] in FixedString64Bytes a, [IsReadOnly] in FixedString4096Bytes b); // 0x0000000181C90DB0-0x0000000181C90DE0
		public static bool operator !=([IsReadOnly] in FixedString64Bytes a, [IsReadOnly] in FixedString4096Bytes b); // 0x0000000181C917E0-0x0000000181C91810
		public bool Equals(FixedString4096Bytes other); // 0x0000000181C90DB0-0x0000000181C90DE0
		public static implicit operator FixedString4096Bytes([IsReadOnly] in FixedString64Bytes fs); // 0x0000000181C916E0-0x0000000181C917A0
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public static bool operator ==([IsReadOnly] in FixedString64Bytes a, string b); // 0x0000000181C951E0-0x0000000181C952D0
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public static bool operator !=([IsReadOnly] in FixedString64Bytes a, string b); // 0x0000000181C95300-0x0000000181C953A0
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public static implicit operator FixedString64Bytes(string b); // 0x0000000181C952D0-0x0000000181C95300
		[ExcludeFromBurstCompatTesting("Returns managed string")]
		public override string ToString(); // 0x0000000181C94F40-0x0000000181C94F80
		public override int GetHashCode(); // 0x0000000181C91240-0x0000000181C91250
		[ExcludeFromBurstCompatTesting("Takes managed object")]
		public override bool Equals(object obj); // 0x0000000181C94A70-0x0000000181C94DF0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		[IsReadOnly]
		private void CheckIndexInRange(int index); // 0x0000000181C947B0-0x0000000181C948E0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckLengthInRange(int length); // 0x0000000181C948E0-0x0000000181C94A10
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckCapacityInRange(int capacity); // 0x0000000181C945F0-0x0000000181C946B0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckCopyError(CopyError error, string source); // 0x0000000181C946B0-0x0000000181C94750
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckFormatError(FormatError error); // 0x0000000181C94750-0x0000000181C947B0
	}
}
