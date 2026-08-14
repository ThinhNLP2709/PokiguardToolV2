namespace Unity.VisualScripting;

internal sealed class GradientCloner : Cloner<Gradient>
{

	public GradientCloner() { }

	public virtual Gradient ConstructClone(Type type, Gradient original) { }

	public virtual void FillClone(Type type, ref Gradient clone, Gradient original, CloningContext context) { }

	public virtual bool Handles(Type type) { }

}

