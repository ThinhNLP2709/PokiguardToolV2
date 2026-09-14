/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

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
	public Vector3 from { get; set; } // 0x0000000180D85F60-0x0000000180D85F80 0x0000000180D85F80-0x0000000180D85F90
	public Vector3 to { get; set; } // 0x0000000180D85F90-0x0000000180D85FB0 0x0000000180D85FB0-0x0000000180D85FC0
	public ActionMethodDelegate easeInternal { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8E90-0x00000001802D8EA0 0x00000001802D8EA0-0x00000001802D8F00
	public ActionMethodDelegate initInternal { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802D8F00-0x00000001802D8F10 0x00000001802D8F10-0x00000001802D8F70
	public Transform toTrans { get; } // 0x0000000180D85FC0-0x0000000180D85FE0 
	public int uniqueId { get; } // 0x0000000180D86730-0x0000000180D86740 
	public int id { get; } // 0x0000000180D86730-0x0000000180D86740 
	public LTDescrOptional optional { get; } // 0x0000000180D86740-0x0000000180D86750 

	// Nested types
	public delegate Vector3 EaseTypeDelegate(); // TypeDefIndex: 303; 0x00000001802D88A0-0x00000001802D88E0

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
		static __c(); // 0x00000001802D89D0-0x00000001802D8A70
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _setCallback_b__113_0(); // 0x000000018028A320-0x000000018028A330
		internal void _setValue3_b__114_0(); // 0x000000018028A320-0x000000018028A330
	}

	// Constructors
	public LTDescr(); // 0x0000000180D86690-0x0000000180D86730

	// Methods
	public override string ToString(); // 0x0000000180D85FE0-0x0000000180D86690
	public void reset(); // 0x0000000180D86750-0x0000000180D86980
	public LTDescr setFollow(); // 0x0000000180D86980-0x0000000180D86990
	public LTDescr setMoveX(); // 0x0000000180D86990-0x0000000180D86B10
	public LTDescr setMoveY(); // 0x0000000180D86B10-0x0000000180D86C90
	public LTDescr setMoveZ(); // 0x0000000180D86C90-0x0000000180D86E10
	public LTDescr setMoveLocalX(); // 0x0000000180D86E10-0x0000000180D86F90
	public LTDescr setMoveLocalY(); // 0x0000000180D86F90-0x0000000180D87110
	public LTDescr setMoveLocalZ(); // 0x0000000180D87110-0x0000000180D87290
	private void initFromInternal(); // 0x0000000180D87290-0x0000000180D872A0
	public LTDescr setOffset(Vector3 offset); // 0x0000000180D872A0-0x0000000180D872C0
	public LTDescr setMoveCurved(); // 0x0000000180D872C0-0x0000000180D87440
	public LTDescr setMoveCurvedLocal(); // 0x0000000180D87440-0x0000000180D875C0
	public LTDescr setMoveSpline(); // 0x0000000180D875C0-0x0000000180D87740
	public LTDescr setMoveSplineLocal(); // 0x0000000180D87740-0x0000000180D878C0
	public LTDescr setScaleX(); // 0x0000000180D878C0-0x0000000180D87A40
	public LTDescr setScaleY(); // 0x0000000180D87A40-0x0000000180D87BC0
	public LTDescr setScaleZ(); // 0x0000000180D87BC0-0x0000000180D87D40
	public LTDescr setRotateX(); // 0x0000000180D87D40-0x0000000180D87EC0
	public LTDescr setRotateY(); // 0x0000000180D87EC0-0x0000000180D88040
	public LTDescr setRotateZ(); // 0x0000000180D88040-0x0000000180D881C0
	public LTDescr setRotateAround(); // 0x0000000180D881C0-0x0000000180D88340
	public LTDescr setRotateAroundLocal(); // 0x0000000180D88340-0x0000000180D884C0
	public LTDescr setAlpha(); // 0x0000000180D884C0-0x0000000180D88640
	public LTDescr setTextAlpha(); // 0x0000000180D88640-0x0000000180D887C0
	public LTDescr setAlphaVertex(); // 0x0000000180D887C0-0x0000000180D88940
	public LTDescr setColor(); // 0x0000000180D88940-0x0000000180D88AC0
	public LTDescr setCallbackColor(); // 0x0000000180D88AC0-0x0000000180D88C40
	public LTDescr setTextColor(); // 0x0000000180D88C40-0x0000000180D88DC0
	public LTDescr setCanvasAlpha(); // 0x0000000180D88DC0-0x0000000180D88F40
	public LTDescr setCanvasGroupAlpha(); // 0x0000000180D88F40-0x0000000180D890C0
	public LTDescr setCanvasColor(); // 0x0000000180D890C0-0x0000000180D89240
	public LTDescr setCanvasMoveX(); // 0x0000000180D89240-0x0000000180D893C0
	public LTDescr setCanvasMoveY(); // 0x0000000180D893C0-0x0000000180D89540
	public LTDescr setCanvasMoveZ(); // 0x0000000180D89540-0x0000000180D896C0
	private void initCanvasRotateAround(); // 0x0000000180D896C0-0x0000000180D89770
	public LTDescr setCanvasRotateAround(); // 0x0000000180D89770-0x0000000180D898F0
	public LTDescr setCanvasRotateAroundLocal(); // 0x0000000180D898F0-0x0000000180D89A70
	public LTDescr setCanvasPlaySprite(); // 0x0000000180D89A70-0x0000000180D89BF0
	public LTDescr setCanvasMove(); // 0x0000000180D89BF0-0x0000000180D89D70
	public LTDescr setCanvasScale(); // 0x0000000180D89D70-0x0000000180D89EF0
	public LTDescr setCanvasSizeDelta(); // 0x0000000180D89EF0-0x0000000180D8A070
	private void callback(); // 0x0000000180D8A070-0x0000000180D8A100
	public LTDescr setCallback(); // 0x0000000180D8A100-0x0000000180D8A350
	public LTDescr setValue3(); // 0x0000000180D8A350-0x0000000180D8A5A0
	public LTDescr setMove(); // 0x0000000180D8A5A0-0x0000000180D8A720
	public LTDescr setMoveLocal(); // 0x0000000180D8A720-0x0000000180D8A8A0
	public LTDescr setMoveToTransform(); // 0x0000000180D8A8A0-0x0000000180D8AA20
	public LTDescr setRotate(); // 0x0000000180D8AA20-0x0000000180D8ABA0
	public LTDescr setRotateLocal(); // 0x0000000180D8ABA0-0x0000000180D8AD20
	public LTDescr setScale(); // 0x0000000180D8AD20-0x0000000180D8AEA0
	public LTDescr setGUIMove(); // 0x0000000180D8AEA0-0x0000000180D8B020
	public LTDescr setGUIMoveMargin(); // 0x0000000180D8B020-0x0000000180D8B1A0
	public LTDescr setGUIScale(); // 0x0000000180D8B1A0-0x0000000180D8B320
	public LTDescr setGUIAlpha(); // 0x0000000180D8B320-0x0000000180D8B4A0
	public LTDescr setGUIRotate(); // 0x0000000180D8B4A0-0x0000000180D8B620
	public LTDescr setDelayedSound(); // 0x0000000180D8B620-0x0000000180D8B7A0
	public LTDescr setTarget(Transform trans); // 0x0000000180D8B7A0-0x0000000180D8B810
	private void init(); // 0x0000000180D8B810-0x0000000180D8B9A0
	private void initSpeed(); // 0x0000000180D8B9A0-0x0000000180D8BAA0
	public LTDescr updateNow(); // 0x0000000180D8BAA0-0x0000000180D8BAC0
	public bool updateInternal(); // 0x0000000180D8BAC0-0x0000000180D8C050
	public void callOnCompletes(); // 0x0000000180D8C050-0x0000000180D8C190
	public LTDescr setFromColor(Color col); // 0x0000000180D8C190-0x0000000180D8C200
	private static void alphaRecursive(Transform transform, float val, bool useRecursion = true /* Metadata: 0x005ED9C6 */); // 0x0000000180D8C200-0x0000000180D8C7C0
	private static void colorRecursive(Transform transform, Color toColor, bool useRecursion = true /* Metadata: 0x005ED9C7 */); // 0x0000000180D8C7C0-0x0000000180D8CC30
	private static void alphaRecursive(RectTransform rectTransform, float val, int recursiveLevel = 0 /* Metadata: 0x005ED9C8 */); // 0x0000000180D8CC30-0x0000000180D8D1A0
	private static void alphaRecursiveSprite(Transform transform, float val); // 0x0000000180D8D1A0-0x0000000180D8D730
	private static void colorRecursiveSprite(Transform transform, Color toColor); // 0x0000000180D8D730-0x0000000180D8DC40
	private static void colorRecursive(RectTransform rectTransform, Color toColor); // 0x0000000180D8DC40-0x0000000180D8E100
	private static void textAlphaChildrenRecursive(Transform trans, float val, bool useRecursion = true /* Metadata: 0x005ED9C9 */); // 0x0000000180D8E100-0x0000000180D8E530
	private static void textAlphaRecursive(Transform trans, float val, bool useRecursion = true /* Metadata: 0x005ED9CA */); // 0x0000000180D8E530-0x0000000180D8E930
	private static void textColorRecursive(Transform trans, Color toColor); // 0x0000000180D8E930-0x0000000180D8ED10
	private static Color tweenColor(LTDescr tween, float val); // 0x0000000180D8ED10-0x0000000180D8EDE0
	public LTDescr pause(); // 0x0000000180D8EDE0-0x0000000180D8EE00
	public LTDescr resume(); // 0x0000000180D8EE00-0x0000000180D8EE10
	public LTDescr setAxis(Vector3 axis); // 0x0000000180D8EE10-0x0000000180D8EE40
	public LTDescr setDelay(float delay); // 0x0000000180D8EE40-0x0000000180D8EE50
	public LTDescr setEase(LeanTweenType easeType); // 0x0000000180D8EE50-0x0000000180D8FFE0
	public LTDescr setEaseLinear(); // 0x0000000180D8FFE0-0x0000000180D900B0
	public LTDescr setEaseSpring(); // 0x0000000180D900B0-0x0000000180D90180
	public LTDescr setEaseInQuad(); // 0x0000000180D90180-0x0000000180D90250
	public LTDescr setEaseOutQuad(); // 0x0000000180D90250-0x0000000180D90320
	public LTDescr setEaseInOutQuad(); // 0x0000000180D90320-0x0000000180D903F0
	public LTDescr setEaseInCubic(); // 0x0000000180D903F0-0x0000000180D904C0
	public LTDescr setEaseOutCubic(); // 0x0000000180D904C0-0x0000000180D90590
	public LTDescr setEaseInOutCubic(); // 0x0000000180D90590-0x0000000180D90660
	public LTDescr setEaseInQuart(); // 0x0000000180D90660-0x0000000180D90730
	public LTDescr setEaseOutQuart(); // 0x0000000180D90730-0x0000000180D90800
	public LTDescr setEaseInOutQuart(); // 0x0000000180D90800-0x0000000180D908D0
	public LTDescr setEaseInQuint(); // 0x0000000180D908D0-0x0000000180D909A0
	public LTDescr setEaseOutQuint(); // 0x0000000180D909A0-0x0000000180D90A70
	public LTDescr setEaseInOutQuint(); // 0x0000000180D90A70-0x0000000180D90B40
	public LTDescr setEaseInSine(); // 0x0000000180D90B40-0x0000000180D90C10
	public LTDescr setEaseOutSine(); // 0x0000000180D90C10-0x0000000180D90CE0
	public LTDescr setEaseInOutSine(); // 0x0000000180D90CE0-0x0000000180D90DB0
	public LTDescr setEaseInExpo(); // 0x0000000180D90DB0-0x0000000180D90E80
	public LTDescr setEaseOutExpo(); // 0x0000000180D90E80-0x0000000180D90F50
	public LTDescr setEaseInOutExpo(); // 0x0000000180D90F50-0x0000000180D91020
	public LTDescr setEaseInCirc(); // 0x0000000180D91020-0x0000000180D910F0
	public LTDescr setEaseOutCirc(); // 0x0000000180D910F0-0x0000000180D911C0
	public LTDescr setEaseInOutCirc(); // 0x0000000180D911C0-0x0000000180D91290
	public LTDescr setEaseInBounce(); // 0x0000000180D91290-0x0000000180D91360
	public LTDescr setEaseOutBounce(); // 0x0000000180D91360-0x0000000180D91430
	public LTDescr setEaseInOutBounce(); // 0x0000000180D91430-0x0000000180D91500
	public LTDescr setEaseInBack(); // 0x0000000180D91500-0x0000000180D915D0
	public LTDescr setEaseOutBack(); // 0x0000000180D915D0-0x0000000180D916A0
	public LTDescr setEaseInOutBack(); // 0x0000000180D916A0-0x0000000180D91770
	public LTDescr setEaseInElastic(); // 0x0000000180D91770-0x0000000180D91840
	public LTDescr setEaseOutElastic(); // 0x0000000180D91840-0x0000000180D91910
	public LTDescr setEaseInOutElastic(); // 0x0000000180D91910-0x0000000180D919E0
	public LTDescr setEasePunch(); // 0x0000000180D919E0-0x0000000180D91B80
	public LTDescr setEaseShake(); // 0x0000000180D91B80-0x0000000180D91D20
	private Vector3 tweenOnCurve(); // 0x0000000180D91D20-0x0000000180D91F90
	private Vector3 easeInOutQuad(); // 0x0000000180D91F90-0x0000000180D920B0
	private Vector3 easeInQuad(); // 0x0000000180D920B0-0x0000000180D92170
	private Vector3 easeOutQuad(); // 0x0000000180D92170-0x0000000180D92250
	private Vector3 easeLinear(); // 0x0000000180D92250-0x0000000180D92300
	private Vector3 easeSpring(); // 0x0000000180D92300-0x0000000180D92470
	private Vector3 easeInCubic(); // 0x0000000180D92470-0x0000000180D92530
	private Vector3 easeOutCubic(); // 0x0000000180D92530-0x0000000180D92610
	private Vector3 easeInOutCubic(); // 0x0000000180D92610-0x0000000180D92730
	private Vector3 easeInQuart(); // 0x0000000180D92730-0x0000000180D927F0
	private Vector3 easeOutQuart(); // 0x0000000180D927F0-0x0000000180D928E0
	private Vector3 easeInOutQuart(); // 0x0000000180D928E0-0x0000000180D92A80
	private Vector3 easeInQuint(); // 0x0000000180D92A80-0x0000000180D92B60
	private Vector3 easeOutQuint(); // 0x0000000180D92B60-0x0000000180D92C50
	private Vector3 easeInOutQuint(); // 0x0000000180D92C50-0x0000000180D92D80
	private Vector3 easeInSine(); // 0x0000000180D92D80-0x0000000180D92EA0
	private Vector3 easeOutSine(); // 0x0000000180D92EA0-0x0000000180D92FA0
	private Vector3 easeInOutSine(); // 0x0000000180D92FA0-0x0000000180D93070
	private Vector3 easeInExpo(); // 0x0000000180D93070-0x0000000180D93140
	private Vector3 easeOutExpo(); // 0x0000000180D93140-0x0000000180D93220
	private Vector3 easeInOutExpo(); // 0x0000000180D93220-0x0000000180D93370
	private Vector3 easeInCirc(); // 0x0000000180D93370-0x0000000180D93460
	private Vector3 easeOutCirc(); // 0x0000000180D93460-0x0000000180D93570
	private Vector3 easeInOutCirc(); // 0x0000000180D93570-0x0000000180D936E0
	private Vector3 easeInBounce(); // 0x0000000180D936E0-0x0000000180D93870
	private Vector3 easeOutBounce(); // 0x0000000180D93870-0x0000000180D93AB0
	private Vector3 easeInOutBounce(); // 0x0000000180D93AB0-0x0000000180D93D30
	private Vector3 easeInBack(); // 0x0000000180D93D30-0x0000000180D93E30
	private Vector3 easeOutBack(); // 0x0000000180D93E30-0x0000000180D93F30
	private Vector3 easeInOutBack(); // 0x0000000180D93F30-0x0000000180D94110
	private Vector3 easeInElastic(); // 0x0000000180D94110-0x0000000180D94260
	private Vector3 easeOutElastic(); // 0x0000000180D94260-0x0000000180D943B0
	private Vector3 easeInOutElastic(); // 0x0000000180D943B0-0x0000000180D94500
	public LTDescr setOvershoot(float overshoot); // 0x0000000180D94500-0x0000000180D94510
	public LTDescr setPeriod(float period); // 0x0000000180D94510-0x0000000180D94520
	public LTDescr setScale(float scale); // 0x0000000180D94520-0x0000000180D94530
	public LTDescr setEase(AnimationCurve easeCurve); // 0x0000000180D94530-0x0000000180D94690
	public LTDescr setTo(Vector3 to); // 0x0000000180D94690-0x0000000180D946F0
	public LTDescr setTo(Transform to); // 0x0000000180D8B7A0-0x0000000180D8B810
	public LTDescr setFrom(Vector3 from); // 0x0000000180D946F0-0x0000000180D947E0
	public LTDescr setFrom(float from); // 0x0000000180D947E0-0x0000000180D94810
	public LTDescr setHasInitialized(bool has); // 0x0000000180D94810-0x0000000180D94820
	public LTDescr setId(uint id, uint global_counter); // 0x0000000180D94820-0x0000000180D94830
	public LTDescr setTime(float time); // 0x0000000180D94830-0x0000000180D94850
	public LTDescr setSpeed(float speed); // 0x0000000180D94850-0x0000000180D94880
	public LTDescr setRepeat(int repeat); // 0x0000000180D94880-0x0000000180D948D0
	public LTDescr setUseEstimatedTime(bool useEstimatedTime); // 0x0000000180D948D0-0x0000000180D948E0
	public LTDescr setIgnoreTimeScale(bool useUnScaledTime); // 0x0000000180D948D0-0x0000000180D948E0
	public LTDescr setLoopCount(int loopCount); // 0x0000000180D948E0-0x0000000180D94900
	public LTDescr setLoopClamp(); // 0x0000000180D94900-0x0000000180D94920
	public LTDescr setLoopPingPong(); // 0x0000000180D94920-0x0000000180D94940
	public LTDescr setLoopPingPong(int loops); // 0x0000000180D94940-0x0000000180D94960
	public LTDescr setOnComplete(Action onComplete); // 0x0000000180D94960-0x0000000180D949E0
	public LTDescr setOnComplete(Action<object> onComplete); // 0x0000000180D949E0-0x0000000180D94A60
	public LTDescr setOnCompleteParam(object onCompleteParam); // 0x0000000180D94A60-0x0000000180D94AE0
	public LTDescr setOnUpdate(Action<float> onUpdate); // 0x0000000180D94AE0-0x0000000180D94B60
	public LTDescr setOnUpdateRatio(Action<float, float> onUpdate); // 0x0000000180D94B60-0x0000000180D94BE0
	public LTDescr setOnUpdateVector2(Action<Vector2> onUpdate); // 0x0000000180D94BE0-0x0000000180D94C60
	public LTDescr setOnUpdateVector3(Action<Vector3> onUpdate); // 0x0000000180D94C60-0x0000000180D94CE0
	public LTDescr setOnUpdateColor(Action<Color> onUpdate); // 0x0000000180D94CE0-0x0000000180D94D60
	public LTDescr setOnUpdateColor(Action<Color, object> onUpdate); // 0x0000000180D94D60-0x0000000180D94DE0
	public LTDescr setOnUpdate(Action<Color> onUpdate); // 0x0000000180D94CE0-0x0000000180D94D60
	public LTDescr setOnUpdate(Action<Color, object> onUpdate); // 0x0000000180D94D60-0x0000000180D94DE0
	public LTDescr setOnUpdate(Action<float, object> onUpdate, object onUpdateParam = null); // 0x0000000180D94DE0-0x0000000180D94EE0
	public LTDescr setOnUpdate(Action<Vector2> onUpdate, object onUpdateParam = null); // 0x0000000180D94EE0-0x0000000180D94FE0
	public LTDescr setOnUpdate(Action<Vector3> onUpdate, object onUpdateParam = null); // 0x0000000180D94FE0-0x0000000180D950E0
	public LTDescr setOnUpdateParam(object onUpdateParam); // 0x0000000180D950E0-0x0000000180D95150
	public LTDescr setOrientToPath(bool doesOrient); // 0x0000000180D95150-0x0000000180D95220
	public LTDescr setOrientToPath2d(bool doesOrient2d); // 0x0000000180D95220-0x0000000180D952A0
	public LTDescr setRect(LTRect rect); // 0x0000000180D952A0-0x0000000180D95310
	public LTDescr setPoint(Vector3 point); // 0x0000000180D95310-0x0000000180D95340
	public LTDescr setDestroyOnComplete(bool doesDestroy); // 0x0000000180D95340-0x0000000180D95350
	public LTDescr setAudio(object audio); // 0x0000000180D95350-0x0000000180D953C0
	public LTDescr setOnCompleteOnRepeat(bool isOn); // 0x0000000180D953C0-0x0000000180D953D0
	public LTDescr setOnCompleteOnStart(bool isOn); // 0x0000000180D953D0-0x0000000180D953E0
	public LTDescr setRect(RectTransform rect); // 0x0000000180D953E0-0x0000000180D95440
	public LTDescr setSprites(Sprite[] sprites); // 0x0000000180D95440-0x0000000180D954A0
	public LTDescr setOnStart(Action onStart); // 0x0000000180D954A0-0x0000000180D95510
	public LTDescr setDirection(float direction); // 0x0000000180D95510-0x0000000180D95760
	public LTDescr setRecursive(bool useRecursion); // 0x0000000180D95760-0x0000000180D95770
	[CompilerGenerated]
	private void _setMoveX_b__73_0(); // 0x0000000180D95770-0x0000000180D95810
	[CompilerGenerated]
	private void _setMoveX_b__73_1(); // 0x0000000180D95810-0x0000000180D959F0
	[CompilerGenerated]
	private void _setMoveY_b__74_0(); // 0x0000000180D959F0-0x0000000180D95A90
	[CompilerGenerated]
	private void _setMoveY_b__74_1(); // 0x0000000180D95A90-0x0000000180D95C60
	[CompilerGenerated]
	private void _setMoveZ_b__75_0(); // 0x0000000180D95C60-0x0000000180D95D00
	[CompilerGenerated]
	private void _setMoveZ_b__75_1(); // 0x0000000180D95D00-0x0000000180D95EC0
	[CompilerGenerated]
	private void _setMoveLocalX_b__76_0(); // 0x0000000180D95EC0-0x0000000180D95F60
	[CompilerGenerated]
	private void _setMoveLocalX_b__76_1(); // 0x0000000180D95F60-0x0000000180D96140
	[CompilerGenerated]
	private void _setMoveLocalY_b__77_0(); // 0x0000000180D96140-0x0000000180D961E0
	[CompilerGenerated]
	private void _setMoveLocalY_b__77_1(); // 0x0000000180D961E0-0x0000000180D963B0
	[CompilerGenerated]
	private void _setMoveLocalZ_b__78_0(); // 0x0000000180D963B0-0x0000000180D96450
	[CompilerGenerated]
	private void _setMoveLocalZ_b__78_1(); // 0x0000000180D96450-0x0000000180D96610
	[CompilerGenerated]
	private void _setMoveCurved_b__81_0(); // 0x0000000180D96610-0x0000000180D96AF0
	[CompilerGenerated]
	private void _setMoveCurvedLocal_b__82_0(); // 0x0000000180D96AF0-0x0000000180D96EA0
	[CompilerGenerated]
	private void _setMoveSpline_b__83_0(); // 0x0000000180D96EA0-0x0000000180D97080
	[CompilerGenerated]
	private void _setMoveSplineLocal_b__84_0(); // 0x0000000180D97080-0x0000000180D97290
	[CompilerGenerated]
	private void _setScaleX_b__85_0(); // 0x0000000180D97290-0x0000000180D97330
	[CompilerGenerated]
	private void _setScaleX_b__85_1(); // 0x0000000180D97330-0x0000000180D97510
	[CompilerGenerated]
	private void _setScaleY_b__86_0(); // 0x0000000180D97510-0x0000000180D975B0
	[CompilerGenerated]
	private void _setScaleY_b__86_1(); // 0x0000000180D975B0-0x0000000180D97780
	[CompilerGenerated]
	private void _setScaleZ_b__87_0(); // 0x0000000180D97780-0x0000000180D97820
	[CompilerGenerated]
	private void _setScaleZ_b__87_1(); // 0x0000000180D97820-0x0000000180D979E0
	[CompilerGenerated]
	private void _setRotateX_b__88_0(); // 0x0000000180D979E0-0x0000000180D97B10
	[CompilerGenerated]
	private void _setRotateX_b__88_1(); // 0x0000000180D97B10-0x0000000180D97CE0
	[CompilerGenerated]
	private void _setRotateY_b__89_0(); // 0x0000000180D97CE0-0x0000000180D97E10
	[CompilerGenerated]
	private void _setRotateY_b__89_1(); // 0x0000000180D97E10-0x0000000180D97FD0
	[CompilerGenerated]
	private void _setRotateZ_b__90_0(); // 0x0000000180D97FD0-0x0000000180D98100
	[CompilerGenerated]
	private void _setRotateZ_b__90_1(); // 0x0000000180D98100-0x0000000180D982C0
	[CompilerGenerated]
	private void _setRotateAround_b__91_0(); // 0x0000000180D982C0-0x0000000180D98360
	[CompilerGenerated]
	private void _setRotateAround_b__91_1(); // 0x0000000180D98360-0x0000000180D98840
	[CompilerGenerated]
	private void _setRotateAroundLocal_b__92_0(); // 0x0000000180D98840-0x0000000180D988E0
	[CompilerGenerated]
	private void _setRotateAroundLocal_b__92_1(); // 0x0000000180D988E0-0x0000000180D98EE0
	[CompilerGenerated]
	private void _setAlpha_b__93_0(); // 0x0000000180D98EE0-0x0000000180D997A0
	[CompilerGenerated]
	private void _setAlpha_b__93_2(); // 0x0000000180D997A0-0x0000000180D99B50
	[CompilerGenerated]
	private void _setAlpha_b__93_1(); // 0x0000000180D99B50-0x0000000180D99F10
	[CompilerGenerated]
	private void _setTextAlpha_b__94_0(); // 0x0000000180D99F10-0x0000000180D9A0D0
	[CompilerGenerated]
	private void _setTextAlpha_b__94_1(); // 0x0000000180D9A0D0-0x0000000180D9A130
	[CompilerGenerated]
	private void _setAlphaVertex_b__95_0(); // 0x0000000180D9A130-0x0000000180D9A210
	[CompilerGenerated]
	private void _setAlphaVertex_b__95_1(); // 0x0000000180D9A210-0x0000000180D9A4B0
	[CompilerGenerated]
	private void _setColor_b__96_0(); // 0x0000000180D9A4B0-0x0000000180D9ADC0
	[CompilerGenerated]
	private void _setColor_b__96_1(); // 0x0000000180D9ADC0-0x0000000180D9B240
	[CompilerGenerated]
	private void _setCallbackColor_b__97_0(); // 0x0000000180D9B240-0x0000000180D9B260
	[CompilerGenerated]
	private void _setCallbackColor_b__97_1(); // 0x0000000180D9B260-0x0000000180D9B6E0
	[CompilerGenerated]
	private void _setTextColor_b__98_0(); // 0x0000000180D9B6E0-0x0000000180D9B8E0
	[CompilerGenerated]
	private void _setTextColor_b__98_1(); // 0x0000000180D9B8E0-0x0000000180D9BC00
	[CompilerGenerated]
	private void _setCanvasAlpha_b__99_0(); // 0x0000000180D9BC00-0x0000000180D9BEE0
	[CompilerGenerated]
	private void _setCanvasAlpha_b__99_1(); // 0x0000000180D9BEE0-0x0000000180D9C200
	[CompilerGenerated]
	private void _setCanvasGroupAlpha_b__100_0(); // 0x0000000180D9C200-0x0000000180D9C2C0
	[CompilerGenerated]
	private void _setCanvasGroupAlpha_b__100_1(); // 0x0000000180D9C2C0-0x0000000180D9C3B0
	[CompilerGenerated]
	private void _setCanvasColor_b__101_0(); // 0x0000000180D9C3B0-0x0000000180D9C6D0
	[CompilerGenerated]
	private void _setCanvasColor_b__101_1(); // 0x0000000180D9C6D0-0x0000000180D9CAE0
	[CompilerGenerated]
	private void _setCanvasMoveX_b__102_0(); // 0x0000000180D9CAE0-0x0000000180D9CBA0
	[CompilerGenerated]
	private void _setCanvasMoveX_b__102_1(); // 0x0000000180D9CBA0-0x0000000180D9CCB0
	[CompilerGenerated]
	private void _setCanvasMoveY_b__103_0(); // 0x0000000180D9CCB0-0x0000000180D9CD70
	[CompilerGenerated]
	private void _setCanvasMoveY_b__103_1(); // 0x0000000180D9CD70-0x0000000180D9CE80
	[CompilerGenerated]
	private void _setCanvasMoveZ_b__104_0(); // 0x0000000180D9CE80-0x0000000180D9CF30
	[CompilerGenerated]
	private void _setCanvasMoveZ_b__104_1(); // 0x0000000180D9CF30-0x0000000180D9D050
	[CompilerGenerated]
	private void _setCanvasRotateAround_b__106_0(); // 0x0000000180D9D050-0x0000000180D9D4F0
	[CompilerGenerated]
	private void _setCanvasRotateAroundLocal_b__107_0(); // 0x0000000180D9D4F0-0x0000000180D9DA90
	[CompilerGenerated]
	private void _setCanvasPlaySprite_b__108_0(); // 0x0000000180D9DA90-0x0000000180D9DB40
	[CompilerGenerated]
	private void _setCanvasPlaySprite_b__108_1(); // 0x0000000180D9DB40-0x0000000180D9DC20
	[CompilerGenerated]
	private void _setCanvasMove_b__109_0(); // 0x0000000180D9DC20-0x0000000180D9DCF0
	[CompilerGenerated]
	private void _setCanvasMove_b__109_1(); // 0x0000000180D9DCF0-0x0000000180D9DD50
	[CompilerGenerated]
	private void _setCanvasScale_b__110_0(); // 0x0000000180D9DD50-0x0000000180D9DDF0
	[CompilerGenerated]
	private void _setCanvasScale_b__110_1(); // 0x0000000180D9DDF0-0x0000000180D9DEB0
	[CompilerGenerated]
	private void _setCanvasSizeDelta_b__111_0(); // 0x0000000180D9DEB0-0x0000000180D9DF00
	[CompilerGenerated]
	private void _setCanvasSizeDelta_b__111_1(); // 0x0000000180D9DF00-0x0000000180D9DF60
	[CompilerGenerated]
	private void _setMove_b__115_0(); // 0x0000000180D9DF60-0x0000000180D9E000
	[CompilerGenerated]
	private void _setMove_b__115_1(); // 0x0000000180D9E000-0x0000000180D9E110
	[CompilerGenerated]
	private void _setMoveLocal_b__116_0(); // 0x0000000180D9E110-0x0000000180D9E1B0
	[CompilerGenerated]
	private void _setMoveLocal_b__116_1(); // 0x0000000180D9E1B0-0x0000000180D9E2C0
	[CompilerGenerated]
	private void _setMoveToTransform_b__117_0(); // 0x0000000180D9DF60-0x0000000180D9E000
	[CompilerGenerated]
	private void _setMoveToTransform_b__117_1(); // 0x0000000180D9E2C0-0x0000000180D9E4E0
	[CompilerGenerated]
	private void _setRotate_b__118_0(); // 0x0000000180D9E4E0-0x0000000180D9E670
	[CompilerGenerated]
	private void _setRotate_b__118_1(); // 0x0000000180D9E670-0x0000000180D9E720
	[CompilerGenerated]
	private void _setRotateLocal_b__119_0(); // 0x0000000180D9E720-0x0000000180D9E8B0
	[CompilerGenerated]
	private void _setRotateLocal_b__119_1(); // 0x0000000180D9E8B0-0x0000000180D9E960
	[CompilerGenerated]
	private void _setScale_b__120_0(); // 0x0000000180D9E960-0x0000000180D9EA00
	[CompilerGenerated]
	private void _setScale_b__120_1(); // 0x0000000180D9EA00-0x0000000180D9EB10
	[CompilerGenerated]
	private void _setGUIMove_b__121_0(); // 0x0000000180D9EB10-0x0000000180D9EBD0
	[CompilerGenerated]
	private void _setGUIMove_b__121_1(); // 0x0000000180D9EBD0-0x0000000180D9ECF0
	[CompilerGenerated]
	private void _setGUIMoveMargin_b__122_0(); // 0x0000000180D9ECF0-0x0000000180D9ED30
	[CompilerGenerated]
	private void _setGUIMoveMargin_b__122_1(); // 0x0000000180D9ED30-0x0000000180D9EDA0
	[CompilerGenerated]
	private void _setGUIScale_b__123_0(); // 0x0000000180D9EDA0-0x0000000180D9EE60
	[CompilerGenerated]
	private void _setGUIScale_b__123_1(); // 0x0000000180D9EE60-0x0000000180D9EF80
	[CompilerGenerated]
	private void _setGUIAlpha_b__124_0(); // 0x0000000180D9EF80-0x0000000180D9EFB0
	[CompilerGenerated]
	private void _setGUIAlpha_b__124_1(); // 0x0000000180D9EFB0-0x0000000180D9F010
	[CompilerGenerated]
	private void _setGUIRotate_b__125_0(); // 0x0000000180D9F010-0x0000000180D9F090
	[CompilerGenerated]
	private void _setGUIRotate_b__125_1(); // 0x0000000180D9F090-0x0000000180D9F0F0
	[CompilerGenerated]
	private void _setDelayedSound_b__126_0(); // 0x0000000180D9F0F0-0x0000000180D9F100
}

