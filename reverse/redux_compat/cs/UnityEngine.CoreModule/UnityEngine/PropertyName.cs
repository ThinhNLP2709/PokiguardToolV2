/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[UsedByNativeCode]
	public struct PropertyName : IEquatable<UnityEngine.PropertyName> // TypeDefIndex: 7694
	{
		// Fields
		internal int id; // 0x00
	
		// Constructors
		public PropertyName(string name); // 0x00000001821F6850-0x00000001821F6870
		public PropertyName(PropertyName other); // 0x0000000180732D50-0x0000000180732D60
		public PropertyName(int id); // 0x0000000180732D50-0x0000000180732D60
	
		// Methods
		public static bool IsNullOrEmpty(PropertyName prop); // 0x00000001821F67E0-0x00000001821F67F0
		public static bool operator ==(PropertyName lhs, PropertyName rhs); // 0x0000000180A2DD00-0x0000000180A2DD10
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
		public override bool Equals(object other); // 0x00000001821F6760-0x00000001821F67E0
		public bool Equals(PropertyName other); // 0x00000001815FCAB0-0x00000001815FCAC0
		public static implicit operator PropertyName(string name); // 0x00000001821F6870-0x00000001821F6880
		public override string ToString(); // 0x00000001821F67F0-0x00000001821F6850
	}
}
