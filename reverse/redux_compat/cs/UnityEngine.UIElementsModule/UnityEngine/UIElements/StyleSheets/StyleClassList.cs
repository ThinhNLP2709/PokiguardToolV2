/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Unmanaged;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.StyleSheets
{
	[DefaultMember("Item")]
	internal struct StyleClassList : IEnumerable<UniqueStyleString> // TypeDefIndex: 5236
	{
		// Fields
		private static readonly MemoryLabel k_MemoryLabel; // 0x00
		private static ComponentDataStore s_Records; // 0x10
		private static unsafe Record* s_EmptyRecordPtr; // 0x40
		private static int s_RecordCount; // 0x48
		private static UnmanagedBlock<int> s_RecordSortedIdPool; // 0x50
		private static int s_RecordSortedIdCount; // 0x60
		private static Dictionary<int, StyleClassList> s_HashToFirstRecord; // 0x68
		private unsafe Record* m_Record; // 0x00
	
		// Properties
		public static StyleClassList Empty { get; } // 0x0000000182455C70-0x0000000182455CC0 
		private ref Record record { [IsReadOnly] get; } // 0x00000001808BADD0-0x00000001808BADE0 
		public int Count { [IsReadOnly] get; } // 0x0000000182455C00-0x0000000182455C70 
	
		// Nested types
		private struct Record // TypeDefIndex: 5237
		{
			// Fields
			public static readonly Record k_Empty; // 0x00
			private readonly int m_IdPoolStart; // 0x00
			private readonly int m_Count; // 0x04
			internal unsafe Record* m_NextRecordWithSameHash; // 0x08
			internal readonly int m_Hash; // 0x10
	
			// Properties
			public int Count { get; } // 0x00000001802E7C60-0x00000001802E7DA0 
			private int this[int index] { get => default; } // 0x00000001824505C0-0x0000000182450660 
	
			// Constructors
			private unsafe Record(int idPoolStart, int count, int hash); // 0x00000001824505A0-0x00000001824505C0
			static Record(); // 0x0000000182450540-0x00000001824505A0
	
			// Methods
			public ReadOnlySpan<int> GetClassIds(); // 0x000000018244F7D0-0x000000018244F920
			internal int GetClassIdStartOffset(); // 0x0000000180732D10-0x0000000180732D20
			private static Span<int> Alloc(int count, out int idPoolStart); // 0x000000018244F160-0x000000018244F2D0
			public static Record MakeWithAdded(Record record, UniqueStyleString addedClassName, int insertIndex, int hash); // 0x000000018244F940-0x000000018244FBB0
			public static Record MakeWithAdded(Record record, ReadOnlySpan<UniqueStyleString> addedClassNames, ReadOnlySpan<int> insertIndices, int hash); // 0x000000018244FBB0-0x000000018244FF10
			public static Record MakeWithRemoved(Record record, int removeIndex, int hash); // 0x000000018244FF10-0x0000000182450160
			public bool Contains(UniqueStyleString className); // 0x000000018244F530-0x000000018244F5B0
			public bool Find(UniqueStyleString className, out int index); // 0x000000018244F720-0x000000018244F7D0
			private int BinarySearch(int classId); // 0x000000018244F2D0-0x000000018244F3F0
			public bool MatchesWithAdded(Record record, UniqueStyleString addedClassName, int insertIndex); // 0x0000000182450320-0x0000000182450450
			public bool MatchesWithAdded(Record record, ReadOnlySpan<UniqueStyleString> addedClassNames, ReadOnlySpan<int> insertIndices); // 0x0000000182450160-0x0000000182450320
			public bool MatchesWithRemoved(Record record, int removeIndex); // 0x0000000182450450-0x0000000182450540
			private bool CompareSpan(int selfStart, Record record, int recordStart, int count); // 0x000000018244F3F0-0x000000018244F530
			private static void CopySpan(Span<int> self, int selfStart, Record record, int recordStart, int count); // 0x000000018244F5B0-0x000000018244F720
			public Enumerator GetEnumerator(); // 0x000000018244F920-0x000000018244F940
		}
	
		internal struct Enumerator : IEnumerator<UniqueStyleString> // TypeDefIndex: 5238
		{
			// Fields
			private readonly int m_Start; // 0x00
			private readonly int m_Count; // 0x04
			private int i; // 0x08
	
			// Properties
			public UniqueStyleString Current { get; } // 0x000000018244EC90-0x000000018244ED30 
			UniqueStyleString IEnumerator<UnityEngine.UIElements.UniqueStyleString>.Current { get; } // 0x000000018244EC20-0x000000018244EC30 
			object IEnumerator.Current { get; } // 0x000000018244EC30-0x000000018244EC80 
	
			// Constructors
			internal Enumerator(int start, int count); // 0x000000018244EC80-0x000000018244EC90
	
			// Methods
			public bool MoveNext(); // 0x000000018244EC10-0x000000018244EC20
			void IEnumerator.Reset(); // 0x000000018112ACA0-0x000000018112ACB0
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		// Constructors
		static unsafe StyleClassList(); // 0x0000000182455AF0-0x0000000182455C00
		private unsafe StyleClassList(Record* record); // 0x0000000180CBE820-0x0000000180CBE830
	
		// Methods
		private static void ResetStaticState(); // 0x0000000182454600-0x0000000182454940
		private static void UpdateNativeClassIdPointer(); // 0x0000000182454B00-0x0000000182454BA0
		[IsReadOnly]
		internal ReadOnlySpan<int> GetClassIds(); // 0x00000001824542B0-0x0000000182454440
		[IsReadOnly]
		internal int GetClassIdStartOffset(); // 0x0000000182454240-0x00000001824542B0
		private static unsafe Record* AllocateRecord(); // 0x0000000182453BE0-0x0000000182453CD0
		public void Clear(); // 0x0000000182453E10-0x0000000182453E70
		public void Add(UniqueStyleString className, out bool added); // 0x0000000182453A80-0x0000000182453BE0
		private void _Add(UniqueStyleString className, int insertIndex); // 0x0000000182455000-0x0000000182455380
		private void _Add(ReadOnlySpan<UniqueStyleString> classNames, ReadOnlySpan<int> insertIndices); // 0x0000000182455380-0x00000001824557D0
		public void Remove(UniqueStyleString className, out bool removed); // 0x00000001824544E0-0x0000000182454600
		private void _Remove(UniqueStyleString className, int removeIndex); // 0x00000001824557D0-0x0000000182455AF0
		public void AddRange(ReadOnlySpan<UniqueStyleString> classNames, out bool added); // 0x0000000182453A00-0x0000000182453A80
		private void _AddRange(ReadOnlySpan<UniqueStyleString> classNames, out bool added); // 0x0000000182454BA0-0x0000000182455000
		public void Enable(UniqueStyleString className, bool enable, out bool changed); // 0x0000000182453F60-0x0000000182454240
		[IsReadOnly]
		public bool Contains(UniqueStyleString className); // 0x0000000182453E70-0x0000000182453F60
		[IsReadOnly]
		public Enumerator GetEnumerator(); // 0x0000000182454440-0x00000001824544E0
		IEnumerator<UniqueStyleString> IEnumerable<UniqueStyleString>.GetEnumerator(); // 0x0000000182454940-0x0000000182454A20
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000182454A20-0x0000000182454B00
		internal static void ClearInstances(); // 0x0000000182453CD0-0x0000000182453E10
	}
}
