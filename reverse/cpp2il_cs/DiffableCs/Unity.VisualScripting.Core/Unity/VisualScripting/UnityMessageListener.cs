namespace Unity.VisualScripting;

[AddComponentMenu(null)]
[Obsolete("UnityMessageListener is deprecated and has been replaced by separate message listeners for each event, eg. UnityOnCollisionEnterMessageListener or UnityOnButtonClickMessageListener.")]
public sealed class UnityMessageListener : MessageListener, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IScrollHandler, ISelectHandler, IDeselectHandler, ISubmitHandler, ICancelHandler, IMoveHandler
{

	public UnityMessageListener() { }

	[CompilerGenerated]
	private void <AddGUIListeners>b__1_0() { }

	[CompilerGenerated]
	private void <AddGUIListeners>b__1_1(bool value) { }

	[CompilerGenerated]
	private void <AddGUIListeners>b__1_2(float value) { }

	[CompilerGenerated]
	private void <AddGUIListeners>b__1_3(float value) { }

	[CompilerGenerated]
	private void <AddGUIListeners>b__1_4(int value) { }

	[CompilerGenerated]
	private void <AddGUIListeners>b__1_5(string value) { }

	[CompilerGenerated]
	private void <AddGUIListeners>b__1_6(string value) { }

	[CompilerGenerated]
	private void <AddGUIListeners>b__1_7(Vector2 value) { }

	public void AddGUIListeners() { }

	private void OnBecameInvisible() { }

	private void OnBecameVisible() { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	public override void OnCancel(BaseEventData eventData) { }

	private void OnCollisionEnter(Collision collision) { }

	private void OnCollisionEnter2D(Collision2D collision) { }

	private void OnCollisionExit(Collision collision) { }

	private void OnCollisionExit2D(Collision2D collision) { }

	private void OnCollisionStay(Collision collision) { }

	private void OnCollisionStay2D(Collision2D collision) { }

	private void OnControllerColliderHit(ControllerColliderHit hit) { }

	public override void OnDeselect(BaseEventData eventData) { }

	public override void OnDrag(PointerEventData eventData) { }

	public override void OnDrop(PointerEventData eventData) { }

	public override void OnEndDrag(PointerEventData eventData) { }

	private void OnJointBreak(float breakForce) { }

	private void OnJointBreak2D(Joint2D brokenJoint) { }

	private void OnMouseDown() { }

	private void OnMouseDrag() { }

	private void OnMouseEnter() { }

	private void OnMouseExit() { }

	private void OnMouseOver() { }

	private void OnMouseUp() { }

	private void OnMouseUpAsButton() { }

	public override void OnMove(AxisEventData eventData) { }

	private void OnParticleCollision(GameObject other) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void OnPointerDown(PointerEventData eventData) { }

	public override void OnPointerEnter(PointerEventData eventData) { }

	public override void OnPointerExit(PointerEventData eventData) { }

	public override void OnPointerUp(PointerEventData eventData) { }

	public override void OnScroll(PointerEventData eventData) { }

	public override void OnSelect(BaseEventData eventData) { }

	public override void OnSubmit(BaseEventData eventData) { }

	private void OnTransformChildrenChanged() { }

	private void OnTransformParentChanged() { }

	private void OnTriggerEnter(Collider other) { }

	private void OnTriggerEnter2D(Collider2D other) { }

	private void OnTriggerExit(Collider other) { }

	private void OnTriggerExit2D(Collider2D other) { }

	private void OnTriggerStay(Collider other) { }

	private void OnTriggerStay2D(Collider2D other) { }

	private void Start() { }

}

