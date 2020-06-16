/**
 * @author Kleber Ribeiro da Silva
 * @email krsmga@gmail.com
 * @create date 2020-06-13 18:47:15
 * @modify date 2020-06-16 09:23:45
 * @github https://github.com/krsmga/LoadScene
 */

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// The LoadScene class makes it easy to call a new scene by offering different possibilities according to your needs.
/// </summary>
/// <remarks>
/// <param name="onStart">If 'true' starts loading the scene in Start() method.</param>
/// <param name="sceneName">Name of the scene to be called.</param>
/// <param name="asyncLoad">Starts loading the scene asynchronously.</param>
/// <param name="waitInLoad">Adjusts a time in seconds during the charge cycle.</param>
/// <param name="progressBar">Allows you to attach a Slider component to show the scene loading process.</param>
/// <param name="waitAfterload">If 'true', it waits to execute the Execute() method to finish loading the scene.</param>
/// </remarks>
public class LoadScene : MonoBehaviour
{
    [SerializeField] private bool onStart = default;
    [SerializeField] private string sceneName = default;
    [SerializeField] private bool asyncLoad = default;
    [SerializeField] private float waitInLoad = default;
    [SerializeField] private Slider progressBar = default;
    [SerializeField] private bool waitAfterload = default;
    
    private AsyncOperation asyncOperation;

    void Start()
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("Error: [LoadScene] - It is necessary to define the scene name!");
            return;
        }
        
        if (onStart)
        {
            StartLoad(true);
        }
    }

    /// <summary>
    /// This method starts loading the scene AsyncLoad() or NormalLoad()
    /// </summary>
    public void StartLoad(bool value)
    {
        if (!value)
        {
            return;
        }

        // Reset progress bar
        ProgressBar(0);

        if (asyncLoad)
        {
            StartCoroutine(AsyncLoad());
        }
        else
        {
            NormalLoad();
        }
    }

    /// <summary>
    /// This method starts loading the scene asynchronously
    /// </summary>
	private IEnumerator AsyncLoad()
    {
        //wait time to start load
        asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        asyncOperation.allowSceneActivation = false;

        // Wait until the asynchronous scene fully loads
        while (asyncOperation.progress < 0.9f)
        {
            ProgressBar(asyncOperation.progress);
            yield return new WaitForSeconds(waitInLoad);
        }

        if (!waitAfterload)
        {
            Execute();
        }
    }

    /// <summary>
    /// This method starts loading the scene in the normal way
    /// </summary>
    private void NormalLoad()
	{
		SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
	}

    /// <summary>
    /// This method manages the slider value as a progress bar
    /// </summary>
    private void ProgressBar(float value)
    {
        if (progressBar != null)
        {
            progressBar.value = value;
        }
    }

    /// <summary>
    /// This method performs the opening of the scene after it is loaded
    /// </summary>
    public void Execute()
    {
        ProgressBar(1);
        asyncOperation.allowSceneActivation = true;
    }
}
