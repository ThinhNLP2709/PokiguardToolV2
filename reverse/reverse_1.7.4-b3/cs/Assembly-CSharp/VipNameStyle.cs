/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class VipNameStyle : MonoBehaviour // TypeDefIndex: 1484
{
	// Fields
	public const string NODE_PLATE = "vipNamePlate"; // Metadata: 0x005EFC10
	private const int SETTLE_FRAMES = 2; // Metadata: 0x005EFC1D
	private UnityEngine.UI.Text _label; // 0x20
	private TMP_Text _tmp; // 0x28
	private Image _plate; // 0x30
	private RectTransform _plateRt; // 0x38
	private Canvas _plateCanvas; // 0x40
	private const float PLATE_PUSH = 0.01f; // Metadata: 0x005EFC1E
	private bool _colorSaved; // 0x48
	private Color _origColor; // 0x4C
	private Color _appliedColor; // 0x5C
	private Shadow[] _fx; // 0x70
	private Color[] _fxOrig; // 0x78
	private string _lastText; // 0x80
	private float _lastFontSize; // 0x88
	private Vector2 _lastSize; // 0x8C
	private Vector3 _lastPos; // 0x94
	private Vector3 _lastScale; // 0xA0
	private float _lastAlpha; // 0xAC
	private int _settle; // 0xB0
	[CompilerGenerated]
	private int _Level_k__BackingField; // 0xB4
	private static TextGenerator s_measure; // 0x00
	private static readonly Dictionary<Font, Vector3> s_band; // 0x08
	private const string BAND_REF = "N\u1EC5\u1ED3gyj"; // Metadata: 0x005EFC22
	private const int BAND_REF_SIZE = 32; // Metadata: 0x005EFC2D

	// Properties
	public static Color PlateColor { get; } // 0x0000000180804AF0-0x0000000180804B80 
	public int Level { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180804B80-0x0000000180804B90 0x0000000180804B90-0x0000000180804BA0
	public Image Plate { get; } // 0x00000001802B4AE0-0x00000001802B4AF0 
	private Transform LabelTransform { get; } // 0x000000018080A7F0-0x000000018080A9A0 
	private RectTransform LabelRect { get; } // 0x000000018080A9A0-0x000000018080AB50 
	private float FontSize { get; } // 0x000000018080AB50-0x000000018080ADB0 

	// Constructors
	public VipNameStyle(); // 0x000000018080C430-0x000000018080C490
	static VipNameStyle(); // 0x000000018080C490-0x000000018080C5E0

	// Methods
	public static Color TextColor(int level); // 0x0000000180804A40-0x0000000180804AF0
	public static VipNameStyle Find(UnityEngine.UI.Text label); // 0x0000000180804BA0-0x0000000180804CA0
	public static VipNameStyle Find(TMP_Text label); // 0x0000000180804CA0-0x0000000180804DA0
	public static VipNameStyle Apply(UnityEngine.UI.Text label, int level); // 0x0000000180804DA0-0x0000000180805120
	public static VipNameStyle Apply(TMP_Text label, int level); // 0x0000000180805120-0x00000001808054A0
	public static void Detach(UnityEngine.UI.Text label); // 0x00000001808054A0-0x00000001808055F0
	public static void Detach(TMP_Text label); // 0x00000001808055F0-0x0000000180805740
	private static bool Wanted(int level); // 0x0000000180805740-0x00000001808057C0
	private void ApplyInternal(int level); // 0x00000001808057C0-0x00000001808059E0
	private void Clear(); // 0x00000001808059E0-0x0000000180805B10
	private void DarkenEffects(); // 0x0000000180805B10-0x0000000180805F20
	private void RestoreEffects(); // 0x0000000180805F20-0x00000001808062A0
	private static Color DarkOf(Color original); // 0x00000001808062A0-0x00000001808062C0
	private void CaptureOriginalColor(); // 0x00000001808062C0-0x0000000180806370
	private Color CurrentColor(); // 0x0000000180806370-0x0000000180806540
	private void SetColor(Color c); // 0x0000000180806540-0x0000000180806700
	private void RestoreColor(); // 0x0000000180806700-0x00000001808067B0
	private void EnsurePlate(); // 0x00000001808067B0-0x00000001808070F0
	private void SyncPlateCanvas(); // 0x00000001808070F0-0x0000000180807690
	private void PushPlateBehindText(RectTransform lrt); // 0x0000000180807690-0x0000000180807EB0
	private void KeepBehindLabel(); // 0x0000000180807EB0-0x0000000180808220
	private void DestroyPlate(); // 0x0000000180808220-0x0000000180808450
	private bool LabelShowing(); // 0x0000000180808450-0x0000000180808700
	public void Relayout(); // 0x0000000180808700-0x0000000180809390
	private bool MeasureInk(out Rect ink, out float fs); // 0x0000000180809390-0x0000000180809B30
	private static bool BandOf(Font font, out Vector3 k); // 0x0000000180809B30-0x000000018080A240
	private bool MeasureTmp(out Rect ink, out float fs); // 0x000000018080A240-0x000000018080A570
	private void EstimateInk(out Rect ink, out float fs); // 0x000000018080A570-0x000000018080A7F0
	private float TextWidth(float fs); // 0x000000018080ADB0-0x000000018080B1B0
	private float HorizontalCenter(Rect r, float textW); // 0x000000018080B1B0-0x000000018080B480
	private float VerticalCenter(Rect r, float fs); // 0x000000018080B480-0x000000018080B720
	private new void MarkDirty(); // 0x000000018080B720-0x000000018080B7A0
	private void LateUpdate(); // 0x000000018080B7A0-0x000000018080BEC0
	private void OnEnable(); // 0x000000018080BEC0-0x000000018080C030
	private void OnDisable(); // 0x000000018080C030-0x000000018080C170
	private void OnTransformParentChanged(); // 0x000000018080C170-0x000000018080C420
	private void OnDestroy(); // 0x000000018080C420-0x000000018080C430
}

