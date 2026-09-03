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
	public class RectOffsetPlugin : ABSTweenPlugin<RectOffset, RectOffset, NoOptions> // TypeDefIndex: 13463
	{
		// Fields
		private static RectOffset _r; // 0x00
	
		// Constructors
		public RectOffsetPlugin(); // 0x00000001802F4070-0x00000001802F4080
		static RectOffsetPlugin(); // 0x0000000180729110-0x0000000180729190
	
		// Methods
		public override void Reset(TweenerCore<RectOffset, RectOffset, NoOptions> t); // 0x00000001807289E0-0x0000000180728A50
		public override void SetFrom(TweenerCore<RectOffset, RectOffset, NoOptions> t, bool isRelative); // 0x0000000180728C00-0x0000000180728DB0
		public override void SetFrom(TweenerCore<RectOffset, RectOffset, NoOptions> t, RectOffset fromValue, bool setImmediately, bool isRelative); // 0x0000000180728DB0-0x0000000180728FE0
		public override RectOffset ConvertToStartValue(TweenerCore<RectOffset, RectOffset, NoOptions> t, RectOffset value); // 0x0000000180728200-0x00000001807282D0
		public override void SetRelativeEndValue(TweenerCore<RectOffset, RectOffset, NoOptions> t); // 0x0000000180728FE0-0x0000000180729110
		public override void SetChangeValue(TweenerCore<RectOffset, RectOffset, NoOptions> t); // 0x0000000180728A50-0x0000000180728C00
		public override float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, RectOffset changeValue); // 0x00000001807288F0-0x00000001807289E0
		public override void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<RectOffset> getter, DOSetter<RectOffset> setter, float elapsed, RectOffset startValue, RectOffset changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice); // 0x00000001807282D0-0x00000001807288F0
	}
}
