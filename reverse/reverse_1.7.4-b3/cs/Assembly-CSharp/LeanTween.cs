/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

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
	public static int maxSearch { get; } // 0x00000001802DD920-0x00000001802DD980 
	public static int maxSimulataneousTweens { get; } // 0x00000001802DD980-0x00000001802DD9E0 
	public static int tweensRunning { get; } // 0x00000001802DD9E0-0x00000001802DDAC0 
	public static GameObject tweenEmpty { get; } // 0x00000001802E3130-0x00000001802E31F0 

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
		internal void _followDamp_b__0(); // 0x00000001802F0690-0x00000001802F09A0
		internal void _followDamp_b__1(); // 0x00000001802F09A0-0x00000001802F0CB0
		internal void _followDamp_b__2(); // 0x00000001802F0CB0-0x00000001802F0EA0
		internal void _followDamp_b__3(); // 0x00000001802F0EA0-0x00000001802F10A0
		internal void _followDamp_b__4(); // 0x00000001802F10A0-0x00000001802F12A0
		internal void _followDamp_b__5(); // 0x00000001802F12A0-0x00000001802F1490
		internal void _followDamp_b__6(); // 0x00000001802F1490-0x00000001802F1690
		internal void _followDamp_b__7(); // 0x00000001802F1690-0x00000001802F1890
		internal void _followDamp_b__8(); // 0x00000001802F1890-0x00000001802F1B80
		internal void _followDamp_b__9(); // 0x00000001802F1B80-0x00000001802F1E60
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
		internal void _followSpring_b__0(); // 0x00000001802F1E60-0x00000001802F2100
		internal void _followSpring_b__1(); // 0x00000001802F2100-0x00000001802F2370
		internal void _followSpring_b__2(); // 0x00000001802F2370-0x00000001802F2580
		internal void _followSpring_b__3(); // 0x00000001802F2580-0x00000001802F2790
		internal void _followSpring_b__4(); // 0x00000001802F2790-0x00000001802F29A0
		internal void _followSpring_b__5(); // 0x00000001802F29A0-0x00000001802F2BB0
		internal void _followSpring_b__6(); // 0x00000001802F2BB0-0x00000001802F2DC0
		internal void _followSpring_b__7(); // 0x00000001802F2DC0-0x00000001802F2FD0
		internal void _followSpring_b__8(); // 0x00000001802F2FD0-0x00000001802F3280
		internal void _followSpring_b__9(); // 0x00000001802F3280-0x00000001802F3470
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
		internal void _followBounceOut_b__0(); // 0x00000001802F3470-0x00000001802F3720
		internal void _followBounceOut_b__1(); // 0x00000001802F3720-0x00000001802F39D0
		internal void _followBounceOut_b__2(); // 0x00000001802F39D0-0x00000001802F3BF0
		internal void _followBounceOut_b__3(); // 0x00000001802F3BF0-0x00000001802F3E10
		internal void _followBounceOut_b__4(); // 0x00000001802F3E10-0x00000001802F4030
		internal void _followBounceOut_b__5(); // 0x00000001802F4030-0x00000001802F4250
		internal void _followBounceOut_b__6(); // 0x00000001802F4250-0x00000001802F4470
		internal void _followBounceOut_b__7(); // 0x00000001802F4470-0x00000001802F4690
		internal void _followBounceOut_b__8(); // 0x00000001802F4690-0x00000001802F4960
		internal void _followBounceOut_b__9(); // 0x00000001802F4960-0x00000001802F4CE0
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
		internal void _followLinear_b__0(); // 0x00000001802F4CE0-0x00000001802F4F50
		internal void _followLinear_b__1(); // 0x00000001802F4F50-0x00000001802F51A0
		internal void _followLinear_b__2(); // 0x00000001802F51A0-0x00000001802F5320
		internal void _followLinear_b__3(); // 0x00000001802F5320-0x00000001802F54A0
		internal void _followLinear_b__4(); // 0x00000001802F54A0-0x00000001802F5620
		internal void _followLinear_b__5(); // 0x00000001802F5620-0x00000001802F57A0
		internal void _followLinear_b__6(); // 0x00000001802F57A0-0x00000001802F5920
		internal void _followLinear_b__7(); // 0x00000001802F5920-0x00000001802F5AA0
		internal void _followLinear_b__8(); // 0x00000001802F5AA0-0x00000001802F5CF0
		internal void _followLinear_b__9(); // 0x00000001802F5CF0-0x00000001802F5F00
	}

	// Constructors
	public LeanTween(); // 0x000000018028A560-0x000000018028A5B0
	static LeanTween(); // 0x00000001802F0070-0x00000001802F0690

	// Methods
	public static void init(); // 0x00000001802DD870-0x00000001802DD920
	public static void init(int maxSimultaneousTweens); // 0x00000001802DDAC0-0x00000001802DDB30
	public static void init(int maxSimultaneousTweens, int maxSimultaneousSequences); // 0x00000001802DDB30-0x00000001802DE3D0
	public static void reset(); // 0x00000001802DE3D0-0x00000001802DE590
	public void Update(); // 0x00000001802DE590-0x00000001802DE5E0
	private static void onLevelWasLoaded54(Scene scene, LoadSceneMode mode); // 0x00000001802DE5E0-0x00000001802DE7E0
	private static void internalOnLevelWasLoaded(int lvl); // 0x00000001802DE7E0-0x00000001802DE970
	public static void update(); // 0x00000001802DE970-0x00000001802DF340
	public static void removeTween(int i, int uniqueId); // 0x00000001802DF340-0x00000001802DF3E0
	public static void removeTween(int i, bool shouldReset = true /* Metadata: 0x005EDAC0 */); // 0x00000001802DF3E0-0x00000001802DF910
	public static Vector3[] add(Vector3[] a, Vector3 b); // 0x00000001802DF910-0x00000001802DFA60
	public static float closestRot(float from, float to); // 0x00000001802DFA60-0x00000001802DFB00
	public static void cancelAll(); // 0x00000001802DFB00-0x00000001802DFB50
	public static void cancelAll(bool callComplete); // 0x00000001802DFB50-0x00000001802DFD60
	public static void cancel(GameObject gameObject); // 0x00000001802DFD60-0x00000001802DFDC0
	public static void cancel(GameObject gameObject, bool callOnComplete, TweenAction matchType = TweenAction.NONE /* Metadata: 0x005EDAC1 */); // 0x00000001802DFDC0-0x00000001802E0040
	public static void cancel(RectTransform rect); // 0x00000001802E0040-0x00000001802E00C0
	public static void cancel(GameObject gameObject, int uniqueId, bool callOnComplete = false /* Metadata: 0x005EDAC2 */); // 0x00000001802E00C0-0x00000001802E0430
	public static void cancel(LTRect ltRect, int uniqueId); // 0x00000001802E0430-0x00000001802E0500
	public static void cancel(int uniqueId); // 0x00000001802E0500-0x00000001802E0560
	public static void cancel(int uniqueId, bool callOnComplete); // 0x00000001802E0560-0x00000001802E0730
	public static LTDescr descr(int uniqueId); // 0x00000001802E0730-0x00000001802E08B0
	public static LTDescr description(int uniqueId); // 0x00000001802E08B0-0x00000001802E0900
	public static LTDescr[] descriptions(GameObject gameObject = null); // 0x00000001802E0900-0x00000001802E0CD0
	[Obsolete("Use \'pause( id )\' instead")]
	public static void pause(GameObject gameObject, int uniqueId); // 0x00000001802E0CD0-0x00000001802E0D20
	public static void pause(int uniqueId); // 0x00000001802E0D20-0x00000001802E0DF0
	public static void pause(GameObject gameObject); // 0x00000001802E0DF0-0x00000001802E1060
	public static void pauseAll(); // 0x00000001802E1060-0x00000001802E1120
	public static void resumeAll(); // 0x00000001802E1120-0x00000001802E11C0
	[Obsolete("Use \'resume( id )\' instead")]
	public static void resume(GameObject gameObject, int uniqueId); // 0x00000001802E11C0-0x00000001802E1210
	public static void resume(int uniqueId); // 0x00000001802E1210-0x00000001802E12C0
	public static void resume(GameObject gameObject); // 0x00000001802E12C0-0x00000001802E1500
	public static bool isPaused(GameObject gameObject = null); // 0x00000001802E1500-0x00000001802E1940
	public static bool isPaused(RectTransform rect); // 0x00000001802E1940-0x00000001802E19B0
	public static bool isPaused(int uniqueId); // 0x00000001802E19B0-0x00000001802E1B10
	public static bool isTweening(GameObject gameObject = null); // 0x00000001802E1B10-0x00000001802E1E90
	public static bool isTweening(RectTransform rect); // 0x00000001802E1E90-0x00000001802E1F00
	public static bool isTweening(int uniqueId); // 0x00000001802E1F00-0x00000001802E1FD0
	public static bool isTweening(LTRect ltRect); // 0x00000001802E1FD0-0x00000001802E2120
	public static void drawBezierPath(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float arrowSize = 0f /* Metadata: 0x005EDAC3 */, Transform arrowTransform = null); // 0x00000001802E2120-0x00000001802E2CF0
	public static object logError(string error); // 0x00000001802E2CF0-0x00000001802E2DB0
	public static LTDescr options(LTDescr seed); // 0x00000001802E2DB0-0x00000001802E2E20
	public static LTDescr options(); // 0x00000001802E2E20-0x00000001802E3130
	private static LTDescr pushNewTween(GameObject gameObject, Vector3 to, float time, LTDescr tween); // 0x00000001802E31F0-0x00000001802E3420
	public static LTDescr play(RectTransform rectTransform, Sprite[] sprites); // 0x00000001802E3420-0x00000001802E3740
	public static LTSeq sequence(bool initSequence = true /* Metadata: 0x005EDAC7 */); // 0x00000001802E3740-0x00000001802E3940
	public static LTDescr alpha(GameObject gameObject, float to, float time); // 0x00000001802E3940-0x00000001802E3C20
	public static LTDescr alpha(LTRect ltRect, float to, float time); // 0x00000001802E3C20-0x00000001802E3E90
	public static LTDescr textAlpha(RectTransform rectTransform, float to, float time); // 0x00000001802E3E90-0x00000001802E3F60
	public static LTDescr alphaText(RectTransform rectTransform, float to, float time); // 0x00000001802E3F60-0x00000001802E4030
	public static LTDescr alphaCanvas(CanvasGroup canvasGroup, float to, float time); // 0x00000001802E4030-0x00000001802E4280
	public static LTDescr alphaVertex(GameObject gameObject, float to, float time); // 0x00000001802E4280-0x00000001802E44C0
	public static LTDescr color(GameObject gameObject, Color to, float time); // 0x00000001802E44C0-0x00000001802E47E0
	public static LTDescr textColor(RectTransform rectTransform, Color to, float time); // 0x00000001802E47E0-0x00000001802E4900
	public static LTDescr colorText(RectTransform rectTransform, Color to, float time); // 0x00000001802E4900-0x00000001802E4A20
	public static LTDescr delayedCall(float delayTime, Action callback); // 0x00000001802E4A20-0x00000001802E4B10
	public static LTDescr delayedCall(float delayTime, Action<object> callback); // 0x00000001802E4B10-0x00000001802E4C00
	public static LTDescr delayedCall(GameObject gameObject, float delayTime, Action callback); // 0x00000001802E4C00-0x00000001802E4CD0
	public static LTDescr delayedCall(GameObject gameObject, float delayTime, Action<object> callback); // 0x00000001802E4CD0-0x00000001802E4DB0
	public static LTDescr destroyAfter(LTRect rect, float delayTime); // 0x00000001802E4DB0-0x00000001802E4EA0
	public static LTDescr move(GameObject gameObject, Vector3 to, float time); // 0x00000001802E4EA0-0x00000001802E4F50
	public static LTDescr move(GameObject gameObject, Vector2 to, float time); // 0x00000001802E4F50-0x00000001802E50C0
	public static LTDescr move(GameObject gameObject, Vector3[] to, float time); // 0x00000001802E50C0-0x00000001802E5330
	public static LTDescr move(GameObject gameObject, LTBezierPath to, float time); // 0x00000001802E5330-0x00000001802E5500
	public static LTDescr move(GameObject gameObject, LTSpline to, float time); // 0x00000001802E5500-0x00000001802E56D0
	public static LTDescr moveSpline(GameObject gameObject, Vector3[] to, float time); // 0x00000001802E56D0-0x00000001802E58F0
	public static LTDescr moveSpline(GameObject gameObject, LTSpline to, float time); // 0x00000001802E58F0-0x00000001802E5AC0
	public static LTDescr moveSplineLocal(GameObject gameObject, Vector3[] to, float time); // 0x00000001802E5AC0-0x00000001802E5CE0
	public static LTDescr move(LTRect ltRect, Vector2 to, float time); // 0x00000001802E5CE0-0x00000001802E5F40
	public static LTDescr moveMargin(LTRect ltRect, Vector2 to, float time); // 0x00000001802E5F40-0x00000001802E61A0
	public static LTDescr moveX(GameObject gameObject, float to, float time); // 0x00000001802E61A0-0x00000001802E63E0
	public static LTDescr moveY(GameObject gameObject, float to, float time); // 0x00000001802E63E0-0x00000001802E6620
	public static LTDescr moveZ(GameObject gameObject, float to, float time); // 0x00000001802E6620-0x00000001802E6860
	public static LTDescr moveLocal(GameObject gameObject, Vector3 to, float time); // 0x00000001802E6860-0x00000001802E6A80
	public static LTDescr moveLocal(GameObject gameObject, Vector3[] to, float time); // 0x00000001802E6A80-0x00000001802E6CF0
	public static LTDescr moveLocalX(GameObject gameObject, float to, float time); // 0x00000001802E6CF0-0x00000001802E6F30
	public static LTDescr moveLocalY(GameObject gameObject, float to, float time); // 0x00000001802E6F30-0x00000001802E7170
	public static LTDescr moveLocalZ(GameObject gameObject, float to, float time); // 0x00000001802E7170-0x00000001802E73B0
	public static LTDescr moveLocal(GameObject gameObject, LTBezierPath to, float time); // 0x00000001802E73B0-0x00000001802E7580
	public static LTDescr moveLocal(GameObject gameObject, LTSpline to, float time); // 0x00000001802E7580-0x00000001802E7750
	public static LTDescr move(GameObject gameObject, Transform to, float time); // 0x00000001802E7750-0x00000001802E79F0
	public static LTDescr rotate(GameObject gameObject, Vector3 to, float time); // 0x00000001802E79F0-0x00000001802E7C10
	public static LTDescr rotate(LTRect ltRect, float to, float time); // 0x00000001802E7C10-0x00000001802E7E70
	public static LTDescr rotateLocal(GameObject gameObject, Vector3 to, float time); // 0x00000001802E7E70-0x00000001802E8090
	public static LTDescr rotateX(GameObject gameObject, float to, float time); // 0x00000001802E8090-0x00000001802E82D0
	public static LTDescr rotateY(GameObject gameObject, float to, float time); // 0x00000001802E82D0-0x00000001802E8510
	public static LTDescr rotateZ(GameObject gameObject, float to, float time); // 0x00000001802E8510-0x00000001802E8750
	public static LTDescr rotateAround(GameObject gameObject, Vector3 axis, float add, float time); // 0x00000001802E8750-0x00000001802E89B0
	public static LTDescr rotateAroundLocal(GameObject gameObject, Vector3 axis, float add, float time); // 0x00000001802E89B0-0x00000001802E8C10
	public static LTDescr scale(GameObject gameObject, Vector3 to, float time); // 0x00000001802E8C10-0x00000001802E8E30
	public static LTDescr scale(LTRect ltRect, Vector2 to, float time); // 0x00000001802E8E30-0x00000001802E9090
	public static LTDescr scaleX(GameObject gameObject, float to, float time); // 0x00000001802E9090-0x00000001802E92D0
	public static LTDescr scaleY(GameObject gameObject, float to, float time); // 0x00000001802E92D0-0x00000001802E9510
	public static LTDescr scaleZ(GameObject gameObject, float to, float time); // 0x00000001802E9510-0x00000001802E9750
	public static LTDescr value(GameObject gameObject, float from, float to, float time); // 0x00000001802E9750-0x00000001802E9850
	public static LTDescr value(float from, float to, float time); // 0x00000001802E9850-0x00000001802E9950
	public static LTDescr value(GameObject gameObject, Vector2 from, Vector2 to, float time); // 0x00000001802E9950-0x00000001802E9AD0
	public static LTDescr value(GameObject gameObject, Vector3 from, Vector3 to, float time); // 0x00000001802E9AD0-0x00000001802E9BB0
	public static LTDescr value(GameObject gameObject, Color from, Color to, float time); // 0x00000001802E9BB0-0x00000001802E9DB0
	public static LTDescr value(GameObject gameObject, Action<float> callOnUpdate, float from, float to, float time); // 0x00000001802E9DB0-0x00000001802E9F10
	public static LTDescr value(GameObject gameObject, Action<float, float> callOnUpdateRatio, float from, float to, float time); // 0x00000001802E9F10-0x00000001802EA0D0
	public static LTDescr value(GameObject gameObject, Action<Color> callOnUpdate, Color from, Color to, float time); // 0x00000001802EA0D0-0x00000001802EA260
	public static LTDescr value(GameObject gameObject, Action<Color, object> callOnUpdate, Color from, Color to, float time); // 0x00000001802EA260-0x00000001802EA440
	public static LTDescr value(GameObject gameObject, Action<Vector2> callOnUpdate, Vector2 from, Vector2 to, float time); // 0x00000001802EA440-0x00000001802EA630
	public static LTDescr value(GameObject gameObject, Action<Vector3> callOnUpdate, Vector3 from, Vector3 to, float time); // 0x00000001802EA630-0x00000001802EA7A0
	public static LTDescr value(GameObject gameObject, Action<float, object> callOnUpdate, float from, float to, float time); // 0x00000001802EA7A0-0x00000001802EA9D0
	public static LTDescr delayedSound(AudioClip audio, Vector3 pos, float volume); // 0x00000001802EA9D0-0x00000001802EAB50
	public static LTDescr delayedSound(GameObject gameObject, AudioClip audio, Vector3 pos, float volume); // 0x00000001802EAB50-0x00000001802EACC0
	public static LTDescr move(RectTransform rectTrans, Vector3 to, float time); // 0x00000001802EACC0-0x00000001802EAF50
	public static LTDescr moveX(RectTransform rectTrans, float to, float time); // 0x00000001802EAF50-0x00000001802EB210
	public static LTDescr moveY(RectTransform rectTrans, float to, float time); // 0x00000001802EB210-0x00000001802EB4D0
	public static LTDescr moveZ(RectTransform rectTrans, float to, float time); // 0x00000001802EB4D0-0x00000001802EB790
	public static LTDescr rotate(RectTransform rectTrans, float to, float time); // 0x00000001802EB790-0x00000001802EB900
	public static LTDescr rotate(RectTransform rectTrans, Vector3 to, float time); // 0x00000001802EB900-0x00000001802EBA60
	public static LTDescr rotateAround(RectTransform rectTrans, Vector3 axis, float to, float time); // 0x00000001802EBA60-0x00000001802EBBD0
	public static LTDescr rotateAroundLocal(RectTransform rectTrans, Vector3 axis, float to, float time); // 0x00000001802EBBD0-0x00000001802EBEB0
	public static LTDescr scale(RectTransform rectTrans, Vector3 to, float time); // 0x00000001802EBEB0-0x00000001802EC140
	public static LTDescr size(RectTransform rectTrans, Vector2 to, float time); // 0x00000001802EC140-0x00000001802EC420
	public static LTDescr alpha(RectTransform rectTrans, float to, float time); // 0x00000001802EC420-0x00000001802EC6E0
	public static LTDescr color(RectTransform rectTrans, Color to, float time); // 0x00000001802EC6E0-0x00000001802EC9D0
	public static float tweenOnCurve(LTDescr tweenDescr, float ratioPassed); // 0x00000001802EC9D0-0x00000001802ECA90
	public static Vector3 tweenOnCurveVector(LTDescr tweenDescr, float ratioPassed); // 0x00000001802ECA90-0x00000001802ECCE0
	public static float easeOutQuadOpt(float start, float diff, float ratioPassed); // 0x00000001802ECCE0-0x00000001802ECD00
	public static float easeInQuadOpt(float start, float diff, float ratioPassed); // 0x00000001802ECD00-0x00000001802ECD10
	public static float easeInOutQuadOpt(float start, float diff, float ratioPassed); // 0x00000001802ECD10-0x00000001802ECD70
	public static Vector3 easeInOutQuadOpt(Vector3 start, Vector3 diff, float ratioPassed); // 0x00000001802ECD70-0x00000001802ECE90
	public static float linear(float start, float end, float val); // 0x00000001802ECE90-0x00000001802ECEC0
	public static float clerp(float start, float end, float val); // 0x00000001802ECEC0-0x00000001802ECF70
	public static float spring(float start, float end, float val); // 0x00000001802ECF70-0x00000001802ED050
	public static float easeInQuad(float start, float end, float val); // 0x00000001802ED050-0x00000001802ED070
	public static float easeOutQuad(float start, float end, float val); // 0x00000001802ED070-0x00000001802ED0A0
	public static float easeInOutQuad(float start, float end, float val); // 0x00000001802ED0A0-0x00000001802ED100
	public static float easeInOutQuadOpt2(float start, float diffBy2, float val, float val2); // 0x00000001802ED100-0x00000001802ED140
	public static float easeInCubic(float start, float end, float val); // 0x00000001802ED140-0x00000001802ED160
	public static float easeOutCubic(float start, float end, float val); // 0x00000001802ED160-0x00000001802ED190
	public static float easeInOutCubic(float start, float end, float val); // 0x00000001802ED190-0x00000001802ED1F0
	public static float easeInQuart(float start, float end, float val); // 0x00000001802ED1F0-0x00000001802ED210
	public static float easeOutQuart(float start, float end, float val); // 0x00000001802ED210-0x00000001802ED250
	public static float easeInOutQuart(float start, float end, float val); // 0x00000001802ED250-0x00000001802ED2C0
	public static float easeInQuint(float start, float end, float val); // 0x00000001802ED2C0-0x00000001802ED2E0
	public static float easeOutQuint(float start, float end, float val); // 0x00000001802ED2E0-0x00000001802ED320
	public static float easeInOutQuint(float start, float end, float val); // 0x00000001802ED320-0x00000001802ED390
	public static float easeInSine(float start, float end, float val); // 0x00000001802ED390-0x00000001802ED3E0
	public static float easeOutSine(float start, float end, float val); // 0x00000001802ED3E0-0x00000001802ED420
	public static float easeInOutSine(float start, float end, float val); // 0x00000001802ED420-0x00000001802ED480
	public static float easeInExpo(float start, float end, float val); // 0x00000001802ED480-0x00000001802ED4D0
	public static float easeOutExpo(float start, float end, float val); // 0x00000001802ED4D0-0x00000001802ED530
	public static float easeInOutExpo(float start, float end, float val); // 0x00000001802ED530-0x00000001802ED5C0
	public static float easeInCirc(float start, float end, float val); // 0x00000001802ED5C0-0x00000001802ED630
	public static float easeOutCirc(float start, float end, float val); // 0x00000001802ED630-0x00000001802ED690
	public static float easeInOutCirc(float start, float end, float val); // 0x00000001802ED690-0x00000001802ED750
	public static float easeInBounce(float start, float end, float val); // 0x00000001802ED750-0x00000001802ED7F0
	public static float easeOutBounce(float start, float end, float val); // 0x00000001802ED7F0-0x00000001802ED8C0
	public static float easeInOutBounce(float start, float end, float val); // 0x00000001802ED8C0-0x00000001802ED9B0
	public static float easeInBack(float start, float end, float val, float overshoot = 1f /* Metadata: 0x005EDAC8 */); // 0x00000001802ED9B0-0x00000001802ED9F0
	public static float easeOutBack(float start, float end, float val, float overshoot = 1f /* Metadata: 0x005EDACC */); // 0x00000001802ED9F0-0x00000001802EDA30
	public static float easeInOutBack(float start, float end, float val, float overshoot = 1f /* Metadata: 0x005EDAD0 */); // 0x00000001802EDA30-0x00000001802EDAD0
	public static float easeInElastic(float start, float end, float val, float overshoot = 1f /* Metadata: 0x005EDAD4 */, float period = 0.3f /* Metadata: 0x005EDAD8 */); // 0x00000001802EDAD0-0x00000001802EDBF0
	public static float easeOutElastic(float start, float end, float val, float overshoot = 1f /* Metadata: 0x005EDADC */, float period = 0.3f /* Metadata: 0x005EDAE0 */); // 0x00000001802EDBF0-0x00000001802EDD10
	public static float easeInOutElastic(float start, float end, float val, float overshoot = 1f /* Metadata: 0x005EDAE4 */, float period = 0.3f /* Metadata: 0x005EDAE8 */); // 0x00000001802EDD10-0x00000001802EDEA0
	public static LTDescr followDamp(Transform trans, Transform target, LeanProp prop, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005EDAEC */); // 0x00000001802EDEA0-0x00000001802EE3C0
	public static LTDescr followSpring(Transform trans, Transform target, LeanProp prop, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005EDAF0 */, float friction = 2f /* Metadata: 0x005EDAF4 */, float accelRate = 0.5f /* Metadata: 0x005EDAF8 */); // 0x00000001802EE3C0-0x00000001802EE900
	public static LTDescr followBounceOut(Transform trans, Transform target, LeanProp prop, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005EDAFC */, float friction = 2f /* Metadata: 0x005EDB00 */, float accelRate = 0.5f /* Metadata: 0x005EDB04 */, float hitDamping = 0.9f /* Metadata: 0x005EDB08 */); // 0x00000001802EE900-0x00000001802EEDC0
	public static LTDescr followLinear(Transform trans, Transform target, LeanProp prop, float moveSpeed); // 0x00000001802EEDC0-0x00000001802EF240
	public static void addListener(int eventId, Action<LTEvent> callback); // 0x00000001802EF240-0x00000001802EF2B0
	public static void addListener(GameObject caller, int eventId, Action<LTEvent> callback); // 0x00000001802EF2B0-0x00000001802EF990
	public static bool removeListener(int eventId, Action<LTEvent> callback); // 0x00000001802EF990-0x00000001802EFA00
	public static bool removeListener(int eventId); // 0x00000001802EFA00-0x00000001802EFAB0
	public static bool removeListener(GameObject caller, int eventId, Action<LTEvent> callback); // 0x00000001802EFAB0-0x00000001802EFD90
	public static void dispatchEvent(int eventId); // 0x00000001802EFD90-0x00000001802EFDF0
	public static void dispatchEvent(int eventId, object data); // 0x00000001802EFDF0-0x00000001802F0070
}

