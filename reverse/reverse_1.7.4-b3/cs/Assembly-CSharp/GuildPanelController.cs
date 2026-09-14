/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class GuildPanelController : MonoBehaviour, IPokyEventPanel // TypeDefIndex: 873
{
	// Fields
	public const string PANEL_KEY = "PanelGuild"; // Metadata: 0x005EEB89
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
	private const float RAID_REQUEST_WINDOW = 5f; // Metadata: 0x005EEB94
	private static float _openRaidUntil; // 0x10
	private bool _pushHooked; // 0x108

	// Properties
	public static bool HasGuild { get; } // 0x0000000180550BC0-0x0000000180550C40 
	public int UserId { get; } // 0x0000000180550F90-0x0000000180550FA0 
	public bool IsBusy { get; } // 0x0000000180550FA0-0x0000000180550FB0 
	public GuildHomeData Home { get; } // 0x00000001802D8F00-0x00000001802D8F10 
	public int MyRole { get; } // 0x0000000180550FC0-0x0000000180551000 
	public GuildSeasonInfo Season { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180551000-0x0000000180551010 0x00000001803752E0-0x00000001803753C0
	public GuildVaultBrief VaultBrief { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802B4A40-0x00000001802B4A50 0x00000001802B4AF0-0x00000001802B4B50
	public Transform PopupHost { get; } // 0x0000000180551110-0x0000000180551220 
	public bool HasGuildNow { get; } // 0x0000000180551220-0x0000000180551250 
	public long MyGuildId { get; } // 0x0000000180551250-0x0000000180551280 
	public bool CanManageRequests { get; } // 0x0000000180553210-0x0000000180553250 
	public GuildDetailData Detail { get; } // 0x00000001802D8F70-0x00000001802D8F80 
	private static bool Live { get; } // 0x0000000180553250-0x00000001805532D0 
	private static bool RaidRequestPending { get; } // 0x0000000180553970-0x0000000180553A20 

	// Events
	public static event Action<bool> OnGuildMembershipChanged {
		add; // 0x0000000180550D10-0x0000000180550E50
		remove; // 0x0000000180550E50-0x0000000180550F90
	}

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 874
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__92_1; // 0x08

		// Constructors
		static __c(); // 0x0000000180559900-0x00000001805599A0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ReloadDetail_b__92_1(string err); // 0x00000001805599A0-0x0000000180559A20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass104_0<T> // TypeDefIndex: 875
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
	private sealed class __c__DisplayClass105_0<T> // TypeDefIndex: 876
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
	private sealed class __c__DisplayClass106_0 // TypeDefIndex: 877
	{
		// Fields
		public GuildPanelController __4__this; // 0x10
		public Action onOk; // 0x18
		public Action onFail; // 0x20

		// Constructors
		public __c__DisplayClass106_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PostRaw_b__0(string _); // 0x0000000180559A20-0x0000000180559A90
		internal void _PostRaw_b__1(string err); // 0x0000000180559A90-0x0000000180559B50
	}

	// Constructors
	public GuildPanelController(); // 0x0000000180559410-0x0000000180559510

	// Methods
	public static void NoteHasGuild(bool hasGuild); // 0x0000000180550C40-0x0000000180550D10
	public void NoteGuildLevel(int level); // 0x0000000180550FB0-0x0000000180550FC0
	public void NoteTopGuilds(GuildTopGuildsData d); // 0x0000000180551010-0x0000000180551110
	public void OpenTopGuilds(); // 0x0000000180551280-0x0000000180551530
	public void OpenGuildDetail(long guildId, Action<long, bool> onRequestChanged = null); // 0x0000000180551530-0x0000000180551890
	public void OpenVault(); // 0x0000000180551890-0x0000000180551D40
	public void OpenHorn(); // 0x0000000180551D40-0x00000001805521C0
	public void RefetchTop(); // 0x00000001805521C0-0x00000001805522F0
	private void HideInfoPopups(); // 0x00000001805522F0-0x00000001805529D0
	private void RaiseInfoPopups(); // 0x00000001805529D0-0x0000000180553210
	private void Awake(); // 0x00000001805532D0-0x00000001805532E0
	public void OpenPanel(); // 0x00000001805532E0-0x0000000180553890
	public static void RequestOpenRaid(); // 0x0000000180553890-0x0000000180553920
	public static void ClearOpenRaidRequest(); // 0x0000000180553920-0x0000000180553970
	private void OnEnable(); // 0x0000000180553A20-0x0000000180553A40
	private void OnDisable(); // 0x0000000180553A40-0x0000000180553AE0
	private void OnDestroy(); // 0x0000000180553AE0-0x0000000180553AF0
	private void EnsureWired(); // 0x0000000180553AF0-0x0000000180554BF0
	private T Attach<T>(Transform root, string nodeName)
		where T : Component;
	public void ReloadHome(); // 0x0000000180554BF0-0x0000000180554D50
	public void ApplyHome(GuildHomeData d); // 0x0000000180554D50-0x00000001805558E0
	private static bool VaultNotifyOf(GuildHomeData d); // 0x00000001805558E0-0x0000000180555960
	private void NoteLevelUp(int level); // 0x0000000180555960-0x0000000180555AA0
	public void ReloadDetail(); // 0x0000000180555AA0-0x0000000180555D90
	public void OpenCreate(); // 0x0000000180555D90-0x0000000180555F10
	public void OpenMembers(); // 0x0000000180555F10-0x00000001805561D0
	public void OpenRequests(); // 0x00000001805561D0-0x0000000180556610
	public void OpenEdit(); // 0x0000000180556610-0x0000000180556730
	public void OpenShop(); // 0x0000000180556730-0x00000001805568C0
	private void BringToFront(Component view); // 0x00000001805568C0-0x0000000180557090
	public void OpenRaid(); // 0x0000000180557090-0x0000000180557220
	public void ShowHall(); // 0x0000000180557220-0x0000000180557440
	public void ClosePanel(); // 0x0000000180557440-0x00000001805576A0
	public void CloseForBattle(); // 0x00000001805576A0-0x00000001805578C0
	private void HideAll(); // 0x00000001805578C0-0x0000000180557CA0
	public void Get<T>(string url, Action<T> onOk, Action<string> onError = null);
	public void Post<T>(string url, object body, Action<T> onOk, Action onFail = null);
	public void PostRaw(string url, Action onOk, Action onFail = null); // 0x0000000180557CA0-0x0000000180557FE0
	private void SubscribePush(bool on); // 0x0000000180557FE0-0x00000001805581A0
	private void HandleGuildPush(ChatMessageDTO m); // 0x00000001805581A0-0x0000000180558800
	public void Confirm(string message, Action onYes); // 0x0000000180558800-0x0000000180558B80
	private void HideConfirm(); // 0x0000000180558B80-0x0000000180558D20
	private void SetLoading(bool on); // 0x0000000180558D20-0x0000000180559200
	private void Track(int id); // 0x0000000180559200-0x00000001805592B0
	private void CancelFx(); // 0x00000001805592B0-0x0000000180559410
	[CompilerGenerated]
	private void _EnsureWired_b__86_0(); // 0x0000000180559510-0x0000000180559550
	[CompilerGenerated]
	private void _ReloadHome_b__88_0(GuildHomeData d); // 0x0000000180559550-0x00000001805595A0
	[CompilerGenerated]
	private void _ReloadHome_b__88_1(string err); // 0x00000001805595A0-0x00000001805596C0
	[CompilerGenerated]
	private void _ReloadDetail_b__92_0(GuildDetailData d); // 0x00000001805596C0-0x0000000180559900
}

