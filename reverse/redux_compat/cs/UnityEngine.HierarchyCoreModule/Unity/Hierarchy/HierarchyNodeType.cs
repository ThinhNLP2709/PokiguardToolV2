/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;

// Image 56: UnityEngine.HierarchyCoreModule.dll - Assembly: UnityEngine.HierarchyCoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15636-15666

namespace Unity.Hierarchy
{
	[IsReadOnly]
	[NativeHeader("Modules/HierarchyCore/Public/HierarchyNodeType.h")]
	public struct HierarchyNodeType : IEquatable<Unity.Hierarchy.HierarchyNodeType> // TypeDefIndex: 15656
	{
		// Fields
		private static readonly HierarchyNodeType s_Null; // 0x00
		private readonly int m_Id; // 0x00
	
		// Properties
		[IsReadOnly]
		public static ref HierarchyNodeType Null { get; } // 0x0000000182274530-0x0000000182274570 
		public int Id { get; } // 0x0000000180732D10-0x0000000180732D20 
	
		// Methods
		[ExcludeFromDocs]
		public static bool operator ==([IsReadOnly] in HierarchyNodeType lhs, [IsReadOnly] in HierarchyNodeType rhs); // 0x000000018216CF90-0x000000018216CFA0
		[ExcludeFromDocs]
		public bool Equals(HierarchyNodeType other); // 0x00000001822743B0-0x00000001822743C0
		[ExcludeFromDocs]
		public override string ToString(); // 0x0000000182274460-0x0000000182274530
		[ExcludeFromDocs]
		public override bool Equals(object obj); // 0x00000001822743C0-0x0000000182274440
		[ExcludeFromDocs]
		public override int GetHashCode(); // 0x0000000182274440-0x0000000182274460
	}
}
