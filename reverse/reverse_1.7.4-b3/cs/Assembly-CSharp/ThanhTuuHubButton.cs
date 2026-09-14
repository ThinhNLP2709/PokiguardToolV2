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
public class ThanhTuuHubButton : MonoBehaviour, IHubSuspendable // TypeDefIndex: 1269
{
	// Fields
	public const string NODE_NAME = "btnThanhTuu"; // Metadata: 0x005EF646
	public const string ANCHOR_NODE = "btnShopAvt"; // Metadata: 0x005EF652
	public static readonly string[] LABEL_TEMPLATES; // 0x00
	public const string ICON_NAME = "icon"; // Metadata: 0x005EF65D
	public const string LABEL_NAME = "txt"; // Metadata: 0x005EF662
	public const string BADGE_NAME = "badge"; // Metadata: 0x005EF666
	public const string LABEL_TEXT = "Th\u00E0nh T\u1EF1u"; // Metadata: 0x005EF66C
	public static readonly Vector2 SIZE; // 0x08
	public const float RESUME_REFETCH_DELAY = 1.5f; // Metadata: 0x005EF679
	private const float DEFER_DELAY = 0.01f; // Metadata: 0x005EF67D
	private static readonly Vector2 LABEL_POS; // 0x10
	private static readonly Vector2 LABEL_SIZE; // 0x18
	private const float BADGE_SIZE = 34f; // Metadata: 0x005EF681
	private static readonly Vector2 BADGE_POS; // 0x20
	private const int LABEL_FONT_SIZE = 23; // Metadata: 0x005EF685
	private static readonly Color LABEL_COLOR; // 0x28
	private static readonly Color LABEL_OUTLINE; // 0x38
	private static bool _warnedNoAnchor; // 0x48
	private Image _icon; // 0x20
	private GameObject _badge; // 0x28
	private Image _badgeImage; // 0x30
	private UnityEngine.UI.Text _label; // 0x38
	private float _lastPulseAt; // 0x40
	private int _pulseTweenId; // 0x44
	private string _boundPrefix; // 0x48
	private bool _subscribed; // 0x50
	private bool _activating; // 0x51
	private int _deferId; // 0x54
	private int _resumeId; // 0x58

	// Constructors
	public ThanhTuuHubButton(); // 0x0000000180716BE0-0x0000000180716C40
	static ThanhTuuHubButton(); // 0x0000000180716C40-0x0000000180716E50

	// Methods
	public static ThanhTuuHubButton Ensure(MonoBehaviour hub); // 0x0000000180710F10-0x00000001807113E0
	private static ThanhTuuHubButton FindExisting(); // 0x00000001807113E0-0x0000000180711470
	private static RectTransform FindAnchor(MonoBehaviour hub); // 0x0000000180711470-0x0000000180711FA0
	private static Transform RootCanvasOf(MonoBehaviour hub); // 0x0000000180711FA0-0x00000001807121F0
	private static RectTransform FindButtonDeep(Transform root, string nodeName); // 0x00000001807121F0-0x0000000180712620
	private static void StripLegacyGate(ThanhTuuHubButton b); // 0x0000000180712620-0x00000001807127E0
	private static ThanhTuuHubButton Build(Transform parent, RectTransform anchor); // 0x00000001807127E0-0x0000000180712EB0
	private static void Place(RectTransform rt, RectTransform anchor); // 0x0000000180712EB0-0x00000001807138A0
	private static bool IsNarrowScreen(); // 0x00000001807138A0-0x0000000180713960
	private static void SetLayer(Transform t, int layer); // 0x0000000180713960-0x0000000180713B60
	private static Image MakeIcon(RectTransform parent); // 0x0000000180713B60-0x0000000180713F30
	private static UnityEngine.UI.Text TemplateLabel(Transform scope); // 0x0000000180713F30-0x00000001807144F0
	private static UnityEngine.UI.Text MakeLabel(RectTransform parent, Transform scope); // 0x00000001807144F0-0x00000001807151F0
	private static GameObject MakeBadge(RectTransform parent); // 0x00000001807151F0-0x0000000180715560
	private void Awake(); // 0x0000000180715560-0x0000000180715790
	private void OnDestroy(); // 0x0000000180715790-0x0000000180715A00
	private void OnEnable(); // 0x0000000180715A00-0x0000000180715AC0
	private void OnDisable(); // 0x0000000180715AC0-0x0000000180715BD0
	public void OnHubSuspend(); // 0x0000000180715BD0-0x0000000180715C30
	public void OnHubResume(); // 0x0000000180715C30-0x0000000180715DA0
	private void OnResumeRefetch(); // 0x0000000180715DA0-0x0000000180715F60
	private static void CancelTween(ref int id); // 0x0000000180715F60-0x0000000180716010
	private void OnClick(); // 0x0000000180716010-0x0000000180716080
	private static bool FlagOn(); // 0x0000000180716080-0x00000001807160F0
	private void Render(); // 0x00000001807160F0-0x0000000180716440
	private void DeferRender(); // 0x0000000180716440-0x0000000180716520
	private void OnDeferredRender(); // 0x0000000180716520-0x0000000180716610
	private void SetBadge(bool want); // 0x0000000180716610-0x00000001807168B0
	private void BindArt(); // 0x00000001807168B0-0x0000000180716BE0
}

