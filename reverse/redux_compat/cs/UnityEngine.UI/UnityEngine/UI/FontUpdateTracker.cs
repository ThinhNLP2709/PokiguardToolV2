/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	public static class FontUpdateTracker // TypeDefIndex: 13034
	{
		// Fields
		private static readonly Dictionary<Font, HashSet<Text>> m_Tracked; // 0x00
	
		// Constructors
		static FontUpdateTracker(); // 0x000000018236B820-0x000000018236B8B0
	
		// Methods
		public static void TrackText(Text t); // 0x000000018236B3F0-0x000000018236B620
		private static void RebuildForFont(Font f); // 0x000000018236B210-0x000000018236B3F0
		public static void UntrackText(Text t); // 0x000000018236B620-0x000000018236B820
	}
}
