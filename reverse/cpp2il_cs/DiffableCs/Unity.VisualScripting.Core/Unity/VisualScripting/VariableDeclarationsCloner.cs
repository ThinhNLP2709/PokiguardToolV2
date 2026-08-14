namespace Unity.VisualScripting;

public sealed class VariableDeclarationsCloner : Cloner<VariableDeclarations>
{
	public static readonly VariableDeclarationsCloner instance; //Field offset: 0x0

	private static VariableDeclarationsCloner() { }

	public VariableDeclarationsCloner() { }

	public virtual VariableDeclarations ConstructClone(Type type, VariableDeclarations original) { }

	public virtual void FillClone(Type type, ref VariableDeclarations clone, VariableDeclarations original, CloningContext context) { }

	public virtual bool Handles(Type type) { }

}

