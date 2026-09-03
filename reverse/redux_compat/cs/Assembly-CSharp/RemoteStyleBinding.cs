/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[AddComponentMenu("Pokiguard/Remote Style Binding")]
[DisallowMultipleComponent]
public class RemoteStyleBinding : MonoBehaviour // TypeDefIndex: 833
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

	// Constructors
	public RemoteStyleBinding(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Awake(); // 0x000000018042D990-0x000000018042D9F0
	private void OnEnable(); // 0x000000018042DF60-0x000000018042DF70
	private void OnDestroy(); // 0x000000018042DEA0-0x000000018042DF60
	private void CaptureBaseline(); // 0x000000018042D9F0-0x000000018042DEA0
	public void Apply(); // 0x000000018042D2D0-0x000000018042D990
	private void ApplyText(); // 0x000000018042D1A0-0x000000018042D2D0
	private void ApplyColor(); // 0x000000018042C700-0x000000018042C820
	private void ApplyFontSize(); // 0x000000018042C820-0x000000018042C940
	private void ApplySprite(); // 0x000000018042D070-0x000000018042D1A0
	private void ApplyPos(); // 0x000000018042CA50-0x000000018042CC40
	private void ApplySize(); // 0x000000018042CE80-0x000000018042D070
	private void ApplyScale(); // 0x000000018042CC40-0x000000018042CE80
	private void ApplyInteractable(); // 0x000000018042C940-0x000000018042CA50
	private void ApplyActive(); // 0x000000018042C610-0x000000018042C700
	private static bool TryParseVector2(string s, out Vector2 result); // 0x000000018042E140-0x000000018042E290
	private static bool TryParseScale(string s, out Vector3 result); // 0x000000018042DF70-0x000000018042E140
}

