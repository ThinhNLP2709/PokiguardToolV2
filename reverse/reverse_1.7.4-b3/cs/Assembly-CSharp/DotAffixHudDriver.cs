/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class DotAffixHudDriver : MonoBehaviour // TypeDefIndex: 2181
{
	// Fields
	private const float RESUBSCRIBE_STEP = 5f; // Metadata: 0x005F078B
	private static DotAffixHudDriver _instance; // 0x00
	private MatchService _subscribedMs; // 0x20

	// Nested types
	[CompilerGenerated]
	private sealed class _WatchSubscription_d__9 : IEnumerator<object> // TypeDefIndex: 2182
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public DotAffixHudDriver __4__this; // 0x20
		private WaitForSecondsRealtime _wait_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WatchSubscription_d__9(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180A757A0-0x0000000180A75910
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A75910-0x0000000180A75950
	}

	// Constructors
	public DotAffixHudDriver(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetStatics(); // 0x0000000180A744D0-0x0000000180A74570
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInit(); // 0x0000000180A74570-0x0000000180A746F0
	private void Awake(); // 0x0000000180A746F0-0x0000000180A74990
	private void OnEnable(); // 0x0000000180A74990-0x0000000180A74B40
	private void OnDisable(); // 0x0000000180A74B40-0x0000000180A74C70
	private void OnDestroy(); // 0x0000000180A74C70-0x0000000180A74E30
	[IteratorStateMachine(typeof(_WatchSubscription_d__9))]
	private IEnumerator WatchSubscription(); // 0x0000000180A74E30-0x0000000180A74ED0
	private void EnsureSubscription(); // 0x0000000180A74ED0-0x0000000180A75150
	private void Unsubscribe(); // 0x0000000180A75150-0x0000000180A75400
	private static void HandleMatchStart(ChatMessageDTO m); // 0x0000000180A75400-0x0000000180A755B0
	private static void HandleGameOver(string winner); // 0x0000000180A755B0-0x0000000180A75650
	private static void HandleMatchExit(MatchKind kind); // 0x0000000180A75650-0x0000000180A756A0
	private static void HandleSceneUnloaded(Scene s); // 0x0000000180A756A0-0x0000000180A757A0
}

