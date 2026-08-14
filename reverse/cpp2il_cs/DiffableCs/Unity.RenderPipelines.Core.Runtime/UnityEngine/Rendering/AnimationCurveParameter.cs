namespace UnityEngine.Rendering;

public class AnimationCurveParameter : VolumeParameter<AnimationCurve>
{

	public AnimationCurveParameter(AnimationCurve value, bool overrideState = false) { }

	public virtual object Clone() { }

	public virtual int GetHashCode() { }

	public virtual void Interp(AnimationCurve lhsCurve, AnimationCurve rhsCurve, float t) { }

	public virtual void SetValue(VolumeParameter parameter) { }

}

