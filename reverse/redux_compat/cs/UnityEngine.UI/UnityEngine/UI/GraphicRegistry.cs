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
using UnityEngine.UI.Collections;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	public class GraphicRegistry // TypeDefIndex: 13039
	{
		// Fields
		private static GraphicRegistry s_Instance; // 0x00
		private readonly Dictionary<Canvas, IndexedSet<Graphic>> m_Graphics; // 0x10
		private readonly Dictionary<Canvas, IndexedSet<Graphic>> m_RaycastableGraphics; // 0x18
		private static readonly List<Graphic> s_EmptyList; // 0x08
	
		// Properties
		public static GraphicRegistry instance { get; } // 0x000000018236DDA0-0x000000018236DFC0 
	
		// Constructors
		protected GraphicRegistry(); // 0x000000018236DC10-0x000000018236DDA0
		static GraphicRegistry(); // 0x000000018236DB80-0x000000018236DC10
	
		// Methods
		public static void RegisterGraphicForCanvas(Canvas c, Graphic graphic); // 0x000000018236D530-0x000000018236D6F0
		public static void RegisterRaycastGraphicForCanvas(Canvas c, Graphic graphic); // 0x000000018236D6F0-0x000000018236D8D0
		public static void UnregisterGraphicForCanvas(Canvas c, Graphic graphic); // 0x000000018236D8D0-0x000000018236DA30
		public static void UnregisterRaycastGraphicForCanvas(Canvas c, Graphic graphic); // 0x000000018236DA30-0x000000018236DB80
		public static void DisableGraphicForCanvas(Canvas c, Graphic graphic); // 0x000000018236CFD0-0x000000018236D270
		public static void DisableRaycastGraphicForCanvas(Canvas c, Graphic graphic); // 0x000000018236D270-0x000000018236D3D0
		public static IList<Graphic> GetGraphicsForCanvas(Canvas canvas); // 0x000000018236D3D0-0x000000018236D480
		public static IList<Graphic> GetRaycastableGraphicsForCanvas(Canvas canvas); // 0x000000018236D480-0x000000018236D530
	}
}
