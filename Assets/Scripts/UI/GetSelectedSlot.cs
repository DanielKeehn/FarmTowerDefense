using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetSelectedSlot : MonoBehaviour
{
	private Toolbar toolbar;
	private itemSlot itemSlot;
	private SpawnManager spawnManager;

	public itemSlot ourItemSlot;
	public TextMeshProUGUI Name;
	public TextMeshProUGUI costValue;
	public TextMeshProUGUI healthValue;
	public TextMeshProUGUI damageValue;

	// Start is called before the first frame update
	void Start()
	{
		toolbar = FindObjectOfType<Toolbar>();
		spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
		if (!spawnManager)
		{
			Debug.LogWarning("No animal manager found");
		}
		if (!toolbar)
		{
			Debug.LogWarning("No toolbar found");
		}

		if (!healthValue || !costValue)
		{
			Debug.LogWarning("text values box found");
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (!itemSlot || itemSlot != toolbar.getItemSlot())
		{
		itemSlot = toolbar.getItemSlot();
		UpdateSelectedSlotData();
		}
	}

	private void UpdateSelectedSlotData()
	{
		ourItemSlot.Icon = itemSlot.Icon;
		ourItemSlot.nameObj = itemSlot.nameObj;
		ourItemSlot.UpdateIcon(itemSlot.Icon, itemSlot.nameObj);
		Animal animalScript = spawnManager.playerSelectedAnimal.GetComponent<Animal>();
		Name.text = animalScript.name;
		costValue.text = animalScript.costToSpawn.ToString();
		healthValue.text = animalScript.health.ToString();
		//damageValue.text = animalScript.damage.ToString();
	}
}
