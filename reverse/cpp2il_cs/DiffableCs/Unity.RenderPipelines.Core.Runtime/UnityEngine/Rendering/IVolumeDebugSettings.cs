namespace UnityEngine.Rendering;

public interface IVolumeDebugSettings
{

	public IEnumerable<Camera> cameras
	{
		 get { } //Length: 0
	}

	public Camera selectedCamera
	{
		 get { } //Length: 0
	}

	public int selectedCameraIndex
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public LayerMask selectedCameraLayerMask
	{
		 get { } //Length: 0
	}

	public Vector3 selectedCameraPosition
	{
		 get { } //Length: 0
	}

	public VolumeStack selectedCameraVolumeStack
	{
		 get { } //Length: 0
	}

	public int selectedComponent
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public Type selectedComponentType
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public IEnumerable<Camera> get_cameras() { }

	public Camera get_selectedCamera() { }

	public int get_selectedCameraIndex() { }

	public LayerMask get_selectedCameraLayerMask() { }

	public Vector3 get_selectedCameraPosition() { }

	public VolumeStack get_selectedCameraVolumeStack() { }

	public int get_selectedComponent() { }

	public Type get_selectedComponentType() { }

	public Volume[] GetVolumes() { }

	public float GetVolumeWeight(Volume volume) { }

	public bool RefreshVolumes(Volume[] newVolumes) { }

	public void set_selectedCameraIndex(int value) { }

	public void set_selectedComponent(int value) { }

	public void set_selectedComponentType(Type value) { }

	public bool VolumeHasInfluence(Volume volume) { }

}

