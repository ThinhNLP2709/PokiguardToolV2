/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.UI.Collections;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	public class ClipperRegistry // TypeDefIndex: 13017
	{
		// Fields
		private static ClipperRegistry s_Instance; // 0x00
		private readonly IndexedSet<IClipper> m_Clippers; // 0x10
	
		// Properties
		public static ClipperRegistry instance { get; } // 0x0000000182361D00-0x0000000182361E00 
	
		// Constructors
		protected ClipperRegistry(); // 0x0000000182361C80-0x0000000182361D00
	
		// Methods
		public void Cull(); // 0x0000000182361A20-0x0000000182361B50
		public static void Register(IClipper c); // 0x0000000182361BB0-0x0000000182361C20
		public static void Unregister(IClipper c); // 0x0000000182361C20-0x0000000182361C80
		public static void Disable(IClipper c); // 0x0000000182361B50-0x0000000182361BB0
	}
}
