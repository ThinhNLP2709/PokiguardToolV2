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
public class WeaponBadgeUI : MonoBehaviour // TypeDefIndex: 1493
{
	// Fields
	public const string NODE = "weaponBadge"; // Metadata: 0x005EFD56
	public const string BG_PREFIX = "weaponBg_"; // Metadata: 0x005EFD62
	public const float BG_ALPHA = 0.92f; // Metadata: 0x005EFD6C
	[Header("Refs \u2014 \u0111\u1EC3 tr\u1ED1ng s\u1EBD t\u1EF1 t\u00ECm theo t\u00EAn trong Awake")]
	[SerializeField]
	private Image imgIcon; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text txtStar; // 0x28
	[Header("T\u00F9y ch\u1ECDn")]
	[Tooltip("B\u1EA5m badge \u0111\u1EC3 m\u1EDF tooltip xem nhanh th\u00F4ng s\u1ED1.")]
	public bool clickable; // 0x30
	[Header("Ch\u1EBF \u0111\u1ED9 N\u1EC0N \u2014 \u1EA3nh v\u0169 kh\u00ED v\u1EBD SAU avatar thay v\u00EC badge g\u00F3c")]
	[SerializeField]
	[Tooltip("B\u1EADt khi node n\u00E0y l\u00E0 N\u1EC0N ph\u00EDa sau avatar: alpha d\u1ECBu l\u1EA1i v\u00E0 (n\u1EBFu c\u00F3 sortingCanvas) l\u1EDBp v\u1EBD = avatar \u2212 1 thay v\u00EC + 2.")]
	private bool backgroundMode; // 0x31
	[Header("Sorting \u2014 CH\u1EC8 d\u00F9ng khi badge n\u1EB1m c\u1EA1nh avatar SpriteRenderer (slot ph\u00F2ng ch\u1EDD coop/PVP)")]
	[SerializeField]
	[Tooltip("Canvas ri\u00EAng tr\u00EAn node badge (overrideSorting). Tr\u1ED1ng = kh\u00F4ng \u0111\u1EE5ng g\u00EC t\u1EDBi sorting.")]
	private Canvas sortingCanvas; // 0x38
	[SerializeField]
	[Tooltip("SpriteRenderer avatar \u0111\u1EC3 b\u00E1m sorting layer/order. Tr\u1ED1ng = kh\u00F4ng \u0111\u1EE5ng g\u00EC t\u1EDBi sorting.")]
	private SpriteRenderer avatarRenderer; // 0x40
	private Button _button; // 0x48
	private Outline _outline; // 0x50
	private long _ownerUserId; // 0x58
	private UserWeaponDTO _cachedData; // 0x60
	private int _lastImageId; // 0x68
	private string _lastRarity; // 0x70
	private int _lastStar; // 0x78

	// Constructors
	public WeaponBadgeUI(); // 0x000000018081C760-0x000000018081C7C0

	// Methods
	private void Awake(); // 0x0000000180819F10-0x0000000180819F20
	private void AutoWire(); // 0x0000000180819F20-0x000000018081A6C0
	public void SetOwner(long userId); // 0x00000001803C6050-0x00000001803C6060
	public void SetFullData(UserWeaponDTO data); // 0x000000018081A6C0-0x000000018081A740
	public void SetData(int imageId, string rarity, int star = 0 /* Metadata: 0x005EFD4C */); // 0x000000018081A740-0x000000018081ACC0
	private void ApplySorting(); // 0x000000018081ACC0-0x000000018081AF70
	private void ApplyRarityOutline(string rarity); // 0x000000018081AF70-0x000000018081B3E0
	public void Hide(); // 0x000000018081B3E0-0x000000018081B540
	private void SetupClick(); // 0x000000018081B540-0x000000018081BC20
	private void OpenTooltip(); // 0x000000018081BC20-0x000000018081BD50
	public static WeaponBadgeUI FindUnder(Component avatarNode); // 0x000000018081BD50-0x000000018081C540
	private static WeaponBadgeUI Pick(Transform t); // 0x000000018081C540-0x000000018081C640
	public static void Apply(WeaponBadgeUI badge, int imageId, string rarity, int star = 0 /* Metadata: 0x005EFD4D */, long ownerUserId = 0 /* Metadata: 0x005EFD4E */); // 0x000000018081C640-0x000000018081C760
}

