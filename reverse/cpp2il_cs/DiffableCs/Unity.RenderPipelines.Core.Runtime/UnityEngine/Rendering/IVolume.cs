namespace UnityEngine.Rendering;

public interface IVolume
{

	public List<Collider> colliders
	{
		 get { } //Length: 0
	}

	public bool isGlobal
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public List<Collider> get_colliders() { }

	public bool get_isGlobal() { }

	public void set_isGlobal(bool value) { }

}

