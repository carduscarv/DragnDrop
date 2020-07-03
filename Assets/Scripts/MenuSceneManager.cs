﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    public void GoToScene(string scene){

        SceneManager.LoadScene(scene);
    }

    public void Quit(){
        Application.Quit();
    }
}
