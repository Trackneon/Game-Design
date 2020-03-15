using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyGameObject : MonoBehaviour
{
    public FloatData data;
    public GameObject obj;

    void Start()
    {
        //data.value = 1f;
    }
    public void Update()
    {
        //if (data.value <= 0f && obj.tag == "Enemy")
        //{
          //  Destroy(obj);
        //}

        if (data.value <= 0f && obj.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
