/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Image))]
	public class PokyGiftFxPlayer : MonoBehaviour // TypeDefIndex: 1912
	{
		// Fields
		public const float FPS_POKY = 60f; // Metadata: 0x0064DEAB
		public const int POKY_TICKS_PER_FRAME = 6; // Metadata: 0x0064DEAF
		public const float POKY_SPIN_PER_TICK = -0.8f; // Metadata: 0x0064DEB0
		[Tooltip("C\u00E1c frame c\u1EE7a hi\u1EC7u \u1EE9ng. \u0110\u1EC3 tr\u1ED1ng = ch\u1EC9 xoay/nh\u1EA5p nh\u00F4, kh\u00F4ng l\u1EADt frame.")]
		public Sprite[] frames; // 0x20
		[Tooltip("S\u1ED1 l\u01B0\u1EE3t Update cho m\u1ED7i frame theo Poky (6 = 10 frame/gi\u00E2y \u1EDF 60 fps).")]
		public int ticksPerFrame; // 0x28
		[Tooltip("Frame b\u1EAFt \u0111\u1EA7u \u2014 l\u1EC7ch pha gi\u1EEFa nhi\u1EC1u b\u1EA3n th\u1EC3 c\u00F9ng hi\u1EC7u \u1EE9ng cho \u0111\u1EE1 \u0111\u1EC1u t\u0103m t\u1EAFp.")]
		public int startFrame; // 0x2C
		[Tooltip("\u0110\u1ED9 xoay m\u1ED7i l\u01B0\u1EE3t Update theo Poky (\u22120,8 = \u221248 \u0111\u1ED9/gi\u00E2y \u1EDF 60 fps). 0 = kh\u00F4ng xoay.")]
		public float spinPerTick; // 0x30
		[Tooltip("Ki\u1EC3u ch\u1EA1y: Loop (m\u1EB7c \u0111\u1ECBnh, nh\u01B0 h\u1ED9p qu\u00E0) \u00B7 Once (d\u1EEBng \u1EDF frame cu\u1ED1i) \u00B7 PingPong.")]
		public PlayMode playMode; // 0x34
		[Tooltip("Once xong th\u00EC t\u1EF1 t\u1EAFt node (d\u00F9ng cho FX b\u1EAFn m\u1ED9t ph\u00E1t r\u1ED3i bi\u1EBFn m\u1EA5t).")]
		public bool autoDisableOnEnd; // 0x38
		[Tooltip("> 0 \u21D2 m\u1ED7i frame \u00E9p sizeDelta = c\u1EE1 TH\u1EACT c\u1EE7a sprite \u00D7 h\u1EC7 s\u1ED1 n\u00E0y. B\u1EAFt bu\u1ED9c v\u1EDBi b\u1ED9 frame c\u00F3 k\u00EDch th\u01B0\u1EDBc thay \u0111\u1ED5i (EffectUpLevel: 13\u00D78 \u2192 138\u00D764), n\u1EBFu kh\u00F4ng frame nh\u1ECF b\u1ECB k\u00E9o gi\u00E3n th\u00E0nh kh\u1ED1i m\u1EDD.")]
		public float nativeSizeScale; // 0x3C
		[Tooltip("Bi\u00EAn \u0111\u1ED9 nh\u1EA5p nh\u00F4 c\u1EE7a localScale (0 = t\u1EAFt). 0,25 = ph\u00ECnh/x\u1EB9p \u00B125 %.")]
		public float pulseAmplitude; // 0x40
		[Tooltip("Chu k\u1EF3 nh\u1EA5p nh\u00F4 (gi\u00E2y).")]
		public float pulseSeconds; // 0x44
		[NonSerialized]
		public Action onEnd; // 0x48
		private Image _img; // 0x50
		private RectTransform _rt; // 0x58
		private float _frameTimer; // 0x60
		private float _pulseTimer; // 0x64
		private int _current; // 0x68
		private int _dir; // 0x6C
		private bool _finished; // 0x70
	
		// Properties
		public bool IsFinished { get; } // 0x0000000180643BD0-0x0000000180643BE0 
		public int CurrentFrame { get; } // 0x00000001803002C0-0x00000001803002D0 
		public int FrameCount { get; } // 0x0000000180643B90-0x0000000180643BB0 
		private bool HasFrames { get; } // 0x0000000180643BB0-0x0000000180643BD0 
	
		// Nested types
		public enum PlayMode // TypeDefIndex: 1913
		{
			Loop = 0,
			Once = 1,
			PingPong = 2
		}
	
		// Constructors
		public PokyGiftFxPlayer(); // 0x0000000180643B70-0x0000000180643B90
	
		// Methods
		public static PlayMode FromPokyTypeAnim(int typeAnim); // 0x00000001806437E0-0x0000000180643800
		private void Awake(); // 0x0000000180643640-0x00000001806436F0
		public void Play(); // 0x0000000180643800-0x0000000180643810
		private void OnEnable(); // 0x0000000180643800-0x0000000180643810
		private void Restart(); // 0x0000000180643810-0x0000000180643950
		private void ApplyFrame(); // 0x00000001806434E0-0x0000000180643640
		private void Update(); // 0x0000000180643950-0x0000000180643B70
		private void Advance(); // 0x0000000180643440-0x00000001806434E0
		private void EndOnce(); // 0x00000001806436F0-0x00000001806437E0
	}
}
