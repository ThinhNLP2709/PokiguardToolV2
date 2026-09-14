/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class GuildRow : MonoBehaviour // TypeDefIndex: 930
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
	private const int NAME_FS = 26; // Metadata: 0x005EEE43
	private const int NAME_FS_MIN = 16; // Metadata: 0x005EEE44
	private const int LEVEL_FS = 20; // Metadata: 0x005EEE45
	private const float ICON_MAX_W = 120f; // Metadata: 0x005EEE46
	private const string NODE_LEVEL = "txtLevel"; // Metadata: 0x005EEE4A
	private const string NODE_CHIP_BG = "chipBg"; // Metadata: 0x005EEE53
	private static readonly Color LEVEL_COLOR; // 0x40
	private static readonly Vector2 CENTER; // 0x50
	private bool _wired; // 0x50
	private GuildListItem _data; // 0x58
	private RectTransform _levelChip; // 0x60
	private UnityEngine.UI.Text _txtLevel; // 0x68

	// Properties
	public GuildListItem Data { get; } // 0x00000001803456E0-0x00000001803456F0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass30_0 // TypeDefIndex: 931
	{
		// Fields
		public Action<GuildListItem> onJoin; // 0x10
		public GuildRow __4__this; // 0x18
		public Action<GuildListItem> onCancel; // 0x20
		public Action<GuildListItem> onDetail; // 0x28

		// Constructors
		public __c__DisplayClass30_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Bind_b__0(); // 0x00000001805AF010-0x00000001805AF050
		internal void _Bind_b__1(); // 0x00000001805AF050-0x00000001805AF090
		internal void _Bind_b__2(); // 0x00000001805AF090-0x00000001805AF0D0
	}

	// Constructors
	public GuildRow(); // 0x000000018028A560-0x000000018028A5B0
	static GuildRow(); // 0x00000001805AEEA0-0x00000001805AF010

	// Methods
	private void Awake(); // 0x00000001805AB520-0x00000001805AB530
	private void EnsureWired(); // 0x00000001805AB530-0x00000001805AC040
	public void Bind(GuildListItem data, Action<GuildListItem> onJoin, Action<GuildListItem> onCancel, Action<GuildListItem> onDetail); // 0x00000001805AC040-0x00000001805AC710
	public void SetRequested(bool requested); // 0x00000001805AC710-0x00000001805AC7B0
	private void NormalizeRowLayout(); // 0x00000001805AC7B0-0x00000001805ACB50
	private void PlaceMemberIcon(); // 0x00000001805ACB50-0x00000001805ACEA0
	private void SetLevel(int level); // 0x00000001805ACEA0-0x00000001805AD080
	private void EnsureLevelChip(); // 0x00000001805AD080-0x00000001805AE1F0
	private static UnityEngine.UI.Text CloneText(UnityEngine.UI.Text sample, Transform parent, string nodeName); // 0x00000001805AE1F0-0x00000001805AE8F0
	private void Place(RectTransform rt, Vector2 pos, Vector2 size); // 0x00000001805AE8F0-0x00000001805AEC10
	private static void FitText(UnityEngine.UI.Text t, int max, int min); // 0x00000001805AEC10-0x00000001805AEEA0
}

