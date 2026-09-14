/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PokiGuard.StatusFx;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokiGuard.GalaxyRicky
{
	public static class GalaxyRickyFx // TypeDefIndex: 2537
	{
		// Fields
		public static readonly string[] ALL_SPRITES; // 0x00
		private static readonly string[] CARD_ORDER; // 0x08
		private static readonly string[] CARD_SPRITES; // 0x10
		private static readonly Color COL_RED; // 0x18
		private static readonly Color COL_YELLOW; // 0x28
		private static readonly Color COL_BLUE; // 0x38
		private static readonly Color COL_GOLD; // 0x48
		private static readonly Color COL_RING; // 0x58
		private static readonly Color COL_RING_FLAT; // 0x68
		private static readonly Color COL_PILLAR_FALLBACK; // 0x78
		private static readonly Color COL_COUNTER; // 0x88
		private static readonly Color COL_OUTLINE; // 0x98
		private static readonly Color[] CARD_FALLBACK; // 0xA8
		private static Nodes _active; // 0xB0
		private static Nodes _linger; // 0xB8
		private static GameObject _lingerGo; // 0xC0
		private static MonoBehaviour _lingerHost; // 0xC8
		private static Coroutine _lingerCo; // 0xD0
		private static readonly int[] _orderTmp; // 0xD8
	
		// Nested types
		public sealed class Nodes // TypeDefIndex: 2538
		{
			// Fields
			public RectTransform Root; // 0x10
			public Image Pillar; // 0x18
			public Image Glow; // 0x20
			public float GlowMax; // 0x28
			public Image Ring; // 0x30
			public Image Flash; // 0x38
			public float FlashMax; // 0x40
			public readonly Image[] Cards; // 0x48
			public UnityEngine.UI.Text Counter; // 0x50
			public UnityEngine.UI.Text Doubled; // 0x58
			public float U; // 0x60
			public float PetH; // 0x64
			public Vector2 Caster; // 0x68
			public Vector2 Anchor; // 0x70
			public Vector2 Target; // 0x78
			public float Dir; // 0x80
			public int PickIndex; // 0x84
			public bool AtSelf; // 0x88
			public float Clock; // 0x8C
			public Transform Pet; // 0x90
			public Vector3 PetOrigin; // 0x98
			public Vector3 PetStep; // 0xA4
			public float PetT; // 0xB0
			public bool JumpLogged; // 0xB4
	
			// Constructors
			public Nodes(); // 0x0000000180BC3170-0x0000000180BC3210
	
			// Methods
			public float Px(float v); // 0x0000000180BC3130-0x0000000180BC3140
			public Vector2 At(float dx, float dy); // 0x0000000180BC3140-0x0000000180BC3170
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass114_0 // TypeDefIndex: 2539
		{
			// Fields
			public Nodes n; // 0x10
	
			// Constructors
			public __c__DisplayClass114_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Play_b__0(float t); // 0x0000000180BC3210-0x0000000180BC3280
			internal void _Play_b__1(float t); // 0x0000000180BC3280-0x0000000180BC32F0
			internal void _Play_b__2(float t); // 0x0000000180BC32F0-0x0000000180BC3360
			internal void _Play_b__3(float t); // 0x0000000180BC3360-0x0000000180BC33D0
		}
	
		[CompilerGenerated]
		private sealed class _LingerAfterPlay_d__127 : IEnumerator<object> // TypeDefIndex: 2540
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public Nodes n; // 0x20
			public float sp; // 0x28
			public GameObject holder; // 0x30
			private Image _card_5__2; // 0x38
			private Animator _anim_5__3; // 0x40
			private bool _hasKey_5__4; // 0x48
			private float _clock_5__5; // 0x4C
			private float _maxWait_5__6; // 0x50
			private bool _strikeSeen_5__7; // 0x54
			private bool _impactFired_5__8; // 0x55
			private bool _strikeDone_5__9; // 0x56
			private float _strikeAt_5__10; // 0x58
			private float _doneAt_5__11; // 0x5C
			private Vector2 _reveal_5__12; // 0x60
			private MatchService _ms_5__13; // 0x68
			private float _dur_5__14; // 0x70
			private float _f_5__15; // 0x74
			private Vector2 _fall_5__16; // 0x78
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _LingerAfterPlay_d__127(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180BC33D0-0x0000000180BC34E0
			private bool MoveNext(); // 0x0000000180BC34E0-0x0000000180BC49B0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180BC49B0-0x0000000180BC49F0
		}
	
		[CompilerGenerated]
		private sealed class _Play_d__114 : IEnumerator<object> // TypeDefIndex: 2541
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public bool atSelf; // 0x20
			public string pick; // 0x28
			public int useCount; // 0x30
			public bool doubled; // 0x34
			public float speed; // 0x38
			private __c__DisplayClass114_0 __8__1; // 0x40
			private StatusFxController _ctl_5__2; // 0x48
			private float _sp_5__3; // 0x50
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _Play_d__114(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180BC49F0-0x0000000180BC4AB0
			private bool MoveNext(); // 0x0000000180BC4AB0-0x0000000180BC5BE0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180BC5BE0-0x0000000180BC5C20
		}
	
		[CompilerGenerated]
		private sealed class _Tween_d__135 : IEnumerator<object> // TypeDefIndex: 2542
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public float dur; // 0x20
			public Nodes n; // 0x28
			public Action<float> step; // 0x30
			private float _t_5__2; // 0x38
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _Tween_d__135(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
			private bool MoveNext(); // 0x0000000180BC5C70-0x0000000180BC5E40
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180BC5E40-0x0000000180BC5E80
		}
	
		// Constructors
		static GalaxyRickyFx(); // 0x0000000180BC2B40-0x0000000180BC3130
	
		// Methods
		[IteratorStateMachine(typeof(_Play_d__114))]
		public static IEnumerator Play(bool atSelf, string pick, int useCount, bool doubled, float speed = 1f /* Metadata: 0x005F23DA */); // 0x0000000180BB9D30-0x0000000180BB9E00
		public static void AbortAll(); // 0x0000000180BB9E00-0x0000000180BBA3B0
		public static RectTransform BuildNodes(RectTransform parent, Vector2 casterPos, Vector2 targetPos, string pick, int useCount, bool doubled, out Nodes nodes, Func<string, Sprite> loader = null, float dir = 0f /* Metadata: 0x005F23DE */, float petHeight = 0f /* Metadata: 0x005F23E2 */); // 0x0000000180BBA3B0-0x0000000180BBB9F0
		public static float UnitsPerVideoPx(RectTransform overlay); // 0x0000000180BBB9F0-0x0000000180BBBBD0
		public static Vector2 PillarSize(Nodes n); // 0x0000000180BBBBD0-0x0000000180BBBC20
		public static int FontPx(Nodes n, int videoPx); // 0x0000000180BBBC20-0x0000000180BBBC50
		private static void StepRise(Nodes n, float t); // 0x0000000180BBBC50-0x0000000180BBC570
		private static void StepShuffle(Nodes n, float t); // 0x0000000180BBC570-0x0000000180BBCF00
		private static void StepReveal(Nodes n, float t); // 0x0000000180BBCF00-0x0000000180BBD8A0
		private static void StepHold(Nodes n, float t); // 0x0000000180BBD8A0-0x0000000180BBDBC0
		private static void RingFlatten(Nodes n, float e); // 0x0000000180BBDBC0-0x0000000180BBDE80
		private static void DetachAndLinger(StatusFxController ctl, Nodes n, float sp); // 0x0000000180BBDE80-0x0000000180BBE960
		[IteratorStateMachine(typeof(_LingerAfterPlay_d__127))]
		private static IEnumerator LingerAfterPlay(GameObject holder, Nodes n, float sp); // 0x0000000180BBE960-0x0000000180BBEA80
		private static bool HasParam(Animator a, string name); // 0x0000000180BBEA80-0x0000000180BBEBA0
		private static Transform FindCasterPet(bool atSelf); // 0x0000000180BBEBA0-0x0000000180BBEFC0
		private static bool TryPetStep(Transform pet, RectTransform overlay, Vector2 casterLocal, out Vector3 step, out string diag); // 0x0000000180BBEFC0-0x0000000180BBFA20
		private static Camera CanvasCameraOf(Transform t); // 0x0000000180BBFA20-0x0000000180BBFCA0
		private static float PetHeightUnits(Transform pet, RectTransform overlay); // 0x0000000180BBFCA0-0x0000000180BC0320
		private static void ApplyPet(Nodes n); // 0x0000000180BC0320-0x0000000180BC0650
		private static void RestorePet(Nodes n); // 0x0000000180BC0650-0x0000000180BC0840
		[IteratorStateMachine(typeof(_Tween_d__135))]
		private static IEnumerator Tween(Nodes n, float dur, Action<float> step); // 0x0000000180BC0840-0x0000000180BC0960
		private static bool Alive(Nodes n); // 0x0000000180BC0960-0x0000000180BC0AA0
		private static float Dt(); // 0x0000000180BC0AA0-0x0000000180BC0B30
		private static Vector2 WorldToRootLocal(RectTransform overlay, Vector3 world); // 0x0000000180BC0B30-0x0000000180BC0D00
		private static float DirOf(Vector2 caster, Vector2 target, bool atSelf); // 0x0000000180BC0D00-0x0000000180BC0D60
		private static float OverlayWidth(RectTransform overlay); // 0x0000000180BC0D60-0x0000000180BC0F30
		private static float EaseOut(float x); // 0x0000000180922B30-0x0000000180922B50
		private static Vector2 PillarCenter(Nodes n); // 0x0000000180BC0F30-0x0000000180BC1010
		private static Vector2 FanCenter(Nodes n); // 0x0000000180BC1010-0x0000000180BC1060
		private static Vector2 FanPos(Nodes n, int i); // 0x0000000180BC1060-0x0000000180BC1140
		private static float FanTilt(Nodes n, int i); // 0x0000000180BC1140-0x0000000180BC1180
		private static Vector2 RevealPos(Nodes n); // 0x0000000180BC1180-0x0000000180BC11D0
		private static Vector2 FallPos(Nodes n); // 0x0000000180BC11D0-0x0000000180BC1220
		private static Vector2 CounterPos(Nodes n); // 0x0000000180BC1220-0x0000000180BC1270
		private static float OrbitAngle(int i, float p); // 0x0000000180BC1270-0x0000000180BC12C0
		private static Vector2 OrbitPos(Nodes n, int i, float p); // 0x0000000180BC12C0-0x0000000180BC13E0
		private static void SpinRing(Nodes n); // 0x0000000180BC13E0-0x0000000180BC15E0
		private static void BlinkDoubled(Nodes n); // 0x0000000180BC15E0-0x0000000180BC1760
		private static int PickToIndex(string pick); // 0x0000000180BC1760-0x0000000180BC1A00
		private static Sprite LoadSprite(string path); // 0x0000000180BC1A00-0x0000000180BC1B40
		private static Image MakeImage(RectTransform parent, string name, string spritePath, Color fallback, Vector2 size, Func<string, Sprite> loader); // 0x0000000180BC1B40-0x0000000180BC20B0
		private static void TintKeepSprite(Image img, Color tint); // 0x0000000180BC20B0-0x0000000180BC2210
		private static UnityEngine.UI.Text MakeText(RectTransform parent, string name, string content, int fontSize, Color color, Nodes n); // 0x0000000180BC2210-0x0000000180BC2800
		private static void SetAlpha(Graphic g, float a); // 0x0000000180BC2800-0x0000000180BC2970
		private static void SafeDestroy(GameObject go); // 0x0000000180BC2970-0x0000000180BC2AD0
		private static Color Hex(uint rgb); // 0x0000000180BC2AD0-0x0000000180BC2B40
	}
}
