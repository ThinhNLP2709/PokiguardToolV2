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
	public class ColorPlugin : ABSTweenPlugin<Color, Color, ColorOptions> // TypeDefIndex: 13460
	{
		// Constructors
		public ColorPlugin(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void Reset(TweenerCore<Color, Color, ColorOptions> t); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetFrom(TweenerCore<Color, Color, ColorOptions> t, bool isRelative); // 0x000000018071CE20-0x000000018071CF80
		public override void SetFrom(TweenerCore<Color, Color, ColorOptions> t, Color fromValue, bool setImmediately, bool isRelative); // 0x000000018071CF80-0x000000018071D190
		public override Color ConvertToStartValue(TweenerCore<Color, Color, ColorOptions> t, Color value); // 0x000000018071CA60-0x000000018071CA70
		public override void SetRelativeEndValue(TweenerCore<Color, Color, ColorOptions> t); // 0x000000018071D190-0x000000018071D210
		public override void SetChangeValue(TweenerCore<Color, Color, ColorOptions> t); // 0x000000018071CDA0-0x000000018071CE20
		public override float GetSpeedBasedDuration(ColorOptions options, float unitsXSecond, Color changeValue); // 0x000000018071C500-0x000000018071C510
		public override void EvaluateAndApply(ColorOptions options, Tween t, bool isRelative, DOGetter<Color> getter, DOSetter<Color> setter, float elapsed, Color startValue, Color changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice); // 0x000000018071CA70-0x000000018071CDA0
	}
}
