/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class GetUserBasicInfo : MonoBehaviour // TypeDefIndex: 16
{
	// Fields
	[CompilerGenerated]
	private static GetUserBasicInfo _Instance_k__BackingField; // 0x00
	private string API_URL; // 0x20
	private string authToken; // 0x28
	private Dictionary<string, Action<UserBasicInfo>> callbacks; // 0x30

	// Properties
	public static GetUserBasicInfo Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F5F60-0x00000001802F5FA0 0x00000001802F5FA0-0x00000001802F6000

	// Nested types
	[Serializable]
	private class UsernameRequest // TypeDefIndex: 17
	{
		// Fields
		public string username; // 0x10

		// Constructors
		public UsernameRequest(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class UserBasicInfo // TypeDefIndex: 18
	{
		// Fields
		public long id; // 0x10
		public int petId; // 0x18
		public int avtId; // 0x1C
		public int energy; // 0x20
		public int energyFull; // 0x24
		public long gold; // 0x28
		public int ruby; // 0x30
		public long requestAttack; // 0x38
		public string name; // 0x40
		public int lever; // 0x48
		public int exp; // 0x4C
		public int expCurrent; // 0x50
		public int wheel; // 0x54
		public int starWhite; // 0x58
		public int starBlue; // 0x5C
		public int starRed; // 0x60
		public int secondsUntilNextRegen; // 0x64

		// Constructors
		public UserBasicInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[CompilerGenerated]
	private sealed class _FetchUserInfo_d__11 : IEnumerator<object> // TypeDefIndex: 19
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string username; // 0x20
		public GetUserBasicInfo __4__this; // 0x28
		private UnityWebRequest _request_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FetchUserInfo_d__11(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F8F10-0x00000001802F8FF0
		private bool MoveNext(); // 0x00000001802F88A0-0x00000001802F8EC0
		private void __m__Finally1(); // 0x00000001802F8FF0-0x00000001802F9040
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802F8ED0-0x00000001802F8F10
	}

	// Constructors
	public GetUserBasicInfo(); // 0x00000001802F5E80-0x00000001802F5F60

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInitialize(); // 0x00000001802F59D0-0x00000001802F5AC0
	private void Awake(); // 0x00000001802F5AC0-0x00000001802F5BF0
	private void Start(); // 0x00000001802E76C0-0x00000001802E76D0
	public void GetUserInfo(string username, Action<UserBasicInfo> onFetched); // 0x00000001802F5C80-0x00000001802F5E80
	[IteratorStateMachine(typeof(_FetchUserInfo_d__11))]
	private IEnumerator FetchUserInfo(string username); // 0x00000001802F5BF0-0x00000001802F5C80
	private void LogUserInfo(string username, UserBasicInfo info); // 0x00000001802E76C0-0x00000001802E76D0
}

