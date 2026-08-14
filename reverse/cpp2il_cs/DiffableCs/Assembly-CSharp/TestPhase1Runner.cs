//Type is in global namespace

public class TestPhase1Runner : MonoBehaviour
{
	public string LastReport; //Field offset: 0x20

	public TestPhase1Runner() { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::AfterSceneLoad (0))]
	private static void Bootstrap() { }

	public void CreateCoopRoom() { }

	public void CreateCoopRoomWithEnemy(int enemyPetId) { }

	public void DumpRoomState() { }

	public void LeaveRoom() { }

	public void SetMyPet(int petId) { }

	public void StartMatch() { }

}

