﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public void changeToScene(int changeSceneTo)
    {
        SceneManager.LoadScene(changeSceneTo);
    }

}
