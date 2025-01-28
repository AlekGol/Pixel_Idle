using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ClickTarget();
    }

    private void ClickTarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, 512);
            
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Enemy")
                { 
                player.target = hit.transform;
                
                }
            }
            else
            {
                player.target = null;
            }
        }
      
    }
}
