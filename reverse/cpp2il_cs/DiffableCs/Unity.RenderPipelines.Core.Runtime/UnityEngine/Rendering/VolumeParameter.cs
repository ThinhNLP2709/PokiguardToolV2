namespace UnityEngine.Rendering;

public abstract class VolumeParameter : ICloneable
{
	public const string k_DebuggerDisplay = "{m_Value} ({m_OverrideState})"; //Field offset: 0x0
	[SerializeField]
	protected bool m_OverrideState; //Field offset: 0x10

	public override bool overrideState
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	protected VolumeParameter() { }

	public abstract object Clone() { }

	public override bool get_overrideState() { }

	public T GetValue() { }

	internal abstract void Interp(VolumeParameter from, VolumeParameter to, float t) { }

	public static bool IsObjectParameter(Type type) { }

	protected private override void OnDisable() { }

	protected private override void OnEnable() { }

	public override void Release() { }

	public override void set_overrideState(bool value) { }

	public abstract void SetValue(VolumeParameter parameter) { }

}

