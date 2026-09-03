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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class NoticeToastView : MonoBehaviour // TypeDefIndex: 831
{
	// Fields
	[SerializeField]
	private CanvasGroup canvasGroup; // 0x20
	[SerializeField]
	private RectTransform panel; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtMessage; // 0x30
	private const float FADE = 0.22f; // Metadata: 0x0064CA60
	private const float SLIDE = 26f; // Metadata: 0x0064CA64

	// Nested types
	[CompilerGenerated]
	private sealed class _CoPlay_d__6 : IEnumerator<object> // TypeDefIndex: 832
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public NoticeToastView __4__this; // 0x20
		public float duration; // 0x28
		private Vector2 _basePos_5__2; // 0x2C
		private float _t_5__3; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CoPlay_d__6(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180436920-0x0000000180436DB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180436DB0-0x0000000180436DF0
	}

	// Constructors
	public NoticeToastView(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public void Play(string message, float duration); // 0x0000000180428280-0x00000001804284A0
	[IteratorStateMachine(typeof(_CoPlay_d__6))]
	private IEnumerator CoPlay(float duration); // 0x0000000180428040-0x00000001804280C0
	public void BuildHierarchy(); // 0x0000000180427560-0x0000000180428040
	private static GameObject FindOrCreate(Transform parent, string name); // 0x00000001804280C0-0x0000000180428280
}

