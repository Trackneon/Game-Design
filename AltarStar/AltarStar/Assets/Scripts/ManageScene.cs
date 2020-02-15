using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{

    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene("NewMapTest");
    }

    // Update is called once per frame
    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void PortalChamber()
    {
        SceneManager.LoadScene("PortalChamber");
    }
}
