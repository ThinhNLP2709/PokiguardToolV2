/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyHomeNextModule : MonoBehaviour // TypeDefIndex: 2217
	{
		// Fields
		private const float SCROLL_SEC = 0.45f; // Metadata: 0x0068E1ED
		[Header("Tham chi\u1EBFu trong node NextModule")]
		[Tooltip("\u1EA2nh to\u00E0 nh\u00E0 (node \'Image\').")]
		public Image icon; // 0x20
		[Tooltip("T\u00EAn m\u00F4-\u0111un (node \'Image (1)/Text Module\').")]
		public UnityEngine.UI.Text moduleText; // 0x28
		[Tooltip("D\u00F2ng y\u00EAu c\u1EA7u c\u1EA5p (node \'Image (1)/Text\').")]
		public UnityEngine.UI.Text requireText; // 0x30
		[Header("Cu\u1ED9n t\u1EDBi m\u1EE5c ti\u00EAu")]
		[Tooltip("Khu to\u00E0 nh\u00E0 (node CanvasBuilding/Buildings) \u2014 d\u1ECBch ngang \u0111\u1EC3 \u0111\u01B0a to\u00E0 v\u00E0o gi\u1EEFa.")]
		public RectTransform buildingsRoot; // 0x38
		[Tooltip("Bi\u00EAn k\u00E9o ngang (px). Builder \u0111i\u1EC1n theo b\u1EC1 r\u1ED9ng \u1EA3nh n\u1EC1n th\u1EADt.")]
		public float scrollLimit; // 0x40
		private PokyHomeModuleView _target; // 0x48
	
		// Properties
		public PokyHomeModuleView Target { get; } // 0x0000000180319990-0x00000001803199A0 
	
		// Constructors
		public PokyHomeNextModule(); // 0x00000001807871C0-0x00000001807871D0
	
		// Methods
		private void OnDisable(); // 0x0000000180786BC0-0x0000000180786C70
		public void Refresh(PokyHomeLockState state, int userLevel); // 0x0000000180786C70-0x0000000180787110
		public void Hide(); // 0x00000001802F4D60-0x00000001802F4DB0
		public void FocusTarget(); // 0x0000000180786770-0x0000000180786BC0
		[CompilerGenerated]
		private void _FocusTarget_b__12_0(float x); // 0x0000000180787110-0x00000001807871C0
	}
}
