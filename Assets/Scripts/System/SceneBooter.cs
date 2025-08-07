using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBooter : MonoBehaviour
{
    private void Start()
    {
#if UNITY_EDITOR
        return;
#endif
#if UNITY_STANDALONE
        SceneManager.LoadScene("Entry", LoadSceneMode.Additive);
#endif
    }
}