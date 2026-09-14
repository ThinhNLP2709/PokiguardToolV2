/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class CanDauVanApi // TypeDefIndex: 381
{
	// Nested types
	[Serializable]
	private class RollReq // TypeDefIndex: 382
	{
		// Fields
		public int rollSeq; // 0x10
		public long t; // 0x18
		public string s; // 0x20

		// Constructors
		public RollReq(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	private class BuyReq // TypeDefIndex: 383
	{
		// Fields
		public int qty; // 0x10
		public long t; // 0x18
		public string s; // 0x20

		// Constructors
		public BuyReq(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass4_0 // TypeDefIndex: 384
	{
		// Fields
		public Action<string> err; // 0x10
		public Action<CanDauVanState> ok; // 0x18

		// Constructors
		public __c__DisplayClass4_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _GetState_b__0(CanDauVanState state); // 0x0000000180322BD0-0x0000000180322C20
		internal void _GetState_b__1(string raw); // 0x0000000180322C20-0x0000000180322D70
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass5_0 // TypeDefIndex: 385
	{
		// Fields
		public Action<string> err; // 0x10
		public Action<CanDauVanRollResult> ok; // 0x18

		// Constructors
		public __c__DisplayClass5_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Roll_b__0(CanDauVanRollResult result); // 0x0000000180322BD0-0x0000000180322C20
		internal void _Roll_b__1(string raw); // 0x0000000180322D70-0x0000000180322EC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass6_0 // TypeDefIndex: 386
	{
		// Fields
		public Action<string> err; // 0x10
		public Action<CanDauVanBuyResult> ok; // 0x18

		// Constructors
		public __c__DisplayClass6_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Buy_b__0(CanDauVanBuyResult result); // 0x0000000180322BD0-0x0000000180322C20
		internal void _Buy_b__1(string raw); // 0x0000000180322EC0-0x0000000180323010
	}

	// Methods
	public static void GetState(Action<CanDauVanState> ok, Action<string> err); // 0x0000000180321060-0x0000000180321590
	public static void Roll(int rollSeq, Action<CanDauVanRollResult> ok, Action<string> err); // 0x0000000180321590-0x0000000180321C30
	public static void Buy(int qty, Action<CanDauVanBuyResult> ok, Action<string> err); // 0x0000000180321C30-0x00000001803222D0
	public static string RollSpinType(int rollSeq); // 0x00000001803222D0-0x0000000180322370
	public static string BuySpinType(int qty); // 0x0000000180322370-0x0000000180322410
	public static CanDauVanBusinessError Split(string err); // 0x0000000180322410-0x00000001803225A0
	public static string CodeOf(string err); // 0x00000001803225A0-0x00000001803225C0
	public static string MessageOf(string err); // 0x00000001803225C0-0x0000000180322640
	public static bool IsEnded(string err); // 0x0000000180322640-0x0000000180322720
	public static bool IsNoTicket(string err); // 0x0000000180322720-0x00000001803227B0
	public static bool IsStaleSeq(string err); // 0x00000001803227B0-0x0000000180322840
	private static bool Accept(CanDauVanEnvelope packet, Action<string> err); // 0x0000000180322840-0x0000000180322AA0
	private static void Fail(Action<string> err, string code, string message); // 0x0000000180322AA0-0x0000000180322B70
	private static string Infra(string raw); // 0x0000000180322B70-0x0000000180322BD0
}

