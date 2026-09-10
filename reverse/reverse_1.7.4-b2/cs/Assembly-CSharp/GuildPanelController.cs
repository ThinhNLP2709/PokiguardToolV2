/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class GuildPanelController : MonoBehaviour, IPokyEventPanel // TypeDefIndex: 763
{
	// Fields
	public const string PANEL_KEY = "PanelGuild"; // Metadata: 0x0068BAE8
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
	private GuildBossView bossView; // 0x48
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
	private static bool _openBossOnNextOpen; // 0x10
	private bool _pushHooked; // 0xC4

	// Properties
	public static bool HasGuild { get; } // 0x0000000180477960-0x00000001804779D0 
	public int UserId { get; } // 0x000000018039C4E0-0x000000018039C4F0 
	public bool IsBusy { get; } // 0x00000001804779D0-0x00000001804779E0 
	public GuildHomeData Home { get; } // 0x0000000180319900-0x0000000180319910 
	public int MyRole { get; } // 0x0000000180477A20-0x0000000180477A60 
	public bool CanManageRequests { get; } // 0x0000000180477920-0x0000000180477960 
	private static bool Live { get; } // 0x00000001804779E0-0x0000000180477A20 

	// Events
	public static event Action<bool> OnGuildMembershipChanged {
		add; // 0x0000000180477840-0x0000000180477920
		remove; // 0x0000000180477A60-0x0000000180477B40
	}

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 764
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<string> __9__57_1; // 0x08

		// Constructors
		static __c(); // 0x000000018047F690-0x000000018047F700
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ReloadDetail_b__57_1(string err); // 0x000000018047DDD0-0x000000018047DE40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass69_0<T> // TypeDefIndex: 765
	{
		// Fields
		public GuildPanelController __4__this;
		public Action<T> onOk;
		public Action<string> onError;

		// Constructors
		public __c__DisplayClass69_0();

		// Methods
		internal void _Get_b__0(T d);
		internal void _Get_b__1(string err);
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass70_0<T> // TypeDefIndex: 766
	{
		// Fields
		public GuildPanelController __4__this;
		public Action<T> onOk;
		public Action onFail;

		// Constructors
		public __c__DisplayClass70_0();

		// Methods
		internal void _Post_b__0(T d);
		internal void _Post_b__1(string err);
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass71_0 // TypeDefIndex: 767
	{
		// Fields
		public GuildPanelController __4__this; // 0x10
		public Action onOk; // 0x18
		public Action onFail; // 0x20

		// Constructors
		public __c__DisplayClass71_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PostRaw_b__0(string _); // 0x000000018047F570-0x000000018047F5E0
		internal void _PostRaw_b__1(string err); // 0x000000018047F5E0-0x000000018047F690
	}

	// Constructors
	public GuildPanelController(); // 0x00000001804777C0-0x0000000180477840

	// Methods
	public static void NoteHasGuild(bool hasGuild); // 0x0000000180475F90-0x0000000180476050
	public void NoteGuildLevel(int level); // 0x0000000180475F80-0x0000000180475F90
	private void Awake(); // 0x0000000180474890-0x00000001804748A0
	public void OpenPanel(); // 0x0000000180476660-0x0000000180476990
	public static void RequestOpenBoss(); // 0x0000000180476FE0-0x0000000180477020
	private void OnEnable(); // 0x0000000180476160-0x0000000180476180
	private void OnDisable(); // 0x0000000180476110-0x0000000180476160
	private void OnDestroy(); // 0x0000000180476100-0x0000000180476110
	private void EnsureWired(); // 0x0000000180474FF0-0x0000000180475B10
	private T Attach<T>(Transform root, string nodeName)
		where T : Component;
	public void ReloadHome(); // 0x0000000180476EB0-0x0000000180476FE0
	public void ApplyHome(GuildHomeData d); // 0x0000000180474280-0x0000000180474890
	private void NoteLevelUp(int level); // 0x0000000180476050-0x0000000180476100
	public void ReloadDetail(); // 0x0000000180476D20-0x0000000180476EB0
	public void OpenCreate(); // 0x00000001804762B0-0x00000001804763D0
	public void OpenMembers(); // 0x0000000180476470-0x0000000180476660
	public void OpenRequests(); // 0x0000000180476990-0x0000000180476A20
	public void OpenEdit(); // 0x00000001804763D0-0x0000000180476470
	public void OpenShop(); // 0x0000000180476A20-0x0000000180476B50
	private void BringToFront(Component view); // 0x00000001804748A0-0x00000001804749F0
	public void OpenBoss(); // 0x0000000180476180-0x00000001804762B0
	public void ShowHall(); // 0x00000001804771B0-0x0000000180477300
	public void ClosePanel(); // 0x0000000180474C40-0x0000000180474E70
	public void CloseForBattle(); // 0x0000000180474AC0-0x0000000180474C40
	private void HideAll(); // 0x0000000180475DB0-0x0000000180475EF0
	public void Get<T>(string url, Action<T> onOk, Action<string> onError = null);
	public void Post<T>(string url, object body, Action<T> onOk, Action onFail = null);
	public void PostRaw(string url, Action onOk, Action onFail = null); // 0x0000000180476B50-0x0000000180476D20
	private void SubscribePush(bool on); // 0x0000000180477300-0x0000000180477450
	private void HandleGuildPush(ChatMessageDTO m); // 0x0000000180475B10-0x0000000180475DB0
	public void Confirm(string message, Action onYes); // 0x0000000180474E70-0x0000000180474FF0
	private void HideConfirm(); // 0x0000000180475EF0-0x0000000180475F80
	private void SetLoading(bool on); // 0x0000000180477020-0x00000001804771B0
	private void Track(int id); // 0x0000000180477450-0x00000001804774F0
	private void CancelFx(); // 0x00000001804749F0-0x0000000180474AC0
	[CompilerGenerated]
	private void _EnsureWired_b__52_0(); // 0x00000001804774F0-0x0000000180477530
	[CompilerGenerated]
	private void _ReloadHome_b__54_0(GuildHomeData d); // 0x0000000180477640-0x0000000180477690
	[CompilerGenerated]
	private void _ReloadHome_b__54_1(string err); // 0x0000000180477690-0x00000001804777C0
	[CompilerGenerated]
	private void _ReloadDetail_b__57_0(GuildDetailData d); // 0x0000000180477530-0x0000000180477640
}

