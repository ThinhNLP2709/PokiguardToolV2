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
public class LoginHeroFx : MonoBehaviour // TypeDefIndex: 1070
{
	// Fields
	[CompilerGenerated]
	private static LoginHeroFx _Active_k__BackingField; // 0x00
	private const int SPARK_MAX = 20; // Metadata: 0x005F06CE
	private const int PUFF_MAX = 6; // Metadata: 0x005F06CF
	private const int RAY_MAX = 8; // Metadata: 0x005F06D0
	private const float CY = 18f; // Metadata: 0x005F06D1
	private const float RAY_W = 170f; // Metadata: 0x005F06D5
	private const float RAY_H = 340f; // Metadata: 0x005F06D9
	private const float RAY_DY = -10f; // Metadata: 0x005F06DD
	private const float RAY_SPIN = 0.018f; // Metadata: 0x005F06E1
	private const float RAY_A_MIN = 0.09f; // Metadata: 0x005F06E5
	private const float RAY_A_MAX = 0.18f; // Metadata: 0x005F06E9
	private const float RAY_PERIOD = 5.5f; // Metadata: 0x005F06ED
	private const float AURA_SIZE = 430f; // Metadata: 0x005F06F1
	private const float AURA_DY = 6f; // Metadata: 0x005F06F5
	private const float AURA_PERIOD = 4.2f; // Metadata: 0x005F06F9
	private const float AURA_A_MIN = 0.1f; // Metadata: 0x005F06FD
	private const float AURA_A_MAX = 0.24f; // Metadata: 0x005F0701
	private const float HALO_SIZE = 210f; // Metadata: 0x005F0705
	private const float HALO_DY = 92f; // Metadata: 0x005F0709
	private const float HALO_PERIOD = 3.1f; // Metadata: 0x005F070D
	private const float HALO_A_MIN = 0.06f; // Metadata: 0x005F0711
	private const float HALO_A_MAX = 0.18f; // Metadata: 0x005F0715
	private const float AURA_PUMP = 0.05f; // Metadata: 0x005F0719
	private const float BOB_AMP = 6f; // Metadata: 0x005F071D
	private const float BOB_PERIOD = 2.4f; // Metadata: 0x005F0721
	private const float SPARK_RX_MIN = 135f; // Metadata: 0x005F0725
	private const float SPARK_RX_MAX = 240f; // Metadata: 0x005F0729
	private const float SPARK_RY_MIN = 105f; // Metadata: 0x005F072D
	private const float SPARK_RY_MAX = 215f; // Metadata: 0x005F0731
	private const float SPARK_SIZE_MIN = 14f; // Metadata: 0x005F0735
	private const float SPARK_SIZE_MAX = 34f; // Metadata: 0x005F0739
	private const float SPARK_SPD_MIN = 0.16f; // Metadata: 0x005F073D
	private const float SPARK_SPD_MAX = 0.42f; // Metadata: 0x005F0741
	private const float SPARK_TW_MIN = 0.5f; // Metadata: 0x005F0745
	private const float SPARK_TW_MAX = 1.4f; // Metadata: 0x005F0749
	private const float SPARK_A_MIN = 0.55f; // Metadata: 0x005F074D
	private const float SPARK_A_MAX = 1f; // Metadata: 0x005F0751
	private const float SPARK_TILT = 20f; // Metadata: 0x005F0755
	private const float PUFF_W_MIN = 46f; // Metadata: 0x005F0759
	private const float PUFF_W_MAX = 96f; // Metadata: 0x005F075D
	private const float PUFF_SPD_MIN = 7f; // Metadata: 0x005F0761
	private const float PUFF_SPD_MAX = 17f; // Metadata: 0x005F0765
	private const float PUFF_A_MIN = 0.28f; // Metadata: 0x005F0769
	private const float PUFF_A_MAX = 0.46f; // Metadata: 0x005F076D
	private static readonly Color PUFF_TINT; // 0x08
	private const float PUFF_Y_LOW = -0.88f; // Metadata: 0x005F0771
	private const float PUFF_Y_HIGH = -0.12f; // Metadata: 0x005F0775
	private const float PUFF_ASPECT = 0.796875f; // Metadata: 0x005F0779
	private const float ALPHA_EPS = 0.01f; // Metadata: 0x005F077D
	private RectTransform _back; // 0x20
	private RectTransform _front; // 0x28
	private RectTransform _rayRoot; // 0x30
	private Image[] _rays; // 0x38
	private float[] _rayPhase; // 0x40
	private float[] _rayLastA; // 0x48
	private Image _aura; // 0x50
	private Image _halo; // 0x58
	private RectTransform _auraRt; // 0x60
	private RectTransform _haloRt; // 0x68
	private float _auraLastA; // 0x70
	private float _haloLastA; // 0x74
	private Spark[] _sparks; // 0x78
	private Puff[] _puffs; // 0x80
	private int _sparkOn; // 0x88
	private Sprite _dot; // 0x90
	private bool _dotOwned; // 0x98
	private float _halfW; // 0x9C
	private float _halfH; // 0xA0
	private bool _built; // 0xA4
	private bool _paused; // 0xA5
	private bool _low; // 0xA6

	// Properties
	public static LoginHeroFx Active { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018065F710-0x000000018065F770 0x000000018065F770-0x000000018065F820
	public bool Built { get; } // 0x00000001803C6F40-0x00000001803C6F50 
	public int PartCount { get; } // 0x000000018065F820-0x000000018065FA00 

	// Nested types
	private struct Spark // TypeDefIndex: 1071
	{
		// Fields
		public RectTransform rt; // 0x00
		public Image img; // 0x08
		public float rx; // 0x10
		public float ry; // 0x14
		public float spd; // 0x18
		public float phase; // 0x1C
		public float cosT; // 0x20
		public float sinT; // 0x24
		public float twSpd; // 0x28
		public float twPhase; // 0x2C
		public float baseA; // 0x30
		public Color color; // 0x34
		public float lastA; // 0x44
	}

	private struct Puff // TypeDefIndex: 1072
	{
		// Fields
		public RectTransform rt; // 0x00
		public float x; // 0x08
		public float y; // 0x0C
		public float w; // 0x10
		public float spd; // 0x14
		public float swayAmp; // 0x18
		public float swaySpd; // 0x1C
		public float phase; // 0x20
	}

	// Constructors
	public LoginHeroFx(); // 0x00000001806650B0-0x0000000180665350
	static LoginHeroFx(); // 0x0000000180665350-0x00000001806653A0

	// Methods
	public void Build(RectTransform back, RectTransform front); // 0x000000018065FA00-0x00000001806600E0
	private void BuildRays(int n); // 0x00000001806600E0-0x00000001806611B0
	private void BuildAura(Sprite dot); // 0x00000001806611B0-0x0000000180661460
	private void BuildSparks(Sprite dot, int n); // 0x0000000180661460-0x0000000180661A90
	private static Color SparkColor(int i); // 0x0000000180661A90-0x0000000180661B10
	private void BuildPuffs(int n); // 0x0000000180661B10-0x0000000180662730
	private RectTransform NewDot(Transform parent, string name, Sprite sprite, float size); // 0x0000000180662730-0x0000000180662D20
	private Sprite DotSprite(); // 0x0000000180662D20-0x00000001806631B0
	public void SetPaused(bool on); // 0x00000001806631B0-0x00000001806631C0
	public void SetLowTier(bool low); // 0x00000001806631C0-0x00000001806635A0
	public void Tick(float t, float dt); // 0x00000001806635A0-0x0000000180663600
	private void ApplyPose(float t); // 0x0000000180663600-0x0000000180664340
	private void DriftPuffs(float dt); // 0x0000000180664340-0x0000000180664630
	private static void WriteAlpha(Image img, float a, ref float last); // 0x0000000180664630-0x00000001806647B0
	public void Dispose(); // 0x00000001806647B0-0x0000000180664AF0
	private void Clear(); // 0x0000000180664AF0-0x0000000180664F00
	private void OnDestroy(); // 0x0000000180664F00-0x00000001806650B0
}

