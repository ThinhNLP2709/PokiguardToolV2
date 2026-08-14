namespace Unity.VisualScripting;

public abstract class Cloner : ICloner
{

	protected Cloner`1() { }

	public override void AfterClone(Type type, T clone) { }

	public override void BeforeClone(Type type, T original) { }

	public override T ConstructClone(Type type, T original) { }

	public override void FillClone(Type type, ref T clone, T original, CloningContext context) { }

	public abstract bool Handles(Type type) { }

	private override void Unity.VisualScripting.ICloner.AfterClone(Type type, object clone) { }

	private override void Unity.VisualScripting.ICloner.BeforeClone(Type type, object original) { }

	private override object Unity.VisualScripting.ICloner.ConstructClone(Type type, object original) { }

	private override void Unity.VisualScripting.ICloner.FillClone(Type type, ref object clone, object original, CloningContext context) { }

}

