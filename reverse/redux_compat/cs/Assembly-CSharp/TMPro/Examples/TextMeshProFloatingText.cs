/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace TMPro.Examples
{
	public class TextMeshProFloatingText : MonoBehaviour // TypeDefIndex: 1820
	{
		// Fields
		public Font TheFont; // 0x20
		private GameObject m_floatingText; // 0x28
		private TextMeshPro m_textMeshPro; // 0x30
		private TextMesh m_textMesh; // 0x38
		private Transform m_transform; // 0x40
		private Transform m_floatingText_Transform; // 0x48
		private Transform m_cameraTransform; // 0x50
		private Vector3 lastPOS; // 0x58
		private Quaternion lastRotation; // 0x64
		public int SpawnType; // 0x74
		public bool IsTextObjectScaleStatic; // 0x78
		private static WaitForEndOfFrame k_WaitForEndOfFrame; // 0x00
		private static WaitForSeconds[] k_WaitForSecondsRandom; // 0x08
	
		// Nested types
		[CompilerGenerated]
		private sealed class _DisplayTextMeshFloatingText_d__16 : IEnumerator<object> // TypeDefIndex: 1821
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public TextMeshProFloatingText __4__this; // 0x20
			private float _CountDuration_5__2; // 0x28
			private float _starting_Count_5__3; // 0x2C
			private float _current_Count_5__4; // 0x30
			private Vector3 _start_pos_5__5; // 0x34
			private Color32 _start_color_5__6; // 0x40
			private float _alpha_5__7; // 0x44
			private float _fadeDuration_5__8; // 0x48
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _DisplayTextMeshFloatingText_d__16(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x0000000180610190-0x0000000180610710
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180610710-0x0000000180610750
		}
	
		[CompilerGenerated]
		private sealed class _DisplayTextMeshProFloatingText_d__15 : IEnumerator<object> // TypeDefIndex: 1822
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public TextMeshProFloatingText __4__this; // 0x20
			private float _CountDuration_5__2; // 0x28
			private float _starting_Count_5__3; // 0x2C
			private float _current_Count_5__4; // 0x30
			private Vector3 _start_pos_5__5; // 0x34
			private Color32 _start_color_5__6; // 0x40
			private float _alpha_5__7; // 0x44
			private float _fadeDuration_5__8; // 0x48
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _DisplayTextMeshProFloatingText_d__15(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x0000000180610750-0x0000000180610CF0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180610CF0-0x0000000180610D30
		}
	
		// Constructors
		public TextMeshProFloatingText(); // 0x000000018060B200-0x000000018060B240
		static TextMeshProFloatingText(); // 0x000000018060AC30-0x000000018060B200
	
		// Methods
		private void Awake(); // 0x000000018060A470-0x000000018060A570
		private void Start(); // 0x000000018060A650-0x000000018060AC30
		[IteratorStateMachine(typeof(_DisplayTextMeshProFloatingText_d__15))]
		public IEnumerator DisplayTextMeshProFloatingText(); // 0x000000018060A5E0-0x000000018060A650
		[IteratorStateMachine(typeof(_DisplayTextMeshFloatingText_d__16))]
		public IEnumerator DisplayTextMeshFloatingText(); // 0x000000018060A570-0x000000018060A5E0
	}
}
