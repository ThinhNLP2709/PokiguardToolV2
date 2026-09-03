/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class UnityMainThreadDispatcher : MonoBehaviour // TypeDefIndex: 450
{
	// Fields
	private static UnityMainThreadDispatcher _instance; // 0x00
	private static Queue<Action> _executionQueue; // 0x08
	private readonly List<Action> _drainBuffer; // 0x20
	private readonly Stopwatch _drainWatch; // 0x28
	private const double FRAME_BUDGET_MS = 4; // Metadata: 0x0064C42D
	private const int MIN_ACTIONS_PER_FRAME = 4; // Metadata: 0x0064C435

	// Constructors
	public UnityMainThreadDispatcher(); // 0x000000018036F0A0-0x000000018036F150
	static UnityMainThreadDispatcher(); // 0x000000018036F010-0x000000018036F0A0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void EnsureCreatedOnMainThread(); // 0x000000018036E4A0-0x000000018036E660
	public static UnityMainThreadDispatcher Instance(); // 0x000000018036E660-0x000000018036E7F0
	public static bool TryEnqueue(Action action); // 0x000000018036E7F0-0x000000018036E8F0
	private void Update(); // 0x000000018036E8F0-0x000000018036F010
	public void Enqueue(Action action); // 0x000000018036E380-0x000000018036E4A0
}

