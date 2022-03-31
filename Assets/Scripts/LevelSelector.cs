using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelselector : MonoBehaviour

{
    public void LoadingLevels(string nameOftheLevel)

    {
        SceneManager.LoadScene(nameOftheLevel);
    }

}
