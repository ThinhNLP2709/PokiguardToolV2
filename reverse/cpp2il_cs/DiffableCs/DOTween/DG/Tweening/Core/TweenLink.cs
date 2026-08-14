namespace DG.Tweening.Core;

internal class TweenLink
{
	public readonly GameObject target; //Field offset: 0x10
	public readonly LinkBehaviour behaviour; //Field offset: 0x18
	public bool lastSeenActive; //Field offset: 0x1C

	public TweenLink(GameObject target, LinkBehaviour behaviour) { }

}

