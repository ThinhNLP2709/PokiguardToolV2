namespace UnityEngine;

[NativeType("Runtime/Graphics/Mesh/SpriteRenderer.h")]
[RequireComponent(typeof(Transform))]
public sealed class SpriteRenderer : Renderer
{
	private UnityEvent<SpriteRenderer> m_SpriteChangeEvent; //Field offset: 0x18

	public Color color
	{
		 get { } //Length: 142
		 set { } //Length: 133
	}

	internal bool hasSpriteChangeEvents
	{
		internal set { } //Length: 134
	}

	public SpriteMaskInteraction maskInteraction
	{
		 get { } //Length: 118
	}

	public Sprite sprite
	{
		 get { } //Length: 144
		 set { } //Length: 186
	}

	public Color get_color() { }

	private static void get_color_Injected(IntPtr _unity_self, out Color ret) { }

	public SpriteMaskInteraction get_maskInteraction() { }

	private static SpriteMaskInteraction get_maskInteraction_Injected(IntPtr _unity_self) { }

	public Sprite get_sprite() { }

	private static IntPtr get_sprite_Injected(IntPtr _unity_self) { }

	[RequiredByNativeCode]
	private void InvokeSpriteChanged() { }

	public void RegisterSpriteChangeCallback(UnityAction<SpriteRenderer> callback) { }

	public void set_color(Color value) { }

	private static void set_color_Injected(IntPtr _unity_self, in Color value) { }

	internal void set_hasSpriteChangeEvents(bool value) { }

	private static void set_hasSpriteChangeEvents_Injected(IntPtr _unity_self, bool value) { }

	public void set_sprite(Sprite value) { }

	private static void set_sprite_Injected(IntPtr _unity_self, IntPtr value) { }

	public void UnregisterSpriteChangeCallback(UnityAction<SpriteRenderer> callback) { }

}

