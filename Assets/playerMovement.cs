using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        changeSize();
    }

    // Update is called once per frame
    void Update()
    {
        moving();
    }

    private void moving()
    {
        if (Input.GetKey(KeyCode.W) && gameObject.transform.position.y + (1.8 * Menu.size) < 5)
        {
            gameObject.transform.position += Vector3.up * Time.deltaTime * 3;
        }
        else if (Input.GetKey(KeyCode.S) && gameObject.transform.position.y - (1.8 * Menu.size) > -5)
        {
            gameObject.transform.position += Vector3.down * Time.deltaTime * 3;
        }
    }
    
    private void changeSize()
    {
        gameObject.transform.localScale = new Vector3(0.7f * Menu.size, 0.15f, 1f);
    }
}
