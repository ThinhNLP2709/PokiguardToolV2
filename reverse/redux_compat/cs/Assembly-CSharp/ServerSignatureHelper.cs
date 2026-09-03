/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class ServerSignatureHelper // TypeDefIndex: 1136
{
	// Nested types
	[Serializable]
	public class SignatureRequest // TypeDefIndex: 1137
	{
		// Fields
		public long userId; // 0x10
		public long bossScheduleId; // 0x18
		public int damageDealt; // 0x20
		public int turnCount; // 0x24
		public bool victory; // 0x28
		public long timestamp; // 0x30
		public string deviceId; // 0x38
		public string nonce; // 0x40
		public string gameVersion; // 0x48

		// Constructors
		public SignatureRequest(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class SignatureResponse // TypeDefIndex: 1138
	{
		// Fields
		public bool success; // 0x10
		public string signature; // 0x18
		public long serverTimestamp; // 0x20
		public string message; // 0x28
		public string sessionToken; // 0x30
		public string deviceId; // 0x38
		public string nonce; // 0x40

		// Constructors
		public SignatureResponse(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass2_0 // TypeDefIndex: 1139
	{
		// Fields
		public string deviceId; // 0x10
		public string nonce; // 0x18
		public Action<SignatureResponse> onSuccess; // 0x20
		public Action<string> onError; // 0x28

		// Constructors
		public __c__DisplayClass2_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RequestSignature_b__0(SignatureResponse response); // 0x00000001804C2E40-0x00000001804C2F70
		internal void _RequestSignature_b__1(string error); // 0x00000001804C2F70-0x00000001804C3010
	}

	[CompilerGenerated]
	private sealed class _RequestSignature_d__2 : IEnumerator<object> // TypeDefIndex: 1140
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<SignatureResponse> onSuccess; // 0x20
		public Action<string> onError; // 0x28
		public long userId; // 0x30
		public long bossScheduleId; // 0x38
		public int damageDealt; // 0x40
		public int turnCount; // 0x44
		public bool victory; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RequestSignature_d__2(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804C1790-0x00000001804C1AF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804C1AF0-0x00000001804C1B30
	}

	// Methods
	[IteratorStateMachine(typeof(_RequestSignature_d__2))]
	public static IEnumerator RequestSignature(long userId, long bossScheduleId, int damageDealt, int turnCount, bool victory, Action<SignatureResponse> onSuccess, Action<string> onError); // 0x00000001804B9960-0x00000001804B9A20
	public static string GenerateNonce(); // 0x00000001804B9880-0x00000001804B98E0
	public static long GetCurrentTimestamp(); // 0x00000001804B98E0-0x00000001804B9950
	public static string GetDeviceId(); // 0x00000001804B9950-0x00000001804B9960
	public static string CalculateChecksum(long userId, long bossId, int damage, int turnCount, bool victory); // 0x00000001804B9800-0x00000001804B9880
}

