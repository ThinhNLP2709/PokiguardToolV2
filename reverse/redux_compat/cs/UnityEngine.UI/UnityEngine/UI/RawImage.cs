/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Serialization;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[AddComponentMenu("UI (Canvas)/Raw Image", 12)]
	[RequireComponent(typeof(CanvasRenderer))]
	[UGUIHelpURL("RawImage")]
	public class RawImage : MaskableGraphic // TypeDefIndex: 13098
	{
		// Fields
		[FormerlySerializedAs("m_Tex")]
		[SerializeField]
		private Texture m_Texture; // 0xE0
		[SerializeField]
		private Rect m_UVRect; // 0xE8
	
		// Properties
		public override Texture mainTexture { get; } // 0x000000018259A270-0x000000018259A400 
		public Texture texture { get; set; } // 0x00000001806CCB80-0x00000001806CCB90 0x000000018259A410-0x000000018259A4D0
		public Rect uvRect { get; set; } // 0x000000018259A400-0x000000018259A410 0x000000018259A4D0-0x000000018259A5A0
	
		// Constructors
		protected RawImage(); // 0x000000018259A250-0x000000018259A270
	
		// Methods
		public override void SetNativeSize(); // 0x000000018259A0B0-0x000000018259A250
		protected override void OnPopulateMesh(VertexHelper vh); // 0x0000000182599C00-0x000000018259A0B0
		protected override void OnDidApplyAnimationProperties(); // 0x0000000182376A90-0x0000000182376AE0
	}
}
