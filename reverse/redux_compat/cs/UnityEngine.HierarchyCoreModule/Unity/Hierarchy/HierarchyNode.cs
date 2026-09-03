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
	[NativeHeader("Modules/HierarchyCore/Public/HierarchyNode.h")]
	public struct HierarchyNode : IEquatable<Unity.Hierarchy.HierarchyNode> // TypeDefIndex: 15654
	{
		// Fields
		private static readonly HierarchyNode s_Null; // 0x00
		private readonly int m_Id; // 0x00
		private readonly int m_Version; // 0x04
	
		// Properties
		[IsReadOnly]
		public static ref HierarchyNode Null { get; } // 0x00000001822747A0-0x00000001822747E0 
		public int Id { get; } // 0x0000000180732D10-0x0000000180732D20 
		public int Version { get; } // 0x00000001802E7C60-0x00000001802E7DA0 
	
		// Constructors
		public HierarchyNode(); // 0x0000000182274790-0x00000001822747A0
	
		// Methods
		[ExcludeFromDocs]
		public static bool operator ==([IsReadOnly] in HierarchyNode lhs, [IsReadOnly] in HierarchyNode rhs); // 0x00000001821FC0B0-0x00000001821FC0D0
		[ExcludeFromDocs]
		public bool Equals(HierarchyNode other); // 0x0000000182274600-0x0000000182274620
		[ExcludeFromDocs]
		public override string ToString(); // 0x0000000182274680-0x0000000182274790
		[ExcludeFromDocs]
		public override bool Equals(object obj); // 0x0000000182274570-0x0000000182274600
		[ExcludeFromDocs]
		public override int GetHashCode(); // 0x0000000182274620-0x0000000182274680
	}
}
