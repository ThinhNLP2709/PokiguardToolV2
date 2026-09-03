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
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal static class WorldSpaceDataStore // TypeDefIndex: 4985
	{
		// Fields
		private static Dictionary<uint, WorldSpaceData> m_WorldSpaceData; // 0x00
	
		// Constructors
		static WorldSpaceDataStore(); // 0x0000000182407580-0x0000000182407610
	
		// Methods
		public static void SetWorldSpaceData(VisualElement ve, WorldSpaceData data); // 0x00000001824074A0-0x0000000182407580
		public static WorldSpaceData GetWorldSpaceData(VisualElement ve); // 0x0000000182407370-0x00000001824074A0
		public static void ClearWorldSpaceData(VisualElement ve); // 0x0000000182407270-0x0000000182407370
		public static void ClearLocalBounds3DData(VisualElement ve); // 0x0000000182407030-0x0000000182407270
	}
}
