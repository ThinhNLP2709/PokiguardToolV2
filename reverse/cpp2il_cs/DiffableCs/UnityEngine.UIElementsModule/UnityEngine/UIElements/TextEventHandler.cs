namespace UnityEngine.UIElements;

internal class TextEventHandler
{
	private TextElement m_TextElement; //Field offset: 0x10
	private EventCallback<PointerDownEvent> m_LinkTagOnPointerDown; //Field offset: 0x18
	private EventCallback<PointerUpEvent> m_LinkTagOnPointerUp; //Field offset: 0x20
	private EventCallback<PointerMoveEvent> m_LinkTagOnPointerMove; //Field offset: 0x28
	private EventCallback<PointerOutEvent> m_LinkTagOnPointerOut; //Field offset: 0x30
	private EventCallback<PointerUpEvent> m_ATagOnPointerUp; //Field offset: 0x38
	private EventCallback<PointerMoveEvent> m_ATagOnPointerMove; //Field offset: 0x40
	private EventCallback<PointerOverEvent> m_ATagOnPointerOver; //Field offset: 0x48
	private EventCallback<PointerOutEvent> m_ATagOnPointerOut; //Field offset: 0x50
	internal bool isOverridingCursor; //Field offset: 0x58
	internal int currentLinkIDHash; //Field offset: 0x5C
	internal bool hasLinkTag; //Field offset: 0x60
	internal bool hasATag; //Field offset: 0x61

	private TextInfo textInfo
	{
		private get { } //Length: 41
	}

	public TextEventHandler(TextElement textElement) { }

	private void AllocateATagCallbacks() { }

	private void AllocateLinkCallbacks() { }

	private void ATagOnPointerMove(PointerMoveEvent pme) { }

	private void ATagOnPointerOut(PointerOutEvent evt) { }

	private void ATagOnPointerOver(PointerOverEvent _) { }

	private void ATagOnPointerUp(PointerUpEvent pue) { }

	private TextInfo get_textInfo() { }

	internal void HandleATag() { }

	internal void HandleLinkAndATagCallbacks() { }

	internal void HandleLinkTag() { }

	private bool HasAllocatedATagCallbacks() { }

	private bool HasAllocatedLinkCallbacks() { }

	private void LinkTagOnPointerDown(PointerDownEvent pde) { }

	private void LinkTagOnPointerMove(PointerMoveEvent pme) { }

	private void LinkTagOnPointerOut(PointerOutEvent poe) { }

	private void LinkTagOnPointerUp(PointerUpEvent pue) { }

}

