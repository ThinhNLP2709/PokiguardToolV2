/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class PlayerUISlotPVP : MonoBehaviour // TypeDefIndex: 204
{
	// Fields
	[Header("UI \u2014 g\u00E1n Inspector ho\u1EB7c \u0111\u1EC3 tr\u1ED1ng \u0111\u1EC3 t\u1EF1 Find theo t\u00EAn")]
	[SerializeField]
	private SpriteRenderer sprAvatar; // 0x20
	[SerializeField]
	private Image imgLogo; // 0x28
	[SerializeField]
	private Image imgLevelFrame; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text txtLevel; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text txtUserName; // 0x40
	[SerializeField]
	private UnityEngine.UI.Text txtEnergy; // 0x48
	[SerializeField]
	private UnityEngine.UI.Text txtPassCount; // 0x50
	[SerializeField]
	private UnityEngine.UI.Text txtSansang; // 0x58
	[SerializeField]
	private Transform anmtPetRoot; // 0x60
	internal SpriteRenderer imgPet; // 0x68
	[SerializeField]
	public Button btnKick; // 0x70
	[SerializeField]
	private Image imgRankIcon; // 0x78
	[SerializeField]
	public Image leaderIcon; // 0x80
	[SerializeField]
	private WeaponBadgeUI weaponBadge; // 0x88
	[Header("PVP Stats")]
	[SerializeField]
	private UnityEngine.UI.Text txtWinLoss; // 0x90
	[SerializeField]
	private UnityEngine.UI.Text txtWinRate; // 0x98
	[SerializeField]
	private UnityEngine.UI.Text txtBestStreak; // 0xA0
	[SerializeField]
	private UnityEngine.UI.Text txtRankName; // 0xA8
	[SerializeField]
	private UnityEngine.UI.Text txtRankPosition; // 0xB0
	[Header("Default Sprites")]
	public Sprite defAvt; // 0xB8
	[Header("Pet Animation")]
	public Animator petAnimator; // 0xC0
	private RuntimeAnimatorController baseController; // 0xC8
	private Color _sansangColorDefault; // 0xD0
	private bool _sansangColorCaptured; // 0xE0
	internal PlayerUIModel usersInfo; // 0xE8
	internal int actorNumber; // 0xF0
	private const int LEGACY_IDX_IMAGE_AVT = 1; // Metadata: 0x0064C04D
	private const int LEGACY_IDX_LEVEL = 2; // Metadata: 0x0064C04E
	private const int LEGACY_IDX_USERNAME = 3; // Metadata: 0x0064C04F
	private const int LEGACY_IDX_PET = 4; // Metadata: 0x0064C050
	private const int LEGACY_IDX_ENERGY = 5; // Metadata: 0x0064C051
	private const int LEGACY_IDX_PASS = 6; // Metadata: 0x0064C052
	private string _lastAppliedPetId; // 0xF8
	private int _lastLoadedRankUserId; // 0x100
	private RuntimeAnimatorController _lastAppliedController; // 0x108
	private int _petAnimToken; // 0x110
	private string _petAnimLoadingId; // 0x118
	private static readonly Dictionary<int, int> _rankPosCache; // 0x00
	private static readonly Dictionary<int, float> _rankPosCacheTime; // 0x08
	private static readonly Dictionary<int, float> _rankPosRetryAt; // 0x10
	private static readonly HashSet<int> _rankPosInflight; // 0x18
	private const float RANK_POS_TTL = 120f; // Metadata: 0x0064C053
	private const float RANK_POS_FAIL_BACKOFF = 30f; // Metadata: 0x0064C057

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass35_0 // TypeDefIndex: 205
	{
		// Fields
		public PlayerUISlotPVP __4__this; // 0x10
		public string capturedUsername; // 0x18

		// Constructors
		public __c__DisplayClass35_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetData_b__0(); // 0x00000001806A5AD0-0x00000001806A5B40
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass42_0 // TypeDefIndex: 206
	{
		// Fields
		public PlayerUISlotPVP __4__this; // 0x10
		public int token; // 0x18
		public string petId; // 0x20

		// Constructors
		public __c__DisplayClass42_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _ReplacePetAnimations_b__0(AnimationClip[] clips); // 0x00000001806A5B40-0x00000001806A5C00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass50_0 // TypeDefIndex: 207
	{
		// Fields
		public int userId; // 0x10
		public PlayerUISlotPVP __4__this; // 0x18

		// Constructors
		public __c__DisplayClass50_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _LoadRankPositionForSlot_b__0(PvpProfileDTO data); // 0x00000001806A5C00-0x00000001806A5E50
		internal void _LoadRankPositionForSlot_b__1(string err); // 0x00000001806A5E50-0x00000001806A5F20
	}

	// Constructors
	public PlayerUISlotPVP(); // 0x000000018068BFF0-0x000000018068C010
	static PlayerUISlotPVP(); // 0x000000018068BE50-0x000000018068BFF0

	// Methods
	private void Awake(); // 0x000000018068A260-0x000000018068A290
	private void Start(); // 0x000000018068BDC0-0x000000018068BE50
	private void AutoFillMissingRefs(); // 0x0000000180689580-0x000000018068A260
	public void SetData(PlayerUIModel model); // 0x000000018068AA40-0x000000018068BDC0
	private static bool IsWsOwner(string userName); // 0x000000018068A290-0x000000018068A300
	public void ReplacePetAnimations(string petId); // 0x000000018068A6D0-0x000000018068AA40
	private void ApplyPetClipsPvp(string petId, AnimationClip[] clips); // 0x00000001806892B0-0x0000000180689580
	private void LoadRankPositionForSlot(int userId); // 0x000000018068A300-0x000000018068A6D0
}

