using UnityEngine;

public class TriggerWardrobe : MonoBehaviour
{
    public GameObject leftSide;
    public GameObject openedDoor;
    public BoxCollider2D leftCollider;

    private GameObject player;
    private bool used;


    void Start(){        
        openedDoor.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        leftCollider.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("trigger");
        if (!used) {
            leftSide.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.openDoor;
            openedDoor.SetActive(true);

            collision.GetComponentInChildren<Animator>().SetTrigger("groom");
            collision.GetComponent<PlayerMovement>().SetSpeed(15f);

            CameraController.instance.StartZoomIn(2.5f, 4f);

            GameObject puff = (GameObject)Instantiate(GameAssets.instance.smokePF, transform.position, transform.rotation);
            puff.transform.localScale = new Vector3(2f, 2f, 2f);
            Destroy(puff, 2f);
            used = true;
        }
    }

    private void Update() {
        if (Vector3.Distance(player.transform.position, transform.position) > 10f && used)
            Destroy(gameObject);
    }
}