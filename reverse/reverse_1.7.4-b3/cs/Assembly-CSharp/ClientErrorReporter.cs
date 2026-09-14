/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ClientErrorReporter : MonoBehaviour // TypeDefIndex: 1763
{
	// Fields
	private const int MaxReportsPerSession = 15; // Metadata: 0x005F017B
	private const float MinSecondsBetweenSends = 5f; // Metadata: 0x005F017C
	private const int MaxMessageLength = 500; // Metadata: 0x005F0180
	private const int MaxStackLength = 2000; // Metadata: 0x005F0182
	private const int MaxPendingQueue = 100; // Metadata: 0x005F0184
	private static ClientErrorReporter _instance; // 0x00
	private readonly ConcurrentQueue<PendingReport> _pending; // 0x20
	private readonly HashSet<int> _sentHashes; // 0x28
	private int _sentCount; // 0x30
	private float _lastSendAt; // 0x34
	private bool _sending; // 0x38

	// Nested types
	private struct PendingReport // TypeDefIndex: 1764
	{
		// Fields
		public string level; // 0x00
		public string message; // 0x08
		public string stack; // 0x10
	}

	[Serializable]
	private class ClientLogPayload // TypeDefIndex: 1765
	{
		// Fields
		public string level; // 0x10
		public string message; // 0x18
		public string stack; // 0x20
		public string scene; // 0x28
		public string version; // 0x30

		// Constructors
		public ClientLogPayload(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class _SendReport_d__16 : IEnumerator<object> // TypeDefIndex: 1766
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ClientErrorReporter __4__this; // 0x20
		public PendingReport report; // 0x28
		public string token; // 0x40
		private UnityWebRequest _request_5__2; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SendReport_d__16(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808D6370-0x00000001808D64A0
		private bool MoveNext(); // 0x00000001808D64A0-0x00000001808D6E30
		private void __m__Finally1(); // 0x00000001808D6E30-0x00000001808D6E90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808D6E90-0x00000001808D6ED0
	}

	// Constructors
	public ClientErrorReporter(); // 0x00000001808D6080-0x00000001808D6370

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void Bootstrap(); // 0x00000001808D52D0-0x00000001808D54B0
	private void OnEnable(); // 0x00000001808D54B0-0x00000001808D56D0
	private void OnDisable(); // 0x00000001808D56D0-0x00000001808D58B0
	private void OnLogMessage(string condition, string stackTrace, LogType type); // 0x00000001808D58B0-0x00000001808D5AC0
	private void Update(); // 0x00000001808D5AC0-0x00000001808D5EE0
	[IteratorStateMachine(typeof(_SendReport_d__16))]
	private IEnumerator SendReport(PendingReport report, string token); // 0x00000001808D5EE0-0x00000001808D6050
	private static string Truncate(string s, int max); // 0x00000001808D6050-0x00000001808D6080
}

