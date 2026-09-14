/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[AddComponentMenu("Pokiguard/Remote Style Binding")]
[DisallowMultipleComponent]
public class RemoteStyleBinding : MonoBehaviour // TypeDefIndex: 1407
{
	// Fields
	[Tooltip("Kho\u00E1 duy nh\u1EA5t to\u00E0n game, v\u00ED d\u1EE5 \'hub.btnShop\'. Ph\u1EA3i kh\u1EDBp c\u1ED9t ui_key tr\u00EAn web admin.\n\u0110\u1EB7t theo quy \u01B0\u1EDBc <m\u00E0n h\u00ECnh>.<t\u00EAn ph\u1EA7n t\u1EED> \u0111\u1EC3 tra c\u1EE9u d\u1EC5.")]
	public string key; // 0x20
	[Tooltip("B\u1ECF tr\u1ED1ng = t\u1EF1 t\u00ECm tr\u00EAn ch\u00EDnh GameObject n\u00E0y. Ch\u1EC9 g\u00E1n tay khi mu\u1ED1n \u0111\u1ED5i Text/Image c\u1EE7a node kh\u00E1c.")]
	public Graphic targetGraphic; // 0x28
	private UnityEngine.UI.Text _text; // 0x30
	private Image _image; // 0x38
	private Selectable _selectable; // 0x40
	private RectTransform _rect; // 0x48
	private string _baseText; // 0x50
	private Color _baseColor; // 0x58
	private int _baseFontSize; // 0x68
	private Sprite _baseSprite; // 0x70
	private Vector2 _basePos; // 0x78
	private Vector2 _baseSize; // 0x80
	private Vector3 _baseScale; // 0x88
	private bool _baseActive; // 0x94
	private bool _baseInteractable; // 0x95
	private bool _captured; // 0x96
	private string _defaultSpritePath; // 0x98

	// Constructors
	public RemoteStyleBinding(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Awake(); // 0x0000000180792A20-0x0000000180792A80
	private void OnEnable(); // 0x0000000180792A80-0x0000000180792A90
	private void OnDestroy(); // 0x0000000180792A90-0x0000000180792BA0
	private void CaptureBaseline(); // 0x0000000180792BA0-0x0000000180793700
	public void Apply(); // 0x0000000180793700-0x0000000180793A40
	private void ApplyText(); // 0x0000000180793A40-0x0000000180793C10
	private void ApplyColor(); // 0x0000000180793C10-0x0000000180793DC0
	private void ApplyFontSize(); // 0x0000000180793DC0-0x0000000180794030
	private void ApplySprite(); // 0x0000000180794030-0x0000000180794240
	public void SetDefaultSprite(string resourcePath); // 0x0000000180794240-0x00000001807942D0
	private void ApplyPos(); // 0x00000001807942D0-0x0000000180794610
	private void ApplySize(); // 0x0000000180794610-0x0000000180794950
	private void ApplyScale(); // 0x0000000180794950-0x0000000180794D10
	private void ApplyInteractable(); // 0x0000000180794D10-0x0000000180794EE0
	private void ApplyActive(); // 0x0000000180794EE0-0x00000001807950C0
	private static bool TryParseVector2(string s, out Vector2 result); // 0x00000001807950C0-0x00000001807952E0
	private static bool TryParseScale(string s, out Vector3 result); // 0x00000001807952E0-0x00000001807955F0
}

