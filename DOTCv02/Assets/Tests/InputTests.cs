using NSubstitute;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class InputTests
{
    [UnityTest]
    public IEnumerator MoveCharacterAlongHorizontalAxis_Unity()
    {
        var player = new GameObject();
        player.gameObject.AddComponent<PlayerData>().characterSpeed = 5.0f;
        var movementInputManager = player.AddComponent<KeyboardMovementInputManager>();
        var unityServices = Substitute.For<IUnityServices>();
        unityServices.GetAxisRaw("Horizontal").Returns(1);
        movementInputManager._unityServices = unityServices;
        player.gameObject.AddComponent<CharacterMovementController>();

        yield return new WaitForSeconds(1.1f);
        
        Assert.AreEqual(5, player.transform.position.x, 0.1f);
    }

    //[Test]
    //public void MoveCharacterAlongHorizontalAxis()
    //{
    //    Movement movement = new Movement(5.0f);
    //    Assert.AreEqual(5, movement.GetMovementVector(1, 0).x, 0.1f);
    //}
}
