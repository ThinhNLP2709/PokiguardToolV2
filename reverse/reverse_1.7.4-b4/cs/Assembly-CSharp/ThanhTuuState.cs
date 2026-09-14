/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[Serializable]
public class ThanhTuuState : ThanhTuuEnvelope // TypeDefIndex: 1285
{
	// Fields
	public long serverTime; // 0x20
	public bool active; // 0x28
	public bool claimEnabled; // 0x29
	public int claimable; // 0x2C
	public ThanhTuuStrings strings; // 0x30
	public ThanhTuuTheme theme; // 0x38
	public ThanhTuuWallet wallet; // 0x40
	public ThanhTuuCategory[] categories; // 0x48
	public string[] feed; // 0x50
	private static ThanhTuuState _current; // 0x00
	private static float _lastFetchAt; // 0x08
	private static bool _inflight; // 0x0C
	private static readonly List<Action> _waiters; // 0x10
	private static int _ownerId; // 0x18
	private static int _generation; // 0x1C
	[CompilerGenerated]
	private static Action OnChanged; // 0x20

	// Properties
	public static int SelfUserId { get; } // 0x000000018071C190-0x000000018071C1E0 
	public static ThanhTuuState Current { get; } // 0x000000018071C1E0-0x000000018071C240 

	// Events
	public static event Action OnChanged {
		add; // 0x000000018071BF30-0x000000018071C060
		remove; // 0x000000018071C060-0x000000018071C190
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass30_0 // TypeDefIndex: 1286
	{
		// Fields
		public int gen; // 0x10

		// Constructors
		public __c__DisplayClass30_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RefetchIfStale_b__0(ThanhTuuState s); // 0x000000018071CDC0-0x000000018071CE40
		internal void _RefetchIfStale_b__1(string err); // 0x000000018071CE40-0x000000018071CEB0
	}

	// Constructors
	public ThanhTuuState(); // 0x000000018028A320-0x000000018028A330
	static ThanhTuuState(); // 0x000000018071CC40-0x000000018071CDC0

	// Methods
	public ThanhTuuGroup FindGroup(int groupId); // 0x000000018071BE60-0x000000018071BF30
	public static void Set(ThanhTuuState s); // 0x000000018071C240-0x000000018071C3C0
	public static bool Set(ThanhTuuState s, bool force); // 0x000000018071C3C0-0x000000018071C520
	public static bool IsOlder(ThanhTuuState a, ThanhTuuState b); // 0x000000018071C520-0x000000018071C550
	public static void RefetchIfStale(float seconds, Action onDone = null); // 0x000000018071C550-0x000000018071C7A0
	private static void Fire(); // 0x000000018071C7A0-0x000000018071C970
	private static void FlushWaiters(); // 0x000000018071C970-0x000000018071CA90
	private static void Invoke(Action a); // 0x000000018071CA90-0x000000018071CB30
	private static void SyncOwner(); // 0x000000018071CB30-0x000000018071CC40
	private static float Now(); // 0x0000000180345390-0x00000001803453E0
}

