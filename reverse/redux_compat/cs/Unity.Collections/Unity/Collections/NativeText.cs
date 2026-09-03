/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Properties;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[DebuggerDisplay("Length = {Length}")]
	[GenerateTestsForBurstCompatibility]
	[NativeContainer]
	public struct NativeText : INativeList<byte>, INativeDisposable, IUTF8Bytes, IComparable<string>, IEquatable<string>, IComparable<Unity.Collections.NativeText>, IEquatable<Unity.Collections.NativeText>, IComparable<Unity.Collections.FixedString32Bytes>, IEquatable<Unity.Collections.FixedString32Bytes>, IComparable<Unity.Collections.FixedString64Bytes>, IEquatable<Unity.Collections.FixedString64Bytes>, IComparable<Unity.Collections.FixedString128Bytes>, IEquatable<Unity.Collections.FixedString128Bytes>, IComparable<Unity.Collections.FixedString512Bytes>, IEquatable<Unity.Collections.FixedString512Bytes>, IComparable<Unity.Collections.FixedString4096Bytes>, IEquatable<Unity.Collections.FixedString4096Bytes> // TypeDefIndex: 11630
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		internal unsafe UnsafeText* m_Data; // 0x00
		public const int MaxCapacity = 2147483646; // Metadata: 0x006A1C47
	
		// Properties
		public int Length { [IsReadOnly] get; set; } // 0x00000001808AA110-0x00000001808AA130 0x0000000181CA4700-0x0000000181CA4740
		public int Capacity { [IsReadOnly] get; set; } // 0x0000000181CA4650-0x0000000181CA4670 0x0000000181CA46E0-0x0000000181CA46F0
		public bool IsEmpty { [IsReadOnly] get; } // 0x0000000181CA4670-0x0000000181CA46A0 
		public bool IsCreated { [IsReadOnly] get; } // 0x0000000180B1C1D0-0x0000000180B1C1E0 
		public byte this[int index] { get => default; set {} } // 0x0000000181CA46A0-0x0000000181CA46B0 0x0000000181CA46F0-0x0000000181CA4700
		[CreateProperty]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ExcludeFromBurstCompatTesting("Returns managed string")]
		public string Value { get; } // 0x0000000181CA4090-0x0000000181CA40F0 
	
		// Nested types
		public struct Enumerator : IEnumerator<Unicode.Rune> // TypeDefIndex: 11631
		{
			// Fields
			private ReadOnly target; // 0x00
			private int offset; // 0x08
			private Unicode.Rune current; // 0x0C
	
			// Properties
			object IEnumerator.Current { get; } // 0x0000000181CA1500-0x0000000181CA1550 
			public Unicode.Rune Current { get; } // 0x0000000180732D30-0x0000000180732D40 
	
			// Constructors
			public Enumerator(NativeText source); // 0x0000000181CA1550-0x0000000181CA1560
			public Enumerator(ReadOnly source); // 0x0000000181CA1550-0x0000000181CA1560
	
			// Methods
			public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			public bool MoveNext(); // 0x0000000181CA14A0-0x0000000181CA14F0
			public void Reset(); // 0x0000000181CA14F0-0x0000000181CA1500
		}
	
		[NativeContainer]
		[NativeContainerIsReadOnly]
		public struct ReadOnly : INativeList<byte>, IUTF8Bytes, IComparable<string>, IEquatable<string>, IComparable<NativeText>, IEquatable<NativeText>, IComparable<FixedString32Bytes>, IEquatable<FixedString32Bytes>, IComparable<FixedString64Bytes>, IEquatable<FixedString64Bytes>, IComparable<FixedString128Bytes>, IEquatable<FixedString128Bytes>, IComparable<FixedString512Bytes>, IEquatable<FixedString512Bytes>, IComparable<FixedString4096Bytes>, IEquatable<FixedString4096Bytes> // TypeDefIndex: 11632
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			internal unsafe UnsafeText* m_Data; // 0x00
	
			// Properties
			public int Capacity { [IsReadOnly] get; set; } // 0x0000000181CA4650-0x0000000181CA4670 0x00000001802E76C0-0x00000001802E76D0
			public bool IsEmpty { [IsReadOnly] get; set; } // 0x0000000181CA4670-0x0000000181CA46A0 0x00000001802E76C0-0x00000001802E76D0
			public int Length { [IsReadOnly] get; set; } // 0x00000001808AA110-0x00000001808AA130 0x00000001802E76C0-0x00000001802E76D0
			public byte this[int index] { [IsReadOnly] get => default; set {} } // 0x0000000181CA46A0-0x0000000181CA46B0 0x00000001802E76C0-0x00000001802E76D0
			[CreateProperty]
			[EditorBrowsable(EditorBrowsableState.Never)]
			[ExcludeFromBurstCompatTesting("Returns managed string")]
			public string Value { get; } // 0x0000000181CA5340-0x0000000181CA53A0 
	
			// Constructors
			internal unsafe ReadOnly(UnsafeText* text); // 0x0000000180CBE820-0x0000000180CBE830
	
			// Methods
			public void Clear(); // 0x00000001802E76C0-0x00000001802E76D0
			public ref byte ElementAt(int index); // 0x0000000181CA4CB0-0x0000000181CA4D00
			public unsafe byte* GetUnsafePtr(); // 0x0000000181CA3FF0-0x0000000181CA4000
			public bool TryResize(int newLength, NativeArrayOptions clearOptions = NativeArrayOptions.ClearMemory /* Metadata: 0x006A1C4C */); // 0x00000001802E7840-0x00000001802E7850
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			internal static unsafe void CheckNull(void* dataPtr); // 0x0000000181CA4B90-0x0000000181CA4BF0
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[IsReadOnly]
			private void CheckRead(); // 0x00000001802E76C0-0x00000001802E76D0
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Conditional("UNITY_DOTS_DEBUG")]
			private void ErrorWrite(); // 0x0000000181CA51D0-0x0000000181CA5220
			[ExcludeFromBurstCompatTesting("Takes managed string")]
			public int CompareTo(string other); // 0x0000000181CA4BF0-0x0000000181CA4C70
			[ExcludeFromBurstCompatTesting("Takes managed string")]
			public bool Equals(string other); // 0x0000000181CA5140-0x0000000181CA51C0
			public int CompareTo(ReadOnly other); // 0x0000000181CA4C70-0x0000000181CA4C80
			public bool Equals(ReadOnly other); // 0x0000000181CA51C0-0x0000000181CA51D0
			public int CompareTo(NativeText other); // 0x0000000181CA3A40-0x0000000181CA3A50
			public bool Equals(NativeText other); // 0x0000000181CA3B50-0x0000000181CA3B60
			public int CompareTo(FixedString32Bytes other); // 0x0000000181CA3A20-0x0000000181CA3A40
			public static bool operator ==([IsReadOnly] in ReadOnly a, [IsReadOnly] in FixedString32Bytes b); // 0x0000000181CA4D00-0x0000000181CA4D30
			public static bool operator !=([IsReadOnly] in ReadOnly a, [IsReadOnly] in FixedString32Bytes b); // 0x0000000181CA53D0-0x0000000181CA5400
			public bool Equals(FixedString32Bytes other); // 0x0000000181CA4D00-0x0000000181CA4D30
			public int CompareTo(FixedString64Bytes other); // 0x0000000181CA3A20-0x0000000181CA3A40
			public static bool operator ==([IsReadOnly] in ReadOnly a, [IsReadOnly] in FixedString64Bytes b); // 0x0000000181CA4D00-0x0000000181CA4D30
			public static bool operator !=([IsReadOnly] in ReadOnly a, [IsReadOnly] in FixedString64Bytes b); // 0x0000000181CA53D0-0x0000000181CA5400
			public bool Equals(FixedString64Bytes other); // 0x0000000181CA4D00-0x0000000181CA4D30
			public int CompareTo(FixedString128Bytes other); // 0x0000000181CA3A20-0x0000000181CA3A40
			public static bool operator ==([IsReadOnly] in ReadOnly a, [IsReadOnly] in FixedString128Bytes b); // 0x0000000181CA4D00-0x0000000181CA4D30
			public static bool operator !=([IsReadOnly] in ReadOnly a, [IsReadOnly] in FixedString128Bytes b); // 0x0000000181CA53D0-0x0000000181CA5400
			public bool Equals(FixedString128Bytes other); // 0x0000000181CA4D00-0x0000000181CA4D30
			public int CompareTo(FixedString512Bytes other); // 0x0000000181CA3A20-0x0000000181CA3A40
			public static bool operator ==([IsReadOnly] in ReadOnly a, [IsReadOnly] in FixedString512Bytes b); // 0x0000000181CA4D00-0x0000000181CA4D30
			public static bool operator !=([IsReadOnly] in ReadOnly a, [IsReadOnly] in FixedString512Bytes b); // 0x0000000181CA53D0-0x0000000181CA5400
			public bool Equals(FixedString512Bytes other); // 0x0000000181CA4D00-0x0000000181CA4D30
			public int CompareTo(FixedString4096Bytes other); // 0x0000000181CA3A20-0x0000000181CA3A40
			public static bool operator ==([IsReadOnly] in ReadOnly a, [IsReadOnly] in FixedString4096Bytes b); // 0x0000000181CA4D00-0x0000000181CA4D30
			public static bool operator !=([IsReadOnly] in ReadOnly a, [IsReadOnly] in FixedString4096Bytes b); // 0x0000000181CA53D0-0x0000000181CA5400
			public bool Equals(FixedString4096Bytes other); // 0x0000000181CA4D00-0x0000000181CA4D30
			[ExcludeFromBurstCompatTesting("Returns managed string")]
			public override string ToString(); // 0x0000000181CA5340-0x0000000181CA53A0
			public override int GetHashCode(); // 0x0000000181CA3FE0-0x0000000181CA3FF0
			[ExcludeFromBurstCompatTesting("Takes managed object")]
			public override bool Equals(object other); // 0x0000000181CA4D30-0x0000000181CA5140
			public Enumerator GetEnumerator(); // 0x0000000181CA3FC0-0x0000000181CA3FE0
		}
	
		// Constructors
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public unsafe NativeText(string source, Allocator allocator); // 0x0000000181CA42A0-0x0000000181CA4400
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public unsafe NativeText(string source, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CA4500-0x0000000181CA4650
		public unsafe NativeText(int capacity, Allocator allocator); // 0x0000000181CA4160-0x0000000181CA41A0
		public unsafe NativeText(int capacity, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CA4400-0x0000000181CA4500
		public unsafe NativeText(Allocator allocator); // 0x0000000181CA4130-0x0000000181CA4160
		public unsafe NativeText(AllocatorManager.AllocatorHandle allocator); // 0x0000000181CA41A0-0x0000000181CA41B0
		public unsafe NativeText([IsReadOnly] in FixedString32Bytes source, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CA41B0-0x0000000181CA4220
		public unsafe NativeText([IsReadOnly] in FixedString32Bytes source, Allocator allocator); // 0x0000000181CA4220-0x0000000181CA42A0
		public unsafe NativeText([IsReadOnly] in FixedString64Bytes source, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CA41B0-0x0000000181CA4220
		public unsafe NativeText([IsReadOnly] in FixedString64Bytes source, Allocator allocator); // 0x0000000181CA4220-0x0000000181CA42A0
		public unsafe NativeText([IsReadOnly] in FixedString128Bytes source, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CA41B0-0x0000000181CA4220
		public unsafe NativeText([IsReadOnly] in FixedString128Bytes source, Allocator allocator); // 0x0000000181CA4220-0x0000000181CA42A0
		public unsafe NativeText([IsReadOnly] in FixedString512Bytes source, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CA41B0-0x0000000181CA4220
		public unsafe NativeText([IsReadOnly] in FixedString512Bytes source, Allocator allocator); // 0x0000000181CA4220-0x0000000181CA42A0
		public unsafe NativeText([IsReadOnly] in FixedString4096Bytes source, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CA41B0-0x0000000181CA4220
		public unsafe NativeText([IsReadOnly] in FixedString4096Bytes source, Allocator allocator); // 0x0000000181CA4220-0x0000000181CA42A0
	
		// Methods
		public bool TryResize(int newLength, NativeArrayOptions clearOptions = NativeArrayOptions.ClearMemory /* Metadata: 0x006A1C46 */); // 0x0000000181CA40F0-0x0000000181CA4130
		public unsafe byte* GetUnsafePtr(); // 0x0000000181CA3FF0-0x0000000181CA4000
		public ref byte ElementAt(int index); // 0x0000000181CA3B40-0x0000000181CA3B50
		public void Clear(); // 0x0000000181CA3970-0x0000000181CA39A0
		public void Add([IsReadOnly] in byte value); // 0x0000000181CA3760-0x0000000181CA37D0
		public int CompareTo(NativeText other); // 0x0000000181CA3A40-0x0000000181CA3A50
		public bool Equals(NativeText other); // 0x0000000181CA3B50-0x0000000181CA3B60
		public int CompareTo(ReadOnly other); // 0x0000000181CA3A50-0x0000000181CA3A70
		public bool Equals(ReadOnly other); // 0x0000000181CA3B50-0x0000000181CA3B60
		public void Dispose(); // 0x0000000181CA3AF0-0x0000000181CA3B40
		public JobHandle Dispose(JobHandle inputDeps); // 0x0000000181CA3A70-0x0000000181CA3AF0
		public Enumerator GetEnumerator(); // 0x0000000181CA3FC0-0x0000000181CA3FE0
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public int CompareTo(string other); // 0x0000000181CA39A0-0x0000000181CA3A20
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public bool Equals(string other); // 0x0000000181CA3F40-0x0000000181CA3FC0
		public int CompareTo(FixedString32Bytes other); // 0x0000000181CA3A20-0x0000000181CA3A40
		public static bool operator ==([IsReadOnly] in NativeText a, [IsReadOnly] in FixedString32Bytes b); // 0x0000000181CA3F10-0x0000000181CA3F40
		public static bool operator !=([IsReadOnly] in NativeText a, [IsReadOnly] in FixedString32Bytes b); // 0x0000000181CA46B0-0x0000000181CA46E0
		public bool Equals(FixedString32Bytes other); // 0x0000000181CA3F10-0x0000000181CA3F40
		public int CompareTo(FixedString64Bytes other); // 0x0000000181CA3A20-0x0000000181CA3A40
		public static bool operator ==([IsReadOnly] in NativeText a, [IsReadOnly] in FixedString64Bytes b); // 0x0000000181CA3F10-0x0000000181CA3F40
		public static bool operator !=([IsReadOnly] in NativeText a, [IsReadOnly] in FixedString64Bytes b); // 0x0000000181CA46B0-0x0000000181CA46E0
		public bool Equals(FixedString64Bytes other); // 0x0000000181CA3F10-0x0000000181CA3F40
		public int CompareTo(FixedString128Bytes other); // 0x0000000181CA3A20-0x0000000181CA3A40
		public static bool operator ==([IsReadOnly] in NativeText a, [IsReadOnly] in FixedString128Bytes b); // 0x0000000181CA3F10-0x0000000181CA3F40
		public static bool operator !=([IsReadOnly] in NativeText a, [IsReadOnly] in FixedString128Bytes b); // 0x0000000181CA46B0-0x0000000181CA46E0
		public bool Equals(FixedString128Bytes other); // 0x0000000181CA3F10-0x0000000181CA3F40
		public int CompareTo(FixedString512Bytes other); // 0x0000000181CA3A20-0x0000000181CA3A40
		public static bool operator ==([IsReadOnly] in NativeText a, [IsReadOnly] in FixedString512Bytes b); // 0x0000000181CA3F10-0x0000000181CA3F40
		public static bool operator !=([IsReadOnly] in NativeText a, [IsReadOnly] in FixedString512Bytes b); // 0x0000000181CA46B0-0x0000000181CA46E0
		public bool Equals(FixedString512Bytes other); // 0x0000000181CA3F10-0x0000000181CA3F40
		public int CompareTo(FixedString4096Bytes other); // 0x0000000181CA3A20-0x0000000181CA3A40
		public static bool operator ==([IsReadOnly] in NativeText a, [IsReadOnly] in FixedString4096Bytes b); // 0x0000000181CA3F10-0x0000000181CA3F40
		public static bool operator !=([IsReadOnly] in NativeText a, [IsReadOnly] in FixedString4096Bytes b); // 0x0000000181CA46B0-0x0000000181CA46E0
		public bool Equals(FixedString4096Bytes other); // 0x0000000181CA3F10-0x0000000181CA3F40
		[ExcludeFromBurstCompatTesting("Returns managed string")]
		public override string ToString(); // 0x0000000181CA4090-0x0000000181CA40F0
		public override int GetHashCode(); // 0x0000000181CA3FE0-0x0000000181CA3FF0
		[ExcludeFromBurstCompatTesting("Takes managed object")]
		public override bool Equals(object other); // 0x0000000181CA3B60-0x0000000181CA3F10
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		internal static unsafe void CheckNull(void* dataPtr); // 0x0000000181CA3910-0x0000000181CA3970
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[IsReadOnly]
		private void CheckRead(); // 0x00000001802E76C0-0x00000001802E76D0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void CheckWrite(); // 0x00000001802E76C0-0x00000001802E76D0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[IsReadOnly]
		private void CheckWriteAndBumpSecondaryVersion(); // 0x00000001802E76C0-0x00000001802E76D0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckIndexInRange(int index); // 0x0000000181CA37D0-0x0000000181CA3910
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void ThrowCopyError(CopyError error, string source); // 0x0000000181CA4000-0x0000000181CA4090
		public ReadOnly AsReadOnly(); // 0x00000001808BADD0-0x00000001808BADE0
	}
}
