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

public class GuildJoinView : MonoBehaviour // TypeDefIndex: 804
{
	// Fields
	[SerializeField]
	private ScrollRect scroll; // 0x20
	[SerializeField]
	private RectTransform content; // 0x28
	[SerializeField]
	private GameObject rowTemplate; // 0x30
	[SerializeField]
	private InputField inputFind; // 0x38
	[SerializeField]
	private Button btnFind; // 0x40
	[SerializeField]
	private Button btnCreate; // 0x48
	[SerializeField]
	private Button btnClose; // 0x50
	[SerializeField]
	private UnityEngine.UI.Text txtEmpty; // 0x58
	private const float LOAD_MORE_AT = 0.08f; // Metadata: 0x005EFDBA
	private readonly List<GuildRow> _pool; // 0x60
	private readonly List<GuildListItem> _items; // 0x68
	private readonly HashSet<long> _pending; // 0x70
	private GuildPanelController _owner; // 0x78
	private bool _wired; // 0x80
	private bool _loading; // 0x81
	private int _page; // 0x84
	private int _totalPages; // 0x88
	private string _query; // 0x90
	private const string NODE_TOP = "BtnTopGuilds"; // Metadata: 0x005EFDBE
	private static readonly Vector2 TOP_POS; // 0x00
	private static readonly Vector2 TOP_SIZE; // 0x08
	private const int TOP_FS = 22; // Metadata: 0x005EFDCB
	private Button _btnTopGuilds; // 0x98

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass29_0 // TypeDefIndex: 805
	{
		// Fields
		public GuildJoinView __4__this; // 0x10
		public int page; // 0x18

		// Constructors
		public __c__DisplayClass29_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadPage_b__0(GuildListData d); // 0x0000000180537180-0x0000000180537350
		internal void _LoadPage_b__1(string err); // 0x0000000180537350-0x00000001805373F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass32_0 // TypeDefIndex: 806
	{
		// Fields
		public GuildJoinView __4__this; // 0x10
		public GuildListItem g; // 0x18

		// Constructors
		public __c__DisplayClass32_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClickJoin_b__0(GuildActionData _); // 0x00000001805373F0-0x0000000180537560
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass33_0 // TypeDefIndex: 807
	{
		// Fields
		public GuildJoinView __4__this; // 0x10
		public GuildListItem g; // 0x18

		// Constructors
		public __c__DisplayClass33_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClickCancel_b__0(GuildActionData _); // 0x0000000180537560-0x00000001805376C0
	}

	// Constructors
	public GuildJoinView(); // 0x0000000180536720-0x00000001805369D0
	static GuildJoinView(); // 0x00000001805369D0-0x0000000180536A40

	// Methods
	public void Init(GuildPanelController owner); // 0x0000000180531C70-0x0000000180531CD0
	private void EnsureWired(); // 0x0000000180531CD0-0x0000000180532BD0
	public void Open(long[] myPendingRequests); // 0x0000000180532BD0-0x0000000180532F30
	public void Close(); // 0x0000000180518440-0x0000000180518530
	private void Reload(string query); // 0x0000000180532F30-0x0000000180533020
	private void HandleScroll(Vector2 pos); // 0x0000000180533020-0x0000000180533070
	private void LoadPage(int page); // 0x0000000180533070-0x0000000180533340
	private void RenderRows(); // 0x0000000180533340-0x0000000180533A80
	private GuildRow EnsureRow(int index); // 0x0000000180533A80-0x0000000180533EE0
	private void OnClickJoin(GuildListItem g); // 0x0000000180533EE0-0x00000001805341D0
	private void OnClickCancel(GuildListItem g); // 0x00000001805341D0-0x00000001805344C0
	private void OnClickDetail(GuildListItem g); // 0x00000001805344C0-0x00000001805346D0
	internal void MarkRequested(long guildId, bool requested); // 0x00000001805346D0-0x00000001805348E0
	private void EnsureTopGuildsButton(); // 0x00000001805348E0-0x0000000180535CF0
	private Sprite TopButtonSprite(); // 0x0000000180535CF0-0x0000000180536340
	private Font SampleFont(); // 0x0000000180536340-0x0000000180536720
	[CompilerGenerated]
	private void _EnsureWired_b__24_0(); // 0x0000000180536A40-0x0000000180536B60
	[CompilerGenerated]
	private void _EnsureWired_b__24_1(); // 0x0000000180536B60-0x0000000180536DC0
	[CompilerGenerated]
	private void _EnsureWired_b__24_2(); // 0x0000000180536DC0-0x0000000180536EC0
	[CompilerGenerated]
	private void _EnsureWired_b__24_3(); // 0x0000000180536EC0-0x0000000180536FC0
	[CompilerGenerated]
	private void _EnsureWired_b__24_4(string v); // 0x0000000180536FC0-0x0000000180536FD0
	[CompilerGenerated]
	private void _OnClickDetail_b__34_0(long id, bool requested); // 0x0000000180536FD0-0x0000000180537080
	[CompilerGenerated]
	private void _EnsureTopGuildsButton_b__36_0(); // 0x0000000180537080-0x0000000180537180
}

