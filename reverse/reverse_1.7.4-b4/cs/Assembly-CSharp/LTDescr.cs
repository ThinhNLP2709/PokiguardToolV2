/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class LTDescr // TypeDefIndex: 302
{
	// Fields
	public bool toggle; // 0x10
	public bool useEstimatedTime; // 0x11
	public bool useFrames; // 0x12
	public bool useManualTime; // 0x13
	public bool usesNormalDt; // 0x14
	public bool hasInitiliazed; // 0x15
	public bool hasExtraOnCompletes; // 0x16
	public bool hasPhysics; // 0x17
	public bool onCompleteOnRepeat; // 0x18
	public bool onCompleteOnStart; // 0x19
	public bool useRecursion; // 0x1A
	public float ratioPassed; // 0x1C
	public float passed; // 0x20
	public float delay; // 0x24
	public float time; // 0x28
	public float speed; // 0x2C
	public float lastVal; // 0x30
	private uint _id; // 0x34
	public int loopCount; // 0x38
	public uint counter; // 0x3C
	public float direction; // 0x40
	public float directionLast; // 0x44
	public float overshoot; // 0x48
	public float period; // 0x4C
	public float scale; // 0x50
	public bool destroyOnComplete; // 0x54
	public Transform trans; // 0x58
	internal Vector3 fromInternal; // 0x60
	internal Vector3 toInternal; // 0x6C
	internal Vector3 diff; // 0x78
	internal Vector3 diffDiv2; // 0x84
	public TweenAction type; // 0x90
	private LeanTweenType easeType; // 0x94
	public LeanTweenType loopType; // 0x98
	public bool hasUpdateCallback; // 0x9C
	public EaseTypeDelegate easeMethod; // 0xA0
	[CompilerGenerated]
	private ActionMethodDelegate _easeInternal_k__BackingField; // 0xA8
	[CompilerGenerated]
	private ActionMethodDelegate _initInternal_k__BackingField; // 0xB0
	public SpriteRenderer spriteRen; // 0xB8
	public RectTransform rectTransform; // 0xC0
	public UnityEngine.UI.Text uiText; // 0xC8
	public Image uiImage; // 0xD0
	public RawImage rawImage; // 0xD8
	public Sprite[] sprites; // 0xE0
	public LTDescrOptional _optional; // 0xE8
	public static float val; // 0x00
	public static float dt; // 0x04
	public static Vector3 newVect; // 0x08

	// Properties
	public Vector3 from { get; set; } // 0x0000000180D93D40-0x0000000180D93D60 0x0000000180D93D60-0x0000000180D93D70
	public Vector3 to { get; set; } // 0x0000000180D93D70-0x0000000180D93D90 0x0000000180D93D90-0x0000000180D93DA0
	public ActionMethodDelegate easeInternal { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8EC0-0x00000001802D8ED0 0x00000001802D8ED0-0x00000001802D8F30
	public ActionMethodDelegate initInternal { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8F30-0x00000001802D8F40 0x00000001802D8F40-0x00000001802D8FA0
	public Transform toTrans { get; } // 0x0000000180D93DA0-0x0000000180D93DC0 
	public int uniqueId { get; } // 0x0000000180D94510-0x0000000180D94520 
	public int id { get; } // 0x0000000180D94510-0x0000000180D94520 
	public LTDescrOptional optional { get; } // 0x0000000180D94520-0x0000000180D94530 

	// Nested types
	public delegate Vector3 EaseTypeDelegate(); // TypeDefIndex: 303; 0x00000001802D88D0-0x00000001802D8910

	public delegate void ActionMethodDelegate(); // TypeDefIndex: 304; 0x00000001802B4BB0-0x00000001802B4BC0

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 305
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static ActionMethodDelegate __9__113_0; // 0x08
		public static ActionMethodDelegate __9__114_0; // 0x10

		// Constructors
		static __c(); // 0x00000001802D8A00-0x00000001802D8AA0
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _setCallback_b__113_0(); // 0x000000018028A320-0x000000018028A330
		internal void _setValue3_b__114_0(); // 0x000000018028A320-0x000000018028A330
	}

	// Constructors
	public LTDescr(); // 0x0000000180D94470-0x0000000180D94510

	// Methods
	public override string ToString(); // 0x0000000180D93DC0-0x0000000180D94470
	public void reset(); // 0x0000000180D94530-0x0000000180D94760
	public LTDescr setFollow(); // 0x0000000180D94760-0x0000000180D94770
	public LTDescr setMoveX(); // 0x0000000180D94770-0x0000000180D948F0
	public LTDescr setMoveY(); // 0x0000000180D948F0-0x0000000180D94A70
	public LTDescr setMoveZ(); // 0x0000000180D94A70-0x0000000180D94BF0
	public LTDescr setMoveLocalX(); // 0x0000000180D94BF0-0x0000000180D94D70
	public LTDescr setMoveLocalY(); // 0x0000000180D94D70-0x0000000180D94EF0
	public LTDescr setMoveLocalZ(); // 0x0000000180D94EF0-0x0000000180D95070
	private void initFromInternal(); // 0x0000000180D95070-0x0000000180D95080
	public LTDescr setOffset(Vector3 offset); // 0x0000000180D95080-0x0000000180D950A0
	public LTDescr setMoveCurved(); // 0x0000000180D950A0-0x0000000180D95220
	public LTDescr setMoveCurvedLocal(); // 0x0000000180D95220-0x0000000180D953A0
	public LTDescr setMoveSpline(); // 0x0000000180D953A0-0x0000000180D95520
	public LTDescr setMoveSplineLocal(); // 0x0000000180D95520-0x0000000180D956A0
	public LTDescr setScaleX(); // 0x0000000180D956A0-0x0000000180D95820
	public LTDescr setScaleY(); // 0x0000000180D95820-0x0000000180D959A0
	public LTDescr setScaleZ(); // 0x0000000180D959A0-0x0000000180D95B20
	public LTDescr setRotateX(); // 0x0000000180D95B20-0x0000000180D95CA0
	public LTDescr setRotateY(); // 0x0000000180D95CA0-0x0000000180D95E20
	public LTDescr setRotateZ(); // 0x0000000180D95E20-0x0000000180D95FA0
	public LTDescr setRotateAround(); // 0x0000000180D95FA0-0x0000000180D96120
	public LTDescr setRotateAroundLocal(); // 0x0000000180D96120-0x0000000180D962A0
	public LTDescr setAlpha(); // 0x0000000180D962A0-0x0000000180D96420
	public LTDescr setTextAlpha(); // 0x0000000180D96420-0x0000000180D965A0
	public LTDescr setAlphaVertex(); // 0x0000000180D965A0-0x0000000180D96720
	public LTDescr setColor(); // 0x0000000180D96720-0x0000000180D968A0
	public LTDescr setCallbackColor(); // 0x0000000180D968A0-0x0000000180D96A20
	public LTDescr setTextColor(); // 0x0000000180D96A20-0x0000000180D96BA0
	public LTDescr setCanvasAlpha(); // 0x0000000180D96BA0-0x0000000180D96D20
	public LTDescr setCanvasGroupAlpha(); // 0x0000000180D96D20-0x0000000180D96EA0
	public LTDescr setCanvasColor(); // 0x0000000180D96EA0-0x0000000180D97020
	public LTDescr setCanvasMoveX(); // 0x0000000180D97020-0x0000000180D971A0
	public LTDescr setCanvasMoveY(); // 0x0000000180D971A0-0x0000000180D97320
	public LTDescr setCanvasMoveZ(); // 0x0000000180D97320-0x0000000180D974A0
	private void initCanvasRotateAround(); // 0x0000000180D974A0-0x0000000180D97550
	public LTDescr setCanvasRotateAround(); // 0x0000000180D97550-0x0000000180D976D0
	public LTDescr setCanvasRotateAroundLocal(); // 0x0000000180D976D0-0x0000000180D97850
	public LTDescr setCanvasPlaySprite(); // 0x0000000180D97850-0x0000000180D979D0
	public LTDescr setCanvasMove(); // 0x0000000180D979D0-0x0000000180D97B50
	public LTDescr setCanvasScale(); // 0x0000000180D97B50-0x0000000180D97CD0
	public LTDescr setCanvasSizeDelta(); // 0x0000000180D97CD0-0x0000000180D97E50
	private void callback(); // 0x0000000180D97E50-0x0000000180D97EE0
	public LTDescr setCallback(); // 0x0000000180D97EE0-0x0000000180D98130
	public LTDescr setValue3(); // 0x0000000180D98130-0x0000000180D98380
	public LTDescr setMove(); // 0x0000000180D98380-0x0000000180D98500
	public LTDescr setMoveLocal(); // 0x0000000180D98500-0x0000000180D98680
	public LTDescr setMoveToTransform(); // 0x0000000180D98680-0x0000000180D98800
	public LTDescr setRotate(); // 0x0000000180D98800-0x0000000180D98980
	public LTDescr setRotateLocal(); // 0x0000000180D98980-0x0000000180D98B00
	public LTDescr setScale(); // 0x0000000180D98B00-0x0000000180D98C80
	public LTDescr setGUIMove(); // 0x0000000180D98C80-0x0000000180D98E00
	public LTDescr setGUIMoveMargin(); // 0x0000000180D98E00-0x0000000180D98F80
	public LTDescr setGUIScale(); // 0x0000000180D98F80-0x0000000180D99100
	public LTDescr setGUIAlpha(); // 0x0000000180D99100-0x0000000180D99280
	public LTDescr setGUIRotate(); // 0x0000000180D99280-0x0000000180D99400
	public LTDescr setDelayedSound(); // 0x0000000180D99400-0x0000000180D99580
	public LTDescr setTarget(Transform trans); // 0x0000000180D99580-0x0000000180D995F0
	private void init(); // 0x0000000180D995F0-0x0000000180D99780
	private void initSpeed(); // 0x0000000180D99780-0x0000000180D99880
	public LTDescr updateNow(); // 0x0000000180D99880-0x0000000180D998A0
	public bool updateInternal(); // 0x0000000180D998A0-0x0000000180D99E30
	public void callOnCompletes(); // 0x0000000180D99E30-0x0000000180D99F70
	public LTDescr setFromColor(Color col); // 0x0000000180D99F70-0x0000000180D99FE0
	private static void alphaRecursive(Transform transform, float val, bool useRecursion = true /* Metadata: 0x005EED96 */); // 0x0000000180D99FE0-0x0000000180D9A5A0
	private static void colorRecursive(Transform transform, Color toColor, bool useRecursion = true /* Metadata: 0x005EED97 */); // 0x0000000180D9A5A0-0x0000000180D9AA10
	private static void alphaRecursive(RectTransform rectTransform, float val, int recursiveLevel = 0 /* Metadata: 0x005EED98 */); // 0x0000000180D9AA10-0x0000000180D9AF80
	private static void alphaRecursiveSprite(Transform transform, float val); // 0x0000000180D9AF80-0x0000000180D9B510
	private static void colorRecursiveSprite(Transform transform, Color toColor); // 0x0000000180D9B510-0x0000000180D9BA20
	private static void colorRecursive(RectTransform rectTransform, Color toColor); // 0x0000000180D9BA20-0x0000000180D9BEE0
	private static void textAlphaChildrenRecursive(Transform trans, float val, bool useRecursion = true /* Metadata: 0x005EED99 */); // 0x0000000180D9BEE0-0x0000000180D9C310
	private static void textAlphaRecursive(Transform trans, float val, bool useRecursion = true /* Metadata: 0x005EED9A */); // 0x0000000180D9C310-0x0000000180D9C710
	private static void textColorRecursive(Transform trans, Color toColor); // 0x0000000180D9C710-0x0000000180D9CAF0
	private static Color tweenColor(LTDescr tween, float val); // 0x0000000180D9CAF0-0x0000000180D9CBC0
	public LTDescr pause(); // 0x0000000180D9CBC0-0x0000000180D9CBE0
	public LTDescr resume(); // 0x0000000180D9CBE0-0x0000000180D9CBF0
	public LTDescr setAxis(Vector3 axis); // 0x0000000180D9CBF0-0x0000000180D9CC20
	public LTDescr setDelay(float delay); // 0x0000000180D9CC20-0x0000000180D9CC30
	public LTDescr setEase(LeanTweenType easeType); // 0x0000000180D9CC30-0x0000000180D9DDC0
	public LTDescr setEaseLinear(); // 0x0000000180D9DDC0-0x0000000180D9DE90
	public LTDescr setEaseSpring(); // 0x0000000180D9DE90-0x0000000180D9DF60
	public LTDescr setEaseInQuad(); // 0x0000000180D9DF60-0x0000000180D9E030
	public LTDescr setEaseOutQuad(); // 0x0000000180D9E030-0x0000000180D9E100
	public LTDescr setEaseInOutQuad(); // 0x0000000180D9E100-0x0000000180D9E1D0
	public LTDescr setEaseInCubic(); // 0x0000000180D9E1D0-0x0000000180D9E2A0
	public LTDescr setEaseOutCubic(); // 0x0000000180D9E2A0-0x0000000180D9E370
	public LTDescr setEaseInOutCubic(); // 0x0000000180D9E370-0x0000000180D9E440
	public LTDescr setEaseInQuart(); // 0x0000000180D9E440-0x0000000180D9E510
	public LTDescr setEaseOutQuart(); // 0x0000000180D9E510-0x0000000180D9E5E0
	public LTDescr setEaseInOutQuart(); // 0x0000000180D9E5E0-0x0000000180D9E6B0
	public LTDescr setEaseInQuint(); // 0x0000000180D9E6B0-0x0000000180D9E780
	public LTDescr setEaseOutQuint(); // 0x0000000180D9E780-0x0000000180D9E850
	public LTDescr setEaseInOutQuint(); // 0x0000000180D9E850-0x0000000180D9E920
	public LTDescr setEaseInSine(); // 0x0000000180D9E920-0x0000000180D9E9F0
	public LTDescr setEaseOutSine(); // 0x0000000180D9E9F0-0x0000000180D9EAC0
	public LTDescr setEaseInOutSine(); // 0x0000000180D9EAC0-0x0000000180D9EB90
	public LTDescr setEaseInExpo(); // 0x0000000180D9EB90-0x0000000180D9EC60
	public LTDescr setEaseOutExpo(); // 0x0000000180D9EC60-0x0000000180D9ED30
	public LTDescr setEaseInOutExpo(); // 0x0000000180D9ED30-0x0000000180D9EE00
	public LTDescr setEaseInCirc(); // 0x0000000180D9EE00-0x0000000180D9EED0
	public LTDescr setEaseOutCirc(); // 0x0000000180D9EED0-0x0000000180D9EFA0
	public LTDescr setEaseInOutCirc(); // 0x0000000180D9EFA0-0x0000000180D9F070
	public LTDescr setEaseInBounce(); // 0x0000000180D9F070-0x0000000180D9F140
	public LTDescr setEaseOutBounce(); // 0x0000000180D9F140-0x0000000180D9F210
	public LTDescr setEaseInOutBounce(); // 0x0000000180D9F210-0x0000000180D9F2E0
	public LTDescr setEaseInBack(); // 0x0000000180D9F2E0-0x0000000180D9F3B0
	public LTDescr setEaseOutBack(); // 0x0000000180D9F3B0-0x0000000180D9F480
	public LTDescr setEaseInOutBack(); // 0x0000000180D9F480-0x0000000180D9F550
	public LTDescr setEaseInElastic(); // 0x0000000180D9F550-0x0000000180D9F620
	public LTDescr setEaseOutElastic(); // 0x0000000180D9F620-0x0000000180D9F6F0
	public LTDescr setEaseInOutElastic(); // 0x0000000180D9F6F0-0x0000000180D9F7C0
	public LTDescr setEasePunch(); // 0x0000000180D9F7C0-0x0000000180D9F960
	public LTDescr setEaseShake(); // 0x0000000180D9F960-0x0000000180D9FB00
	private Vector3 tweenOnCurve(); // 0x0000000180D9FB00-0x0000000180D9FD70
	private Vector3 easeInOutQuad(); // 0x0000000180D9FD70-0x0000000180D9FE90
	private Vector3 easeInQuad(); // 0x0000000180D9FE90-0x0000000180D9FF50
	private Vector3 easeOutQuad(); // 0x0000000180D9FF50-0x0000000180DA0030
	private Vector3 easeLinear(); // 0x0000000180DA0030-0x0000000180DA00E0
	private Vector3 easeSpring(); // 0x0000000180DA00E0-0x0000000180DA0250
	private Vector3 easeInCubic(); // 0x0000000180DA0250-0x0000000180DA0310
	private Vector3 easeOutCubic(); // 0x0000000180DA0310-0x0000000180DA03F0
	private Vector3 easeInOutCubic(); // 0x0000000180DA03F0-0x0000000180DA0510
	private Vector3 easeInQuart(); // 0x0000000180DA0510-0x0000000180DA05D0
	private Vector3 easeOutQuart(); // 0x0000000180DA05D0-0x0000000180DA06C0
	private Vector3 easeInOutQuart(); // 0x0000000180DA06C0-0x0000000180DA0860
	private Vector3 easeInQuint(); // 0x0000000180DA0860-0x0000000180DA0940
	private Vector3 easeOutQuint(); // 0x0000000180DA0940-0x0000000180DA0A30
	private Vector3 easeInOutQuint(); // 0x0000000180DA0A30-0x0000000180DA0B60
	private Vector3 easeInSine(); // 0x0000000180DA0B60-0x0000000180DA0C80
	private Vector3 easeOutSine(); // 0x0000000180DA0C80-0x0000000180DA0D80
	private Vector3 easeInOutSine(); // 0x0000000180DA0D80-0x0000000180DA0E50
	private Vector3 easeInExpo(); // 0x0000000180DA0E50-0x0000000180DA0F20
	private Vector3 easeOutExpo(); // 0x0000000180DA0F20-0x0000000180DA1000
	private Vector3 easeInOutExpo(); // 0x0000000180DA1000-0x0000000180DA1150
	private Vector3 easeInCirc(); // 0x0000000180DA1150-0x0000000180DA1240
	private Vector3 easeOutCirc(); // 0x0000000180DA1240-0x0000000180DA1350
	private Vector3 easeInOutCirc(); // 0x0000000180DA1350-0x0000000180DA14C0
	private Vector3 easeInBounce(); // 0x0000000180DA14C0-0x0000000180DA1650
	private Vector3 easeOutBounce(); // 0x0000000180DA1650-0x0000000180DA1890
	private Vector3 easeInOutBounce(); // 0x0000000180DA1890-0x0000000180DA1B10
	private Vector3 easeInBack(); // 0x0000000180DA1B10-0x0000000180DA1C10
	private Vector3 easeOutBack(); // 0x0000000180DA1C10-0x0000000180DA1D10
	private Vector3 easeInOutBack(); // 0x0000000180DA1D10-0x0000000180DA1EF0
	private Vector3 easeInElastic(); // 0x0000000180DA1EF0-0x0000000180DA2040
	private Vector3 easeOutElastic(); // 0x0000000180DA2040-0x0000000180DA2190
	private Vector3 easeInOutElastic(); // 0x0000000180DA2190-0x0000000180DA22E0
	public LTDescr setOvershoot(float overshoot); // 0x0000000180DA22E0-0x0000000180DA22F0
	public LTDescr setPeriod(float period); // 0x0000000180DA22F0-0x0000000180DA2300
	public LTDescr setScale(float scale); // 0x0000000180DA2300-0x0000000180DA2310
	public LTDescr setEase(AnimationCurve easeCurve); // 0x0000000180DA2310-0x0000000180DA2470
	public LTDescr setTo(Vector3 to); // 0x0000000180DA2470-0x0000000180DA24D0
	public LTDescr setTo(Transform to); // 0x0000000180D99580-0x0000000180D995F0
	public LTDescr setFrom(Vector3 from); // 0x0000000180DA24D0-0x0000000180DA25C0
	public LTDescr setFrom(float from); // 0x0000000180DA25C0-0x0000000180DA25F0
	public LTDescr setHasInitialized(bool has); // 0x0000000180DA25F0-0x0000000180DA2600
	public LTDescr setId(uint id, uint global_counter); // 0x0000000180DA2600-0x0000000180DA2610
	public LTDescr setTime(float time); // 0x0000000180DA2610-0x0000000180DA2630
	public LTDescr setSpeed(float speed); // 0x0000000180DA2630-0x0000000180DA2660
	public LTDescr setRepeat(int repeat); // 0x0000000180DA2660-0x0000000180DA26B0
	public LTDescr setUseEstimatedTime(bool useEstimatedTime); // 0x0000000180DA26B0-0x0000000180DA26C0
	public LTDescr setIgnoreTimeScale(bool useUnScaledTime); // 0x0000000180DA26B0-0x0000000180DA26C0
	public LTDescr setLoopCount(int loopCount); // 0x0000000180DA26C0-0x0000000180DA26E0
	public LTDescr setLoopClamp(); // 0x0000000180DA26E0-0x0000000180DA2700
	public LTDescr setLoopPingPong(); // 0x0000000180DA2700-0x0000000180DA2720
	public LTDescr setLoopPingPong(int loops); // 0x0000000180DA2720-0x0000000180DA2740
	public LTDescr setOnComplete(Action onComplete); // 0x0000000180DA2740-0x0000000180DA27C0
	public LTDescr setOnComplete(Action<object> onComplete); // 0x0000000180DA27C0-0x0000000180DA2840
	public LTDescr setOnCompleteParam(object onCompleteParam); // 0x0000000180DA2840-0x0000000180DA28C0
	public LTDescr setOnUpdate(Action<float> onUpdate); // 0x0000000180DA28C0-0x0000000180DA2940
	public LTDescr setOnUpdateRatio(Action<float, float> onUpdate); // 0x0000000180DA2940-0x0000000180DA29C0
	public LTDescr setOnUpdateVector2(Action<Vector2> onUpdate); // 0x0000000180DA29C0-0x0000000180DA2A40
	public LTDescr setOnUpdateVector3(Action<Vector3> onUpdate); // 0x0000000180DA2A40-0x0000000180DA2AC0
	public LTDescr setOnUpdateColor(Action<Color> onUpdate); // 0x0000000180DA2AC0-0x0000000180DA2B40
	public LTDescr setOnUpdateColor(Action<Color, object> onUpdate); // 0x0000000180DA2B40-0x0000000180DA2BC0
	public LTDescr setOnUpdate(Action<Color> onUpdate); // 0x0000000180DA2AC0-0x0000000180DA2B40
	public LTDescr setOnUpdate(Action<Color, object> onUpdate); // 0x0000000180DA2B40-0x0000000180DA2BC0
	public LTDescr setOnUpdate(Action<float, object> onUpdate, object onUpdateParam = null); // 0x0000000180DA2BC0-0x0000000180DA2CC0
	public LTDescr setOnUpdate(Action<Vector2> onUpdate, object onUpdateParam = null); // 0x0000000180DA2CC0-0x0000000180DA2DC0
	public LTDescr setOnUpdate(Action<Vector3> onUpdate, object onUpdateParam = null); // 0x0000000180DA2DC0-0x0000000180DA2EC0
	public LTDescr setOnUpdateParam(object onUpdateParam); // 0x0000000180DA2EC0-0x0000000180DA2F30
	public LTDescr setOrientToPath(bool doesOrient); // 0x0000000180DA2F30-0x0000000180DA3000
	public LTDescr setOrientToPath2d(bool doesOrient2d); // 0x0000000180DA3000-0x0000000180DA3080
	public LTDescr setRect(LTRect rect); // 0x0000000180DA3080-0x0000000180DA30F0
	public LTDescr setPoint(Vector3 point); // 0x0000000180DA30F0-0x0000000180DA3120
	public LTDescr setDestroyOnComplete(bool doesDestroy); // 0x0000000180DA3120-0x0000000180DA3130
	public LTDescr setAudio(object audio); // 0x0000000180DA3130-0x0000000180DA31A0
	public LTDescr setOnCompleteOnRepeat(bool isOn); // 0x0000000180DA31A0-0x0000000180DA31B0
	public LTDescr setOnCompleteOnStart(bool isOn); // 0x0000000180DA31B0-0x0000000180DA31C0
	public LTDescr setRect(RectTransform rect); // 0x0000000180DA31C0-0x0000000180DA3220
	public LTDescr setSprites(Sprite[] sprites); // 0x0000000180DA3220-0x0000000180DA3280
	public LTDescr setOnStart(Action onStart); // 0x0000000180DA3280-0x0000000180DA32F0
	public LTDescr setDirection(float direction); // 0x0000000180DA32F0-0x0000000180DA3540
	public LTDescr setRecursive(bool useRecursion); // 0x0000000180DA3540-0x0000000180DA3550
	[CompilerGenerated]
	private void _setMoveX_b__73_0(); // 0x0000000180DA3550-0x0000000180DA35F0
	[CompilerGenerated]
	private void _setMoveX_b__73_1(); // 0x0000000180DA35F0-0x0000000180DA37D0
	[CompilerGenerated]
	private void _setMoveY_b__74_0(); // 0x0000000180DA37D0-0x0000000180DA3870
	[CompilerGenerated]
	private void _setMoveY_b__74_1(); // 0x0000000180DA3870-0x0000000180DA3A40
	[CompilerGenerated]
	private void _setMoveZ_b__75_0(); // 0x0000000180DA3A40-0x0000000180DA3AE0
	[CompilerGenerated]
	private void _setMoveZ_b__75_1(); // 0x0000000180DA3AE0-0x0000000180DA3CA0
	[CompilerGenerated]
	private void _setMoveLocalX_b__76_0(); // 0x0000000180DA3CA0-0x0000000180DA3D40
	[CompilerGenerated]
	private void _setMoveLocalX_b__76_1(); // 0x0000000180DA3D40-0x0000000180DA3F20
	[CompilerGenerated]
	private void _setMoveLocalY_b__77_0(); // 0x0000000180DA3F20-0x0000000180DA3FC0
	[CompilerGenerated]
	private void _setMoveLocalY_b__77_1(); // 0x0000000180DA3FC0-0x0000000180DA4190
	[CompilerGenerated]
	private void _setMoveLocalZ_b__78_0(); // 0x0000000180DA4190-0x0000000180DA4230
	[CompilerGenerated]
	private void _setMoveLocalZ_b__78_1(); // 0x0000000180DA4230-0x0000000180DA43F0
	[CompilerGenerated]
	private void _setMoveCurved_b__81_0(); // 0x0000000180DA43F0-0x0000000180DA48D0
	[CompilerGenerated]
	private void _setMoveCurvedLocal_b__82_0(); // 0x0000000180DA48D0-0x0000000180DA4C80
	[CompilerGenerated]
	private void _setMoveSpline_b__83_0(); // 0x0000000180DA4C80-0x0000000180DA4E60
	[CompilerGenerated]
	private void _setMoveSplineLocal_b__84_0(); // 0x0000000180DA4E60-0x0000000180DA5070
	[CompilerGenerated]
	private void _setScaleX_b__85_0(); // 0x0000000180DA5070-0x0000000180DA5110
	[CompilerGenerated]
	private void _setScaleX_b__85_1(); // 0x0000000180DA5110-0x0000000180DA52F0
	[CompilerGenerated]
	private void _setScaleY_b__86_0(); // 0x0000000180DA52F0-0x0000000180DA5390
	[CompilerGenerated]
	private void _setScaleY_b__86_1(); // 0x0000000180DA5390-0x0000000180DA5560
	[CompilerGenerated]
	private void _setScaleZ_b__87_0(); // 0x0000000180DA5560-0x0000000180DA5600
	[CompilerGenerated]
	private void _setScaleZ_b__87_1(); // 0x0000000180DA5600-0x0000000180DA57C0
	[CompilerGenerated]
	private void _setRotateX_b__88_0(); // 0x0000000180DA57C0-0x0000000180DA58F0
	[CompilerGenerated]
	private void _setRotateX_b__88_1(); // 0x0000000180DA58F0-0x0000000180DA5AC0
	[CompilerGenerated]
	private void _setRotateY_b__89_0(); // 0x0000000180DA5AC0-0x0000000180DA5BF0
	[CompilerGenerated]
	private void _setRotateY_b__89_1(); // 0x0000000180DA5BF0-0x0000000180DA5DB0
	[CompilerGenerated]
	private void _setRotateZ_b__90_0(); // 0x0000000180DA5DB0-0x0000000180DA5EE0
	[CompilerGenerated]
	private void _setRotateZ_b__90_1(); // 0x0000000180DA5EE0-0x0000000180DA60A0
	[CompilerGenerated]
	private void _setRotateAround_b__91_0(); // 0x0000000180DA60A0-0x0000000180DA6140
	[CompilerGenerated]
	private void _setRotateAround_b__91_1(); // 0x0000000180DA6140-0x0000000180DA6620
	[CompilerGenerated]
	private void _setRotateAroundLocal_b__92_0(); // 0x0000000180DA6620-0x0000000180DA66C0
	[CompilerGenerated]
	private void _setRotateAroundLocal_b__92_1(); // 0x0000000180DA66C0-0x0000000180DA6CC0
	[CompilerGenerated]
	private void _setAlpha_b__93_0(); // 0x0000000180DA6CC0-0x0000000180DA7580
	[CompilerGenerated]
	private void _setAlpha_b__93_2(); // 0x0000000180DA7580-0x0000000180DA7930
	[CompilerGenerated]
	private void _setAlpha_b__93_1(); // 0x0000000180DA7930-0x0000000180DA7CF0
	[CompilerGenerated]
	private void _setTextAlpha_b__94_0(); // 0x0000000180DA7CF0-0x0000000180DA7EB0
	[CompilerGenerated]
	private void _setTextAlpha_b__94_1(); // 0x0000000180DA7EB0-0x0000000180DA7F10
	[CompilerGenerated]
	private void _setAlphaVertex_b__95_0(); // 0x0000000180DA7F10-0x0000000180DA7FF0
	[CompilerGenerated]
	private void _setAlphaVertex_b__95_1(); // 0x0000000180DA7FF0-0x0000000180DA8290
	[CompilerGenerated]
	private void _setColor_b__96_0(); // 0x0000000180DA8290-0x0000000180DA8BA0
	[CompilerGenerated]
	private void _setColor_b__96_1(); // 0x0000000180DA8BA0-0x0000000180DA9020
	[CompilerGenerated]
	private void _setCallbackColor_b__97_0(); // 0x0000000180DA9020-0x0000000180DA9040
	[CompilerGenerated]
	private void _setCallbackColor_b__97_1(); // 0x0000000180DA9040-0x0000000180DA94C0
	[CompilerGenerated]
	private void _setTextColor_b__98_0(); // 0x0000000180DA94C0-0x0000000180DA96C0
	[CompilerGenerated]
	private void _setTextColor_b__98_1(); // 0x0000000180DA96C0-0x0000000180DA99E0
	[CompilerGenerated]
	private void _setCanvasAlpha_b__99_0(); // 0x0000000180DA99E0-0x0000000180DA9CC0
	[CompilerGenerated]
	private void _setCanvasAlpha_b__99_1(); // 0x0000000180DA9CC0-0x0000000180DA9FE0
	[CompilerGenerated]
	private void _setCanvasGroupAlpha_b__100_0(); // 0x0000000180DA9FE0-0x0000000180DAA0A0
	[CompilerGenerated]
	private void _setCanvasGroupAlpha_b__100_1(); // 0x0000000180DAA0A0-0x0000000180DAA190
	[CompilerGenerated]
	private void _setCanvasColor_b__101_0(); // 0x0000000180DAA190-0x0000000180DAA4B0
	[CompilerGenerated]
	private void _setCanvasColor_b__101_1(); // 0x0000000180DAA4B0-0x0000000180DAA8C0
	[CompilerGenerated]
	private void _setCanvasMoveX_b__102_0(); // 0x0000000180DAA8C0-0x0000000180DAA980
	[CompilerGenerated]
	private void _setCanvasMoveX_b__102_1(); // 0x0000000180DAA980-0x0000000180DAAA90
	[CompilerGenerated]
	private void _setCanvasMoveY_b__103_0(); // 0x0000000180DAAA90-0x0000000180DAAB50
	[CompilerGenerated]
	private void _setCanvasMoveY_b__103_1(); // 0x0000000180DAAB50-0x0000000180DAAC60
	[CompilerGenerated]
	private void _setCanvasMoveZ_b__104_0(); // 0x0000000180DAAC60-0x0000000180DAAD10
	[CompilerGenerated]
	private void _setCanvasMoveZ_b__104_1(); // 0x0000000180DAAD10-0x0000000180DAAE30
	[CompilerGenerated]
	private void _setCanvasRotateAround_b__106_0(); // 0x0000000180DAAE30-0x0000000180DAB2D0
	[CompilerGenerated]
	private void _setCanvasRotateAroundLocal_b__107_0(); // 0x0000000180DAB2D0-0x0000000180DAB870
	[CompilerGenerated]
	private void _setCanvasPlaySprite_b__108_0(); // 0x0000000180DAB870-0x0000000180DAB920
	[CompilerGenerated]
	private void _setCanvasPlaySprite_b__108_1(); // 0x0000000180DAB920-0x0000000180DABA00
	[CompilerGenerated]
	private void _setCanvasMove_b__109_0(); // 0x0000000180DABA00-0x0000000180DABAD0
	[CompilerGenerated]
	private void _setCanvasMove_b__109_1(); // 0x0000000180DABAD0-0x0000000180DABB30
	[CompilerGenerated]
	private void _setCanvasScale_b__110_0(); // 0x0000000180DABB30-0x0000000180DABBD0
	[CompilerGenerated]
	private void _setCanvasScale_b__110_1(); // 0x0000000180DABBD0-0x0000000180DABC90
	[CompilerGenerated]
	private void _setCanvasSizeDelta_b__111_0(); // 0x0000000180DABC90-0x0000000180DABCE0
	[CompilerGenerated]
	private void _setCanvasSizeDelta_b__111_1(); // 0x0000000180DABCE0-0x0000000180DABD40
	[CompilerGenerated]
	private void _setMove_b__115_0(); // 0x0000000180DABD40-0x0000000180DABDE0
	[CompilerGenerated]
	private void _setMove_b__115_1(); // 0x0000000180DABDE0-0x0000000180DABEF0
	[CompilerGenerated]
	private void _setMoveLocal_b__116_0(); // 0x0000000180DABEF0-0x0000000180DABF90
	[CompilerGenerated]
	private void _setMoveLocal_b__116_1(); // 0x0000000180DABF90-0x0000000180DAC0A0
	[CompilerGenerated]
	private void _setMoveToTransform_b__117_0(); // 0x0000000180DABD40-0x0000000180DABDE0
	[CompilerGenerated]
	private void _setMoveToTransform_b__117_1(); // 0x0000000180DAC0A0-0x0000000180DAC2C0
	[CompilerGenerated]
	private void _setRotate_b__118_0(); // 0x0000000180DAC2C0-0x0000000180DAC450
	[CompilerGenerated]
	private void _setRotate_b__118_1(); // 0x0000000180DAC450-0x0000000180DAC500
	[CompilerGenerated]
	private void _setRotateLocal_b__119_0(); // 0x0000000180DAC500-0x0000000180DAC690
	[CompilerGenerated]
	private void _setRotateLocal_b__119_1(); // 0x0000000180DAC690-0x0000000180DAC740
	[CompilerGenerated]
	private void _setScale_b__120_0(); // 0x0000000180DAC740-0x0000000180DAC7E0
	[CompilerGenerated]
	private void _setScale_b__120_1(); // 0x0000000180DAC7E0-0x0000000180DAC8F0
	[CompilerGenerated]
	private void _setGUIMove_b__121_0(); // 0x0000000180DAC8F0-0x0000000180DAC9B0
	[CompilerGenerated]
	private void _setGUIMove_b__121_1(); // 0x0000000180DAC9B0-0x0000000180DACAD0
	[CompilerGenerated]
	private void _setGUIMoveMargin_b__122_0(); // 0x0000000180DACAD0-0x0000000180DACB10
	[CompilerGenerated]
	private void _setGUIMoveMargin_b__122_1(); // 0x0000000180DACB10-0x0000000180DACB80
	[CompilerGenerated]
	private void _setGUIScale_b__123_0(); // 0x0000000180DACB80-0x0000000180DACC40
	[CompilerGenerated]
	private void _setGUIScale_b__123_1(); // 0x0000000180DACC40-0x0000000180DACD60
	[CompilerGenerated]
	private void _setGUIAlpha_b__124_0(); // 0x0000000180DACD60-0x0000000180DACD90
	[CompilerGenerated]
	private void _setGUIAlpha_b__124_1(); // 0x0000000180DACD90-0x0000000180DACDF0
	[CompilerGenerated]
	private void _setGUIRotate_b__125_0(); // 0x0000000180DACDF0-0x0000000180DACE70
	[CompilerGenerated]
	private void _setGUIRotate_b__125_1(); // 0x0000000180DACE70-0x0000000180DACED0
	[CompilerGenerated]
	private void _setDelayedSound_b__126_0(); // 0x0000000180DACED0-0x0000000180DACEE0
}

