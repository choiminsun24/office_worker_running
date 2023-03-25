using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    //�ִϸ��̼��� Entry�� �ٷ� �����ؼ� �����ָ� �� �� ���ƿ�.
    //���� ��ũ�ѹ� ��� ���� ���ư��� �ε��� ���ص� �ִϸ��̼� Entry�� ������ �� �� �����ϴ�.
    //Animation and Loading circle can be implemented by applying it to entry. 

    static string NextScene;
    public Scrollbar scb;
    private float timer;
  
    public static void LoadScene(string SceneName)
    {
        SceneManager.LoadScene("LoadingScene");
        NextScene = SceneName;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(NextScene);
        op.allowSceneActivation = false;

        timer = 0f;

        while(!op.isDone)
        {
            yield return null;

            Debug.Log("�ε� ��"); //����׿�
            scb.size = op.progress;

            if(op.progress >= 0.9f)
            {
                timer += Time.unscaledDeltaTime;
                Debug.Log(timer); //����׿�

                if(timer >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}