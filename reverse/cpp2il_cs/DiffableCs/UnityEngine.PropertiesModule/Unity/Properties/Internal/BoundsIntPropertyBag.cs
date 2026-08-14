namespace Unity.Properties.Internal;

internal class BoundsIntPropertyBag : ContainerPropertyBag<BoundsInt>
{
	private class PositionProperty : Property<BoundsInt, Vector3Int>
	{

		public virtual bool IsReadOnly
		{
			 get { } //Length: 3
		}

		public virtual string Name
		{
			 get { } //Length: 44
		}

		public PositionProperty() { }

		public virtual bool get_IsReadOnly() { }

		public virtual string get_Name() { }

		public virtual Vector3Int GetValue(ref BoundsInt container) { }

		public virtual void SetValue(ref BoundsInt container, Vector3Int value) { }

	}

	private class SizeProperty : Property<BoundsInt, Vector3Int>
	{

		public virtual bool IsReadOnly
		{
			 get { } //Length: 3
		}

		public virtual string Name
		{
			 get { } //Length: 44
		}

		public SizeProperty() { }

		public virtual bool get_IsReadOnly() { }

		public virtual string get_Name() { }

		public virtual Vector3Int GetValue(ref BoundsInt container) { }

		public virtual void SetValue(ref BoundsInt container, Vector3Int value) { }

	}


	public BoundsIntPropertyBag() { }

}

