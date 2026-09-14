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
public class CanDauVanHubButton : MonoBehaviour // TypeDefIndex: 410
{
	// Fields
	public const string NODE_NAME = "btnCanDauVan"; // Metadata: 0x005EDE9E
	public static readonly string[] TEMPLATE_NODES; // 0x00
	public const string FRAME_NAME = "nameFrame"; // Metadata: 0x005EDEAB
	public const string LABEL_NAME = "txt"; // Metadata: 0x005EDEB5
	public const string BADGE_NAME = "badgeTicket"; // Metadata: 0x005EDEB9
	public const string SOON_NAME = "txt_Soon"; // Metadata: 0x005EDEC5
	public const string LABEL_TEXT = "C\u00E2n \u0110\u1EA9u V\u00E2n"; // Metadata: 0x005EDECE
	public static readonly Vector2 SIZE; // 0x08
	private static readonly Vector2 FRAME_POS; // 0x10
	private static readonly Vector2 FRAME_SIZE; // 0x18
	private static readonly Vector2 LABEL_POS; // 0x20
	private static readonly Vector2 LABEL_SIZE; // 0x28
	private const int LABEL_FONT_SIZE = 23; // Metadata: 0x005EDEDF
	private static readonly Color LABEL_COLOR; // 0x30
	private static readonly Color LABEL_OUTLINE; // 0x40
	private static readonly Color FRAME_FALLBACK; // 0x50
	private const float BADGE_SIZE = 40f; // Metadata: 0x005EDEE0
	private static readonly Vector2 BADGE_POS; // 0x60
	private Image _icon; // 0x20
	private GameObject _dot; // 0x28
	private Image _dotImage; // 0x30
	private UnityEngine.UI.Text _soon; // 0x38
	private UnityEngine.UI.Text _label; // 0x40
	private float _lastPulseAt; // 0x48
	private int _pulseTweenId; // 0x4C
	private string _boundPrefix; // 0x50
	private bool _firstFetchDone; // 0x58

	// Constructors
	public CanDauVanHubButton(); // 0x00000001803426C0-0x0000000180342710
	static CanDauVanHubButton(); // 0x0000000180342710-0x00000001803429D0

	// Methods
	public static CanDauVanHubButton Ensure(MonoBehaviour hub); // 0x000000018033DDF0-0x000000018033E210
	private static CanDauVanHubButton FindExisting(); // 0x000000018033E210-0x000000018033E2B0
	private static RectTransform FindTemplate(); // 0x000000018033E2B0-0x000000018033E740
	private static Transform FallbackParent(MonoBehaviour hub); // 0x000000018033E740-0x000000018033E8F0
	private static CanDauVanHubButton Build(Transform parent, RectTransform template); // 0x000000018033E8F0-0x000000018033F210
	private static void Place(RectTransform rt, RectTransform template); // 0x000000018033F210-0x000000018033F9A0
	private static T TemplatePart<T>(RectTransform template, string childName)
		where T : Component;
	private static UnityEngine.UI.Text TemplateLabel(RectTransform template); // 0x000000018033F9A0-0x000000018033FE10
	private static void CopyRect(RectTransform dst, RectTransform src, Vector2 fallbackPos, Vector2 fallbackSize); // 0x000000018033FE10-0x0000000180340020
	private static void MakeFrame(RectTransform parent, RectTransform template); // 0x0000000180340020-0x0000000180340510
	private static UnityEngine.UI.Text MakeLabel(RectTransform parent, RectTransform template); // 0x0000000180340510-0x0000000180340FD0
	private static GameObject MakeDot(RectTransform parent); // 0x0000000180340FD0-0x0000000180341340
	private static UnityEngine.UI.Text MakeSoon(RectTransform parent); // 0x0000000180341340-0x0000000180341840
	private void OnEnable(); // 0x0000000180341840-0x0000000180341A20
	private void OnDisable(); // 0x0000000180341A20-0x0000000180341C50
	private void OpenPanel(); // 0x0000000180341C50-0x0000000180341CC0
	private void Render(); // 0x0000000180341CC0-0x0000000180342390
	private void BindIcon(CanDauVanTheme theme); // 0x0000000180342390-0x00000001803426C0
}

