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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class MatchPerfProbe : MonoBehaviour // TypeDefIndex: 1788
{
	// Fields
	private const string RC_PROBE = "perf.probe"; // Metadata: 0x005F156F
	public const string PREF_PROBE = "ff_PerfProbe"; // Metadata: 0x005F157A
	private const int WARMUP_FRAMES = 5; // Metadata: 0x005F1587
	private const float HITCH_MS = 50f; // Metadata: 0x005F1588
	private const float BUCKET_MS = 0.5f; // Metadata: 0x005F158C
	private const int BUCKETS = 401; // Metadata: 0x005F1590
	private const float SAMPLE_EVERY_SEC = 5f; // Metadata: 0x005F1592
	private const int RTT_SLOTS = 64; // Metadata: 0x005F1596
	private const float MIN_SEND_INTERVAL_SEC = 60f; // Metadata: 0x005F1598
	private const int MIN_FRAMES_TO_SEND = 30; // Metadata: 0x005F159C
	private const float POST_EXIT_DELAY_SEC = 5f; // Metadata: 0x005F159D
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
	private static bool ProbeEnabled { get; } // 0x00000001808DFA10-0x00000001808DFAB0 
	public static int TransitionWatchdogTotal { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808E0240-0x00000001808E02A0 0x00000001808E02A0-0x00000001808E0300

	// Nested types
	[Serializable]
	private class Payload // TypeDefIndex: 1789
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
		public double clockDriftPct; // 0x78

		// Constructors
		public Payload(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class _SendRoutine_d__74 : IEnumerator<object> // TypeDefIndex: 1790
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchPerfProbe __4__this; // 0x20
		public Payload p; // 0x28
		public string token; // 0x30
		private UnityWebRequest _req_5__2; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SendRoutine_d__74(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808E2670-0x00000001808E27A0
		private bool MoveNext(); // 0x00000001808E27A0-0x00000001808E2D10
		private void __m__Finally1(); // 0x00000001808E2D10-0x00000001808E2D70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808E2D70-0x00000001808E2DB0
	}

	// Constructors
	public MatchPerfProbe(); // 0x00000001808E1C60-0x00000001808E1E80
	static MatchPerfProbe(); // 0x00000001808E1E80-0x00000001808E2670

	// Methods
	public static void MarkEnterBegin(); // 0x00000001808DFAB0-0x00000001808DFB60
	public static void MarkEnterEnd(); // 0x00000001808DFB60-0x00000001808DFC40
	public static void MarkExitBegin(); // 0x00000001808DFC40-0x00000001808DFCF0
	public static void MarkExitEnd(); // 0x00000001808DFCF0-0x00000001808DFDD0
	public static void MarkTurnRelease(); // 0x00000001808DFDD0-0x00000001808DFEB0
	public static void MarkResRecv(); // 0x00000001808DFEB0-0x00000001808DFF40
	public static void MarkAckSent(); // 0x00000001808DFF40-0x00000001808E0010
	public static void MarkTurnEndRecv(); // 0x00000001808E0010-0x00000001808E0150
	public static void NoteTransitionWatchdog(); // 0x00000001808E0150-0x00000001808E0240
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void Bootstrap(); // 0x00000001808E0300-0x00000001808E0500
	private void Update(); // 0x00000001808E0500-0x00000001808E0640
	private void OnApplicationPause(bool paused); // 0x00000001808E0640-0x00000001808E06C0
	private void BeginSample(); // 0x00000001808E06C0-0x00000001808E0B30
	private void AccumulateFrame(); // 0x00000001808E0B30-0x00000001808E0D10
	private void SampleGcAndRtt(); // 0x00000001808E0D10-0x00000001808E0F40
	private void EndSample(); // 0x00000001808E0F40-0x00000001808E1080
	private void SendPending(Payload p); // 0x00000001808E1080-0x00000001808E1340
	private Payload BuildPayload(int frames); // 0x00000001808E1340-0x00000001808E17A0
	private static double ClockDriftMonitorDrift(); // 0x00000001808E17A0-0x00000001808E1870
	private float Percentile(int frames, float q); // 0x00000001808E1870-0x00000001808E1910
	private int RttP50(); // 0x00000001808E1910-0x00000001808E1B00
	[IteratorStateMachine(typeof(_SendRoutine_d__74))]
	private IEnumerator SendRoutine(Payload p, string token); // 0x00000001808E1B00-0x00000001808E1C60
}

