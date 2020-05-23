using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemSlot : MonoBehaviour
{
	public string nameObj;
	
	public Sprite Icon;

    void Start()
    {
		nameObj = "Locked Item Slot";
	}

	public void UpdateIcon(Sprite sprite, string name)
	{
		nameObj = name;
		Icon = sprite;
		GameObject itemImage = transform.Find("Border/ItemImage").gameObject;
		Image imageComponent = itemImage.GetComponent<Image>();	
		imageComponent.sprite = Icon;
	}

}
