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
	public class FloatPlugin : ABSTweenPlugin<float, float, FloatOptions> // TypeDefIndex: 13470
	{
		// Constructors
		public FloatPlugin(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void Reset(TweenerCore<float, float, FloatOptions> t); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetFrom(TweenerCore<float, float, FloatOptions> t, bool isRelative); // 0x0000000180720B00-0x0000000180720BF0
		public override void SetFrom(TweenerCore<float, float, FloatOptions> t, float fromValue, bool setImmediately, bool isRelative); // 0x0000000180720BF0-0x0000000180720CF0
		public override float ConvertToStartValue(TweenerCore<float, float, FloatOptions> t, float value); // 0x00000001807205E0-0x00000001807205F0
		public override void SetRelativeEndValue(TweenerCore<float, float, FloatOptions> t); // 0x0000000180720CF0-0x0000000180720D20
		public override void SetChangeValue(TweenerCore<float, float, FloatOptions> t); // 0x0000000180720AD0-0x0000000180720B00
		public override float GetSpeedBasedDuration(FloatOptions options, float unitsXSecond, float changeValue); // 0x0000000180720AB0-0x0000000180720AD0
		public override void EvaluateAndApply(FloatOptions options, Tween t, bool isRelative, DOGetter<float> getter, DOSetter<float> setter, float elapsed, float startValue, float changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice); // 0x0000000180720900-0x0000000180720AB0
	}
}
