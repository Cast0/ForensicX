using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
   public static SceneController instance;
    [SerializeField]
    Animator TransitionAnim;

    private void awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextScene()
    {
        StartCoroutine(Loadlevel());
    }

    IEnumerator Loadlevel()
    {
        TransitionAnim.SetTrigger("exit");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Main Menu");
        TransitionAnim.SetTrigger("enter");

    }
}
