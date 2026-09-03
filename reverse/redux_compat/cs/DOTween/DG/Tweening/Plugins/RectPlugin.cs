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
using DG.Tweening.Plugins.Options;
using UnityEngine;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening.Plugins
{
	public class RectPlugin : ABSTweenPlugin<Rect, Rect, RectOptions> // TypeDefIndex: 13464
	{
		// Constructors
		public RectPlugin(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void Reset(TweenerCore<Rect, Rect, RectOptions> t); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetFrom(TweenerCore<Rect, Rect, RectOptions> t, bool isRelative); // 0x00000001807296B0-0x00000001807298E0
		public override void SetFrom(TweenerCore<Rect, Rect, RectOptions> t, Rect fromValue, bool setImmediately, bool isRelative); // 0x00000001807298E0-0x0000000180729B50
		public override Rect ConvertToStartValue(TweenerCore<Rect, Rect, RectOptions> t, Rect value); // 0x000000018071CA60-0x000000018071CA70
		public override void SetRelativeEndValue(TweenerCore<Rect, Rect, RectOptions> t); // 0x0000000180729B50-0x0000000180729C00
		public override void SetChangeValue(TweenerCore<Rect, Rect, RectOptions> t); // 0x0000000180729600-0x00000001807296B0
		public override float GetSpeedBasedDuration(RectOptions options, float unitsXSecond, Rect changeValue); // 0x0000000180729550-0x0000000180729600
		public override void EvaluateAndApply(RectOptions options, Tween t, bool isRelative, DOGetter<Rect> getter, DOSetter<Rect> setter, float elapsed, Rect startValue, Rect changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice); // 0x0000000180729190-0x0000000180729550
	}
}
