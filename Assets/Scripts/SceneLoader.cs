using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject LoaderUI;
    public Slider progressSlider;
    public static SceneLoader instance = null;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        LoaderUI.SetActive(false);
    }

    public void LoadScene(int index)
    {
        LoaderUI.SetActive(true);
        StartCoroutine(LoadScene_Coroutine(index));
    }

    public IEnumerator LoadScene_Coroutine(int index)
    {
        progressSlider.value = 0;






        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        asyncOperation.allowSceneActivation = false;
        float progress = 0;


        while (!asyncOperation.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            progressSlider.value = progress;


            if (progress >= 0.9f)
            {

                progressSlider.value = 1;
                asyncOperation.allowSceneActivation = true;

            }
            yield return null;
        }
    }
}
