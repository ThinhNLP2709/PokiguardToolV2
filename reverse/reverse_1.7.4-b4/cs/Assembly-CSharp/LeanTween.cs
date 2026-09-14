/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class LeanTween : MonoBehaviour // TypeDefIndex: 319
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
	public static int maxSearch { get; } // 0x00000001802DD950-0x00000001802DD9B0 
	public static int maxSimulataneousTweens { get; } // 0x00000001802DD9B0-0x00000001802DDA10 
	public static int tweensRunning { get; } // 0x00000001802DDA10-0x00000001802DDAF0 
	public static GameObject tweenEmpty { get; } // 0x00000001802E3160-0x00000001802E3220 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass193_0 // TypeDefIndex: 320
	{
		// Fields
		public LTDescr d; // 0x10
		public float smoothTime; // 0x18
		public float maxSpeed; // 0x1C

		// Constructors
		public __c__DisplayClass193_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _followDamp_b__0(); // 0x00000001802F06C0-0x00000001802F09D0
		internal void _followDamp_b__1(); // 0x00000001802F09D0-0x00000001802F0CE0
		internal void _followDamp_b__2(); // 0x00000001802F0CE0-0x00000001802F0ED0
		internal void _followDamp_b__3(); // 0x00000001802F0ED0-0x00000001802F10D0
		internal void _followDamp_b__4(); // 0x00000001802F10D0-0x00000001802F12D0
		internal void _followDamp_b__5(); // 0x00000001802F12D0-0x00000001802F14C0
		internal void _followDamp_b__6(); // 0x00000001802F14C0-0x00000001802F16C0
		internal void _followDamp_b__7(); // 0x00000001802F16C0-0x00000001802F18C0
		internal void _followDamp_b__8(); // 0x00000001802F18C0-0x00000001802F1BB0
		internal void _followDamp_b__9(); // 0x00000001802F1BB0-0x00000001802F1E90
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass194_0 // TypeDefIndex: 321
	{
		// Fields
		public LTDescr d; // 0x10
		public float smoothTime; // 0x18
		public float maxSpeed; // 0x1C
		public float friction; // 0x20
		public float accelRate; // 0x24

		// Constructors
		public __c__DisplayClass194_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _followSpring_b__0(); // 0x00000001802F1E90-0x00000001802F2130
		internal void _followSpring_b__1(); // 0x00000001802F2130-0x00000001802F23A0
		internal void _followSpring_b__2(); // 0x00000001802F23A0-0x00000001802F25B0
		internal void _followSpring_b__3(); // 0x00000001802F25B0-0x00000001802F27C0
		internal void _followSpring_b__4(); // 0x00000001802F27C0-0x00000001802F29D0
		internal void _followSpring_b__5(); // 0x00000001802F29D0-0x00000001802F2BE0
		internal void _followSpring_b__6(); // 0x00000001802F2BE0-0x00000001802F2DF0
		internal void _followSpring_b__7(); // 0x00000001802F2DF0-0x00000001802F3000
		internal void _followSpring_b__8(); // 0x00000001802F3000-0x00000001802F32B0
		internal void _followSpring_b__9(); // 0x00000001802F32B0-0x00000001802F34A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass195_0 // TypeDefIndex: 322
	{
		// Fields
		public LTDescr d; // 0x10
		public float smoothTime; // 0x18
		public float maxSpeed; // 0x1C
		public float friction; // 0x20
		public float accelRate; // 0x24
		public float hitDamping; // 0x28

		// Constructors
		public __c__DisplayClass195_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _followBounceOut_b__0(); // 0x00000001802F34A0-0x00000001802F3750
		internal void _followBounceOut_b__1(); // 0x00000001802F3750-0x00000001802F3A00
		internal void _followBounceOut_b__2(); // 0x00000001802F3A00-0x00000001802F3C20
		internal void _followBounceOut_b__3(); // 0x00000001802F3C20-0x00000001802F3E40
		internal void _followBounceOut_b__4(); // 0x00000001802F3E40-0x00000001802F4060
		internal void _followBounceOut_b__5(); // 0x00000001802F4060-0x00000001802F4280
		internal void _followBounceOut_b__6(); // 0x00000001802F4280-0x00000001802F44A0
		internal void _followBounceOut_b__7(); // 0x00000001802F44A0-0x00000001802F46C0
		internal void _followBounceOut_b__8(); // 0x00000001802F46C0-0x00000001802F4990
		internal void _followBounceOut_b__9(); // 0x00000001802F4990-0x00000001802F4D10
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass196_0 // TypeDefIndex: 323
	{
		// Fields
		public LTDescr d; // 0x10
		public float moveSpeed; // 0x18

		// Constructors
		public __c__DisplayClass196_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _followLinear_b__0(); // 0x00000001802F4D10-0x00000001802F4F80
		internal void _followLinear_b__1(); // 0x00000001802F4F80-0x00000001802F51D0
		internal void _followLinear_b__2(); // 0x00000001802F51D0-0x00000001802F5350
		internal void _followLinear_b__3(); // 0x00000001802F5350-0x00000001802F54D0
		internal void _followLinear_b__4(); // 0x00000001802F54D0-0x00000001802F5650
		internal void _followLinear_b__5(); // 0x00000001802F5650-0x00000001802F57D0
		internal void _followLinear_b__6(); // 0x00000001802F57D0-0x00000001802F5950
		internal void _followLinear_b__7(); // 0x00000001802F5950-0x00000001802F5AD0
		internal void _followLinear_b__8(); // 0x00000001802F5AD0-0x00000001802F5D20
		internal void _followLinear_b__9(); // 0x00000001802F5D20-0x00000001802F5F30
	}

	// Constructors
	public LeanTween(); // 0x000000018028A560-0x000000018028A5B0
	static LeanTween(); // 0x00000001802F00A0-0x00000001802F06C0

	// Methods
	public static void init(); // 0x00000001802DD8A0-0x00000001802DD950
	public static void init(int maxSimultaneousTweens); // 0x00000001802DDAF0-0x00000001802DDB60
	public static void init(int maxSimultaneousTweens, int maxSimultaneousSequences); // 0x00000001802DDB60-0x00000001802DE400
	public static void reset(); // 0x00000001802DE400-0x00000001802DE5C0
	public void Update(); // 0x00000001802DE5C0-0x00000001802DE610
	private static void onLevelWasLoaded54(Scene scene, LoadSceneMode mode); // 0x00000001802DE610-0x00000001802DE810
	private static void internalOnLevelWasLoaded(int lvl); // 0x00000001802DE810-0x00000001802DE9A0
	public static void update(); // 0x00000001802DE9A0-0x00000001802DF370
	public static void removeTween(int i, int uniqueId); // 0x00000001802DF370-0x00000001802DF410
	public static void removeTween(int i, bool shouldReset = true /* Metadata: 0x005EEE90 */); // 0x00000001802DF410-0x00000001802DF940
	public static Vector3[] add(Vector3[] a, Vector3 b); // 0x00000001802DF940-0x00000001802DFA90
	public static float closestRot(float from, float to); // 0x00000001802DFA90-0x00000001802DFB30
	public static void cancelAll(); // 0x00000001802DFB30-0x00000001802DFB80
	public static void cancelAll(bool callComplete); // 0x00000001802DFB80-0x00000001802DFD90
	public static void cancel(GameObject gameObject); // 0x00000001802DFD90-0x00000001802DFDF0
	public static void cancel(GameObject gameObject, bool callOnComplete, TweenAction matchType = TweenAction.NONE /* Metadata: 0x005EEE91 */); // 0x00000001802DFDF0-0x00000001802E0070
	public static void cancel(RectTransform rect); // 0x00000001802E0070-0x00000001802E00F0
	public static void cancel(GameObject gameObject, int uniqueId, bool callOnComplete = false /* Metadata: 0x005EEE92 */); // 0x00000001802E00F0-0x00000001802E0460
	public static void cancel(LTRect ltRect, int uniqueId); // 0x00000001802E0460-0x00000001802E0530
	public static void cancel(int uniqueId); // 0x00000001802E0530-0x00000001802E0590
	public static void cancel(int uniqueId, bool callOnComplete); // 0x00000001802E0590-0x00000001802E0760
	public static LTDescr descr(int uniqueId); // 0x00000001802E0760-0x00000001802E08E0
	public static LTDescr description(int uniqueId); // 0x00000001802E08E0-0x00000001802E0930
	public static LTDescr[] descriptions(GameObject gameObject = null); // 0x00000001802E0930-0x00000001802E0D00
	[Obsolete("Use \'pause( id )\' instead")]
	public static void pause(GameObject gameObject, int uniqueId); // 0x00000001802E0D00-0x00000001802E0D50
	public static void pause(int uniqueId); // 0x00000001802E0D50-0x00000001802E0E20
	public static void pause(GameObject gameObject); // 0x00000001802E0E20-0x00000001802E1090
	public static void pauseAll(); // 0x00000001802E1090-0x00000001802E1150
	public static void resumeAll(); // 0x00000001802E1150-0x00000001802E11F0
	[Obsolete("Use \'resume( id )\' instead")]
	public static void resume(GameObject gameObject, int uniqueId); // 0x00000001802E11F0-0x00000001802E1240
	public static void resume(int uniqueId); // 0x00000001802E1240-0x00000001802E12F0
	public static void resume(GameObject gameObject); // 0x00000001802E12F0-0x00000001802E1530
	public static bool isPaused(GameObject gameObject = null); // 0x00000001802E1530-0x00000001802E1970
	public static bool isPaused(RectTransform rect); // 0x00000001802E1970-0x00000001802E19E0
	public static bool isPaused(int uniqueId); // 0x00000001802E19E0-0x00000001802E1B40
	public static bool isTweening(GameObject gameObject = null); // 0x00000001802E1B40-0x00000001802E1EC0
	public static bool isTweening(RectTransform rect); // 0x00000001802E1EC0-0x00000001802E1F30
	public static bool isTweening(int uniqueId); // 0x00000001802E1F30-0x00000001802E2000
	public static bool isTweening(LTRect ltRect); // 0x00000001802E2000-0x00000001802E2150
	public static void drawBezierPath(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float arrowSize = 0f /* Metadata: 0x005EEE93 */, Transform arrowTransform = null); // 0x00000001802E2150-0x00000001802E2D20
	public static object logError(string error); // 0x00000001802E2D20-0x00000001802E2DE0
	public static LTDescr options(LTDescr seed); // 0x00000001802E2DE0-0x00000001802E2E50
	public static LTDescr options(); // 0x00000001802E2E50-0x00000001802E3160
	private static LTDescr pushNewTween(GameObject gameObject, Vector3 to, float time, LTDescr tween); // 0x00000001802E3220-0x00000001802E3450
	public static LTDescr play(RectTransform rectTransform, Sprite[] sprites); // 0x00000001802E3450-0x00000001802E3770
	public static LTSeq sequence(bool initSequence = true /* Metadata: 0x005EEE97 */); // 0x00000001802E3770-0x00000001802E3970
	public static LTDescr alpha(GameObject gameObject, float to, float time); // 0x00000001802E3970-0x00000001802E3C50
	public static LTDescr alpha(LTRect ltRect, float to, float time); // 0x00000001802E3C50-0x00000001802E3EC0
	public static LTDescr textAlpha(RectTransform rectTransform, float to, float time); // 0x00000001802E3EC0-0x00000001802E3F90
	public static LTDescr alphaText(RectTransform rectTransform, float to, float time); // 0x00000001802E3F90-0x00000001802E4060
	public static LTDescr alphaCanvas(CanvasGroup canvasGroup, float to, float time); // 0x00000001802E4060-0x00000001802E42B0
	public static LTDescr alphaVertex(GameObject gameObject, float to, float time); // 0x00000001802E42B0-0x00000001802E44F0
	public static LTDescr color(GameObject gameObject, Color to, float time); // 0x00000001802E44F0-0x00000001802E4810
	public static LTDescr textColor(RectTransform rectTransform, Color to, float time); // 0x00000001802E4810-0x00000001802E4930
	public static LTDescr colorText(RectTransform rectTransform, Color to, float time); // 0x00000001802E4930-0x00000001802E4A50
	public static LTDescr delayedCall(float delayTime, Action callback); // 0x00000001802E4A50-0x00000001802E4B40
	public static LTDescr delayedCall(float delayTime, Action<object> callback); // 0x00000001802E4B40-0x00000001802E4C30
	public static LTDescr delayedCall(GameObject gameObject, float delayTime, Action callback); // 0x00000001802E4C30-0x00000001802E4D00
	public static LTDescr delayedCall(GameObject gameObject, float delayTime, Action<object> callback); // 0x00000001802E4D00-0x00000001802E4DE0
	public static LTDescr destroyAfter(LTRect rect, float delayTime); // 0x00000001802E4DE0-0x00000001802E4ED0
	public static LTDescr move(GameObject gameObject, Vector3 to, float time); // 0x00000001802E4ED0-0x00000001802E4F80
	public static LTDescr move(GameObject gameObject, Vector2 to, float time); // 0x00000001802E4F80-0x00000001802E50F0
	public static LTDescr move(GameObject gameObject, Vector3[] to, float time); // 0x00000001802E50F0-0x00000001802E5360
	public static LTDescr move(GameObject gameObject, LTBezierPath to, float time); // 0x00000001802E5360-0x00000001802E5530
	public static LTDescr move(GameObject gameObject, LTSpline to, float time); // 0x00000001802E5530-0x00000001802E5700
	public static LTDescr moveSpline(GameObject gameObject, Vector3[] to, float time); // 0x00000001802E5700-0x00000001802E5920
	public static LTDescr moveSpline(GameObject gameObject, LTSpline to, float time); // 0x00000001802E5920-0x00000001802E5AF0
	public static LTDescr moveSplineLocal(GameObject gameObject, Vector3[] to, float time); // 0x00000001802E5AF0-0x00000001802E5D10
	public static LTDescr move(LTRect ltRect, Vector2 to, float time); // 0x00000001802E5D10-0x00000001802E5F70
	public static LTDescr moveMargin(LTRect ltRect, Vector2 to, float time); // 0x00000001802E5F70-0x00000001802E61D0
	public static LTDescr moveX(GameObject gameObject, float to, float time); // 0x00000001802E61D0-0x00000001802E6410
	public static LTDescr moveY(GameObject gameObject, float to, float time); // 0x00000001802E6410-0x00000001802E6650
	public static LTDescr moveZ(GameObject gameObject, float to, float time); // 0x00000001802E6650-0x00000001802E6890
	public static LTDescr moveLocal(GameObject gameObject, Vector3 to, float time); // 0x00000001802E6890-0x00000001802E6AB0
	public static LTDescr moveLocal(GameObject gameObject, Vector3[] to, float time); // 0x00000001802E6AB0-0x00000001802E6D20
	public static LTDescr moveLocalX(GameObject gameObject, float to, float time); // 0x00000001802E6D20-0x00000001802E6F60
	public static LTDescr moveLocalY(GameObject gameObject, float to, float time); // 0x00000001802E6F60-0x00000001802E71A0
	public static LTDescr moveLocalZ(GameObject gameObject, float to, float time); // 0x00000001802E71A0-0x00000001802E73E0
	public static LTDescr moveLocal(GameObject gameObject, LTBezierPath to, float time); // 0x00000001802E73E0-0x00000001802E75B0
	public static LTDescr moveLocal(GameObject gameObject, LTSpline to, float time); // 0x00000001802E75B0-0x00000001802E7780
	public static LTDescr move(GameObject gameObject, Transform to, float time); // 0x00000001802E7780-0x00000001802E7A20
	public static LTDescr rotate(GameObject gameObject, Vector3 to, float time); // 0x00000001802E7A20-0x00000001802E7C40
	public static LTDescr rotate(LTRect ltRect, float to, float time); // 0x00000001802E7C40-0x00000001802E7EA0
	public static LTDescr rotateLocal(GameObject gameObject, Vector3 to, float time); // 0x00000001802E7EA0-0x00000001802E80C0
	public static LTDescr rotateX(GameObject gameObject, float to, float time); // 0x00000001802E80C0-0x00000001802E8300
	public static LTDescr rotateY(GameObject gameObject, float to, float time); // 0x00000001802E8300-0x00000001802E8540
	public static LTDescr rotateZ(GameObject gameObject, float to, float time); // 0x00000001802E8540-0x00000001802E8780
	public static LTDescr rotateAround(GameObject gameObject, Vector3 axis, float add, float time); // 0x00000001802E8780-0x00000001802E89E0
	public static LTDescr rotateAroundLocal(GameObject gameObject, Vector3 axis, float add, float time); // 0x00000001802E89E0-0x00000001802E8C40
	public static LTDescr scale(GameObject gameObject, Vector3 to, float time); // 0x00000001802E8C40-0x00000001802E8E60
	public static LTDescr scale(LTRect ltRect, Vector2 to, float time); // 0x00000001802E8E60-0x00000001802E90C0
	public static LTDescr scaleX(GameObject gameObject, float to, float time); // 0x00000001802E90C0-0x00000001802E9300
	public static LTDescr scaleY(GameObject gameObject, float to, float time); // 0x00000001802E9300-0x00000001802E9540
	public static LTDescr scaleZ(GameObject gameObject, float to, float time); // 0x00000001802E9540-0x00000001802E9780
	public static LTDescr value(GameObject gameObject, float from, float to, float time); // 0x00000001802E9780-0x00000001802E9880
	public static LTDescr value(float from, float to, float time); // 0x00000001802E9880-0x00000001802E9980
	public static LTDescr value(GameObject gameObject, Vector2 from, Vector2 to, float time); // 0x00000001802E9980-0x00000001802E9B00
	public static LTDescr value(GameObject gameObject, Vector3 from, Vector3 to, float time); // 0x00000001802E9B00-0x00000001802E9BE0
	public static LTDescr value(GameObject gameObject, Color from, Color to, float time); // 0x00000001802E9BE0-0x00000001802E9DE0
	public static LTDescr value(GameObject gameObject, Action<float> callOnUpdate, float from, float to, float time); // 0x00000001802E9DE0-0x00000001802E9F40
	public static LTDescr value(GameObject gameObject, Action<float, float> callOnUpdateRatio, float from, float to, float time); // 0x00000001802E9F40-0x00000001802EA100
	public static LTDescr value(GameObject gameObject, Action<Color> callOnUpdate, Color from, Color to, float time); // 0x00000001802EA100-0x00000001802EA290
	public static LTDescr value(GameObject gameObject, Action<Color, object> callOnUpdate, Color from, Color to, float time); // 0x00000001802EA290-0x00000001802EA470
	public static LTDescr value(GameObject gameObject, Action<Vector2> callOnUpdate, Vector2 from, Vector2 to, float time); // 0x00000001802EA470-0x00000001802EA660
	public static LTDescr value(GameObject gameObject, Action<Vector3> callOnUpdate, Vector3 from, Vector3 to, float time); // 0x00000001802EA660-0x00000001802EA7D0
	public static LTDescr value(GameObject gameObject, Action<float, object> callOnUpdate, float from, float to, float time); // 0x00000001802EA7D0-0x00000001802EAA00
	public static LTDescr delayedSound(AudioClip audio, Vector3 pos, float volume); // 0x00000001802EAA00-0x00000001802EAB80
	public static LTDescr delayedSound(GameObject gameObject, AudioClip audio, Vector3 pos, float volume); // 0x00000001802EAB80-0x00000001802EACF0
	public static LTDescr move(RectTransform rectTrans, Vector3 to, float time); // 0x00000001802EACF0-0x00000001802EAF80
	public static LTDescr moveX(RectTransform rectTrans, float to, float time); // 0x00000001802EAF80-0x00000001802EB240
	public static LTDescr moveY(RectTransform rectTrans, float to, float time); // 0x00000001802EB240-0x00000001802EB500
	public static LTDescr moveZ(RectTransform rectTrans, float to, float time); // 0x00000001802EB500-0x00000001802EB7C0
	public static LTDescr rotate(RectTransform rectTrans, float to, float time); // 0x00000001802EB7C0-0x00000001802EB930
	public static LTDescr rotate(RectTransform rectTrans, Vector3 to, float time); // 0x00000001802EB930-0x00000001802EBA90
	public static LTDescr rotateAround(RectTransform rectTrans, Vector3 axis, float to, float time); // 0x00000001802EBA90-0x00000001802EBC00
	public static LTDescr rotateAroundLocal(RectTransform rectTrans, Vector3 axis, float to, float time); // 0x00000001802EBC00-0x00000001802EBEE0
	public static LTDescr scale(RectTransform rectTrans, Vector3 to, float time); // 0x00000001802EBEE0-0x00000001802EC170
	public static LTDescr size(RectTransform rectTrans, Vector2 to, float time); // 0x00000001802EC170-0x00000001802EC450
	public static LTDescr alpha(RectTransform rectTrans, float to, float time); // 0x00000001802EC450-0x00000001802EC710
	public static LTDescr color(RectTransform rectTrans, Color to, float time); // 0x00000001802EC710-0x00000001802ECA00
	public static float tweenOnCurve(LTDescr tweenDescr, float ratioPassed); // 0x00000001802ECA00-0x00000001802ECAC0
	public static Vector3 tweenOnCurveVector(LTDescr tweenDescr, float ratioPassed); // 0x00000001802ECAC0-0x00000001802ECD10
	public static float easeOutQuadOpt(float start, float diff, float ratioPassed); // 0x00000001802ECD10-0x00000001802ECD30
	public static float easeInQuadOpt(float start, float diff, float ratioPassed); // 0x00000001802ECD30-0x00000001802ECD40
	public static float easeInOutQuadOpt(float start, float diff, float ratioPassed); // 0x00000001802ECD40-0x00000001802ECDA0
	public static Vector3 easeInOutQuadOpt(Vector3 start, Vector3 diff, float ratioPassed); // 0x00000001802ECDA0-0x00000001802ECEC0
	public static float linear(float start, float end, float val); // 0x00000001802ECEC0-0x00000001802ECEF0
	public static float clerp(float start, float end, float val); // 0x00000001802ECEF0-0x00000001802ECFA0
	public static float spring(float start, float end, float val); // 0x00000001802ECFA0-0x00000001802ED080
	public static float easeInQuad(float start, float end, float val); // 0x00000001802ED080-0x00000001802ED0A0
	public static float easeOutQuad(float start, float end, float val); // 0x00000001802ED0A0-0x00000001802ED0D0
	public static float easeInOutQuad(float start, float end, float val); // 0x00000001802ED0D0-0x00000001802ED130
	public static float easeInOutQuadOpt2(float start, float diffBy2, float val, float val2); // 0x00000001802ED130-0x00000001802ED170
	public static float easeInCubic(float start, float end, float val); // 0x00000001802ED170-0x00000001802ED190
	public static float easeOutCubic(float start, float end, float val); // 0x00000001802ED190-0x00000001802ED1C0
	public static float easeInOutCubic(float start, float end, float val); // 0x00000001802ED1C0-0x00000001802ED220
	public static float easeInQuart(float start, float end, float val); // 0x00000001802ED220-0x00000001802ED240
	public static float easeOutQuart(float start, float end, float val); // 0x00000001802ED240-0x00000001802ED280
	public static float easeInOutQuart(float start, float end, float val); // 0x00000001802ED280-0x00000001802ED2F0
	public static float easeInQuint(float start, float end, float val); // 0x00000001802ED2F0-0x00000001802ED310
	public static float easeOutQuint(float start, float end, float val); // 0x00000001802ED310-0x00000001802ED350
	public static float easeInOutQuint(float start, float end, float val); // 0x00000001802ED350-0x00000001802ED3C0
	public static float easeInSine(float start, float end, float val); // 0x00000001802ED3C0-0x00000001802ED410
	public static float easeOutSine(float start, float end, float val); // 0x00000001802ED410-0x00000001802ED450
	public static float easeInOutSine(float start, float end, float val); // 0x00000001802ED450-0x00000001802ED4B0
	public static float easeInExpo(float start, float end, float val); // 0x00000001802ED4B0-0x00000001802ED500
	public static float easeOutExpo(float start, float end, float val); // 0x00000001802ED500-0x00000001802ED560
	public static float easeInOutExpo(float start, float end, float val); // 0x00000001802ED560-0x00000001802ED5F0
	public static float easeInCirc(float start, float end, float val); // 0x00000001802ED5F0-0x00000001802ED660
	public static float easeOutCirc(float start, float end, float val); // 0x00000001802ED660-0x00000001802ED6C0
	public static float easeInOutCirc(float start, float end, float val); // 0x00000001802ED6C0-0x00000001802ED780
	public static float easeInBounce(float start, float end, float val); // 0x00000001802ED780-0x00000001802ED820
	public static float easeOutBounce(float start, float end, float val); // 0x00000001802ED820-0x00000001802ED8F0
	public static float easeInOutBounce(float start, float end, float val); // 0x00000001802ED8F0-0x00000001802ED9E0
	public static float easeInBack(float start, float end, float val, float overshoot = 1f /* Metadata: 0x005EEE98 */); // 0x00000001802ED9E0-0x00000001802EDA20
	public static float easeOutBack(float start, float end, float val, float overshoot = 1f /* Metadata: 0x005EEE9C */); // 0x00000001802EDA20-0x00000001802EDA60
	public static float easeInOutBack(float start, float end, float val, float overshoot = 1f /* Metadata: 0x005EEEA0 */); // 0x00000001802EDA60-0x00000001802EDB00
	public static float easeInElastic(float start, float end, float val, float overshoot = 1f /* Metadata: 0x005EEEA4 */, float period = 0.3f /* Metadata: 0x005EEEA8 */); // 0x00000001802EDB00-0x00000001802EDC20
	public static float easeOutElastic(float start, float end, float val, float overshoot = 1f /* Metadata: 0x005EEEAC */, float period = 0.3f /* Metadata: 0x005EEEB0 */); // 0x00000001802EDC20-0x00000001802EDD40
	public static float easeInOutElastic(float start, float end, float val, float overshoot = 1f /* Metadata: 0x005EEEB4 */, float period = 0.3f /* Metadata: 0x005EEEB8 */); // 0x00000001802EDD40-0x00000001802EDED0
	public static LTDescr followDamp(Transform trans, Transform target, LeanProp prop, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005EEEBC */); // 0x00000001802EDED0-0x00000001802EE3F0
	public static LTDescr followSpring(Transform trans, Transform target, LeanProp prop, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005EEEC0 */, float friction = 2f /* Metadata: 0x005EEEC4 */, float accelRate = 0.5f /* Metadata: 0x005EEEC8 */); // 0x00000001802EE3F0-0x00000001802EE930
	public static LTDescr followBounceOut(Transform trans, Transform target, LeanProp prop, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005EEECC */, float friction = 2f /* Metadata: 0x005EEED0 */, float accelRate = 0.5f /* Metadata: 0x005EEED4 */, float hitDamping = 0.9f /* Metadata: 0x005EEED8 */); // 0x00000001802EE930-0x00000001802EEDF0
	public static LTDescr followLinear(Transform trans, Transform target, LeanProp prop, float moveSpeed); // 0x00000001802EEDF0-0x00000001802EF270
	public static void addListener(int eventId, Action<LTEvent> callback); // 0x00000001802EF270-0x00000001802EF2E0
	public static void addListener(GameObject caller, int eventId, Action<LTEvent> callback); // 0x00000001802EF2E0-0x00000001802EF9C0
	public static bool removeListener(int eventId, Action<LTEvent> callback); // 0x00000001802EF9C0-0x00000001802EFA30
	public static bool removeListener(int eventId); // 0x00000001802EFA30-0x00000001802EFAE0
	public static bool removeListener(GameObject caller, int eventId, Action<LTEvent> callback); // 0x00000001802EFAE0-0x00000001802EFDC0
	public static void dispatchEvent(int eventId); // 0x00000001802EFDC0-0x00000001802EFE20
	public static void dispatchEvent(int eventId, object data); // 0x00000001802EFE20-0x00000001802F00A0
}

