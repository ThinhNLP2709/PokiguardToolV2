/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 23: UnityEngine.IMGUIModule.dll - Assembly: UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13910-13956

namespace UnityEngine
{
	internal class ScrollViewState // TypeDefIndex: 13952
	{
		// Fields
		public Rect position; // 0x10
		public Rect visibleRect; // 0x20
		public Rect viewRect; // 0x30
		public Vector2 scrollPosition; // 0x40
		public bool apply; // 0x48
		public bool isDuringTouchScroll; // 0x49
		public Vector2 touchScrollStartMousePosition; // 0x4C
		public Vector2 touchScrollStartPosition; // 0x54
		public Vector2 velocity; // 0x5C
		public float previousTimeSinceStartup; // 0x64
	
		// Constructors
		[RequiredByNativeCode]
		public ScrollViewState(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public bool ScrollTowards(Rect pos, float maxDelta); // 0x000000018229ED40-0x000000018229EEE0
		private Vector2 ScrollNeeded(Rect pos); // 0x000000018229EB40-0x000000018229ED40
	}
}
