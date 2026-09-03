/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class AppVersionGate // TypeDefIndex: 1150
{
	// Fields
	public const string MODE_NONE = "NONE"; // Metadata: 0x0064D388
	public const string MODE_SOFT = "SOFT"; // Metadata: 0x0064D38D
	public const string MODE_FORCE = "FORCE"; // Metadata: 0x0064D392
	public const string MODE_MAINTENANCE = "MAINTENANCE"; // Metadata: 0x0064D398
	private const int TIMEOUT_SECONDS = 5; // Metadata: 0x0064D3A4
	private const double STICKY_HOURS = 12; // Metadata: 0x0064D3A5
	private const string PREF_STICKY_MODE = "GateStickyMode"; // Metadata: 0x0064D3AD
	private const string PREF_STICKY_AT = "GateStickyAtUtcTicks"; // Metadata: 0x0064D3BC
	private const string PREF_STICKY_MSG = "GateStickyMessage"; // Metadata: 0x0064D3D1
	[CompilerGenerated]
	private static AppBootstrapData _Data_k__BackingField; // 0x00
	[CompilerGenerated]
	private static string _Mode_k__BackingField; // 0x08
	[CompilerGenerated]
	private static bool _UsedFailOpen_k__BackingField; // 0x10
	[CompilerGenerated]
	private static string _BlockMessage_k__BackingField; // 0x18

	// Properties
	public static AppBootstrapData Data { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804AD0E0-0x00000001804AD130 0x00000001804AD510-0x00000001804AD580
	public static string Mode { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804AD240-0x00000001804AD290 0x00000001804AD580-0x00000001804AD5F0
	public static bool UsedFailOpen { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804AD450-0x00000001804AD4A0 0x00000001804AD5F0-0x00000001804AD650
	public static string BlockMessage { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804AD060-0x00000001804AD0B0 0x00000001804AD4A0-0x00000001804AD510
	public static bool IsBlocking { get; } // 0x00000001804AD130-0x00000001804AD240 
	public static string UpdateUrl { get; } // 0x00000001804AD290-0x00000001804AD450 
	public static string CurrentPlatform { get; } // 0x00000001804AD0B0-0x00000001804AD0E0 

	// Nested types
	[CompilerGenerated]
	private sealed class _Fetch_d__31 : IEnumerator<object> // TypeDefIndex: 1151
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private string _raw_5__2; // 0x20
		private bool _ok_5__3; // 0x28
		private string _err_5__4; // 0x30
		private UnityWebRequest _req_5__5; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Fetch_d__31(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804BD0F0-0x00000001804BD200
		private bool MoveNext(); // 0x00000001804BC6C0-0x00000001804BD0B0
		private void __m__Finally1(); // 0x00000001804BD200-0x00000001804BD250
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804BD0B0-0x00000001804BD0F0
	}

	// Constructors
	static AppVersionGate(); // 0x00000001804ACFF0-0x00000001804AD060

	// Methods
	[IteratorStateMachine(typeof(_Fetch_d__31))]
	public static IEnumerator Fetch(); // 0x00000001804AC920-0x00000001804AC970
	public static void OpenUpdateUrl(); // 0x00000001804ACA70-0x00000001804ACCF0
	private static string NormalizeMode(string m); // 0x00000001804AC970-0x00000001804ACA70
	private static void ApplyFailOpenOrSticky(string reason); // 0x00000001804AC600-0x00000001804AC890
	private static string ReadStickyMode(); // 0x00000001804ACCF0-0x00000001804ACEF0
	private static void RememberSticky(string mode, string message); // 0x00000001804ACEF0-0x00000001804ACFF0
	private static void ClearSticky(); // 0x00000001804AC890-0x00000001804AC920
}

