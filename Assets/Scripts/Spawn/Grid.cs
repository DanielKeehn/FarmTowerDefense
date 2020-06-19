using UnityEngine;

public class Grid : MonoBehaviour
{
	[SerializeField] [Range(5,20)] private float size = 1f;

	public float Size { get { return size; } }

	private int[,] grid = new int[10, 10];

	private void Awake()
	{
		for (int i = 0; i < 100 / size; i++)
		{
			for (int j = 0; j < 100 / size; j++)
			{
				grid[i,j] = -1;
			}
		}
	}

	public Vector3 GetNearestPointOnGrid(Vector3 position)
	{
		position -= transform.position;

		int xCount = Mathf.RoundToInt(position.x / size);
		int yCount = Mathf.RoundToInt(position.y / size);
		int zCount = Mathf.RoundToInt(position.z / size);

		if (grid[xCount, zCount] == -1)
		{
			Vector3 result = new Vector3((float)xCount * size + size / 2, (float)yCount * size, (float)zCount * size + size / 2);
			result += transform.position;

			grid[xCount, zCount] = 1;
			return result;
		}
		return Vector3.zero;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;

		for (float x = transform.position.x; x < transform.position.x + 100; x += size)
		{
			for (float z = transform.position.z; z < transform.position.z + 100; z += size)
			{
				Gizmos.DrawLine(new Vector3(x, 0f, z), new Vector3(x + size, 0f, z));
				Gizmos.DrawLine(new Vector3(x, 0f, z), new Vector3(x, 0f, z + size));
			}
		}
	}
}
