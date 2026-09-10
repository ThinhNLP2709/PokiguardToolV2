/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class LeanTween : MonoBehaviour // TypeDefIndex: 322
{
	// Fields
	public static bool throwErrors; // 0x00
	public static float tau; // 0x04
	public static float PI_DIV2; // 0x08
	private static LTSeq[] sequences; // 0x10
	private static LTDescr[] tweens; // 0x18
	private static int[] tweensFinished; // 0x20
	private static int[] tweensFinishedIds; // 0x28
	private static LTDescr tween; // 0x30
	private static int tweenMaxSearch; // 0x38
	private static int maxTweens; // 0x3C
	private static int maxSequences; // 0x40
	private static int frameRendered; // 0x44
	private static GameObject _tweenEmpty; // 0x48
	public static float dtEstimated; // 0x50
	public static float dtManual; // 0x54
	public static float dtActual; // 0x58
	private static uint global_counter; // 0x5C
	private static int i; // 0x60
	private static int j; // 0x64
	private static int finishedCnt; // 0x68
	public static AnimationCurve punch; // 0x70
	public static AnimationCurve shake; // 0x78
	private static int maxTweenReached; // 0x80
	public static int startSearch; // 0x84
	public static LTDescr d; // 0x88
	private static Action<LTEvent>[] eventListeners; // 0x90
	private static GameObject[] goListeners; // 0x98
	private static int eventsMaxSearch; // 0xA0
	public static int EVENTS_MAX; // 0xA4
	public static int LISTENERS_MAX; // 0xA8
	private static int INIT_LISTENERS_MAX; // 0xAC

	// Properties
	public static int maxSearch { get; } // 0x0000000180325810-0x0000000180325860 
	public static int maxSimulataneousTweens { get; } // 0x0000000180325860-0x00000001803258B0 
	public static int tweensRunning { get; } // 0x0000000180325970-0x0000000180325A50 
	public static GameObject tweenEmpty { get; } // 0x00000001803258B0-0x0000000180325970 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass193_0 // TypeDefIndex: 323
	{
		// Fields
		public LTDescr d; // 0x10
		public float smoothTime; // 0x18
		public float maxSpeed; // 0x1C

		// Constructors
		public __c__DisplayClass193_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _followDamp_b__0(); // 0x000000018032D1A0-0x000000018032D3D0
		internal void _followDamp_b__1(); // 0x000000018032D3D0-0x000000018032D600
		internal void _followDamp_b__2(); // 0x000000018032D600-0x000000018032D720
		internal void _followDamp_b__3(); // 0x000000018032D720-0x000000018032D840
		internal void _followDamp_b__4(); // 0x000000018032D840-0x000000018032D960
		internal void _followDamp_b__5(); // 0x000000018032D960-0x000000018032DA80
		internal void _followDamp_b__6(); // 0x000000018032DA80-0x000000018032DBA0
		internal void _followDamp_b__7(); // 0x000000018032DBA0-0x000000018032DCC0
		internal void _followDamp_b__8(); // 0x000000018032DCC0-0x000000018032DEA0
		internal void _followDamp_b__9(); // 0x000000018032DEA0-0x000000018032E130
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass194_0 // TypeDefIndex: 324
	{
		// Fields
		public LTDescr d; // 0x10
		public float smoothTime; // 0x18
		public float maxSpeed; // 0x1C
		public float friction; // 0x20
		public float accelRate; // 0x24

		// Constructors
		public __c__DisplayClass194_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _followSpring_b__0(); // 0x000000018032E130-0x000000018032E300
		internal void _followSpring_b__1(); // 0x000000018032E300-0x000000018032E490
		internal void _followSpring_b__2(); // 0x000000018032E490-0x000000018032E5D0
		internal void _followSpring_b__3(); // 0x000000018032E5D0-0x000000018032E710
		internal void _followSpring_b__4(); // 0x000000018032E710-0x000000018032E850
		internal void _followSpring_b__5(); // 0x000000018032E850-0x000000018032E990
		internal void _followSpring_b__6(); // 0x000000018032E990-0x000000018032EAD0
		internal void _followSpring_b__7(); // 0x000000018032EAD0-0x000000018032EC10
		internal void _followSpring_b__8(); // 0x000000018032EC10-0x000000018032ED90
		internal void _followSpring_b__9(); // 0x000000018032ED90-0x000000018032F090
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass195_0 // TypeDefIndex: 325
	{
		// Fields
		public LTDescr d; // 0x10
		public float smoothTime; // 0x18
		public float maxSpeed; // 0x1C
		public float friction; // 0x20
		public float accelRate; // 0x24
		public float hitDamping; // 0x28

		// Constructors
		public __c__DisplayClass195_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _followBounceOut_b__0(); // 0x000000018032F090-0x000000018032F270
		internal void _followBounceOut_b__1(); // 0x000000018032F270-0x000000018032F450
		internal void _followBounceOut_b__2(); // 0x000000018032F450-0x000000018032F590
		internal void _followBounceOut_b__3(); // 0x000000018032F590-0x000000018032F6D0
		internal void _followBounceOut_b__4(); // 0x000000018032F6D0-0x000000018032F810
		internal void _followBounceOut_b__5(); // 0x000000018032F810-0x000000018032F950
		internal void _followBounceOut_b__6(); // 0x000000018032F950-0x000000018032FA90
		internal void _followBounceOut_b__7(); // 0x000000018032FA90-0x000000018032FBD0
		internal void _followBounceOut_b__8(); // 0x000000018032FBD0-0x000000018032FD60
		internal void _followBounceOut_b__9(); // 0x000000018032FD60-0x0000000180330090
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass196_0 // TypeDefIndex: 326
	{
		// Fields
		public LTDescr d; // 0x10
		public float moveSpeed; // 0x18

		// Constructors
		public __c__DisplayClass196_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _followLinear_b__0(); // 0x0000000180330090-0x0000000180330250
		internal void _followLinear_b__1(); // 0x0000000180330250-0x00000001803303B0
		internal void _followLinear_b__2(); // 0x00000001803303B0-0x0000000180330460
		internal void _followLinear_b__3(); // 0x0000000180330460-0x0000000180330510
		internal void _followLinear_b__4(); // 0x0000000180330510-0x00000001803305C0
		internal void _followLinear_b__5(); // 0x00000001803305C0-0x0000000180330670
		internal void _followLinear_b__6(); // 0x0000000180330670-0x0000000180330720
		internal void _followLinear_b__7(); // 0x0000000180330720-0x00000001803307D0
		internal void _followLinear_b__8(); // 0x00000001803307D0-0x0000000180330930
		internal void _followLinear_b__9(); // 0x0000000180330930-0x0000000180330B30
	}

	// Constructors
	public LeanTween(); // 0x00000001802EBA70-0x00000001802EBAF0
	static LeanTween(); // 0x000000018031FE10-0x00000001803204E0

	// Methods
	public static void init(); // 0x0000000180325FD0-0x0000000180326070
	public static void init(int maxSimultaneousTweens); // 0x0000000180325F70-0x0000000180325FD0
	public static void init(int maxSimultaneousTweens, int maxSimultaneousSequences); // 0x0000000180325A50-0x0000000180325F70
	public static void reset(); // 0x0000000180329FF0-0x000000018032A120
	public void Update(); // 0x000000018031FDD0-0x000000018031FE10
	private static void onLevelWasLoaded54(Scene scene, LoadSceneMode mode); // 0x0000000180328DA0-0x0000000180328E30
	private static void internalOnLevelWasLoaded(int lvl); // 0x0000000180326070-0x00000001803260B0
	public static void update(); // 0x000000018032BC40-0x000000018032C280
	public static void removeTween(int i, int uniqueId); // 0x0000000180329F50-0x0000000180329FF0
	public static void removeTween(int i, bool shouldReset = true /* Metadata: 0x0068AEA0 */); // 0x0000000180329CA0-0x0000000180329F50
	public static Vector3[] add(Vector3[] a, Vector3 b); // 0x0000000180320960-0x0000000180320AA0
	public static float closestRot(float from, float to); // 0x0000000180321CD0-0x0000000180321D70
	public static void cancelAll(); // 0x0000000180321180-0x00000001803212B0
	public static void cancelAll(bool callComplete); // 0x0000000180320FF0-0x0000000180321180
	public static void cancel(GameObject gameObject); // 0x0000000180321950-0x0000000180321AB0
	public static void cancel(GameObject gameObject, bool callOnComplete, TweenAction matchType = TweenAction.NONE /* Metadata: 0x0068AEA1 */); // 0x00000001803216F0-0x0000000180321880
	public static void cancel(RectTransform rect); // 0x0000000180321AB0-0x0000000180321C20
	public static void cancel(GameObject gameObject, int uniqueId, bool callOnComplete = false /* Metadata: 0x0068AEA2 */); // 0x0000000180321480-0x00000001803216A0
	public static void cancel(LTRect ltRect, int uniqueId); // 0x0000000180321880-0x0000000180321950
	public static void cancel(int uniqueId); // 0x00000001803216A0-0x00000001803216F0
	public static void cancel(int uniqueId, bool callOnComplete); // 0x00000001803212B0-0x0000000180321480
	public static LTDescr descr(int uniqueId); // 0x0000000180322800-0x00000001803229A0
	public static LTDescr description(int uniqueId); // 0x00000001803229A0-0x00000001803229F0
	public static LTDescr[] descriptions(GameObject gameObject = null); // 0x00000001803229F0-0x0000000180322C50
	[Obsolete("Use \'pause( id )\' instead")]
	public static void pause(GameObject gameObject, int uniqueId); // 0x0000000180329350-0x0000000180329440
	public static void pause(int uniqueId); // 0x0000000180329440-0x00000001803294F0
	public static void pause(GameObject gameObject); // 0x00000001803291C0-0x0000000180329350
	public static void pauseAll(); // 0x0000000180329120-0x00000001803291C0
	public static void resumeAll(); // 0x000000018032A120-0x000000018032A1C0
	[Obsolete("Use \'resume( id )\' instead")]
	public static void resume(GameObject gameObject, int uniqueId); // 0x000000018032A1C0-0x000000018032A2B0
	public static void resume(int uniqueId); // 0x000000018032A2B0-0x000000018032A360
	public static void resume(GameObject gameObject); // 0x000000018032A360-0x000000018032A4F0
	public static bool isPaused(GameObject gameObject = null); // 0x0000000180326120-0x0000000180326400
	public static bool isPaused(RectTransform rect); // 0x00000001803260B0-0x0000000180326120
	public static bool isPaused(int uniqueId); // 0x0000000180326400-0x0000000180326530
	public static bool isTweening(GameObject gameObject = null); // 0x00000001803266F0-0x0000000180326910
	public static bool isTweening(RectTransform rect); // 0x0000000180326680-0x00000001803266F0
	public static bool isTweening(int uniqueId); // 0x0000000180326910-0x00000001803269D0
	public static bool isTweening(LTRect ltRect); // 0x0000000180326530-0x0000000180326680
	public static void drawBezierPath(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float arrowSize = 0f /* Metadata: 0x0068AEA3 */, Transform arrowTransform = null); // 0x0000000180323010-0x0000000180323870
	public static object logError(string error); // 0x0000000180326A00-0x0000000180326AB0
	public static LTDescr options(LTDescr seed); // 0x00000001803290C0-0x0000000180329120
	public static LTDescr options(); // 0x0000000180328E30-0x00000001803290C0
	private static LTDescr pushNewTween(GameObject gameObject, Vector3 to, float time, LTDescr tween); // 0x0000000180329620-0x0000000180329790
	public static LTDescr play(RectTransform rectTransform, Sprite[] sprites); // 0x00000001803294F0-0x0000000180329620
	public static LTSeq sequence(bool initSequence = true /* Metadata: 0x0068AEA7 */); // 0x000000018032B4C0-0x000000018032B6B0
	public static LTDescr alpha(GameObject gameObject, float to, float time); // 0x0000000180320DF0-0x0000000180320F00
	public static LTDescr alpha(LTRect ltRect, float to, float time); // 0x0000000180320F00-0x0000000180320FF0
	public static LTDescr textAlpha(RectTransform rectTransform, float to, float time); // 0x000000018032B890-0x000000018032B960
	public static LTDescr alphaText(RectTransform rectTransform, float to, float time); // 0x0000000180320B70-0x0000000180320C40
	public static LTDescr alphaCanvas(CanvasGroup canvasGroup, float to, float time); // 0x0000000180320AA0-0x0000000180320B70
	public static LTDescr alphaVertex(GameObject gameObject, float to, float time); // 0x0000000180320C40-0x0000000180320D00
	public static LTDescr color(GameObject gameObject, Color to, float time); // 0x0000000180321FD0-0x0000000180322120
	public static LTDescr textColor(RectTransform rectTransform, Color to, float time); // 0x000000018032B960-0x000000018032BA80
	public static LTDescr colorText(RectTransform rectTransform, Color to, float time); // 0x0000000180321D70-0x0000000180321E90
	public static LTDescr delayedCall(float delayTime, Action callback); // 0x0000000180322120-0x0000000180322200
	public static LTDescr delayedCall(float delayTime, Action<object> callback); // 0x00000001803224C0-0x00000001803225A0
	public static LTDescr delayedCall(GameObject gameObject, float delayTime, Action callback); // 0x00000001803222E0-0x00000001803224C0
	public static LTDescr delayedCall(GameObject gameObject, float delayTime, Action<object> callback); // 0x0000000180322200-0x00000001803222E0
	public static LTDescr destroyAfter(LTRect rect, float delayTime); // 0x0000000180322C50-0x0000000180322D40
	public static LTDescr move(GameObject gameObject, Vector3 to, float time); // 0x0000000180328C10-0x0000000180328CC0
	public static LTDescr move(GameObject gameObject, Vector2 to, float time); // 0x0000000180328700-0x0000000180328800
	public static LTDescr move(GameObject gameObject, Vector3[] to, float time); // 0x0000000180328440-0x0000000180328700
	public static LTDescr move(GameObject gameObject, LTBezierPath to, float time); // 0x0000000180328200-0x0000000180328440
	public static LTDescr move(GameObject gameObject, LTSpline to, float time); // 0x00000001803289D0-0x0000000180328C10
	public static LTDescr moveSpline(GameObject gameObject, Vector3[] to, float time); // 0x0000000180327840-0x0000000180327AB0
	public static LTDescr moveSpline(GameObject gameObject, LTSpline to, float time); // 0x0000000180327AB0-0x0000000180327CF0
	public static LTDescr moveSplineLocal(GameObject gameObject, Vector3[] to, float time); // 0x00000001803275D0-0x0000000180327840
	public static LTDescr move(LTRect ltRect, Vector2 to, float time); // 0x0000000180328800-0x00000001803288F0
	public static LTDescr moveMargin(LTRect ltRect, Vector2 to, float time); // 0x00000001803274E0-0x00000001803275D0
	public static LTDescr moveX(GameObject gameObject, float to, float time); // 0x0000000180327DE0-0x0000000180327EA0
	public static LTDescr moveY(GameObject gameObject, float to, float time); // 0x0000000180327F90-0x0000000180328050
	public static LTDescr moveZ(GameObject gameObject, float to, float time); // 0x0000000180328140-0x0000000180328200
	public static LTDescr moveLocal(GameObject gameObject, Vector3 to, float time); // 0x0000000180326CF0-0x0000000180326DA0
	public static LTDescr moveLocal(GameObject gameObject, Vector3[] to, float time); // 0x0000000180327220-0x00000001803274E0
	public static LTDescr moveLocalX(GameObject gameObject, float to, float time); // 0x0000000180326AB0-0x0000000180326B70
	public static LTDescr moveLocalY(GameObject gameObject, float to, float time); // 0x0000000180326B70-0x0000000180326C30
	public static LTDescr moveLocalZ(GameObject gameObject, float to, float time); // 0x0000000180326C30-0x0000000180326CF0
	public static LTDescr moveLocal(GameObject gameObject, LTBezierPath to, float time); // 0x0000000180326FE0-0x0000000180327220
	public static LTDescr moveLocal(GameObject gameObject, LTSpline to, float time); // 0x0000000180326DA0-0x0000000180326FE0
	public static LTDescr move(GameObject gameObject, Transform to, float time); // 0x0000000180328CC0-0x0000000180328DA0
	public static LTDescr rotate(GameObject gameObject, Vector3 to, float time); // 0x000000018032AF50-0x000000018032B000
	public static LTDescr rotate(LTRect ltRect, float to, float time); // 0x000000018032AE70-0x000000018032AF50
	public static LTDescr rotateLocal(GameObject gameObject, Vector3 to, float time); // 0x000000018032A930-0x000000018032A9E0
	public static LTDescr rotateX(GameObject gameObject, float to, float time); // 0x000000018032A9E0-0x000000018032AAA0
	public static LTDescr rotateY(GameObject gameObject, float to, float time); // 0x000000018032AAA0-0x000000018032AB60
	public static LTDescr rotateZ(GameObject gameObject, float to, float time); // 0x000000018032AB60-0x000000018032AC20
	public static LTDescr rotateAround(GameObject gameObject, Vector3 axis, float add, float time); // 0x000000018032A710-0x000000018032A800
	public static LTDescr rotateAroundLocal(GameObject gameObject, Vector3 axis, float add, float time); // 0x000000018032A4F0-0x000000018032A5E0
	public static LTDescr scale(GameObject gameObject, Vector3 to, float time); // 0x000000018032B240-0x000000018032B2F0
	public static LTDescr scale(LTRect ltRect, Vector2 to, float time); // 0x000000018032B2F0-0x000000018032B3E0
	public static LTDescr scaleX(GameObject gameObject, float to, float time); // 0x000000018032B000-0x000000018032B0C0
	public static LTDescr scaleY(GameObject gameObject, float to, float time); // 0x000000018032B0C0-0x000000018032B180
	public static LTDescr scaleZ(GameObject gameObject, float to, float time); // 0x000000018032B180-0x000000018032B240
	public static LTDescr value(GameObject gameObject, float from, float to, float time); // 0x000000018032C710-0x000000018032C800
	public static LTDescr value(float from, float to, float time); // 0x000000018032CA00-0x000000018032CB00
	public static LTDescr value(GameObject gameObject, Vector2 from, Vector2 to, float time); // 0x000000018032D060-0x000000018032D1A0
	public static LTDescr value(GameObject gameObject, Vector3 from, Vector3 to, float time); // 0x000000018032C800-0x000000018032C8E0
	public static LTDescr value(GameObject gameObject, Color from, Color to, float time); // 0x000000018032C280-0x000000018032C410
	public static LTDescr value(GameObject gameObject, Action<float> callOnUpdate, float from, float to, float time); // 0x000000018032CD80-0x000000018032CEC0
	public static LTDescr value(GameObject gameObject, Action<float, float> callOnUpdateRatio, float from, float to, float time); // 0x000000018032CB00-0x000000018032CC40
	public static LTDescr value(GameObject gameObject, Action<Color> callOnUpdate, Color from, Color to, float time); // 0x000000018032C570-0x000000018032C710
	public static LTDescr value(GameObject gameObject, Action<Color, object> callOnUpdate, Color from, Color to, float time); // 0x000000018032CEC0-0x000000018032D060
	public static LTDescr value(GameObject gameObject, Action<Vector2> callOnUpdate, Vector2 from, Vector2 to, float time); // 0x000000018032C410-0x000000018032C570
	public static LTDescr value(GameObject gameObject, Action<Vector3> callOnUpdate, Vector3 from, Vector3 to, float time); // 0x000000018032C8E0-0x000000018032CA00
	public static LTDescr value(GameObject gameObject, Action<float, object> callOnUpdate, float from, float to, float time); // 0x000000018032CC40-0x000000018032CD80
	public static LTDescr delayedSound(AudioClip audio, Vector3 pos, float volume); // 0x00000001803226D0-0x0000000180322800
	public static LTDescr delayedSound(GameObject gameObject, AudioClip audio, Vector3 pos, float volume); // 0x00000001803225A0-0x00000001803226D0
	public static LTDescr move(RectTransform rectTrans, Vector3 to, float time); // 0x00000001803288F0-0x00000001803289D0
	public static LTDescr moveX(RectTransform rectTrans, float to, float time); // 0x0000000180327CF0-0x0000000180327DE0
	public static LTDescr moveY(RectTransform rectTrans, float to, float time); // 0x0000000180327EA0-0x0000000180327F90
	public static LTDescr moveZ(RectTransform rectTrans, float to, float time); // 0x0000000180328050-0x0000000180328140
	public static LTDescr rotate(RectTransform rectTrans, float to, float time); // 0x000000018032AD40-0x000000018032AE70
	public static LTDescr rotate(RectTransform rectTrans, Vector3 to, float time); // 0x000000018032AC20-0x000000018032AD40
	public static LTDescr rotateAround(RectTransform rectTrans, Vector3 axis, float to, float time); // 0x000000018032A800-0x000000018032A930
	public static LTDescr rotateAroundLocal(RectTransform rectTrans, Vector3 axis, float to, float time); // 0x000000018032A5E0-0x000000018032A710
	public static LTDescr scale(RectTransform rectTrans, Vector3 to, float time); // 0x000000018032B3E0-0x000000018032B4C0
	public static LTDescr size(RectTransform rectTrans, Vector2 to, float time); // 0x000000018032B6B0-0x000000018032B7B0
	public static LTDescr alpha(RectTransform rectTrans, float to, float time); // 0x0000000180320D00-0x0000000180320DF0
	public static LTDescr color(RectTransform rectTrans, Color to, float time); // 0x0000000180321E90-0x0000000180321FD0
	public static float tweenOnCurve(LTDescr tweenDescr, float ratioPassed); // 0x000000018032BBE0-0x000000018032BC40
	public static Vector3 tweenOnCurveVector(LTDescr tweenDescr, float ratioPassed); // 0x000000018032BA80-0x000000018032BBE0
	public static float easeOutQuadOpt(float start, float diff, float ratioPassed); // 0x00000001803247B0-0x00000001803247D0
	public static float easeInQuadOpt(float start, float diff, float ratioPassed); // 0x00000001803243D0-0x00000001803243E0
	public static float easeInOutQuadOpt(float start, float diff, float ratioPassed); // 0x00000001803241D0-0x0000000180324230
	public static Vector3 easeInOutQuadOpt(Vector3 start, Vector3 diff, float ratioPassed); // 0x00000001803240B0-0x00000001803241D0
	public static float linear(float start, float end, float val); // 0x00000001803269D0-0x0000000180326A00
	public static float clerp(float start, float end, float val); // 0x0000000180321C20-0x0000000180321CD0
	public static float spring(float start, float end, float val); // 0x000000018032B7B0-0x000000018032B890
	public static float easeInQuad(float start, float end, float val); // 0x00000001803243E0-0x0000000180324400
	public static float easeOutQuad(float start, float end, float val); // 0x00000001803247D0-0x0000000180324800
	public static float easeInOutQuad(float start, float end, float val); // 0x0000000180324230-0x0000000180324290
	public static float easeInOutQuadOpt2(float start, float diffBy2, float val, float val2); // 0x0000000180324070-0x00000001803240B0
	public static float easeInCubic(float start, float end, float val); // 0x00000001803239B0-0x00000001803239D0
	public static float easeOutCubic(float start, float end, float val); // 0x0000000180324600-0x0000000180324630
	public static float easeInOutCubic(float start, float end, float val); // 0x0000000180323DF0-0x0000000180323E50
	public static float easeInQuart(float start, float end, float val); // 0x0000000180324400-0x0000000180324420
	public static float easeOutQuart(float start, float end, float val); // 0x0000000180324800-0x0000000180324840
	public static float easeInOutQuart(float start, float end, float val); // 0x0000000180324290-0x0000000180324300
	public static float easeInQuint(float start, float end, float val); // 0x0000000180324420-0x0000000180324440
	public static float easeOutQuint(float start, float end, float val); // 0x0000000180324840-0x0000000180324880
	public static float easeInOutQuint(float start, float end, float val); // 0x0000000180324300-0x0000000180324370
	public static float easeInSine(float start, float end, float val); // 0x0000000180324440-0x0000000180324490
	public static float easeOutSine(float start, float end, float val); // 0x0000000180324880-0x00000001803248C0
	public static float easeInOutSine(float start, float end, float val); // 0x0000000180324370-0x00000001803243D0
	public static float easeInExpo(float start, float end, float val); // 0x0000000180323AF0-0x0000000180323B40
	public static float easeOutExpo(float start, float end, float val); // 0x0000000180324750-0x00000001803247B0
	public static float easeInOutExpo(float start, float end, float val); // 0x0000000180323FE0-0x0000000180324070
	public static float easeInCirc(float start, float end, float val); // 0x0000000180323940-0x00000001803239B0
	public static float easeOutCirc(float start, float end, float val); // 0x00000001803245A0-0x0000000180324600
	public static float easeInOutCirc(float start, float end, float val); // 0x0000000180323D30-0x0000000180323DF0
	public static float easeInBounce(float start, float end, float val); // 0x00000001803238B0-0x0000000180323940
	public static float easeOutBounce(float start, float end, float val); // 0x00000001803244D0-0x00000001803245A0
	public static float easeInOutBounce(float start, float end, float val); // 0x0000000180323BE0-0x0000000180323D30
	public static float easeInBack(float start, float end, float val, float overshoot = 1f /* Metadata: 0x0068AEA8 */); // 0x0000000180323870-0x00000001803238B0
	public static float easeOutBack(float start, float end, float val, float overshoot = 1f /* Metadata: 0x0068AEAC */); // 0x0000000180324490-0x00000001803244D0
	public static float easeInOutBack(float start, float end, float val, float overshoot = 1f /* Metadata: 0x0068AEB0 */); // 0x0000000180323B40-0x0000000180323BE0
	public static float easeInElastic(float start, float end, float val, float overshoot = 1f /* Metadata: 0x0068AEB4 */, float period = 0.3f /* Metadata: 0x0068AEB8 */); // 0x00000001803239D0-0x0000000180323AF0
	public static float easeOutElastic(float start, float end, float val, float overshoot = 1f /* Metadata: 0x0068AEBC */, float period = 0.3f /* Metadata: 0x0068AEC0 */); // 0x0000000180324630-0x0000000180324750
	public static float easeInOutElastic(float start, float end, float val, float overshoot = 1f /* Metadata: 0x0068AEC4 */, float period = 0.3f /* Metadata: 0x0068AEC8 */); // 0x0000000180323E50-0x0000000180323FE0
	public static LTDescr followDamp(Transform trans, Transform target, LeanProp prop, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0068AECC */); // 0x0000000180324C90-0x0000000180325070
	public static LTDescr followSpring(Transform trans, Transform target, LeanProp prop, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0068AED0 */, float friction = 2f /* Metadata: 0x0068AED4 */, float accelRate = 0.5f /* Metadata: 0x0068AED8 */); // 0x0000000180325410-0x0000000180325810
	public static LTDescr followBounceOut(Transform trans, Transform target, LeanProp prop, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0068AEDC */, float friction = 2f /* Metadata: 0x0068AEE0 */, float accelRate = 0.5f /* Metadata: 0x0068AEE4 */, float hitDamping = 0.9f /* Metadata: 0x0068AEE8 */); // 0x00000001803248C0-0x0000000180324C90
	public static LTDescr followLinear(Transform trans, Transform target, LeanProp prop, float moveSpeed); // 0x0000000180325070-0x0000000180325410
	public static void addListener(int eventId, Action<LTEvent> callback); // 0x00000001803204E0-0x0000000180320550
	public static void addListener(GameObject caller, int eventId, Action<LTEvent> callback); // 0x0000000180320550-0x0000000180320960
	public static bool removeListener(int eventId, Action<LTEvent> callback); // 0x0000000180329870-0x0000000180329AA0
	public static bool removeListener(int eventId); // 0x0000000180329790-0x0000000180329870
	public static bool removeListener(GameObject caller, int eventId, Action<LTEvent> callback); // 0x0000000180329AA0-0x0000000180329CA0
	public static void dispatchEvent(int eventId); // 0x0000000180322FC0-0x0000000180323010
	public static void dispatchEvent(int eventId, object data); // 0x0000000180322D40-0x0000000180322FC0
}

