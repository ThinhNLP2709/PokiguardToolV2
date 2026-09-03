/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class LeanTween : MonoBehaviour // TypeDefIndex: 296
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
	public static int maxSearch { get; } // 0x00000001806D8990-0x00000001806D89E0 
	public static int maxSimulataneousTweens { get; } // 0x00000001806D89E0-0x00000001806D8A30 
	public static int tweensRunning { get; } // 0x00000001806D8AF0-0x00000001806D8BD0 
	public static GameObject tweenEmpty { get; } // 0x00000001806D8A30-0x00000001806D8AF0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass193_0 // TypeDefIndex: 297
	{
		// Fields
		public LTDescr d; // 0x10
		public float smoothTime; // 0x18
		public float maxSpeed; // 0x1C

		// Constructors
		public __c__DisplayClass193_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _followDamp_b__0(); // 0x00000001806E0320-0x00000001806E0550
		internal void _followDamp_b__1(); // 0x00000001806E0550-0x00000001806E0780
		internal void _followDamp_b__2(); // 0x00000001806E0780-0x00000001806E08A0
		internal void _followDamp_b__3(); // 0x00000001806E08A0-0x00000001806E09C0
		internal void _followDamp_b__4(); // 0x00000001806E09C0-0x00000001806E0AE0
		internal void _followDamp_b__5(); // 0x00000001806E0AE0-0x00000001806E0C00
		internal void _followDamp_b__6(); // 0x00000001806E0C00-0x00000001806E0D20
		internal void _followDamp_b__7(); // 0x00000001806E0D20-0x00000001806E0E40
		internal void _followDamp_b__8(); // 0x00000001806E0E40-0x00000001806E1020
		internal void _followDamp_b__9(); // 0x00000001806E1020-0x00000001806E12B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass194_0 // TypeDefIndex: 298
	{
		// Fields
		public LTDescr d; // 0x10
		public float smoothTime; // 0x18
		public float maxSpeed; // 0x1C
		public float friction; // 0x20
		public float accelRate; // 0x24

		// Constructors
		public __c__DisplayClass194_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _followSpring_b__0(); // 0x00000001806E12B0-0x00000001806E1480
		internal void _followSpring_b__1(); // 0x00000001806E1480-0x00000001806E1610
		internal void _followSpring_b__2(); // 0x00000001806E1610-0x00000001806E1750
		internal void _followSpring_b__3(); // 0x00000001806E1750-0x00000001806E1890
		internal void _followSpring_b__4(); // 0x00000001806E1890-0x00000001806E19D0
		internal void _followSpring_b__5(); // 0x00000001806E19D0-0x00000001806E1B10
		internal void _followSpring_b__6(); // 0x00000001806E1B10-0x00000001806E1C50
		internal void _followSpring_b__7(); // 0x00000001806E1C50-0x00000001806E1D90
		internal void _followSpring_b__8(); // 0x00000001806E1D90-0x00000001806E1F10
		internal void _followSpring_b__9(); // 0x00000001806E1F10-0x00000001806E2210
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass195_0 // TypeDefIndex: 299
	{
		// Fields
		public LTDescr d; // 0x10
		public float smoothTime; // 0x18
		public float maxSpeed; // 0x1C
		public float friction; // 0x20
		public float accelRate; // 0x24
		public float hitDamping; // 0x28

		// Constructors
		public __c__DisplayClass195_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _followBounceOut_b__0(); // 0x00000001806E2210-0x00000001806E23F0
		internal void _followBounceOut_b__1(); // 0x00000001806E23F0-0x00000001806E25D0
		internal void _followBounceOut_b__2(); // 0x00000001806E25D0-0x00000001806E2710
		internal void _followBounceOut_b__3(); // 0x00000001806E2710-0x00000001806E2850
		internal void _followBounceOut_b__4(); // 0x00000001806E2850-0x00000001806E2990
		internal void _followBounceOut_b__5(); // 0x00000001806E2990-0x00000001806E2AD0
		internal void _followBounceOut_b__6(); // 0x00000001806E2AD0-0x00000001806E2C10
		internal void _followBounceOut_b__7(); // 0x00000001806E2C10-0x00000001806E2D50
		internal void _followBounceOut_b__8(); // 0x00000001806E2D50-0x00000001806E2EE0
		internal void _followBounceOut_b__9(); // 0x00000001806E2EE0-0x00000001806E3210
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass196_0 // TypeDefIndex: 300
	{
		// Fields
		public LTDescr d; // 0x10
		public float moveSpeed; // 0x18

		// Constructors
		public __c__DisplayClass196_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _followLinear_b__0(); // 0x00000001806E3210-0x00000001806E33D0
		internal void _followLinear_b__1(); // 0x00000001806E33D0-0x00000001806E3530
		internal void _followLinear_b__2(); // 0x00000001806E3530-0x00000001806E35E0
		internal void _followLinear_b__3(); // 0x00000001806E35E0-0x00000001806E3690
		internal void _followLinear_b__4(); // 0x00000001806E3690-0x00000001806E3740
		internal void _followLinear_b__5(); // 0x00000001806E3740-0x00000001806E37F0
		internal void _followLinear_b__6(); // 0x00000001806E37F0-0x00000001806E38A0
		internal void _followLinear_b__7(); // 0x00000001806E38A0-0x00000001806E3950
		internal void _followLinear_b__8(); // 0x00000001806E3950-0x00000001806E3AB0
		internal void _followLinear_b__9(); // 0x00000001806E3AB0-0x00000001806E3CB0
	}

	// Constructors
	public LeanTween(); // 0x00000001802E7A70-0x00000001802E7BC0
	static LeanTween(); // 0x00000001806D2F90-0x00000001806D3660

	// Methods
	public static void init(); // 0x00000001806D9150-0x00000001806D91F0
	public static void init(int maxSimultaneousTweens); // 0x00000001806D90F0-0x00000001806D9150
	public static void init(int maxSimultaneousTweens, int maxSimultaneousSequences); // 0x00000001806D8BD0-0x00000001806D90F0
	public static void reset(); // 0x00000001806DD170-0x00000001806DD2A0
	public void Update(); // 0x00000001806D2F50-0x00000001806D2F90
	private static void onLevelWasLoaded54(Scene scene, LoadSceneMode mode); // 0x00000001806DBF20-0x00000001806DBFB0
	private static void internalOnLevelWasLoaded(int lvl); // 0x00000001806D91F0-0x00000001806D9230
	public static void update(); // 0x00000001806DEDC0-0x00000001806DF400
	public static void removeTween(int i, int uniqueId); // 0x00000001806DD0D0-0x00000001806DD170
	public static void removeTween(int i, bool shouldReset = true /* Metadata: 0x0064C188 */); // 0x00000001806DCE20-0x00000001806DD0D0
	public static Vector3[] add(Vector3[] a, Vector3 b); // 0x00000001806D3AE0-0x00000001806D3C20
	public static float closestRot(float from, float to); // 0x00000001806D4E50-0x00000001806D4EF0
	public static void cancelAll(); // 0x00000001806D4300-0x00000001806D4430
	public static void cancelAll(bool callComplete); // 0x00000001806D4170-0x00000001806D4300
	public static void cancel(GameObject gameObject); // 0x00000001806D4AD0-0x00000001806D4C30
	public static void cancel(GameObject gameObject, bool callOnComplete, TweenAction matchType = TweenAction.NONE /* Metadata: 0x0064C189 */); // 0x00000001806D4870-0x00000001806D4A00
	public static void cancel(RectTransform rect); // 0x00000001806D4C30-0x00000001806D4DA0
	public static void cancel(GameObject gameObject, int uniqueId, bool callOnComplete = false /* Metadata: 0x0064C18A */); // 0x00000001806D4600-0x00000001806D4820
	public static void cancel(LTRect ltRect, int uniqueId); // 0x00000001806D4A00-0x00000001806D4AD0
	public static void cancel(int uniqueId); // 0x00000001806D4820-0x00000001806D4870
	public static void cancel(int uniqueId, bool callOnComplete); // 0x00000001806D4430-0x00000001806D4600
	public static LTDescr descr(int uniqueId); // 0x00000001806D5980-0x00000001806D5B20
	public static LTDescr description(int uniqueId); // 0x00000001806D5B20-0x00000001806D5B70
	public static LTDescr[] descriptions(GameObject gameObject = null); // 0x00000001806D5B70-0x00000001806D5DD0
	[Obsolete("Use \'pause( id )\' instead")]
	public static void pause(GameObject gameObject, int uniqueId); // 0x00000001806DC4D0-0x00000001806DC5C0
	public static void pause(int uniqueId); // 0x00000001806DC5C0-0x00000001806DC670
	public static void pause(GameObject gameObject); // 0x00000001806DC340-0x00000001806DC4D0
	public static void pauseAll(); // 0x00000001806DC2A0-0x00000001806DC340
	public static void resumeAll(); // 0x00000001806DD2A0-0x00000001806DD340
	[Obsolete("Use \'resume( id )\' instead")]
	public static void resume(GameObject gameObject, int uniqueId); // 0x00000001806DD340-0x00000001806DD430
	public static void resume(int uniqueId); // 0x00000001806DD430-0x00000001806DD4E0
	public static void resume(GameObject gameObject); // 0x00000001806DD4E0-0x00000001806DD670
	public static bool isPaused(GameObject gameObject = null); // 0x00000001806D92A0-0x00000001806D9580
	public static bool isPaused(RectTransform rect); // 0x00000001806D9230-0x00000001806D92A0
	public static bool isPaused(int uniqueId); // 0x00000001806D9580-0x00000001806D96B0
	public static bool isTweening(GameObject gameObject = null); // 0x00000001806D9870-0x00000001806D9A90
	public static bool isTweening(RectTransform rect); // 0x00000001806D9800-0x00000001806D9870
	public static bool isTweening(int uniqueId); // 0x00000001806D9A90-0x00000001806D9B50
	public static bool isTweening(LTRect ltRect); // 0x00000001806D96B0-0x00000001806D9800
	public static void drawBezierPath(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float arrowSize = 0f /* Metadata: 0x0064C18B */, Transform arrowTransform = null); // 0x00000001806D6190-0x00000001806D69F0
	public static object logError(string error); // 0x00000001806D9B80-0x00000001806D9C30
	public static LTDescr options(LTDescr seed); // 0x00000001806DC240-0x00000001806DC2A0
	public static LTDescr options(); // 0x00000001806DBFB0-0x00000001806DC240
	private static LTDescr pushNewTween(GameObject gameObject, Vector3 to, float time, LTDescr tween); // 0x00000001806DC7A0-0x00000001806DC910
	public static LTDescr play(RectTransform rectTransform, Sprite[] sprites); // 0x00000001806DC670-0x00000001806DC7A0
	public static LTSeq sequence(bool initSequence = true /* Metadata: 0x0064C18F */); // 0x00000001806DE640-0x00000001806DE830
	public static LTDescr alpha(GameObject gameObject, float to, float time); // 0x00000001806D3F70-0x00000001806D4080
	public static LTDescr alpha(LTRect ltRect, float to, float time); // 0x00000001806D4080-0x00000001806D4170
	public static LTDescr textAlpha(RectTransform rectTransform, float to, float time); // 0x00000001806DEA10-0x00000001806DEAE0
	public static LTDescr alphaText(RectTransform rectTransform, float to, float time); // 0x00000001806D3CF0-0x00000001806D3DC0
	public static LTDescr alphaCanvas(CanvasGroup canvasGroup, float to, float time); // 0x00000001806D3C20-0x00000001806D3CF0
	public static LTDescr alphaVertex(GameObject gameObject, float to, float time); // 0x00000001806D3DC0-0x00000001806D3E80
	public static LTDescr color(GameObject gameObject, Color to, float time); // 0x00000001806D5150-0x00000001806D52A0
	public static LTDescr textColor(RectTransform rectTransform, Color to, float time); // 0x00000001806DEAE0-0x00000001806DEC00
	public static LTDescr colorText(RectTransform rectTransform, Color to, float time); // 0x00000001806D4EF0-0x00000001806D5010
	public static LTDescr delayedCall(float delayTime, Action callback); // 0x00000001806D52A0-0x00000001806D5380
	public static LTDescr delayedCall(float delayTime, Action<object> callback); // 0x00000001806D5640-0x00000001806D5720
	public static LTDescr delayedCall(GameObject gameObject, float delayTime, Action callback); // 0x00000001806D5460-0x00000001806D5640
	public static LTDescr delayedCall(GameObject gameObject, float delayTime, Action<object> callback); // 0x00000001806D5380-0x00000001806D5460
	public static LTDescr destroyAfter(LTRect rect, float delayTime); // 0x00000001806D5DD0-0x00000001806D5EC0
	public static LTDescr move(GameObject gameObject, Vector3 to, float time); // 0x00000001806DBD90-0x00000001806DBE40
	public static LTDescr move(GameObject gameObject, Vector2 to, float time); // 0x00000001806DB880-0x00000001806DB980
	public static LTDescr move(GameObject gameObject, Vector3[] to, float time); // 0x00000001806DB5C0-0x00000001806DB880
	public static LTDescr move(GameObject gameObject, LTBezierPath to, float time); // 0x00000001806DB380-0x00000001806DB5C0
	public static LTDescr move(GameObject gameObject, LTSpline to, float time); // 0x00000001806DBB50-0x00000001806DBD90
	public static LTDescr moveSpline(GameObject gameObject, Vector3[] to, float time); // 0x00000001806DA9C0-0x00000001806DAC30
	public static LTDescr moveSpline(GameObject gameObject, LTSpline to, float time); // 0x00000001806DAC30-0x00000001806DAE70
	public static LTDescr moveSplineLocal(GameObject gameObject, Vector3[] to, float time); // 0x00000001806DA750-0x00000001806DA9C0
	public static LTDescr move(LTRect ltRect, Vector2 to, float time); // 0x00000001806DB980-0x00000001806DBA70
	public static LTDescr moveMargin(LTRect ltRect, Vector2 to, float time); // 0x00000001806DA660-0x00000001806DA750
	public static LTDescr moveX(GameObject gameObject, float to, float time); // 0x00000001806DAF60-0x00000001806DB020
	public static LTDescr moveY(GameObject gameObject, float to, float time); // 0x00000001806DB110-0x00000001806DB1D0
	public static LTDescr moveZ(GameObject gameObject, float to, float time); // 0x00000001806DB2C0-0x00000001806DB380
	public static LTDescr moveLocal(GameObject gameObject, Vector3 to, float time); // 0x00000001806D9E70-0x00000001806D9F20
	public static LTDescr moveLocal(GameObject gameObject, Vector3[] to, float time); // 0x00000001806DA3A0-0x00000001806DA660
	public static LTDescr moveLocalX(GameObject gameObject, float to, float time); // 0x00000001806D9C30-0x00000001806D9CF0
	public static LTDescr moveLocalY(GameObject gameObject, float to, float time); // 0x00000001806D9CF0-0x00000001806D9DB0
	public static LTDescr moveLocalZ(GameObject gameObject, float to, float time); // 0x00000001806D9DB0-0x00000001806D9E70
	public static LTDescr moveLocal(GameObject gameObject, LTBezierPath to, float time); // 0x00000001806DA160-0x00000001806DA3A0
	public static LTDescr moveLocal(GameObject gameObject, LTSpline to, float time); // 0x00000001806D9F20-0x00000001806DA160
	public static LTDescr move(GameObject gameObject, Transform to, float time); // 0x00000001806DBE40-0x00000001806DBF20
	public static LTDescr rotate(GameObject gameObject, Vector3 to, float time); // 0x00000001806DE0D0-0x00000001806DE180
	public static LTDescr rotate(LTRect ltRect, float to, float time); // 0x00000001806DDFF0-0x00000001806DE0D0
	public static LTDescr rotateLocal(GameObject gameObject, Vector3 to, float time); // 0x00000001806DDAB0-0x00000001806DDB60
	public static LTDescr rotateX(GameObject gameObject, float to, float time); // 0x00000001806DDB60-0x00000001806DDC20
	public static LTDescr rotateY(GameObject gameObject, float to, float time); // 0x00000001806DDC20-0x00000001806DDCE0
	public static LTDescr rotateZ(GameObject gameObject, float to, float time); // 0x00000001806DDCE0-0x00000001806DDDA0
	public static LTDescr rotateAround(GameObject gameObject, Vector3 axis, float add, float time); // 0x00000001806DD890-0x00000001806DD980
	public static LTDescr rotateAroundLocal(GameObject gameObject, Vector3 axis, float add, float time); // 0x00000001806DD670-0x00000001806DD760
	public static LTDescr scale(GameObject gameObject, Vector3 to, float time); // 0x00000001806DE3C0-0x00000001806DE470
	public static LTDescr scale(LTRect ltRect, Vector2 to, float time); // 0x00000001806DE470-0x00000001806DE560
	public static LTDescr scaleX(GameObject gameObject, float to, float time); // 0x00000001806DE180-0x00000001806DE240
	public static LTDescr scaleY(GameObject gameObject, float to, float time); // 0x00000001806DE240-0x00000001806DE300
	public static LTDescr scaleZ(GameObject gameObject, float to, float time); // 0x00000001806DE300-0x00000001806DE3C0
	public static LTDescr value(GameObject gameObject, float from, float to, float time); // 0x00000001806DF890-0x00000001806DF980
	public static LTDescr value(float from, float to, float time); // 0x00000001806DFB80-0x00000001806DFC80
	public static LTDescr value(GameObject gameObject, Vector2 from, Vector2 to, float time); // 0x00000001806E01E0-0x00000001806E0320
	public static LTDescr value(GameObject gameObject, Vector3 from, Vector3 to, float time); // 0x00000001806DF980-0x00000001806DFA60
	public static LTDescr value(GameObject gameObject, Color from, Color to, float time); // 0x00000001806DF400-0x00000001806DF590
	public static LTDescr value(GameObject gameObject, Action<float> callOnUpdate, float from, float to, float time); // 0x00000001806DFF00-0x00000001806E0040
	public static LTDescr value(GameObject gameObject, Action<float, float> callOnUpdateRatio, float from, float to, float time); // 0x00000001806DFC80-0x00000001806DFDC0
	public static LTDescr value(GameObject gameObject, Action<Color> callOnUpdate, Color from, Color to, float time); // 0x00000001806DF6F0-0x00000001806DF890
	public static LTDescr value(GameObject gameObject, Action<Color, object> callOnUpdate, Color from, Color to, float time); // 0x00000001806E0040-0x00000001806E01E0
	public static LTDescr value(GameObject gameObject, Action<Vector2> callOnUpdate, Vector2 from, Vector2 to, float time); // 0x00000001806DF590-0x00000001806DF6F0
	public static LTDescr value(GameObject gameObject, Action<Vector3> callOnUpdate, Vector3 from, Vector3 to, float time); // 0x00000001806DFA60-0x00000001806DFB80
	public static LTDescr value(GameObject gameObject, Action<float, object> callOnUpdate, float from, float to, float time); // 0x00000001806DFDC0-0x00000001806DFF00
	public static LTDescr delayedSound(AudioClip audio, Vector3 pos, float volume); // 0x00000001806D5850-0x00000001806D5980
	public static LTDescr delayedSound(GameObject gameObject, AudioClip audio, Vector3 pos, float volume); // 0x00000001806D5720-0x00000001806D5850
	public static LTDescr move(RectTransform rectTrans, Vector3 to, float time); // 0x00000001806DBA70-0x00000001806DBB50
	public static LTDescr moveX(RectTransform rectTrans, float to, float time); // 0x00000001806DAE70-0x00000001806DAF60
	public static LTDescr moveY(RectTransform rectTrans, float to, float time); // 0x00000001806DB020-0x00000001806DB110
	public static LTDescr moveZ(RectTransform rectTrans, float to, float time); // 0x00000001806DB1D0-0x00000001806DB2C0
	public static LTDescr rotate(RectTransform rectTrans, float to, float time); // 0x00000001806DDEC0-0x00000001806DDFF0
	public static LTDescr rotate(RectTransform rectTrans, Vector3 to, float time); // 0x00000001806DDDA0-0x00000001806DDEC0
	public static LTDescr rotateAround(RectTransform rectTrans, Vector3 axis, float to, float time); // 0x00000001806DD980-0x00000001806DDAB0
	public static LTDescr rotateAroundLocal(RectTransform rectTrans, Vector3 axis, float to, float time); // 0x00000001806DD760-0x00000001806DD890
	public static LTDescr scale(RectTransform rectTrans, Vector3 to, float time); // 0x00000001806DE560-0x00000001806DE640
	public static LTDescr size(RectTransform rectTrans, Vector2 to, float time); // 0x00000001806DE830-0x00000001806DE930
	public static LTDescr alpha(RectTransform rectTrans, float to, float time); // 0x00000001806D3E80-0x00000001806D3F70
	public static LTDescr color(RectTransform rectTrans, Color to, float time); // 0x00000001806D5010-0x00000001806D5150
	public static float tweenOnCurve(LTDescr tweenDescr, float ratioPassed); // 0x00000001806DED60-0x00000001806DEDC0
	public static Vector3 tweenOnCurveVector(LTDescr tweenDescr, float ratioPassed); // 0x00000001806DEC00-0x00000001806DED60
	public static float easeOutQuadOpt(float start, float diff, float ratioPassed); // 0x00000001806D7930-0x00000001806D7950
	public static float easeInQuadOpt(float start, float diff, float ratioPassed); // 0x00000001806D7550-0x00000001806D7560
	public static float easeInOutQuadOpt(float start, float diff, float ratioPassed); // 0x00000001806D7350-0x00000001806D73B0
	public static Vector3 easeInOutQuadOpt(Vector3 start, Vector3 diff, float ratioPassed); // 0x00000001806D7230-0x00000001806D7350
	public static float linear(float start, float end, float val); // 0x00000001806D9B50-0x00000001806D9B80
	public static float clerp(float start, float end, float val); // 0x00000001806D4DA0-0x00000001806D4E50
	public static float spring(float start, float end, float val); // 0x00000001806DE930-0x00000001806DEA10
	public static float easeInQuad(float start, float end, float val); // 0x00000001806D7560-0x00000001806D7580
	public static float easeOutQuad(float start, float end, float val); // 0x00000001806D7950-0x00000001806D7980
	public static float easeInOutQuad(float start, float end, float val); // 0x00000001806D73B0-0x00000001806D7410
	public static float easeInOutQuadOpt2(float start, float diffBy2, float val, float val2); // 0x00000001806D71F0-0x00000001806D7230
	public static float easeInCubic(float start, float end, float val); // 0x00000001806D6B30-0x00000001806D6B50
	public static float easeOutCubic(float start, float end, float val); // 0x00000001806D7780-0x00000001806D77B0
	public static float easeInOutCubic(float start, float end, float val); // 0x00000001806D6F70-0x00000001806D6FD0
	public static float easeInQuart(float start, float end, float val); // 0x00000001806D7580-0x00000001806D75A0
	public static float easeOutQuart(float start, float end, float val); // 0x00000001806D7980-0x00000001806D79C0
	public static float easeInOutQuart(float start, float end, float val); // 0x00000001806D7410-0x00000001806D7480
	public static float easeInQuint(float start, float end, float val); // 0x00000001806D75A0-0x00000001806D75C0
	public static float easeOutQuint(float start, float end, float val); // 0x00000001806D79C0-0x00000001806D7A00
	public static float easeInOutQuint(float start, float end, float val); // 0x00000001806D7480-0x00000001806D74F0
	public static float easeInSine(float start, float end, float val); // 0x00000001806D75C0-0x00000001806D7610
	public static float easeOutSine(float start, float end, float val); // 0x00000001806D7A00-0x00000001806D7A40
	public static float easeInOutSine(float start, float end, float val); // 0x00000001806D74F0-0x00000001806D7550
	public static float easeInExpo(float start, float end, float val); // 0x00000001806D6C70-0x00000001806D6CC0
	public static float easeOutExpo(float start, float end, float val); // 0x00000001806D78D0-0x00000001806D7930
	public static float easeInOutExpo(float start, float end, float val); // 0x00000001806D7160-0x00000001806D71F0
	public static float easeInCirc(float start, float end, float val); // 0x00000001806D6AC0-0x00000001806D6B30
	public static float easeOutCirc(float start, float end, float val); // 0x00000001806D7720-0x00000001806D7780
	public static float easeInOutCirc(float start, float end, float val); // 0x00000001806D6EB0-0x00000001806D6F70
	public static float easeInBounce(float start, float end, float val); // 0x00000001806D6A30-0x00000001806D6AC0
	public static float easeOutBounce(float start, float end, float val); // 0x00000001806D7650-0x00000001806D7720
	public static float easeInOutBounce(float start, float end, float val); // 0x00000001806D6D60-0x00000001806D6EB0
	public static float easeInBack(float start, float end, float val, float overshoot = 1f /* Metadata: 0x0064C190 */); // 0x00000001806D69F0-0x00000001806D6A30
	public static float easeOutBack(float start, float end, float val, float overshoot = 1f /* Metadata: 0x0064C194 */); // 0x00000001806D7610-0x00000001806D7650
	public static float easeInOutBack(float start, float end, float val, float overshoot = 1f /* Metadata: 0x0064C198 */); // 0x00000001806D6CC0-0x00000001806D6D60
	public static float easeInElastic(float start, float end, float val, float overshoot = 1f /* Metadata: 0x0064C19C */, float period = 0.3f /* Metadata: 0x0064C1A0 */); // 0x00000001806D6B50-0x00000001806D6C70
	public static float easeOutElastic(float start, float end, float val, float overshoot = 1f /* Metadata: 0x0064C1A4 */, float period = 0.3f /* Metadata: 0x0064C1A8 */); // 0x00000001806D77B0-0x00000001806D78D0
	public static float easeInOutElastic(float start, float end, float val, float overshoot = 1f /* Metadata: 0x0064C1AC */, float period = 0.3f /* Metadata: 0x0064C1B0 */); // 0x00000001806D6FD0-0x00000001806D7160
	public static LTDescr followDamp(Transform trans, Transform target, LeanProp prop, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0064C1B4 */); // 0x00000001806D7E10-0x00000001806D81F0
	public static LTDescr followSpring(Transform trans, Transform target, LeanProp prop, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0064C1B8 */, float friction = 2f /* Metadata: 0x0064C1BC */, float accelRate = 0.5f /* Metadata: 0x0064C1C0 */); // 0x00000001806D8590-0x00000001806D8990
	public static LTDescr followBounceOut(Transform trans, Transform target, LeanProp prop, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0064C1C4 */, float friction = 2f /* Metadata: 0x0064C1C8 */, float accelRate = 0.5f /* Metadata: 0x0064C1CC */, float hitDamping = 0.9f /* Metadata: 0x0064C1D0 */); // 0x00000001806D7A40-0x00000001806D7E10
	public static LTDescr followLinear(Transform trans, Transform target, LeanProp prop, float moveSpeed); // 0x00000001806D81F0-0x00000001806D8590
	public static void addListener(int eventId, Action<LTEvent> callback); // 0x00000001806D3660-0x00000001806D36D0
	public static void addListener(GameObject caller, int eventId, Action<LTEvent> callback); // 0x00000001806D36D0-0x00000001806D3AE0
	public static bool removeListener(int eventId, Action<LTEvent> callback); // 0x00000001806DC9F0-0x00000001806DCC20
	public static bool removeListener(int eventId); // 0x00000001806DC910-0x00000001806DC9F0
	public static bool removeListener(GameObject caller, int eventId, Action<LTEvent> callback); // 0x00000001806DCC20-0x00000001806DCE20
	public static void dispatchEvent(int eventId); // 0x00000001806D6140-0x00000001806D6190
	public static void dispatchEvent(int eventId, object data); // 0x00000001806D5EC0-0x00000001806D6140
}

