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
	public class IntPlugin : ABSTweenPlugin<int, int, NoOptions> // TypeDefIndex: 13461
	{
		// Constructors
		public IntPlugin(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void Reset(TweenerCore<int, int, NoOptions> t); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetFrom(TweenerCore<int, int, NoOptions> t, bool isRelative); // 0x0000000180720FA0-0x0000000180721020
		public override void SetFrom(TweenerCore<int, int, NoOptions> t, int fromValue, bool setImmediately, bool isRelative); // 0x0000000180720F10-0x0000000180720FA0
		public override int ConvertToStartValue(TweenerCore<int, int, NoOptions> t, int value); // 0x0000000180720D20-0x0000000180720D30
		public override void SetRelativeEndValue(TweenerCore<int, int, NoOptions> t); // 0x0000000180721020-0x0000000180721050
		public override void SetChangeValue(TweenerCore<int, int, NoOptions> t); // 0x0000000180720EE0-0x0000000180720F10
		public override float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, int changeValue); // 0x0000000180720EC0-0x0000000180720EE0
		public override void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<int> getter, DOSetter<int> setter, float elapsed, int startValue, int changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice); // 0x0000000180720D30-0x0000000180720EC0
	}
}
