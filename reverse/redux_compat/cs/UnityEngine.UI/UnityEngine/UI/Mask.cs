/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[AddComponentMenu("UI (Canvas)/Mask", 13)]
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[UGUIHelpURL("Mask")]
	public class Mask : UIBehaviour, ICanvasRaycastFilter, IMaterialModifier // TypeDefIndex: 13089
	{
		// Fields
		[NonSerialized]
		private RectTransform m_RectTransform; // 0x20
		[SerializeField]
		private bool m_ShowMaskGraphic; // 0x28
		[NonSerialized]
		private Graphic m_Graphic; // 0x30
		[NonSerialized]
		private Material m_MaskMaterial; // 0x38
		[NonSerialized]
		private Material m_UnmaskMaterial; // 0x40
	
		// Properties
		public RectTransform rectTransform { get; } // 0x00000001825967D0-0x0000000182596840 
		public bool showMaskGraphic { get; set; } // 0x0000000180327270-0x0000000180327280 0x0000000182596840-0x0000000182596920
		public Graphic graphic { get; } // 0x0000000182596760-0x00000001825967D0 
	
		// Constructors
		protected Mask(); // 0x0000000182596750-0x0000000182596760
	
		// Methods
		public virtual bool MaskEnabled(); // 0x00000001825960B0-0x0000000182596170
		[Obsolete("Not used anymore.", true)]
		public virtual void OnSiblingGraphicEnabledDisabled(); // 0x00000001802E76C0-0x00000001802E76D0
		protected override void OnEnable(); // 0x00000001825964D0-0x0000000182596750
		protected override void OnDisable(); // 0x0000000182596170-0x00000001825964D0
		public virtual bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera); // 0x0000000182595FC0-0x00000001825960B0
		public virtual Material GetModifiedMaterial(Material baseMaterial); // 0x0000000182595CB0-0x0000000182595FC0
	}
}
