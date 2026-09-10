/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class FusionCardUI : MonoBehaviour // TypeDefIndex: 1937
{
	// Fields
	public const string PREFAB_PATH = "Prefabs/UI/CardFusion"; // Metadata: 0x0068DC84
	public const string CARD_NODE = "cardFusion"; // Metadata: 0x0068DC9A
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
	private float _nextGlowAt; // 0x64
	private long _boundPetId; // 0x68
	private Color _manaTextBase; // 0x70
	private Color _manaBadgeBase; // 0x80
	private Color _petBase; // 0x90
	private Color _labelBase; // 0xA0
	private bool _baseCaptured; // 0xB0
	private const float DimUsable = 1f; // Metadata: 0x0068DCA5
	private const float DimLocked = 0.62f; // Metadata: 0x0068DCA9
	private const float DimUsed = 0.42f; // Metadata: 0x0068DCAD

	// Properties
	private static float GlowStepSeconds { get; } // 0x00000001806FD9C0-0x00000001806FDA50 

	// Constructors
	public FusionCardUI(); // 0x00000001806FD990-0x00000001806FD9C0
	static FusionCardUI(); // 0x00000001806FD950-0x00000001806FD990

	// Methods
	public static GameObject Spawn(Transform parent, GameObject baseCardPrefab); // 0x00000001806FD480-0x00000001806FD670
	private void Awake(); // 0x00000001806FC930-0x00000001806FC990
	private void OnEnable(); // 0x00000001806FCC60-0x00000001806FCC70
	private void Update(); // 0x00000001806FD670-0x00000001806FD950
	private void RefreshState(); // 0x00000001806FCC70-0x00000001806FD480
	private void CaptureBaseColors(); // 0x00000001806FC990-0x00000001806FCAF0
	private static Color Dimmed(Color baseColor, float factor); // 0x00000001803B3530-0x00000001803B3560
	private void AutoFindRefs(); // 0x00000001806FC660-0x00000001806FC930
	private Transform FindDeep(string nodeName); // 0x00000001806FCAF0-0x00000001806FCC60
}

