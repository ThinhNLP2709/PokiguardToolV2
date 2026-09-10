/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class InfoPlayerBackdrop : MonoBehaviour // TypeDefIndex: 2368
	{
		// Fields
		public const string NODE_NAME = "img_Backdrop"; // Metadata: 0x0068EDC8
		public const string N_SOURCE = "img_Background"; // Metadata: 0x0068EDD5
		public static readonly Vector2 ART_SIZE; // 0x00
		private RectTransform _rt; // 0x20
		private RectTransform _fill; // 0x28
		private RectTransform _parent; // 0x30
		private float _lastW; // 0x38
		private float _lastH; // 0x3C
	
		// Constructors
		public InfoPlayerBackdrop(); // 0x00000001807D9DC0-0x00000001807D9DE0
		static InfoPlayerBackdrop(); // 0x00000001807D9D80-0x00000001807D9DC0
	
		// Methods
		public static InfoPlayerBackdrop Ensure(Transform popupRoot); // 0x00000001807D8F60-0x00000001807D9720
		private void OnEnable(); // 0x00000001807D98D0-0x00000001807D9A30
		private void LateUpdate(); // 0x00000001807D9720-0x00000001807D98D0
		public void Refit(); // 0x00000001807D9A30-0x00000001807D9D80
	}
}
