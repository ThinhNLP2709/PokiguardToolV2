namespace Unity.Properties.Internal;

internal class Vector3IntPropertyBag : ContainerPropertyBag<Vector3Int>
{
	private class XProperty : Property<Vector3Int, Int32>
	{

		public virtual bool IsReadOnly
		{
			 get { } //Length: 3
		}

		public virtual string Name
		{
			 get { } //Length: 44
		}

		public XProperty() { }

		public virtual bool get_IsReadOnly() { }

		public virtual string get_Name() { }

		public virtual int GetValue(ref Vector3Int container) { }

		public virtual void SetValue(ref Vector3Int container, int value) { }

	}

	private class YProperty : Property<Vector3Int, Int32>
	{

		public virtual bool IsReadOnly
		{
			 get { } //Length: 3
		}

		public virtual string Name
		{
			 get { } //Length: 44
		}

		public YProperty() { }

		public virtual bool get_IsReadOnly() { }

		public virtual string get_Name() { }

		public virtual int GetValue(ref Vector3Int container) { }

		public virtual void SetValue(ref Vector3Int container, int value) { }

	}

	private class ZProperty : Property<Vector3Int, Int32>
	{

		public virtual bool IsReadOnly
		{
			 get { } //Length: 3
		}

		public virtual string Name
		{
			 get { } //Length: 44
		}

		public ZProperty() { }

		public virtual bool get_IsReadOnly() { }

		public virtual string get_Name() { }

		public virtual int GetValue(ref Vector3Int container) { }

		public virtual void SetValue(ref Vector3Int container, int value) { }

	}


	public Vector3IntPropertyBag() { }

}

