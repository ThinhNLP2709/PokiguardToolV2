/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class AppVersionGate // TypeDefIndex: 1365
{
	// Fields
	public const string MODE_NONE = "NONE"; // Metadata: 0x0068CEE3
	public const string MODE_SOFT = "SOFT"; // Metadata: 0x0068CEE8
	public const string MODE_FORCE = "FORCE"; // Metadata: 0x0068CEED
	public const string MODE_MAINTENANCE = "MAINTENANCE"; // Metadata: 0x0068CEF3
	private const int TIMEOUT_SECONDS = 5; // Metadata: 0x0068CEFF
	private const double STICKY_HOURS = 12; // Metadata: 0x0068CF00
	private const string PREF_STICKY_MODE = "GateStickyMode"; // Metadata: 0x0068CF08
	private const string PREF_STICKY_AT = "GateStickyAtUtcTicks"; // Metadata: 0x0068CF17
	private const string PREF_STICKY_MSG = "GateStickyMessage"; // Metadata: 0x0068CF2C
	[CompilerGenerated]
	private static AppBootstrapData _Data_k__BackingField; // 0x00
	[CompilerGenerated]
	private static string _Mode_k__BackingField; // 0x08
	[CompilerGenerated]
	private static bool _UsedFailOpen_k__BackingField; // 0x10
	[CompilerGenerated]
	private static string _BlockMessage_k__BackingField; // 0x18

	// Properties
	public static AppBootstrapData Data { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805A8890-0x00000001805A88E0 0x00000001805A8CC0-0x00000001805A8D30
	public static string Mode { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805A89F0-0x00000001805A8A40 0x00000001805A8D30-0x00000001805A8DA0
	public static bool UsedFailOpen { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805A8C00-0x00000001805A8C50 0x00000001805A8DA0-0x00000001805A8E00
	public static string BlockMessage { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805A8810-0x00000001805A8860 0x00000001805A8C50-0x00000001805A8CC0
	public static bool IsBlocking { get; } // 0x00000001805A88E0-0x00000001805A89F0 
	public static string UpdateUrl { get; } // 0x00000001805A8A40-0x00000001805A8C00 
	public static string CurrentPlatform { get; } // 0x00000001805A8860-0x00000001805A8890 

	// Nested types
	[CompilerGenerated]
	private sealed class _Fetch_d__31 : IEnumerator<object> // TypeDefIndex: 1366
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private string _raw_5__2; // 0x20
		private bool _ok_5__3; // 0x28
		private string _err_5__4; // 0x30
		private UnityWebRequest _req_5__5; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Fetch_d__31(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805B8340-0x00000001805B8450
		private bool MoveNext(); // 0x00000001805B7910-0x00000001805B8300
		private void __m__Finally1(); // 0x00000001805B8450-0x00000001805B84A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805B8300-0x00000001805B8340
	}

	// Constructors
	static AppVersionGate(); // 0x00000001805A87A0-0x00000001805A8810

	// Methods
	[IteratorStateMachine(typeof(_Fetch_d__31))]
	public static IEnumerator Fetch(); // 0x00000001805A8020-0x00000001805A8070
	public static void OpenUpdateUrl(); // 0x00000001805A8220-0x00000001805A84A0
	public static int CompareVersion(string a, string b); // 0x00000001805A7E10-0x00000001805A8020
	private static int LeadingNumber(string s); // 0x00000001805A8070-0x00000001805A8120
	private static string NormalizeMode(string m); // 0x00000001805A8120-0x00000001805A8220
	private static void ApplyFailOpenOrSticky(string reason); // 0x00000001805A7AF0-0x00000001805A7D80
	private static string ReadStickyMode(); // 0x00000001805A84A0-0x00000001805A86A0
	private static void RememberSticky(string mode, string message); // 0x00000001805A86A0-0x00000001805A87A0
	private static void ClearSticky(); // 0x00000001805A7D80-0x00000001805A7E10
}

