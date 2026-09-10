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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class GetUserBasicInfo : MonoBehaviour // TypeDefIndex: 21
{
	// Fields
	[CompilerGenerated]
	private static GetUserBasicInfo _Instance_k__BackingField; // 0x00
	private string API_URL; // 0x20
	private string authToken; // 0x28
	private Dictionary<string, Action<UserBasicInfo>> callbacks; // 0x30

	// Properties
	public static GetUserBasicInfo Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802FFC70-0x00000001802FFCB0 0x00000001802FFCB0-0x00000001802FFD10

	// Nested types
	[Serializable]
	private class UsernameRequest // TypeDefIndex: 22
	{
		// Fields
		public string username; // 0x10

		// Constructors
		public UsernameRequest(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	public class UserBasicInfo // TypeDefIndex: 23
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
		public UserBasicInfo(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[CompilerGenerated]
	private sealed class _FetchUserInfo_d__11 : IEnumerator<object> // TypeDefIndex: 24
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string username; // 0x20
		public GetUserBasicInfo __4__this; // 0x28
		private UnityWebRequest _request_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FetchUserInfo_d__11(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180300400-0x00000001803004E0
		private bool MoveNext(); // 0x00000001802FFD90-0x00000001803003B0
		private void __m__Finally1(); // 0x00000001803004E0-0x0000000180300530
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803003C0-0x0000000180300400
	}

	// Constructors
	public GetUserBasicInfo(); // 0x00000001802FFB90-0x00000001802FFC70

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInitialize(); // 0x00000001802FF6E0-0x00000001802FF7D0
	private void Awake(); // 0x00000001802FF7D0-0x00000001802FF900
	private void Start(); // 0x00000001802EB6C0-0x00000001802EB6D0
	public void GetUserInfo(string username, Action<UserBasicInfo> onFetched); // 0x00000001802FF990-0x00000001802FFB90
	[IteratorStateMachine(typeof(_FetchUserInfo_d__11))]
	private IEnumerator FetchUserInfo(string username); // 0x00000001802FF900-0x00000001802FF990
	private void LogUserInfo(string username, UserBasicInfo info); // 0x00000001802EB6C0-0x00000001802EB6D0
}

