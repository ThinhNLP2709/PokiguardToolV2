//Type is in global namespace

public class DotSelectionBorderEffect : MonoBehaviour
{
	[CompilerGenerated]
	private struct <>c__DisplayClass10_0
	{
		public Vector3 ctr; //Field offset: 0x0
		public float z; //Field offset: 0xC

	}

	private static Material s_sharedLineMat; //Field offset: 0x0
	private LineRenderer[] _edges; //Field offset: 0x20
	private GameObject _fxRoot; //Field offset: 0x28
	private SpriteRenderer _spriteRenderer; //Field offset: 0x30

	private static Material SharedLineMaterial
	{
		private get { } //Length: 497
	}

	public DotSelectionBorderEffect() { }

	[CompilerGenerated]
	internal static Vector3 <RefreshGeometry>g__Corner|10_0(float x, float y, ref <>c__DisplayClass10_0 unnamed_param_2) { }

	private void Build(Dot dot) { }

	private LineRenderer CreateEdge(int index) { }

	private static Material get_SharedLineMaterial() { }

	private void LateUpdate() { }

	private void OnDestroy() { }

	private void RefreshGeometry() { }

	public static void StartOn(Dot dot) { }

	public static void StopOn(GameObject dotRoot) { }

	private void Teardown() { }

}

