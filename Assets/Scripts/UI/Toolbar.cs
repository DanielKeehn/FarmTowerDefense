using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbar : MonoBehaviour
{
	public RectTransform highlight;
	[HideInInspector] public itemSlot[] itemSlots;

	private int slotIndex = 0;
	private SpawnManager spawnManager;

	private KeyCode[] keyCodes = {
		 KeyCode.Alpha1,
		 KeyCode.Alpha2,
		 KeyCode.Alpha3,
		 KeyCode.Alpha4,
		 KeyCode.Alpha5,
		 KeyCode.Alpha6,
		 KeyCode.Alpha7,
		 KeyCode.Alpha8,
		 KeyCode.Alpha9,
	 };

	// Start is called before the first frame update
	void Start()
    {
		itemSlots = GetComponentsInChildren<itemSlot>();
		spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
		spawnManager.playerSelectedAnimal = itemSlots[slotIndex].nameObj;
	}

    // Update is called once per frame
    void Update()
    {
		float scroll = Input.GetAxis("Mouse ScrollWheel");

		if (scroll != 0)
		{
			if (scroll > 0)
			{
				slotIndex--;
			}
			else
			{
				slotIndex++;
			}

			if (slotIndex > itemSlots.Length - 1)
			{
				slotIndex = 0;
			}
			if (slotIndex < 0)
			{
				slotIndex = itemSlots.Length - 1;
			}

			highlight.position = itemSlots[slotIndex].gameObject.transform.position;
			spawnManager.playerSelectedAnimal = itemSlots[slotIndex].nameObj;
		}

		for (int i = 0; i < keyCodes.Length; i++)
		{
			if (Input.GetKeyDown(keyCodes[i]))
			{
				slotIndex = i;
				highlight.position = itemSlots[slotIndex].gameObject.transform.position;
				spawnManager.playerSelectedAnimal = itemSlots[slotIndex].nameObj;
			}
		}

    }

	public itemSlot getItemSlot()
	{
		return itemSlots[slotIndex];
	}
}
