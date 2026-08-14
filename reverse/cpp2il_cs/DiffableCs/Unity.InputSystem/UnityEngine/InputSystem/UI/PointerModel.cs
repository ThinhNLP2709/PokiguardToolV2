namespace UnityEngine.InputSystem.UI;

internal struct PointerModel
{
	internal struct ButtonState
	{
		private bool m_IsPressed; //Field offset: 0x0
		private FramePressState m_FramePressState; //Field offset: 0x4
		private float m_PressTime; //Field offset: 0x8
		private RaycastResult m_PressRaycast; //Field offset: 0x10
		private GameObject m_PressObject; //Field offset: 0x60
		private GameObject m_RawPressObject; //Field offset: 0x68
		private GameObject m_LastPressObject; //Field offset: 0x70
		private GameObject m_DragObject; //Field offset: 0x78
		private Vector2 m_PressPosition; //Field offset: 0x80
		private float m_ClickTime; //Field offset: 0x88
		private int m_ClickCount; //Field offset: 0x8C
		private bool m_Dragging; //Field offset: 0x90
		private bool m_ClickedOnSameGameObject; //Field offset: 0x91
		private bool m_IgnoreNextClick; //Field offset: 0x92

		public bool clickedOnSameGameObject
		{
			 get { } //Length: 8
			 set { } //Length: 7
		}

		public bool ignoreNextClick
		{
			 get { } //Length: 8
			 set { } //Length: 7
		}

		public bool isPressed
		{
			 get { } //Length: 4
			 set { } //Length: 68
		}

		public float pressTime
		{
			 get { } //Length: 6
			 set { } //Length: 6
		}

		public bool wasPressedThisFrame
		{
			 get { } //Length: 17
		}

		public bool wasReleasedThisFrame
		{
			 get { } //Length: 17
		}

		public void CopyPressStateFrom(PointerEventData eventData) { }

		public void CopyPressStateTo(PointerEventData eventData) { }

		public bool get_clickedOnSameGameObject() { }

		public bool get_ignoreNextClick() { }

		public bool get_isPressed() { }

		public float get_pressTime() { }

		public bool get_wasPressedThisFrame() { }

		public bool get_wasReleasedThisFrame() { }

		public void OnEndFrame() { }

		public void set_clickedOnSameGameObject(bool value) { }

		public void set_ignoreNextClick(bool value) { }

		public void set_isPressed(bool value) { }

		public void set_pressTime(float value) { }

	}

	public bool changedThisFrame; //Field offset: 0x0
	public ButtonState leftButton; //Field offset: 0x8
	public ButtonState rightButton; //Field offset: 0xA0
	public ButtonState middleButton; //Field offset: 0x138
	public ExtendedPointerEventData eventData; //Field offset: 0x1D0
	private Vector2 m_ScreenPosition; //Field offset: 0x1D8
	private Vector2 m_ScrollDelta; //Field offset: 0x1E0
	private Vector3 m_WorldPosition; //Field offset: 0x1E8
	private Quaternion m_WorldOrientation; //Field offset: 0x1F4
	private float m_Pressure; //Field offset: 0x204
	private float m_AzimuthAngle; //Field offset: 0x208
	private float m_AltitudeAngle; //Field offset: 0x20C
	private float m_Twist; //Field offset: 0x210
	private Vector2 m_Radius; //Field offset: 0x214

	public float altitudeAngle
	{
		 get { } //Length: 9
		 set { } //Length: 27
	}

	public float azimuthAngle
	{
		 get { } //Length: 9
		 set { } //Length: 27
	}

	public UIPointerType pointerType
	{
		 get { } //Length: 32
	}

	public float pressure
	{
		 get { } //Length: 9
		 set { } //Length: 27
	}

	public Vector2 radius
	{
		 get { } //Length: 25
		 set { } //Length: 80
	}

	public Vector2 screenPosition
	{
		 get { } //Length: 25
		 set { } //Length: 80
	}

	public Vector2 scrollDelta
	{
		 get { } //Length: 25
		 set { } //Length: 80
	}

	public float twist
	{
		 get { } //Length: 9
		 set { } //Length: 27
	}

	public Quaternion worldOrientation
	{
		 get { } //Length: 14
		 set { } //Length: 107
	}

	public Vector3 worldPosition
	{
		 get { } //Length: 25
		 set { } //Length: 123
	}

	public PointerModel(ExtendedPointerEventData eventData) { }

	public void CopyTouchOrPenStateFrom(PointerEventData eventData) { }

	public float get_altitudeAngle() { }

	public float get_azimuthAngle() { }

	public UIPointerType get_pointerType() { }

	public float get_pressure() { }

	public Vector2 get_radius() { }

	public Vector2 get_screenPosition() { }

	public Vector2 get_scrollDelta() { }

	public float get_twist() { }

	public Quaternion get_worldOrientation() { }

	public Vector3 get_worldPosition() { }

	public void OnFrameFinished() { }

	public void set_altitudeAngle(float value) { }

	public void set_azimuthAngle(float value) { }

	public void set_pressure(float value) { }

	public void set_radius(Vector2 value) { }

	public void set_screenPosition(Vector2 value) { }

	public void set_scrollDelta(Vector2 value) { }

	public void set_twist(float value) { }

	public void set_worldOrientation(Quaternion value) { }

	public void set_worldPosition(Vector3 value) { }

}

