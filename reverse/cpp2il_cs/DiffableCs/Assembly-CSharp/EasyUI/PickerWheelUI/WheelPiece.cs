namespace EasyUI.PickerWheelUI;

public class WheelPiece
{
	public Sprite Icon; //Field offset: 0x10
	public string Label; //Field offset: 0x18
	[Tooltip("Reward amount")]
	public int Amount; //Field offset: 0x20
	[Range(0, 100)]
	[Tooltip("Probability in %")]
	public float Chance; //Field offset: 0x24
	[HideInInspector]
	public int Index; //Field offset: 0x28
	[HideInInspector]
	public double _weight; //Field offset: 0x30

	public WheelPiece() { }

}

