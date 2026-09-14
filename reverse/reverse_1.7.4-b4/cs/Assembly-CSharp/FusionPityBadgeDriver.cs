/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class FusionPityBadgeDriver : MonoBehaviour // TypeDefIndex: 2320
{
	// Fields
	[CompilerGenerated]
	private SpriteRenderer _Host_k__BackingField; // 0x20
	[CompilerGenerated]
	private EntityId _HostId_k__BackingField; // 0x28
	private Canvas _canvas; // 0x30
	private RectTransform _root; // 0x38
	private RectTransform _rt; // 0x40
	private CanvasGroup _cg; // 0x48
	private Image _bg; // 0x50
	private Image _icon; // 0x58
	private UnityEngine.UI.Text _txt; // 0x60
	private string _template; // 0x68
	private int _percent; // 0x70
	private int _shownPercent; // 0x74
	private float _nextFollowAt; // 0x78
	private Camera _srcCamCache; // 0x80
	private int _srcCamFrame; // 0x88
	private readonly List<Image> _particles; // 0x90
	private RectTransform _particleRoot; // 0x98
	private Sprite _particleSprite; // 0xA0
	private bool _particleSpriteResolved; // 0xA8
	private bool _pulseRunning; // 0xA9
	private bool _dying; // 0xAA
	private const int PARTICLE_BURST = 12; // Metadata: 0x005F1F13

	// Properties
	public SpriteRenderer Host { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8720-0x00000001802A8730 0x00000001802B4BC0-0x00000001802B4C20
	public EntityId HostId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8730-0x00000001802A8740 0x0000000180A44280-0x0000000180A44290

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass36_0 // TypeDefIndex: 2321
	{
		// Fields
		public Color baseColor; // 0x10
		public FusionPityBadgeDriver __4__this; // 0x20

		// Constructors
		public __c__DisplayClass36_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayGain_b__5(float k); // 0x0000000180B2EDF0-0x0000000180B2EFC0
		internal void _PlayGain_b__6(); // 0x0000000180B2EFC0-0x0000000180B2F0F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass36_1 // TypeDefIndex: 2322
	{
		// Fields
		public RectTransform irt; // 0x10
		public FusionPityBadgeDriver __4__this; // 0x18
		public Action<float> __9__9; // 0x20

		// Constructors
		public __c__DisplayClass36_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayGain_b__7(float s); // 0x0000000180B2F0F0-0x0000000180B2F290
		internal void _PlayGain_b__8(); // 0x0000000180B2F290-0x0000000180B2F560
		internal void _PlayGain_b__9(float s); // 0x0000000180B2F560-0x0000000180B2F700
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass37_0 // TypeDefIndex: 2323
	{
		// Fields
		public Image bgImg; // 0x10
		public Color from; // 0x18
		public Color to; // 0x28

		// Constructors
		public __c__DisplayClass37_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayBurst_b__2(float k); // 0x0000000180B2F700-0x0000000180B2F8C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass39_0 // TypeDefIndex: 2324
	{
		// Fields
		public Image img; // 0x10
		public Vector2 to; // 0x18

		// Constructors
		public __c__DisplayClass39_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SpawnParticles_b__0(float k); // 0x0000000180B2F8C0-0x0000000180B2FAF0
		internal void _SpawnParticles_b__1(); // 0x0000000180B2FAF0-0x0000000180B2FC40
	}

	// Constructors
	public FusionPityBadgeDriver(); // 0x0000000180B2E070-0x0000000180B2E200

	// Methods
	internal void Setup(SpriteRenderer host, Canvas canvas, RectTransform root, CanvasGroup cg, Image bg, Image icon, UnityEngine.UI.Text txt, bool isSelfSide); // 0x0000000180B29D80-0x0000000180B2A220
	private void CaptureTemplate(); // 0x0000000180B2A220-0x0000000180B2A370
	internal void SetPercent(int percent); // 0x0000000180B2A370-0x0000000180B2A3A0
	private void ApplyText(int value); // 0x0000000180B2A3A0-0x0000000180B2A5C0
	private void Show(); // 0x0000000180B2A5C0-0x0000000180B2A8E0
	private void StartPulse(); // 0x0000000180B2A8E0-0x0000000180B2AB80
	private void Update(); // 0x0000000180B2AB80-0x0000000180B2AC40
	internal void Follow(bool force); // 0x0000000180B2AC40-0x0000000180B2B510
	private Camera ResolveSrcCam(); // 0x0000000180B2B510-0x0000000180B2BA20
	internal void PlayGain(int before, int after); // 0x0000000180B2BA20-0x0000000180B2C360
	internal void PlayBurst(); // 0x0000000180B2C360-0x0000000180B2C8F0
	private void SpawnParticles(int count, bool burst); // 0x0000000180B2C8F0-0x0000000180B2D300
	private Image RentParticle(int index); // 0x0000000180B2D300-0x0000000180B2DA60
	private void EnsureParticleSprite(); // 0x0000000180B2DA60-0x0000000180B2DC90
	private void OnDestroy(); // 0x0000000180B2DC90-0x0000000180B2E070
	[CompilerGenerated]
	private void _Show_b__31_0(float a); // 0x0000000180B2E200-0x0000000180B2E350
	[CompilerGenerated]
	private void _StartPulse_b__32_0(float k); // 0x0000000180B2E350-0x0000000180B2E500
	[CompilerGenerated]
	private void _PlayGain_b__36_0(float v); // 0x0000000180B2E500-0x0000000180B2E540
	[CompilerGenerated]
	private void _PlayGain_b__36_1(); // 0x0000000180B2E540-0x0000000180B2E560
	[CompilerGenerated]
	private void _PlayGain_b__36_2(float s); // 0x0000000180B2E560-0x0000000180B2E700
	[CompilerGenerated]
	private void _PlayGain_b__36_3(); // 0x0000000180B2E700-0x0000000180B2E930
	[CompilerGenerated]
	private void _PlayGain_b__36_4(float s); // 0x0000000180B2E930-0x0000000180B2EAD0
	[CompilerGenerated]
	private void _PlayBurst_b__37_0(float s); // 0x0000000180B2EAD0-0x0000000180B2EDA0
	[CompilerGenerated]
	private void _PlayBurst_b__37_1(); // 0x0000000180B2EDA0-0x0000000180B2EDF0
}

