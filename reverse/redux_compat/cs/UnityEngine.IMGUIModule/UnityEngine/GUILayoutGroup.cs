/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;

// Image 23: UnityEngine.IMGUIModule.dll - Assembly: UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13910-13956

namespace UnityEngine
{
	[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEditor.CoreModule" })]
	internal class GUILayoutGroup : GUILayoutEntry // TypeDefIndex: 13947
	{
		// Fields
		public List<GUILayoutEntry> entries; // 0x48
		public bool isVertical; // 0x50
		public bool resetCoords; // 0x51
		public float spacing; // 0x54
		public bool sameSize; // 0x58
		public bool isWindow; // 0x59
		public int windowID; // 0x5C
		private int m_Cursor; // 0x60
		protected int m_StretchableCountX; // 0x64
		protected int m_StretchableCountY; // 0x68
		protected bool m_UserSpecifiedWidth; // 0x6C
		protected bool m_UserSpecifiedHeight; // 0x6D
		protected float m_ChildMinWidth; // 0x70
		protected float m_ChildMaxWidth; // 0x74
		protected float m_ChildMinHeight; // 0x78
		protected float m_ChildMaxHeight; // 0x7C
		protected int m_MarginLeft; // 0x80
		protected int m_MarginRight; // 0x84
		protected int m_MarginTop; // 0x88
		protected int m_MarginBottom; // 0x8C
		[NoAutoStaticsCleanup]
		private static readonly GUILayoutEntry none; // 0x00
	
		// Properties
		public override int marginLeft { get; } // 0x0000000180CC3A10-0x0000000180CC3A20 
		public override int marginRight { get; } // 0x0000000180BE5CE0-0x0000000180BE5CF0 
		public override int marginTop { get; } // 0x000000018033D620-0x000000018033D630 
		public override int marginBottom { get; } // 0x000000018033D640-0x000000018033D650 
	
		// Constructors
		public GUILayoutGroup(); // 0x000000018229DB90-0x000000018229DCB0
		static GUILayoutGroup(); // 0x000000018229DAB0-0x000000018229DB90
	
		// Methods
		public override void ApplyOptions(GUILayoutOption[] options); // 0x000000018229B680-0x000000018229B780
		protected override void ApplyStyleSettings(GUIStyle style); // 0x000000018229B780-0x000000018229B800
		public void ResetCursor(); // 0x00000001806BAF10-0x00000001806BAF20
		public GUILayoutEntry GetNext(); // 0x000000018229C4B0-0x000000018229C760
		public void Add(GUILayoutEntry e); // 0x000000018229B5D0-0x000000018229B680
		public override void CalcWidth(); // 0x000000018229BE20-0x000000018229C4B0
		public override void SetHorizontal(float x, float width); // 0x000000018229C760-0x000000018229CF40
		public override void CalcHeight(); // 0x000000018229B800-0x000000018229BE20
		public override void SetVertical(float y, float height); // 0x000000018229CF40-0x000000018229D740
		public override string ToString(); // 0x000000018229D740-0x000000018229DAB0
	}
}
