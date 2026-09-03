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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ClientErrorReporter : MonoBehaviour // TypeDefIndex: 1165
{
	// Fields
	private const int MaxReportsPerSession = 15; // Metadata: 0x0064D3F9
	private const float MinSecondsBetweenSends = 5f; // Metadata: 0x0064D3FA
	private const int MaxMessageLength = 500; // Metadata: 0x0064D3FE
	private const int MaxStackLength = 2000; // Metadata: 0x0064D400
	private static ClientErrorReporter _instance; // 0x00
	private readonly ConcurrentQueue<PendingReport> _pending; // 0x20
	private readonly HashSet<int> _sentHashes; // 0x28
	private int _sentCount; // 0x30
	private float _lastSendAt; // 0x34
	private bool _sending; // 0x38

	// Nested types
	private struct PendingReport // TypeDefIndex: 1166
	{
		// Fields
		public string level; // 0x00
		public string message; // 0x08
		public string stack; // 0x10
	}

	[Serializable]
	private class ClientLogPayload // TypeDefIndex: 1167
	{
		// Fields
		public string level; // 0x10
		public string message; // 0x18
		public string stack; // 0x20
		public string scene; // 0x28
		public string version; // 0x30

		// Constructors
		public ClientLogPayload(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[CompilerGenerated]
	private sealed class _SendReport_d__15 : IEnumerator<object> // TypeDefIndex: 1168
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ClientErrorReporter __4__this; // 0x20
		public PendingReport report; // 0x28
		public string token; // 0x40
		private UnityWebRequest _request_5__2; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SendReport_d__15(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804C27B0-0x00000001804C2890
		private bool MoveNext(); // 0x00000001804C21C0-0x00000001804C2770
		private void __m__Finally1(); // 0x00000001804C2890-0x00000001804C28E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804C2770-0x00000001804C27B0
	}

	// Constructors
	public ClientErrorReporter(); // 0x00000001804AEBB0-0x00000001804AEC80

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void Bootstrap(); // 0x00000001804AE4A0-0x00000001804AE5A0
	private void OnEnable(); // 0x00000001804AE630-0x00000001804AE6C0
	private void OnDisable(); // 0x00000001804AE5A0-0x00000001804AE630
	private void OnLogMessage(string condition, string stackTrace, LogType type); // 0x00000001804AE6C0-0x00000001804AE810
	private void Update(); // 0x00000001804AE920-0x00000001804AEBB0
	[IteratorStateMachine(typeof(_SendReport_d__15))]
	private IEnumerator SendReport(PendingReport report, string token); // 0x00000001804AE810-0x00000001804AE8C0
	private static string Truncate(string s, int max); // 0x00000001804AE8C0-0x00000001804AE920
}

