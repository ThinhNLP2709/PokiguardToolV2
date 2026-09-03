/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class WsMatchClient : MonoBehaviour // TypeDefIndex: 453
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
	public static WsMatchClient Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803733C0-0x0000000180373400 0x0000000180374420-0x0000000180374480
	public bool IsConnected { get; } // 0x0000000180373400-0x00000001803734A0 

	// Events
	public event Action<ChatMessageDTO> OnMatchStart {
		add; // 0x0000000180373180-0x0000000180373240
		remove; // 0x00000001803741E0-0x00000001803742A0
	}
	public event Action<ChatMessageDTO> OnMatchResync {
		add; // 0x0000000180372F40-0x0000000180373000
		remove; // 0x0000000180373FA0-0x0000000180374060
	}
	public event Action<ChatMessageDTO> OnMatchMoveRes {
		add; // 0x00000001803729D0-0x0000000180372A90
		remove; // 0x0000000180373A30-0x0000000180373AF0
	}
	public event Action<ChatMessageDTO> OnMatchReject {
		add; // 0x0000000180372DB0-0x0000000180372E70
		remove; // 0x0000000180373E10-0x0000000180373ED0
	}
	public event Action<ChatMessageDTO> OnMatchTurnEnd {
		add; // 0x0000000180373300-0x00000001803733C0
		remove; // 0x0000000180374360-0x0000000180374420
	}
	public event Action<ChatMessageDTO> OnMatchTimerTick {
		add; // 0x0000000180373240-0x0000000180373300
		remove; // 0x00000001803742A0-0x0000000180374360
	}
	public event Action<ChatMessageDTO> OnMatchCardUseRes {
		add; // 0x00000001803725D0-0x0000000180372690
		remove; // 0x0000000180373630-0x00000001803736F0
	}
	public event Action<ChatMessageDTO> OnMatchSkillUseRes {
		add; // 0x00000001803730C0-0x0000000180373180
		remove; // 0x0000000180374120-0x00000001803741E0
	}
	public event Action<ChatMessageDTO> OnMatchPlayerLeft {
		add; // 0x0000000180372A90-0x0000000180372B50
		remove; // 0x0000000180373AF0-0x0000000180373BB0
	}
	public event Action<ChatMessageDTO> OnMatchPlayerRejoin {
		add; // 0x0000000180372B50-0x0000000180372C10
		remove; // 0x0000000180373BB0-0x0000000180373C70
	}
	public event Action<ChatMessageDTO> OnMatchAfkWarn {
		add; // 0x0000000180372440-0x0000000180372500
		remove; // 0x00000001803734A0-0x0000000180373560
	}
	public event Action<ChatMessageDTO> OnMatchSkillCast {
		add; // 0x0000000180373000-0x00000001803730C0
		remove; // 0x0000000180374060-0x0000000180374120
	}
	public event Action<ChatMessageDTO> OnMatchBossAction {
		add; // 0x0000000180372500-0x00000001803725D0
		remove; // 0x0000000180373560-0x0000000180373630
	}
	public event Action<ChatMessageDTO> OnMatchQteChallenge {
		add; // 0x0000000180372C10-0x0000000180372CE0
		remove; // 0x0000000180373C70-0x0000000180373D40
	}
	public event Action<ChatMessageDTO> OnMatchFusionListRes {
		add; // 0x0000000180372760-0x0000000180372830
		remove; // 0x00000001803737C0-0x0000000180373890
	}
	public event Action<ChatMessageDTO> OnMatchFusionRes {
		add; // 0x0000000180372830-0x0000000180372900
		remove; // 0x0000000180373890-0x0000000180373960
	}
	public event Action<ChatMessageDTO> OnMatchGameOver {
		add; // 0x0000000180372900-0x00000001803729D0
		remove; // 0x0000000180373960-0x0000000180373A30
	}
	public event Action<ChatMessageDTO> OnMatchEndNotice {
		add; // 0x0000000180372690-0x0000000180372760
		remove; // 0x00000001803736F0-0x00000001803737C0
	}
	public event Action<ChatMessageDTO> OnMatchResultPush {
		add; // 0x0000000180372E70-0x0000000180372F40
		remove; // 0x0000000180373ED0-0x0000000180373FA0
	}
	public event Action<ChatMessageDTO> OnMatchReadyState {
		add; // 0x0000000180372CE0-0x0000000180372DB0
		remove; // 0x0000000180373D40-0x0000000180373E10
	}

	// Constructors
	public WsMatchClient(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInit(); // 0x0000000180370860-0x0000000180370950
	private void Awake(); // 0x0000000180370950-0x0000000180370A90
	private void OnDestroy(); // 0x0000000180371030-0x0000000180371220
	private void Subscribe(); // 0x0000000180371910-0x0000000180372090
	private void EnsureRoomKickSubscription(); // 0x0000000180370A90-0x0000000180370C60
	private void Unsubscribe(); // 0x0000000180372310-0x0000000180372440
	private static Action<ChatMessageDTO> Forward(Action<ChatMessageDTO> a); // 0x0000000180370C60-0x0000000180370C70
	private void HandleKickedWhileInMatch(string reason); // 0x0000000180370C70-0x0000000180371030
	internal static string ResolveFallbackKickScene(string reason, bool inCoop, bool inPvp, bool coopHandlerAlive, bool pvpHandlerAlive); // 0x0000000180371280-0x0000000180371360
	public void RequestResync(string matchId); // 0x0000000180371220-0x0000000180371280
	public void SendMove(string matchId, int fromCol, int fromRow, int toCol, int toRow, long seqNum); // 0x00000001803716A0-0x0000000180371740
	public void SendCardUse(string matchId, int cardId, int? cardTarget = default); // 0x00000001803713D0-0x0000000180371450
	public void SendSkillUse(string matchId, int skillCardId, int correctDotCount, string timingResult, int dotsToDestroy, List<int> selectedRows, List<List<int>> selectedDots, List<string> qtePresses = null, int? qteElapsedMs = default); // 0x0000000180371840-0x0000000180371910
	public void SendQteStart(string matchId, int skillCardId); // 0x0000000180371740-0x00000001803717B0
	public void SendFusionList(string matchId); // 0x00000001803715D0-0x0000000180371630
	public void SendFusionUse(string matchId, long fusionUserPetId); // 0x0000000180371630-0x00000001803716A0
	public void SendClientReady(string matchId); // 0x0000000180371450-0x00000001803714B0
	public void SendAnimDone(string matchId, long ackToken); // 0x0000000180371360-0x00000001803713D0
	public void SendDragPause(string matchId); // 0x00000001803714B0-0x0000000180371510
	public void SendDragResume(string matchId); // 0x0000000180371510-0x0000000180371570
	public void SendEnergyUse(); // 0x0000000180371570-0x00000001803715D0
	public void SendShadowReport(string matchId, long seqNum, int clientDamage, int clientBossHpAfter, int clientPlayerHpAfter); // 0x00000001803717B0-0x0000000180371840
	[CompilerGenerated]
	private void _Subscribe_b__72_0(ChatMessageDTO e); // 0x0000000180372090-0x00000001803720B0
	[CompilerGenerated]
	private void _Subscribe_b__72_1(ChatMessageDTO e); // 0x00000001803721F0-0x0000000180372210
	[CompilerGenerated]
	private void _Subscribe_b__72_2(ChatMessageDTO e); // 0x0000000180372210-0x0000000180372230
	[CompilerGenerated]
	private void _Subscribe_b__72_3(ChatMessageDTO e); // 0x0000000180372230-0x0000000180372250
	[CompilerGenerated]
	private void _Subscribe_b__72_4(ChatMessageDTO e); // 0x0000000180372250-0x0000000180372270
	[CompilerGenerated]
	private void _Subscribe_b__72_5(ChatMessageDTO e); // 0x0000000180372270-0x0000000180372290
	[CompilerGenerated]
	private void _Subscribe_b__72_6(ChatMessageDTO e); // 0x0000000180372290-0x00000001803722B0
	[CompilerGenerated]
	private void _Subscribe_b__72_7(ChatMessageDTO e); // 0x00000001803722B0-0x00000001803722D0
	[CompilerGenerated]
	private void _Subscribe_b__72_8(ChatMessageDTO e); // 0x00000001803722D0-0x00000001803722F0
	[CompilerGenerated]
	private void _Subscribe_b__72_9(ChatMessageDTO e); // 0x00000001803722F0-0x0000000180372310
	[CompilerGenerated]
	private void _Subscribe_b__72_10(ChatMessageDTO e); // 0x00000001803720B0-0x00000001803720D0
	[CompilerGenerated]
	private void _Subscribe_b__72_11(ChatMessageDTO e); // 0x00000001803720D0-0x00000001803720F0
	[CompilerGenerated]
	private void _Subscribe_b__72_12(ChatMessageDTO e); // 0x00000001803720F0-0x0000000180372110
	[CompilerGenerated]
	private void _Subscribe_b__72_13(ChatMessageDTO e); // 0x0000000180372110-0x0000000180372130
	[CompilerGenerated]
	private void _Subscribe_b__72_14(ChatMessageDTO e); // 0x0000000180372130-0x0000000180372150
	[CompilerGenerated]
	private void _Subscribe_b__72_15(ChatMessageDTO e); // 0x0000000180372150-0x0000000180372170
	[CompilerGenerated]
	private void _Subscribe_b__72_16(ChatMessageDTO e); // 0x0000000180372170-0x0000000180372190
	[CompilerGenerated]
	private void _Subscribe_b__72_17(ChatMessageDTO e); // 0x0000000180372190-0x00000001803721B0
	[CompilerGenerated]
	private void _Subscribe_b__72_18(ChatMessageDTO e); // 0x00000001803721B0-0x00000001803721D0
	[CompilerGenerated]
	private void _Subscribe_b__72_19(ChatMessageDTO e); // 0x00000001803721D0-0x00000001803721F0
}

