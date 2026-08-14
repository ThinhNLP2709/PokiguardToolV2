namespace Unity.VisualScripting;

public interface ICloner
{

	public void AfterClone(Type type, object clone) { }

	public void BeforeClone(Type type, object original) { }

	public object ConstructClone(Type type, object original) { }

	public void FillClone(Type type, ref object clone, object original, CloningContext context) { }

	public bool Handles(Type type) { }

}

