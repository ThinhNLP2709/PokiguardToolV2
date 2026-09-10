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

[DisallowMultipleComponent]
public class GuildRawImageBinder : MonoBehaviour // TypeDefIndex: 773
{
	// Fields
	private const float TIMEOUT_SEC = 30f; // Metadata: 0x0068BB1F
	private const float POLL_SEC = 0.2f; // Metadata: 0x0068BB23
	private RawImage _raw; // 0x20
	private string _path; // 0x28
	private Coroutine _waiting; // 0x30
	private Vector2 _box; // 0x38
	private bool _boxKnown; // 0x40

	// Nested types
	[CompilerGenerated]
	private sealed class _WaitForReal_d__13 : IEnumerator<object> // TypeDefIndex: 774
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildRawImageBinder __4__this; // 0x20
		public string resourcePath; // 0x28
		private float _deadline_5__2; // 0x30
		private WaitForSecondsRealtime _wait_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitForReal_d__13(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180301FB0-0x0000000180301FE0
		private bool MoveNext(); // 0x00000001804976D0-0x00000001804978E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804978E0-0x0000000180497EA0
	}

	// Constructors
	public GuildRawImageBinder(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public static Vector2 OriginalBox(RawImage raw); // 0x000000018047D1C0-0x000000018047D410
	public static void Bind(RawImage raw, string resourcePath, Sprite current); // 0x000000018047CF60-0x000000018047D140
	private void StartWaiting(string resourcePath); // 0x000000018047D410-0x000000018047D4E0
	private void StopWaiting(); // 0x000000018047D140-0x000000018047D180
	private void OnEnable(); // 0x000000018047D180-0x000000018047D1C0
	private void OnDisable(); // 0x000000018047D140-0x000000018047D180
	[IteratorStateMachine(typeof(_WaitForReal_d__13))]
	private IEnumerator WaitForReal(string resourcePath); // 0x000000018047D4E0-0x000000018047D570
}

