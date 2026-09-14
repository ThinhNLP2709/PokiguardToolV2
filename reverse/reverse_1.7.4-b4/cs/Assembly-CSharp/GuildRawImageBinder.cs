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

[DisallowMultipleComponent]
public class GuildRawImageBinder : MonoBehaviour // TypeDefIndex: 917
{
	// Fields
	private const float TIMEOUT_SEC = 30f; // Metadata: 0x005F0102
	private const float POLL_SEC = 0.2f; // Metadata: 0x005F0106
	private RawImage _raw; // 0x20
	private string _path; // 0x28
	private Coroutine _waiting; // 0x30
	private Vector2 _box; // 0x38
	private bool _boxKnown; // 0x40

	// Nested types
	[CompilerGenerated]
	private sealed class _WaitForReal_d__13 : IEnumerator<object> // TypeDefIndex: 918
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
		private bool MoveNext(); // 0x000000018059E360-0x000000018059E810
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018059E810-0x000000018059E850
	}

	// Constructors
	public GuildRawImageBinder(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static Vector2 OriginalBox(RawImage raw); // 0x000000018059D7B0-0x000000018059DB70
	public static void Bind(RawImage raw, string resourcePath, Sprite current); // 0x000000018059DB70-0x000000018059DF50
	private void StartWaiting(string resourcePath); // 0x000000018059DF50-0x000000018059E190
	private void StopWaiting(); // 0x000000018059E190-0x000000018059E210
	private void OnEnable(); // 0x000000018059E210-0x000000018059E240
	private void OnDisable(); // 0x000000018059E240-0x000000018059E250
	[IteratorStateMachine(typeof(_WaitForReal_d__13))]
	private IEnumerator WaitForReal(string resourcePath); // 0x000000018059E250-0x000000018059E360
}

