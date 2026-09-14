/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class GuildPermissionTooltip : MonoBehaviour // TypeDefIndex: 878
{
	// Fields
	[SerializeField]
	private RectTransform mainTooltip; // 0x20
	[SerializeField]
	private Button background; // 0x28
	[SerializeField]
	private Button btnView; // 0x30
	[SerializeField]
	private Button btnAddFriend; // 0x38
	[SerializeField]
	private Button btnPromote; // 0x40
	[SerializeField]
	private Button btnDemote; // 0x48
	[SerializeField]
	private Button btnKick; // 0x50
	private bool _wired; // 0x58
	private GuildMemberItem _target; // 0x60

	// Properties
	public GuildMemberItem Target { get; } // 0x000000018039E720-0x000000018039E730 
	public bool IsOpen { get; } // 0x0000000180559B50-0x0000000180559BD0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 879
	{
		// Fields
		public GuildPermissionTooltip __4__this; // 0x10
		public Action<GuildMemberItem> onView; // 0x18
		public GuildMemberItem target; // 0x20
		public Action<GuildMemberItem> onAddFriend; // 0x28
		public Action<GuildMemberItem> onPromote; // 0x30
		public Action<GuildMemberItem> onDemote; // 0x38
		public Action<GuildMemberItem> onKick; // 0x40

		// Constructors
		public __c__DisplayClass15_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Open_b__0(); // 0x000000018055BFE0-0x000000018055C030
		internal void _Open_b__1(); // 0x000000018055C030-0x000000018055C080
		internal void _Open_b__2(); // 0x000000018055C080-0x000000018055C0D0
		internal void _Open_b__3(); // 0x000000018055C0D0-0x000000018055C120
		internal void _Open_b__4(); // 0x000000018055C120-0x000000018055C170
	}

	// Constructors
	public GuildPermissionTooltip(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x0000000180559BD0-0x0000000180559BE0
	private void EnsureWired(); // 0x0000000180559BE0-0x000000018055A680
	public void Open(GuildMemberItem target, int myRole, long myUserId, Action<GuildMemberItem> onView, Action<GuildMemberItem> onAddFriend, Action<GuildMemberItem> onPromote, Action<GuildMemberItem> onDemote, Action<GuildMemberItem> onKick, RectTransform anchor); // 0x000000018055A680-0x000000018055AF40
	public void Close(); // 0x000000018055AF40-0x000000018055B090
	private void PlaceNear(RectTransform anchor); // 0x000000018055B090-0x000000018055BBB0
	private void PlayOpenFx(); // 0x000000018055BBB0-0x000000018055BE70
	private void OnDisable(); // 0x000000018055BE70-0x000000018055BFE0
}

