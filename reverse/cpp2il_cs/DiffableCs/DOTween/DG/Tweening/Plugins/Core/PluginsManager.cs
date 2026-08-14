namespace DG.Tweening.Plugins.Core;

internal static class PluginsManager
{
	private static ITweenPlugin _floatPlugin; //Field offset: 0x0
	private const int _MaxCustomPlugins = 20; //Field offset: 0x0
	private static ITweenPlugin _doublePlugin; //Field offset: 0x8
	private static ITweenPlugin _intPlugin; //Field offset: 0x10
	private static ITweenPlugin _uintPlugin; //Field offset: 0x18
	private static ITweenPlugin _longPlugin; //Field offset: 0x20
	private static ITweenPlugin _ulongPlugin; //Field offset: 0x28
	private static ITweenPlugin _vector2Plugin; //Field offset: 0x30
	private static ITweenPlugin _vector3Plugin; //Field offset: 0x38
	private static ITweenPlugin _vector4Plugin; //Field offset: 0x40
	private static ITweenPlugin _quaternionPlugin; //Field offset: 0x48
	private static ITweenPlugin _colorPlugin; //Field offset: 0x50
	private static ITweenPlugin _rectPlugin; //Field offset: 0x58
	private static ITweenPlugin _rectOffsetPlugin; //Field offset: 0x60
	private static ITweenPlugin _stringPlugin; //Field offset: 0x68
	private static ITweenPlugin _vector3ArrayPlugin; //Field offset: 0x70
	private static ITweenPlugin _color2Plugin; //Field offset: 0x78
	private static Dictionary<Type, ITweenPlugin> _customPlugins; //Field offset: 0x80

	public static ABSTweenPlugin<T1, T2, TPlugOptions> GetCustomPlugin() { }

	internal static ABSTweenPlugin<T1, T2, TPlugOptions> GetDefaultPlugin() { }

	internal static void PurgeAll() { }

}

