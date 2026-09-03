/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
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
	[NativeHeader("Modules/HierarchyCore/Public/HierarchySearch.h")]
	[RequiredByNativeCode]
	public struct HierarchySearchFilter // TypeDefIndex: 15658
	{
		// Fields
		private static readonly char[] s_WhiteSpaces; // 0x00
		[NoAutoStaticsCleanup]
		private static readonly HierarchySearchFilter s_Invalid; // 0x08
		[CompilerGenerated]
		private string _Name_k__BackingField; // 0x00
		[CompilerGenerated]
		private string _Value_k__BackingField; // 0x08
		[CompilerGenerated]
		private HierarchySearchFilterOperator _Op_k__BackingField; // 0x10
	
		// Properties
		[IsReadOnly]
		public static ref HierarchySearchFilter Invalid { get; } // 0x0000000182274CC0-0x0000000182274D10 
		public bool IsValid { get; } // 0x0000000182274D10-0x0000000182274D60 
		public string Name { [CompilerGenerated] [IsReadOnly] get; } // 0x00000001808BADD0-0x00000001808BADE0 
		public string Value { [CompilerGenerated] [IsReadOnly] get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
		public HierarchySearchFilterOperator Op { [IsReadOnly] [CompilerGenerated] get; } // 0x00000001802E64B0-0x00000001802E64C0 
	
		// Constructors
		static HierarchySearchFilter(); // 0x0000000182274C30-0x0000000182274CC0
	
		// Methods
		public static string ToString(HierarchySearchFilterOperator op); // 0x00000001822748A0-0x0000000182274A40
		public override string ToString(); // 0x0000000182274A40-0x0000000182274C30
		internal static string QuoteStringIfNeeded(string s); // 0x00000001822747E0-0x00000001822748A0
	}
}
