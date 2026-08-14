namespace UnityEngine.InputSystem.LowLevel;

internal struct InputStateBuffers
{
	public struct DoubleBuffers
	{
		public Void** deviceToBufferMapping; //Field offset: 0x0
		public int deviceCount; //Field offset: 0x8

		public bool valid
		{
			 get { } //Length: 8
		}

		public bool get_valid() { }

		public Void* GetBackBuffer(int deviceIndex) { }

		public Void* GetFrontBuffer(int deviceIndex) { }

		public void SetBackBuffer(int deviceIndex, Void* ptr) { }

		public void SetFrontBuffer(int deviceIndex, Void* ptr) { }

		public void SwapBuffers(int deviceIndex) { }

	}

	internal static Void* s_DefaultStateBuffer; //Field offset: 0x0
	internal static Void* s_NoiseMaskBuffer; //Field offset: 0x8
	internal static Void* s_ResetMaskBuffer; //Field offset: 0x10
	internal static DoubleBuffers s_CurrentBuffers; //Field offset: 0x18
	public uint sizePerBuffer; //Field offset: 0x0
	public uint totalSize; //Field offset: 0x4
	public Void* defaultStateBuffer; //Field offset: 0x8
	public Void* noiseMaskBuffer; //Field offset: 0x10
	public Void* resetMaskBuffer; //Field offset: 0x18
	private Void* m_AllBuffers; //Field offset: 0x20
	internal DoubleBuffers m_PlayerStateBuffers; //Field offset: 0x28

	public void AllocateAll(InputDevice[] devices, int deviceCount) { }

	private static uint ComputeSizeOfSingleStateBuffer(InputDevice[] devices, int deviceCount) { }

	public void FreeAll() { }

	public static Void* GetBackBufferForDevice(int deviceIndex) { }

	public DoubleBuffers GetDoubleBuffersFor(InputUpdateType updateType) { }

	public static Void* GetFrontBufferForDevice(int deviceIndex) { }

	public void MigrateAll(InputDevice[] devices, int deviceCount, InputStateBuffers oldBuffers) { }

	private static void MigrateDoubleBuffer(DoubleBuffers newBuffer, InputDevice[] devices, int deviceCount, DoubleBuffers oldBuffer) { }

	private static void MigrateSingleBuffer(Void* newBuffer, InputDevice[] devices, int deviceCount, Void* oldBuffer) { }

	private static uint NextDeviceOffset(uint currentOffset, InputDevice device) { }

	private static DoubleBuffers SetUpDeviceToBufferMappings(int deviceCount, ref Byte* bufferPtr, uint sizePerBuffer, uint mappingTableSizePerBuffer) { }

	public static void SwitchTo(InputStateBuffers buffers, InputUpdateType update) { }

}

