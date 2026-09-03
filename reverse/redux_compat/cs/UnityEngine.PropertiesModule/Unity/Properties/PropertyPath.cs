/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using UnityEngine;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	[IsReadOnly]
	public struct PropertyPath : IEquatable<Unity.Properties.PropertyPath> // TypeDefIndex: 14457
	{
		// Fields
		private readonly PropertyPathPart m_Part0; // 0x00
		private readonly PropertyPathPart m_Part1; // 0x20
		private readonly PropertyPathPart m_Part2; // 0x40
		private readonly PropertyPathPart m_Part3; // 0x60
		private readonly PropertyPathPart[] m_AdditionalParts; // 0x80
		[CompilerGenerated]
		private readonly int _Length_k__BackingField; // 0x88
	
		// Properties
		public int Length { [CompilerGenerated] get; } // 0x000000018033D620-0x000000018033D630 
		public bool IsEmpty { get; } // 0x00000001822E1620-0x00000001822E1630 
		public PropertyPathPart this[int index] { get => default; } // 0x00000001822E1630-0x00000001822E1820 
	
		// Nested types
		[CompilerGenerated]
		private struct __c__DisplayClass36_0 // TypeDefIndex: 14458
		{
			// Fields
			public int index; // 0x00
			public int length; // 0x04
			public string path; // 0x08
			public int state; // 0x10
		}
	
		// Constructors
		public PropertyPath(string path); // 0x00000001822E1180-0x00000001822E1290
		private PropertyPath([IsReadOnly] in PropertyPathPart part); // 0x00000001822E1080-0x00000001822E10F0
		private PropertyPath([IsReadOnly] in PropertyPathPart part0, [IsReadOnly] in PropertyPathPart part1); // 0x00000001822E10F0-0x00000001822E1180
		private PropertyPath([IsReadOnly] in PropertyPathPart part0, [IsReadOnly] in PropertyPathPart part1, [IsReadOnly] in PropertyPathPart part2); // 0x00000001822E1290-0x00000001822E1340
		private PropertyPath([IsReadOnly] in PropertyPathPart part0, [IsReadOnly] in PropertyPathPart part1, [IsReadOnly] in PropertyPathPart part2, [IsReadOnly] in PropertyPathPart part3); // 0x00000001822E1560-0x00000001822E1620
		internal PropertyPath(List<PropertyPathPart> parts); // 0x00000001822E1340-0x00000001822E1560
	
		// Methods
		public static PropertyPath Combine([IsReadOnly] in PropertyPath path, [IsReadOnly] in PropertyPath pathToAppend); // 0x00000001822DDFB0-0x00000001822DE870
		public static PropertyPath AppendPart([IsReadOnly] in PropertyPath path, [IsReadOnly] in PropertyPathPart part); // 0x00000001822DD4C0-0x00000001822DDBD0
		public static PropertyPath AppendIndex([IsReadOnly] in PropertyPath path, int index); // 0x00000001822DD3C0-0x00000001822DD4C0
		public static PropertyPath AppendProperty([IsReadOnly] in PropertyPath path, IProperty property); // 0x00000001822DDBD0-0x00000001822DDEF0
		public static PropertyPath Pop([IsReadOnly] in PropertyPath path); // 0x00000001822E0020-0x00000001822E00B0
		public static PropertyPath SubPath([IsReadOnly] in PropertyPath path, int startIndex, int length); // 0x00000001822E00B0-0x00000001822E0C40
		public override string ToString(); // 0x00000001822E0C40-0x00000001822E0EF0
		private static void AppendToBuilder([IsReadOnly] in PropertyPathPart part, StringBuilder builder); // 0x00000001822DDEF0-0x00000001822DDFB0
		private static void GetParts([IsReadOnly] in PropertyPath path, List<PropertyPathPart> parts); // 0x00000001822DFF10-0x00000001822E0020
		private static PropertyPath ConstructFromPath(string path); // 0x00000001822DE870-0x00000001822DFAF0
		public static bool operator ==(PropertyPath lhs, PropertyPath rhs); // 0x00000001822E1820-0x00000001822E1890
		public static bool operator !=(PropertyPath lhs, PropertyPath rhs); // 0x00000001822E1890-0x00000001822E1970
		public bool Equals(PropertyPath other); // 0x00000001822DFAF0-0x00000001822DFC20
		public override bool Equals(object obj); // 0x00000001822DFC20-0x00000001822DFD20
		public override int GetHashCode(); // 0x00000001822DFD20-0x00000001822DFF10
		[CompilerGenerated]
		internal static void _ConstructFromPath_g__TrimStart_36_0(ref __c__DisplayClass36_0 param_0001b75f); // 0x00000001822E1040-0x00000001822E1080
		[CompilerGenerated]
		internal static void _ConstructFromPath_g__ReadNext_36_1(ref __c__DisplayClass36_0 param_0001b760); // 0x00000001822E0EF0-0x00000001822E1040
	}
}
