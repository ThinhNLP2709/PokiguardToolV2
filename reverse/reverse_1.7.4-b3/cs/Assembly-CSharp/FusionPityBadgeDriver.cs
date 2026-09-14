/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class FusionPityBadgeDriver : MonoBehaviour // TypeDefIndex: 2313
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
	private const int PARTICLE_BURST = 12; // Metadata: 0x005F0AFC

	// Properties
	public SpriteRenderer Host { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8720-0x00000001802A8730 0x00000001802B4BC0-0x00000001802B4C20
	public EntityId HostId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8730-0x00000001802A8740 0x0000000180A78980-0x0000000180A78990

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass36_0 // TypeDefIndex: 2314
	{
		// Fields
		public Color baseColor; // 0x10
		public FusionPityBadgeDriver __4__this; // 0x20

		// Constructors
		public __c__DisplayClass36_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayGain_b__5(float k); // 0x0000000180B21C10-0x0000000180B21DE0
		internal void _PlayGain_b__6(); // 0x0000000180B21DE0-0x0000000180B21F10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass36_1 // TypeDefIndex: 2315
	{
		// Fields
		public RectTransform irt; // 0x10
		public FusionPityBadgeDriver __4__this; // 0x18
		public Action<float> __9__9; // 0x20

		// Constructors
		public __c__DisplayClass36_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayGain_b__7(float s); // 0x0000000180B21F10-0x0000000180B220B0
		internal void _PlayGain_b__8(); // 0x0000000180B220B0-0x0000000180B22380
		internal void _PlayGain_b__9(float s); // 0x0000000180B22380-0x0000000180B22520
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass37_0 // TypeDefIndex: 2316
	{
		// Fields
		public Image bgImg; // 0x10
		public Color from; // 0x18
		public Color to; // 0x28

		// Constructors
		public __c__DisplayClass37_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayBurst_b__2(float k); // 0x0000000180B22520-0x0000000180B226E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass39_0 // TypeDefIndex: 2317
	{
		// Fields
		public Image img; // 0x10
		public Vector2 to; // 0x18

		// Constructors
		public __c__DisplayClass39_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SpawnParticles_b__0(float k); // 0x0000000180B226E0-0x0000000180B22910
		internal void _SpawnParticles_b__1(); // 0x0000000180B22910-0x0000000180B22A60
	}

	// Constructors
	public FusionPityBadgeDriver(); // 0x0000000180B20E90-0x0000000180B21020

	// Methods
	internal void Setup(SpriteRenderer host, Canvas canvas, RectTransform root, CanvasGroup cg, Image bg, Image icon, UnityEngine.UI.Text txt, bool isSelfSide); // 0x0000000180B1CBA0-0x0000000180B1D040
	private void CaptureTemplate(); // 0x0000000180B1D040-0x0000000180B1D190
	internal void SetPercent(int percent); // 0x0000000180B1D190-0x0000000180B1D1C0
	private void ApplyText(int value); // 0x0000000180B1D1C0-0x0000000180B1D3E0
	private void Show(); // 0x0000000180B1D3E0-0x0000000180B1D700
	private void StartPulse(); // 0x0000000180B1D700-0x0000000180B1D9A0
	private void Update(); // 0x0000000180B1D9A0-0x0000000180B1DA60
	internal void Follow(bool force); // 0x0000000180B1DA60-0x0000000180B1E330
	private Camera ResolveSrcCam(); // 0x0000000180B1E330-0x0000000180B1E840
	internal void PlayGain(int before, int after); // 0x0000000180B1E840-0x0000000180B1F180
	internal void PlayBurst(); // 0x0000000180B1F180-0x0000000180B1F710
	private void SpawnParticles(int count, bool burst); // 0x0000000180B1F710-0x0000000180B20120
	private Image RentParticle(int index); // 0x0000000180B20120-0x0000000180B20880
	private void EnsureParticleSprite(); // 0x0000000180B20880-0x0000000180B20AB0
	private void OnDestroy(); // 0x0000000180B20AB0-0x0000000180B20E90
	[CompilerGenerated]
	private void _Show_b__31_0(float a); // 0x0000000180B21020-0x0000000180B21170
	[CompilerGenerated]
	private void _StartPulse_b__32_0(float k); // 0x0000000180B21170-0x0000000180B21320
	[CompilerGenerated]
	private void _PlayGain_b__36_0(float v); // 0x0000000180B21320-0x0000000180B21360
	[CompilerGenerated]
	private void _PlayGain_b__36_1(); // 0x0000000180B21360-0x0000000180B21380
	[CompilerGenerated]
	private void _PlayGain_b__36_2(float s); // 0x0000000180B21380-0x0000000180B21520
	[CompilerGenerated]
	private void _PlayGain_b__36_3(); // 0x0000000180B21520-0x0000000180B21750
	[CompilerGenerated]
	private void _PlayGain_b__36_4(float s); // 0x0000000180B21750-0x0000000180B218F0
	[CompilerGenerated]
	private void _PlayBurst_b__37_0(float s); // 0x0000000180B218F0-0x0000000180B21BC0
	[CompilerGenerated]
	private void _PlayBurst_b__37_1(); // 0x0000000180B21BC0-0x0000000180B21C10
}

