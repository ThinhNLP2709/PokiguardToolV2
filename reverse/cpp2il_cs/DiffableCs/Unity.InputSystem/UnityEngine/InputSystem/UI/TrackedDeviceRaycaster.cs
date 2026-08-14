namespace UnityEngine.InputSystem.UI;

[AddComponentMenu("Event/Tracked Device Raycaster")]
[HelpURL("https://docs.unity3d.com/Packages/com.unity.inputsystem@1.17/manual/TrackedInputDevices.html#tracked-device-raycaster")]
[RequireComponent(typeof(Canvas))]
public class TrackedDeviceRaycaster : BaseRaycaster
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Comparison<RaycastHitData> <>9__25_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal int <SortedRaycastGraphics>b__25_0(RaycastHitData g1, RaycastHitData g2) { }

	}

	private struct RaycastHitData
	{
		[CompilerGenerated]
		private readonly Graphic <graphic>k__BackingField; //Field offset: 0x0
		[CompilerGenerated]
		private readonly Vector3 <worldHitPosition>k__BackingField; //Field offset: 0x8
		[CompilerGenerated]
		private readonly Vector2 <screenPosition>k__BackingField; //Field offset: 0x14
		[CompilerGenerated]
		private readonly float <distance>k__BackingField; //Field offset: 0x1C

		public float distance
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 6
		}

		public Graphic graphic
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 4
		}

		public Vector2 screenPosition
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 19
		}

		public Vector3 worldHitPosition
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 19
		}

		public RaycastHitData(Graphic graphic, Vector3 worldHitPosition, Vector2 screenPosition, float distance) { }

		[CompilerGenerated]
		[IsReadOnly]
		public float get_distance() { }

		[CompilerGenerated]
		[IsReadOnly]
		public Graphic get_graphic() { }

		[CompilerGenerated]
		[IsReadOnly]
		public Vector2 get_screenPosition() { }

		[CompilerGenerated]
		[IsReadOnly]
		public Vector3 get_worldHitPosition() { }

	}

	internal static InlinedArray<TrackedDeviceRaycaster> s_Instances; //Field offset: 0x0
	private static readonly List<RaycastHitData> s_SortedGraphics; //Field offset: 0x18
	private List<RaycastHitData> m_RaycastResultsCache; //Field offset: 0x28
	[FormerlySerializedAs("ignoreReversedGraphics")]
	[SerializeField]
	private bool m_IgnoreReversedGraphics; //Field offset: 0x30
	[FormerlySerializedAs("checkFor2DOcclusion")]
	[SerializeField]
	private bool m_CheckFor2DOcclusion; //Field offset: 0x31
	[FormerlySerializedAs("checkFor3DOcclusion")]
	[SerializeField]
	private bool m_CheckFor3DOcclusion; //Field offset: 0x32
	[SerializeField]
	[Tooltip("Maximum distance (in 3D world space) that rays are traced to find a hit.")]
	private float m_MaxDistance; //Field offset: 0x34
	[SerializeField]
	private LayerMask m_BlockingMask; //Field offset: 0x38
	private Canvas m_Canvas; //Field offset: 0x40

	public LayerMask blockingMask
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	private Canvas canvas
	{
		private get { } //Length: 141
	}

	public bool checkFor2DOcclusion
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public bool checkFor3DOcclusion
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public virtual Camera eventCamera
	{
		 get { } //Length: 121
	}

	public bool ignoreReversedGraphics
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public float maxDistance
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	private static TrackedDeviceRaycaster() { }

	public TrackedDeviceRaycaster() { }

	public LayerMask get_blockingMask() { }

	private Canvas get_canvas() { }

	public bool get_checkFor2DOcclusion() { }

	public bool get_checkFor3DOcclusion() { }

	public virtual Camera get_eventCamera() { }

	public bool get_ignoreReversedGraphics() { }

	public float get_maxDistance() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	internal void PerformRaycast(ExtendedPointerEventData eventData, List<RaycastResult> resultAppendList) { }

	public virtual void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList) { }

	private static bool RayIntersectsRectTransform(RectTransform transform, Ray ray, out Vector3 worldPosition, out float distance) { }

	public void set_blockingMask(LayerMask value) { }

	public void set_checkFor2DOcclusion(bool value) { }

	public void set_checkFor3DOcclusion(bool value) { }

	public void set_ignoreReversedGraphics(bool value) { }

	public void set_maxDistance(float value) { }

	private void SortedRaycastGraphics(Canvas canvas, Ray ray, List<RaycastHitData> results) { }

}

