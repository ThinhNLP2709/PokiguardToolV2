/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class GuildRaidRankRow : MonoBehaviour // TypeDefIndex: 897
{
	// Fields
	public const float ROW_W = 550f; // Metadata: 0x005EEC4E
	public const float ROW_H = 44f; // Metadata: 0x005EEC52
	private const float PAD = 8f; // Metadata: 0x005EEC56
	private const float BADGE_D = 34f; // Metadata: 0x005EEC5A
	private const float AVATAR_D = 36f; // Metadata: 0x005EEC5E
	private const float GAP = 6f; // Metadata: 0x005EEC62
	private const float TAG_W = 56f; // Metadata: 0x005EEC66
	private const float PCT_W = 78f; // Metadata: 0x005EEC6A
	private const float DAMAGE_W = 120f; // Metadata: 0x005EEC6E
	private const float TEXT_H = 30f; // Metadata: 0x005EEC72
	private const float BAR_H = 4f; // Metadata: 0x005EEC76
	private const int NAME_MAX_CHARS = 10; // Metadata: 0x005EEC7A
	private static readonly Color SELF_TINT; // 0x00
	private static readonly Color NORMAL_TINT; // 0x10
	private static readonly Color MUTED_TINT; // 0x20
	private static readonly Color SELF_BG; // 0x30
	private static readonly Color SELF_EDGE; // 0x40
	private static readonly Color ALT_BG; // 0x50
	private static readonly Color BAR_TRACK; // 0x60
	private static readonly Color RANK_GOLD; // 0x70
	private static readonly Color RANK_SILVER; // 0x80
	private static readonly Color RANK_BRONZE; // 0x90
	private static readonly Color RANK_PLAIN; // 0xA0
	[SerializeField]
	private UnityEngine.UI.Text txtRank; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text txtName; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtDamage; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text txtPct; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text txtTag; // 0x40
	[SerializeField]
	private Image imgSelfBg; // 0x48
	[SerializeField]
	private Image imgSelfEdge; // 0x50
	[SerializeField]
	private Image imgBadge; // 0x58
	[SerializeField]
	private Image imgBarFill; // 0x60
	private Outline _selfEdge; // 0x68
	private bool _wired; // 0x70

	// Constructors
	public GuildRaidRankRow(); // 0x000000018028A560-0x000000018028A5B0
	static GuildRaidRankRow(); // 0x0000000180577060-0x00000001805773D0

	// Methods
	private void Awake(); // 0x0000000180571310-0x0000000180571320
	private void EnsureWired(); // 0x0000000180571320-0x0000000180571FA0
	private Image Img(string nodeName); // 0x0000000180571FA0-0x0000000180572130
	public static GuildRaidRankRow Ensure(Transform content, int index, UnityEngine.UI.Text fontSample); // 0x0000000180572130-0x0000000180572840
	private void BuildMissingNodes(UnityEngine.UI.Text fontSample); // 0x0000000180572840-0x00000001805740F0
	private Image MakeStretchImage(string nodeName, Color color, float pad); // 0x00000001805740F0-0x0000000180574560
	private UnityEngine.UI.Text MakeText(string nodeName, Font font, int maxSize, TextAnchor align); // 0x0000000180574560-0x0000000180574B80
	public void NormalizeLayout(); // 0x0000000180574B80-0x0000000180575490
	private static void Place(UnityEngine.UI.Text t, float left, float width, float pivotX, TextAnchor align, int min, int max, float dy); // 0x0000000180575490-0x00000001805758C0
	public void Bind(GuildRaidRow row, float topPct, int index, int freeMax); // 0x00000001805758C0-0x0000000180575C80
	public void BindSelf(int rank, string name, long damage, float pct, int attempts, int attemptsLeft, int freeMax); // 0x0000000180575C80-0x0000000180576090
	private static string LeftTag(int attemptsLeft, int freeMax); // 0x0000000180576090-0x0000000180576200
	private void Paint(int rank, string name, long damage, float pct, long avtId, bool isMe, float topPct, int index, string tag, Color tagColor); // 0x0000000180576200-0x0000000180576E30
	private static Color BadgeColor(int rank); // 0x0000000180576E30-0x0000000180576F60
	private static string Ellipsis(string s); // 0x0000000180576F60-0x0000000180577060
}

