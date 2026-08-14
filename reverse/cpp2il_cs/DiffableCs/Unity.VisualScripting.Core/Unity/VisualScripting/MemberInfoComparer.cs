namespace Unity.VisualScripting;

public class MemberInfoComparer : EqualityComparer<MemberInfo>
{

	public MemberInfoComparer() { }

	public virtual bool Equals(MemberInfo x, MemberInfo y) { }

	public virtual int GetHashCode(MemberInfo obj) { }

}

