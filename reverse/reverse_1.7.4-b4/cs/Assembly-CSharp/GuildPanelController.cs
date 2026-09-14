/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class GuildPanelController : MonoBehaviour, IPokyEventPanel // TypeDefIndex: 875
{
	// Fields
	public const string PANEL_KEY = "PanelGuild"; // Metadata: 0x005EFF57
	[Header("Khung")]
	[SerializeField]
	private GameObject frame; // 0x20
	[SerializeField]
	private Button btnClose; // 0x28
	[Header("Ba nh\u00F3m layout")]
	[SerializeField]
	private GuildJoinView joinView; // 0x30
	[SerializeField]
	private GuildCreateView createView; // 0x38
	[SerializeField]
	private GuildHallView hallView; // 0x40
	[SerializeField]
	private GuildRaidView raidView; // 0x48
	[Header("Modal")]
	[SerializeField]
	private GuildMembersView membersView; // 0x50
	[SerializeField]
	private GuildRequestsView requestsView; // 0x58
	[SerializeField]
	private GuildEditView editView; // 0x60
	[SerializeField]
	private GuildShopView shopView; // 0x68
	[Header("H\u1ED9p x\u00E1c nh\u1EADn (C\u00F3 / Hu\u1EF7)")]
	[SerializeField]
	private GameObject confirmDim; // 0x70
	[SerializeField]
	private UnityEngine.UI.Text txtConfirm; // 0x78
	[SerializeField]
	private Button btnConfirmYes; // 0x80
	[SerializeField]
	private Button btnConfirmNo; // 0x88
	private readonly List<int> _tweens; // 0x90
	private int _userId; // 0x98
	private bool _wired; // 0x9C
	private bool _busy; // 0x9D
	private CanvasGroup _frameGroup; // 0xA0
	private Action _confirmYes; // 0xA8
	private GuildHomeData _home; // 0xB0
	private GuildDetailData _detail; // 0xB8
	private static bool _hasGuildCache; // 0x00
	private static int _hasGuildOwner; // 0x04
	[CompilerGenerated]
	private static Action<bool> OnGuildMembershipChanged; // 0x08
	private int _lastLevel; // 0xC0
	private GuildTopView _topView; // 0xC8
	private GuildDetailPopup _detailPopup; // 0xD0
	private GuildMembersPopup _membersPopup; // 0xD8
	private GuildRequestsPopup _requestsPopup; // 0xE0
	private GuildVaultPopup _vaultPopup; // 0xE8
	private GuildHornPopup _hornPopup; // 0xF0
	[CompilerGenerated]
	private GuildSeasonInfo _Season_k__BackingField; // 0xF8
	[CompilerGenerated]
	private GuildVaultBrief _VaultBrief_k__BackingField; // 0x100
	private const float RAID_REQUEST_WINDOW = 5f; // Metadata: 0x005EFF62
	private static float _openRaidUntil; // 0x10
	private bool _pushHooked; // 0x108

	// Properties
	public static bool HasGuild { get; } // 0x00000001805523D0-0x0000000180552450 
	public int UserId { get; } // 0x00000001805527A0-0x00000001805527B0 
	public bool IsBusy { get; } // 0x00000001805527B0-0x00000001805527C0 
	public GuildHomeData Home { get; } // 0x00000001802D8F30-0x00000001802D8F40 
	public int MyRole { get; } // 0x00000001805527D0-0x0000000180552810 
	public GuildSeasonInfo Season { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180552810-0x0000000180552820 0x0000000180552820-0x0000000180552880
	public GuildVaultBrief VaultBrief { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802B4A40-0x00000001802B4A50 0x00000001802B4AF0-0x00000001802B4B50
	public Transform PopupHost { get; } // 0x0000000180552980-0x0000000180552A90 
	public bool HasGuildNow { get; } // 0x0000000180552A90-0x0000000180552AC0 
	public long MyGuildId { get; } // 0x0000000180552AC0-0x0000000180552AF0 
	public bool CanManageRequests { get; } // 0x0000000180554A80-0x0000000180554AC0 
	public GuildDetailData Detail { get; } // 0x00000001802D8FA0-0x00000001802D8FB0 
	private static bool Live { get; } // 0x0000000180554AC0-0x0000000180554B40 
	private static bool RaidRequestPending { get; } // 0x00000001805551E0-0x0000000180555290 

	// Events
	public static event Action<bool> OnGuildMembershipChanged {
		add; // 0x0000000180552520-0x0000000180552660
		remove; // 0x0000000180552660-0x00000001805527A0
	}

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 876
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__92_1; // 0x08

		// Constructors
		static __c(); // 0x000000018055B1F0-0x000000018055B290
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ReloadDetail_b__92_1(string err); // 0x000000018055B290-0x000000018055B310
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass104_0<T> // TypeDefIndex: 877
	{
		// Fields
		public GuildPanelController __4__this;
		public Action<T> onOk;
		public Action<string> onError;

		// Constructors
		public __c__DisplayClass104_0();

		// Methods
		internal void _Get_b__0(T d);
		internal void _Get_b__1(string err);
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass105_0<T> // TypeDefIndex: 878
	{
		// Fields
		public GuildPanelController __4__this;
		public Action<T> onOk;
		public Action onFail;

		// Constructors
		public __c__DisplayClass105_0();

		// Methods
		internal void _Post_b__0(T d);
		internal void _Post_b__1(string err);
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass106_0 // TypeDefIndex: 879
	{
		// Fields
		public GuildPanelController __4__this; // 0x10
		public Action onOk; // 0x18
		public Action onFail; // 0x20

		// Constructors
		public __c__DisplayClass106_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PostRaw_b__0(string _); // 0x000000018055B310-0x000000018055B3C0
		internal void _PostRaw_b__1(string err); // 0x000000018055B3C0-0x000000018055B480
	}

	// Constructors
	public GuildPanelController(); // 0x000000018055ACD0-0x000000018055ADD0

	// Methods
	public static void NoteHasGuild(bool hasGuild); // 0x0000000180552450-0x0000000180552520
	public void NoteGuildLevel(int level); // 0x00000001805527C0-0x00000001805527D0
	public void NoteTopGuilds(GuildTopGuildsData d); // 0x0000000180552880-0x0000000180552980
	public void OpenTopGuilds(); // 0x0000000180552AF0-0x0000000180552DA0
	public void OpenGuildDetail(long guildId, Action<long, bool> onRequestChanged = null); // 0x0000000180552DA0-0x0000000180553100
	public void OpenVault(); // 0x0000000180553100-0x00000001805535B0
	public void OpenHorn(); // 0x00000001805535B0-0x0000000180553A30
	public void RefetchTop(); // 0x0000000180553A30-0x0000000180553B60
	private void HideInfoPopups(); // 0x0000000180553B60-0x0000000180554240
	private void RaiseInfoPopups(); // 0x0000000180554240-0x0000000180554A80
	private void Awake(); // 0x0000000180554B40-0x0000000180554B50
	public void OpenPanel(); // 0x0000000180554B50-0x0000000180555100
	public static void RequestOpenRaid(); // 0x0000000180555100-0x0000000180555190
	public static void ClearOpenRaidRequest(); // 0x0000000180555190-0x00000001805551E0
	private void OnEnable(); // 0x0000000180555290-0x00000001805552B0
	private void OnDisable(); // 0x00000001805552B0-0x0000000180555350
	private void OnDestroy(); // 0x0000000180555350-0x0000000180555360
	private void EnsureWired(); // 0x0000000180555360-0x0000000180556460
	private T Attach<T>(Transform root, string nodeName)
		where T : Component;
	public void ReloadHome(); // 0x0000000180556460-0x00000001805565C0
	public void ApplyHome(GuildHomeData d); // 0x00000001805565C0-0x0000000180557150
	private static bool VaultNotifyOf(GuildHomeData d); // 0x0000000180557150-0x00000001805571D0
	private void NoteLevelUp(int level); // 0x00000001805571D0-0x0000000180557310
	public void ReloadDetail(); // 0x0000000180557310-0x0000000180557600
	public void OpenCreate(); // 0x0000000180557600-0x0000000180557780
	public void OpenMembers(); // 0x0000000180557780-0x0000000180557A40
	public void OpenRequests(); // 0x0000000180557A40-0x0000000180557E80
	public void OpenEdit(); // 0x0000000180557E80-0x0000000180557FA0
	public void OpenShop(); // 0x0000000180557FA0-0x0000000180558130
	private void BringToFront(Component view); // 0x0000000180558130-0x0000000180558900
	public void OpenRaid(); // 0x0000000180558900-0x0000000180558A90
	public void ShowHall(); // 0x0000000180558A90-0x0000000180558CB0
	public void ClosePanel(); // 0x0000000180558CB0-0x0000000180558F10
	public void CloseForBattle(); // 0x0000000180558F10-0x0000000180559130
	private void HideAll(); // 0x0000000180559130-0x0000000180559510
	public void Get<T>(string url, Action<T> onOk, Action<string> onError = null);
	public void Post<T>(string url, object body, Action<T> onOk, Action onFail = null);
	public void PostRaw(string url, Action onOk, Action onFail = null); // 0x0000000180559510-0x0000000180559870
	private void SubscribePush(bool on); // 0x0000000180559870-0x0000000180559A30
	private void HandleGuildPush(ChatMessageDTO m); // 0x0000000180559A30-0x000000018055A0C0
	public void Confirm(string message, Action onYes); // 0x000000018055A0C0-0x000000018055A440
	private void HideConfirm(); // 0x000000018055A440-0x000000018055A5E0
	private void SetLoading(bool on); // 0x000000018055A5E0-0x000000018055AAC0
	private void Track(int id); // 0x000000018055AAC0-0x000000018055AB70
	private void CancelFx(); // 0x000000018055AB70-0x000000018055ACD0
	[CompilerGenerated]
	private void _EnsureWired_b__86_0(); // 0x000000018055ADD0-0x000000018055AE10
	[CompilerGenerated]
	private void _ReloadHome_b__88_0(GuildHomeData d); // 0x000000018055AE10-0x000000018055AE60
	[CompilerGenerated]
	private void _ReloadHome_b__88_1(string err); // 0x000000018055AE60-0x000000018055AFB0
	[CompilerGenerated]
	private void _ReloadDetail_b__92_0(GuildDetailData d); // 0x000000018055AFB0-0x000000018055B1F0
}

