/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[Serializable]
public class ThanhTuuState : ThanhTuuEnvelope // TypeDefIndex: 1283
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
	public static int SelfUserId { get; } // 0x000000018071A3E0-0x000000018071A430 
	public static ThanhTuuState Current { get; } // 0x000000018071A430-0x000000018071A490 

	// Events
	public static event Action OnChanged {
		add; // 0x000000018071A180-0x000000018071A2B0
		remove; // 0x000000018071A2B0-0x000000018071A3E0
	}

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass30_0 // TypeDefIndex: 1284
	{
		// Fields
		public int gen; // 0x10

		// Constructors
		public __c__DisplayClass30_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RefetchIfStale_b__0(ThanhTuuState s); // 0x000000018071B010-0x000000018071B090
		internal void _RefetchIfStale_b__1(string err); // 0x000000018071B090-0x000000018071B100
	}

	// Constructors
	public ThanhTuuState(); // 0x000000018028A320-0x000000018028A330
	static ThanhTuuState(); // 0x000000018071AE90-0x000000018071B010

	// Methods
	public ThanhTuuGroup FindGroup(int groupId); // 0x000000018071A0B0-0x000000018071A180
	public static void Set(ThanhTuuState s); // 0x000000018071A490-0x000000018071A610
	public static bool Set(ThanhTuuState s, bool force); // 0x000000018071A610-0x000000018071A770
	public static bool IsOlder(ThanhTuuState a, ThanhTuuState b); // 0x000000018071A770-0x000000018071A7A0
	public static void RefetchIfStale(float seconds, Action onDone = null); // 0x000000018071A7A0-0x000000018071A9F0
	private static void Fire(); // 0x000000018071A9F0-0x000000018071ABC0
	private static void FlushWaiters(); // 0x000000018071ABC0-0x000000018071ACE0
	private static void Invoke(Action a); // 0x000000018071ACE0-0x000000018071AD80
	private static void SyncOwner(); // 0x000000018071AD80-0x000000018071AE90
	private static float Now(); // 0x0000000180345270-0x00000001803452C0
}

