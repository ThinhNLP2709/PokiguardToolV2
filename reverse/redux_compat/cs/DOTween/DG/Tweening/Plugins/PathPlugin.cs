/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening.Plugins
{
	public class PathPlugin : ABSTweenPlugin<Vector3, Path, PathOptions> // TypeDefIndex: 13459
	{
		// Fields
		public const float MinLookAhead = 0.0001f; // Metadata: 0x006A7A97
	
		// Constructors
		public PathPlugin(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void Reset(TweenerCore<Vector3, Path, PathOptions> t); // 0x0000000180721F30-0x0000000180721FB0
		public override void SetFrom(TweenerCore<Vector3, Path, PathOptions> t, bool isRelative); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetFrom(TweenerCore<Vector3, Path, PathOptions> t, Path fromValue, bool setImmediately, bool isRelative); // 0x00000001802E76C0-0x00000001802E76D0
		public static ABSTweenPlugin<Vector3, Path, PathOptions> Get(); // 0x0000000180721EC0-0x0000000180721EF0
		public override Path ConvertToStartValue(TweenerCore<Vector3, Path, PathOptions> t, Vector3 value); // 0x0000000180721990-0x00000001807219B0
		public override void SetRelativeEndValue(TweenerCore<Vector3, Path, PathOptions> t); // 0x00000001807239E0-0x0000000180723B10
		public override void SetChangeValue(TweenerCore<Vector3, Path, PathOptions> t); // 0x0000000180721FB0-0x0000000180722670
		public override float GetSpeedBasedDuration(PathOptions options, float unitsXSecond, Path changeValue); // 0x0000000180721EA0-0x0000000180721EC0
		public override void EvaluateAndApply(PathOptions options, Tween t, bool isRelative, DOGetter<Vector3> getter, DOSetter<Vector3> setter, float elapsed, Path startValue, Path changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice); // 0x00000001807219F0-0x0000000180721EA0
		public void SetOrientation(PathOptions options, Tween t, Path path, float pathPerc, Vector3 tPos, UpdateNotice updateNotice); // 0x0000000180722670-0x00000001807239E0
		private Vector3 DivideVectorByVector(Vector3 vector, Vector3 byVector); // 0x00000001807219B0-0x00000001807219F0
		private Vector3 MultiplyVectorByVector(Vector3 vector, Vector3 byVector); // 0x0000000180721EF0-0x0000000180721F30
	}
}
