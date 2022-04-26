using UnityEngine; 
using System.Collections; 
public class PlayerCharacter : MonoBehaviour 
{
    private int _health; 
    void Start() 
    { 
        _health = 5;    // Инициализация переменной health. 
    }
    public void Hurt(int damage) 
    { 
        _health -= damage;             //Уменьшение здоровья игрока. 
        Debug.Log("Health: " + _health); 
    } 
}