/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class LTDescr // TypeDefIndex: 305
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
	public Vector3 from { get; set; } // 0x0000000180864C60-0x0000000180864C80 0x000000018086AA00-0x000000018086AA10
	public Vector3 to { get; set; } // 0x0000000180864CC0-0x0000000180864CE0 0x000000018086AA30-0x000000018086AA40
	public ActionMethodDelegate easeInternal { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180319960-0x0000000180319970 0x0000000180319C80-0x0000000180319CA0
	public ActionMethodDelegate initInternal { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180319900-0x0000000180319910 0x0000000180319BD0-0x0000000180319BF0
	public Transform toTrans { get; } // 0x0000000180864CA0-0x0000000180864CC0 
	public int uniqueId { get; } // 0x0000000180864C80-0x0000000180864C90 
	public int id { get; } // 0x0000000180864C80-0x0000000180864C90 
	public LTDescrOptional optional { get; set; } // 0x0000000180864C90-0x0000000180864CA0 0x000000018086AA10-0x000000018086AA30

	// Nested types
	public delegate Vector3 EaseTypeDelegate(); // TypeDefIndex: 306; 0x0000000180317CC0-0x0000000180317D00

	public delegate void ActionMethodDelegate(); // TypeDefIndex: 307; 0x00000001802EBAF0-0x00000001802EBB90

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 308
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static ActionMethodDelegate __9__113_0; // 0x08
		public static ActionMethodDelegate __9__114_0; // 0x10

		// Constructors
		static __c(); // 0x0000000180330B30-0x0000000180330BA0
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _setCallback_b__113_0(); // 0x00000001802EB6C0-0x00000001802EB6D0
		internal void _setValue3_b__114_0(); // 0x00000001802EB6C0-0x00000001802EB6D0
	}

	// Constructors
	public LTDescr(); // 0x0000000180860FA0-0x0000000180861020

	// Methods
	public override string ToString(); // 0x000000018085AEA0-0x000000018085B4D0
	[Obsolete("Use \'LeanTween.cancel( id )\' instead")]
	public LTDescr cancel(GameObject gameObject); // 0x0000000180861D50-0x0000000180861E10
	public void reset(); // 0x0000000180865020-0x0000000180865170
	public LTDescr setFollow(); // 0x00000001808681C0-0x00000001808681D0
	public LTDescr setMoveX(); // 0x0000000180869080-0x0000000180869150
	public LTDescr setMoveY(); // 0x0000000180869150-0x0000000180869220
	public LTDescr setMoveZ(); // 0x0000000180869220-0x00000001808692F0
	public LTDescr setMoveLocalX(); // 0x0000000180868AD0-0x0000000180868BA0
	public LTDescr setMoveLocalY(); // 0x0000000180868BA0-0x0000000180868C70
	public LTDescr setMoveLocalZ(); // 0x0000000180868C70-0x0000000180868D40
	private void initFromInternal(); // 0x0000000180864D30-0x0000000180864D40
	public LTDescr setOffset(Vector3 offset); // 0x00000001808693C0-0x00000001808693E0
	public LTDescr setMoveCurved(); // 0x0000000180868A00-0x0000000180868AD0
	public LTDescr setMoveCurvedLocal(); // 0x0000000180868930-0x0000000180868A00
	public LTDescr setMoveSpline(); // 0x0000000180868EE0-0x0000000180868FB0
	public LTDescr setMoveSplineLocal(); // 0x0000000180868E10-0x0000000180868EE0
	public LTDescr setScaleX(); // 0x000000018086A290-0x000000018086A360
	public LTDescr setScaleY(); // 0x000000018086A360-0x000000018086A430
	public LTDescr setScaleZ(); // 0x000000018086A430-0x000000018086A500
	public LTDescr setRotateX(); // 0x0000000180869F50-0x000000018086A020
	public LTDescr setRotateY(); // 0x000000018086A020-0x000000018086A0F0
	public LTDescr setRotateZ(); // 0x000000018086A0F0-0x000000018086A1C0
	public LTDescr setRotateAround(); // 0x0000000180869DB0-0x0000000180869E80
	public LTDescr setRotateAroundLocal(); // 0x0000000180869CE0-0x0000000180869DB0
	public LTDescr setAlpha(); // 0x0000000180865250-0x0000000180865320
	public LTDescr setTextAlpha(); // 0x000000018086A680-0x000000018086A750
	public LTDescr setAlphaVertex(); // 0x0000000180865180-0x0000000180865250
	public LTDescr setColor(); // 0x0000000180865F60-0x0000000180866030
	public LTDescr setCallbackColor(); // 0x0000000180865390-0x0000000180865460
	public LTDescr setTextColor(); // 0x000000018086A750-0x000000018086A820
	public LTDescr setCanvasAlpha(); // 0x00000001808655A0-0x0000000180865670
	public LTDescr setCanvasGroupAlpha(); // 0x0000000180865740-0x0000000180865810
	public LTDescr setCanvasColor(); // 0x0000000180865670-0x0000000180865740
	public LTDescr setCanvasMoveX(); // 0x0000000180865810-0x00000001808658E0
	public LTDescr setCanvasMoveY(); // 0x00000001808658E0-0x00000001808659B0
	public LTDescr setCanvasMoveZ(); // 0x00000001808659B0-0x0000000180865A80
	private void initCanvasRotateAround(); // 0x0000000180864CE0-0x0000000180864D30
	public LTDescr setCanvasRotateAround(); // 0x0000000180865CF0-0x0000000180865DC0
	public LTDescr setCanvasRotateAroundLocal(); // 0x0000000180865C20-0x0000000180865CF0
	public LTDescr setCanvasPlaySprite(); // 0x0000000180865B50-0x0000000180865C20
	public LTDescr setCanvasMove(); // 0x0000000180865A80-0x0000000180865B50
	public LTDescr setCanvasScale(); // 0x0000000180865DC0-0x0000000180865E90
	public LTDescr setCanvasSizeDelta(); // 0x0000000180865E90-0x0000000180865F60
	private void callback(); // 0x0000000180861CC0-0x0000000180861D50
	public LTDescr setCallback(); // 0x0000000180865460-0x00000001808655A0
	public LTDescr setValue3(); // 0x000000018086A8C0-0x000000018086AA00
	public LTDescr setMove(); // 0x00000001808692F0-0x00000001808693C0
	public LTDescr setMoveLocal(); // 0x0000000180868D40-0x0000000180868E10
	public LTDescr setMoveToTransform(); // 0x0000000180868FB0-0x0000000180869080
	public LTDescr setRotate(); // 0x000000018086A1C0-0x000000018086A290
	public LTDescr setRotateLocal(); // 0x0000000180869E80-0x0000000180869F50
	public LTDescr setScale(); // 0x000000018086A500-0x000000018086A5D0
	public LTDescr setGUIMove(); // 0x00000001808685E0-0x00000001808686B0
	public LTDescr setGUIMoveMargin(); // 0x0000000180868510-0x00000001808685E0
	public LTDescr setGUIScale(); // 0x0000000180868780-0x0000000180868850
	public LTDescr setGUIAlpha(); // 0x0000000180868440-0x0000000180868510
	public LTDescr setGUIRotate(); // 0x00000001808686B0-0x0000000180868780
	public LTDescr setDelayedSound(); // 0x0000000180866040-0x0000000180866110
	public LTDescr setTarget(Transform trans); // 0x000000018086A640-0x000000018086A680
	private void init(); // 0x0000000180864EA0-0x0000000180865000
	private void initSpeed(); // 0x0000000180864D40-0x0000000180864EA0
	public LTDescr updateNow(); // 0x000000018086B8D0-0x000000018086B8F0
	public bool updateInternal(); // 0x000000018086B590-0x000000018086B8D0
	public void callOnCompletes(); // 0x0000000180861B80-0x0000000180861CC0
	public LTDescr setFromColor(Color col); // 0x0000000180868200-0x0000000180868270
	private static void alphaRecursive(Transform transform, float val, bool useRecursion = true /* Metadata: 0x0068AD9E */); // 0x0000000180861360-0x00000001808617A0
	private static void colorRecursive(Transform transform, Color toColor, bool useRecursion = true /* Metadata: 0x0068AD9F */); // 0x0000000180862150-0x0000000180862480
	private static void alphaRecursive(RectTransform rectTransform, float val, int recursiveLevel = 0 /* Metadata: 0x0068ADA0 */); // 0x00000001808617A0-0x0000000180861B80
	private static void alphaRecursiveSprite(Transform transform, float val); // 0x0000000180861020-0x0000000180861360
	private static void colorRecursiveSprite(Transform transform, Color toColor); // 0x0000000180861E10-0x0000000180862150
	private static void colorRecursive(RectTransform rectTransform, Color toColor); // 0x0000000180862480-0x00000001808627D0
	private static void textAlphaChildrenRecursive(Transform trans, float val, bool useRecursion = true /* Metadata: 0x0068ADA1 */); // 0x000000018086AA40-0x000000018086AD80
	private static void textAlphaRecursive(Transform trans, float val, bool useRecursion = true /* Metadata: 0x0068ADA2 */); // 0x000000018086AD80-0x000000018086B090
	private static void textColorRecursive(Transform trans, Color toColor); // 0x000000018086B090-0x000000018086B370
	private static Color tweenColor(LTDescr tween, float val); // 0x000000018086B370-0x000000018086B440
	public LTDescr pause(); // 0x0000000180865000-0x0000000180865020
	public LTDescr resume(); // 0x0000000180865170-0x0000000180865180
	public LTDescr setAxis(Vector3 axis); // 0x0000000180865360-0x0000000180865390
	public LTDescr setDelay(float delay); // 0x0000000180866030-0x0000000180866040
	public LTDescr setEase(LeanTweenType easeType); // 0x0000000180867700-0x0000000180868110
	public LTDescr setEaseLinear(); // 0x0000000180866E60-0x0000000180866EF0
	public LTDescr setEaseSpring(); // 0x0000000180867670-0x0000000180867700
	public LTDescr setEaseInQuad(); // 0x0000000180866C20-0x0000000180866CB0
	public LTDescr setEaseOutQuad(); // 0x0000000180867250-0x00000001808672E0
	public LTDescr setEaseInOutQuad(); // 0x00000001808669E0-0x0000000180866A70
	public LTDescr setEaseInCubic(); // 0x00000001808664D0-0x0000000180866560
	public LTDescr setEaseOutCubic(); // 0x00000001808670A0-0x0000000180867130
	public LTDescr setEaseInOutCubic(); // 0x0000000180866830-0x00000001808668C0
	public LTDescr setEaseInQuart(); // 0x0000000180866CB0-0x0000000180866D40
	public LTDescr setEaseOutQuart(); // 0x00000001808672E0-0x0000000180867370
	public LTDescr setEaseInOutQuart(); // 0x0000000180866A70-0x0000000180866B00
	public LTDescr setEaseInQuint(); // 0x0000000180866D40-0x0000000180866DD0
	public LTDescr setEaseOutQuint(); // 0x0000000180867370-0x0000000180867400
	public LTDescr setEaseInOutQuint(); // 0x0000000180866B00-0x0000000180866B90
	public LTDescr setEaseInSine(); // 0x0000000180866DD0-0x0000000180866E60
	public LTDescr setEaseOutSine(); // 0x0000000180867400-0x0000000180867490
	public LTDescr setEaseInOutSine(); // 0x0000000180866B90-0x0000000180866C20
	public LTDescr setEaseInExpo(); // 0x00000001808665F0-0x0000000180866680
	public LTDescr setEaseOutExpo(); // 0x00000001808671C0-0x0000000180867250
	public LTDescr setEaseInOutExpo(); // 0x0000000180866950-0x00000001808669E0
	public LTDescr setEaseInCirc(); // 0x0000000180866440-0x00000001808664D0
	public LTDescr setEaseOutCirc(); // 0x0000000180867010-0x00000001808670A0
	public LTDescr setEaseInOutCirc(); // 0x00000001808667A0-0x0000000180866830
	public LTDescr setEaseInBounce(); // 0x00000001808663B0-0x0000000180866440
	public LTDescr setEaseOutBounce(); // 0x0000000180866F80-0x0000000180867010
	public LTDescr setEaseInOutBounce(); // 0x0000000180866710-0x00000001808667A0
	public LTDescr setEaseInBack(); // 0x0000000180866320-0x00000001808663B0
	public LTDescr setEaseOutBack(); // 0x0000000180866EF0-0x0000000180866F80
	public LTDescr setEaseInOutBack(); // 0x0000000180866680-0x0000000180866710
	public LTDescr setEaseInElastic(); // 0x0000000180866560-0x00000001808665F0
	public LTDescr setEaseOutElastic(); // 0x0000000180867130-0x00000001808671C0
	public LTDescr setEaseInOutElastic(); // 0x00000001808668C0-0x0000000180866950
	public LTDescr setEasePunch(); // 0x0000000180867490-0x0000000180867580
	public LTDescr setEaseShake(); // 0x0000000180867580-0x0000000180867670
	private Vector3 tweenOnCurve(); // 0x000000018086B440-0x000000018086B590
	private Vector3 easeInOutQuad(); // 0x0000000180863790-0x00000001808638B0
	private Vector3 easeInQuad(); // 0x0000000180863C30-0x0000000180863CE0
	private Vector3 easeOutQuad(); // 0x0000000180864760-0x0000000180864840
	private Vector3 easeLinear(); // 0x0000000180863F80-0x0000000180864030
	private Vector3 easeSpring(); // 0x0000000180864AF0-0x0000000180864C60
	private Vector3 easeInCubic(); // 0x0000000180862B60-0x0000000180862C10
	private Vector3 easeOutCubic(); // 0x0000000180864470-0x0000000180864550
	private Vector3 easeInOutCubic(); // 0x0000000180863400-0x0000000180863510
	private Vector3 easeInQuart(); // 0x0000000180863CE0-0x0000000180863DA0
	private Vector3 easeOutQuart(); // 0x0000000180864840-0x0000000180864920
	private Vector3 easeInOutQuart(); // 0x00000001808638B0-0x0000000180863A40
	private Vector3 easeInQuint(); // 0x0000000180863DA0-0x0000000180863E70
	private Vector3 easeOutQuint(); // 0x0000000180864920-0x0000000180864A00
	private Vector3 easeInOutQuint(); // 0x0000000180863A40-0x0000000180863B60
	private Vector3 easeInSine(); // 0x0000000180863E70-0x0000000180863F80
	private Vector3 easeOutSine(); // 0x0000000180864A00-0x0000000180864AF0
	private Vector3 easeInOutSine(); // 0x0000000180863B60-0x0000000180863C30
	private Vector3 easeInExpo(); // 0x0000000180862D50-0x0000000180862E20
	private Vector3 easeOutExpo(); // 0x0000000180864690-0x0000000180864760
	private Vector3 easeInOutExpo(); // 0x0000000180863650-0x0000000180863790
	private Vector3 easeInCirc(); // 0x0000000180862A80-0x0000000180862B60
	private Vector3 easeOutCirc(); // 0x0000000180864370-0x0000000180864470
	private Vector3 easeInOutCirc(); // 0x0000000180863290-0x0000000180863400
	private Vector3 easeInBounce(); // 0x00000001808628D0-0x0000000180862A80
	private Vector3 easeOutBounce(); // 0x0000000180864130-0x0000000180864370
	private Vector3 easeInOutBounce(); // 0x0000000180862FF0-0x0000000180863290
	private Vector3 easeInBack(); // 0x00000001808627D0-0x00000001808628D0
	private Vector3 easeOutBack(); // 0x0000000180864030-0x0000000180864130
	private Vector3 easeInOutBack(); // 0x0000000180862E20-0x0000000180862FF0
	private Vector3 easeInElastic(); // 0x0000000180862C10-0x0000000180862D50
	private Vector3 easeOutElastic(); // 0x0000000180864550-0x0000000180864690
	private Vector3 easeInOutElastic(); // 0x0000000180863510-0x0000000180863650
	public LTDescr setOvershoot(float overshoot); // 0x0000000180869AE0-0x0000000180869AF0
	public LTDescr setPeriod(float period); // 0x0000000180869B30-0x0000000180869B40
	public LTDescr setScale(float scale); // 0x000000018086A5D0-0x000000018086A5E0
	public LTDescr setEase(AnimationCurve easeCurve); // 0x0000000180868110-0x00000001808681C0
	public LTDescr setTo(Vector3 to); // 0x000000018086A840-0x000000018086A8A0
	public LTDescr setTo(Transform to); // 0x000000018086A640-0x000000018086A680
	public LTDescr setFrom(Vector3 from); // 0x0000000180868360-0x0000000180868440
	public LTDescr setFrom(float from); // 0x0000000180868270-0x0000000180868360
	public LTDescr setDiff(Vector3 diff); // 0x0000000180866120-0x0000000180866140
	public LTDescr setHasInitialized(bool has); // 0x0000000180868850-0x0000000180868860
	public LTDescr setId(uint id, uint global_counter); // 0x0000000180868860-0x0000000180868870
	public LTDescr setPassed(float passed); // 0x00000001803434B0-0x00000001803434C0
	public LTDescr setTime(float time); // 0x000000018086A820-0x000000018086A840
	public LTDescr setSpeed(float speed); // 0x000000018086A5E0-0x000000018086A610
	public LTDescr setRepeat(int repeat); // 0x0000000180869C90-0x0000000180869CE0
	public LTDescr setLoopType(LeanTweenType loopType); // 0x0000000180868920-0x0000000180868930
	public LTDescr setUseEstimatedTime(bool useEstimatedTime); // 0x0000000180868870-0x0000000180868880
	public LTDescr setIgnoreTimeScale(bool useUnScaledTime); // 0x0000000180868870-0x0000000180868880
	public LTDescr setUseFrames(bool useFrames); // 0x000000018086A8A0-0x000000018086A8B0
	public LTDescr setUseManualTime(bool useManualTime); // 0x000000018086A8B0-0x000000018086A8C0
	public LTDescr setLoopCount(int loopCount); // 0x00000001808688B0-0x00000001808688D0
	public LTDescr setLoopOnce(); // 0x00000001808688D0-0x00000001808688E0
	public LTDescr setLoopClamp(); // 0x0000000180868890-0x00000001808688B0
	public LTDescr setLoopClamp(int loops); // 0x0000000180868880-0x0000000180868890
	public LTDescr setLoopPingPong(); // 0x0000000180868900-0x0000000180868920
	public LTDescr setLoopPingPong(int loops); // 0x00000001808688E0-0x0000000180868900
	public LTDescr setOnComplete(Action onComplete); // 0x0000000180869480-0x00000001808694C0
	public LTDescr setOnComplete(Action<object> onComplete); // 0x0000000180869440-0x0000000180869480
	public LTDescr setOnComplete(Action<object> onComplete, object onCompleteParam); // 0x00000001808694C0-0x0000000180869530
	public LTDescr setOnCompleteParam(object onCompleteParam); // 0x0000000180869400-0x0000000180869440
	public LTDescr setOnUpdate(Action<float> onUpdate); // 0x0000000180869930-0x0000000180869970
	public LTDescr setOnUpdateRatio(Action<float, float> onUpdate); // 0x0000000180869670-0x00000001808696B0
	public LTDescr setOnUpdateObject(Action<float, object> onUpdate); // 0x00000001808695F0-0x0000000180869630
	public LTDescr setOnUpdateVector2(Action<Vector2> onUpdate); // 0x00000001808696B0-0x00000001808696F0
	public LTDescr setOnUpdateVector3(Action<Vector3> onUpdate); // 0x00000001808696F0-0x0000000180869730
	public LTDescr setOnUpdateColor(Action<Color> onUpdate); // 0x0000000180869570-0x00000001808695B0
	public LTDescr setOnUpdateColor(Action<Color, object> onUpdate); // 0x00000001808695B0-0x00000001808695F0
	public LTDescr setOnUpdate(Action<Color> onUpdate); // 0x0000000180869570-0x00000001808695B0
	public LTDescr setOnUpdate(Action<Color, object> onUpdate); // 0x00000001808695B0-0x00000001808695F0
	public LTDescr setOnUpdate(Action<float, object> onUpdate, object onUpdateParam = null); // 0x0000000180869730-0x00000001808697B0
	public LTDescr setOnUpdate(Action<Vector3, object> onUpdate, object onUpdateParam = null); // 0x00000001808697B0-0x0000000180869830
	public LTDescr setOnUpdate(Action<Vector2> onUpdate, object onUpdateParam = null); // 0x0000000180869830-0x00000001808698B0
	public LTDescr setOnUpdate(Action<Vector3> onUpdate, object onUpdateParam = null); // 0x00000001808698B0-0x0000000180869930
	public LTDescr setOnUpdateParam(object onUpdateParam); // 0x0000000180869630-0x0000000180869670
	public LTDescr setOrientToPath(bool doesOrient); // 0x00000001808699F0-0x0000000180869AE0
	public LTDescr setOrientToPath2d(bool doesOrient2d); // 0x0000000180869970-0x00000001808699F0
	public LTDescr setRect(LTRect rect); // 0x0000000180869C40-0x0000000180869C80
	public LTDescr setRect(Rect rect); // 0x0000000180869B70-0x0000000180869C10
	public LTDescr setPath(LTBezierPath path); // 0x0000000180869AF0-0x0000000180869B30
	public LTDescr setPoint(Vector3 point); // 0x0000000180869B40-0x0000000180869B70
	public LTDescr setDestroyOnComplete(bool doesDestroy); // 0x0000000180866110-0x0000000180866120
	public LTDescr setAudio(object audio); // 0x0000000180865320-0x0000000180865360
	public LTDescr setOnCompleteOnRepeat(bool isOn); // 0x00000001808693E0-0x00000001808693F0
	public LTDescr setOnCompleteOnStart(bool isOn); // 0x00000001808693F0-0x0000000180869400
	public LTDescr setRect(RectTransform rect); // 0x0000000180869C10-0x0000000180869C40
	public LTDescr setSprites(Sprite[] sprites); // 0x000000018086A610-0x000000018086A640
	public LTDescr setFrameRate(float frameRate); // 0x00000001808681D0-0x0000000180868200
	public LTDescr setOnStart(Action onStart); // 0x0000000180869530-0x0000000180869570
	public LTDescr setDirection(float direction); // 0x0000000180866140-0x0000000180866320
	public LTDescr setRecursive(bool useRecursion); // 0x0000000180869C80-0x0000000180869C90
	[CompilerGenerated]
	private void _setMoveX_b__73_0(); // 0x000000018085F530-0x000000018085F560
	[CompilerGenerated]
	private void _setMoveX_b__73_1(); // 0x000000018085F560-0x000000018085F620
	[CompilerGenerated]
	private void _setMoveY_b__74_0(); // 0x000000018085F620-0x000000018085F660
	[CompilerGenerated]
	private void _setMoveY_b__74_1(); // 0x000000018085F660-0x000000018085F730
	[CompilerGenerated]
	private void _setMoveZ_b__75_0(); // 0x000000018085F730-0x000000018085F770
	[CompilerGenerated]
	private void _setMoveZ_b__75_1(); // 0x000000018085F770-0x000000018085F830
	[CompilerGenerated]
	private void _setMoveLocalX_b__76_0(); // 0x000000018085ECD0-0x000000018085ED00
	[CompilerGenerated]
	private void _setMoveLocalX_b__76_1(); // 0x000000018085ED00-0x000000018085EDC0
	[CompilerGenerated]
	private void _setMoveLocalY_b__77_0(); // 0x000000018085EDC0-0x000000018085EE00
	[CompilerGenerated]
	private void _setMoveLocalY_b__77_1(); // 0x000000018085EE00-0x000000018085EED0
	[CompilerGenerated]
	private void _setMoveLocalZ_b__78_0(); // 0x000000018085EED0-0x000000018085EF10
	[CompilerGenerated]
	private void _setMoveLocalZ_b__78_1(); // 0x000000018085EF10-0x000000018085EFD0
	[CompilerGenerated]
	private void _setMoveCurved_b__81_0(); // 0x000000018085EA50-0x000000018085EBE0
	[CompilerGenerated]
	private void _setMoveCurvedLocal_b__82_0(); // 0x000000018085E8C0-0x000000018085EA50
	[CompilerGenerated]
	private void _setMoveSpline_b__83_0(); // 0x000000018085F160-0x000000018085F2F0
	[CompilerGenerated]
	private void _setMoveSplineLocal_b__84_0(); // 0x000000018085EFD0-0x000000018085F160
	[CompilerGenerated]
	private void _setScaleX_b__85_0(); // 0x0000000180860750-0x0000000180860780
	[CompilerGenerated]
	private void _setScaleX_b__85_1(); // 0x0000000180860780-0x0000000180860840
	[CompilerGenerated]
	private void _setScaleY_b__86_0(); // 0x0000000180860840-0x0000000180860880
	[CompilerGenerated]
	private void _setScaleY_b__86_1(); // 0x0000000180860880-0x0000000180860950
	[CompilerGenerated]
	private void _setScaleZ_b__87_0(); // 0x0000000180860950-0x0000000180860990
	[CompilerGenerated]
	private void _setScaleZ_b__87_1(); // 0x0000000180860990-0x0000000180860A50
	[CompilerGenerated]
	private void _setRotateX_b__88_0(); // 0x0000000180860230-0x00000001808602D0
	[CompilerGenerated]
	private void _setRotateX_b__88_1(); // 0x00000001808602D0-0x0000000180860390
	[CompilerGenerated]
	private void _setRotateY_b__89_0(); // 0x0000000180860390-0x0000000180860430
	[CompilerGenerated]
	private void _setRotateY_b__89_1(); // 0x0000000180860430-0x0000000180860500
	[CompilerGenerated]
	private void _setRotateZ_b__90_0(); // 0x0000000180860500-0x00000001808605A0
	[CompilerGenerated]
	private void _setRotateZ_b__90_1(); // 0x00000001808605A0-0x0000000180860660
	[CompilerGenerated]
	private void _setRotateAround_b__91_0(); // 0x000000018085FBE0-0x000000018085FC30
	[CompilerGenerated]
	private void _setRotateAround_b__91_1(); // 0x000000018085FC30-0x000000018085FF10
	[CompilerGenerated]
	private void _setRotateAroundLocal_b__92_0(); // 0x000000018085F830-0x000000018085F880
	[CompilerGenerated]
	private void _setRotateAroundLocal_b__92_1(); // 0x000000018085F880-0x000000018085FBE0
	[CompilerGenerated]
	private void _setAlpha_b__93_0(); // 0x000000018085B4D0-0x000000018085BA20
	[CompilerGenerated]
	private void _setAlpha_b__93_2(); // 0x000000018085BBF0-0x000000018085BDB0
	[CompilerGenerated]
	private void _setAlpha_b__93_1(); // 0x000000018085BA20-0x000000018085BBF0
	[CompilerGenerated]
	private void _setTextAlpha_b__94_0(); // 0x0000000180860A50-0x0000000180860B40
	[CompilerGenerated]
	private void _setTextAlpha_b__94_1(); // 0x0000000180860B40-0x0000000180860BA0
	[CompilerGenerated]
	private void _setAlphaVertex_b__95_0(); // 0x000000018085BDB0-0x000000018085BE40
	[CompilerGenerated]
	private void _setAlphaVertex_b__95_1(); // 0x000000018085BE40-0x000000018085C1A0
	[CompilerGenerated]
	private void _setColor_b__96_0(); // 0x000000018085D9F0-0x000000018085DF90
	[CompilerGenerated]
	private void _setColor_b__96_1(); // 0x000000018085DF90-0x000000018085E310
	[CompilerGenerated]
	private void _setCallbackColor_b__97_0(); // 0x000000018085C1A0-0x000000018085C1C0
	[CompilerGenerated]
	private void _setCallbackColor_b__97_1(); // 0x000000018085C1C0-0x000000018085C540
	[CompilerGenerated]
	private void _setTextColor_b__98_0(); // 0x0000000180860BA0-0x0000000180860CE0
	[CompilerGenerated]
	private void _setTextColor_b__98_1(); // 0x0000000180860CE0-0x0000000180860FA0
	[CompilerGenerated]
	private void _setCanvasAlpha_b__99_0(); // 0x000000018085C540-0x000000018085C680
	[CompilerGenerated]
	private void _setCanvasAlpha_b__99_1(); // 0x000000018085C680-0x000000018085C8A0
	[CompilerGenerated]
	private void _setCanvasGroupAlpha_b__100_0(); // 0x000000018085CD40-0x000000018085CDA0
	[CompilerGenerated]
	private void _setCanvasGroupAlpha_b__100_1(); // 0x000000018085CDA0-0x000000018085CE40
	[CompilerGenerated]
	private void _setCanvasColor_b__101_0(); // 0x000000018085C8A0-0x000000018085CA30
	[CompilerGenerated]
	private void _setCanvasColor_b__101_1(); // 0x000000018085CA30-0x000000018085CD40
	[CompilerGenerated]
	private void _setCanvasMoveX_b__102_0(); // 0x000000018085CEE0-0x000000018085CF20
	[CompilerGenerated]
	private void _setCanvasMoveX_b__102_1(); // 0x000000018085CF20-0x000000018085CFE0
	[CompilerGenerated]
	private void _setCanvasMoveY_b__103_0(); // 0x000000018085CFE0-0x000000018085D020
	[CompilerGenerated]
	private void _setCanvasMoveY_b__103_1(); // 0x000000018085D020-0x000000018085D0E0
	[CompilerGenerated]
	private void _setCanvasMoveZ_b__104_0(); // 0x000000018085D0E0-0x000000018085D120
	[CompilerGenerated]
	private void _setCanvasMoveZ_b__104_1(); // 0x000000018085D120-0x000000018085D1D0
	[CompilerGenerated]
	private void _setCanvasRotateAround_b__106_0(); // 0x000000018085D610-0x000000018085D8A0
	[CompilerGenerated]
	private void _setCanvasRotateAroundLocal_b__107_0(); // 0x000000018085D320-0x000000018085D610
	[CompilerGenerated]
	private void _setCanvasPlaySprite_b__108_0(); // 0x000000018085D1D0-0x000000018085D240
	[CompilerGenerated]
	private void _setCanvasPlaySprite_b__108_1(); // 0x000000018085D240-0x000000018085D320
	[CompilerGenerated]
	private void _setCanvasMove_b__109_0(); // 0x000000018085CE40-0x000000018085CE80
	[CompilerGenerated]
	private void _setCanvasMove_b__109_1(); // 0x000000018085CE80-0x000000018085CEE0
	[CompilerGenerated]
	private void _setCanvasScale_b__110_0(); // 0x000000018085D8A0-0x000000018085D8E0
	[CompilerGenerated]
	private void _setCanvasScale_b__110_1(); // 0x000000018085D8E0-0x000000018085D940
	[CompilerGenerated]
	private void _setCanvasSizeDelta_b__111_0(); // 0x000000018085D940-0x000000018085D990
	[CompilerGenerated]
	private void _setCanvasSizeDelta_b__111_1(); // 0x000000018085D990-0x000000018085D9F0
	[CompilerGenerated]
	private void _setMove_b__115_0(); // 0x000000018085F2F0-0x000000018085F330
	[CompilerGenerated]
	private void _setMove_b__115_1(); // 0x000000018085F480-0x000000018085F530
	[CompilerGenerated]
	private void _setMoveLocal_b__116_0(); // 0x000000018085EBE0-0x000000018085EC20
	[CompilerGenerated]
	private void _setMoveLocal_b__116_1(); // 0x000000018085EC20-0x000000018085ECD0
	[CompilerGenerated]
	private void _setMoveToTransform_b__117_0(); // 0x000000018085F2F0-0x000000018085F330
	[CompilerGenerated]
	private void _setMoveToTransform_b__117_1(); // 0x000000018085F330-0x000000018085F480
	[CompilerGenerated]
	private void _setRotate_b__118_0(); // 0x00000001808600A0-0x0000000180860180
	[CompilerGenerated]
	private void _setRotate_b__118_1(); // 0x0000000180860180-0x0000000180860230
	[CompilerGenerated]
	private void _setRotateLocal_b__119_0(); // 0x000000018085FF10-0x000000018085FFF0
	[CompilerGenerated]
	private void _setRotateLocal_b__119_1(); // 0x000000018085FFF0-0x00000001808600A0
	[CompilerGenerated]
	private void _setScale_b__120_0(); // 0x0000000180860660-0x00000001808606A0
	[CompilerGenerated]
	private void _setScale_b__120_1(); // 0x00000001808606A0-0x0000000180860750
	[CompilerGenerated]
	private void _setGUIMove_b__121_0(); // 0x000000018085E460-0x000000018085E510
	[CompilerGenerated]
	private void _setGUIMove_b__121_1(); // 0x000000018085E510-0x000000018085E620
	[CompilerGenerated]
	private void _setGUIMoveMargin_b__122_0(); // 0x000000018085E3B0-0x000000018085E3F0
	[CompilerGenerated]
	private void _setGUIMoveMargin_b__122_1(); // 0x000000018085E3F0-0x000000018085E460
	[CompilerGenerated]
	private void _setGUIScale_b__123_0(); // 0x000000018085E700-0x000000018085E7B0
	[CompilerGenerated]
	private void _setGUIScale_b__123_1(); // 0x000000018085E7B0-0x000000018085E8C0
	[CompilerGenerated]
	private void _setGUIAlpha_b__124_0(); // 0x000000018085E320-0x000000018085E350
	[CompilerGenerated]
	private void _setGUIAlpha_b__124_1(); // 0x000000018085E350-0x000000018085E3B0
	[CompilerGenerated]
	private void _setGUIRotate_b__125_0(); // 0x000000018085E620-0x000000018085E6A0
	[CompilerGenerated]
	private void _setGUIRotate_b__125_1(); // 0x000000018085E6A0-0x000000018085E700
	[CompilerGenerated]
	private void _setDelayedSound_b__126_0(); // 0x000000018085E310-0x000000018085E320
}

