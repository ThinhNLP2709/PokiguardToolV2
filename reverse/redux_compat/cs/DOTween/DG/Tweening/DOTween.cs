/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening
{
	public class DOTween // TypeDefIndex: 13347
	{
		// Fields
		public static readonly string Version; // 0x00
		public static bool useSafeMode; // 0x08
		public static SafeModeLogBehaviour safeModeLogBehaviour; // 0x0C
		public static NestedTweenFailureBehaviour nestedTweenFailureBehaviour; // 0x10
		public static bool showUnityEditorReport; // 0x14
		public static float timeScale; // 0x18
		public static float unscaledTimeScale; // 0x1C
		public static bool useSmoothDeltaTime; // 0x20
		public static float maxSmoothUnscaledTime; // 0x24
		internal static RewindCallbackMode rewindCallbackMode; // 0x28
		private static LogBehaviour _logBehaviour; // 0x2C
		public static Func<LogType, object, bool> onWillLog; // 0x30
		public static bool drawGizmos; // 0x38
		public static bool debugMode; // 0x39
		private static bool _fooDebugStoreTargetId; // 0x3A
		public static UpdateType defaultUpdateType; // 0x3C
		public static bool defaultTimeScaleIndependent; // 0x40
		public static AutoPlay defaultAutoPlay; // 0x44
		public static bool defaultAutoKill; // 0x48
		public static LoopType defaultLoopType; // 0x4C
		public static bool defaultRecyclable; // 0x50
		public static Ease defaultEaseType; // 0x54
		public static float defaultEaseOvershootOrAmplitude; // 0x58
		public static float defaultEasePeriod; // 0x5C
		public static DOTweenComponent instance; // 0x60
		private static bool _foo_isQuitting; // 0x68
		internal static int maxActiveTweenersReached; // 0x6C
		internal static int maxActiveSequencesReached; // 0x70
		internal static SafeModeReport safeModeReport; // 0x74
		internal static readonly List<TweenCallback> GizmosDelegates; // 0x88
		internal static bool initialized; // 0x90
		private static int _isQuittingFrame; // 0x94
	
		// Properties
		public static LogBehaviour logBehaviour { get; set; } // 0x0000000180705B60-0x0000000180705BB0 0x0000000180705C90-0x0000000180705D00
		public static bool debugStoreTargetId { get; set; } // 0x0000000180705A60-0x0000000180705AC0 0x0000000180705BB0-0x0000000180705C10
		internal static bool isQuitting { get; set; } // 0x0000000180705AC0-0x0000000180705B60 0x0000000180705C10-0x0000000180705C90
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass67_0 // TypeDefIndex: 13348
		{
			// Fields
			public float v; // 0x10
			public DOSetter<float> setter; // 0x18
	
			// Constructors
			public __c__DisplayClass67_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal float _To_b__0(); // 0x00000001807187E0-0x00000001807187F0
			internal void _To_b__1(float x); // 0x0000000180719990-0x00000001807199C0
		}
	
		// Constructors
		public DOTween(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static DOTween(); // 0x0000000180705800-0x0000000180705A60
	
		// Methods
		public static IDOTweenInit Init(bool? recycleAllByDefault = default, bool? useSafeMode = default, LogBehaviour? logBehaviour = default); // 0x0000000180702500-0x0000000180702660
		private static void AutoInit(); // 0x0000000180701420-0x0000000180701520
		private static IDOTweenInit Init(DOTweenSettings settings, bool? recycleAllByDefault, bool? useSafeMode, LogBehaviour? logBehaviour); // 0x0000000180701F40-0x0000000180702500
		public static void SetTweensCapacity(int tweenersCapacity, int sequencesCapacity); // 0x0000000180703AD0-0x0000000180703B30
		public static void Clear(bool destroy = false /* Metadata: 0x006A7948 */); // 0x0000000180701860-0x00000001807018B0
		internal static void Clear(bool destroy, bool isApplicationQuitting); // 0x0000000180701560-0x0000000180701860
		public static void ClearCachedTweens(); // 0x0000000180701520-0x0000000180701560
		public static int Validate(); // 0x00000001807057C0-0x0000000180705800
		public static void ManualUpdate(float deltaTime, float unscaledDeltaTime); // 0x0000000180702B60-0x0000000180702C30
		public static TweenerCore<float, float, FloatOptions> To(DOGetter<float> getter, DOSetter<float> setter, float endValue, float duration); // 0x0000000180704AC0-0x0000000180704B60
		public static TweenerCore<double, double, NoOptions> To(DOGetter<double> getter, DOSetter<double> setter, double endValue, float duration); // 0x00000001807052A0-0x0000000180705340
		public static TweenerCore<int, int, NoOptions> To(DOGetter<int> getter, DOSetter<int> setter, int endValue, float duration); // 0x0000000180705150-0x00000001807051F0
		public static TweenerCore<uint, uint, UintOptions> To(DOGetter<uint> getter, DOSetter<uint> setter, uint endValue, float duration); // 0x0000000180704C10-0x0000000180704CB0
		public static TweenerCore<long, long, NoOptions> To(DOGetter<long> getter, DOSetter<long> setter, long endValue, float duration); // 0x00000001807048C0-0x0000000180704960
		public static TweenerCore<ulong, ulong, NoOptions> To(DOGetter<ulong> getter, DOSetter<ulong> setter, ulong endValue, float duration); // 0x0000000180704F40-0x0000000180704FE0
		public static TweenerCore<string, string, StringOptions> To(DOGetter<string> getter, DOSetter<string> setter, string endValue, float duration); // 0x0000000180704CB0-0x0000000180704D50
		public static TweenerCore<Vector2, Vector2, VectorOptions> To(DOGetter<Vector2> getter, DOSetter<Vector2> setter, Vector2 endValue, float duration); // 0x0000000180704EA0-0x0000000180704F40
		public static TweenerCore<Vector3, Vector3, VectorOptions> To(DOGetter<Vector3> getter, DOSetter<Vector3> setter, Vector3 endValue, float duration); // 0x0000000180704960-0x0000000180704A10
		public static TweenerCore<Vector4, Vector4, VectorOptions> To(DOGetter<Vector4> getter, DOSetter<Vector4> setter, Vector4 endValue, float duration); // 0x0000000180705340-0x00000001807053F0
		public static TweenerCore<Quaternion, Vector3, QuaternionOptions> To(DOGetter<Quaternion> getter, DOSetter<Quaternion> setter, Vector3 endValue, float duration); // 0x0000000180704A10-0x0000000180704AC0
		public static TweenerCore<Color, Color, ColorOptions> To(DOGetter<Color> getter, DOSetter<Color> setter, Color endValue, float duration); // 0x0000000180704B60-0x0000000180704C10
		public static TweenerCore<Rect, Rect, RectOptions> To(DOGetter<Rect> getter, DOSetter<Rect> setter, Rect endValue, float duration); // 0x0000000180704DF0-0x0000000180704EA0
		public static Tweener To(DOGetter<RectOffset> getter, DOSetter<RectOffset> setter, RectOffset endValue, float duration); // 0x0000000180704D50-0x0000000180704DF0
		public static TweenerCore<T1, T2, TPlugOptions> To<T1, T2, TPlugOptions>(ABSTweenPlugin<T1, T2, TPlugOptions> plugin, DOGetter<T1> getter, DOSetter<T1> setter, T2 endValue, float duration)
			where TPlugOptions : struct, IPlugOptions;
		public static TweenerCore<Vector3, Vector3, VectorOptions> ToAxis(DOGetter<Vector3> getter, DOSetter<Vector3> setter, float endValue, float duration, AxisConstraint axisConstraint = AxisConstraint.None | AxisConstraint.X /* Metadata: 0x006A7949 */); // 0x00000001807047F0-0x00000001807048C0
		public static TweenerCore<Color, Color, ColorOptions> ToAlpha(DOGetter<Color> getter, DOSetter<Color> setter, float endValue, float duration); // 0x0000000180704500-0x00000001807045D0
		public static Tweener To(DOSetter<float> setter, float startValue, float endValue, float duration); // 0x0000000180704FE0-0x0000000180705150
		public static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> Punch(DOGetter<Vector3> getter, DOSetter<Vector3> setter, Vector3 direction, float duration, int vibrato = 10 /* Metadata: 0x006A794A */, float elasticity = 1f /* Metadata: 0x006A794B */); // 0x00000001807032D0-0x0000000180703650
		public static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> Shake(DOGetter<Vector3> getter, DOSetter<Vector3> setter, float duration, float strength = 3f /* Metadata: 0x006A794F */, int vibrato = 10 /* Metadata: 0x006A7953 */, float randomness = 90f /* Metadata: 0x006A7954 */, bool ignoreZAxis = true /* Metadata: 0x006A7958 */, bool fadeOut = true /* Metadata: 0x006A7959 */, ShakeRandomnessMode randomnessMode = ShakeRandomnessMode.Full /* Metadata: 0x006A795A */); // 0x0000000180704320-0x0000000180704410
		public static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> Shake(DOGetter<Vector3> getter, DOSetter<Vector3> setter, float duration, Vector3 strength, int vibrato = 10 /* Metadata: 0x006A795B */, float randomness = 90f /* Metadata: 0x006A795C */, bool fadeOut = true /* Metadata: 0x006A7960 */, ShakeRandomnessMode randomnessMode = ShakeRandomnessMode.Full /* Metadata: 0x006A7961 */); // 0x0000000180704240-0x0000000180704320
		private static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> Shake(DOGetter<Vector3> getter, DOSetter<Vector3> setter, float duration, Vector3 strength, int vibrato, float randomness, bool ignoreZAxis, bool vectorBased, bool fadeOut, ShakeRandomnessMode randomnessMode); // 0x0000000180703B30-0x0000000180704240
		public static TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> ToArray(DOGetter<Vector3> getter, DOSetter<Vector3> setter, Vector3[] endValues, float[] durations); // 0x00000001807045D0-0x00000001807047F0
		internal static TweenerCore<Color2, Color2, ColorOptions> To(DOGetter<Color2> getter, DOSetter<Color2> setter, Color2 endValue, float duration); // 0x00000001807051F0-0x00000001807052A0
		public static Sequence Sequence(); // 0x0000000180703910-0x0000000180703A70
		public static Sequence Sequence(object target); // 0x0000000180703A70-0x0000000180703AD0
		public static int CompleteAll(bool withCallbacks = false /* Metadata: 0x006A7962 */); // 0x00000001807018B0-0x0000000180701920
		public static int Complete(object targetOrId, bool withCallbacks = false /* Metadata: 0x006A7963 */); // 0x0000000180701B10-0x0000000180701BA0
		internal static int CompleteAndReturnKilledTot(); // 0x0000000180701A10-0x0000000180701A80
		internal static int CompleteAndReturnKilledTot(object targetOrId); // 0x0000000180701990-0x0000000180701A10
		internal static int CompleteAndReturnKilledTot(object target, object id); // 0x0000000180701A80-0x0000000180701B10
		internal static int CompleteAndReturnKilledTotExceptFor(params object[] excludeTargetsOrIds); // 0x0000000180701920-0x0000000180701990
		public static int FlipAll(); // 0x0000000180701BA0-0x0000000180701C10
		public static int Flip(object targetOrId); // 0x0000000180701C10-0x0000000180701C90
		public static int GotoAll(float to, bool andPlay = false /* Metadata: 0x006A7964 */); // 0x0000000180701C90-0x0000000180701D10
		public static int Goto(object targetOrId, float to, bool andPlay = false /* Metadata: 0x006A7965 */); // 0x0000000180701D10-0x0000000180701DB0
		public static int KillAll(bool complete = false /* Metadata: 0x006A7966 */); // 0x0000000180702860-0x00000001807028E0
		public static int KillAll(bool complete, params object[] idsOrTargetsToExclude); // 0x00000001807026F0-0x0000000180702860
		public static int Kill(object targetOrId, bool complete = false /* Metadata: 0x006A7967 */); // 0x0000000180702A30-0x0000000180702B60
		public static int Kill(object target, object id, bool complete = false /* Metadata: 0x006A7968 */); // 0x00000001807028E0-0x0000000180702A30
		public static int PauseAll(); // 0x0000000180702C30-0x0000000180702CA0
		public static int Pause(object targetOrId); // 0x0000000180702CA0-0x0000000180702D20
		public static int PlayAll(); // 0x0000000180702DA0-0x0000000180702E10
		public static int Play(object targetOrId); // 0x0000000180703130-0x00000001807031B0
		public static int Play(object target, object id); // 0x00000001807031B0-0x0000000180703250
		public static int PlayBackwardsAll(); // 0x0000000180702E10-0x0000000180702E80
		public static int PlayBackwards(object targetOrId); // 0x0000000180702E80-0x0000000180702F00
		public static int PlayBackwards(object target, object id); // 0x0000000180702F00-0x0000000180702FA0
		public static int PlayForwardAll(); // 0x0000000180702FA0-0x0000000180703010
		public static int PlayForward(object targetOrId); // 0x0000000180703010-0x0000000180703090
		public static int PlayForward(object target, object id); // 0x0000000180703090-0x0000000180703130
		public static int RestartAll(bool includeDelay = true /* Metadata: 0x006A7969 */); // 0x0000000180703650-0x00000001807036C0
		public static int Restart(object targetOrId, bool includeDelay = true /* Metadata: 0x006A796A */, float changeDelayTo = -1f /* Metadata: 0x006A796B */); // 0x0000000180703770-0x0000000180703810
		public static int Restart(object target, object id, bool includeDelay = true /* Metadata: 0x006A796F */, float changeDelayTo = -1f /* Metadata: 0x006A7970 */); // 0x00000001807036C0-0x0000000180703770
		public static int RewindAll(bool includeDelay = true /* Metadata: 0x006A7974 */); // 0x0000000180703810-0x0000000180703880
		public static int Rewind(object targetOrId, bool includeDelay = true /* Metadata: 0x006A7975 */); // 0x0000000180703880-0x0000000180703910
		public static int SmoothRewindAll(); // 0x0000000180704410-0x0000000180704480
		public static int SmoothRewind(object targetOrId); // 0x0000000180704480-0x0000000180704500
		public static int TogglePauseAll(); // 0x00000001807053F0-0x0000000180705460
		public static int TogglePause(object targetOrId); // 0x0000000180705460-0x00000001807054E0
		public static bool IsTweening(object targetOrId, bool alsoCheckIfIsPlaying = false /* Metadata: 0x006A7976 */); // 0x0000000180702660-0x00000001807026F0
		public static int TotalActiveTweens(); // 0x0000000180705580-0x00000001807055D0
		public static int TotalActiveTweeners(); // 0x0000000180705530-0x0000000180705580
		public static int TotalActiveSequences(); // 0x00000001807054E0-0x0000000180705530
		public static int TotalPlayingTweens(); // 0x00000001807055D0-0x0000000180705610
		public static int TotalTweensById(object id, bool playingOnly = false /* Metadata: 0x006A7977 */); // 0x0000000180705610-0x0000000180705680
		public static List<Tween> PlayingTweens(List<Tween> fillableList = null); // 0x0000000180703250-0x00000001807032D0
		public static List<Tween> PausedTweens(List<Tween> fillableList = null); // 0x0000000180702D20-0x0000000180702DA0
		public static List<Tween> TweensById(object id, bool playingOnly = false /* Metadata: 0x006A7978 */, List<Tween> fillableList = null); // 0x0000000180705680-0x0000000180705730
		public static List<Tween> TweensByTarget(object target, bool playingOnly = false /* Metadata: 0x006A7979 */, List<Tween> fillableList = null); // 0x0000000180705730-0x00000001807057C0
		private static void InitCheck(); // 0x0000000180701DB0-0x0000000180701F40
		private static TweenerCore<T1, T2, TPlugOptions> ApplyTo<T1, T2, TPlugOptions>(DOGetter<T1> getter, DOSetter<T1> setter, T2 endValue, float duration, ABSTweenPlugin<T1, T2, TPlugOptions> plugin = null)
			where TPlugOptions : struct, IPlugOptions;
	}
}
