using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Text scoreText;
    bool gameOver = false;
    private Rigidbody2D rb;
    private Camera cam;
    private float currentscore = 0;
    private int score = 0;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    private void setScore()
    {
        currentscore += Time.deltaTime;

        if (currentscore >= 0.5f)
        {
            score++;
            currentscore = 0;
            scoreText.text = score.ToString("000");
        }
    }
    private void Update()
    {
        if (!gameOver)
        {
            setScore();
            moveMent();
        }
    }
    private void moveMent()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward * (-rotationSpeed) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * (rotationSpeed) * Time.deltaTime);
        }
    }
    private void FixedUpdate()
    {
        if (!gameOver)
        {
            rb.AddRelativeForce(new Vector3(speed * Time.fixedDeltaTime, 0f, 0f));
        }
    }
    private void LateUpdate()
    {
        if (!gameOver)
        {
            cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
        }
    }
    private void OnCollisionEnter2D()
    {
        if (!gameOver)
        {
            gameOver = true;
            Debug.Log("Game Over");
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponentInChildren<ParticleSystem>().Play();
            audioSource.PlayOneShot(audioClip);
            Invoke("Restart", 2f);
        }
    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
