/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 56: UnityEngine.HierarchyCoreModule.dll - Assembly: UnityEngine.HierarchyCoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15636-15666

namespace Unity.Hierarchy
{
	[Serializable]
	[NativeAsStruct]
	[NativeHeader("Modules/HierarchyCore/Public/HierarchySearch.h")]
	[RequiredByNativeCode]
	public sealed class HierarchySearchQueryDescriptor // TypeDefIndex: 15659
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static readonly HashSet<string> s_SystemFilters; // 0x00
		[NoAutoStaticsCleanup]
		private static readonly HierarchySearchQueryDescriptor s_Empty; // 0x08
		[NoAutoStaticsCleanup]
		private static readonly HierarchySearchQueryDescriptor s_InvalidQuery; // 0x10
		private string m_Query; // 0x10
		[CompilerGenerated]
		private HierarchySearchFilter[] _SystemFilters_k__BackingField; // 0x18
		[CompilerGenerated]
		private HierarchySearchFilter[] _Filters_k__BackingField; // 0x20
		[CompilerGenerated]
		private string[] _TextValues_k__BackingField; // 0x28
		[CompilerGenerated]
		private bool _Strict_k__BackingField; // 0x30
		[CompilerGenerated]
		private bool _Invalid_k__BackingField; // 0x31
	
		// Properties
		public HierarchySearchFilter[] SystemFilters { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public HierarchySearchFilter[] Filters { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public string[] TextValues { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public bool Strict { [CompilerGenerated] set; } // 0x00000001802E8960-0x00000001802E8970
		public bool Invalid { [CompilerGenerated] set; } // 0x0000000181B14860-0x0000000181B14870
		public string Query { get; } // 0x0000000182275320-0x00000001822753C0 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 15660
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<HierarchySearchFilter, bool> __9__36_0; // 0x08
			public static Func<HierarchySearchFilter, bool> __9__36_1; // 0x10
	
			// Constructors
			static __c(); // 0x0000000182276940-0x00000001822769B0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _.ctor_b__36_0(HierarchySearchFilter f); // 0x00000001822767E0-0x0000000182276890
			internal bool _.ctor_b__36_1(HierarchySearchFilter f); // 0x0000000182276890-0x0000000182276940
		}
	
		// Constructors
		public HierarchySearchQueryDescriptor(HierarchySearchFilter[] filters = null, string[] textValues = null); // 0x0000000182275580-0x0000000182275970
		static HierarchySearchQueryDescriptor(); // 0x00000001822753C0-0x0000000182275580
	
		// Methods
		public override string ToString(); // 0x0000000182275320-0x00000001822753C0
		internal string BuildFilterQuery(); // 0x0000000182274D60-0x0000000182274DB0
		internal string BuildSystemFilterQuery(); // 0x0000000182275100-0x0000000182275150
		internal string BuildTextQuery(); // 0x0000000182275150-0x0000000182275320
		internal string BuildQuery(); // 0x0000000182274DB0-0x0000000182275100
		private static T[] Where<T>(IEnumerable<T> src, Func<T, bool> pred);
	}
}
