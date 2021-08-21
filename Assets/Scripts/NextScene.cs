using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private IEnumerator coroutine;

    void Start()
    {

        coroutine = nextLevel(3.0f);
        StartCoroutine(coroutine);
    }

    private IEnumerator nextLevel(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
