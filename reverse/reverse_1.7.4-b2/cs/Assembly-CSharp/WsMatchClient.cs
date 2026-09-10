/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class WsMatchClient : MonoBehaviour // TypeDefIndex: 541
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
	public static WsMatchClient Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803DA5F0-0x00000001803DA630 0x00000001803DB650-0x00000001803DB6B0
	public bool IsConnected { get; } // 0x00000001803DA630-0x00000001803DA6D0 

	// Events
	public event Action<ChatMessageDTO> OnMatchStart {
		add; // 0x00000001803DA3B0-0x00000001803DA470
		remove; // 0x00000001803DB410-0x00000001803DB4D0
	}
	public event Action<ChatMessageDTO> OnMatchResync {
		add; // 0x00000001803DA170-0x00000001803DA230
		remove; // 0x00000001803DB1D0-0x00000001803DB290
	}
	public event Action<ChatMessageDTO> OnMatchMoveRes {
		add; // 0x00000001803D9C00-0x00000001803D9CC0
		remove; // 0x00000001803DAC60-0x00000001803DAD20
	}
	public event Action<ChatMessageDTO> OnMatchReject {
		add; // 0x00000001803D9FE0-0x00000001803DA0A0
		remove; // 0x00000001803DB040-0x00000001803DB100
	}
	public event Action<ChatMessageDTO> OnMatchTurnEnd {
		add; // 0x00000001803DA530-0x00000001803DA5F0
		remove; // 0x00000001803DB590-0x00000001803DB650
	}
	public event Action<ChatMessageDTO> OnMatchTimerTick {
		add; // 0x00000001803DA470-0x00000001803DA530
		remove; // 0x00000001803DB4D0-0x00000001803DB590
	}
	public event Action<ChatMessageDTO> OnMatchCardUseRes {
		add; // 0x00000001803D9800-0x00000001803D98C0
		remove; // 0x00000001803DA860-0x00000001803DA920
	}
	public event Action<ChatMessageDTO> OnMatchSkillUseRes {
		add; // 0x00000001803DA2F0-0x00000001803DA3B0
		remove; // 0x00000001803DB350-0x00000001803DB410
	}
	public event Action<ChatMessageDTO> OnMatchPlayerLeft {
		add; // 0x00000001803D9CC0-0x00000001803D9D80
		remove; // 0x00000001803DAD20-0x00000001803DADE0
	}
	public event Action<ChatMessageDTO> OnMatchPlayerRejoin {
		add; // 0x00000001803D9D80-0x00000001803D9E40
		remove; // 0x00000001803DADE0-0x00000001803DAEA0
	}
	public event Action<ChatMessageDTO> OnMatchAfkWarn {
		add; // 0x00000001803D9670-0x00000001803D9730
		remove; // 0x00000001803DA6D0-0x00000001803DA790
	}
	public event Action<ChatMessageDTO> OnMatchSkillCast {
		add; // 0x00000001803DA230-0x00000001803DA2F0
		remove; // 0x00000001803DB290-0x00000001803DB350
	}
	public event Action<ChatMessageDTO> OnMatchBossAction {
		add; // 0x00000001803D9730-0x00000001803D9800
		remove; // 0x00000001803DA790-0x00000001803DA860
	}
	public event Action<ChatMessageDTO> OnMatchQteChallenge {
		add; // 0x00000001803D9E40-0x00000001803D9F10
		remove; // 0x00000001803DAEA0-0x00000001803DAF70
	}
	public event Action<ChatMessageDTO> OnMatchFusionListRes {
		add; // 0x00000001803D9990-0x00000001803D9A60
		remove; // 0x00000001803DA9F0-0x00000001803DAAC0
	}
	public event Action<ChatMessageDTO> OnMatchFusionRes {
		add; // 0x00000001803D9A60-0x00000001803D9B30
		remove; // 0x00000001803DAAC0-0x00000001803DAB90
	}
	public event Action<ChatMessageDTO> OnMatchGameOver {
		add; // 0x00000001803D9B30-0x00000001803D9C00
		remove; // 0x00000001803DAB90-0x00000001803DAC60
	}
	public event Action<ChatMessageDTO> OnMatchEndNotice {
		add; // 0x00000001803D98C0-0x00000001803D9990
		remove; // 0x00000001803DA920-0x00000001803DA9F0
	}
	public event Action<ChatMessageDTO> OnMatchResultPush {
		add; // 0x00000001803DA0A0-0x00000001803DA170
		remove; // 0x00000001803DB100-0x00000001803DB1D0
	}
	public event Action<ChatMessageDTO> OnMatchReadyState {
		add; // 0x00000001803D9F10-0x00000001803D9FE0
		remove; // 0x00000001803DAF70-0x00000001803DB040
	}

	// Constructors
	public WsMatchClient(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInit(); // 0x00000001803D7A60-0x00000001803D7B50
	private void Awake(); // 0x00000001803D7B50-0x00000001803D7C90
	private void OnDestroy(); // 0x00000001803D8230-0x00000001803D8420
	private void Subscribe(); // 0x00000001803D8B40-0x00000001803D92C0
	private void EnsureRoomKickSubscription(); // 0x00000001803D7C90-0x00000001803D7E60
	private void Unsubscribe(); // 0x00000001803D9540-0x00000001803D9670
	private static Action<ChatMessageDTO> Forward(Action<ChatMessageDTO> a); // 0x00000001803D7E60-0x00000001803D7E70
	private void HandleKickedWhileInMatch(string reason); // 0x00000001803D7E70-0x00000001803D8230
	internal static string ResolveFallbackKickScene(string reason, bool inCoop, bool inPvp, bool coopHandlerAlive, bool pvpHandlerAlive); // 0x00000001803D8490-0x00000001803D8570
	public void RequestResync(string matchId, string reason = null); // 0x00000001803D8420-0x00000001803D8490
	public void SendMove(string matchId, int fromCol, int fromRow, int toCol, int toRow, long seqNum); // 0x00000001803D88B0-0x00000001803D8950
	public void SendCardUse(string matchId, int cardId, int? cardTarget = default); // 0x00000001803D85E0-0x00000001803D8660
	public void SendSkillUse(string matchId, int skillCardId, int correctDotCount, string timingResult, int dotsToDestroy, List<int> selectedRows, List<List<int>> selectedDots, List<string> qtePresses = null, int? qteElapsedMs = default, long? qteChallengeId = default); // 0x00000001803D8A50-0x00000001803D8B40
	public void SendQteStart(string matchId, int skillCardId); // 0x00000001803D8950-0x00000001803D89C0
	public void SendFusionList(string matchId); // 0x00000001803D87E0-0x00000001803D8840
	public void SendFusionUse(string matchId, long fusionUserPetId); // 0x00000001803D8840-0x00000001803D88B0
	public void SendClientReady(string matchId); // 0x00000001803D8660-0x00000001803D86C0
	public void SendAnimDone(string matchId, long ackToken); // 0x00000001803D8570-0x00000001803D85E0
	public void SendDragPause(string matchId); // 0x00000001803D86C0-0x00000001803D8720
	public void SendDragResume(string matchId); // 0x00000001803D8720-0x00000001803D8780
	public void SendEnergyUse(); // 0x00000001803D8780-0x00000001803D87E0
	public void SendShadowReport(string matchId, long seqNum, int clientDamage, int clientBossHpAfter, int clientPlayerHpAfter); // 0x00000001803D89C0-0x00000001803D8A50
	[CompilerGenerated]
	private void _Subscribe_b__72_0(ChatMessageDTO e); // 0x00000001803D92C0-0x00000001803D92E0
	[CompilerGenerated]
	private void _Subscribe_b__72_1(ChatMessageDTO e); // 0x00000001803D9420-0x00000001803D9440
	[CompilerGenerated]
	private void _Subscribe_b__72_2(ChatMessageDTO e); // 0x00000001803D9440-0x00000001803D9460
	[CompilerGenerated]
	private void _Subscribe_b__72_3(ChatMessageDTO e); // 0x00000001803D9460-0x00000001803D9480
	[CompilerGenerated]
	private void _Subscribe_b__72_4(ChatMessageDTO e); // 0x00000001803D9480-0x00000001803D94A0
	[CompilerGenerated]
	private void _Subscribe_b__72_5(ChatMessageDTO e); // 0x00000001803D94A0-0x00000001803D94C0
	[CompilerGenerated]
	private void _Subscribe_b__72_6(ChatMessageDTO e); // 0x00000001803D94C0-0x00000001803D94E0
	[CompilerGenerated]
	private void _Subscribe_b__72_7(ChatMessageDTO e); // 0x00000001803D94E0-0x00000001803D9500
	[CompilerGenerated]
	private void _Subscribe_b__72_8(ChatMessageDTO e); // 0x00000001803D9500-0x00000001803D9520
	[CompilerGenerated]
	private void _Subscribe_b__72_9(ChatMessageDTO e); // 0x00000001803D9520-0x00000001803D9540
	[CompilerGenerated]
	private void _Subscribe_b__72_10(ChatMessageDTO e); // 0x00000001803D92E0-0x00000001803D9300
	[CompilerGenerated]
	private void _Subscribe_b__72_11(ChatMessageDTO e); // 0x00000001803D9300-0x00000001803D9320
	[CompilerGenerated]
	private void _Subscribe_b__72_12(ChatMessageDTO e); // 0x00000001803D9320-0x00000001803D9340
	[CompilerGenerated]
	private void _Subscribe_b__72_13(ChatMessageDTO e); // 0x00000001803D9340-0x00000001803D9360
	[CompilerGenerated]
	private void _Subscribe_b__72_14(ChatMessageDTO e); // 0x00000001803D9360-0x00000001803D9380
	[CompilerGenerated]
	private void _Subscribe_b__72_15(ChatMessageDTO e); // 0x00000001803D9380-0x00000001803D93A0
	[CompilerGenerated]
	private void _Subscribe_b__72_16(ChatMessageDTO e); // 0x00000001803D93A0-0x00000001803D93C0
	[CompilerGenerated]
	private void _Subscribe_b__72_17(ChatMessageDTO e); // 0x00000001803D93C0-0x00000001803D93E0
	[CompilerGenerated]
	private void _Subscribe_b__72_18(ChatMessageDTO e); // 0x00000001803D93E0-0x00000001803D9400
	[CompilerGenerated]
	private void _Subscribe_b__72_19(ChatMessageDTO e); // 0x00000001803D9400-0x00000001803D9420
}

