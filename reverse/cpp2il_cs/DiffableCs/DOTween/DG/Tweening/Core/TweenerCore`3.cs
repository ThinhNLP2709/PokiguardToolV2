namespace DG.Tweening.Core;

public class TweenerCore : Tweener
{
	private const string _TxtCantChangeSequencedValues = "You cannot change the values of a tween contained inside a Sequence"; //Field offset: 0x0
	public T2 startValue; //Field offset: 0x0
	public T2 endValue; //Field offset: 0x0
	public T2 changeValue; //Field offset: 0x0
	public TPlugOptions plugOptions; //Field offset: 0x0
	public DOGetter<T1> getter; //Field offset: 0x0
	public DOSetter<T1> setter; //Field offset: 0x0
	internal ABSTweenPlugin<T1, T2, TPlugOptions> tweenPlugin; //Field offset: 0x0
	private Type _colorType; //Field offset: 0x0
	private Type _color32Type; //Field offset: 0x0

	internal TweenerCore`3() { }

	internal virtual bool ApplyTween(float prevPosition, int prevCompletedLoops, int newCompletedSteps, bool useInversePosition, UpdateMode updateMode, UpdateNotice updateNotice) { }

	public virtual Tweener ChangeEndValue(object newEndValue, bool snapStartValue) { }

	public virtual Tweener ChangeEndValue(object newEndValue, float newDuration = -1, bool snapStartValue = false) { }

	public TweenerCore<T1, T2, TPlugOptions> ChangeEndValue(T2 newEndValue, bool snapStartValue) { }

	public TweenerCore<T1, T2, TPlugOptions> ChangeEndValue(T2 newEndValue, float newDuration = -1, bool snapStartValue = false) { }

	public TweenerCore<T1, T2, TPlugOptions> ChangeStartValue(T2 newStartValue, float newDuration = -1) { }

	public virtual Tweener ChangeStartValue(object newStartValue, float newDuration = -1) { }

	public virtual Tweener ChangeValues(object newStartValue, object newEndValue, float newDuration = -1) { }

	public TweenerCore<T1, T2, TPlugOptions> ChangeValues(T2 newStartValue, T2 newEndValue, float newDuration = -1) { }

	internal virtual void Reset() { }

	internal virtual Tweener SetFrom(bool relative) { }

	internal Tweener SetFrom(T2 fromValue, bool setImmediately, bool relative) { }

	internal virtual bool Startup() { }

	internal virtual float UpdateDelay(float elapsed) { }

	internal virtual bool Validate() { }

	private bool ValidateChangeValueType(Type newType, out bool isColor32ToColor) { }

}

