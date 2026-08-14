namespace UnityEngine.InputForUI;

internal struct EventSanitizer
{
	private interface IEventSanitizer
	{

		public void AfterProviderUpdate() { }

		public void BeforeProviderUpdate() { }

		public void Inspect(in Event ev) { }

		public void Reset() { }

	}

	private IEventSanitizer[] _sanitizers; //Field offset: 0x0

	public void AfterProviderUpdate() { }

	public void BeforeProviderUpdate() { }

	public void Inspect(in Event ev) { }

	public void Reset() { }

}

