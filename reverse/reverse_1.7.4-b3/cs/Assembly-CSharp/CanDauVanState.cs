/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[Serializable]
public class CanDauVanState : CanDauVanEnvelope // TypeDefIndex: 424
{
	// Fields
	public long serverTime; // 0x20
	public bool active; // 0x28
	public bool ended; // 0x29
	public long secondsLeft; // 0x30
	public CanDauVanEventInfo @event; // 0x38
	public CanDauVanRules rules; // 0x40
	public CanDauVanPlayer player; // 0x48
	public CanDauVanTile[] track; // 0x50
	public CanDauVanWallet wallet; // 0x58
	private static CanDauVanState _current; // 0x00
	private static float _lastFetchAt; // 0x08
	private static bool _inflight; // 0x0C
	private static int _ownerId; // 0x10
	[CompilerGenerated]
	private static Action OnChanged; // 0x18

	// Properties
	public CanDauVanEventInfo Info { get; } // 0x00000001802BA5A0-0x00000001802BA5B0 
	public CanDauVanTheme Theme { get; } // 0x0000000180344230-0x0000000180344250 
	public CanDauVanStrings Str { get; } // 0x0000000180344250-0x00000001803442C0 
	public CanDauVanRules Rules { get; } // 0x00000001803442C0-0x0000000180344400 
	public int TrackLen { get; } // 0x0000000180344400-0x0000000180344440 
	public int Tickets { get; } // 0x0000000180344440-0x0000000180344460 
	public bool IsSoon { get; } // 0x0000000180344460-0x0000000180344580 
	public static int SelfUserId { get; } // 0x0000000180344820-0x0000000180344870 
	public static CanDauVanState Current { get; } // 0x0000000180344870-0x00000001803448D0 

	// Events
	public static event Action OnChanged {
		add; // 0x00000001803445C0-0x00000001803446F0
		remove; // 0x00000001803446F0-0x0000000180344820
	}

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 425
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<CanDauVanState> __9__49_0; // 0x08
		public static Action<string> __9__49_1; // 0x10

		// Constructors
		static __c(); // 0x0000000180345320-0x00000001803453C0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RequestRefresh_b__49_0(CanDauVanState s); // 0x00000001803453C0-0x0000000180345430
		internal void _RequestRefresh_b__49_1(string err); // 0x0000000180345430-0x0000000180345490
	}

	// Constructors
	public CanDauVanState(); // 0x000000018028A320-0x000000018028A330
	static CanDauVanState(); // 0x00000001803452C0-0x0000000180345320

	// Methods
	public CanDauVanTile TileAt(int idx); // 0x0000000180344580-0x00000001803445C0
	public static void Apply(CanDauVanState s); // 0x00000001803448D0-0x00000001803449E0
	public static void ApplyRoll(CanDauVanRollResult r); // 0x00000001803449E0-0x0000000180344B40
	public static void ApplyBuy(CanDauVanBuyResult r); // 0x0000000180344B40-0x0000000180344D50
	public static void RequestRefresh(bool force = false /* Metadata: 0x005EDEE4 */); // 0x0000000180344D50-0x0000000180345090
	private static void Fire(); // 0x0000000180345090-0x0000000180345180
	private static void SyncOwner(); // 0x0000000180345180-0x0000000180345270
	private static float Now(); // 0x0000000180345270-0x00000001803452C0
}

