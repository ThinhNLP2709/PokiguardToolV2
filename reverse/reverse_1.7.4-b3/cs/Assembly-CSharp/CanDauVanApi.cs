/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

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
		internal void _GetState_b__0(CanDauVanState state); // 0x0000000180322AB0-0x0000000180322B00
		internal void _GetState_b__1(string raw); // 0x0000000180322B00-0x0000000180322C50
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
		internal void _Roll_b__0(CanDauVanRollResult result); // 0x0000000180322AB0-0x0000000180322B00
		internal void _Roll_b__1(string raw); // 0x0000000180322C50-0x0000000180322DA0
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
		internal void _Buy_b__0(CanDauVanBuyResult result); // 0x0000000180322AB0-0x0000000180322B00
		internal void _Buy_b__1(string raw); // 0x0000000180322DA0-0x0000000180322EF0
	}

	// Methods
	public static void GetState(Action<CanDauVanState> ok, Action<string> err); // 0x0000000180320FB0-0x00000001803214B0
	public static void Roll(int rollSeq, Action<CanDauVanRollResult> ok, Action<string> err); // 0x00000001803214B0-0x0000000180321B30
	public static void Buy(int qty, Action<CanDauVanBuyResult> ok, Action<string> err); // 0x0000000180321B30-0x00000001803221B0
	public static string RollSpinType(int rollSeq); // 0x00000001803221B0-0x0000000180322250
	public static string BuySpinType(int qty); // 0x0000000180322250-0x00000001803222F0
	public static CanDauVanBusinessError Split(string err); // 0x00000001803222F0-0x0000000180322480
	public static string CodeOf(string err); // 0x0000000180322480-0x00000001803224A0
	public static string MessageOf(string err); // 0x00000001803224A0-0x0000000180322520
	public static bool IsEnded(string err); // 0x0000000180322520-0x0000000180322600
	public static bool IsNoTicket(string err); // 0x0000000180322600-0x0000000180322690
	public static bool IsStaleSeq(string err); // 0x0000000180322690-0x0000000180322720
	private static bool Accept(CanDauVanEnvelope packet, Action<string> err); // 0x0000000180322720-0x0000000180322980
	private static void Fail(Action<string> err, string code, string message); // 0x0000000180322980-0x0000000180322A50
	private static string Infra(string raw); // 0x0000000180322A50-0x0000000180322AB0
}

