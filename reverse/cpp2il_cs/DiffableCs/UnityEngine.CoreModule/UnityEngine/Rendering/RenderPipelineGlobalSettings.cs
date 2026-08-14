namespace UnityEngine.Rendering;

public abstract class RenderPipelineGlobalSettings : ScriptableObject, ISerializationCallbackReceiver
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly Dictionary<Type, Int32> <settingsMap>k__BackingField; //Field offset: 0x18

	protected override List<IRenderPipelineGraphicsSettings> settingsList
	{
		 get { } //Length: 607
	}

	private Dictionary<Type, Int32> settingsMap
	{
		[CompilerGenerated]
		private get { } //Length: 5
	}

	protected RenderPipelineGlobalSettings() { }

	protected private bool Contains(Type type) { }

	protected override List<IRenderPipelineGraphicsSettings> get_settingsList() { }

	[CompilerGenerated]
	private Dictionary<Type, Int32> get_settingsMap() { }

	protected private bool GetSettingsImplementingInterface(out List<TSettingsInterfaceType>& settings) { }

	public override void OnAfterDeserialize() { }

	public override void OnBeforeSerialize() { }

	private void RecreateSettingsMap() { }

	protected private bool TryGet(Type type, out IRenderPipelineGraphicsSettings settings) { }

	protected private bool TryGetFirstSettingsImplementingInterface(out TSettingsInterfaceType settings) { }

}

