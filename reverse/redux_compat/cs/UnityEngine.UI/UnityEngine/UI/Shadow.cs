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
	[AddComponentMenu("UI (Canvas)/Effects/Shadow", 80)]
	[UGUIHelpURL("Shadow")]
	public class Shadow : BaseMeshEffect // TypeDefIndex: 13143
	{
		// Fields
		[SerializeField]
		private Color m_EffectColor; // 0x28
		[SerializeField]
		private Vector2 m_EffectDistance; // 0x38
		[SerializeField]
		private bool m_UseGraphicAlpha; // 0x40
		private const float kMaxEffectDistance = 600f; // Metadata: 0x006A77AA
	
		// Properties
		public Color effectColor { get; set; } // 0x0000000180C46B90-0x0000000180C46BA0 0x00000001825BD270-0x00000001825BD310
		public Vector2 effectDistance { get; set; } // 0x0000000181FFE190-0x0000000181FFE1B0 0x00000001825BD310-0x00000001825BD410
		public bool useGraphicAlpha { get; set; } // 0x00000001803B1170-0x00000001803B1180 0x00000001825BD410-0x00000001825BD4B0
	
		// Constructors
		protected Shadow(); // 0x00000001825B32B0-0x00000001825B32E0
	
		// Methods
		protected void ApplyShadowZeroAlloc(List<UIVertex> verts, Color32 color, int start, int end, float x, float y); // 0x00000001825BCD40-0x00000001825BD120
		protected void ApplyShadow(List<UIVertex> verts, Color32 color, int start, int end, float x, float y); // 0x00000001825BD120-0x00000001825BD130
		public override void ModifyMesh(VertexHelper vh); // 0x00000001825BD130-0x00000001825BD270
	}
}
