/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

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
	public CanDauVanEventInfo Info { get; } // 0x00000001802BA5D0-0x00000001802BA5E0 
	public CanDauVanTheme Theme { get; } // 0x0000000180344350-0x0000000180344370 
	public CanDauVanStrings Str { get; } // 0x0000000180344370-0x00000001803443E0 
	public CanDauVanRules Rules { get; } // 0x00000001803443E0-0x0000000180344520 
	public int TrackLen { get; } // 0x0000000180344520-0x0000000180344560 
	public int Tickets { get; } // 0x0000000180344560-0x0000000180344580 
	public bool IsSoon { get; } // 0x0000000180344580-0x00000001803446A0 
	public static int SelfUserId { get; } // 0x0000000180344940-0x0000000180344990 
	public static CanDauVanState Current { get; } // 0x0000000180344990-0x00000001803449F0 

	// Events
	public static event Action OnChanged {
		add; // 0x00000001803446E0-0x0000000180344810
		remove; // 0x0000000180344810-0x0000000180344940
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
		static __c(); // 0x0000000180345440-0x00000001803454E0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RequestRefresh_b__49_0(CanDauVanState s); // 0x00000001803454E0-0x0000000180345550
		internal void _RequestRefresh_b__49_1(string err); // 0x0000000180345550-0x00000001803455B0
	}

	// Constructors
	public CanDauVanState(); // 0x000000018028A320-0x000000018028A330
	static CanDauVanState(); // 0x00000001803453E0-0x0000000180345440

	// Methods
	public CanDauVanTile TileAt(int idx); // 0x00000001803446A0-0x00000001803446E0
	public static void Apply(CanDauVanState s); // 0x00000001803449F0-0x0000000180344B00
	public static void ApplyRoll(CanDauVanRollResult r); // 0x0000000180344B00-0x0000000180344C60
	public static void ApplyBuy(CanDauVanBuyResult r); // 0x0000000180344C60-0x0000000180344E70
	public static void RequestRefresh(bool force = false /* Metadata: 0x005EF2B4 */); // 0x0000000180344E70-0x00000001803451B0
	private static void Fire(); // 0x00000001803451B0-0x00000001803452A0
	private static void SyncOwner(); // 0x00000001803452A0-0x0000000180345390
	private static float Now(); // 0x0000000180345390-0x00000001803453E0
}

