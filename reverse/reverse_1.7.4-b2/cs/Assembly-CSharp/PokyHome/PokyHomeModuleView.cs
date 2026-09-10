/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHomeModuleView : MonoBehaviour // TypeDefIndex: 2215
	{
		// Fields
		public const int LABEL_SIZE_LOCKED = 15; // Metadata: 0x0068E1EC
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
		public bool IsLocked { get; } // 0x0000000180495050-0x0000000180495060 
		public RectTransform FocusTarget { get; } // 0x00000001807866B0-0x0000000180786770 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass29_0 // TypeDefIndex: 2216
		{
			// Fields
			public Transform t; // 0x10
			public float x; // 0x18
	
			// Constructors
			public __c__DisplayClass29_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _ShakeLocked_b__0(); // 0x0000000180794580-0x0000000180794640
		}
	
		// Constructors
		public PokyHomeModuleView(); // 0x00000001807865D0-0x00000001807866B0
	
		// Methods
		private void Awake(); // 0x0000000180785E60-0x0000000180785FA0
		private void OnDestroy(); // 0x0000000180786220-0x0000000180786330
		public void Bind(PokyHomeModuleDef def); // 0x0000000180785FA0-0x0000000180786110
		public void ApplyUserLevel(int userLevel); // 0x0000000180785AB0-0x0000000180785E60
		public void SetNotify(int count); // 0x0000000180786330-0x00000001807863C0
		public void ShakeLocked(); // 0x00000001807863C0-0x00000001807865D0
		private void ApplyFxTint(bool locked); // 0x0000000180785740-0x0000000180785AB0
		private void HandleClick(); // 0x0000000180786110-0x0000000180786220
	}
}
