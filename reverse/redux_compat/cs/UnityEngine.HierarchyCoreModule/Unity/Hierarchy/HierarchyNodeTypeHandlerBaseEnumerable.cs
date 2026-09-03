/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 56: UnityEngine.HierarchyCoreModule.dll - Assembly: UnityEngine.HierarchyCoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15636-15666

namespace Unity.Hierarchy
{
	[IsReadOnly]
	public struct HierarchyNodeTypeHandlerBaseEnumerable // TypeDefIndex: 15643
	{
		// Fields
		private readonly Hierarchy m_Hierarchy; // 0x00
	
		// Nested types
		public struct Enumerator : IDisposable // TypeDefIndex: 15644
		{
			// Fields
			private readonly IntPtr[] m_Handlers; // 0x00
			private readonly int m_Count; // 0x08
			private int m_Index; // 0x0C
	
			// Properties
			public HierarchyNodeTypeHandlerBase Current { get; } // 0x0000000182271C30-0x0000000182271CA0 
	
			// Constructors
			internal Enumerator(Hierarchy hierarchy); // 0x0000000182271A50-0x0000000182271C30
	
			// Methods
			public void Dispose(); // 0x0000000182271990-0x0000000182271A50
			public bool MoveNext(); // 0x0000000181129820-0x0000000181129830
		}
	
		// Constructors
		internal HierarchyNodeTypeHandlerBaseEnumerable(Hierarchy hierarchy); // 0x0000000180E02C90-0x0000000180E02CA0
	
		// Methods
		public Enumerator GetEnumerator(); // 0x00000001822727C0-0x00000001822727F0
	}
}
