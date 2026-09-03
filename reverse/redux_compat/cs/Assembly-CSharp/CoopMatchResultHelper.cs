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

public class CoopMatchResultHelper : MonoBehaviour // TypeDefIndex: 742
{
	// Fields
	public static CoopMatchResultHelper Instance; // 0x00
	private const int MAX_RETRIES = 3; // Metadata: 0x0064C8E9
	private const float RETRY_DELAY = 2f; // Metadata: 0x0064C8EA
	public bool lastSubmitSuccess; // 0x20
	public MatchRewardData lastReward; // 0x28
	private string _lastRewardMatchId; // 0x30
	[CompilerGenerated]
	private Action<string> OnRewardPushed; // 0x38
	private string _matchIdForPendingRestSubmit; // 0x40
	private bool _wsSubscribed; // 0x48

	// Properties
	public int lastRewardGold { get; } // 0x00000001803F1800-0x00000001803F1820 
	public int lastRewardExp { get; } // 0x00000001803F17E0-0x00000001803F1800 

	// Events
	public event Action<string> OnRewardPushed {
		add; // 0x00000001803F1720-0x00000001803F17E0
		remove; // 0x00000001803F1820-0x00000001803F18E0
	}

	// Nested types
	[Serializable]
	private class MatchResponse // TypeDefIndex: 743
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18
		public MatchRewardData data; // 0x20

		// Constructors
		public MatchResponse(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[Serializable]
	public class MatchRewardData // TypeDefIndex: 744
	{
		// Fields
		public string mode; // 0x10
		public int gold; // 0x18
		public int exp; // 0x1C
		public int requestAttack; // 0x20
		public bool hackDetected; // 0x24
		public int goldBonus; // 0x28
		public bool receivedPet; // 0x2C
		public long receivedPetId; // 0x30
		public bool duplicatePet; // 0x38
		public int compensationGold; // 0x3C
		public int compensationCrystal; // 0x40
		public int petProgressCount; // 0x44
		public int petProgressTarget; // 0x48
		public int newLevel; // 0x4C
		public int currentExp; // 0x50
		public int expToNextLevel; // 0x54
		public int e1Drop; // 0x58
		public int e2Drop; // 0x5C
		public int e3Drop; // 0x60
		public int eItem1Drop; // 0x64
		public int eItem2Drop; // 0x68
		public int eItem3Drop; // 0x6C
		public int eItem4Drop; // 0x70
		public int crystalDrop; // 0x74
		public int stoneCardDrop; // 0x78
		public List<Board.StoneRewardInfo> stoneRewards; // 0x80
		public long itemAvtDrop; // 0x88
		public int itemAvtDropAmount; // 0x90
		public WeaponDropDTO weaponDrop; // 0x98
		public int weaponShardDrop; // 0xA0
		public int petShardDrop; // 0xA4
		public long petShardPetId; // 0xA8
		public string petShardPetName; // 0xB0
		public int petShardTotal; // 0xB8
		public int rankBefore; // 0xBC
		public int rankChange; // 0xC0
		public int newRank; // 0xC4
		public int enemyRankChange; // 0xC8
		public int enemyNewRank; // 0xCC
		public int winStreak; // 0xD0
		public int rankPosition; // 0xD4
		public int winRate; // 0xD8
		public int pvpWins; // 0xDC
		public int pvpLosses; // 0xE0
		public int towerFloor; // 0xE4
		public bool towerCleared; // 0xE8
		public bool towerFirstClear; // 0xE9
		public TowerGiftBundle towerGift; // 0xF0
		public TowerGiftBundle towerGiftSpecial; // 0xF8
		public int towerNextFloor; // 0x100
		public int towerPower; // 0x104

		// Constructors
		public MatchRewardData(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass21_0 // TypeDefIndex: 745
	{
		// Fields
		public bool success; // 0x10
		public CoopMatchResultHelper __4__this; // 0x18

		// Constructors
		public __c__DisplayClass21_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass21_1 // TypeDefIndex: 746
	{
		// Fields
		public bool callbackReceived; // 0x10
		public __c__DisplayClass21_0 CS___8__locals1; // 0x18

		// Constructors
		public __c__DisplayClass21_1(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SubmitMatchResult_b__0(string response); // 0x000000018040B270-0x000000018040B2B0
		internal void _SubmitMatchResult_b__1(string error); // 0x000000018040B2B0-0x000000018040B330
	}

	[CompilerGenerated]
	private sealed class _PostRawJson_d__23 : IEnumerator<object> // TypeDefIndex: 747
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string url; // 0x20
		public string jsonBody; // 0x28
		public Action<string> onSuccess; // 0x30
		public Action<string> onError; // 0x38
		private UnityWebRequest _request_5__2; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _PostRawJson_d__23(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180408E80-0x0000000180408F60
		private bool MoveNext(); // 0x0000000180408A10-0x0000000180408E40
		private void __m__Finally1(); // 0x0000000180408F60-0x0000000180408FB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180408E40-0x0000000180408E80
	}

	[CompilerGenerated]
	private sealed class _SubmitMatchResult_d__21 : IEnumerator<object> // TypeDefIndex: 748
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CoopMatchResultHelper __4__this; // 0x20
		public long petId; // 0x28
		public string mode; // 0x30
		public bool playerWon; // 0x38
		public int turnCount; // 0x3C
		public long enemyUserId; // 0x40
		private __c__DisplayClass21_0 __8__1; // 0x48
		private __c__DisplayClass21_1 __8__2; // 0x50
		private string _currentMatchId_5__2; // 0x58
		private string _requestBody_5__3; // 0x60
		private string _url_5__4; // 0x68
		private int _retryCount_5__5; // 0x70
		private float _waited_5__6; // 0x74
		private float _reqWaited_5__7; // 0x78

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SubmitMatchResult_d__21(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018040A6E0-0x000000018040A750
		private bool MoveNext(); // 0x0000000180408FB0-0x000000018040A6A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018040A6A0-0x000000018040A6E0
	}

	// Constructors
	public CoopMatchResultHelper(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInitialize(); // 0x00000001803F0650-0x00000001803F0730
	private void Awake(); // 0x00000001803F0730-0x00000001803F0920
	private void TrySubscribeWs(); // 0x00000001803F15F0-0x00000001803F1720
	private void OnDestroy(); // 0x00000001803F1060-0x00000001803F11B0
	private void HandleWsMatchResultPush(ChatMessageDTO msg); // 0x00000001803F0A50-0x00000001803F1060
	private static string ResolveCurrentSubmitMatchId(); // 0x00000001803F1460-0x00000001803F1530
	[IteratorStateMachine(typeof(_SubmitMatchResult_d__21))]
	public IEnumerator SubmitMatchResult(bool playerWon, int turnCount, string mode = "coop" /* Metadata: 0x0064C8D4 */, long enemyUserId = 0 /* Metadata: 0x0064C8D9 */, long petId = 0 /* Metadata: 0x0064C8E1 */); // 0x00000001803F1530-0x00000001803F15F0
	private void ParseResponse(string response); // 0x00000001803F11B0-0x00000001803F13A0
	[IteratorStateMachine(typeof(_PostRawJson_d__23))]
	private IEnumerator PostRawJson(string url, string jsonBody, Action<string> onSuccess, Action<string> onError); // 0x00000001803F13A0-0x00000001803F1460
	private string Esc(string s); // 0x00000001803F0920-0x00000001803F0A50
}

