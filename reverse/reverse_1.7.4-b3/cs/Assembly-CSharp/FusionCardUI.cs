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
public class FusionCardUI : MonoBehaviour // TypeDefIndex: 2303
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/CardFusion"; // Metadata: 0x005F0AA2
	public const string CARD_NODE = "cardFusion"; // Metadata: 0x005F0AB8
	private static readonly Vector2 CardSize; // 0x00
	[SerializeField]
	private Image imgGlow; // 0x20
	[SerializeField]
	private Image imgtCard; // 0x28
	[SerializeField]
	private Image imgFusionPet; // 0x30
	[SerializeField]
	private Image imgManaBadge; // 0x38
	[SerializeField]
	private UnityEngine.UI.Text txtMana; // 0x40
	[SerializeField]
	private UnityEngine.UI.Text txtLabel; // 0x48
	[SerializeField]
	private UnityEngine.UI.Text txtPity; // 0x50
	[SerializeField]
	private GameObject usedOverlay; // 0x58
	public const string PITY_NODE = "txtPity"; // Metadata: 0x005F0AC3
	private Button _btn; // 0x60
	private float _nextRefreshAt; // 0x68
	private float _nextGlowAt; // 0x6C
	private long _boundPetId; // 0x70
	private Color _manaTextBase; // 0x78
	private Color _manaBadgeBase; // 0x88
	private Color _petBase; // 0x98
	private Color _labelBase; // 0xA8
	private bool _baseCaptured; // 0xB8
	private const float DimUsable = 1f; // Metadata: 0x005F0ACB
	private const float DimLocked = 0.62f; // Metadata: 0x005F0ACF
	private const float DimUsed = 0.42f; // Metadata: 0x005F0AD3

	// Properties
	private static float GlowStepSeconds { get; } // 0x0000000180AECFA0-0x0000000180AECFF0 

	// Constructors
	public FusionCardUI(); // 0x0000000180AEF710-0x0000000180AEF780
	static FusionCardUI(); // 0x0000000180AEF780-0x0000000180AEF7D0

	// Methods
	public static GameObject Spawn(Transform parent, GameObject baseCardPrefab); // 0x0000000180AECFF0-0x0000000180AED460
	private void Awake(); // 0x0000000180AED460-0x0000000180AED500
	private void OnEnable(); // 0x0000000180AED500-0x0000000180AED510
	private void Update(); // 0x0000000180AED510-0x0000000180AED990
	private void RefreshState(); // 0x0000000180AED990-0x0000000180AEE810
	private void CaptureBaseColors(); // 0x0000000180AEE810-0x0000000180AEEB30
	private static Color Dimmed(Color baseColor, float factor); // 0x00000001803FBA70-0x00000001803FBAA0
	private void AutoFindRefs(); // 0x0000000180AEEB30-0x0000000180AEF450
	private Transform FindDeep(string nodeName); // 0x0000000180AEF450-0x0000000180AEF710
}

