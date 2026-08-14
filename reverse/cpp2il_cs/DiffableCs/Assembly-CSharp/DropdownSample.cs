//Type is in global namespace

public class DropdownSample : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI text; //Field offset: 0x20
	[SerializeField]
	private TMP_Dropdown dropdownWithoutPlaceholder; //Field offset: 0x28
	[SerializeField]
	private TMP_Dropdown dropdownWithPlaceholder; //Field offset: 0x30

	public DropdownSample() { }

	public void OnButtonClick() { }

}

