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

namespace DG.Tweening.CustomPlugins
{
	public class PureQuaternionPlugin : ABSTweenPlugin<Quaternion, Quaternion, NoOptions> // TypeDefIndex: 13496
	{
		// Fields
		private static PureQuaternionPlugin _plug; // 0x00
	
		// Constructors
		public PureQuaternionPlugin(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public static PureQuaternionPlugin Plug(); // 0x0000000180725E30-0x0000000180725EC0
		public override void Reset(TweenerCore<Quaternion, Quaternion, NoOptions> t); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetFrom(TweenerCore<Quaternion, Quaternion, NoOptions> t, bool isRelative); // 0x0000000180726230-0x0000000180726450
		public override void SetFrom(TweenerCore<Quaternion, Quaternion, NoOptions> t, Quaternion fromValue, bool setImmediately, bool isRelative); // 0x0000000180725EF0-0x0000000180726230
		public override Quaternion ConvertToStartValue(TweenerCore<Quaternion, Quaternion, NoOptions> t, Quaternion value); // 0x000000018071CA60-0x000000018071CA70
		public override void SetRelativeEndValue(TweenerCore<Quaternion, Quaternion, NoOptions> t); // 0x0000000180726450-0x00000001807265D0
		public override void SetChangeValue(TweenerCore<Quaternion, Quaternion, NoOptions> t); // 0x0000000180725EC0-0x0000000180725EF0
		public override float GetSpeedBasedDuration(NoOptions options, float unitsXSecond, Quaternion changeValue); // 0x0000000180725D20-0x0000000180725E30
		public override void EvaluateAndApply(NoOptions options, Tween t, bool isRelative, DOGetter<Quaternion> getter, DOSetter<Quaternion> setter, float elapsed, Quaternion startValue, Quaternion changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice); // 0x0000000180725C50-0x0000000180725D20
	}
}
