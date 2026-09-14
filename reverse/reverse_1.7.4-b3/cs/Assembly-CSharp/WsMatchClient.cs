/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class WsMatchClient : MonoBehaviour // TypeDefIndex: 594
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
	public static WsMatchClient Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018041D710-0x000000018041D750 0x000000018041D750-0x000000018041D7F0
	public bool IsConnected { get; } // 0x00000001804204F0-0x0000000180420610 

	// Events
	public event Action<ChatMessageDTO> OnMatchStart {
		add; // 0x000000018041D7F0-0x000000018041D910
		remove; // 0x000000018041D910-0x000000018041DA30
	}
	public event Action<ChatMessageDTO> OnMatchResync {
		add; // 0x000000018041DA30-0x000000018041DB50
		remove; // 0x000000018041DB50-0x000000018041DC70
	}
	public event Action<ChatMessageDTO> OnMatchMoveRes {
		add; // 0x000000018041DC70-0x000000018041DD90
		remove; // 0x000000018041DD90-0x000000018041DEB0
	}
	public event Action<ChatMessageDTO> OnMatchReject {
		add; // 0x000000018041DEB0-0x000000018041DFD0
		remove; // 0x000000018041DFD0-0x000000018041E0F0
	}
	public event Action<ChatMessageDTO> OnMatchTurnEnd {
		add; // 0x000000018041E0F0-0x000000018041E210
		remove; // 0x000000018041E210-0x000000018041E330
	}
	public event Action<ChatMessageDTO> OnMatchTimerTick {
		add; // 0x000000018041E330-0x000000018041E450
		remove; // 0x000000018041E450-0x000000018041E570
	}
	public event Action<ChatMessageDTO> OnMatchCardUseRes {
		add; // 0x000000018041E570-0x000000018041E690
		remove; // 0x000000018041E690-0x000000018041E7B0
	}
	public event Action<ChatMessageDTO> OnMatchSkillUseRes {
		add; // 0x000000018041E7B0-0x000000018041E8D0
		remove; // 0x000000018041E8D0-0x000000018041E9F0
	}
	public event Action<ChatMessageDTO> OnMatchPlayerLeft {
		add; // 0x000000018041E9F0-0x000000018041EB10
		remove; // 0x000000018041EB10-0x000000018041EC30
	}
	public event Action<ChatMessageDTO> OnMatchPlayerRejoin {
		add; // 0x000000018041EC30-0x000000018041ED50
		remove; // 0x000000018041ED50-0x000000018041EE70
	}
	public event Action<ChatMessageDTO> OnMatchAfkWarn {
		add; // 0x000000018041EE70-0x000000018041EF90
		remove; // 0x000000018041EF90-0x000000018041F0B0
	}
	public event Action<ChatMessageDTO> OnMatchSkillCast {
		add; // 0x000000018041F0B0-0x000000018041F1D0
		remove; // 0x000000018041F1D0-0x000000018041F2F0
	}
	public event Action<ChatMessageDTO> OnMatchBossAction {
		add; // 0x000000018041F2F0-0x000000018041F410
		remove; // 0x000000018041F410-0x000000018041F530
	}
	public event Action<ChatMessageDTO> OnMatchQteChallenge {
		add; // 0x000000018041F530-0x000000018041F650
		remove; // 0x000000018041F650-0x000000018041F770
	}
	public event Action<ChatMessageDTO> OnMatchFusionListRes {
		add; // 0x000000018041F770-0x000000018041F890
		remove; // 0x000000018041F890-0x000000018041F9B0
	}
	public event Action<ChatMessageDTO> OnMatchFusionRes {
		add; // 0x000000018041F9B0-0x000000018041FAD0
		remove; // 0x000000018041FAD0-0x000000018041FBF0
	}
	public event Action<ChatMessageDTO> OnMatchGameOver {
		add; // 0x000000018041FBF0-0x000000018041FD10
		remove; // 0x000000018041FD10-0x000000018041FE30
	}
	public event Action<ChatMessageDTO> OnMatchEndNotice {
		add; // 0x000000018041FE30-0x000000018041FF50
		remove; // 0x000000018041FF50-0x0000000180420070
	}
	public event Action<ChatMessageDTO> OnMatchResultPush {
		add; // 0x0000000180420070-0x0000000180420190
		remove; // 0x0000000180420190-0x00000001804202B0
	}
	public event Action<ChatMessageDTO> OnMatchReadyState {
		add; // 0x00000001804202B0-0x00000001804203D0
		remove; // 0x00000001804203D0-0x00000001804204F0
	}

	// Constructors
	public WsMatchClient(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInit(); // 0x0000000180420610-0x00000001804207A0
	private void Awake(); // 0x00000001804207A0-0x0000000180420A10
	private void OnDestroy(); // 0x0000000180420A10-0x0000000180420B80
	private void Subscribe(); // 0x0000000180420B80-0x0000000180422360
	private void EnsureRoomKickSubscription(); // 0x0000000180422360-0x0000000180422500
	private void Unsubscribe(); // 0x0000000180422500-0x0000000180422710
	private static Action<ChatMessageDTO> Forward(Action<ChatMessageDTO> a); // 0x0000000180422710-0x0000000180422720
	private void HandleKickedWhileInMatch(string reason); // 0x0000000180422720-0x0000000180422DB0
	internal static string ResolveFallbackKickScene(string reason, bool inCoop, bool inPvp, bool coopHandlerAlive, bool pvpHandlerAlive); // 0x0000000180422DB0-0x0000000180422FA0
	public void RequestResync(string matchId, string reason = null); // 0x0000000180422FA0-0x0000000180423010
	public void SendMove(string matchId, int fromCol, int fromRow, int toCol, int toRow, long seqNum); // 0x0000000180423010-0x00000001804230C0
	public void SendCardUse(string matchId, int cardId, int? cardTarget = default); // 0x00000001804230C0-0x0000000180423300
	public void SendSkillUse(string matchId, int skillCardId, int correctDotCount, string timingResult, int dotsToDestroy, List<int> selectedRows, List<List<int>> selectedDots, List<string> qtePresses = null, int? qteElapsedMs = default, long? qteChallengeId = default); // 0x0000000180423300-0x0000000180423400
	public void SendQteStart(string matchId, int skillCardId, Dictionary<string, object> payload = null); // 0x0000000180423400-0x0000000180423490
	public void SendQteTap(string matchId, int elapsedMs, long challengeId); // 0x0000000180423490-0x0000000180423520
	public void SendFusionList(string matchId); // 0x0000000180423520-0x0000000180423590
	public void SendFusionUse(string matchId, long fusionUserPetId); // 0x0000000180423590-0x0000000180423600
	public void SendClientReady(string matchId); // 0x0000000180423600-0x0000000180423670
	public void SendAnimDone(string matchId, long ackToken); // 0x0000000180423670-0x00000001804236E0
	public void SendDragPause(string matchId); // 0x00000001804236E0-0x00000001804238E0
	public void SendDragResume(string matchId); // 0x00000001804238E0-0x0000000180423AE0
	public void SendEnergyUse(); // 0x0000000180423AE0-0x0000000180423CD0
	public void SendShadowReport(string matchId, long seqNum, int clientDamage, int clientBossHpAfter, int clientPlayerHpAfter); // 0x0000000180423CD0-0x0000000180423D70
	[CompilerGenerated]
	private void _Subscribe_b__72_0(ChatMessageDTO e); // 0x0000000180423D70-0x0000000180423D90
	[CompilerGenerated]
	private void _Subscribe_b__72_1(ChatMessageDTO e); // 0x0000000180423D90-0x0000000180423DB0
	[CompilerGenerated]
	private void _Subscribe_b__72_2(ChatMessageDTO e); // 0x0000000180423DB0-0x0000000180423DD0
	[CompilerGenerated]
	private void _Subscribe_b__72_3(ChatMessageDTO e); // 0x0000000180423DD0-0x0000000180423DF0
	[CompilerGenerated]
	private void _Subscribe_b__72_4(ChatMessageDTO e); // 0x0000000180423DF0-0x0000000180423E10
	[CompilerGenerated]
	private void _Subscribe_b__72_5(ChatMessageDTO e); // 0x0000000180423E10-0x0000000180423E30
	[CompilerGenerated]
	private void _Subscribe_b__72_6(ChatMessageDTO e); // 0x0000000180423E30-0x0000000180423E50
	[CompilerGenerated]
	private void _Subscribe_b__72_7(ChatMessageDTO e); // 0x0000000180423E50-0x0000000180423E70
	[CompilerGenerated]
	private void _Subscribe_b__72_8(ChatMessageDTO e); // 0x0000000180423E70-0x0000000180423E90
	[CompilerGenerated]
	private void _Subscribe_b__72_9(ChatMessageDTO e); // 0x0000000180423E90-0x0000000180423EB0
	[CompilerGenerated]
	private void _Subscribe_b__72_10(ChatMessageDTO e); // 0x0000000180423EB0-0x0000000180423ED0
	[CompilerGenerated]
	private void _Subscribe_b__72_11(ChatMessageDTO e); // 0x0000000180423ED0-0x0000000180423EF0
	[CompilerGenerated]
	private void _Subscribe_b__72_12(ChatMessageDTO e); // 0x0000000180423EF0-0x0000000180423F10
	[CompilerGenerated]
	private void _Subscribe_b__72_13(ChatMessageDTO e); // 0x0000000180423F10-0x0000000180423F30
	[CompilerGenerated]
	private void _Subscribe_b__72_14(ChatMessageDTO e); // 0x0000000180423F30-0x0000000180423F50
	[CompilerGenerated]
	private void _Subscribe_b__72_15(ChatMessageDTO e); // 0x0000000180423F50-0x0000000180423F70
	[CompilerGenerated]
	private void _Subscribe_b__72_16(ChatMessageDTO e); // 0x0000000180423F70-0x0000000180423F90
	[CompilerGenerated]
	private void _Subscribe_b__72_17(ChatMessageDTO e); // 0x0000000180423F90-0x0000000180423FB0
	[CompilerGenerated]
	private void _Subscribe_b__72_18(ChatMessageDTO e); // 0x0000000180423FB0-0x0000000180423FD0
	[CompilerGenerated]
	private void _Subscribe_b__72_19(ChatMessageDTO e); // 0x0000000180423FD0-0x0000000180423FF0
}

