/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class GuildRow : MonoBehaviour // TypeDefIndex: 932
{
	// Fields
	[SerializeField]
	private GuildLogoView logo; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text txtName; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtNumMember; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text txtPoint; // 0x38
	[SerializeField]
	private Button btnJoin; // 0x40
	[SerializeField]
	private Button btnCancel; // 0x48
	private static readonly Vector2 NAME_POS; // 0x00
	private static readonly Vector2 NAME_SIZE; // 0x08
	private static readonly Vector2 LEVEL_POS; // 0x10
	private static readonly Vector2 LEVEL_SIZE; // 0x18
	private static readonly Vector2 ICON_POS; // 0x20
	private static readonly Vector2 ICON_SIZE; // 0x28
	private static readonly Vector2 MEMBER_POS; // 0x30
	private static readonly Vector2 MEMBER_SIZE; // 0x38
	private const int NAME_FS = 26; // Metadata: 0x005F0211
	private const int NAME_FS_MIN = 16; // Metadata: 0x005F0212
	private const int LEVEL_FS = 20; // Metadata: 0x005F0213
	private const float ICON_MAX_W = 120f; // Metadata: 0x005F0214
	private const string NODE_LEVEL = "txtLevel"; // Metadata: 0x005F0218
	private const string NODE_CHIP_BG = "chipBg"; // Metadata: 0x005F0221
	private static readonly Color LEVEL_COLOR; // 0x40
	private static readonly Vector2 CENTER; // 0x50
	private bool _wired; // 0x50
	private GuildListItem _data; // 0x58
	private RectTransform _levelChip; // 0x60
	private UnityEngine.UI.Text _txtLevel; // 0x68

	// Properties
	public GuildListItem Data { get; } // 0x0000000180345800-0x0000000180345810 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass30_0 // TypeDefIndex: 933
	{
		// Fields
		public Action<GuildListItem> onJoin; // 0x10
		public GuildRow __4__this; // 0x18
		public Action<GuildListItem> onCancel; // 0x20
		public Action<GuildListItem> onDetail; // 0x28

		// Constructors
		public __c__DisplayClass30_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Bind_b__0(); // 0x00000001805B0970-0x00000001805B09B0
		internal void _Bind_b__1(); // 0x00000001805B09B0-0x00000001805B09F0
		internal void _Bind_b__2(); // 0x00000001805B09F0-0x00000001805B0A30
	}

	// Constructors
	public GuildRow(); // 0x000000018028A560-0x000000018028A5B0
	static GuildRow(); // 0x00000001805B0800-0x00000001805B0970

	// Methods
	private void Awake(); // 0x00000001805ACE80-0x00000001805ACE90
	private void EnsureWired(); // 0x00000001805ACE90-0x00000001805AD9A0
	public void Bind(GuildListItem data, Action<GuildListItem> onJoin, Action<GuildListItem> onCancel, Action<GuildListItem> onDetail); // 0x00000001805AD9A0-0x00000001805AE070
	public void SetRequested(bool requested); // 0x00000001805AE070-0x00000001805AE110
	private void NormalizeRowLayout(); // 0x00000001805AE110-0x00000001805AE4B0
	private void PlaceMemberIcon(); // 0x00000001805AE4B0-0x00000001805AE800
	private void SetLevel(int level); // 0x00000001805AE800-0x00000001805AE9E0
	private void EnsureLevelChip(); // 0x00000001805AE9E0-0x00000001805AFB50
	private static UnityEngine.UI.Text CloneText(UnityEngine.UI.Text sample, Transform parent, string nodeName); // 0x00000001805AFB50-0x00000001805B0250
	private void Place(RectTransform rt, Vector2 pos, Vector2 size); // 0x00000001805B0250-0x00000001805B0570
	private static void FitText(UnityEngine.UI.Text t, int max, int min); // 0x00000001805B0570-0x00000001805B0800
}

