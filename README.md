# LoadScene
The LoadScene class makes it easy to call a new scene by offering different possibilities according to your needs.

## Script settings in Inspector
![](../master/Example.png)

## Steps for use
1. Attach the **LoadScene.cs** script to any **GameObject** in the Scene.

2. The **On Start** if 'true' starts loading the scene in **`Start()`** method.

3. The **Scene Name** parameter name of the scene to be called.

4. The **Async Load** starts loading the scene asynchronously.

5. The **Wait In Load** adjusts a time in seconds during the charge cycle.

6. The **Progress Bar** allows you to attach a Slider component to show the scene loading process.

7. The **Wait After load** if 'true', it waits to execute the Execute() method to finish loading the scene.



