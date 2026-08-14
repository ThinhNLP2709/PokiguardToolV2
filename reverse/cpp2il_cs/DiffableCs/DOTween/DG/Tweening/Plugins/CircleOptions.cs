namespace DG.Tweening.Plugins;

public struct CircleOptions : IPlugOptions
{
	public float endValueDegrees; //Field offset: 0x0
	public bool relativeCenter; //Field offset: 0x4
	public bool snapping; //Field offset: 0x5
	internal Vector2 center; //Field offset: 0x8
	internal float radius; //Field offset: 0x10
	internal float startValueDegrees; //Field offset: 0x14
	internal bool initialized; //Field offset: 0x18

	public void Initialize(Vector2 startValue, Vector2 endValue) { }

	public override void Reset() { }

}

