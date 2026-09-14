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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class CoopMatchResultHelper : MonoBehaviour // TypeDefIndex: 1190
{
	// Fields
	public static CoopMatchResultHelper Instance; // 0x00
	private const int MAX_RETRIES = 3; // Metadata: 0x005EF57D
	private const float RETRY_DELAY = 2f; // Metadata: 0x005EF57E
	public bool lastSubmitSuccess; // 0x20
	public MatchRewardData lastReward; // 0x28
	private string _lastRewardMatchId; // 0x30
	[CompilerGenerated]
	private Action<string> OnRewardPushed; // 0x38
	private string _matchIdForPendingRestSubmit; // 0x40
	private bool _wsSubscribed; // 0x48

	// Properties
	public int lastRewardGold { get; } // 0x0000000180663A90-0x0000000180663AB0 
	public int lastRewardExp { get; } // 0x00000001806CC100-0x00000001806CC120 

	// Events
	public event Action<string> OnRewardPushed {
		add; // 0x00000001806CBEC0-0x00000001806CBFE0
		remove; // 0x00000001806CBFE0-0x00000001806CC100
	}

	// Nested types
	[Serializable]
	private class MatchResponse // TypeDefIndex: 1191
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18
		public MatchRewardData data; // 0x20

		// Constructors
		public MatchResponse(); // 0x000000018028A320-0x000000018028A330
	}

	[Serializable]
	public class MatchRewardData // TypeDefIndex: 1192
	{
		// Fields
		public string mode; // 0x10
		public int gold; // 0x18
		public int exp; // 0x1C
		public int requestAttack; // 0x20
		public bool hackDetected; // 0x24
		public int guildContribBonus; // 0x28
		public int guildContribSameGuild; // 0x2C
		public int guildContribToday; // 0x30
		public int guildContribCap; // 0x34
		public int goldBonus; // 0x38
		public bool receivedPet; // 0x3C
		public long receivedPetId; // 0x40
		public bool duplicatePet; // 0x48
		public int compensationGold; // 0x4C
		public int compensationCrystal; // 0x50
		public int petProgressCount; // 0x54
		public int petProgressTarget; // 0x58
		public int newLevel; // 0x5C
		public int currentExp; // 0x60
		public int expToNextLevel; // 0x64
		public int e1Drop; // 0x68
		public int e2Drop; // 0x6C
		public int e3Drop; // 0x70
		public int eItem1Drop; // 0x74
		public int eItem2Drop; // 0x78
		public int eItem3Drop; // 0x7C
		public int eItem4Drop; // 0x80
		public int crystalDrop; // 0x84
		public int stoneCardDrop; // 0x88
		public List<Board.StoneRewardInfo> stoneRewards; // 0x90
		public long itemAvtDrop; // 0x98
		public int itemAvtDropAmount; // 0xA0
		public WeaponDropDTO weaponDrop; // 0xA8
		public int weaponShardDrop; // 0xB0
		public int petShardDrop; // 0xB4
		public long petShardPetId; // 0xB8
		public string petShardPetName; // 0xC0
		public int petShardTotal; // 0xC8
		public long sweepTicketDropItemId; // 0xD0
		public int sweepTicketDropAmount; // 0xD8
		public string sweepTicketDropLabel; // 0xE0
		public int rankBefore; // 0xE8
		public int rankChange; // 0xEC
		public int newRank; // 0xF0
		public int enemyRankChange; // 0xF4
		public int enemyNewRank; // 0xF8
		public int winStreak; // 0xFC
		public int rankPosition; // 0x100
		public int winRate; // 0x104
		public int pvpWins; // 0x108
		public int pvpLosses; // 0x10C
		public int towerFloor; // 0x110
		public bool towerCleared; // 0x114
		public bool towerFirstClear; // 0x115
		public TowerGiftBundle towerGift; // 0x118
		public TowerGiftBundle towerGiftSpecial; // 0x120
		public int towerNextFloor; // 0x128
		public int towerPower; // 0x12C

		// Constructors
		public MatchRewardData(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass21_0 // TypeDefIndex: 1193
	{
		// Fields
		public bool success; // 0x10
		public CoopMatchResultHelper __4__this; // 0x18

		// Constructors
		public __c__DisplayClass21_0(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass21_1 // TypeDefIndex: 1194
	{
		// Fields
		public bool callbackReceived; // 0x10
		public __c__DisplayClass21_0 CS___8__locals1; // 0x18

		// Constructors
		public __c__DisplayClass21_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SubmitMatchResult_b__0(string response); // 0x00000001806CD900-0x00000001806CD940
		internal void _SubmitMatchResult_b__1(string error); // 0x00000001806CD940-0x00000001806CD9D0
	}

	[CompilerGenerated]
	private sealed class _PostRawJson_d__23 : IEnumerator<object> // TypeDefIndex: 1195
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PostRawJson_d__23(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001806CD9D0-0x00000001806CDB00
		private bool MoveNext(); // 0x00000001806CDB00-0x00000001806CE0B0
		private void __m__Finally1(); // 0x00000001806CE0B0-0x00000001806CE110
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806CE110-0x00000001806CE150
	}

	[CompilerGenerated]
	private sealed class _SubmitMatchResult_d__21 : IEnumerator<object> // TypeDefIndex: 1196
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SubmitMatchResult_d__21(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001806CE150-0x00000001806CE300
		private bool MoveNext(); // 0x00000001806CE300-0x00000001806CFE80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806CFE80-0x00000001806CFEC0
	}

	// Constructors
	public CoopMatchResultHelper(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInitialize(); // 0x00000001806CC120-0x00000001806CC2A0
	private void Awake(); // 0x00000001806CC2A0-0x00000001806CC540
	private void TrySubscribeWs(); // 0x00000001806CC540-0x00000001806CC810
	private void OnDestroy(); // 0x00000001806CC810-0x00000001806CCBA0
	private void HandleWsMatchResultPush(ChatMessageDTO msg); // 0x00000001806CCBA0-0x00000001806CD200
	private static string ResolveCurrentSubmitMatchId(); // 0x00000001806CD200-0x00000001806CD280
	[IteratorStateMachine(typeof(_SubmitMatchResult_d__21))]
	public IEnumerator SubmitMatchResult(bool playerWon, int turnCount, string mode = "coop" /* Metadata: 0x005EF568 */, long enemyUserId = 0 /* Metadata: 0x005EF56D */, long petId = 0 /* Metadata: 0x005EF575 */); // 0x00000001806CD280-0x00000001806CD3D0
	private void ParseResponse(string response); // 0x00000001806CD3D0-0x00000001806CD5F0
	[IteratorStateMachine(typeof(_PostRawJson_d__23))]
	private IEnumerator PostRawJson(string url, string jsonBody, Action<string> onSuccess, Action<string> onError); // 0x00000001806CD5F0-0x00000001806CD7A0
	private string Esc(string s); // 0x00000001806CD7A0-0x00000001806CD900
}

