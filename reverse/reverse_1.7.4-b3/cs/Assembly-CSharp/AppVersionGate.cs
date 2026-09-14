/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class AppVersionGate // TypeDefIndex: 1747
{
	// Fields
	[CompilerGenerated]
	private static AppBootstrapData _Data_k__BackingField; // 0x00
	[CompilerGenerated]
	private static string _Mode_k__BackingField; // 0x08
	[CompilerGenerated]
	private static bool _UsedFailOpen_k__BackingField; // 0x10
	[CompilerGenerated]
	private static string _BlockMessage_k__BackingField; // 0x18

	// Properties
	public static AppBootstrapData Data { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808CAFE0-0x00000001808CB040 0x00000001808CB040-0x00000001808CB0F0
	public static string Mode { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808CB0F0-0x00000001808CB150 0x00000001808CB150-0x00000001808CB210
	public static bool UsedFailOpen { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808CB210-0x00000001808CB270 0x00000001808CB270-0x00000001808CB2D0
	public static string BlockMessage { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808CB2D0-0x00000001808CB330 0x00000001808CB330-0x00000001808CB3F0
	public static bool IsBlocking { get; } // 0x00000001808CB3F0-0x00000001808CB4E0 
	public static string UpdateUrl { get; } // 0x00000001808CB4E0-0x00000001808CB5F0 
	public static string CurrentPlatform { get; } // 0x00000001808CB5F0-0x00000001808CB630 

	// Nested types
	[CompilerGenerated]
	private sealed class _Fetch_d__31 : IEnumerator<object> // TypeDefIndex: 1748
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private string _raw_5__2; // 0x20
		private bool _ok_5__3; // 0x28
		private string _err_5__4; // 0x30
		private UnityWebRequest _req_5__5; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Fetch_d__31(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808CC610-0x00000001808CC820
		private bool MoveNext(); // 0x00000001808CC820-0x00000001808CD6C0
		private void __m__Finally1(); // 0x00000001808CD6C0-0x00000001808CD720
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808CD720-0x00000001808CD760
	}

	// Constructors
	static AppVersionGate(); // 0x00000001808CC550-0x00000001808CC610

	// Methods
	[IteratorStateMachine(typeof(_Fetch_d__31))]
	public static IEnumerator Fetch(); // 0x00000001808CB630-0x00000001808CB670
	public static void OpenUpdateUrl(); // 0x00000001808CB670-0x00000001808CB860
	public static int CompareVersion(string a, string b); // 0x00000001808CB860-0x00000001808CBAF0
	private static int LeadingNumber(string s); // 0x00000001808CBAF0-0x00000001808CBB80
	private static string NormalizeMode(string m); // 0x00000001808CBB80-0x00000001808CBD10
	private static void ApplyFailOpenOrSticky(string reason); // 0x00000001808CBD10-0x00000001808CBF50
	private static string ReadStickyMode(); // 0x00000001808CBF50-0x00000001808CC2B0
	private static void RememberSticky(string mode, string message); // 0x00000001808CC2B0-0x00000001808CC480
	private static void ClearSticky(); // 0x00000001808CC480-0x00000001808CC550
}

