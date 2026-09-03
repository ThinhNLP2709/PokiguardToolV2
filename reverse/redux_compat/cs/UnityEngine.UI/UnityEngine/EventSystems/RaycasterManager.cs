/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.EventSystems
{
	public static class RaycasterManager // TypeDefIndex: 13207
	{
		// Fields
		private static readonly List<BaseRaycaster> s_Raycasters; // 0x00
	
		// Constructors
		static RaycasterManager(); // 0x00000001825BBE30-0x00000001825BBEC0
	
		// Methods
		internal static void AddRaycaster(BaseRaycaster baseRaycaster); // 0x00000001825BBC10-0x00000001825BBD20
		public static List<BaseRaycaster> GetRaycasters(); // 0x00000001825BBD20-0x00000001825BBD70
		internal static void RemoveRaycasters(BaseRaycaster baseRaycaster); // 0x00000001825BBD70-0x00000001825BBE30
	}
}
