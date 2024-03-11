using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public void ToLoadScreen()
    {
        SceneManager.LoadScene("Loading Screen");
    }
}
