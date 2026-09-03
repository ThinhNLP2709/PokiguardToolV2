/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening.Plugins
{
	public class StringPlugin : ABSTweenPlugin<string, string, StringOptions> // TypeDefIndex: 13468
	{
		// Fields
		private static readonly StringBuilder _Buffer; // 0x00
		private static readonly List<char> _OpenedTags; // 0x08
	
		// Constructors
		public StringPlugin(); // 0x00000001802F4070-0x00000001802F4080
		static StringPlugin(); // 0x000000018072BD40-0x000000018072BE10
	
		// Methods
		public override void SetFrom(TweenerCore<string, string, StringOptions> t, bool isRelative); // 0x000000018072BCA0-0x000000018072BD40
		public override void SetFrom(TweenerCore<string, string, StringOptions> t, string fromValue, bool setImmediately, bool isRelative); // 0x000000018072BBD0-0x000000018072BCA0
		public override void Reset(TweenerCore<string, string, StringOptions> t); // 0x000000018072B7A0-0x000000018072B830
		public override string ConvertToStartValue(TweenerCore<string, string, StringOptions> t, string value); // 0x0000000180700320-0x0000000180700330
		public override void SetRelativeEndValue(TweenerCore<string, string, StringOptions> t); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetChangeValue(TweenerCore<string, string, StringOptions> t); // 0x000000018072B940-0x000000018072BBD0
		public override float GetSpeedBasedDuration(StringOptions options, float unitsXSecond, string changeValue); // 0x000000018072B740-0x000000018072B7A0
		public override void EvaluateAndApply(StringOptions options, Tween t, bool isRelative, DOGetter<string> getter, DOSetter<string> setter, float elapsed, string startValue, string changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice); // 0x000000018072B030-0x000000018072B740
		private StringBuilder Append(string value, int startIndex, int length, bool richTextEnabled); // 0x000000018072A9C0-0x000000018072B030
		private char[] ScrambledCharsToUse(StringOptions options); // 0x000000018072B830-0x000000018072B940
	}
}
