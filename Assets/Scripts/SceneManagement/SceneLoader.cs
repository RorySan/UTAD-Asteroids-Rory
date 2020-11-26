using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroids.SceneManagement
{

    public class SceneLoader : MonoBehaviour
    {

        [SerializeField] float delayedLoad = 2f;

        public void LoadNextScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

        public void LoadSceneDelayed(string scene)
        {
            StartCoroutine(CoroutineDelayedNextScene(scene));
        }

        public void LoadPreviousScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex - 1);
        }

        public void RestartGame()
        {
            //FindObjectOfType<LevelController>().ResetGame();
            SceneManager.LoadScene(1);
        }

        public void LoadStartScene()
        {
            SceneManager.LoadScene(0);
        }

        public void LoadGameOver()
        {
            StartCoroutine(CoroutineDelayedNextScene("Game Over"));
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        IEnumerator CoroutineDelayedNextScene(string scene)
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(scene);
        }
    }
}
