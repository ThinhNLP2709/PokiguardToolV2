namespace DG.Tweening.Plugins;

public class ColorPlugin : ABSTweenPlugin<Color, Color, ColorOptions>
{

	public ColorPlugin() { }

	public virtual Color ConvertToStartValue(TweenerCore<Color, Color, ColorOptions> t, Color value) { }

	public virtual void EvaluateAndApply(ColorOptions options, Tween t, bool isRelative, DOGetter<Color> getter, DOSetter<Color> setter, float elapsed, Color startValue, Color changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice) { }

	public virtual float GetSpeedBasedDuration(ColorOptions options, float unitsXSecond, Color changeValue) { }

	public virtual void Reset(TweenerCore<Color, Color, ColorOptions> t) { }

	public virtual void SetChangeValue(TweenerCore<Color, Color, ColorOptions> t) { }

	public virtual void SetFrom(TweenerCore<Color, Color, ColorOptions> t, bool isRelative) { }

	public virtual void SetFrom(TweenerCore<Color, Color, ColorOptions> t, Color fromValue, bool setImmediately, bool isRelative) { }

	public virtual void SetRelativeEndValue(TweenerCore<Color, Color, ColorOptions> t) { }

}

