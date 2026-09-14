/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class UnityMainThreadDispatcher : MonoBehaviour // TypeDefIndex: 590
{
	// Fields
	private static UnityMainThreadDispatcher _instance; // 0x00
	private static Queue<PendingAction> _executionQueue; // 0x08
	private static readonly object _queueLock; // 0x10
	private readonly List<PendingAction> _drainBuffer; // 0x20
	private readonly Stopwatch _drainWatch; // 0x28
	private const double FRAME_BUDGET_MS = 4; // Metadata: 0x005EF7BE
	private const int MIN_ACTIONS_PER_FRAME = 4; // Metadata: 0x005EF7C6
	private const int MAX_HEAVY_ACTIONS_PER_FRAME = 1; // Metadata: 0x005EF7C7
	private const string RC_DISPATCHER_HEAVY_CAP = "match.dispatcherHeavyCap"; // Metadata: 0x005EF7C8
	private bool _heavyCapOn; // 0x30

	// Nested types
	private struct PendingAction // TypeDefIndex: 591
	{
		// Fields
		public Action Action; // 0x00
		public bool Heavy; // 0x08
	}

	// Constructors
	public UnityMainThreadDispatcher(); // 0x000000018041C0C0-0x000000018041C2B0
	static UnityMainThreadDispatcher(); // 0x000000018041C2B0-0x000000018041C4B0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void EnsureCreatedOnMainThread(); // 0x000000018041AA40-0x000000018041AA90
	public static UnityMainThreadDispatcher Instance(); // 0x000000018041AA90-0x000000018041ADD0
	public static bool TryEnqueue(Action action); // 0x000000018041ADD0-0x000000018041AE30
	public static bool TryEnqueue(Action action, bool heavy); // 0x000000018041AE30-0x000000018041AFD0
	private void Awake(); // 0x000000018041AFD0-0x000000018041B080
	private void Start(); // 0x000000018041B080-0x000000018041B0F0
	private void OnDestroy(); // 0x000000018041B0F0-0x000000018041B1A0
	private void RefreshFlags(); // 0x000000018041B080-0x000000018041B0F0
	private void Update(); // 0x000000018041B1A0-0x000000018041BE50
	public void Enqueue(Action action); // 0x000000018041BE50-0x000000018041BE60
	public void Enqueue(Action action, bool heavy); // 0x000000018041BE60-0x000000018041C0C0
}

