namespace Unity.VisualScripting;

public sealed class AnimationCurveCloner : Cloner<AnimationCurve>
{

	public AnimationCurveCloner() { }

	public virtual AnimationCurve ConstructClone(Type type, AnimationCurve original) { }

	public virtual void FillClone(Type type, ref AnimationCurve clone, AnimationCurve original, CloningContext context) { }

	public virtual bool Handles(Type type) { }

}

