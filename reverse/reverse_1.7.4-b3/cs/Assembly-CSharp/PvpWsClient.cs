/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class PvpWsClient : MonoBehaviour // TypeDefIndex: 562
{
	// Fields
	private static PvpWsClient _instance; // 0x00
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnPongReceived; // 0x20
	private bool _subscribed; // 0x28

	// Properties
	public static PvpWsClient Instance { get; } // 0x00000001803EBA70-0x00000001803EBC60 
	public static bool UsePvpWs { get; } // 0x00000001803EBC60-0x00000001803EBCB0 

	// Events
	public event Action<ChatMessageDTO> OnPongReceived {
		add; // 0x00000001803EBCB0-0x00000001803EBDD0
		remove; // 0x00000001803EBDD0-0x00000001803EBEF0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class _RetrySubscribe_d__13 : IEnumerator<object> // TypeDefIndex: 563
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PvpWsClient __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RetrySubscribe_d__13(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001803ECA80-0x00000001803ECB50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803ECB50-0x00000001803ECB90
	}

	// Constructors
	public PvpWsClient(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x00000001803EBEF0-0x00000001803EC190
	private void OnEnable(); // 0x00000001803EC190-0x00000001803EC1A0
	private void OnDisable(); // 0x00000001803EC1A0-0x00000001803EC1B0
	private void TrySubscribe(); // 0x00000001803EC1B0-0x00000001803EC510
	[IteratorStateMachine(typeof(_RetrySubscribe_d__13))]
	private IEnumerator RetrySubscribe(); // 0x00000001803EC510-0x00000001803EC5B0
	private void Unsubscribe(); // 0x00000001803EC5B0-0x00000001803EC840
	private void HandlePong(ChatMessageDTO msg); // 0x00000001803EC840-0x00000001803EC860
	public void SendPing(string roomId = null); // 0x00000001803EC860-0x00000001803ECA80
}

