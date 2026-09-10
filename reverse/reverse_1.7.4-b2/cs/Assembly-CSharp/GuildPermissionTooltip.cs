/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class GuildPermissionTooltip : MonoBehaviour // TypeDefIndex: 768
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
	public GuildMemberItem Target { get; } // 0x0000000180385A10-0x0000000180385A20 
	public bool IsOpen { get; } // 0x0000000180478FF0-0x0000000180479020 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 769
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
		public __c__DisplayClass15_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Open_b__0(); // 0x000000018047E3E0-0x000000018047E470
		internal void _Open_b__1(); // 0x000000018047E470-0x000000018047E500
		internal void _Open_b__2(); // 0x000000018047E500-0x000000018047E590
		internal void _Open_b__3(); // 0x000000018047E590-0x000000018047E620
		internal void _Open_b__4(); // 0x000000018047E620-0x000000018047E6B0
	}

	// Constructors
	public GuildPermissionTooltip(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x0000000180477B40-0x0000000180477B50
	private void EnsureWired(); // 0x0000000180477BC0-0x0000000180478000
	public void Open(GuildMemberItem target, int myRole, long myUserId, Action<GuildMemberItem> onView, Action<GuildMemberItem> onAddFriend, Action<GuildMemberItem> onPromote, Action<GuildMemberItem> onDemote, Action<GuildMemberItem> onKick, RectTransform anchor); // 0x00000001804780A0-0x0000000180478730
	public void Close(); // 0x0000000180477B50-0x0000000180477BC0
	private void PlaceNear(RectTransform anchor); // 0x0000000180478730-0x0000000180478E40
	private void PlayOpenFx(); // 0x0000000180478E40-0x0000000180478FF0
	private void OnDisable(); // 0x0000000180478000-0x00000001804780A0
}

