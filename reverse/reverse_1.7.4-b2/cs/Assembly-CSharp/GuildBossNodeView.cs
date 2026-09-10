/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class GuildBossNodeView : MonoBehaviour // TypeDefIndex: 679
{
	// Fields
	[SerializeField]
	private Transform imgBoss; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text txtLv; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtYc; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text txtWin; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text txtCt; // 0x40
	[SerializeField]
	private UnityEngine.UI.Text lblHunt; // 0x48
	[SerializeField]
	private UnityEngine.UI.Text txtHunt; // 0x50
	[SerializeField]
	private GameObject fightingBox; // 0x58
	[SerializeField]
	private UnityEngine.UI.Text txtFightingName; // 0x60
	private UnityEngine.UI.Text _lblYc; // 0x68
	private Button _btnClaim; // 0x70
	private UnityEngine.UI.Text _txtClaim; // 0x78
	private Image _imgClaim; // 0x80
	private const float PET_BOX_FALLBACK = 150f; // Metadata: 0x0068B7C2
	private const float INFO_W = 248f; // Metadata: 0x0068B7C6
	private const float INFO_H = 120f; // Metadata: 0x0068B7CA
	private const float INFO_Y = -130f; // Metadata: 0x0068B7CE
	private const float LABEL_X = -62f; // Metadata: 0x0068B7D2
	private const float VALUE_X = 60f; // Metadata: 0x0068B7D6
	private static readonly Vector2 LABEL_SIZE; // 0x00
	private static readonly Vector2 VALUE_SIZE; // 0x08
	private static readonly Vector2 FULL_SIZE; // 0x10
	private static readonly float[] ROW_Y; // 0x18
	private const int FONT_ROW = 16; // Metadata: 0x0068B7DA
	private const int FONT_TITLE = 18; // Metadata: 0x0068B7DB
	private const int FONT_MIN = 11; // Metadata: 0x0068B7DC
	private const int FIGHTING_NAME_MAX = 12; // Metadata: 0x0068B7DD
	private const string NODE_PET = "Image"; // Metadata: 0x0068B7DE
	private const string NODE_INFO = "Info"; // Metadata: 0x0068B7E4
	private const string NODE_BADGE = "huntOrderBadge"; // Metadata: 0x0068B7E9
	private const string BADGE_BG = "Image/petK/Circle Bg Dark"; // Metadata: 0x0068B7F8
	private const string BADGE_DIGIT = "Image/petK/number/number_A_"; // Metadata: 0x0068B812
	private static readonly Color CLEARED_BADGE; // 0x20
	private static readonly Color LV_GOLD; // 0x30
	private static readonly Color LABEL_CYAN; // 0x40
	private static readonly Color VALUE_GREEN; // 0x50
	private static readonly Color VALUE_RED; // 0x60
	private bool _wired; // 0x88
	private GuildBossNodeData _data; // 0x90
	private Color _winColorHome; // 0x98
	private Animator _petAnim; // 0xA8
	private Image _petImg; // 0xB0
	private PetImageFit _petFit; // 0xB8
	private int _petShown; // 0xC0
	private static Sprite _badgeBg; // 0x70
	private static Sprite[] _digits; // 0x78
	private static Material _grayMat; // 0x80
	private static bool _grayWarned; // 0x88

	// Properties
	public GuildBossNodeData Data { get; } // 0x0000000180319910-0x0000000180319920 
	public bool HasPetRig { get; } // 0x000000018043F4D0-0x000000018043F550 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass55_0 // TypeDefIndex: 680
	{
		// Fields
		public Action<GuildBossNodeData> onClick; // 0x10
		public GuildBossNodeView __4__this; // 0x18

		// Constructors
		public __c__DisplayClass55_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Bind_b__0(); // 0x000000018044F960-0x000000018044F9A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass56_0 // TypeDefIndex: 681
	{
		// Fields
		public Action<GuildBossNodeData> onClaim; // 0x10
		public GuildBossNodeView __4__this; // 0x18

		// Constructors
		public __c__DisplayClass56_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _RefreshClaimButton_b__0(); // 0x000000018044F960-0x000000018044F9A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass57_0 // TypeDefIndex: 682
	{
		// Fields
		public GuildBossNodeView __4__this; // 0x10
		public bool gray; // 0x18
		public Action done; // 0x20

		// Constructors
		public __c__DisplayClass57_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _LoadPet_b__0(bool _); // 0x000000018044F9A0-0x000000018044FA80
	}

	// Constructors
	public GuildBossNodeView(); // 0x000000018043F460-0x000000018043F4D0
	static GuildBossNodeView(); // 0x000000018043F2F0-0x000000018043F460

	// Methods
	private void Awake(); // 0x000000018043AAB0-0x000000018043AAC0
	private void OnDisable(); // 0x000000018043DE10-0x000000018043DE20
	private void EnsureWired(); // 0x000000018043CBF0-0x000000018043D140
	public void Bind(GuildBossNodeData data, int order, Action<GuildBossNodeData> onClick, Action<GuildBossNodeData> onClaim = null); // 0x000000018043AAC0-0x000000018043B900
	private void RefreshClaimButton(Action<GuildBossNodeData> onClaim); // 0x000000018043E170-0x000000018043EF30
	public void LoadPet(Action done); // 0x000000018043D140-0x000000018043D4E0
	public void ReleasePet(); // 0x000000018043EF30-0x000000018043F030
	public void SetFocused(bool on); // 0x000000018043F030-0x000000018043F0C0
	private static void SetGrayscale(Image img, bool on); // 0x000000018043F0C0-0x000000018043F2F0
	private void EnsureHuntRow(Transform info); // 0x000000018043C8F0-0x000000018043CBF0
	private void NormalizeInfoLayout(Transform info); // 0x000000018043D870-0x000000018043DE10
	private static string Ellipsize(string s, int max); // 0x000000018043C220-0x000000018043C2B0
	private static void PlaceInfoRow(Transform info, string name, Vector2 pos, Vector2 size, int maxFont, TextAnchor align); // 0x000000018043DFA0-0x000000018043E170
	private UnityEngine.UI.Text MakeInfoText(Transform parent, string name, Vector2 pos, Vector2 size, string value, Color color); // 0x000000018043D4E0-0x000000018043D870
	private void EnsureBadge(int order, bool locked, bool cleared); // 0x000000018043C2B0-0x000000018043C8F0
	private static void BuildDigits(Transform badgeT, int order, bool locked); // 0x000000018043B900-0x000000018043C220
	private float PetBoxSize(); // 0x000000018043DE20-0x000000018043DFA0
}

