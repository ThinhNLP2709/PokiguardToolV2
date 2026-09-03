/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DG.Tweening.Core;
using DG.Tweening.Plugins;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening
{
	public static class TweenSettingsExtensions // TypeDefIndex: 13446
	{
		// Methods
		private static bool ValidateAddToSequence(Sequence s, Tween t, bool ignoreTween = false /* Metadata: 0x006A7A6B */); // 0x0000000180717E20-0x0000000180717EC0
	
		// Extension methods
		public static T SetAutoKill<T>(this T t)
			where T : Tween;
		public static T SetAutoKill<T>(this T t, bool autoKillOnCompletion)
			where T : Tween;
		public static T SetId<T>(this T t, object objectId)
			where T : Tween;
		public static T SetId<T>(this T t, string stringId)
			where T : Tween;
		public static T SetId<T>(this T t, int intId)
			where T : Tween;
		public static T SetLink<T>(this T t, GameObject gameObject)
			where T : Tween;
		public static T SetLink<T>(this T t, GameObject gameObject, LinkBehaviour behaviour)
			where T : Tween;
		public static T SetTarget<T>(this T t, object target)
			where T : Tween;
		public static T SetLoops<T>(this T t, int loops)
			where T : Tween;
		public static T SetLoops<T>(this T t, int loops, LoopType loopType)
			where T : Tween;
		public static T SetEase<T>(this T t, Ease ease)
			where T : Tween;
		public static T SetEase<T>(this T t, Ease ease, float overshoot)
			where T : Tween;
		public static T SetEase<T>(this T t, Ease ease, float amplitude, float period)
			where T : Tween;
		public static T SetEase<T>(this T t, AnimationCurve animCurve)
			where T : Tween;
		public static T SetEase<T>(this T t, EaseFunction customEase)
			where T : Tween;
		public static T SetRecyclable<T>(this T t)
			where T : Tween;
		public static T SetRecyclable<T>(this T t, bool recyclable)
			where T : Tween;
		public static T SetUpdate<T>(this T t, bool isIndependentUpdate)
			where T : Tween;
		public static T SetUpdate<T>(this T t, UpdateType updateType)
			where T : Tween;
		public static T SetUpdate<T>(this T t, UpdateType updateType, bool isIndependentUpdate)
			where T : Tween;
		public static T SetInverted<T>(this T t)
			where T : Tween;
		public static T SetInverted<T>(this T t, bool inverted)
			where T : Tween;
		public static T OnStart<T>(this T t, TweenCallback action)
			where T : Tween;
		public static T OnPlay<T>(this T t, TweenCallback action)
			where T : Tween;
		public static T OnPause<T>(this T t, TweenCallback action)
			where T : Tween;
		public static T OnRewind<T>(this T t, TweenCallback action)
			where T : Tween;
		public static T OnUpdate<T>(this T t, TweenCallback action)
			where T : Tween;
		public static T OnStepComplete<T>(this T t, TweenCallback action)
			where T : Tween;
		public static T OnComplete<T>(this T t, TweenCallback action)
			where T : Tween;
		public static T OnKill<T>(this T t, TweenCallback action)
			where T : Tween;
		public static T OnWaypointChange<T>(this T t, TweenCallback<int> action)
			where T : Tween;
		public static T SetAs<T>(this T t, Tween asTween)
			where T : Tween;
		public static T SetAs<T>(this T t, TweenParams tweenParams)
			where T : Tween;
		public static Sequence Append(this Sequence s, Tween t); // 0x0000000180716D10-0x0000000180716DD0
		public static Sequence Prepend(this Sequence s, Tween t); // 0x00000001807172B0-0x00000001807174B0
		public static Sequence Join(this Sequence s, Tween t); // 0x00000001807170A0-0x0000000180717160
		public static Sequence Insert(this Sequence s, float atPosition, Tween t); // 0x0000000180716F70-0x0000000180717030
		public static Sequence AppendInterval(this Sequence s, float interval); // 0x0000000180716C90-0x0000000180716D10
		public static Sequence PrependInterval(this Sequence s, float interval); // 0x00000001807171D0-0x00000001807172B0
		public static Sequence AppendCallback(this Sequence s, TweenCallback callback); // 0x0000000180716C20-0x0000000180716C90
		public static Sequence PrependCallback(this Sequence s, TweenCallback callback); // 0x0000000180717160-0x00000001807171D0
		public static Sequence JoinCallback(this Sequence s, TweenCallback callback); // 0x0000000180717030-0x00000001807170A0
		public static Sequence InsertCallback(this Sequence s, float atPosition, TweenCallback callback); // 0x0000000180716F00-0x0000000180716F70
		public static T From<T>(this T t)
			where T : Tweener;
		public static T From<T>(this T t, bool isRelative)
			where T : Tweener;
		public static T From<T>(this T t, bool setImmediately, bool isRelative)
			where T : Tweener;
		public static TweenerCore<T1, T2, TPlugOptions> From<T1, T2, TPlugOptions>(this TweenerCore<T1, T2, TPlugOptions> t, T2 fromValue, bool setImmediately = true /* Metadata: 0x006A7A6C */, bool isRelative = false /* Metadata: 0x006A7A6D */)
			where TPlugOptions : struct, IPlugOptions;
		public static TweenerCore<Color, Color, ColorOptions> From(this TweenerCore<Color, Color, ColorOptions> t, float fromAlphaValue, bool setImmediately = true /* Metadata: 0x006A7A6E */, bool isRelative = false /* Metadata: 0x006A7A6F */); // 0x0000000180716DD0-0x0000000180716E40
		public static TweenerCore<Vector3, Vector3, VectorOptions> From(this TweenerCore<Vector3, Vector3, VectorOptions> t, float fromValue, bool setImmediately = true /* Metadata: 0x006A7A70 */, bool isRelative = false /* Metadata: 0x006A7A71 */); // 0x0000000180716E40-0x0000000180716EA0
		public static TweenerCore<Vector2, Vector2, CircleOptions> From(this TweenerCore<Vector2, Vector2, CircleOptions> t, float fromValueDegrees, bool setImmediately = true /* Metadata: 0x006A7A72 */, bool isRelative = false /* Metadata: 0x006A7A73 */); // 0x0000000180716EA0-0x0000000180716F00
		public static T SetDelay<T>(this T t, float delay)
			where T : Tween;
		public static T SetDelay<T>(this T t, float delay, bool asPrependedIntervalIfSequence)
			where T : Tween;
		public static T SetRelative<T>(this T t)
			where T : Tween;
		public static T SetRelative<T>(this T t, bool isRelative)
			where T : Tween;
		public static T SetSpeedBased<T>(this T t)
			where T : Tween;
		public static T SetSpeedBased<T>(this T t, bool isSpeedBased)
			where T : Tween;
		public static Tweener SetOptions(this TweenerCore<float, float, FloatOptions> t, bool snapping); // 0x0000000180717B40-0x0000000180717B60
		public static Tweener SetOptions(this TweenerCore<Vector2, Vector2, VectorOptions> t, bool snapping); // 0x0000000180717960-0x0000000180717980
		public static Tweener SetOptions(this TweenerCore<Vector2, Vector2, VectorOptions> t, AxisConstraint axisConstraint, bool snapping = false /* Metadata: 0x006A7A74 */); // 0x0000000180717B90-0x0000000180717BB0
		public static Tweener SetOptions(this TweenerCore<Vector3, Vector3, VectorOptions> t, bool snapping); // 0x0000000180717B00-0x0000000180717B20
		public static Tweener SetOptions(this TweenerCore<Vector3, Vector3, VectorOptions> t, AxisConstraint axisConstraint, bool snapping = false /* Metadata: 0x006A7A75 */); // 0x0000000180717B20-0x0000000180717B40
		public static Tweener SetOptions(this TweenerCore<Vector4, Vector4, VectorOptions> t, bool snapping); // 0x0000000180717920-0x0000000180717940
		public static Tweener SetOptions(this TweenerCore<Vector4, Vector4, VectorOptions> t, AxisConstraint axisConstraint, bool snapping = false /* Metadata: 0x006A7A76 */); // 0x0000000180717900-0x0000000180717920
		public static Tweener SetOptions(this TweenerCore<Quaternion, Vector3, QuaternionOptions> t, bool useShortest360Route = true /* Metadata: 0x006A7A77 */); // 0x0000000180717980-0x00000001807179A0
		public static Tweener SetOptions(this TweenerCore<Color, Color, ColorOptions> t, bool alphaOnly); // 0x0000000180717940-0x0000000180717960
		public static Tweener SetOptions(this TweenerCore<Rect, Rect, RectOptions> t, bool snapping); // 0x0000000180717940-0x0000000180717960
		public static Tweener SetOptions(this TweenerCore<string, string, StringOptions> t, bool richTextEnabled, ScrambleMode scrambleMode = ScrambleMode.None /* Metadata: 0x006A7A78 */, string scrambleChars = null); // 0x00000001807179A0-0x0000000180717AA0
		public static Tweener SetOptions(this TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, bool snapping); // 0x0000000180717960-0x0000000180717980
		public static Tweener SetOptions(this TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, AxisConstraint axisConstraint, bool snapping = false /* Metadata: 0x006A7A79 */); // 0x0000000180717B90-0x0000000180717BB0
		public static Tweener SetOptions(this TweenerCore<Vector2, Vector2, CircleOptions> t, float endValueDegrees, bool relativeCenter = true /* Metadata: 0x006A7A7A */, bool snapping = false /* Metadata: 0x006A7A7B */); // 0x0000000180717AD0-0x0000000180717B00
		public static TweenerCore<Vector3, Path, PathOptions> SetOptions(this TweenerCore<Vector3, Path, PathOptions> t, AxisConstraint lockPosition, AxisConstraint lockRotation = AxisConstraint.None /* Metadata: 0x006A7A7C */); // 0x0000000180717B60-0x0000000180717B90
		public static TweenerCore<Vector3, Path, PathOptions> SetOptions(this TweenerCore<Vector3, Path, PathOptions> t, bool closePath, AxisConstraint lockPosition = AxisConstraint.None /* Metadata: 0x006A7A7D */, AxisConstraint lockRotation = AxisConstraint.None /* Metadata: 0x006A7A7E */); // 0x0000000180717AA0-0x0000000180717AD0
		public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(this TweenerCore<Vector3, Path, PathOptions> t, Vector3 lookAtPosition, Vector3? forwardDirection = default, Vector3? up = default); // 0x0000000180717600-0x0000000180717670
		public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(this TweenerCore<Vector3, Path, PathOptions> t, Vector3 lookAtPosition, bool stableZRotation); // 0x0000000180717700-0x0000000180717770
		public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(this TweenerCore<Vector3, Path, PathOptions> t, Transform lookAtTransform, Vector3? forwardDirection = default, Vector3? up = default); // 0x0000000180717540-0x0000000180717600
		public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(this TweenerCore<Vector3, Path, PathOptions> t, Transform lookAtTransform, bool stableZRotation); // 0x0000000180717770-0x0000000180717830
		public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(this TweenerCore<Vector3, Path, PathOptions> t, float lookAhead, Vector3? forwardDirection = default, Vector3? up = default); // 0x0000000180717670-0x0000000180717700
		public static TweenerCore<Vector3, Path, PathOptions> SetLookAt(this TweenerCore<Vector3, Path, PathOptions> t, float lookAhead, bool stableZRotation); // 0x00000001807174B0-0x0000000180717540
		private static TweenerCore<Vector3, Path, PathOptions> SetLookAt(this TweenerCore<Vector3, Path, PathOptions> t, OrientType orientType, Vector3 lookAtPosition, Transform lookAtTransform, float lookAhead, Vector3? forwardDirection = default, Vector3? up = default, bool stableZRotation = false /* Metadata: 0x006A7A7F */); // 0x0000000180717830-0x0000000180717900
		private static void SetPathForwardDirection(this TweenerCore<Vector3, Path, PathOptions> t, Vector3? forwardDirection = default, Vector3? up = default); // 0x0000000180717BB0-0x0000000180717E20
	}
}
