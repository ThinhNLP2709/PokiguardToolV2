//Type is in global namespace

public class FusionGhostFxNode : MonoBehaviour
{
	public int petId; //Field offset: 0x20
	public GameObject auraObject; //Field offset: 0x28
	public Transform ghostTransform; //Field offset: 0x30
	public SpriteRenderer ghostRenderer; //Field offset: 0x38
	public Animator ghostAnimator; //Field offset: 0x40
	public Vector3 ghostBaseScale; //Field offset: 0x48

	public FusionGhostFxNode() { }

	private void OnDestroy() { }

}

