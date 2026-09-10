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

public class GuildJoinView : MonoBehaviour // TypeDefIndex: 710
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
	private const float LOAD_MORE_AT = 0.08f; // Metadata: 0x0068BA77
	private readonly List<GuildRow> _pool; // 0x60
	private readonly List<GuildListItem> _items; // 0x68
	private readonly HashSet<long> _pending; // 0x70
	private GuildPanelController _owner; // 0x78
	private bool _wired; // 0x80
	private bool _loading; // 0x81
	private int _page; // 0x84
	private int _totalPages; // 0x88
	private string _query; // 0x90

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass24_0 // TypeDefIndex: 711
	{
		// Fields
		public GuildJoinView __4__this; // 0x10
		public int page; // 0x18

		// Constructors
		public __c__DisplayClass24_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadPage_b__0(GuildListData d); // 0x000000018047E6B0-0x000000018047E830
		internal void _LoadPage_b__1(string err); // 0x000000018047E830-0x000000018047E8C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass27_0 // TypeDefIndex: 712
	{
		// Fields
		public GuildJoinView __4__this; // 0x10
		public GuildListItem g; // 0x18

		// Constructors
		public __c__DisplayClass27_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OnClickJoin_b__0(GuildActionData _); // 0x000000018047E8C0-0x000000018047EA00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass28_0 // TypeDefIndex: 713
	{
		// Fields
		public GuildJoinView __4__this; // 0x10
		public GuildListItem g; // 0x18

		// Constructors
		public __c__DisplayClass28_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OnClickCancel_b__0(GuildActionData _); // 0x000000018047EA00-0x000000018047EB40
	}

	// Constructors
	public GuildJoinView(); // 0x000000018046BE30-0x000000018046BF70

	// Methods
	public void Init(GuildPanelController owner); // 0x000000018046AB40-0x000000018046AB70
	private void EnsureWired(); // 0x000000018046A210-0x000000018046AAF0
	public void Open(long[] myPendingRequests); // 0x000000018046B450-0x000000018046B630
	public void Close(); // 0x00000001802F4D60-0x00000001802F4DB0
	private void Reload(string query); // 0x000000018046B630-0x000000018046B6E0
	private void HandleScroll(Vector2 pos); // 0x000000018046AAF0-0x000000018046AB40
	private void LoadPage(int page); // 0x000000018046AB70-0x000000018046AD40
	private void RenderRows(); // 0x000000018046B6E0-0x000000018046BAA0
	private GuildRow EnsureRow(int index); // 0x000000018046A010-0x000000018046A210
	private void OnClickJoin(GuildListItem g); // 0x000000018046B280-0x000000018046B450
	private void OnClickCancel(GuildListItem g); // 0x000000018046AEA0-0x000000018046B070
	private void OnClickDetail(GuildListItem g); // 0x000000018046B070-0x000000018046B280
	private void MarkRequested(long guildId, bool requested); // 0x000000018046AD40-0x000000018046AEA0
	[CompilerGenerated]
	private void _EnsureWired_b__19_0(); // 0x000000018046BAA0-0x000000018046BBB0
	[CompilerGenerated]
	private void _EnsureWired_b__19_1(); // 0x000000018046BBB0-0x000000018046BD30
	[CompilerGenerated]
	private void _EnsureWired_b__19_2(); // 0x000000018046BD30-0x000000018046BDB0
	[CompilerGenerated]
	private void _EnsureWired_b__19_3(); // 0x000000018046BDB0-0x000000018046BE30
	[CompilerGenerated]
	private void _EnsureWired_b__19_4(string v); // 0x000000018046B630-0x000000018046B6E0
}

