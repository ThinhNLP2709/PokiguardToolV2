namespace Unity.VisualScripting;

public struct LooseAssemblyName
{
	public readonly string name; //Field offset: 0x0

	public LooseAssemblyName(string name) { }

	public virtual bool Equals(object obj) { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(LooseAssemblyName a, LooseAssemblyName b) { }

	public static LooseAssemblyName op_Explicit(AssemblyName strongAssemblyName) { }

	public static LooseAssemblyName op_Implicit(string name) { }

	public static string op_Implicit(LooseAssemblyName name) { }

	public static bool op_Inequality(LooseAssemblyName a, LooseAssemblyName b) { }

	public virtual string ToString() { }

}

