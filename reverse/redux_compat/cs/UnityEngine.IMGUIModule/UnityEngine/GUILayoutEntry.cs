/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;

// Image 23: UnityEngine.IMGUIModule.dll - Assembly: UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13910-13956

namespace UnityEngine
{
	[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
	internal class GUILayoutEntry // TypeDefIndex: 13945
	{
		// Fields
		public float minWidth; // 0x10
		public float maxWidth; // 0x14
		public float minHeight; // 0x18
		public float maxHeight; // 0x1C
		public Rect rect; // 0x20
		public int stretchWidth; // 0x30
		public int stretchHeight; // 0x34
		public bool consideredForMargin; // 0x38
		private GUIStyle m_Style; // 0x40
		internal static readonly Rect kDummyRect; // 0x00
		[NoAutoStaticsCleanup]
		protected static int indent; // 0x10
	
		// Properties
		public GUIStyle style { get; set; } // 0x0000000180377940-0x0000000180377950 0x000000018227C150-0x000000018227C1A0
		public virtual int marginLeft { get; } // 0x000000018227C070-0x000000018227C0A0 
		public virtual int marginRight { get; } // 0x000000018227C0A0-0x000000018227C0D0 
		public virtual int marginTop { get; } // 0x000000018227C0D0-0x000000018227C100 
		public virtual int marginBottom { get; } // 0x000000018227BFF0-0x000000018227C020 
		public int marginHorizontal { get; } // 0x000000018227C020-0x000000018227C070 
		public int marginVertical { get; } // 0x000000018227C100-0x000000018227C150 
	
		// Constructors
		public GUILayoutEntry(float _minWidth, float _maxWidth, float _minHeight, float _maxHeight, GUIStyle _style); // 0x000000018227BDE0-0x000000018227BEE0
		public GUILayoutEntry(float _minWidth, float _maxWidth, float _minHeight, float _maxHeight, GUIStyle _style, GUILayoutOption[] options); // 0x000000018227BEE0-0x000000018227BFF0
		static GUILayoutEntry(); // 0x000000018227BD80-0x000000018227BDE0
	
		// Methods
		public virtual void CalcWidth(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void CalcHeight(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void SetHorizontal(float x, float width); // 0x000000018227B6E0-0x000000018227B750
		public virtual void SetVertical(float y, float height); // 0x000000018227B750-0x000000018227B7C0
		protected virtual void ApplyStyleSettings(GUIStyle style); // 0x000000018227B4B0-0x000000018227B6E0
		public virtual void ApplyOptions(GUILayoutOption[] options); // 0x000000018227B120-0x000000018227B4B0
		public override string ToString(); // 0x000000018227B7C0-0x000000018227BD80
	}
}
