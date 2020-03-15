using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//[RequireComponent(typeof(Button))]
//[RequireComponent(typeof(Image))]
//[RequireComponent(typeof(Text))]
public class WeaponButtonHandler : MonoBehaviour
{
    public new WeaponConfig weaponObj;
    private Button weaponButton;
    private Image buttonImg;
    private Text buttonText;
    void Start ()
    {
        weaponButton = GetComponent<Button>();
        weaponButton.onClick.AddListener(weaponObj.RaiseFireAction);
        buttonImg = GetComponent<Image>();
        buttonImg.color = weaponObj.weaponColor;
        buttonText = GetComponentInChildren<Text>();
        buttonText.text = weaponObj.name + " Fire";
        weaponButton.interactable = true;

    }


    //void Update()
    //{
    //    if (Input.GetKeyDown("n"))
    //    {
    //        WeaponHandler.Fire();
    //        Debug.Log("fire");
    //    }
    //}
}