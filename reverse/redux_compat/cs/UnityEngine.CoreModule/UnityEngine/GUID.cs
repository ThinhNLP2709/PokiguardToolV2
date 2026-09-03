/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.Scripting.APIUpdating;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[Serializable]
	[MovedFrom(true, "UnityEditor", "UnityEditor", null)]
	[NativeHeader("Runtime/Utilities/GUID.h")]
	[RequiredByNativeCode]
	public struct GUID : IComparable, IComparable<UnityEngine.GUID>, IEquatable<UnityEngine.GUID> // TypeDefIndex: 7756
	{
		// Fields
		private uint m_Value0; // 0x00
		private uint m_Value1; // 0x04
		private uint m_Value2; // 0x08
		private uint m_Value3; // 0x0C
	
		// Methods
		public static bool operator ==(GUID x, GUID y); // 0x00000001815FB130-0x00000001815FB160
		public static bool operator <(GUID x, GUID y); // 0x00000001821E7780-0x00000001821E77A0
		public static bool operator >(GUID x, GUID y); // 0x00000001821E76F0-0x00000001821E7780
		public override bool Equals(object obj); // 0x00000001821E74C0-0x00000001821E7570
		public bool Equals(GUID obj); // 0x00000001821E7570-0x00000001821E75B0
		public override int GetHashCode(); // 0x00000001821E76C0-0x00000001821E76E0
		public int CompareTo(object obj); // 0x00000001821E7350-0x00000001821E73E0
		public int CompareTo(GUID rhs); // 0x00000001821E73E0-0x00000001821E74C0
		public override string ToString(); // 0x00000001821E76E0-0x00000001821E76F0
		[NativeMethod(Name = "GUIDToString", IsFreeFunction = true, IsThreadSafe = true)]
		private static string GUIDToHexInternal(ref GUID value); // 0x00000001821E7600-0x00000001821E76C0
		private static void GUIDToHexInternal_Injected(ref GUID value, ); // 0x00000001821E75B0-0x00000001821E7600
	}
}
