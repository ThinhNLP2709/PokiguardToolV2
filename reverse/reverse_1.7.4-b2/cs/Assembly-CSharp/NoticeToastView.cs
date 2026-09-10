/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class NoticeToastView : MonoBehaviour // TypeDefIndex: 1027
{
	// Fields
	[SerializeField]
	private CanvasGroup canvasGroup; // 0x20
	[SerializeField]
	private RectTransform panel; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtMessage; // 0x30
	private const float FADE = 0.22f; // Metadata: 0x0068C171
	private const float SLIDE = 26f; // Metadata: 0x0068C175

	// Nested types
	[CompilerGenerated]
	private sealed class _CoPlay_d__6 : IEnumerator<object> // TypeDefIndex: 1028
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public NoticeToastView __4__this; // 0x20
		public float duration; // 0x28
		private Vector2 _basePos_5__2; // 0x2C
		private float _t_5__3; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _CoPlay_d__6(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018050EB60-0x000000018050EFF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018050EFF0-0x000000018050F030
	}

	// Constructors
	public NoticeToastView(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public void Play(string message, float duration); // 0x00000001804FDF10-0x00000001804FE130
	[IteratorStateMachine(typeof(_CoPlay_d__6))]
	private IEnumerator CoPlay(float duration); // 0x00000001804FDCD0-0x00000001804FDD50
	public void BuildHierarchy(); // 0x00000001804FD1F0-0x00000001804FDCD0
	private static GameObject FindOrCreate(Transform parent, string name); // 0x00000001804FDD50-0x00000001804FDF10
}

