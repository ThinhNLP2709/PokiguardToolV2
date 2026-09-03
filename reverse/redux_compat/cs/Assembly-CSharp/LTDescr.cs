/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class LTDescr // TypeDefIndex: 279
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
	public Vector3 from { get; set; } // 0x00000001806BAE30-0x00000001806BAE50 0x00000001806C0BF0-0x00000001806C0C00
	public Vector3 to { get; set; } // 0x00000001806BAEA0-0x00000001806BAEC0 0x00000001806C0C40-0x00000001806C0C50
	public ActionMethodDelegate easeInternal { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D510-0x000000018033D520 0x000000018033EAB0-0x000000018033EAD0
	public ActionMethodDelegate initInternal { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806BAE60-0x00000001806BAE70 0x00000001806C0C00-0x00000001806C0C20
	public Transform toTrans { get; } // 0x00000001806BAE80-0x00000001806BAEA0 
	public int uniqueId { get; } // 0x00000001806BAE50-0x00000001806BAE60 
	public int id { get; } // 0x00000001806BAE50-0x00000001806BAE60 
	public LTDescrOptional optional { get; set; } // 0x00000001806BAE70-0x00000001806BAE80 0x00000001806C0C20-0x00000001806C0C40

	// Nested types
	public delegate Vector3 EaseTypeDelegate(); // TypeDefIndex: 280; 0x00000001806CAF60-0x00000001806CAFA0

	public delegate void ActionMethodDelegate(); // TypeDefIndex: 281; 0x0000000180313920-0x00000001803139C0

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 282
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static ActionMethodDelegate __9__113_0; // 0x08
		public static ActionMethodDelegate __9__114_0; // 0x10

		// Constructors
		static __c(); // 0x00000001806E3CB0-0x00000001806E3D20
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _setCallback_b__113_0(); // 0x00000001802E76C0-0x00000001802E76D0
		internal void _setValue3_b__114_0(); // 0x00000001802E76C0-0x00000001802E76D0
	}

	// Constructors
	public LTDescr(); // 0x00000001806B7170-0x00000001806B71F0

	// Methods
	public override string ToString(); // 0x00000001806B1070-0x00000001806B16A0
	[Obsolete("Use \'LeanTween.cancel( id )\' instead")]
	public LTDescr cancel(GameObject gameObject); // 0x00000001806B7F20-0x00000001806B7FE0
	public void reset(); // 0x00000001806BB200-0x00000001806BB350
	public LTDescr setFollow(); // 0x00000001806BE3A0-0x00000001806BE3B0
	public LTDescr setMoveX(); // 0x00000001806BF260-0x00000001806BF330
	public LTDescr setMoveY(); // 0x00000001806BF330-0x00000001806BF400
	public LTDescr setMoveZ(); // 0x00000001806BF400-0x00000001806BF4D0
	public LTDescr setMoveLocalX(); // 0x00000001806BECB0-0x00000001806BED80
	public LTDescr setMoveLocalY(); // 0x00000001806BED80-0x00000001806BEE50
	public LTDescr setMoveLocalZ(); // 0x00000001806BEE50-0x00000001806BEF20
	private void initFromInternal(); // 0x00000001806BAF10-0x00000001806BAF20
	public LTDescr setOffset(Vector3 offset); // 0x00000001806BF5A0-0x00000001806BF5C0
	public LTDescr setMoveCurved(); // 0x00000001806BEBE0-0x00000001806BECB0
	public LTDescr setMoveCurvedLocal(); // 0x00000001806BEB10-0x00000001806BEBE0
	public LTDescr setMoveSpline(); // 0x00000001806BF0C0-0x00000001806BF190
	public LTDescr setMoveSplineLocal(); // 0x00000001806BEFF0-0x00000001806BF0C0
	public LTDescr setScaleX(); // 0x00000001806C0480-0x00000001806C0550
	public LTDescr setScaleY(); // 0x00000001806C0550-0x00000001806C0620
	public LTDescr setScaleZ(); // 0x00000001806C0620-0x00000001806C06F0
	public LTDescr setRotateX(); // 0x00000001806C0140-0x00000001806C0210
	public LTDescr setRotateY(); // 0x00000001806C0210-0x00000001806C02E0
	public LTDescr setRotateZ(); // 0x00000001806C02E0-0x00000001806C03B0
	public LTDescr setRotateAround(); // 0x00000001806BFFA0-0x00000001806C0070
	public LTDescr setRotateAroundLocal(); // 0x00000001806BFED0-0x00000001806BFFA0
	public LTDescr setAlpha(); // 0x00000001806BB430-0x00000001806BB500
	public LTDescr setTextAlpha(); // 0x00000001806C0870-0x00000001806C0940
	public LTDescr setAlphaVertex(); // 0x00000001806BB360-0x00000001806BB430
	public LTDescr setColor(); // 0x00000001806BC140-0x00000001806BC210
	public LTDescr setCallbackColor(); // 0x00000001806BB570-0x00000001806BB640
	public LTDescr setTextColor(); // 0x00000001806C0940-0x00000001806C0A10
	public LTDescr setCanvasAlpha(); // 0x00000001806BB780-0x00000001806BB850
	public LTDescr setCanvasGroupAlpha(); // 0x00000001806BB920-0x00000001806BB9F0
	public LTDescr setCanvasColor(); // 0x00000001806BB850-0x00000001806BB920
	public LTDescr setCanvasMoveX(); // 0x00000001806BB9F0-0x00000001806BBAC0
	public LTDescr setCanvasMoveY(); // 0x00000001806BBAC0-0x00000001806BBB90
	public LTDescr setCanvasMoveZ(); // 0x00000001806BBB90-0x00000001806BBC60
	private void initCanvasRotateAround(); // 0x00000001806BAEC0-0x00000001806BAF10
	public LTDescr setCanvasRotateAround(); // 0x00000001806BBED0-0x00000001806BBFA0
	public LTDescr setCanvasRotateAroundLocal(); // 0x00000001806BBE00-0x00000001806BBED0
	public LTDescr setCanvasPlaySprite(); // 0x00000001806BBD30-0x00000001806BBE00
	public LTDescr setCanvasMove(); // 0x00000001806BBC60-0x00000001806BBD30
	public LTDescr setCanvasScale(); // 0x00000001806BBFA0-0x00000001806BC070
	public LTDescr setCanvasSizeDelta(); // 0x00000001806BC070-0x00000001806BC140
	private void callback(); // 0x00000001806B7E90-0x00000001806B7F20
	public LTDescr setCallback(); // 0x00000001806BB640-0x00000001806BB780
	public LTDescr setValue3(); // 0x00000001806C0AB0-0x00000001806C0BF0
	public LTDescr setMove(); // 0x00000001806BF4D0-0x00000001806BF5A0
	public LTDescr setMoveLocal(); // 0x00000001806BEF20-0x00000001806BEFF0
	public LTDescr setMoveToTransform(); // 0x00000001806BF190-0x00000001806BF260
	public LTDescr setRotate(); // 0x00000001806C03B0-0x00000001806C0480
	public LTDescr setRotateLocal(); // 0x00000001806C0070-0x00000001806C0140
	public LTDescr setScale(); // 0x00000001806C06F0-0x00000001806C07C0
	public LTDescr setGUIMove(); // 0x00000001806BE7C0-0x00000001806BE890
	public LTDescr setGUIMoveMargin(); // 0x00000001806BE6F0-0x00000001806BE7C0
	public LTDescr setGUIScale(); // 0x00000001806BE960-0x00000001806BEA30
	public LTDescr setGUIAlpha(); // 0x00000001806BE620-0x00000001806BE6F0
	public LTDescr setGUIRotate(); // 0x00000001806BE890-0x00000001806BE960
	public LTDescr setDelayedSound(); // 0x00000001806BC220-0x00000001806BC2F0
	public LTDescr setTarget(Transform trans); // 0x00000001806C0830-0x00000001806C0870
	private void init(); // 0x00000001806BB080-0x00000001806BB1E0
	private void initSpeed(); // 0x00000001806BAF20-0x00000001806BB080
	public LTDescr updateNow(); // 0x00000001806C1AE0-0x00000001806C1B00
	public bool updateInternal(); // 0x00000001806C17A0-0x00000001806C1AE0
	public void callOnCompletes(); // 0x00000001806B7D50-0x00000001806B7E90
	public LTDescr setFromColor(Color col); // 0x00000001806BE3E0-0x00000001806BE450
	private static void alphaRecursive(Transform transform, float val, bool useRecursion = true /* Metadata: 0x0064C086 */); // 0x00000001806B7530-0x00000001806B7970
	private static void colorRecursive(Transform transform, Color toColor, bool useRecursion = true /* Metadata: 0x0064C087 */); // 0x00000001806B8320-0x00000001806B8650
	private static void alphaRecursive(RectTransform rectTransform, float val, int recursiveLevel = 0 /* Metadata: 0x0064C088 */); // 0x00000001806B7970-0x00000001806B7D50
	private static void alphaRecursiveSprite(Transform transform, float val); // 0x00000001806B71F0-0x00000001806B7530
	private static void colorRecursiveSprite(Transform transform, Color toColor); // 0x00000001806B7FE0-0x00000001806B8320
	private static void colorRecursive(RectTransform rectTransform, Color toColor); // 0x00000001806B8650-0x00000001806B89A0
	private static void textAlphaChildrenRecursive(Transform trans, float val, bool useRecursion = true /* Metadata: 0x0064C089 */); // 0x00000001806C0C50-0x00000001806C0F90
	private static void textAlphaRecursive(Transform trans, float val, bool useRecursion = true /* Metadata: 0x0064C08A */); // 0x00000001806C0F90-0x00000001806C12A0
	private static void textColorRecursive(Transform trans, Color toColor); // 0x00000001806C12A0-0x00000001806C1580
	private static Color tweenColor(LTDescr tween, float val); // 0x00000001806C1580-0x00000001806C1650
	public LTDescr pause(); // 0x00000001806BB1E0-0x00000001806BB200
	public LTDescr resume(); // 0x00000001806BB350-0x00000001806BB360
	public LTDescr setAxis(Vector3 axis); // 0x00000001806BB540-0x00000001806BB570
	public LTDescr setDelay(float delay); // 0x00000001806BC210-0x00000001806BC220
	public LTDescr setEase(LeanTweenType easeType); // 0x00000001806BD8E0-0x00000001806BE2F0
	public LTDescr setEaseLinear(); // 0x00000001806BD040-0x00000001806BD0D0
	public LTDescr setEaseSpring(); // 0x00000001806BD850-0x00000001806BD8E0
	public LTDescr setEaseInQuad(); // 0x00000001806BCE00-0x00000001806BCE90
	public LTDescr setEaseOutQuad(); // 0x00000001806BD430-0x00000001806BD4C0
	public LTDescr setEaseInOutQuad(); // 0x00000001806BCBC0-0x00000001806BCC50
	public LTDescr setEaseInCubic(); // 0x00000001806BC6B0-0x00000001806BC740
	public LTDescr setEaseOutCubic(); // 0x00000001806BD280-0x00000001806BD310
	public LTDescr setEaseInOutCubic(); // 0x00000001806BCA10-0x00000001806BCAA0
	public LTDescr setEaseInQuart(); // 0x00000001806BCE90-0x00000001806BCF20
	public LTDescr setEaseOutQuart(); // 0x00000001806BD4C0-0x00000001806BD550
	public LTDescr setEaseInOutQuart(); // 0x00000001806BCC50-0x00000001806BCCE0
	public LTDescr setEaseInQuint(); // 0x00000001806BCF20-0x00000001806BCFB0
	public LTDescr setEaseOutQuint(); // 0x00000001806BD550-0x00000001806BD5E0
	public LTDescr setEaseInOutQuint(); // 0x00000001806BCCE0-0x00000001806BCD70
	public LTDescr setEaseInSine(); // 0x00000001806BCFB0-0x00000001806BD040
	public LTDescr setEaseOutSine(); // 0x00000001806BD5E0-0x00000001806BD670
	public LTDescr setEaseInOutSine(); // 0x00000001806BCD70-0x00000001806BCE00
	public LTDescr setEaseInExpo(); // 0x00000001806BC7D0-0x00000001806BC860
	public LTDescr setEaseOutExpo(); // 0x00000001806BD3A0-0x00000001806BD430
	public LTDescr setEaseInOutExpo(); // 0x00000001806BCB30-0x00000001806BCBC0
	public LTDescr setEaseInCirc(); // 0x00000001806BC620-0x00000001806BC6B0
	public LTDescr setEaseOutCirc(); // 0x00000001806BD1F0-0x00000001806BD280
	public LTDescr setEaseInOutCirc(); // 0x00000001806BC980-0x00000001806BCA10
	public LTDescr setEaseInBounce(); // 0x00000001806BC590-0x00000001806BC620
	public LTDescr setEaseOutBounce(); // 0x00000001806BD160-0x00000001806BD1F0
	public LTDescr setEaseInOutBounce(); // 0x00000001806BC8F0-0x00000001806BC980
	public LTDescr setEaseInBack(); // 0x00000001806BC500-0x00000001806BC590
	public LTDescr setEaseOutBack(); // 0x00000001806BD0D0-0x00000001806BD160
	public LTDescr setEaseInOutBack(); // 0x00000001806BC860-0x00000001806BC8F0
	public LTDescr setEaseInElastic(); // 0x00000001806BC740-0x00000001806BC7D0
	public LTDescr setEaseOutElastic(); // 0x00000001806BD310-0x00000001806BD3A0
	public LTDescr setEaseInOutElastic(); // 0x00000001806BCAA0-0x00000001806BCB30
	public LTDescr setEasePunch(); // 0x00000001806BD670-0x00000001806BD760
	public LTDescr setEaseShake(); // 0x00000001806BD760-0x00000001806BD850
	private Vector3 tweenOnCurve(); // 0x00000001806C1650-0x00000001806C17A0
	private Vector3 easeInOutQuad(); // 0x00000001806B9960-0x00000001806B9A80
	private Vector3 easeInQuad(); // 0x00000001806B9E00-0x00000001806B9EB0
	private Vector3 easeOutQuad(); // 0x00000001806BA930-0x00000001806BAA10
	private Vector3 easeLinear(); // 0x00000001806BA150-0x00000001806BA200
	private Vector3 easeSpring(); // 0x00000001806BACC0-0x00000001806BAE30
	private Vector3 easeInCubic(); // 0x00000001806B8D30-0x00000001806B8DE0
	private Vector3 easeOutCubic(); // 0x00000001806BA640-0x00000001806BA720
	private Vector3 easeInOutCubic(); // 0x00000001806B95D0-0x00000001806B96E0
	private Vector3 easeInQuart(); // 0x00000001806B9EB0-0x00000001806B9F70
	private Vector3 easeOutQuart(); // 0x00000001806BAA10-0x00000001806BAAF0
	private Vector3 easeInOutQuart(); // 0x00000001806B9A80-0x00000001806B9C10
	private Vector3 easeInQuint(); // 0x00000001806B9F70-0x00000001806BA040
	private Vector3 easeOutQuint(); // 0x00000001806BAAF0-0x00000001806BABD0
	private Vector3 easeInOutQuint(); // 0x00000001806B9C10-0x00000001806B9D30
	private Vector3 easeInSine(); // 0x00000001806BA040-0x00000001806BA150
	private Vector3 easeOutSine(); // 0x00000001806BABD0-0x00000001806BACC0
	private Vector3 easeInOutSine(); // 0x00000001806B9D30-0x00000001806B9E00
	private Vector3 easeInExpo(); // 0x00000001806B8F20-0x00000001806B8FF0
	private Vector3 easeOutExpo(); // 0x00000001806BA860-0x00000001806BA930
	private Vector3 easeInOutExpo(); // 0x00000001806B9820-0x00000001806B9960
	private Vector3 easeInCirc(); // 0x00000001806B8C50-0x00000001806B8D30
	private Vector3 easeOutCirc(); // 0x00000001806BA540-0x00000001806BA640
	private Vector3 easeInOutCirc(); // 0x00000001806B9460-0x00000001806B95D0
	private Vector3 easeInBounce(); // 0x00000001806B8AA0-0x00000001806B8C50
	private Vector3 easeOutBounce(); // 0x00000001806BA300-0x00000001806BA540
	private Vector3 easeInOutBounce(); // 0x00000001806B91C0-0x00000001806B9460
	private Vector3 easeInBack(); // 0x00000001806B89A0-0x00000001806B8AA0
	private Vector3 easeOutBack(); // 0x00000001806BA200-0x00000001806BA300
	private Vector3 easeInOutBack(); // 0x00000001806B8FF0-0x00000001806B91C0
	private Vector3 easeInElastic(); // 0x00000001806B8DE0-0x00000001806B8F20
	private Vector3 easeOutElastic(); // 0x00000001806BA720-0x00000001806BA860
	private Vector3 easeInOutElastic(); // 0x00000001806B96E0-0x00000001806B9820
	public LTDescr setOvershoot(float overshoot); // 0x00000001806BFCC0-0x00000001806BFCD0
	public LTDescr setPeriod(float period); // 0x00000001806BFD20-0x00000001806BFD30
	public LTDescr setScale(float scale); // 0x00000001806C07C0-0x00000001806C07D0
	public LTDescr setEase(AnimationCurve easeCurve); // 0x00000001806BE2F0-0x00000001806BE3A0
	public LTDescr setTo(Vector3 to); // 0x00000001806C0A30-0x00000001806C0A90
	public LTDescr setTo(Transform to); // 0x00000001806C0830-0x00000001806C0870
	public LTDescr setFrom(Vector3 from); // 0x00000001806BE540-0x00000001806BE620
	public LTDescr setFrom(float from); // 0x00000001806BE450-0x00000001806BE540
	public LTDescr setDiff(Vector3 diff); // 0x00000001806BC300-0x00000001806BC320
	public LTDescr setHasInitialized(bool has); // 0x00000001806BEA30-0x00000001806BEA40
	public LTDescr setId(uint id, uint global_counter); // 0x00000001806BEA40-0x00000001806BEA50
	public LTDescr setPassed(float passed); // 0x00000001806BFCD0-0x00000001806BFCE0
	public LTDescr setTime(float time); // 0x00000001806C0A10-0x00000001806C0A30
	public LTDescr setSpeed(float speed); // 0x00000001806C07D0-0x00000001806C0800
	public LTDescr setRepeat(int repeat); // 0x00000001806BFE80-0x00000001806BFED0
	public LTDescr setLoopType(LeanTweenType loopType); // 0x00000001806BEB00-0x00000001806BEB10
	public LTDescr setUseEstimatedTime(bool useEstimatedTime); // 0x00000001806BEA50-0x00000001806BEA60
	public LTDescr setIgnoreTimeScale(bool useUnScaledTime); // 0x00000001806BEA50-0x00000001806BEA60
	public LTDescr setUseFrames(bool useFrames); // 0x00000001806C0A90-0x00000001806C0AA0
	public LTDescr setUseManualTime(bool useManualTime); // 0x00000001806C0AA0-0x00000001806C0AB0
	public LTDescr setLoopCount(int loopCount); // 0x00000001806BEA90-0x00000001806BEAB0
	public LTDescr setLoopOnce(); // 0x00000001806BEAB0-0x00000001806BEAC0
	public LTDescr setLoopClamp(); // 0x00000001806BEA70-0x00000001806BEA90
	public LTDescr setLoopClamp(int loops); // 0x00000001806BEA60-0x00000001806BEA70
	public LTDescr setLoopPingPong(); // 0x00000001806BEAE0-0x00000001806BEB00
	public LTDescr setLoopPingPong(int loops); // 0x00000001806BEAC0-0x00000001806BEAE0
	public LTDescr setOnComplete(Action onComplete); // 0x00000001806BF660-0x00000001806BF6A0
	public LTDescr setOnComplete(Action<object> onComplete); // 0x00000001806BF620-0x00000001806BF660
	public LTDescr setOnComplete(Action<object> onComplete, object onCompleteParam); // 0x00000001806BF6A0-0x00000001806BF710
	public LTDescr setOnCompleteParam(object onCompleteParam); // 0x00000001806BF5E0-0x00000001806BF620
	public LTDescr setOnUpdate(Action<float> onUpdate); // 0x00000001806BFB10-0x00000001806BFB50
	public LTDescr setOnUpdateRatio(Action<float, float> onUpdate); // 0x00000001806BF850-0x00000001806BF890
	public LTDescr setOnUpdateObject(Action<float, object> onUpdate); // 0x00000001806BF7D0-0x00000001806BF810
	public LTDescr setOnUpdateVector2(Action<Vector2> onUpdate); // 0x00000001806BF890-0x00000001806BF8D0
	public LTDescr setOnUpdateVector3(Action<Vector3> onUpdate); // 0x00000001806BF8D0-0x00000001806BF910
	public LTDescr setOnUpdateColor(Action<Color> onUpdate); // 0x00000001806BF750-0x00000001806BF790
	public LTDescr setOnUpdateColor(Action<Color, object> onUpdate); // 0x00000001806BF790-0x00000001806BF7D0
	public LTDescr setOnUpdate(Action<Color> onUpdate); // 0x00000001806BF750-0x00000001806BF790
	public LTDescr setOnUpdate(Action<Color, object> onUpdate); // 0x00000001806BF790-0x00000001806BF7D0
	public LTDescr setOnUpdate(Action<float, object> onUpdate, object onUpdateParam = null); // 0x00000001806BF910-0x00000001806BF990
	public LTDescr setOnUpdate(Action<Vector3, object> onUpdate, object onUpdateParam = null); // 0x00000001806BF990-0x00000001806BFA10
	public LTDescr setOnUpdate(Action<Vector2> onUpdate, object onUpdateParam = null); // 0x00000001806BFA10-0x00000001806BFA90
	public LTDescr setOnUpdate(Action<Vector3> onUpdate, object onUpdateParam = null); // 0x00000001806BFA90-0x00000001806BFB10
	public LTDescr setOnUpdateParam(object onUpdateParam); // 0x00000001806BF810-0x00000001806BF850
	public LTDescr setOrientToPath(bool doesOrient); // 0x00000001806BFBD0-0x00000001806BFCC0
	public LTDescr setOrientToPath2d(bool doesOrient2d); // 0x00000001806BFB50-0x00000001806BFBD0
	public LTDescr setRect(LTRect rect); // 0x00000001806BFE30-0x00000001806BFE70
	public LTDescr setRect(Rect rect); // 0x00000001806BFD60-0x00000001806BFE00
	public LTDescr setPath(LTBezierPath path); // 0x00000001806BFCE0-0x00000001806BFD20
	public LTDescr setPoint(Vector3 point); // 0x00000001806BFD30-0x00000001806BFD60
	public LTDescr setDestroyOnComplete(bool doesDestroy); // 0x00000001806BC2F0-0x00000001806BC300
	public LTDescr setAudio(object audio); // 0x00000001806BB500-0x00000001806BB540
	public LTDescr setOnCompleteOnRepeat(bool isOn); // 0x00000001806BF5C0-0x00000001806BF5D0
	public LTDescr setOnCompleteOnStart(bool isOn); // 0x00000001806BF5D0-0x00000001806BF5E0
	public LTDescr setRect(RectTransform rect); // 0x00000001806BFE00-0x00000001806BFE30
	public LTDescr setSprites(Sprite[] sprites); // 0x00000001806C0800-0x00000001806C0830
	public LTDescr setFrameRate(float frameRate); // 0x00000001806BE3B0-0x00000001806BE3E0
	public LTDescr setOnStart(Action onStart); // 0x00000001806BF710-0x00000001806BF750
	public LTDescr setDirection(float direction); // 0x00000001806BC320-0x00000001806BC500
	public LTDescr setRecursive(bool useRecursion); // 0x00000001806BFE70-0x00000001806BFE80
	[CompilerGenerated]
	private void _setMoveX_b__73_0(); // 0x00000001806B5700-0x00000001806B5730
	[CompilerGenerated]
	private void _setMoveX_b__73_1(); // 0x00000001806B5730-0x00000001806B57F0
	[CompilerGenerated]
	private void _setMoveY_b__74_0(); // 0x00000001806B57F0-0x00000001806B5830
	[CompilerGenerated]
	private void _setMoveY_b__74_1(); // 0x00000001806B5830-0x00000001806B5900
	[CompilerGenerated]
	private void _setMoveZ_b__75_0(); // 0x00000001806B5900-0x00000001806B5940
	[CompilerGenerated]
	private void _setMoveZ_b__75_1(); // 0x00000001806B5940-0x00000001806B5A00
	[CompilerGenerated]
	private void _setMoveLocalX_b__76_0(); // 0x00000001806B4EA0-0x00000001806B4ED0
	[CompilerGenerated]
	private void _setMoveLocalX_b__76_1(); // 0x00000001806B4ED0-0x00000001806B4F90
	[CompilerGenerated]
	private void _setMoveLocalY_b__77_0(); // 0x00000001806B4F90-0x00000001806B4FD0
	[CompilerGenerated]
	private void _setMoveLocalY_b__77_1(); // 0x00000001806B4FD0-0x00000001806B50A0
	[CompilerGenerated]
	private void _setMoveLocalZ_b__78_0(); // 0x00000001806B50A0-0x00000001806B50E0
	[CompilerGenerated]
	private void _setMoveLocalZ_b__78_1(); // 0x00000001806B50E0-0x00000001806B51A0
	[CompilerGenerated]
	private void _setMoveCurved_b__81_0(); // 0x00000001806B4C20-0x00000001806B4DB0
	[CompilerGenerated]
	private void _setMoveCurvedLocal_b__82_0(); // 0x00000001806B4A90-0x00000001806B4C20
	[CompilerGenerated]
	private void _setMoveSpline_b__83_0(); // 0x00000001806B5330-0x00000001806B54C0
	[CompilerGenerated]
	private void _setMoveSplineLocal_b__84_0(); // 0x00000001806B51A0-0x00000001806B5330
	[CompilerGenerated]
	private void _setScaleX_b__85_0(); // 0x00000001806B6920-0x00000001806B6950
	[CompilerGenerated]
	private void _setScaleX_b__85_1(); // 0x00000001806B6950-0x00000001806B6A10
	[CompilerGenerated]
	private void _setScaleY_b__86_0(); // 0x00000001806B6A10-0x00000001806B6A50
	[CompilerGenerated]
	private void _setScaleY_b__86_1(); // 0x00000001806B6A50-0x00000001806B6B20
	[CompilerGenerated]
	private void _setScaleZ_b__87_0(); // 0x00000001806B6B20-0x00000001806B6B60
	[CompilerGenerated]
	private void _setScaleZ_b__87_1(); // 0x00000001806B6B60-0x00000001806B6C20
	[CompilerGenerated]
	private void _setRotateX_b__88_0(); // 0x00000001806B6400-0x00000001806B64A0
	[CompilerGenerated]
	private void _setRotateX_b__88_1(); // 0x00000001806B64A0-0x00000001806B6560
	[CompilerGenerated]
	private void _setRotateY_b__89_0(); // 0x00000001806B6560-0x00000001806B6600
	[CompilerGenerated]
	private void _setRotateY_b__89_1(); // 0x00000001806B6600-0x00000001806B66D0
	[CompilerGenerated]
	private void _setRotateZ_b__90_0(); // 0x00000001806B66D0-0x00000001806B6770
	[CompilerGenerated]
	private void _setRotateZ_b__90_1(); // 0x00000001806B6770-0x00000001806B6830
	[CompilerGenerated]
	private void _setRotateAround_b__91_0(); // 0x00000001806B5DB0-0x00000001806B5E00
	[CompilerGenerated]
	private void _setRotateAround_b__91_1(); // 0x00000001806B5E00-0x00000001806B60E0
	[CompilerGenerated]
	private void _setRotateAroundLocal_b__92_0(); // 0x00000001806B5A00-0x00000001806B5A50
	[CompilerGenerated]
	private void _setRotateAroundLocal_b__92_1(); // 0x00000001806B5A50-0x00000001806B5DB0
	[CompilerGenerated]
	private void _setAlpha_b__93_0(); // 0x00000001806B16A0-0x00000001806B1BF0
	[CompilerGenerated]
	private void _setAlpha_b__93_2(); // 0x00000001806B1DC0-0x00000001806B1F80
	[CompilerGenerated]
	private void _setAlpha_b__93_1(); // 0x00000001806B1BF0-0x00000001806B1DC0
	[CompilerGenerated]
	private void _setTextAlpha_b__94_0(); // 0x00000001806B6C20-0x00000001806B6D10
	[CompilerGenerated]
	private void _setTextAlpha_b__94_1(); // 0x00000001806B6D10-0x00000001806B6D70
	[CompilerGenerated]
	private void _setAlphaVertex_b__95_0(); // 0x00000001806B1F80-0x00000001806B2010
	[CompilerGenerated]
	private void _setAlphaVertex_b__95_1(); // 0x00000001806B2010-0x00000001806B2370
	[CompilerGenerated]
	private void _setColor_b__96_0(); // 0x00000001806B3BC0-0x00000001806B4160
	[CompilerGenerated]
	private void _setColor_b__96_1(); // 0x00000001806B4160-0x00000001806B44E0
	[CompilerGenerated]
	private void _setCallbackColor_b__97_0(); // 0x00000001806B2370-0x00000001806B2390
	[CompilerGenerated]
	private void _setCallbackColor_b__97_1(); // 0x00000001806B2390-0x00000001806B2710
	[CompilerGenerated]
	private void _setTextColor_b__98_0(); // 0x00000001806B6D70-0x00000001806B6EB0
	[CompilerGenerated]
	private void _setTextColor_b__98_1(); // 0x00000001806B6EB0-0x00000001806B7170
	[CompilerGenerated]
	private void _setCanvasAlpha_b__99_0(); // 0x00000001806B2710-0x00000001806B2850
	[CompilerGenerated]
	private void _setCanvasAlpha_b__99_1(); // 0x00000001806B2850-0x00000001806B2A70
	[CompilerGenerated]
	private void _setCanvasGroupAlpha_b__100_0(); // 0x00000001806B2F10-0x00000001806B2F70
	[CompilerGenerated]
	private void _setCanvasGroupAlpha_b__100_1(); // 0x00000001806B2F70-0x00000001806B3010
	[CompilerGenerated]
	private void _setCanvasColor_b__101_0(); // 0x00000001806B2A70-0x00000001806B2C00
	[CompilerGenerated]
	private void _setCanvasColor_b__101_1(); // 0x00000001806B2C00-0x00000001806B2F10
	[CompilerGenerated]
	private void _setCanvasMoveX_b__102_0(); // 0x00000001806B30B0-0x00000001806B30F0
	[CompilerGenerated]
	private void _setCanvasMoveX_b__102_1(); // 0x00000001806B30F0-0x00000001806B31B0
	[CompilerGenerated]
	private void _setCanvasMoveY_b__103_0(); // 0x00000001806B31B0-0x00000001806B31F0
	[CompilerGenerated]
	private void _setCanvasMoveY_b__103_1(); // 0x00000001806B31F0-0x00000001806B32B0
	[CompilerGenerated]
	private void _setCanvasMoveZ_b__104_0(); // 0x00000001806B32B0-0x00000001806B32F0
	[CompilerGenerated]
	private void _setCanvasMoveZ_b__104_1(); // 0x00000001806B32F0-0x00000001806B33A0
	[CompilerGenerated]
	private void _setCanvasRotateAround_b__106_0(); // 0x00000001806B37E0-0x00000001806B3A70
	[CompilerGenerated]
	private void _setCanvasRotateAroundLocal_b__107_0(); // 0x00000001806B34F0-0x00000001806B37E0
	[CompilerGenerated]
	private void _setCanvasPlaySprite_b__108_0(); // 0x00000001806B33A0-0x00000001806B3410
	[CompilerGenerated]
	private void _setCanvasPlaySprite_b__108_1(); // 0x00000001806B3410-0x00000001806B34F0
	[CompilerGenerated]
	private void _setCanvasMove_b__109_0(); // 0x00000001806B3010-0x00000001806B3050
	[CompilerGenerated]
	private void _setCanvasMove_b__109_1(); // 0x00000001806B3050-0x00000001806B30B0
	[CompilerGenerated]
	private void _setCanvasScale_b__110_0(); // 0x00000001806B3A70-0x00000001806B3AB0
	[CompilerGenerated]
	private void _setCanvasScale_b__110_1(); // 0x00000001806B3AB0-0x00000001806B3B10
	[CompilerGenerated]
	private void _setCanvasSizeDelta_b__111_0(); // 0x00000001806B3B10-0x00000001806B3B60
	[CompilerGenerated]
	private void _setCanvasSizeDelta_b__111_1(); // 0x00000001806B3B60-0x00000001806B3BC0
	[CompilerGenerated]
	private void _setMove_b__115_0(); // 0x00000001806B54C0-0x00000001806B5500
	[CompilerGenerated]
	private void _setMove_b__115_1(); // 0x00000001806B5650-0x00000001806B5700
	[CompilerGenerated]
	private void _setMoveLocal_b__116_0(); // 0x00000001806B4DB0-0x00000001806B4DF0
	[CompilerGenerated]
	private void _setMoveLocal_b__116_1(); // 0x00000001806B4DF0-0x00000001806B4EA0
	[CompilerGenerated]
	private void _setMoveToTransform_b__117_0(); // 0x00000001806B54C0-0x00000001806B5500
	[CompilerGenerated]
	private void _setMoveToTransform_b__117_1(); // 0x00000001806B5500-0x00000001806B5650
	[CompilerGenerated]
	private void _setRotate_b__118_0(); // 0x00000001806B6270-0x00000001806B6350
	[CompilerGenerated]
	private void _setRotate_b__118_1(); // 0x00000001806B6350-0x00000001806B6400
	[CompilerGenerated]
	private void _setRotateLocal_b__119_0(); // 0x00000001806B60E0-0x00000001806B61C0
	[CompilerGenerated]
	private void _setRotateLocal_b__119_1(); // 0x00000001806B61C0-0x00000001806B6270
	[CompilerGenerated]
	private void _setScale_b__120_0(); // 0x00000001806B6830-0x00000001806B6870
	[CompilerGenerated]
	private void _setScale_b__120_1(); // 0x00000001806B6870-0x00000001806B6920
	[CompilerGenerated]
	private void _setGUIMove_b__121_0(); // 0x00000001806B4630-0x00000001806B46E0
	[CompilerGenerated]
	private void _setGUIMove_b__121_1(); // 0x00000001806B46E0-0x00000001806B47F0
	[CompilerGenerated]
	private void _setGUIMoveMargin_b__122_0(); // 0x00000001806B4580-0x00000001806B45C0
	[CompilerGenerated]
	private void _setGUIMoveMargin_b__122_1(); // 0x00000001806B45C0-0x00000001806B4630
	[CompilerGenerated]
	private void _setGUIScale_b__123_0(); // 0x00000001806B48D0-0x00000001806B4980
	[CompilerGenerated]
	private void _setGUIScale_b__123_1(); // 0x00000001806B4980-0x00000001806B4A90
	[CompilerGenerated]
	private void _setGUIAlpha_b__124_0(); // 0x00000001806B44F0-0x00000001806B4520
	[CompilerGenerated]
	private void _setGUIAlpha_b__124_1(); // 0x00000001806B4520-0x00000001806B4580
	[CompilerGenerated]
	private void _setGUIRotate_b__125_0(); // 0x00000001806B47F0-0x00000001806B4870
	[CompilerGenerated]
	private void _setGUIRotate_b__125_1(); // 0x00000001806B4870-0x00000001806B48D0
	[CompilerGenerated]
	private void _setDelayedSound_b__126_0(); // 0x00000001806B44E0-0x00000001806B44F0
}

