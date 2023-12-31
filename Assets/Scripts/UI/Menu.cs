using UnityEngine;

[CreateAssetMenu(fileName = "Menu", menuName = "SO/Menu")]

public class Menu : ScriptableObject
{
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
