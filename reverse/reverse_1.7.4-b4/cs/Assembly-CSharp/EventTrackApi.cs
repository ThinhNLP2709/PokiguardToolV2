/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class EventTrackApi // TypeDefIndex: 603
{
	// Nested types
	[Serializable]
	private class ClaimReq // TypeDefIndex: 604
	{
		// Fields
		public long milestoneId; // 0x10
		public long t; // 0x18
		public string s; // 0x20

		// Constructors
		public ClaimReq(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass2_0 // TypeDefIndex: 605
	{
		// Fields
		public Action<string> err; // 0x10
		public Action<EventTrackState> ok; // 0x18

		// Constructors
		public __c__DisplayClass2_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _GetState_b__0(EventTrackState state); // 0x000000018042ED70-0x000000018042EDC0
		internal void _GetState_b__1(string raw); // 0x000000018042EDC0-0x000000018042EF10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass3_0 // TypeDefIndex: 606
	{
		// Fields
		public Action<string> err; // 0x10
		public Action<EventTrackClaimResult> ok; // 0x18

		// Constructors
		public __c__DisplayClass3_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Claim_b__0(EventTrackClaimResult result); // 0x000000018042ED70-0x000000018042EDC0
		internal void _Claim_b__1(string raw); // 0x000000018042EF10-0x000000018042F060
	}

	// Methods
	public static void GetState(string key, Action<EventTrackState> ok, Action<string> err); // 0x000000018042D870-0x000000018042DDB0
	public static void Claim(string key, long milestoneId, Action<EventTrackClaimResult> ok, Action<string> err); // 0x000000018042DDB0-0x000000018042E4A0
	public static string SpinType(string key, long milestoneId); // 0x000000018042E4A0-0x000000018042E580
	public static EventTrackBusinessError Split(string err); // 0x000000018042E580-0x000000018042E710
	public static string CodeOf(string err); // 0x000000018042E710-0x000000018042E730
	public static string MessageOf(string err); // 0x000000018042E730-0x000000018042E7B0
	public static bool IsEnded(string err); // 0x000000018042E7B0-0x000000018042E890
	private static bool Accept(EventTrackState state, Action<string> err); // 0x000000018042E890-0x000000018042EAF0
	private static void Fail(Action<string> err, string code, string message); // 0x000000018042EAF0-0x000000018042EBC0
	private static string Infra(string raw); // 0x000000018042EBC0-0x000000018042EC20
	public static string SafeKey(string key); // 0x000000018042EC20-0x000000018042ED70
}

