using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    private bool _alive; //Логическая переменная для слежения за состоянием персонажа.

    [SerializeField] private GameObject fireballPrefab; 
    private GameObject _fireball; 

    void Start() 
    {
        _alive = true; //Инициализация этой переменной.
    } 
    void Update() 
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit)) 
            { 
                GameObject hitObject = hit.transform.gameObject; 
                if (hitObject.GetComponent<PlayerCharacter>()) 
                {  
                    if (_fireball == null) 
                    {  
                        _fireball = Instantiate(fireballPrefab) as GameObject;  
                        _fireball.transform.position =  
                        transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation; 
                    } 
                } 
                else if (hit.distance < obstacleRange) 
                { 
                    float angle = Random.Range(-110, 110); 
                    transform.Rotate(0, angle, 0); 
                } 
            } 
        }
       
    }
    public void SetAlive(bool alive) 
    {
        _alive = alive;
    } 
    public void ReactToHit() 
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null) 
        {
            behavior.SetAlive(false);
        }
        StartCoroutine(Die()); 
    }
    private IEnumerator Die() 
    {
        // Опрокидываем врага, ждем 1,5 секунды и уничтожаем его.
        this.transform.Rotate(75, 0, 0);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }

}
