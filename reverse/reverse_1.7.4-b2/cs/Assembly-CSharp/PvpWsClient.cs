/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class PvpWsClient : MonoBehaviour // TypeDefIndex: 509
{
	// Fields
	private static PvpWsClient _instance; // 0x00
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnPongReceived; // 0x20
	private bool _subscribed; // 0x28

	// Properties
	public static PvpWsClient Instance { get; } // 0x00000001803A9F40-0x00000001803AA050 
	public static bool UsePvpWs { get; } // 0x00000001803AA050-0x00000001803AA090 

	// Events
	public event Action<ChatMessageDTO> OnPongReceived {
		add; // 0x00000001803A9E80-0x00000001803A9F40
		remove; // 0x00000001803AA090-0x00000001803AA150
	}

	// Nested types
	[CompilerGenerated]
	private sealed class _RetrySubscribe_d__13 : IEnumerator<object> // TypeDefIndex: 510
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PvpWsClient __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RetrySubscribe_d__13(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001803BCBF0-0x00000001803BCCA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803BCCA0-0x00000001803BCCE0
	}

	// Constructors
	public PvpWsClient(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x00000001803A9990-0x00000001803A9A70
	private void OnEnable(); // 0x00000001803A9B90-0x00000001803A9BA0
	private void OnDisable(); // 0x00000001803A9A90-0x00000001803A9B90
	private void TrySubscribe(); // 0x00000001803A9D20-0x00000001803A9E80
	[IteratorStateMachine(typeof(_RetrySubscribe_d__13))]
	private IEnumerator RetrySubscribe(); // 0x00000001803A9BA0-0x00000001803A9C10
	private void Unsubscribe(); // 0x00000001803A9A90-0x00000001803A9B90
	private void HandlePong(ChatMessageDTO msg); // 0x00000001803A9A70-0x00000001803A9A90
	public void SendPing(string roomId = null); // 0x00000001803A9C10-0x00000001803A9D20
}

