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
public class LoginBackdrop : MonoBehaviour // TypeDefIndex: 1033
{
	// Fields
	private const float NEBULA_OVERSCAN = 1.06f; // Metadata: 0x005F0692
	private const float NEBULA_PERIOD = 40f; // Metadata: 0x005F0696
	private const float NEBULA_DRIFT_X = 0.015f; // Metadata: 0x005F069A
	private const float NEBULA_DRIFT_Y = 0.01f; // Metadata: 0x005F069E
	private const float STAR_TEX_SIZE = 256f; // Metadata: 0x005F06A2
	private const float STAR_TILE_MAX = 24f; // Metadata: 0x005F06A6
	private const int RAY_COUNT = 3; // Metadata: 0x005F06AA
	private const float RAY_W = 420f; // Metadata: 0x005F06AB
	private const float RAY_H = 900f; // Metadata: 0x005F06AF
	private const float FADE_TIME = 0.35f; // Metadata: 0x005F06B3
	private const int ORB_MAX = 48; // Metadata: 0x005F06B7
	private const int CLOUD_MAX = 12; // Metadata: 0x005F06B8
	private const int CLOUD_LOW = 2; // Metadata: 0x005F06B9
	private const float CLOUD_W = 260f; // Metadata: 0x005F06BA
	private const float CLOUD_BOB = 4f; // Metadata: 0x005F06BE
	private const int CLOUD_SEED = 20260908; // Metadata: 0x005F06C2
	private static readonly float[] CLOUD_SCALE; // 0x00
	private static readonly float[] CLOUD_ALPHA; // 0x08
	private static readonly float[] CLOUD_SPEED; // 0x10
	private RectTransform _rect; // 0x20
	private RawImage _nebula; // 0x28
	private RawImage _starsFar; // 0x30
	private RawImage _starsNear; // 0x38
	private RectTransform _rayRoot; // 0x40
	private readonly RectTransform[] _rays; // 0x48
	private readonly Image[] _rayImg; // 0x50
	private RectTransform _cloudRoot; // 0x58
	private Cloud[] _clouds; // 0x60
	private RectTransform _orbRoot; // 0x68
	private Orb[] _orbs; // 0x70
	private RectTransform _shootRt; // 0x78
	private Image _shootImg; // 0x80
	private Image _vignette; // 0x88
	private Image _fade; // 0x90
	private bool _lowTier; // 0x98
	private bool _paused; // 0x99
	private bool _animated; // 0x9A
	private bool _rayOn; // 0x9B
	private bool _starNearOn; // 0x9C
	private bool _shootOn; // 0x9D
	private bool _nebulaDriftOn; // 0x9E
	private float _starFarSpeed; // 0xA0
	private float _starNearSpeed; // 0xA4
	private float _tileX; // 0xA8
	private float _tileY; // 0xAC
	private float _tiledForW; // 0xB0
	private float _tiledForH; // 0xB4
	private float _nebUvX; // 0xB8
	private float _nebUvY; // 0xBC
	private float _nebUvW; // 0xC0
	private float _nebUvH; // 0xC4
	private float _coveredW; // 0xC8
	private float _coveredH; // 0xCC
	private float _t; // 0xD0
	private float _fadeLeft; // 0xD4
	private float _shootTimer; // 0xD8
	private float _shootLeft; // 0xDC
	private float _shootFromX; // 0xE0
	private float _shootFromY; // 0xE4
	private float _shootToX; // 0xE8
	private float _shootToY; // 0xEC
	private Sprite _orbSprite; // 0xF0
	private Sprite _raySprite; // 0xF8
	private Sprite _vignetteSprite; // 0x100
	private bool _orbSpriteOwned; // 0x108
	private bool _raySpriteOwned; // 0x109
	private bool _vignetteSpriteOwned; // 0x10A
	private int _cloudWant; // 0x10C

	// Nested types
	private struct Cloud // TypeDefIndex: 1034
	{
		// Fields
		public RectTransform rt; // 0x00
		public Image img; // 0x08
		public float x; // 0x10
		public float y; // 0x14
		public float w; // 0x18
		public float speed; // 0x1C
		public float alpha; // 0x20
		public float bobFreq; // 0x24
		public float phase; // 0x28
		public float lastAlpha; // 0x2C
	}

	private struct Orb // TypeDefIndex: 1035
	{
		// Fields
		public RectTransform rt; // 0x00
		public Image img; // 0x08
		public float x; // 0x10
		public float y; // 0x14
		public float size; // 0x18
		public float speed; // 0x1C
		public float swayAmp; // 0x20
		public float swayFreq; // 0x24
		public float phase; // 0x28
		public float alpha; // 0x2C
	}

	// Constructors
	public LoginBackdrop(); // 0x0000000180645B30-0x0000000180645DB0
	static LoginBackdrop(); // 0x0000000180645DB0-0x0000000180645FE0

	// Methods
	public void Build(RectTransform parent); // 0x000000018063BEC0-0x000000018063C260
	private void ReadConfig(); // 0x000000018063C260-0x000000018063C650
	private void BuildNebula(); // 0x000000018063C650-0x000000018063CAB0
	private void OnNebulaReady(Texture2D tex); // 0x000000018063CAB0-0x000000018063CC80
	public void RefreshNebulaCover(); // 0x000000018063CC80-0x000000018063D110
	private float NebulaAspect(); // 0x000000018063D110-0x000000018063D320
	private void RefreshCoverIfResized(); // 0x000000018063D320-0x000000018063D620
	private void OnRectTransformDimensionsChange(); // 0x000000018063D620-0x000000018063D630
	private void BuildStars(); // 0x000000018063D630-0x000000018063DB10
	public void RefreshStarTiling(bool force); // 0x000000018063DB10-0x000000018063DFD0
	private void BuildClouds(); // 0x000000018063DFD0-0x000000018063F1E0
	private static Sprite CloudSprite(string name); // 0x000000018063F1E0-0x000000018063F340
	private static float SpriteAspect(Sprite sp); // 0x000000018063F340-0x000000018063F5E0
	private void BuildRays(); // 0x000000018063F5E0-0x0000000180640260
	private void BuildOrbs(); // 0x0000000180640260-0x0000000180641180
	private Sprite OrbSprite(); // 0x0000000180641180-0x00000001806415C0
	private void Respawn(ref Orb o, float w, float h, bool anywhere); // 0x00000001806415C0-0x0000000180641AE0
	private static Color OrbColor(float alpha); // 0x0000000180641AE0-0x0000000180641BA0
	private void BuildShooting(); // 0x0000000180641BA0-0x00000001806423A0
	private void BuildVignette(); // 0x00000001806423A0-0x0000000180642B20
	private void BuildFade(); // 0x0000000180642B20-0x0000000180642C60
	private RawImage NewRaw(string name); // 0x0000000180642C60-0x0000000180643010
	public void SetLowTier(bool low); // 0x0000000180643010-0x0000000180643890
	public void Pause(bool on); // 0x0000000180643890-0x0000000180643AB0
	private void Update(); // 0x0000000180643AB0-0x0000000180644DB0
	private void TickClouds(float dt); // 0x0000000180644DB0-0x0000000180645370
	private void TickShooting(float dt); // 0x0000000180645370-0x0000000180645850
	private void OnDestroy(); // 0x0000000180645850-0x0000000180645B30
}

