namespace UnityEngine.Rendering;

public abstract class DebugDisplaySettings : IDebugDisplaySettings
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<T> <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal T <.cctor>b__17_0() { }

	}

	private class IDebugDisplaySettingsDataComparer : IEqualityComparer<IDebugDisplaySettingsData>
	{

		public IDebugDisplaySettingsDataComparer() { }

		public override bool Equals(IDebugDisplaySettingsData x, IDebugDisplaySettingsData y) { }

		public override int GetHashCode(IDebugDisplaySettingsData obj) { }

	}

	private static readonly Lazy<T> s_Instance; //Field offset: 0x0
	protected readonly HashSet<IDebugDisplaySettingsData> m_Settings; //Field offset: 0x0

	public override bool AreAnySettingsActive
	{
		 get { } //Length: 301
	}

	public static T Instance
	{
		 get { } //Length: 198
	}

	public override bool IsLightingActive
	{
		 get { } //Length: 447
	}

	public override bool IsPostProcessingAllowed
	{
		 get { } //Length: 446
	}

	private static DebugDisplaySettings`1() { }

	protected DebugDisplaySettings`1() { }

	protected TData Add(TData newData) { }

	public override void ForEach(Action<IDebugDisplaySettingsData> onExecute) { }

	public override bool get_AreAnySettingsActive() { }

	public static T get_Instance() { }

	public override bool get_IsLightingActive() { }

	public override bool get_IsPostProcessingAllowed() { }

	public override void Reset() { }

	public override bool TryGetScreenClearColor(ref Color color) { }

	private override IDebugDisplaySettingsData UnityEngine.Rendering.IDebugDisplaySettings.Add(IDebugDisplaySettingsData newData) { }

}

