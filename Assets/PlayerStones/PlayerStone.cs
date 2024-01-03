using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerStone : MonoBehaviour, IPointerClickHandler
{
    public GameObject Game;
    public GameObject Position;
    private Game gameScript;
    public GameObject KickedPlayer;

    // Start is called before the first frame update
    void Start()
    {
        gameScript= Game.GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.isValid && eventData.pointerCurrentRaycast.gameObject == this.GetComponentInChildren<CapsuleCollider>().gameObject)
        {
            var targetPosition = this.gameScript.GetTargetPosition(Position);
            Position = targetPosition;


            gameScript.Movements.Enqueue(
                new Game.StoneMovement()
                {
                    Movement = () =>
                    {
                        gameObject.transform.position =
                            Vector3.MoveTowards(transform.position, Position.transform.position, 0.01f);
                    },
                    IsFinished = () => gameObject.transform.position == Position.transform.position
                });
        }
    }

    private void TestAnimation()
    {
        float smoothTime = 0.1f;
        float speed = 5;
        float deltaTime = 0.01f;

        Vector3 velocity = Vector3.zero;
        gameScript.Movements.Enqueue(
            new Game.StoneMovement()
            {
                Movement = () =>
                {
                    gameObject.transform.position =
                        Vector3.MoveTowards(transform.position, Position.transform.position, 0.01f);
                },
                IsFinished = () => gameObject.transform.position == Position.transform.position
            });

        Vector3 velocityKicked = Vector3.zero;
        gameScript.Movements.Enqueue(
            new Game.StoneMovement()
            {
                Movement = () =>
                {
                    KickedPlayer.transform.position = Vector3.SmoothDamp(KickedPlayer.transform.position, Vector3.zero,
                        ref velocityKicked, smoothTime, speed);
                },
                IsFinished = () => KickedPlayer.transform.position == Vector3.zero
            });
    }
}
