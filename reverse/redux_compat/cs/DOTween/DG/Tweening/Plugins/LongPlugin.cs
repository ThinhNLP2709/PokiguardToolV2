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
	public class LongPlugin : ABSTweenPlugin<long, long, NoOptions> // TypeDefIndex: 13456
	{
		// Constructors
		public LongPlugin(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void Reset(TweenerCore<long, long, NoOptions> t); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetFrom(TweenerCore<long, long, NoOptions> t, bool isRelative); // 0x0000000180721790-0x0000000180721820
		public override void SetFrom(TweenerCore<long, long, NoOptions> t, long fromValue, bool setImmediately, bool isRelative); // 0x0000000180721820-0x00000001807218B0
		public override long ConvertToStartValue(TweenerCore<long, long, NoOptions> t, long value); // 0x0000000180700320-0x0000000180700330
		public override void SetRelativeEndValue(TweenerCore<long, long, NoOptions> t); // 0x00000001807218B0-0x00000001807218E0
		public override void SetChangeValue(TweenerCore<long, long, NoOptions> t); // 0x0000000180721760-0x0000000180721790
		public override float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, long changeValue); // 0x0000000180721740-0x0000000180721760
		public override void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<long> getter, DOSetter<long> setter, float elapsed, long startValue, long changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice); // 0x00000001807215A0-0x0000000180721740
	}
}
