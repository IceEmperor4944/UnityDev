using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject[] elements;
    [SerializeField] GameObject tank;

    private void Update()
    {
        if(tank.gameObject.TryGetComponent(out PlayerTank pt))
        {
            foreach(var element in elements)
            {
                if (pt.dead)
                {
                    if (element.name == "Game Over" || element.name == "Play Again" || element.name == "Exit" || element.name == "Panel")
                    {
                        element.SetActive(true);
                    }
                    else if (element.name == "Ammo" || element.name == "Health")
                    {
                        element.SetActive(false);
                    }
                }
                else if (pt.win)
                {
                    if (element.name == "You Win" || element.name == "Play Again" || element.name == "Exit" || element.name == "Panel")
                    {
                        element.SetActive(true);
                    }
                    else if (element.name == "Ammo" || element.name == "Health")
                    {
                        element.SetActive(false);
                    }
                }
                else
                {
                    if (element.name == "Game Over" || element.name == "Play Again" || element.name == "Exit" || element.name == "You Win" || element.name == "Panel")
                    {
                        element.SetActive(false);
                    }
                    else if (element.name == "Ammo" || element.name == "Health")
                    {
                        element.SetActive(true);
                    }
                }
            }
        }
    }

    public void ExitPressed()
    {
        Application.Quit();
    }

    public void PlayAgainPressed()
    {
        if (tank.gameObject.TryGetComponent(out PlayerTank pt))
        {
            pt.dead = false;
            pt.win = false;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}