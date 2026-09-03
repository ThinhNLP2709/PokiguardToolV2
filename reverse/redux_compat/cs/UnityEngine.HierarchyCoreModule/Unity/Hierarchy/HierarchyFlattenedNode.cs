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
	[NativeHeader("Modules/HierarchyCore/Public/HierarchyFlattenedNode.h")]
	public struct HierarchyFlattenedNode : IEquatable<Unity.Hierarchy.HierarchyFlattenedNode> // TypeDefIndex: 15653
	{
		// Fields
		private static readonly HierarchyFlattenedNode s_Null; // 0x00
		private readonly HierarchyNode m_Node; // 0x00
		private readonly HierarchyNodeType m_Type; // 0x08
		private readonly int m_Version; // 0x0C
		private readonly int m_ParentOffset; // 0x10
		private readonly int m_NextSiblingOffset; // 0x14
		private readonly int m_ChildIndex; // 0x18
		private readonly int m_ChildrenCount; // 0x1C
		private readonly int m_Depth; // 0x20
	
		// Properties
		[IsReadOnly]
		public static ref HierarchyFlattenedNode Null { get; } // 0x00000001822722B0-0x00000001822722F0 
		public HierarchyNode Node { get; } // 0x00000001808BADD0-0x00000001808BADE0 
	
		// Constructors
		public HierarchyFlattenedNode(); // 0x0000000182272230-0x00000001822722B0
	
		// Methods
		[ExcludeFromDocs]
		public static bool operator ==([IsReadOnly] in HierarchyFlattenedNode lhs, [IsReadOnly] in HierarchyFlattenedNode rhs); // 0x00000001822722F0-0x0000000182272310
		[ExcludeFromDocs]
		public bool Equals(HierarchyFlattenedNode other); // 0x0000000182271FF0-0x0000000182272010
		[ExcludeFromDocs]
		public override string ToString(); // 0x0000000182272110-0x0000000182272230
		[ExcludeFromDocs]
		public override bool Equals(object obj); // 0x0000000182272010-0x00000001822720B0
		[ExcludeFromDocs]
		public override int GetHashCode(); // 0x00000001822720B0-0x0000000182272110
	}
}
