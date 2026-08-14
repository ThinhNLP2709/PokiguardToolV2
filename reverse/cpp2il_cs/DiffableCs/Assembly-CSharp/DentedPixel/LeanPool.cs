namespace DentedPixel;

public class LeanPool
{
	private GameObject[] array; //Field offset: 0x10
	private Queue<GameObject> oldestItems; //Field offset: 0x18
	private int retrieveIndex; //Field offset: 0x20

	public LeanPool() { }

	public void giveup(GameObject go) { }

	public GameObject[] init(GameObject prefab, int count, Transform parent = null, bool retrieveOldestItems = true) { }

	public void init(GameObject[] array, bool retrieveOldestItems = true) { }

	public GameObject retrieve() { }

}

