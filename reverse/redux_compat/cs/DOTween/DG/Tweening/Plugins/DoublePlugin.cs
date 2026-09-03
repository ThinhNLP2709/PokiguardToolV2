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

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening.Plugins
{
	public class DoublePlugin : ABSTweenPlugin<double, double, NoOptions> // TypeDefIndex: 13455
	{
		// Constructors
		public DoublePlugin(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void Reset(TweenerCore<double, double, NoOptions> t); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetFrom(TweenerCore<double, double, NoOptions> t, bool isRelative); // 0x00000001807207A0-0x0000000180720830
		public override void SetFrom(TweenerCore<double, double, NoOptions> t, double fromValue, bool setImmediately, bool isRelative); // 0x0000000180720830-0x00000001807208D0
		public override double ConvertToStartValue(TweenerCore<double, double, NoOptions> t, double value); // 0x00000001807205E0-0x00000001807205F0
		public override void SetRelativeEndValue(TweenerCore<double, double, NoOptions> t); // 0x00000001807208D0-0x0000000180720900
		public override void SetChangeValue(TweenerCore<double, double, NoOptions> t); // 0x0000000180720770-0x00000001807207A0
		public override float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, double changeValue); // 0x0000000180720750-0x0000000180720770
		public override void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<double> getter, DOSetter<double> setter, float elapsed, double startValue, double changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice); // 0x00000001807205F0-0x0000000180720750
	}
}
