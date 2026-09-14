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
public class ThanhTuuHubButton : MonoBehaviour, IHubSuspendable // TypeDefIndex: 1271
{
	// Fields
	public const string NODE_NAME = "btnThanhTuu"; // Metadata: 0x005F0A13
	public const string ANCHOR_NODE = "btnShopAvt"; // Metadata: 0x005F0A1F
	public static readonly string[] LABEL_TEMPLATES; // 0x00
	public const string ICON_NAME = "icon"; // Metadata: 0x005F0A2A
	public const string LABEL_NAME = "txt"; // Metadata: 0x005F0A2F
	public const string BADGE_NAME = "badge"; // Metadata: 0x005F0A33
	public const string LABEL_TEXT = "Th\u00E0nh T\u1EF1u"; // Metadata: 0x005F0A39
	public static readonly Vector2 SIZE; // 0x08
	public const float RESUME_REFETCH_DELAY = 1.5f; // Metadata: 0x005F0A46
	private const float DEFER_DELAY = 0.01f; // Metadata: 0x005F0A4A
	private static readonly Vector2 LABEL_POS; // 0x10
	private static readonly Vector2 LABEL_SIZE; // 0x18
	private const float BADGE_SIZE = 34f; // Metadata: 0x005F0A4E
	private static readonly Vector2 BADGE_POS; // 0x20
	private const int LABEL_FONT_SIZE = 23; // Metadata: 0x005F0A52
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
	public ThanhTuuHubButton(); // 0x0000000180718990-0x00000001807189F0
	static ThanhTuuHubButton(); // 0x00000001807189F0-0x0000000180718C00

	// Methods
	public static ThanhTuuHubButton Ensure(MonoBehaviour hub); // 0x0000000180712CC0-0x0000000180713190
	private static ThanhTuuHubButton FindExisting(); // 0x0000000180713190-0x0000000180713220
	private static RectTransform FindAnchor(MonoBehaviour hub); // 0x0000000180713220-0x0000000180713D50
	private static Transform RootCanvasOf(MonoBehaviour hub); // 0x0000000180713D50-0x0000000180713FA0
	private static RectTransform FindButtonDeep(Transform root, string nodeName); // 0x0000000180713FA0-0x00000001807143D0
	private static void StripLegacyGate(ThanhTuuHubButton b); // 0x00000001807143D0-0x0000000180714590
	private static ThanhTuuHubButton Build(Transform parent, RectTransform anchor); // 0x0000000180714590-0x0000000180714C60
	private static void Place(RectTransform rt, RectTransform anchor); // 0x0000000180714C60-0x0000000180715650
	private static bool IsNarrowScreen(); // 0x0000000180715650-0x0000000180715710
	private static void SetLayer(Transform t, int layer); // 0x0000000180715710-0x0000000180715910
	private static Image MakeIcon(RectTransform parent); // 0x0000000180715910-0x0000000180715CE0
	private static UnityEngine.UI.Text TemplateLabel(Transform scope); // 0x0000000180715CE0-0x00000001807162A0
	private static UnityEngine.UI.Text MakeLabel(RectTransform parent, Transform scope); // 0x00000001807162A0-0x0000000180716FA0
	private static GameObject MakeBadge(RectTransform parent); // 0x0000000180716FA0-0x0000000180717310
	private void Awake(); // 0x0000000180717310-0x0000000180717540
	private void OnDestroy(); // 0x0000000180717540-0x00000001807177B0
	private void OnEnable(); // 0x00000001807177B0-0x0000000180717870
	private void OnDisable(); // 0x0000000180717870-0x0000000180717980
	public void OnHubSuspend(); // 0x0000000180717980-0x00000001807179E0
	public void OnHubResume(); // 0x00000001807179E0-0x0000000180717B50
	private void OnResumeRefetch(); // 0x0000000180717B50-0x0000000180717D10
	private static void CancelTween(ref int id); // 0x0000000180717D10-0x0000000180717DC0
	private void OnClick(); // 0x0000000180717DC0-0x0000000180717E30
	private static bool FlagOn(); // 0x0000000180717E30-0x0000000180717EA0
	private void Render(); // 0x0000000180717EA0-0x00000001807181F0
	private void DeferRender(); // 0x00000001807181F0-0x00000001807182D0
	private void OnDeferredRender(); // 0x00000001807182D0-0x00000001807183C0
	private void SetBadge(bool want); // 0x00000001807183C0-0x0000000180718660
	private void BindArt(); // 0x0000000180718660-0x0000000180718990
}

