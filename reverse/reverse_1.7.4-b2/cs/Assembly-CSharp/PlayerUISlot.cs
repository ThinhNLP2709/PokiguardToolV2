/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class PlayerUISlot : MonoBehaviour // TypeDefIndex: 56
{
	// Fields
	[Header("UI References \u2014 g\u00E1n s\u1EB5n, t\u1EF1 t\u00ECm khi null")]
	[SerializeField]
	private SpriteRenderer sprAvatar; // 0x20
	[SerializeField]
	private Image imgLevelFrame; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtLevel; // 0x30
	[SerializeField]
	private UnityEngine.UI.Text txtUserName; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text txtEnergyUI; // 0x40
	[SerializeField]
	private UnityEngine.UI.Text txtPassUI; // 0x48
	[SerializeField]
	private UnityEngine.UI.Text txtSansang; // 0x50
	[SerializeField]
	internal SpriteRenderer imgSlotPet; // 0x58
	public Button btnKick; // 0x60
	public Image LeaderStar; // 0x68
	[SerializeField]
	private WeaponBadgeUI weaponBadge; // 0x70
	[Header("Voice Chat (\u0111\u00E3 g\u1EE1 voice \u2014 4 n\u00FAt lu\u00F4n \u1EA9n, gi\u1EEF ref Inspector)")]
	public Button btnmic; // 0x78
	public Button btnoffmic; // 0x80
	public Button btnloa; // 0x88
	public Button btnoffloa; // 0x90
	[Header("Pet Animation")]
	[SerializeField]
	public Animator petAnimator; // 0x98
	[Header("Selected Cards Container")]
	[SerializeField]
	public Transform cardsContainer; // 0xA0
	[Header("Default Sprites")]
	public Sprite defAvt; // 0xA8
	internal PlayerUIModel usersInfo; // 0xB0
	private bool showDebugGUI; // 0xB8
	internal int actorNumber; // 0xBC
	private Color _sansangColorDefault; // 0xC0
	private bool _sansangColorCaptured; // 0xD0
	private const int IDX_AVATAR = 0; // Metadata: 0x0068AA62
	private const int IDX_LEVEL_FRAME = 1; // Metadata: 0x0068AA63
	private const int IDX_USERNAME = 2; // Metadata: 0x0068AA64
	private const int IDX_ENERGY = 3; // Metadata: 0x0068AA65
	private const int IDX_PASS_COUNT = 4; // Metadata: 0x0068AA66
	private const int IDX_PET = 5; // Metadata: 0x0068AA67
	private const int IDX_CARDS = 6; // Metadata: 0x0068AA68
	private int _petAnimToken; // 0xD4
	private string _petAnimLoadingId; // 0xD8
	private string _lastAppliedPetId; // 0xE0
	private RuntimeAnimatorController _lastAppliedController; // 0xE8

	// Properties
	internal SpriteRenderer AvatarRenderer { get; } // 0x00000001802FF660-0x00000001802FF670 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass34_0 // TypeDefIndex: 57
	{
		// Fields
		public string capturedKickName; // 0x10

		// Constructors
		public __c__DisplayClass34_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SetData_b__0(); // 0x0000000180425F00-0x0000000180425F60
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass42_0 // TypeDefIndex: 58
	{
		// Fields
		public PlayerUISlot __4__this; // 0x10
		public int token; // 0x18
		public string petId; // 0x20

		// Constructors
		public __c__DisplayClass42_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _ReplacePetAnimations_b__0(AnimationClip[] clips); // 0x0000000180425F60-0x0000000180426020
	}

	// Constructors
	public PlayerUISlot(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Awake(); // 0x000000018030E660-0x000000018030E690
	private void AutoFillMissingRefs(); // 0x000000018030DCF0-0x000000018030E660
	public void SetData(PlayerUIModel model, int petId = -1 /* Metadata: 0x0068AA61 */); // 0x000000018030F060-0x000000018030FA70
	private void RenderSelectedCards(int[] cardIds); // 0x000000018030E940-0x000000018030EC80
	private void SetEmpty(); // 0x000000018030FA70-0x00000001803101A0
	private static int SafePetId(string petId); // 0x000000018030F030-0x000000018030F060
	public void ReplacePetAnimations(string petId); // 0x000000018030EC80-0x000000018030F030
	private void ClearPetAnimMemo(); // 0x000000018030E690-0x000000018030E6F0
	private void ApplyPetClips(string petId, AnimationClip[] clips); // 0x000000018030DA50-0x000000018030DCF0
	private Button FindChildButton(string name); // 0x000000018030E6F0-0x000000018030E7F0
	private void HideAllVoiceButtons(); // 0x000000018030E7F0-0x000000018030E940
}

