namespace Unity.VisualScripting;

[AddComponentMenu(null)]
[DisableAnnotation]
[IncludeInSettings(False)]
public abstract class MessageListener : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Type, Boolean> <>9__2_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <get_listenerTypes>b__2_0(Type t) { }

	}

	private static Type[] _listenerTypes; //Field offset: 0x0

	[Obsolete("listenerTypes is deprecated", False)]
	public static Type[] listenerTypes
	{
		 get { } //Length: 494
	}

	protected MessageListener() { }

	[Obsolete("Use the overload with a messageListenerType parameter instead", False)]
	public static void AddTo(GameObject gameObject) { }

	public static void AddTo(Type messageListenerType, GameObject gameObject) { }

	public static Type[] get_listenerTypes() { }

}

