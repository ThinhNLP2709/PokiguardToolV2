/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[IsReadOnly]
	public struct BindingId : IEquatable<UnityEngine.UIElements.BindingId> // TypeDefIndex: 4944
	{
		// Fields
		public static readonly BindingId Invalid; // 0x00
		private readonly PropertyPath m_PropertyPath; // 0x00
		private readonly string m_Path; // 0x90
	
		// Constructors
		public BindingId(string path); // 0x00000001823CD290-0x00000001823CD370
		public BindingId([IsReadOnly] in PropertyPath path); // 0x00000001823CD370-0x00000001823CD430
	
		// Methods
		public static implicit operator PropertyPath([IsReadOnly] in BindingId vep); // 0x00000001823CD520-0x00000001823CD570
		public static implicit operator string([IsReadOnly] in BindingId vep); // 0x00000001806CCBA0-0x00000001806CCBB0
		public static implicit operator BindingId(string name); // 0x00000001823CD570-0x00000001823CD690
		public static implicit operator BindingId([IsReadOnly] in PropertyPath path); // 0x00000001823CD430-0x00000001823CD520
		public override string ToString(); // 0x00000001806CCBA0-0x00000001806CCBB0
		public bool Equals(BindingId other); // 0x00000001823CD0A0-0x00000001823CD170
		public override bool Equals(object obj); // 0x00000001823CD170-0x00000001823CD280
		public override int GetHashCode(); // 0x00000001823CD280-0x00000001823CD290
		public static bool operator ==([IsReadOnly] in BindingId lhs, [IsReadOnly] in BindingId rhs); // 0x00000001823CD0A0-0x00000001823CD170
		public static bool operator !=([IsReadOnly] in BindingId lhs, [IsReadOnly] in BindingId rhs); // 0x00000001823CD690-0x00000001823CD770
	}
}
