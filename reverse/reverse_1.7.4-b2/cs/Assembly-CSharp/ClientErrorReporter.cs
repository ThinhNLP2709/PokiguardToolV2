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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ClientErrorReporter : MonoBehaviour // TypeDefIndex: 1381
{
	// Fields
	private const int MaxReportsPerSession = 15; // Metadata: 0x0068CF54
	private const float MinSecondsBetweenSends = 5f; // Metadata: 0x0068CF55
	private const int MaxMessageLength = 500; // Metadata: 0x0068CF59
	private const int MaxStackLength = 2000; // Metadata: 0x0068CF5B
	private const int MaxPendingQueue = 100; // Metadata: 0x0068CF5D
	private static ClientErrorReporter _instance; // 0x00
	private readonly ConcurrentQueue<PendingReport> _pending; // 0x20
	private readonly HashSet<int> _sentHashes; // 0x28
	private int _sentCount; // 0x30
	private float _lastSendAt; // 0x34
	private bool _sending; // 0x38

	// Nested types
	private struct PendingReport // TypeDefIndex: 1382
	{
		// Fields
		public string level; // 0x00
		public string message; // 0x08
		public string stack; // 0x10
	}

	[Serializable]
	private class ClientLogPayload // TypeDefIndex: 1383
	{
		// Fields
		public string level; // 0x10
		public string message; // 0x18
		public string stack; // 0x20
		public string scene; // 0x28
		public string version; // 0x30

		// Constructors
		public ClientLogPayload(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[CompilerGenerated]
	private sealed class _SendReport_d__16 : IEnumerator<object> // TypeDefIndex: 1384
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ClientErrorReporter __4__this; // 0x20
		public PendingReport report; // 0x28
		public string token; // 0x40
		private UnityWebRequest _request_5__2; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SendReport_d__16(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805BDEC0-0x00000001805BDFA0
		private bool MoveNext(); // 0x00000001805BD8D0-0x00000001805BDE80
		private void __m__Finally1(); // 0x00000001805BDFA0-0x00000001805BDFF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805BDE80-0x00000001805BDEC0
	}

	// Constructors
	public ClientErrorReporter(); // 0x00000001805AA3D0-0x00000001805AA4A0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void Bootstrap(); // 0x00000001805A9C90-0x00000001805A9D90
	private void OnEnable(); // 0x00000001805A9E20-0x00000001805A9EB0
	private void OnDisable(); // 0x00000001805A9D90-0x00000001805A9E20
	private void OnLogMessage(string condition, string stackTrace, LogType type); // 0x00000001805A9EB0-0x00000001805AA020
	private void Update(); // 0x00000001805AA130-0x00000001805AA3D0
	[IteratorStateMachine(typeof(_SendReport_d__16))]
	private IEnumerator SendReport(PendingReport report, string token); // 0x00000001805AA020-0x00000001805AA0D0
	private static string Truncate(string s, int max); // 0x00000001805AA0D0-0x00000001805AA130
}

