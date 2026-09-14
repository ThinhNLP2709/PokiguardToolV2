/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokiGuard.Audition
{
	public sealed class AuditionStage // TypeDefIndex: 2542
	{
		// Fields
		[CompilerGenerated]
		private static AuditionStage _Active_k__BackingField; // 0x00
		[CompilerGenerated]
		private IAuditionHost _Host_k__BackingField; // 0x10
		[CompilerGenerated]
		private bool _Disposed_k__BackingField; // 0x18
		[CompilerGenerated]
		private bool _Tapped_k__BackingField; // 0x19
		[CompilerGenerated]
		private int _TapElapsedMs_k__BackingField; // 0x1C
		[CompilerGenerated]
		private int _CorrectCount_k__BackingField; // 0x20
		public Action<string> PressCallback; // 0x28
		public Action<int> TapCallback; // 0x30
		private AuditionStyle _st; // 0x38
		private AuditionChallenge _ch; // 0x40
		private bool _fx; // 0x48
		private bool _shake; // 0x49
		private bool _sfx; // 0x4A
		private RectTransform _root; // 0x50
		private Image _scrim; // 0x58
		private CanvasGroup _pillGroup; // 0x60
		private RectTransform _pill; // 0x68
		private Image _touchBarImg; // 0x70
		private Image _trackImg; // 0x78
		private RectTransform _disc; // 0x80
		private Image _discImg; // 0x88
		private UnityEngine.UI.Text _touchText; // 0x90
		private RectTransform _touchTextRt; // 0x98
		private Image _perfectStar; // 0xA0
		private Image _btnLeftFace; // 0xA8
		private Image _btnRightFace; // 0xB0
		private Sprite _btnLeftUp; // 0xB8
		private Sprite _btnLeftDown; // 0xC0
		private Sprite _btnRightUp; // 0xC8
		private Sprite _btnRightDown; // 0xD0
		private readonly Image[] _pressGlow; // 0xD8
		private readonly float[] _pressGlowAt; // 0xE0
		private Image _screenFlash; // 0xE8
		private UnityEngine.UI.Text _word; // 0xF0
		private RectTransform _wordRt; // 0xF8
		private UnityEngine.UI.Text _sub; // 0x100
		private Image[] _resultStars; // 0x108
		private ArrowNode[] _arrows; // 0x110
		private int _cursor; // 0x118
		private RectTransform[] _sparkRt; // 0x120
		private Vector2[] _sparkPos; // 0x128
		private Vector2[] _sparkVel; // 0x130
		private Image[] _sparkImg; // 0x138
		private int _sparkAlive; // 0x140
		private float _sparkBornAt; // 0x144
		private float _ui; // 0x148
		private float _qteElapsed; // 0x14C
		private float _durSec; // 0x150
		private int _durMs; // 0x154
		private bool _wasPerfect; // 0x158
		private bool _scrimDone; // 0x159
		private float _resultAt; // 0x15C
		private float _resultFadeAt; // 0x160
		private string _grade; // 0x168
		private static readonly Color PressedTint; // 0x08
		private static readonly Color GoodZoneTint; // 0x18
		private static readonly Color TrackIdle; // 0x28
		private static readonly Color TrackTapped; // 0x38
		private static readonly Color StarIdle; // 0x48
	
		// Properties
		public static AuditionStage Active { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180BBBE20-0x0000000180BBBE80 0x0000000180BBBE80-0x0000000180BBBF30
		public IAuditionHost Host { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802D8A70-0x00000001802D8A80 0x00000001802D8A80-0x00000001802D8AE0
		public bool Disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180BBBF30-0x0000000180BBBF40 0x00000001808D7CA0-0x00000001808D7CB0
		public bool Tapped { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180BBBF40-0x0000000180BBBF50 0x0000000180BBBF50-0x0000000180BBBF60
		public int TapElapsedMs { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180BBBF60-0x0000000180BBBF70 0x0000000180BBBF70-0x0000000180BBBF80
		public int CorrectCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180BBBF80-0x0000000180BBBF90 0x0000000180BBBF90-0x0000000180BBBFA0
	
		// Nested types
		private struct ArrowNode // TypeDefIndex: 2543
		{
			// Fields
			public RectTransform Rt; // 0x00
			public Image Circle; // 0x08
			public Image Glyph; // 0x10
			public Image Flash; // 0x18
			public Image Ring; // 0x20
			public Vector2 Home; // 0x28
			public byte State; // 0x30
			public float HitAt; // 0x34
			public float WrongAt; // 0x38
			public bool Legacy; // 0x3C
			public Sprite DoneSprite; // 0x40
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass101_0 // TypeDefIndex: 2544
		{
			// Fields
			public Image faceImg; // 0x10
			public Sprite face; // 0x18
			public Sprite downSp; // 0x20
			public AuditionStage __4__this; // 0x28
			public int slot; // 0x30
			public string dir; // 0x38
	
			// Constructors
			public __c__DisplayClass101_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _BuildOneButton_b__0(BaseEventData _); // 0x0000000180BC83E0-0x0000000180BC8610
			internal void _BuildOneButton_b__1(BaseEventData _); // 0x0000000180BC8610-0x0000000180BC8690
			internal void _BuildOneButton_b__2(BaseEventData _); // 0x0000000180BC8690-0x0000000180BC8710
		}
	
		// Constructors
		public AuditionStage(); // 0x0000000180BC81A0-0x0000000180BC8330
		static AuditionStage(); // 0x0000000180BC8330-0x0000000180BC83E0
	
		// Methods
		public bool Build(IAuditionHost host, AuditionStyle style, AuditionChallenge ch); // 0x0000000180BBBFA0-0x0000000180BBC720
		private void BuildScrim(); // 0x0000000180BBC720-0x0000000180BBC880
		private void BuildPill(); // 0x0000000180BBC880-0x0000000180BBDF10
		private void BuildTouchBar(); // 0x0000000180BBDF10-0x0000000180BBEE10
		private void AddZone(RectTransform track, int fromMs, int toMs, Sprite sp, Color col, string name); // 0x0000000180BBEE10-0x0000000180BBF030
		private void BuildButtons(); // 0x0000000180BBF030-0x0000000180BBF5D0
		private Image BuildPressGlow(RectTransform holder, float w, float h); // 0x0000000180BBF5D0-0x0000000180BBF8F0
		private void FirePressGlow(int slot); // 0x0000000180BBF8F0-0x0000000180BBFA90
		private void TickPressGlow(); // 0x0000000180BBFA90-0x0000000180BBFE20
		private Image BuildOneButton(string name, Vector2 anchor, Vector2 pos, Sprite face, bool flipGlyph, string dir); // 0x0000000180BBFE20-0x0000000180BC0BA0
		private void BuildResult(); // 0x0000000180BC0BA0-0x0000000180BC21B0
		private void BuildFxLayers(); // 0x0000000180BC21B0-0x0000000180BC2C60
		public void PressDir(string dir); // 0x0000000180BC2C60-0x0000000180BC2EF0
		private void ApplyDoneVisual(int i); // 0x0000000180BC2EF0-0x0000000180BC3160
		public void TapBar(); // 0x0000000180BC3160-0x0000000180BC3420
		public void Tick(float qteElapsedSec, float dt); // 0x0000000180BC3420-0x0000000180BC3750
		private void TickScrim(); // 0x0000000180BC3750-0x0000000180BC3930
		private void TickPill(); // 0x0000000180BC3930-0x0000000180BC3CE0
		private void TickArrows(); // 0x0000000180BC3CE0-0x0000000180BC4A00
		private void TickBar(); // 0x0000000180BC4A00-0x0000000180BC50C0
		private void TickResult(); // 0x0000000180BC50C0-0x0000000180BC57E0
		private void TickSparks(float dt); // 0x0000000180BC57E0-0x0000000180BC5D50
		public void ShowResult(string grade, int correct, int total, float mult, float tailSec); // 0x0000000180BC5D50-0x0000000180BC6500
		private void SpawnSparks(int n); // 0x0000000180BC6500-0x0000000180BC69D0
		private string GradeText(string g); // 0x0000000180BC69D0-0x0000000180BC6BD0
		private Color GradeColor(string g); // 0x0000000180BC6BD0-0x0000000180BC6DC0
		private Color WaitColor(int i, bool legacy); // 0x0000000180BC6DC0-0x0000000180BC6F10
		private static void SetPressed(Image face, bool pressed, Sprite upSp, Sprite downSp); // 0x0000000180BC6F10-0x0000000180BC73D0
		private static void SetPressed(Image face, bool pressed); // 0x0000000180BC73D0-0x0000000180BC7520
		public void Dispose(); // 0x0000000180BC7520-0x0000000180BC79D0
		private static void Stretch(RectTransform rt); // 0x0000000180799B40-0x0000000180799C30
		private static Image NewImage(string name, Transform parent, Sprite sp, Color col, Image.Type type); // 0x0000000180BC79D0-0x0000000180BC7D20
		private static UnityEngine.UI.Text NewText(string name, Transform parent, string content, int size, Color col, TextAnchor anchor); // 0x0000000180BC7D20-0x0000000180BC80F0
		private static void AddOutline(UnityEngine.UI.Text t, Color col, float dist); // 0x0000000180BC80F0-0x0000000180BC81A0
	}
}
