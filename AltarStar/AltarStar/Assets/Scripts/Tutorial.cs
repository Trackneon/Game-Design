using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject tutDisplay;

    void Start()
    {
        tutDisplay.SetActive(false);
    }

    //void OnTriggerEnter (Collider player)
    //{
    //    if (player.gameObject.tag == "Player")
    //    {
    //        tutDisplay.SetActive(true);
    //        StartCoroutine("WaitForSec");
    //    }
    //}
    //IEnumerator WaitForSec()
    //{
    //    yield return new WaitForSeconds(8);
    //    Destroy(tutDisplay);
    //    Destroy(gameObject);
    //}

    public void TutDisplay()
    {
        tutDisplay.SetActive(true);
    }

    public void TutHide()
    {
        tutDisplay.SetActive(false);
    }
}
