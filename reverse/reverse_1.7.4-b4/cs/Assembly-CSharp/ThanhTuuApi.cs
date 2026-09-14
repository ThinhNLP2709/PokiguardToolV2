/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class ThanhTuuApi // TypeDefIndex: 1236
{
	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass1_0 // TypeDefIndex: 1237
	{
		// Fields
		public Action<string> err; // 0x10
		public Action<ThanhTuuState> ok; // 0x18

		// Constructors
		public __c__DisplayClass1_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _GetState_b__0(ThanhTuuState state); // 0x00000001806F51B0-0x00000001806F5200
		internal void _GetState_b__1(string raw); // 0x00000001806F5200-0x00000001806F5210
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass2_0 // TypeDefIndex: 1238
	{
		// Fields
		public Action<string> err; // 0x10
		public Action<ThanhTuuClaimResult> ok; // 0x18

		// Constructors
		public __c__DisplayClass2_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Claim_b__0(ThanhTuuClaimResult result); // 0x00000001806F51B0-0x00000001806F5200
		internal void _Claim_b__1(string raw); // 0x00000001806F5200-0x00000001806F5210
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass3_0 // TypeDefIndex: 1239
	{
		// Fields
		public Action<string> err; // 0x10
		public Action<ThanhTuuClaimResult> ok; // 0x18

		// Constructors
		public __c__DisplayClass3_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Chest_b__0(ThanhTuuClaimResult result); // 0x00000001806F51B0-0x00000001806F5200
		internal void _Chest_b__1(string raw); // 0x00000001806F5200-0x00000001806F5210
	}

	// Methods
	public static void GetState(Action<ThanhTuuState> ok, Action<string> err); // 0x00000001806F31D0-0x00000001806F3700
	public static void Claim(int taskId, Action<ThanhTuuClaimResult> ok, Action<string> err); // 0x00000001806F3700-0x00000001806F3DB0
	public static void Chest(int groupId, Action<ThanhTuuClaimResult> ok, Action<string> err); // 0x00000001806F3DB0-0x00000001806F4460
	public static string ClaimSpinType(int taskId); // 0x00000001806F4460-0x00000001806F4500
	public static string ChestSpinType(int groupId); // 0x00000001806F4500-0x00000001806F45A0
	public static ThanhTuuBusinessError Split(string err); // 0x00000001806F45A0-0x00000001806F4730
	public static string CodeOf(string err); // 0x00000001806F4730-0x00000001806F4750
	public static string MessageOf(string err); // 0x00000001806F4750-0x00000001806F47D0
	public static bool ShouldRefetch(string err); // 0x00000001806F47D0-0x00000001806F4A00
	private static bool Accept(ThanhTuuEnvelope packet, Action<string> err); // 0x00000001806F4A00-0x00000001806F4C70
	private static void Fail(Action<string> err, string code, string message); // 0x00000001806F4C70-0x00000001806F4D40
	private static void FailInfra(Action<string> err, string raw); // 0x00000001806F4D40-0x00000001806F4F80
	private static string FirstLine(string raw); // 0x00000001806F4F80-0x00000001806F5000
	private static bool HasStatus(string head, string status); // 0x00000001806F5000-0x00000001806F51B0
}

