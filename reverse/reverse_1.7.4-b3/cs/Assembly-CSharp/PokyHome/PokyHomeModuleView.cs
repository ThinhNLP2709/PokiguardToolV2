/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHomeModuleView : MonoBehaviour // TypeDefIndex: 2651
	{
		// Fields
		public const int LABEL_SIZE_LOCKED = 15; // Metadata: 0x005F12F7
		[Header("D\u1EEF li\u1EC7u (builder ghi t\u1EEB PokyHomeModuleConfig)")]
		public string moduleId; // 0x20
		public string label; // 0x28
		public string routeKey; // 0x30
		public string flagKey; // 0x38
		public int requireLevel; // 0x40
		public PokyNotifySource notifySource; // 0x44
		[Header("Tham chi\u1EBFu")]
		public HomePressScale press; // 0x48
		public Image icon; // 0x50
		public Sprite normalSprite; // 0x58
		public Sprite lockedSprite; // 0x60
		public GameObject lockIcon; // 0x68
		public UnityEngine.UI.Text labelText; // 0x70
		public HomeNotifyBadge badge; // 0x78
		[Tooltip("Node Fx thay Spine \u2014 kho\u00E1 th\u00EC l\u00E0m x\u00E1m c\u1EA3 c\u1EE5m (kh\u00F4ng c\u00F3 sprite _gray cho Spine).")]
		public GameObject fxRoot; // 0x80
		private bool _locked; // 0x88
		private bool _applied; // 0x89
		private bool _hooked; // 0x8A
		private int _labelSizeOpen; // 0x8C
		private readonly List<Graphic> _fxGraphics; // 0x90
		private readonly List<Color> _fxColors; // 0x98
		private bool _fxCaptured; // 0xA0
	
		// Properties
		public bool IsLocked { get; } // 0x00000001803C60F0-0x00000001803C6100 
		public RectTransform FocusTarget { get; } // 0x0000000180C285B0-0x0000000180C28700 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass29_0 // TypeDefIndex: 2652
		{
			// Fields
			public Transform t; // 0x10
			public float x; // 0x18
	
			// Constructors
			public __c__DisplayClass29_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _ShakeLocked_b__0(); // 0x0000000180C29070-0x0000000180C29270
		}
	
		// Constructors
		public PokyHomeModuleView(); // 0x0000000180C28E20-0x0000000180C29070
	
		// Methods
		private void Awake(); // 0x0000000180C27120-0x0000000180C27410
		private void OnDestroy(); // 0x0000000180C27410-0x0000000180C27600
		public void Bind(PokyHomeModuleDef def); // 0x0000000180C27600-0x0000000180C27930
		public void ApplyUserLevel(int userLevel); // 0x0000000180C27930-0x0000000180C28030
		public void SetNotify(int count); // 0x0000000180C28030-0x0000000180C28140
		public void ShakeLocked(); // 0x0000000180C28140-0x0000000180C285B0
		private void ApplyFxTint(bool locked); // 0x0000000180C28700-0x0000000180C28C80
		private void HandleClick(); // 0x0000000180C28C80-0x0000000180C28E20
	}
}
