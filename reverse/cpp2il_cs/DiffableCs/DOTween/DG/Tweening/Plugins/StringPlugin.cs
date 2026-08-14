namespace DG.Tweening.Plugins;

public class StringPlugin : ABSTweenPlugin<String, String, StringOptions>
{
	private static readonly StringBuilder _Buffer; //Field offset: 0x0
	private static readonly List<Char> _OpenedTags; //Field offset: 0x8

	private static StringPlugin() { }

	public StringPlugin() { }

	private StringBuilder Append(string value, int startIndex, int length, bool richTextEnabled) { }

	public virtual string ConvertToStartValue(TweenerCore<String, String, StringOptions> t, string value) { }

	public virtual void EvaluateAndApply(StringOptions options, Tween t, bool isRelative, DOGetter<String> getter, DOSetter<String> setter, float elapsed, string startValue, string changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice) { }

	public virtual float GetSpeedBasedDuration(StringOptions options, float unitsXSecond, string changeValue) { }

	public virtual void Reset(TweenerCore<String, String, StringOptions> t) { }

	private Char[] ScrambledCharsToUse(StringOptions options) { }

	public virtual void SetChangeValue(TweenerCore<String, String, StringOptions> t) { }

	public virtual void SetFrom(TweenerCore<String, String, StringOptions> t, bool isRelative) { }

	public virtual void SetFrom(TweenerCore<String, String, StringOptions> t, string fromValue, bool setImmediately, bool isRelative) { }

	public virtual void SetRelativeEndValue(TweenerCore<String, String, StringOptions> t) { }

}

