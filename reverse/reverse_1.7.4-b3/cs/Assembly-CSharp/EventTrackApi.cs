/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class EventTrackApi // TypeDefIndex: 602
{
	// Nested types
	[Serializable]
	private class ClaimReq // TypeDefIndex: 603
	{
		// Fields
		public long milestoneId; // 0x10
		public long t; // 0x18
		public string s; // 0x20

		// Constructors
		public ClaimReq(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass2_0 // TypeDefIndex: 604
	{
		// Fields
		public Action<string> err; // 0x10
		public Action<EventTrackState> ok; // 0x18

		// Constructors
		public __c__DisplayClass2_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _GetState_b__0(EventTrackState state); // 0x000000018042DCA0-0x000000018042DCF0
		internal void _GetState_b__1(string raw); // 0x000000018042DCF0-0x000000018042DE40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass3_0 // TypeDefIndex: 605
	{
		// Fields
		public Action<string> err; // 0x10
		public Action<EventTrackClaimResult> ok; // 0x18

		// Constructors
		public __c__DisplayClass3_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Claim_b__0(EventTrackClaimResult result); // 0x000000018042DCA0-0x000000018042DCF0
		internal void _Claim_b__1(string raw); // 0x000000018042DE40-0x000000018042DF90
	}

	// Methods
	public static void GetState(string key, Action<EventTrackState> ok, Action<string> err); // 0x000000018042C7E0-0x000000018042CD00
	public static void Claim(string key, long milestoneId, Action<EventTrackClaimResult> ok, Action<string> err); // 0x000000018042CD00-0x000000018042D3D0
	public static string SpinType(string key, long milestoneId); // 0x000000018042D3D0-0x000000018042D4B0
	public static EventTrackBusinessError Split(string err); // 0x000000018042D4B0-0x000000018042D640
	public static string CodeOf(string err); // 0x000000018042D640-0x000000018042D660
	public static string MessageOf(string err); // 0x000000018042D660-0x000000018042D6E0
	public static bool IsEnded(string err); // 0x000000018042D6E0-0x000000018042D7C0
	private static bool Accept(EventTrackState state, Action<string> err); // 0x000000018042D7C0-0x000000018042DA20
	private static void Fail(Action<string> err, string code, string message); // 0x000000018042DA20-0x000000018042DAF0
	private static string Infra(string raw); // 0x000000018042DAF0-0x000000018042DB50
	public static string SafeKey(string key); // 0x000000018042DB50-0x000000018042DCA0
}

