using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Vector3 torque;
    Vector3 force;
    AudioSource audioSource;
    public AudioClip clipSavePeople;
    public AudioClip clipOnFire;
    public Text lifeCount;
    public Text peopleCount;
    public Text timeCount;
    int savePeople = 0;
    public string nextScene;
    
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
         audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameData.timer <= 0){
            SceneManager.LoadScene("TimeOutScene");
        }

        GameData.timer -= 1.0f * Time.deltaTime;
        timeCount.text = GameData.timer.ToString("0");
        lifeCount.text = GameData.lives.ToString();
        peopleCount.text = savePeople.ToString();

        torque = Vector3.zero;
        force = Vector3.zero;
        if(Input.GetKey(KeyCode.W))
        {
            force += transform.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            force += -transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            torque += -transform.up;
        }
        else if (Input.GetKey(KeyCode.D))
        {
           torque += transform.up;
        }

        

    }

    private void FixedUpdate()
    {
        rb.AddTorque(torque * 125.0f);
        rb.AddForce(force * 45.0f);
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "human")
        {
            savePeople++;
            audioSource.clip = clipSavePeople;
            audioSource.Play();
            Destroy(other.gameObject, 1);
            if(savePeople == 5)
            {
                SceneManager.LoadScene(nextScene);
            }
        }

        if (other.gameObject.tag == "Fire")
        {
            GameData.lives--;
            audioSource.clip = clipOnFire;
            audioSource.Play();
            if(GameData.lives <= 0)
            {
                SceneManager.LoadScene("LoseScene");
            }
            
        }
    }
}
