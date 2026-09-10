/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class UnityMainThreadDispatcher : MonoBehaviour // TypeDefIndex: 536
{
	// Fields
	private static UnityMainThreadDispatcher _instance; // 0x00
	private static Queue<PendingAction> _executionQueue; // 0x08
	private static readonly object _queueLock; // 0x10
	private readonly List<PendingAction> _drainBuffer; // 0x20
	private readonly Stopwatch _drainWatch; // 0x28
	private const double FRAME_BUDGET_MS = 4; // Metadata: 0x0068B617
	private const int MIN_ACTIONS_PER_FRAME = 4; // Metadata: 0x0068B61F
	private const int MAX_HEAVY_ACTIONS_PER_FRAME = 1; // Metadata: 0x0068B620
	private const string RC_DISPATCHER_HEAVY_CAP = "match.dispatcherHeavyCap"; // Metadata: 0x0068B621
	private bool _heavyCapOn; // 0x30

	// Nested types
	private struct PendingAction // TypeDefIndex: 537
	{
		// Fields
		public Action Action; // 0x00
		public bool Heavy; // 0x08
	}

	// Constructors
	public UnityMainThreadDispatcher(); // 0x00000001803D5FB0-0x00000001803D6060
	static UnityMainThreadDispatcher(); // 0x00000001803D5EE0-0x00000001803D5FB0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void EnsureCreatedOnMainThread(); // 0x00000001803D50B0-0x00000001803D5270
	public static UnityMainThreadDispatcher Instance(); // 0x00000001803D5270-0x00000001803D5400
	public static bool TryEnqueue(Action action); // 0x00000001803D54F0-0x00000001803D5620
	public static bool TryEnqueue(Action action, bool heavy); // 0x00000001803D5620-0x00000001803D5730
	private void Awake(); // 0x00000001803D4E80-0x00000001803D4F10
	private void Start(); // 0x00000001803D5490-0x00000001803D54F0
	private void OnDestroy(); // 0x00000001803D5400-0x00000001803D5490
	private void RefreshFlags(); // 0x00000001803D5490-0x00000001803D54F0
	private void Update(); // 0x00000001803D5730-0x00000001803D5EE0
	public void Enqueue(Action action); // 0x00000001803D50A0-0x00000001803D50B0
	public void Enqueue(Action action, bool heavy); // 0x00000001803D4F10-0x00000001803D50A0
}

