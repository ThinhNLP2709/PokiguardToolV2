/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class GuildMemberRow : MonoBehaviour // TypeDefIndex: 715
{
	// Fields
	[SerializeField]
	private UnityEngine.UI.Text txtName; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text txtStatus; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtRole; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text txtEloPve; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text txtEloPvp; // 0x40
	[SerializeField]
	private UnityEngine.UI.Text txtPoint; // 0x48
	[SerializeField]
	private GameObject iconEloPve; // 0x50
	[SerializeField]
	private GameObject iconEloPvp; // 0x58
	[SerializeField]
	private Button btnDetail; // 0x60
	private static readonly Color DOT_ONLINE; // 0x00
	private static readonly Color DOT_OFFLINE; // 0x10
	private const int BADGE_MAX_RANK = 10; // Metadata: 0x0068BA7C
	private const int MOBILE_MIN_FONT = 24; // Metadata: 0x0068BA7D
	private const float DETAIL_TOUCH_SIDE = 72f; // Metadata: 0x0068BA7E
	private static readonly Color RANK_GOLD; // 0x20
	private static readonly Color RANK_SILVER; // 0x30
	private static readonly Color RANK_BRONZE; // 0x40
	private static readonly Color LC_COLOR; // 0x50
	private const string NODE_RANK = "txtGuildRank"; // Metadata: 0x0068BA82
	private const string NODE_POWER = "txtGuildPower"; // Metadata: 0x0068BA8F
	private bool _wired; // 0x68
	private GuildMemberItem _data; // 0x70
	private UnityEngine.UI.Text _txtRank; // 0x78
	private UnityEngine.UI.Text _txtPower; // 0x80

	// Properties
	public GuildMemberItem Data { get; } // 0x000000018046EFB0-0x000000018046EFC0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass29_0 // TypeDefIndex: 716
	{
		// Fields
		public Action<GuildMemberItem, RectTransform> onDetail; // 0x10
		public GuildMemberRow __4__this; // 0x18

		// Constructors
		public __c__DisplayClass29_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Bind_b__0(); // 0x000000018047EB40-0x000000018047EBE0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass37_0 // TypeDefIndex: 717
	{
		// Fields
		public GuildMemberRow __4__this; // 0x10
		public Color target; // 0x18

		// Constructors
		public __c__DisplayClass37_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _FlashRole_b__0(float k); // 0x000000018047EBE0-0x000000018047ED20
		internal void _FlashRole_b__1(); // 0x000000018047ED20-0x000000018047EDD0
	}

	// Constructors
	public GuildMemberRow(); // 0x00000001802EBA70-0x00000001802EBAF0
	static GuildMemberRow(); // 0x000000018046EEF0-0x000000018046EFB0

	// Methods
	private void Awake(); // 0x000000018046D030-0x000000018046D040
	private void EnsureWired(); // 0x000000018046E0A0-0x000000018046E590
	private void WidenDetailTouch(); // 0x000000018046EAC0-0x000000018046EEF0
	public void Bind(GuildMemberItem data, Action<GuildMemberItem, RectTransform> onDetail, int rank = 0 /* Metadata: 0x0068BA7B */); // 0x000000018046D040-0x000000018046D6F0
	private void NormalizeRowLayout(); // 0x000000018046E7F0-0x000000018046E930
	private static void PlaceCentered(UnityEngine.UI.Text t, Vector2 pos, Vector2 size, TextAnchor align); // 0x000000018046E930-0x000000018046EAC0
	private void ApplyRankBadge(int rank); // 0x000000018046CDC0-0x000000018046D030
	private void ApplyCombatPower(long combatPower); // 0x000000018046CBA0-0x000000018046CDC0
	private UnityEngine.UI.Text EnsureRankNode(); // 0x000000018046DD50-0x000000018046E0A0
	private UnityEngine.UI.Text EnsurePowerNode(); // 0x000000018046DA50-0x000000018046DD50
	private static UnityEngine.UI.Text CloneText(UnityEngine.UI.Text sample, Transform parent, string nodeName); // 0x000000018046D6F0-0x000000018046DA50
	public void FlashRole(); // 0x000000018046E590-0x000000018046E7F0
}

