namespace UnityEngine.Accessibility;

internal class ServiceManager
{
	private readonly IDictionary<Type, IService> m_Services; //Field offset: 0x10

	public ServiceManager() { }

	public T GetService() { }

	protected void ScreenReaderStatusChanged(bool isScreenReaderEnabled) { }

	private void StopService() { }

	private void UpdateServices(bool isScreenReaderEnabled) { }

}

