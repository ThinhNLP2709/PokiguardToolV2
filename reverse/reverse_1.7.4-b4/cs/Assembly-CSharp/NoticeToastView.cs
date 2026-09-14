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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class NoticeToastView : MonoBehaviour // TypeDefIndex: 1407
{
	// Fields
	[SerializeField]
	private CanvasGroup canvasGroup; // 0x20
	[SerializeField]
	private RectTransform panel; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtMessage; // 0x30
	private const float FADE = 0.22f; // Metadata: 0x005F0F20
	private const float SLIDE = 26f; // Metadata: 0x005F0F24

	// Nested types
	[CompilerGenerated]
	private sealed class _CoPlay_d__6 : IEnumerator<object> // TypeDefIndex: 1408
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public NoticeToastView __4__this; // 0x20
		public float duration; // 0x28
		private Vector2 _basePos_5__2; // 0x2C
		private float _t_5__3; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CoPlay_d__6(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180794050-0x0000000180794930
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180794930-0x0000000180794970
	}

	// Constructors
	public NoticeToastView(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public void Play(string message, float duration); // 0x0000000180792440-0x0000000180792980
	[IteratorStateMachine(typeof(_CoPlay_d__6))]
	private IEnumerator CoPlay(float duration); // 0x0000000180792980-0x0000000180792A40
	public void BuildHierarchy(); // 0x0000000180792A40-0x0000000180793CA0
	private static GameObject FindOrCreate(Transform parent, string name); // 0x0000000180793CA0-0x0000000180794050
}

