/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class PvpWsClient : MonoBehaviour // TypeDefIndex: 440
{
	// Fields
	private static PvpWsClient _instance; // 0x00
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnPongReceived; // 0x20
	private bool _subscribed; // 0x28

	// Properties
	public static PvpWsClient Instance { get; } // 0x000000018034B2F0-0x000000018034B400 
	public static bool UsePvpWs { get; } // 0x000000018034B400-0x000000018034B440 

	// Events
	public event Action<ChatMessageDTO> OnPongReceived {
		add; // 0x000000018034B230-0x000000018034B2F0
		remove; // 0x000000018034B440-0x000000018034B500
	}

	// Nested types
	[CompilerGenerated]
	private sealed class _RetrySubscribe_d__13 : IEnumerator<object> // TypeDefIndex: 441
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public PvpWsClient __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RetrySubscribe_d__13(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180356EF0-0x0000000180356FA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180356FA0-0x0000000180356FE0
	}

	// Constructors
	public PvpWsClient(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x000000018034AD40-0x000000018034AE20
	private void OnEnable(); // 0x000000018034AF40-0x000000018034AF50
	private void OnDisable(); // 0x000000018034AE40-0x000000018034AF40
	private void TrySubscribe(); // 0x000000018034B0D0-0x000000018034B230
	[IteratorStateMachine(typeof(_RetrySubscribe_d__13))]
	private IEnumerator RetrySubscribe(); // 0x000000018034AF50-0x000000018034AFC0
	private void Unsubscribe(); // 0x000000018034AE40-0x000000018034AF40
	private void HandlePong(ChatMessageDTO msg); // 0x000000018034AE20-0x000000018034AE40
	public void SendPing(string roomId = null); // 0x000000018034AFC0-0x000000018034B0D0
}

