using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroids.SceneManagement
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadNextScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

        public void DelayedNextScene()
        {
            StartCoroutine(CoroutineDelayedNextScene());
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
            SceneManager.LoadScene(2);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        IEnumerator CoroutineDelayedNextScene()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("Game Over");
        }
    }
}
