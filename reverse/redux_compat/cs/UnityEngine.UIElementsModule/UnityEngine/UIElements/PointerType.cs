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
	public static class PointerType // TypeDefIndex: 4102
	{
		// Fields
		public static readonly string mouse; // 0x00
		public static readonly string touch; // 0x08
		public static readonly string pen; // 0x10
		public static readonly string tracked; // 0x18
		public static readonly string unknown; // 0x20
	
		// Constructors
		static PointerType(); // 0x00000001824A6E20-0x00000001824A6F90
	
		// Methods
		internal static string GetPointerType(int pointerId); // 0x00000001824A6C50-0x00000001824A6DB0
		internal static bool IsDirectManipulationDevice(string pointerType); // 0x00000001824A6DB0-0x00000001824A6E20
	}
}
