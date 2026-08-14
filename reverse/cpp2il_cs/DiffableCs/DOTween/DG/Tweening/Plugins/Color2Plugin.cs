namespace DG.Tweening.Plugins;

internal class Color2Plugin : ABSTweenPlugin<Color2, Color2, ColorOptions>
{

	public Color2Plugin() { }

	public virtual Color2 ConvertToStartValue(TweenerCore<Color2, Color2, ColorOptions> t, Color2 value) { }

	public virtual void EvaluateAndApply(ColorOptions options, Tween t, bool isRelative, DOGetter<Color2> getter, DOSetter<Color2> setter, float elapsed, Color2 startValue, Color2 changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice) { }

	public virtual float GetSpeedBasedDuration(ColorOptions options, float unitsXSecond, Color2 changeValue) { }

	public virtual void Reset(TweenerCore<Color2, Color2, ColorOptions> t) { }

	public virtual void SetChangeValue(TweenerCore<Color2, Color2, ColorOptions> t) { }

	public virtual void SetFrom(TweenerCore<Color2, Color2, ColorOptions> t, bool isRelative) { }

	public virtual void SetFrom(TweenerCore<Color2, Color2, ColorOptions> t, Color2 fromValue, bool setImmediately, bool isRelative) { }

	public virtual void SetRelativeEndValue(TweenerCore<Color2, Color2, ColorOptions> t) { }

}

