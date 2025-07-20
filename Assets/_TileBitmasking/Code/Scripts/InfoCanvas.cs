using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace TileBitmasking.Sample
{
    public class InfoCanvas : MonoBehaviour
    {
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private Text logTextPrefab;
        [SerializeField] private RectTransform logParent;
        [SerializeField] private string sceneName;

        public void Log(string log)
        {
            Text instance = Instantiate(logTextPrefab, logParent);
            instance.text = log;
            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;
        }

        public void OnClick_ChangeSceneButton()
        {
            if (!string.IsNullOrEmpty(sceneName))
            {
                Debug.Log(sceneName);
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}