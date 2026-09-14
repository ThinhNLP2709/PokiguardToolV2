/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class UnityMainThreadDispatcher : MonoBehaviour // TypeDefIndex: 589
{
	// Fields
	private static UnityMainThreadDispatcher _instance; // 0x00
	private static Queue<PendingAction> _executionQueue; // 0x08
	private static readonly object _queueLock; // 0x10
	private readonly List<PendingAction> _drainBuffer; // 0x20
	private readonly Stopwatch _drainWatch; // 0x28
	private const double FRAME_BUDGET_MS = 4; // Metadata: 0x005EE3ED
	private const int MIN_ACTIONS_PER_FRAME = 4; // Metadata: 0x005EE3F5
	private const int MAX_HEAVY_ACTIONS_PER_FRAME = 1; // Metadata: 0x005EE3F6
	private const string RC_DISPATCHER_HEAVY_CAP = "match.dispatcherHeavyCap"; // Metadata: 0x005EE3F7
	private bool _heavyCapOn; // 0x30

	// Nested types
	private struct PendingAction // TypeDefIndex: 590
	{
		// Fields
		public Action Action; // 0x00
		public bool Heavy; // 0x08
	}

	// Constructors
	public UnityMainThreadDispatcher(); // 0x000000018041B360-0x000000018041B550
	static UnityMainThreadDispatcher(); // 0x000000018041B550-0x000000018041B750

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void EnsureCreatedOnMainThread(); // 0x0000000180419CE0-0x0000000180419D30
	public static UnityMainThreadDispatcher Instance(); // 0x0000000180419D30-0x000000018041A070
	public static bool TryEnqueue(Action action); // 0x000000018041A070-0x000000018041A0D0
	public static bool TryEnqueue(Action action, bool heavy); // 0x000000018041A0D0-0x000000018041A270
	private void Awake(); // 0x000000018041A270-0x000000018041A320
	private void Start(); // 0x000000018041A320-0x000000018041A390
	private void OnDestroy(); // 0x000000018041A390-0x000000018041A440
	private void RefreshFlags(); // 0x000000018041A320-0x000000018041A390
	private void Update(); // 0x000000018041A440-0x000000018041B0F0
	public void Enqueue(Action action); // 0x000000018041B0F0-0x000000018041B100
	public void Enqueue(Action action, bool heavy); // 0x000000018041B100-0x000000018041B360
}

