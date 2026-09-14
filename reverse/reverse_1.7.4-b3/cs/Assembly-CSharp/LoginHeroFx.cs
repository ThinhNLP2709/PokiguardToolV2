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
public class LoginHeroFx : MonoBehaviour // TypeDefIndex: 1068
{
	// Fields
	[CompilerGenerated]
	private static LoginHeroFx _Active_k__BackingField; // 0x00
	private const int SPARK_MAX = 20; // Metadata: 0x005EF301
	private const int PUFF_MAX = 6; // Metadata: 0x005EF302
	private const int RAY_MAX = 8; // Metadata: 0x005EF303
	private const float CY = 18f; // Metadata: 0x005EF304
	private const float RAY_W = 170f; // Metadata: 0x005EF308
	private const float RAY_H = 340f; // Metadata: 0x005EF30C
	private const float RAY_DY = -10f; // Metadata: 0x005EF310
	private const float RAY_SPIN = 0.018f; // Metadata: 0x005EF314
	private const float RAY_A_MIN = 0.09f; // Metadata: 0x005EF318
	private const float RAY_A_MAX = 0.18f; // Metadata: 0x005EF31C
	private const float RAY_PERIOD = 5.5f; // Metadata: 0x005EF320
	private const float AURA_SIZE = 430f; // Metadata: 0x005EF324
	private const float AURA_DY = 6f; // Metadata: 0x005EF328
	private const float AURA_PERIOD = 4.2f; // Metadata: 0x005EF32C
	private const float AURA_A_MIN = 0.1f; // Metadata: 0x005EF330
	private const float AURA_A_MAX = 0.24f; // Metadata: 0x005EF334
	private const float HALO_SIZE = 210f; // Metadata: 0x005EF338
	private const float HALO_DY = 92f; // Metadata: 0x005EF33C
	private const float HALO_PERIOD = 3.1f; // Metadata: 0x005EF340
	private const float HALO_A_MIN = 0.06f; // Metadata: 0x005EF344
	private const float HALO_A_MAX = 0.18f; // Metadata: 0x005EF348
	private const float AURA_PUMP = 0.05f; // Metadata: 0x005EF34C
	private const float BOB_AMP = 6f; // Metadata: 0x005EF350
	private const float BOB_PERIOD = 2.4f; // Metadata: 0x005EF354
	private const float SPARK_RX_MIN = 135f; // Metadata: 0x005EF358
	private const float SPARK_RX_MAX = 240f; // Metadata: 0x005EF35C
	private const float SPARK_RY_MIN = 105f; // Metadata: 0x005EF360
	private const float SPARK_RY_MAX = 215f; // Metadata: 0x005EF364
	private const float SPARK_SIZE_MIN = 14f; // Metadata: 0x005EF368
	private const float SPARK_SIZE_MAX = 34f; // Metadata: 0x005EF36C
	private const float SPARK_SPD_MIN = 0.16f; // Metadata: 0x005EF370
	private const float SPARK_SPD_MAX = 0.42f; // Metadata: 0x005EF374
	private const float SPARK_TW_MIN = 0.5f; // Metadata: 0x005EF378
	private const float SPARK_TW_MAX = 1.4f; // Metadata: 0x005EF37C
	private const float SPARK_A_MIN = 0.55f; // Metadata: 0x005EF380
	private const float SPARK_A_MAX = 1f; // Metadata: 0x005EF384
	private const float SPARK_TILT = 20f; // Metadata: 0x005EF388
	private const float PUFF_W_MIN = 46f; // Metadata: 0x005EF38C
	private const float PUFF_W_MAX = 96f; // Metadata: 0x005EF390
	private const float PUFF_SPD_MIN = 7f; // Metadata: 0x005EF394
	private const float PUFF_SPD_MAX = 17f; // Metadata: 0x005EF398
	private const float PUFF_A_MIN = 0.28f; // Metadata: 0x005EF39C
	private const float PUFF_A_MAX = 0.46f; // Metadata: 0x005EF3A0
	private static readonly Color PUFF_TINT; // 0x08
	private const float PUFF_Y_LOW = -0.88f; // Metadata: 0x005EF3A4
	private const float PUFF_Y_HIGH = -0.12f; // Metadata: 0x005EF3A8
	private const float PUFF_ASPECT = 0.796875f; // Metadata: 0x005EF3AC
	private const float ALPHA_EPS = 0.01f; // Metadata: 0x005EF3B0
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
	public static LoginHeroFx Active { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018065DD20-0x000000018065DD80 0x000000018065DD80-0x000000018065DE30
	public bool Built { get; } // 0x00000001803C6270-0x00000001803C6280 
	public int PartCount { get; } // 0x000000018065DE30-0x000000018065E010 

	// Nested types
	private struct Spark // TypeDefIndex: 1069
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

	private struct Puff // TypeDefIndex: 1070
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
	public LoginHeroFx(); // 0x00000001806636C0-0x0000000180663960
	static LoginHeroFx(); // 0x0000000180663960-0x00000001806639B0

	// Methods
	public void Build(RectTransform back, RectTransform front); // 0x000000018065E010-0x000000018065E6F0
	private void BuildRays(int n); // 0x000000018065E6F0-0x000000018065F7C0
	private void BuildAura(Sprite dot); // 0x000000018065F7C0-0x000000018065FA70
	private void BuildSparks(Sprite dot, int n); // 0x000000018065FA70-0x00000001806600A0
	private static Color SparkColor(int i); // 0x00000001806600A0-0x0000000180660120
	private void BuildPuffs(int n); // 0x0000000180660120-0x0000000180660D40
	private RectTransform NewDot(Transform parent, string name, Sprite sprite, float size); // 0x0000000180660D40-0x0000000180661330
	private Sprite DotSprite(); // 0x0000000180661330-0x00000001806617C0
	public void SetPaused(bool on); // 0x00000001806617C0-0x00000001806617D0
	public void SetLowTier(bool low); // 0x00000001806617D0-0x0000000180661BB0
	public void Tick(float t, float dt); // 0x0000000180661BB0-0x0000000180661C10
	private void ApplyPose(float t); // 0x0000000180661C10-0x0000000180662950
	private void DriftPuffs(float dt); // 0x0000000180662950-0x0000000180662C40
	private static void WriteAlpha(Image img, float a, ref float last); // 0x0000000180662C40-0x0000000180662DC0
	public void Dispose(); // 0x0000000180662DC0-0x0000000180663100
	private void Clear(); // 0x0000000180663100-0x0000000180663510
	private void OnDestroy(); // 0x0000000180663510-0x00000001806636C0
}

