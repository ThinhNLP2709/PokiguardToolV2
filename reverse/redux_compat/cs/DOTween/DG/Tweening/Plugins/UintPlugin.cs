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
	public class UintPlugin : ABSTweenPlugin<uint, uint, UintOptions> // TypeDefIndex: 13465
	{
		// Constructors
		public UintPlugin(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void Reset(TweenerCore<uint, uint, UintOptions> t); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetFrom(TweenerCore<uint, uint, UintOptions> t, bool isRelative); // 0x000000018072C310-0x000000018072C390
		public override void SetFrom(TweenerCore<uint, uint, UintOptions> t, uint fromValue, bool setImmediately, bool isRelative); // 0x0000000180720F10-0x0000000180720FA0
		public override uint ConvertToStartValue(TweenerCore<uint, uint, UintOptions> t, uint value); // 0x0000000180720D20-0x0000000180720D30
		public override void SetRelativeEndValue(TweenerCore<uint, uint, UintOptions> t); // 0x0000000180721020-0x0000000180721050
		public override void SetChangeValue(TweenerCore<uint, uint, UintOptions> t); // 0x000000018072C2C0-0x000000018072C310
		public override float GetSpeedBasedDuration(UintOptions options, float unitsXSecond, uint changeValue); // 0x000000018072C290-0x000000018072C2C0
		public override void EvaluateAndApply(UintOptions options, Tween t, bool isRelative, DOGetter<uint> getter, DOSetter<uint> setter, float elapsed, uint startValue, uint changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice); // 0x000000018072C0D0-0x000000018072C290
	}
}
