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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class GuildRawImageBinder : MonoBehaviour // TypeDefIndex: 915
{
	// Fields
	private const float TIMEOUT_SEC = 30f; // Metadata: 0x005EED34
	private const float POLL_SEC = 0.2f; // Metadata: 0x005EED38
	private RawImage _raw; // 0x20
	private string _path; // 0x28
	private Coroutine _waiting; // 0x30
	private Vector2 _box; // 0x38
	private bool _boxKnown; // 0x40

	// Nested types
	[CompilerGenerated]
	private sealed class _WaitForReal_d__13 : IEnumerator<object> // TypeDefIndex: 916
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GuildRawImageBinder __4__this; // 0x20
		public string resourcePath; // 0x28
		private float _deadline_5__2; // 0x30
		private WaitForSecondsRealtime _wait_5__3; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitForReal_d__13(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180291A40-0x0000000180291AB0
		private bool MoveNext(); // 0x000000018059CA00-0x000000018059CEB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018059CEB0-0x000000018059CEF0
	}

	// Constructors
	public GuildRawImageBinder(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static Vector2 OriginalBox(RawImage raw); // 0x000000018059BE50-0x000000018059C210
	public static void Bind(RawImage raw, string resourcePath, Sprite current); // 0x000000018059C210-0x000000018059C5F0
	private void StartWaiting(string resourcePath); // 0x000000018059C5F0-0x000000018059C830
	private void StopWaiting(); // 0x000000018059C830-0x000000018059C8B0
	private void OnEnable(); // 0x000000018059C8B0-0x000000018059C8E0
	private void OnDisable(); // 0x000000018059C8E0-0x000000018059C8F0
	[IteratorStateMachine(typeof(_WaitForReal_d__13))]
	private IEnumerator WaitForReal(string resourcePath); // 0x000000018059C8F0-0x000000018059CA00
}

