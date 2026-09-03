/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class FusionCardUI : MonoBehaviour // TypeDefIndex: 1664
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/CardFusion"; // Metadata: 0x0064D855
	public const string CARD_NODE = "cardFusion"; // Metadata: 0x0064D86B
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
	private GameObject usedOverlay; // 0x50
	private Button _btn; // 0x58
	private float _nextRefreshAt; // 0x60
	private long _boundPetId; // 0x68
	private Color _manaTextBase; // 0x70
	private Color _manaBadgeBase; // 0x80
	private Color _petBase; // 0x90
	private Color _labelBase; // 0xA0
	private bool _baseCaptured; // 0xB0
	private const float DimUsable = 1f; // Metadata: 0x0064D876
	private const float DimLocked = 0.62f; // Metadata: 0x0064D87A
	private const float DimUsed = 0.42f; // Metadata: 0x0064D87E

	// Constructors
	public FusionCardUI(); // 0x00000001805CBB90-0x00000001805CBBC0
	static FusionCardUI(); // 0x00000001805CBB50-0x00000001805CBB90

	// Methods
	public static GameObject Spawn(Transform parent, GameObject baseCardPrefab); // 0x00000001805CB750-0x00000001805CB940
	private void Awake(); // 0x00000001805CAC00-0x00000001805CAC60
	private void OnEnable(); // 0x00000001805CAF30-0x00000001805CAF40
	private void Update(); // 0x00000001805CB940-0x00000001805CBB50
	private void RefreshState(); // 0x00000001805CAF40-0x00000001805CB750
	private void CaptureBaseColors(); // 0x00000001805CAC60-0x00000001805CADC0
	private static Color Dimmed(Color baseColor, float factor); // 0x0000000180351740-0x0000000180351770
	private void AutoFindRefs(); // 0x00000001805CA930-0x00000001805CAC00
	private Transform FindDeep(string nodeName); // 0x00000001805CADC0-0x00000001805CAF30
}

