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
	internal sealed class GUIScrollGroup : GUILayoutGroup // TypeDefIndex: 13948
	{
		// Fields
		public float calcMinWidth; // 0x90
		public float calcMaxWidth; // 0x94
		public float calcMinHeight; // 0x98
		public float calcMaxHeight; // 0x9C
		public float clientWidth; // 0xA0
		public float clientHeight; // 0xA4
		public bool allowHorizontalScroll; // 0xA8
		public bool allowVerticalScroll; // 0xA9
		public bool needsHorizontalScrollbar; // 0xAA
		public bool needsVerticalScrollbar; // 0xAB
		public GUIStyle horizontalScrollbar; // 0xB0
		public GUIStyle verticalScrollbar; // 0xB8
	
		// Constructors
		[RequiredByNativeCode]
		public GUIScrollGroup(); // 0x000000018229E2A0-0x000000018229E400
	
		// Methods
		public override void CalcWidth(); // 0x000000018229DDD0-0x000000018229DE70
		public override void SetHorizontal(float x, float width); // 0x000000018229DE70-0x000000018229E000
		public override void CalcHeight(); // 0x000000018229DCB0-0x000000018229DDD0
		public override void SetVertical(float y, float height); // 0x000000018229E000-0x000000018229E2A0
	}
}
