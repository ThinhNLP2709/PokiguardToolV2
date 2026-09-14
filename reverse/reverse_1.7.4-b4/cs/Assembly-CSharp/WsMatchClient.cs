/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class WsMatchClient : MonoBehaviour // TypeDefIndex: 595
{
	// Fields
	[CompilerGenerated]
	private static WsMatchClient _Instance_k__BackingField; // 0x00
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchStart; // 0x20
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchResync; // 0x28
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchMoveRes; // 0x30
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchReject; // 0x38
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchTurnEnd; // 0x40
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchTimerTick; // 0x48
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchCardUseRes; // 0x50
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchSkillUseRes; // 0x58
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchPlayerLeft; // 0x60
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchPlayerRejoin; // 0x68
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchAfkWarn; // 0x70
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchSkillCast; // 0x78
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchBossAction; // 0x80
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchQteChallenge; // 0x88
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchFusionListRes; // 0x90
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchFusionRes; // 0x98
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchGameOver; // 0xA0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchEndNotice; // 0xA8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchResultPush; // 0xB0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchReadyState; // 0xB8
	private bool subscribed; // 0xC0
	private WsRoomService subscribedRoomService; // 0xC8
	private bool kickExitStarted; // 0xD0

	// Properties
	public static WsMatchClient Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018041E470-0x000000018041E4B0 0x000000018041E4B0-0x000000018041E550
	public bool IsConnected { get; } // 0x0000000180421250-0x0000000180421370 

	// Events
	public event Action<ChatMessageDTO> OnMatchStart {
		add; // 0x000000018041E550-0x000000018041E670
		remove; // 0x000000018041E670-0x000000018041E790
	}
	public event Action<ChatMessageDTO> OnMatchResync {
		add; // 0x000000018041E790-0x000000018041E8B0
		remove; // 0x000000018041E8B0-0x000000018041E9D0
	}
	public event Action<ChatMessageDTO> OnMatchMoveRes {
		add; // 0x000000018041E9D0-0x000000018041EAF0
		remove; // 0x000000018041EAF0-0x000000018041EC10
	}
	public event Action<ChatMessageDTO> OnMatchReject {
		add; // 0x000000018041EC10-0x000000018041ED30
		remove; // 0x000000018041ED30-0x000000018041EE50
	}
	public event Action<ChatMessageDTO> OnMatchTurnEnd {
		add; // 0x000000018041EE50-0x000000018041EF70
		remove; // 0x000000018041EF70-0x000000018041F090
	}
	public event Action<ChatMessageDTO> OnMatchTimerTick {
		add; // 0x000000018041F090-0x000000018041F1B0
		remove; // 0x000000018041F1B0-0x000000018041F2D0
	}
	public event Action<ChatMessageDTO> OnMatchCardUseRes {
		add; // 0x000000018041F2D0-0x000000018041F3F0
		remove; // 0x000000018041F3F0-0x000000018041F510
	}
	public event Action<ChatMessageDTO> OnMatchSkillUseRes {
		add; // 0x000000018041F510-0x000000018041F630
		remove; // 0x000000018041F630-0x000000018041F750
	}
	public event Action<ChatMessageDTO> OnMatchPlayerLeft {
		add; // 0x000000018041F750-0x000000018041F870
		remove; // 0x000000018041F870-0x000000018041F990
	}
	public event Action<ChatMessageDTO> OnMatchPlayerRejoin {
		add; // 0x000000018041F990-0x000000018041FAB0
		remove; // 0x000000018041FAB0-0x000000018041FBD0
	}
	public event Action<ChatMessageDTO> OnMatchAfkWarn {
		add; // 0x000000018041FBD0-0x000000018041FCF0
		remove; // 0x000000018041FCF0-0x000000018041FE10
	}
	public event Action<ChatMessageDTO> OnMatchSkillCast {
		add; // 0x000000018041FE10-0x000000018041FF30
		remove; // 0x000000018041FF30-0x0000000180420050
	}
	public event Action<ChatMessageDTO> OnMatchBossAction {
		add; // 0x0000000180420050-0x0000000180420170
		remove; // 0x0000000180420170-0x0000000180420290
	}
	public event Action<ChatMessageDTO> OnMatchQteChallenge {
		add; // 0x0000000180420290-0x00000001804203B0
		remove; // 0x00000001804203B0-0x00000001804204D0
	}
	public event Action<ChatMessageDTO> OnMatchFusionListRes {
		add; // 0x00000001804204D0-0x00000001804205F0
		remove; // 0x00000001804205F0-0x0000000180420710
	}
	public event Action<ChatMessageDTO> OnMatchFusionRes {
		add; // 0x0000000180420710-0x0000000180420830
		remove; // 0x0000000180420830-0x0000000180420950
	}
	public event Action<ChatMessageDTO> OnMatchGameOver {
		add; // 0x0000000180420950-0x0000000180420A70
		remove; // 0x0000000180420A70-0x0000000180420B90
	}
	public event Action<ChatMessageDTO> OnMatchEndNotice {
		add; // 0x0000000180420B90-0x0000000180420CB0
		remove; // 0x0000000180420CB0-0x0000000180420DD0
	}
	public event Action<ChatMessageDTO> OnMatchResultPush {
		add; // 0x0000000180420DD0-0x0000000180420EF0
		remove; // 0x0000000180420EF0-0x0000000180421010
	}
	public event Action<ChatMessageDTO> OnMatchReadyState {
		add; // 0x0000000180421010-0x0000000180421130
		remove; // 0x0000000180421130-0x0000000180421250
	}

	// Constructors
	public WsMatchClient(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInit(); // 0x0000000180421370-0x0000000180421500
	private void Awake(); // 0x0000000180421500-0x0000000180421770
	private void OnDestroy(); // 0x0000000180421770-0x00000001804218E0
	private void Subscribe(); // 0x00000001804218E0-0x00000001804230C0
	private void EnsureRoomKickSubscription(); // 0x00000001804230C0-0x0000000180423260
	private void Unsubscribe(); // 0x0000000180423260-0x0000000180423470
	private static Action<ChatMessageDTO> Forward(Action<ChatMessageDTO> a); // 0x0000000180423470-0x0000000180423480
	private void HandleKickedWhileInMatch(string reason); // 0x0000000180423480-0x0000000180423B10
	internal static string ResolveFallbackKickScene(string reason, bool inCoop, bool inPvp, bool coopHandlerAlive, bool pvpHandlerAlive); // 0x0000000180423B10-0x0000000180423D00
	public void RequestResync(string matchId, string reason = null); // 0x0000000180423D00-0x0000000180423D70
	public void SendMove(string matchId, int fromCol, int fromRow, int toCol, int toRow, long seqNum); // 0x0000000180423D70-0x0000000180423E20
	public void SendCardUse(string matchId, int cardId, int? cardTarget = default); // 0x0000000180423E20-0x0000000180424060
	public void SendSkillUse(string matchId, int skillCardId, int correctDotCount, string timingResult, int dotsToDestroy, List<int> selectedRows, List<List<int>> selectedDots, List<string> qtePresses = null, int? qteElapsedMs = default, long? qteChallengeId = default); // 0x0000000180424060-0x0000000180424160
	public void SendQteStart(string matchId, int skillCardId, Dictionary<string, object> payload = null); // 0x0000000180424160-0x00000001804241F0
	public void SendQteTap(string matchId, int elapsedMs, long challengeId); // 0x00000001804241F0-0x0000000180424280
	public void SendFusionList(string matchId); // 0x0000000180424280-0x00000001804242F0
	public void SendFusionUse(string matchId, long fusionUserPetId); // 0x00000001804242F0-0x0000000180424360
	public void SendClientReady(string matchId); // 0x0000000180424360-0x00000001804243D0
	public void SendAnimDone(string matchId, long ackToken); // 0x00000001804243D0-0x0000000180424440
	public void SendDragPause(string matchId); // 0x0000000180424440-0x0000000180424640
	public void SendDragResume(string matchId); // 0x0000000180424640-0x0000000180424840
	public void SendEnergyUse(); // 0x0000000180424840-0x0000000180424A30
	public void SendShadowReport(string matchId, long seqNum, int clientDamage, int clientBossHpAfter, int clientPlayerHpAfter); // 0x0000000180424A30-0x0000000180424AD0
	[CompilerGenerated]
	private void _Subscribe_b__72_0(ChatMessageDTO e); // 0x0000000180424AD0-0x0000000180424AF0
	[CompilerGenerated]
	private void _Subscribe_b__72_1(ChatMessageDTO e); // 0x0000000180424AF0-0x0000000180424B10
	[CompilerGenerated]
	private void _Subscribe_b__72_2(ChatMessageDTO e); // 0x0000000180424B10-0x0000000180424B30
	[CompilerGenerated]
	private void _Subscribe_b__72_3(ChatMessageDTO e); // 0x0000000180424B30-0x0000000180424B50
	[CompilerGenerated]
	private void _Subscribe_b__72_4(ChatMessageDTO e); // 0x0000000180424B50-0x0000000180424B70
	[CompilerGenerated]
	private void _Subscribe_b__72_5(ChatMessageDTO e); // 0x0000000180424B70-0x0000000180424B90
	[CompilerGenerated]
	private void _Subscribe_b__72_6(ChatMessageDTO e); // 0x0000000180424B90-0x0000000180424BB0
	[CompilerGenerated]
	private void _Subscribe_b__72_7(ChatMessageDTO e); // 0x0000000180424BB0-0x0000000180424BD0
	[CompilerGenerated]
	private void _Subscribe_b__72_8(ChatMessageDTO e); // 0x0000000180424BD0-0x0000000180424BF0
	[CompilerGenerated]
	private void _Subscribe_b__72_9(ChatMessageDTO e); // 0x0000000180424BF0-0x0000000180424C10
	[CompilerGenerated]
	private void _Subscribe_b__72_10(ChatMessageDTO e); // 0x0000000180424C10-0x0000000180424C30
	[CompilerGenerated]
	private void _Subscribe_b__72_11(ChatMessageDTO e); // 0x0000000180424C30-0x0000000180424C50
	[CompilerGenerated]
	private void _Subscribe_b__72_12(ChatMessageDTO e); // 0x0000000180424C50-0x0000000180424C70
	[CompilerGenerated]
	private void _Subscribe_b__72_13(ChatMessageDTO e); // 0x0000000180424C70-0x0000000180424C90
	[CompilerGenerated]
	private void _Subscribe_b__72_14(ChatMessageDTO e); // 0x0000000180424C90-0x0000000180424CB0
	[CompilerGenerated]
	private void _Subscribe_b__72_15(ChatMessageDTO e); // 0x0000000180424CB0-0x0000000180424CD0
	[CompilerGenerated]
	private void _Subscribe_b__72_16(ChatMessageDTO e); // 0x0000000180424CD0-0x0000000180424CF0
	[CompilerGenerated]
	private void _Subscribe_b__72_17(ChatMessageDTO e); // 0x0000000180424CF0-0x0000000180424D10
	[CompilerGenerated]
	private void _Subscribe_b__72_18(ChatMessageDTO e); // 0x0000000180424D10-0x0000000180424D30
	[CompilerGenerated]
	private void _Subscribe_b__72_19(ChatMessageDTO e); // 0x0000000180424D30-0x0000000180424D50
}

