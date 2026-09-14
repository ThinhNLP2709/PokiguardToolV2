/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class CanDauVanHubButton : MonoBehaviour // TypeDefIndex: 410
{
	// Fields
	public const string NODE_NAME = "btnCanDauVan"; // Metadata: 0x005EF26E
	public static readonly string[] TEMPLATE_NODES; // 0x00
	public const string FRAME_NAME = "nameFrame"; // Metadata: 0x005EF27B
	public const string LABEL_NAME = "txt"; // Metadata: 0x005EF285
	public const string BADGE_NAME = "badgeTicket"; // Metadata: 0x005EF289
	public const string SOON_NAME = "txt_Soon"; // Metadata: 0x005EF295
	public const string LABEL_TEXT = "C\u00E2n \u0110\u1EA9u V\u00E2n"; // Metadata: 0x005EF29E
	public static readonly Vector2 SIZE; // 0x08
	private static readonly Vector2 FRAME_POS; // 0x10
	private static readonly Vector2 FRAME_SIZE; // 0x18
	private static readonly Vector2 LABEL_POS; // 0x20
	private static readonly Vector2 LABEL_SIZE; // 0x28
	private const int LABEL_FONT_SIZE = 23; // Metadata: 0x005EF2AF
	private static readonly Color LABEL_COLOR; // 0x30
	private static readonly Color LABEL_OUTLINE; // 0x40
	private static readonly Color FRAME_FALLBACK; // 0x50
	private const float BADGE_SIZE = 40f; // Metadata: 0x005EF2B0
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
	public CanDauVanHubButton(); // 0x00000001803427E0-0x0000000180342830
	static CanDauVanHubButton(); // 0x0000000180342830-0x0000000180342AF0

	// Methods
	public static CanDauVanHubButton Ensure(MonoBehaviour hub); // 0x000000018033DF10-0x000000018033E330
	private static CanDauVanHubButton FindExisting(); // 0x000000018033E330-0x000000018033E3D0
	private static RectTransform FindTemplate(); // 0x000000018033E3D0-0x000000018033E860
	private static Transform FallbackParent(MonoBehaviour hub); // 0x000000018033E860-0x000000018033EA10
	private static CanDauVanHubButton Build(Transform parent, RectTransform template); // 0x000000018033EA10-0x000000018033F330
	private static void Place(RectTransform rt, RectTransform template); // 0x000000018033F330-0x000000018033FAC0
	private static T TemplatePart<T>(RectTransform template, string childName)
		where T : Component;
	private static UnityEngine.UI.Text TemplateLabel(RectTransform template); // 0x000000018033FAC0-0x000000018033FF30
	private static void CopyRect(RectTransform dst, RectTransform src, Vector2 fallbackPos, Vector2 fallbackSize); // 0x000000018033FF30-0x0000000180340140
	private static void MakeFrame(RectTransform parent, RectTransform template); // 0x0000000180340140-0x0000000180340630
	private static UnityEngine.UI.Text MakeLabel(RectTransform parent, RectTransform template); // 0x0000000180340630-0x00000001803410F0
	private static GameObject MakeDot(RectTransform parent); // 0x00000001803410F0-0x0000000180341460
	private static UnityEngine.UI.Text MakeSoon(RectTransform parent); // 0x0000000180341460-0x0000000180341960
	private void OnEnable(); // 0x0000000180341960-0x0000000180341B40
	private void OnDisable(); // 0x0000000180341B40-0x0000000180341D70
	private void OpenPanel(); // 0x0000000180341D70-0x0000000180341DE0
	private void Render(); // 0x0000000180341DE0-0x00000001803424B0
	private void BindIcon(CanDauVanTheme theme); // 0x00000001803424B0-0x00000001803427E0
}

