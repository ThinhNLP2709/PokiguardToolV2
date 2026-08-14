namespace UnityEngine.Rendering;

public class CameraSwitcher : MonoBehaviour
{
	public Camera[] m_Cameras; //Field offset: 0x20
	private int m_CurrentCameraIndex; //Field offset: 0x28
	private Camera m_OriginalCamera; //Field offset: 0x30
	private Vector3 m_OriginalCameraPosition; //Field offset: 0x38
	private Quaternion m_OriginalCameraRotation; //Field offset: 0x44
	private Camera m_CurrentCamera; //Field offset: 0x58
	private GUIContent[] m_CameraNames; //Field offset: 0x60
	private Int32[] m_CameraIndices; //Field offset: 0x68
	private EnumField m_DebugEntry; //Field offset: 0x70
	private int m_DebugEntryEnumIndex; //Field offset: 0x78

	public CameraSwitcher() { }

	[CompilerGenerated]
	private int <OnEnable>b__10_0() { }

	[CompilerGenerated]
	private void <OnEnable>b__10_1(int value) { }

	[CompilerGenerated]
	private int <OnEnable>b__10_2() { }

	[CompilerGenerated]
	private void <OnEnable>b__10_3(int value) { }

	private int GetCameraCount() { }

	private Camera GetNextCamera() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void SetCameraIndex(int index) { }

}

