/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class MatchPerfProbe : MonoBehaviour // TypeDefIndex: 1404
{
	// Fields
	private const string RC_PROBE = "perf.probe"; // Metadata: 0x0068CF7F
	public const string PREF_PROBE = "ff_PerfProbe"; // Metadata: 0x0068CF8A
	private const int WARMUP_FRAMES = 5; // Metadata: 0x0068CF97
	private const float HITCH_MS = 50f; // Metadata: 0x0068CF98
	private const float BUCKET_MS = 0.5f; // Metadata: 0x0068CF9C
	private const int BUCKETS = 401; // Metadata: 0x0068CFA0
	private const float SAMPLE_EVERY_SEC = 5f; // Metadata: 0x0068CFA2
	private const int RTT_SLOTS = 64; // Metadata: 0x0068CFA6
	private const float MIN_SEND_INTERVAL_SEC = 60f; // Metadata: 0x0068CFA8
	private const int MIN_FRAMES_TO_SEND = 30; // Metadata: 0x0068CFAC
	private const float POST_EXIT_DELAY_SEC = 5f; // Metadata: 0x0068CFAD
	private static MatchPerfProbe _inst; // 0x00
	private static bool _measuring; // 0x08
	private readonly int[] _hist; // 0x20
	private readonly int[] _hitchPhase; // 0x28
	private readonly int[] _rtt; // 0x30
	private readonly int[] _rttSortBuf; // 0x38
	private int _frames; // 0x40
	private int _warmupLeft; // 0x44
	private float _maxFrameMs; // 0x48
	private int _hitch1Hz; // 0x4C
	private long _lastHitchSecond; // 0x50
	private int _rttCount; // 0x58
	private float _nextSampleAt; // 0x5C
	private int _gcStart; // 0x60
	private long _gcMemStart; // 0x68
	private long _gcAllocBytes; // 0x70
	private long _gcMemPrev; // 0x78
	private int _gcCount; // 0x80
	private string _matchId; // 0x88
	private float _lastSentAt; // 0x90
	private bool _sending; // 0x94
	private int _transitionWatchdogAtStart; // 0x98
	private Payload _pending; // 0xA0
	private float _pendingSendAt; // 0xA8
	private bool _declinedThisMatch; // 0xAC
	private static float _enterBeganAt; // 0x0C
	private static int _enterMs; // 0x10
	private static float _exitBeganAt; // 0x14
	private static int _exitMs; // 0x18
	private static float _tRelease; // 0x1C
	private static float _tMoveResRecv; // 0x20
	private static float _tAckSent; // 0x24
	private static int _turns; // 0x28
	private static double _sumTurnRoundTripMs; // 0x30
	private static double _sumRenderMs; // 0x38
	private static int _renderSamples; // 0x40
	[CompilerGenerated]
	private static int _TransitionWatchdogTotal_k__BackingField; // 0x44

	// Properties
	private static bool ProbeEnabled { get; } // 0x00000001805B35D0-0x00000001805B3650 
	public static int TransitionWatchdogTotal { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805B3650-0x00000001805B36A0 0x00000001805B36A0-0x00000001805B3700

	// Nested types
	[Serializable]
	private class Payload // TypeDefIndex: 1405
	{
		// Fields
		public string device; // 0x10
		public string os; // 0x18
		public string gpu; // 0x20
		public int memMb; // 0x28
		public int tier; // 0x2C
		public string version; // 0x30
		public string matchId; // 0x38
		public int frames; // 0x40
		public float p50; // 0x44
		public float p95; // 0x48
		public float p99; // 0x4C
		public float maxFrameMs; // 0x50
		public int hitch1HzCount; // 0x54
		public int gcCount; // 0x58
		public int gcAllocKB; // 0x5C
		public int rttP50; // 0x60
		public int enterMs; // 0x64
		public int exitMs; // 0x68
		public int turns; // 0x6C
		public int avgTurnRoundTripMs; // 0x70
		public int avgRenderMs; // 0x74

		// Constructors
		public Payload(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[CompilerGenerated]
	private sealed class _SendRoutine_d__73 : IEnumerator<object> // TypeDefIndex: 1406
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchPerfProbe __4__this; // 0x20
		public Payload p; // 0x28
		public string token; // 0x30
		private UnityWebRequest _req_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SendRoutine_d__73(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805D5330-0x00000001805D5410
		private bool MoveNext(); // 0x00000001805D4EE0-0x00000001805D52F0
		private void __m__Finally1(); // 0x00000001805D5410-0x00000001805D5460
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D52F0-0x00000001805D5330
	}

	// Constructors
	public MatchPerfProbe(); // 0x00000001805B3500-0x00000001805B35D0
	static MatchPerfProbe(); // 0x00000001805B3470-0x00000001805B3500

	// Methods
	public static void MarkEnterBegin(); // 0x00000001805B26E0-0x00000001805B2750
	public static void MarkEnterEnd(); // 0x00000001805B2750-0x00000001805B2800
	public static void MarkExitBegin(); // 0x00000001805B2800-0x00000001805B2870
	public static void MarkExitEnd(); // 0x00000001805B2870-0x00000001805B2920
	public static void MarkTurnRelease(); // 0x00000001805B2AA0-0x00000001805B2B40
	public static void MarkResRecv(); // 0x00000001805B2920-0x00000001805B29A0
	public static void MarkAckSent(); // 0x00000001805B2620-0x00000001805B26E0
	public static void MarkTurnEndRecv(); // 0x00000001805B29A0-0x00000001805B2AA0
	public static void NoteTransitionWatchdog(); // 0x00000001805B2B40-0x00000001805B2C20
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void Bootstrap(); // 0x00000001805B2120-0x00000001805B2240
	private void Update(); // 0x00000001805B31D0-0x00000001805B3470
	private void OnApplicationPause(bool paused); // 0x00000001805B2C20-0x00000001805B2C90
	private void BeginSample(); // 0x00000001805B1D50-0x00000001805B2120
	private void AccumulateFrame(); // 0x00000001805B1BF0-0x00000001805B1D50
	private void SampleGcAndRtt(); // 0x00000001805B2E20-0x00000001805B2F70
	private void EndSample(); // 0x00000001805B2560-0x00000001805B2620
	private void SendPending(Payload p); // 0x00000001805B2F70-0x00000001805B3120
	private Payload BuildPayload(int frames); // 0x00000001805B2240-0x00000001805B2560
	private float Percentile(int frames, float q); // 0x00000001805B2C90-0x00000001805B2D80
	private int RttP50(); // 0x00000001805B2D80-0x00000001805B2E20
	[IteratorStateMachine(typeof(_SendRoutine_d__73))]
	private IEnumerator SendRoutine(Payload p, string token); // 0x00000001805B3120-0x00000001805B31D0
}

