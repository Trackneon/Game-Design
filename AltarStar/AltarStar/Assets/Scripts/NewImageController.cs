using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewImageController : MonoBehaviour
{
    public Image image;
    public FloatData data;

    public void Start()
    {
        image = GetComponent<Image>();
    }

    public void Update()
    {
        image.fillAmount = data.value;
    }
}
