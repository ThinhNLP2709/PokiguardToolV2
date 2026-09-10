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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace TMPro.Examples
{
	public class TextMeshProFloatingText : MonoBehaviour // TypeDefIndex: 2099
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
		private sealed class _DisplayTextMeshFloatingText_d__16 : IEnumerator<object> // TypeDefIndex: 2100
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _DisplayTextMeshFloatingText_d__16(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
			private bool MoveNext(); // 0x00000001807368B0-0x0000000180736E30
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180736E30-0x0000000180736E70
		}
	
		[CompilerGenerated]
		private sealed class _DisplayTextMeshProFloatingText_d__15 : IEnumerator<object> // TypeDefIndex: 2101
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _DisplayTextMeshProFloatingText_d__15(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
			private bool MoveNext(); // 0x0000000180736E70-0x0000000180737410
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180737410-0x0000000180737450
		}
	
		// Constructors
		public TextMeshProFloatingText(); // 0x0000000180731760-0x00000001807317A0
		static TextMeshProFloatingText(); // 0x0000000180731190-0x0000000180731760
	
		// Methods
		private void Awake(); // 0x00000001807309D0-0x0000000180730AD0
		private void Start(); // 0x0000000180730BB0-0x0000000180731190
		[IteratorStateMachine(typeof(_DisplayTextMeshProFloatingText_d__15))]
		public IEnumerator DisplayTextMeshProFloatingText(); // 0x0000000180730B40-0x0000000180730BB0
		[IteratorStateMachine(typeof(_DisplayTextMeshFloatingText_d__16))]
		public IEnumerator DisplayTextMeshFloatingText(); // 0x0000000180730AD0-0x0000000180730B40
	}
}
