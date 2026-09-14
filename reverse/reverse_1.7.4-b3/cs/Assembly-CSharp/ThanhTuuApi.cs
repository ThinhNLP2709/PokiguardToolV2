/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class ThanhTuuApi // TypeDefIndex: 1234
{
	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass1_0 // TypeDefIndex: 1235
	{
		// Fields
		public Action<string> err; // 0x10
		public Action<ThanhTuuState> ok; // 0x18

		// Constructors
		public __c__DisplayClass1_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _GetState_b__0(ThanhTuuState state); // 0x00000001806F3400-0x00000001806F3450
		internal void _GetState_b__1(string raw); // 0x00000001806F3450-0x00000001806F3460
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass2_0 // TypeDefIndex: 1236
	{
		// Fields
		public Action<string> err; // 0x10
		public Action<ThanhTuuClaimResult> ok; // 0x18

		// Constructors
		public __c__DisplayClass2_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Claim_b__0(ThanhTuuClaimResult result); // 0x00000001806F3400-0x00000001806F3450
		internal void _Claim_b__1(string raw); // 0x00000001806F3450-0x00000001806F3460
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass3_0 // TypeDefIndex: 1237
	{
		// Fields
		public Action<string> err; // 0x10
		public Action<ThanhTuuClaimResult> ok; // 0x18

		// Constructors
		public __c__DisplayClass3_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Chest_b__0(ThanhTuuClaimResult result); // 0x00000001806F3400-0x00000001806F3450
		internal void _Chest_b__1(string raw); // 0x00000001806F3450-0x00000001806F3460
	}

	// Methods
	public static void GetState(Action<ThanhTuuState> ok, Action<string> err); // 0x00000001806F14A0-0x00000001806F19B0
	public static void Claim(int taskId, Action<ThanhTuuClaimResult> ok, Action<string> err); // 0x00000001806F19B0-0x00000001806F2030
	public static void Chest(int groupId, Action<ThanhTuuClaimResult> ok, Action<string> err); // 0x00000001806F2030-0x00000001806F26B0
	public static string ClaimSpinType(int taskId); // 0x00000001806F26B0-0x00000001806F2750
	public static string ChestSpinType(int groupId); // 0x00000001806F2750-0x00000001806F27F0
	public static ThanhTuuBusinessError Split(string err); // 0x00000001806F27F0-0x00000001806F2980
	public static string CodeOf(string err); // 0x00000001806F2980-0x00000001806F29A0
	public static string MessageOf(string err); // 0x00000001806F29A0-0x00000001806F2A20
	public static bool ShouldRefetch(string err); // 0x00000001806F2A20-0x00000001806F2C50
	private static bool Accept(ThanhTuuEnvelope packet, Action<string> err); // 0x00000001806F2C50-0x00000001806F2EC0
	private static void Fail(Action<string> err, string code, string message); // 0x00000001806F2EC0-0x00000001806F2F90
	private static void FailInfra(Action<string> err, string raw); // 0x00000001806F2F90-0x00000001806F31D0
	private static string FirstLine(string raw); // 0x00000001806F31D0-0x00000001806F3250
	private static bool HasStatus(string head, string status); // 0x00000001806F3250-0x00000001806F3400
}

