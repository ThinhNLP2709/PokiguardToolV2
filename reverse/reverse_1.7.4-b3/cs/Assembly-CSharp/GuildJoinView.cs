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

public class GuildJoinView : MonoBehaviour // TypeDefIndex: 803
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
	private const float LOAD_MORE_AT = 0.08f; // Metadata: 0x005EE9EB
	private readonly List<GuildRow> _pool; // 0x60
	private readonly List<GuildListItem> _items; // 0x68
	private readonly HashSet<long> _pending; // 0x70
	private GuildPanelController _owner; // 0x78
	private bool _wired; // 0x80
	private bool _loading; // 0x81
	private int _page; // 0x84
	private int _totalPages; // 0x88
	private string _query; // 0x90
	private const string NODE_TOP = "BtnTopGuilds"; // Metadata: 0x005EE9EF
	private static readonly Vector2 TOP_POS; // 0x00
	private static readonly Vector2 TOP_SIZE; // 0x08
	private const int TOP_FS = 22; // Metadata: 0x005EE9FC
	private Button _btnTopGuilds; // 0x98

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass29_0 // TypeDefIndex: 804
	{
		// Fields
		public GuildJoinView __4__this; // 0x10
		public int page; // 0x18

		// Constructors
		public __c__DisplayClass29_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _LoadPage_b__0(GuildListData d); // 0x00000001805359A0-0x0000000180535B70
		internal void _LoadPage_b__1(string err); // 0x0000000180535B70-0x0000000180535C10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass32_0 // TypeDefIndex: 805
	{
		// Fields
		public GuildJoinView __4__this; // 0x10
		public GuildListItem g; // 0x18

		// Constructors
		public __c__DisplayClass32_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClickJoin_b__0(GuildActionData _); // 0x0000000180535C10-0x0000000180535D80
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass33_0 // TypeDefIndex: 806
	{
		// Fields
		public GuildJoinView __4__this; // 0x10
		public GuildListItem g; // 0x18

		// Constructors
		public __c__DisplayClass33_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClickCancel_b__0(GuildActionData _); // 0x0000000180535D80-0x0000000180535EE0
	}

	// Constructors
	public GuildJoinView(); // 0x0000000180534F40-0x00000001805351F0
	static GuildJoinView(); // 0x00000001805351F0-0x0000000180535260

	// Methods
	public void Init(GuildPanelController owner); // 0x0000000180530490-0x00000001805304F0
	private void EnsureWired(); // 0x00000001805304F0-0x00000001805313F0
	public void Open(long[] myPendingRequests); // 0x00000001805313F0-0x0000000180531750
	public void Close(); // 0x0000000180516CA0-0x0000000180516D90
	private void Reload(string query); // 0x0000000180531750-0x0000000180531840
	private void HandleScroll(Vector2 pos); // 0x0000000180531840-0x0000000180531890
	private void LoadPage(int page); // 0x0000000180531890-0x0000000180531B60
	private void RenderRows(); // 0x0000000180531B60-0x00000001805322A0
	private GuildRow EnsureRow(int index); // 0x00000001805322A0-0x0000000180532700
	private void OnClickJoin(GuildListItem g); // 0x0000000180532700-0x00000001805329F0
	private void OnClickCancel(GuildListItem g); // 0x00000001805329F0-0x0000000180532CE0
	private void OnClickDetail(GuildListItem g); // 0x0000000180532CE0-0x0000000180532EF0
	internal void MarkRequested(long guildId, bool requested); // 0x0000000180532EF0-0x0000000180533100
	private void EnsureTopGuildsButton(); // 0x0000000180533100-0x0000000180534510
	private Sprite TopButtonSprite(); // 0x0000000180534510-0x0000000180534B60
	private Font SampleFont(); // 0x0000000180534B60-0x0000000180534F40
	[CompilerGenerated]
	private void _EnsureWired_b__24_0(); // 0x0000000180535260-0x0000000180535380
	[CompilerGenerated]
	private void _EnsureWired_b__24_1(); // 0x0000000180535380-0x00000001805355E0
	[CompilerGenerated]
	private void _EnsureWired_b__24_2(); // 0x00000001805355E0-0x00000001805356E0
	[CompilerGenerated]
	private void _EnsureWired_b__24_3(); // 0x00000001805356E0-0x00000001805357E0
	[CompilerGenerated]
	private void _EnsureWired_b__24_4(string v); // 0x00000001805357E0-0x00000001805357F0
	[CompilerGenerated]
	private void _OnClickDetail_b__34_0(long id, bool requested); // 0x00000001805357F0-0x00000001805358A0
	[CompilerGenerated]
	private void _EnsureTopGuildsButton_b__36_0(); // 0x00000001805358A0-0x00000001805359A0
}

