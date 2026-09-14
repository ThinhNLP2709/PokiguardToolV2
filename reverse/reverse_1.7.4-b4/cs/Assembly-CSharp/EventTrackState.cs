/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[Serializable]
public class EventTrackState // TypeDefIndex: 639
{
	// Fields
	public long serverTime; // 0x10
	public bool active; // 0x18
	public bool ended; // 0x19
	public EventTrackEvent @event; // 0x20
	public EventTrackRules rules; // 0x28
	public EventTrackProgress progress; // 0x30
	public EventTrackSurge surge; // 0x38
	public EventTrackMilestone[] milestones; // 0x40
	public long secondsLeft; // 0x48
	public long secondsToDailyReset; // 0x50
	public EventTrackWallet wallet; // 0x58
	public string code; // 0x60
	public string message; // 0x68
	private static readonly Dictionary<string, EventTrackState> _cache; // 0x00
	private static readonly Dictionary<string, int> _predicted; // 0x08
	private static readonly Dictionary<string, float> _lastFetchAt; // 0x10
	private static readonly HashSet<string> _inflight; // 0x18
	private static int _ownerId; // 0x20
	[CompilerGenerated]
	private static Action<string> OnChanged; // 0x28
	[CompilerGenerated]
	private static Action<string, int> OnPredictedGain; // 0x30
	private static ChatService _hooked; // 0x38

	// Properties
	public EventTrackEvent Info { get; } // 0x00000001802A8720-0x00000001802A8730 
	public string Key { get; } // 0x00000001804418D0-0x0000000180441930 
	public EventTrackTheme Theme { get; } // 0x0000000180441930-0x0000000180441950 
	public EventTrackStrings Str { get; } // 0x0000000180441950-0x0000000180441A10 
	public bool IsBusinessError { get; } // 0x0000000180441A10-0x0000000180441AA0 
	public bool HasClaimable { get; } // 0x0000000180441AA0-0x0000000180441B40 
	public static int SelfUserId { get; } // 0x0000000180442080-0x00000001804420D0 

	// Events
	public static event Action<string> OnChanged {
		add; // 0x0000000180441B40-0x0000000180441C90
		remove; // 0x0000000180441C90-0x0000000180441DE0
	}
	public static event Action<string, int> OnPredictedGain {
		add; // 0x0000000180441DE0-0x0000000180441F30
		remove; // 0x0000000180441F30-0x0000000180442080
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass47_0 // TypeDefIndex: 640
	{
		// Fields
		public string k; // 0x10

		// Constructors
		public __c__DisplayClass47_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RequestRefresh_b__0(EventTrackState s); // 0x0000000180443F10-0x0000000180443FC0
		internal void _RequestRefresh_b__1(string err); // 0x0000000180443FC0-0x0000000180444050
	}

	// Constructors
	public EventTrackState(); // 0x000000018028A320-0x000000018028A330
	static EventTrackState(); // 0x00000001804439A0-0x0000000180443F10

	// Methods
	public static EventTrackState Get(string key); // 0x00000001804420D0-0x0000000180442190
	public static void Apply(string key, EventTrackState s); // 0x0000000180442190-0x00000001804423E0
	public static void RequestRefresh(string key, bool force = false /* Metadata: 0x005EF835 */); // 0x00000001804423E0-0x0000000180442820
	public static void EnsureEnergyHook(); // 0x0000000180442820-0x0000000180442B80
	public static void ReleaseEnergyHook(); // 0x0000000180442B80-0x0000000180442E80
	private static void HandleEnergyDelta(ChatMessageDTO msg); // 0x0000000180442E80-0x0000000180443250
	private static void PredictOne(string k, int spent, string reason); // 0x0000000180443250-0x0000000180443690
	private static int Extra(string k); // 0x0000000180443690-0x0000000180443770
	private static void Fire(string k); // 0x0000000180443770-0x0000000180443860
	private static void SyncOwner(); // 0x0000000180443860-0x00000001804439A0
	private static float Now(); // 0x0000000180345390-0x00000001803453E0
}

