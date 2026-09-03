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
	public class UlongPlugin : ABSTweenPlugin<ulong, ulong, NoOptions> // TypeDefIndex: 13457
	{
		// Constructors
		public UlongPlugin(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void Reset(TweenerCore<ulong, ulong, NoOptions> t); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetFrom(TweenerCore<ulong, ulong, NoOptions> t, bool isRelative); // 0x000000018072C5F0-0x000000018072C680
		public override void SetFrom(TweenerCore<ulong, ulong, NoOptions> t, ulong fromValue, bool setImmediately, bool isRelative); // 0x0000000180721820-0x00000001807218B0
		public override ulong ConvertToStartValue(TweenerCore<ulong, ulong, NoOptions> t, ulong value); // 0x0000000180700320-0x0000000180700330
		public override void SetRelativeEndValue(TweenerCore<ulong, ulong, NoOptions> t); // 0x00000001807218B0-0x00000001807218E0
		public override void SetChangeValue(TweenerCore<ulong, ulong, NoOptions> t); // 0x0000000180721760-0x0000000180721790
		public override float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, ulong changeValue); // 0x000000018072C5B0-0x000000018072C5F0
		public override void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<ulong> getter, DOSetter<ulong> setter, float elapsed, ulong startValue, ulong changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice); // 0x000000018072C390-0x000000018072C5B0
	}
}
