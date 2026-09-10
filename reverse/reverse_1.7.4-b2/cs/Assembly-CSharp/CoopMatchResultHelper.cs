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

public class CoopMatchResultHelper : MonoBehaviour // TypeDefIndex: 932
{
	// Fields
	public static CoopMatchResultHelper Instance; // 0x00
	private const int MAX_RETRIES = 3; // Metadata: 0x0068BFA9
	private const float RETRY_DELAY = 2f; // Metadata: 0x0068BFAA
	public bool lastSubmitSuccess; // 0x20
	public MatchRewardData lastReward; // 0x28
	private string _lastRewardMatchId; // 0x30
	[CompilerGenerated]
	private Action<string> OnRewardPushed; // 0x38
	private string _matchIdForPendingRestSubmit; // 0x40
	private bool _wsSubscribed; // 0x48

	// Properties
	public int lastRewardGold { get; } // 0x00000001804C9720-0x00000001804C9740 
	public int lastRewardExp { get; } // 0x00000001804C9700-0x00000001804C9720 

	// Events
	public event Action<string> OnRewardPushed {
		add; // 0x00000001804C9640-0x00000001804C9700
		remove; // 0x00000001804C9740-0x00000001804C9800
	}

	// Nested types
	[Serializable]
	private class MatchResponse // TypeDefIndex: 933
	{
		// Fields
		public bool success; // 0x10
		public string message; // 0x18
		public MatchRewardData data; // 0x20

		// Constructors
		public MatchResponse(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[Serializable]
	public class MatchRewardData // TypeDefIndex: 934
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
		public long sweepTicketDropItemId; // 0xC0
		public int sweepTicketDropAmount; // 0xC8
		public string sweepTicketDropLabel; // 0xD0
		public int rankBefore; // 0xD8
		public int rankChange; // 0xDC
		public int newRank; // 0xE0
		public int enemyRankChange; // 0xE4
		public int enemyNewRank; // 0xE8
		public int winStreak; // 0xEC
		public int rankPosition; // 0xF0
		public int winRate; // 0xF4
		public int pvpWins; // 0xF8
		public int pvpLosses; // 0xFC
		public int towerFloor; // 0x100
		public bool towerCleared; // 0x104
		public bool towerFirstClear; // 0x105
		public TowerGiftBundle towerGift; // 0x108
		public TowerGiftBundle towerGiftSpecial; // 0x110
		public int towerNextFloor; // 0x118
		public int towerPower; // 0x11C

		// Constructors
		public MatchRewardData(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass21_0 // TypeDefIndex: 935
	{
		// Fields
		public bool success; // 0x10
		public CoopMatchResultHelper __4__this; // 0x18

		// Constructors
		public __c__DisplayClass21_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass21_1 // TypeDefIndex: 936
	{
		// Fields
		public bool callbackReceived; // 0x10
		public __c__DisplayClass21_0 CS___8__locals1; // 0x18

		// Constructors
		public __c__DisplayClass21_1(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SubmitMatchResult_b__0(string response); // 0x00000001804E1930-0x00000001804E1970
		internal void _SubmitMatchResult_b__1(string error); // 0x00000001804E1970-0x00000001804E19F0
	}

	[CompilerGenerated]
	private sealed class _PostRawJson_d__23 : IEnumerator<object> // TypeDefIndex: 937
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PostRawJson_d__23(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804DEDF0-0x00000001804DEED0
		private bool MoveNext(); // 0x00000001804DE980-0x00000001804DEDB0
		private void __m__Finally1(); // 0x00000001804DEED0-0x00000001804DEF20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804DEDB0-0x00000001804DEDF0
	}

	[CompilerGenerated]
	private sealed class _SubmitMatchResult_d__21 : IEnumerator<object> // TypeDefIndex: 938
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SubmitMatchResult_d__21(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804E08D0-0x00000001804E0940
		private bool MoveNext(); // 0x00000001804DF130-0x00000001804E0890
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804E0890-0x00000001804E08D0
	}

	// Constructors
	public CoopMatchResultHelper(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInitialize(); // 0x00000001804C8570-0x00000001804C8650
	private void Awake(); // 0x00000001804C8650-0x00000001804C8840
	private void TrySubscribeWs(); // 0x00000001804C9510-0x00000001804C9640
	private void OnDestroy(); // 0x00000001804C8F80-0x00000001804C90D0
	private void HandleWsMatchResultPush(ChatMessageDTO msg); // 0x00000001804C8970-0x00000001804C8F80
	private static string ResolveCurrentSubmitMatchId(); // 0x00000001804C9380-0x00000001804C9450
	[IteratorStateMachine(typeof(_SubmitMatchResult_d__21))]
	public IEnumerator SubmitMatchResult(bool playerWon, int turnCount, string mode = "coop" /* Metadata: 0x0068BF94 */, long enemyUserId = 0 /* Metadata: 0x0068BF99 */, long petId = 0 /* Metadata: 0x0068BFA1 */); // 0x00000001804C9450-0x00000001804C9510
	private void ParseResponse(string response); // 0x00000001804C90D0-0x00000001804C92C0
	[IteratorStateMachine(typeof(_PostRawJson_d__23))]
	private IEnumerator PostRawJson(string url, string jsonBody, Action<string> onSuccess, Action<string> onError); // 0x00000001804C92C0-0x00000001804C9380
	private string Esc(string s); // 0x00000001804C8840-0x00000001804C8970
}

