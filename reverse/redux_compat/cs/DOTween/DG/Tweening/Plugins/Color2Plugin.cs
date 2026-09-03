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
	internal class Color2Plugin : ABSTweenPlugin<Color2, Color2, ColorOptions> // TypeDefIndex: 13454
	{
		// Constructors
		public Color2Plugin(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void Reset(TweenerCore<Color2, Color2, ColorOptions> t); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetFrom(TweenerCore<Color2, Color2, ColorOptions> t, bool isRelative); // 0x000000018071C750-0x000000018071C9D0
		public override void SetFrom(TweenerCore<Color2, Color2, ColorOptions> t, Color2 fromValue, bool setImmediately, bool isRelative); // 0x000000018071C590-0x000000018071C750
		public override Color2 ConvertToStartValue(TweenerCore<Color2, Color2, ColorOptions> t, Color2 value); // 0x000000018071C180-0x000000018071C1A0
		public override void SetRelativeEndValue(TweenerCore<Color2, Color2, ColorOptions> t); // 0x000000018071C9D0-0x000000018071CA50
		public override void SetChangeValue(TweenerCore<Color2, Color2, ColorOptions> t); // 0x000000018071C510-0x000000018071C590
		public override float GetSpeedBasedDuration(ColorOptions options, float unitsXSecond, Color2 changeValue); // 0x000000018071C500-0x000000018071C510
		public override void EvaluateAndApply(ColorOptions options, Tween t, bool isRelative, DOGetter<Color2> getter, DOSetter<Color2> setter, float elapsed, Color2 startValue, Color2 changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice); // 0x000000018071C1A0-0x000000018071C500
	}
}
