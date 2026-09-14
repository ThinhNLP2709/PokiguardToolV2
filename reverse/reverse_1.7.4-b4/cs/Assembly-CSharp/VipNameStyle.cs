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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class VipNameStyle : MonoBehaviour // TypeDefIndex: 1486
{
	// Fields
	public const string NODE_PLATE = "vipNamePlate"; // Metadata: 0x005F0FDD
	private const int SETTLE_FRAMES = 2; // Metadata: 0x005F0FEA
	private UnityEngine.UI.Text _label; // 0x20
	private TMP_Text _tmp; // 0x28
	private Image _plate; // 0x30
	private RectTransform _plateRt; // 0x38
	private Canvas _plateCanvas; // 0x40
	private const float PLATE_PUSH = 0.01f; // Metadata: 0x005F0FEB
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
	private const string BAND_REF = "N\u1EC5\u1ED3gyj"; // Metadata: 0x005F0FEF
	private const int BAND_REF_SIZE = 32; // Metadata: 0x005F0FFA

	// Properties
	public static Color PlateColor { get; } // 0x0000000180806BE0-0x0000000180806C70 
	public int Level { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180806C70-0x0000000180806C80 0x0000000180806C80-0x0000000180806C90
	public Image Plate { get; } // 0x00000001802B4AE0-0x00000001802B4AF0 
	private Transform LabelTransform { get; } // 0x000000018080C8E0-0x000000018080CA90 
	private RectTransform LabelRect { get; } // 0x000000018080CA90-0x000000018080CC40 
	private float FontSize { get; } // 0x000000018080CC40-0x000000018080CEA0 

	// Constructors
	public VipNameStyle(); // 0x000000018080E520-0x000000018080E580
	static VipNameStyle(); // 0x000000018080E580-0x000000018080E6D0

	// Methods
	public static Color TextColor(int level); // 0x0000000180806B30-0x0000000180806BE0
	public static VipNameStyle Find(UnityEngine.UI.Text label); // 0x0000000180806C90-0x0000000180806D90
	public static VipNameStyle Find(TMP_Text label); // 0x0000000180806D90-0x0000000180806E90
	public static VipNameStyle Apply(UnityEngine.UI.Text label, int level); // 0x0000000180806E90-0x0000000180807210
	public static VipNameStyle Apply(TMP_Text label, int level); // 0x0000000180807210-0x0000000180807590
	public static void Detach(UnityEngine.UI.Text label); // 0x0000000180807590-0x00000001808076E0
	public static void Detach(TMP_Text label); // 0x00000001808076E0-0x0000000180807830
	private static bool Wanted(int level); // 0x0000000180807830-0x00000001808078B0
	private void ApplyInternal(int level); // 0x00000001808078B0-0x0000000180807AD0
	private void Clear(); // 0x0000000180807AD0-0x0000000180807C00
	private void DarkenEffects(); // 0x0000000180807C00-0x0000000180808010
	private void RestoreEffects(); // 0x0000000180808010-0x0000000180808390
	private static Color DarkOf(Color original); // 0x0000000180808390-0x00000001808083B0
	private void CaptureOriginalColor(); // 0x00000001808083B0-0x0000000180808460
	private Color CurrentColor(); // 0x0000000180808460-0x0000000180808630
	private void SetColor(Color c); // 0x0000000180808630-0x00000001808087F0
	private void RestoreColor(); // 0x00000001808087F0-0x00000001808088A0
	private void EnsurePlate(); // 0x00000001808088A0-0x00000001808091E0
	private void SyncPlateCanvas(); // 0x00000001808091E0-0x0000000180809780
	private void PushPlateBehindText(RectTransform lrt); // 0x0000000180809780-0x0000000180809FA0
	private void KeepBehindLabel(); // 0x0000000180809FA0-0x000000018080A310
	private void DestroyPlate(); // 0x000000018080A310-0x000000018080A540
	private bool LabelShowing(); // 0x000000018080A540-0x000000018080A7F0
	public void Relayout(); // 0x000000018080A7F0-0x000000018080B480
	private bool MeasureInk(out Rect ink, out float fs); // 0x000000018080B480-0x000000018080BC20
	private static bool BandOf(Font font, out Vector3 k); // 0x000000018080BC20-0x000000018080C330
	private bool MeasureTmp(out Rect ink, out float fs); // 0x000000018080C330-0x000000018080C660
	private void EstimateInk(out Rect ink, out float fs); // 0x000000018080C660-0x000000018080C8E0
	private float TextWidth(float fs); // 0x000000018080CEA0-0x000000018080D2A0
	private float HorizontalCenter(Rect r, float textW); // 0x000000018080D2A0-0x000000018080D570
	private float VerticalCenter(Rect r, float fs); // 0x000000018080D570-0x000000018080D810
	private new void MarkDirty(); // 0x000000018080D810-0x000000018080D890
	private void LateUpdate(); // 0x000000018080D890-0x000000018080DFB0
	private void OnEnable(); // 0x000000018080DFB0-0x000000018080E120
	private void OnDisable(); // 0x000000018080E120-0x000000018080E260
	private void OnTransformParentChanged(); // 0x000000018080E260-0x000000018080E510
	private void OnDestroy(); // 0x000000018080E510-0x000000018080E520
}

