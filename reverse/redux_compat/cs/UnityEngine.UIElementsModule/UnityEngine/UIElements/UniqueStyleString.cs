/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[IsReadOnly]
	public struct UniqueStyleString : IEquatable<UnityEngine.UIElements.UniqueStyleString> // TypeDefIndex: 4874
	{
		// Fields
		public static readonly UniqueStyleString Null; // 0x00
		public static readonly UniqueStyleString Empty; // 0x04
		private static Dictionary<string, int> k_StringToIndex; // 0x08
		private static List<string> k_IndexToString; // 0x10
		private readonly int m_Id; // 0x00
	
		// Properties
		public int id { get; } // 0x0000000180732D10-0x0000000180732D20 
		internal string value { [VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEngine.HierarchyModule" })] get; } // 0x00000001823E0640-0x00000001823E06B0 
	
		// Constructors
		internal UniqueStyleString(int id); // 0x0000000180732D50-0x0000000180732D60
		public UniqueStyleString(string s); // 0x00000001823E0510-0x00000001823E0640
		static UniqueStyleString(); // 0x00000001823E02F0-0x00000001823E0510
	
		// Methods
		public bool IsNullOrEmpty(); // 0x00000001823E0140-0x00000001823E0190
		internal static bool IsNullOrEmpty(int id); // 0x00000001823E0130-0x00000001823E0140
		public static bool TryGet(string value, out UniqueStyleString result); // 0x00000001823E0200-0x00000001823E02F0
		public override string ToString(); // 0x00000001823E0190-0x00000001823E0200
		public override int GetHashCode(); // 0x00000001814330E0-0x00000001814330F0
		public bool Equals(UniqueStyleString other); // 0x00000001815FCAB0-0x00000001815FCAC0
		public override bool Equals(object obj); // 0x00000001823E00A0-0x00000001823E0130
	}
}
