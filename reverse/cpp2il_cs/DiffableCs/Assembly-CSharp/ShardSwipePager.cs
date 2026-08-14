//Type is in global namespace

[DisallowMultipleComponent]
public class ShardSwipePager : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
{
	private const float MIN_DISTANCE = 80; //Field offset: 0x0
	private const float HORIZONTAL_BIAS = 1.5; //Field offset: 0x0
	public Action<Int32> OnSwipe; //Field offset: 0x20
	private Vector2 _start; //Field offset: 0x28
	private bool _tracking; //Field offset: 0x30

	public ShardSwipePager() { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	private void OnDisable() { }

	public override void OnDrag(PointerEventData eventData) { }

	public override void OnEndDrag(PointerEventData eventData) { }

}

