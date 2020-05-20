using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetSelectedSlot : MonoBehaviour
{
	private Toolbar toolbar;
	private itemSlot itemSlot;
	private AnimalManager animalManager;

	[SerializeField] private itemSlot ourItemSlot;
	[SerializeField] private TextMeshProUGUI Name;
	[SerializeField] private TextMeshProUGUI costValue;
	[SerializeField] private TextMeshProUGUI healthValue;
	[SerializeField] private TextMeshProUGUI damageValue;

	// Start is called before the first frame update
	// void Start()
	// {
	// 	toolbar = FindObjectOfType<Toolbar>();
	// 	animalManager = FindObjectOfType<AnimalManager>();
	// 	if (!animalManager)
	// 	{
	// 		Debug.LogWarning("No animal manager found");
	// 	}
	// 	if (!toolbar)
	// 	{
	// 		Debug.LogWarning("No toolbar found");
	// 	}

	// 	if (!healthValue || !costValue)
	// 	{
	// 		Debug.LogWarning("text values box found");
	// 	}
	// }

	// // Update is called once per frame
	// void Update()
	// {
	// 	if (!itemSlot || itemSlot != toolbar.getItemSlot())
	// 	{
	// 	itemSlot = toolbar.getItemSlot();
	// 	UpdateSelectedSlotData();
	// 	}
	// }

	// private void UpdateSelectedSlotData()
	// {
	// 	ourItemSlot.Icon = itemSlot.Icon;
	// 	ourItemSlot.nameObj = itemSlot.nameObj;
	// 	ourItemSlot.UpdateIcon();
	// 	Name.text = ourItemSlot.nameObj;
	// 	GameObject foundAnimal = animalManager.animalDict[ourItemSlot.nameObj];
	// 	Animal animalScript = foundAnimal.gameObject.GetComponent<Animal>();
	// 	costValue.text = animalScript.costToSpawn.ToString();
	// 	healthValue.text = animalScript.health.ToString();
	// 	//damageValue.text = animalScript.damage.ToString();
	// }
}
