using NSubstitute;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class InputTests
{
    [UnityTest]
    public IEnumerator MoveCharacterAlongHorizontalAxis()
    {
        var player = new GameObject();
        player.tag = "Player";
        var defaultData = ScriptableObject.CreateInstance("PlayerData") as PlayerData;
        defaultData.movementSpeed = 5.0f;
        player.AddComponent<PlayerStats>().InitializePlayerStats(defaultData);
        var movementInputManager = player.AddComponent<KeyboardMovementInputManager>();
        var unityServices = Substitute.For<IUnityServices>();
        unityServices.GetAxisRaw("Horizontal").Returns(1);
        movementInputManager._unityServices = unityServices;
        player.gameObject.AddComponent<CharacterMovementController>();

        yield return new WaitForSeconds(1.1f);
        
        Assert.AreEqual(5, player.transform.position.x, 0.1f);
    }

    [UnityTest]
    public IEnumerator MoveCharacterAlongVerticalAxis()
    {
        var player = new GameObject();
        player.tag = "Player";
        var defaultData = ScriptableObject.CreateInstance("PlayerData") as PlayerData;
        defaultData.movementSpeed = 5.0f;
        player.AddComponent<PlayerStats>().InitializePlayerStats(defaultData);
        var movementInputManager = player.AddComponent<KeyboardMovementInputManager>();
        var unityServices = Substitute.For<IUnityServices>();
        unityServices.GetAxisRaw("Vertical").Returns(1);
        movementInputManager._unityServices = unityServices;
        player.gameObject.AddComponent<CharacterMovementController>();

        yield return new WaitForSeconds(1f);

        Assert.AreEqual(4.5, player.transform.position.z, 0.1f);
    }

    [UnityTest]
    public IEnumerator ShootMagicBall()
    {
        var player = new GameObject();
        var shootPos = new GameObject("ShootPosition");
        shootPos.transform.SetParent(player.transform);
        var defaultData = ScriptableObject.CreateInstance("PlayerData") as PlayerData;
        defaultData.damageIncreasePercentage = 0.0f;
        player.AddComponent<PlayerStats>().InitializePlayerStats(defaultData);
        var eventListener = new GameObject("EventListener", typeof(EventListeners));
        var actionsInputManager = player.AddComponent<KeyboradActionsInputManager>();
        var characterAbilityController = player.gameObject.AddComponent<CharacterAbilityController>();
        var shootMagicBallAbility = new GameObject("ShootMagicBallAbility",
            typeof(ShootMagicBallAbility));
        
        ShootAbility_HealDamageMakerAbilityData shootAbilityData =
            ScriptableObject.CreateInstance("ShootAbility_HealDamageMakerAbilityData") as ShootAbility_HealDamageMakerAbilityData;
        shootAbilityData.abilityName = "Shoot Magic Ball";
        var magicBallPrefab = new GameObject("MagicBall", typeof(MagicBall), typeof(Rigidbody));
        magicBallPrefab.tag = "MagicBall";
        shootAbilityData.gameObjectToShoot = magicBallPrefab;
        shootMagicBallAbility.GetComponent<ShootMagicBallAbility>().abilityData = shootAbilityData;

        characterAbilityController.abilityPrefabs.Add(shootMagicBallAbility);

        var unityServices = Substitute.For<IUnityServices>();
        unityServices.GetKeyDown(KeyCode.Alpha1).Returns(true);
        actionsInputManager._unityServices = unityServices;
        
        yield return new WaitForSeconds(0.1f);

        GameObject magicBall = GameObject.FindGameObjectWithTag("MagicBall");
        Assert.IsNotNull(magicBall);
    }

    [TearDown]
    public void RemoveCreatedObjects()
    {
        foreach (ShootableObject shootableObject in GameObject.FindObjectsOfType<ShootableObject>())
            Object.Destroy(shootableObject);

        var playerGO = GameObject.FindGameObjectWithTag("Player");
        if (playerGO != null) Object.Destroy(playerGO);

        var eventListener = GameObject.FindObjectOfType<EventListeners>();
        if (eventListener != null) Object.Destroy(eventListener);
    }
    //[Test]
    //public void MoveCharacterAlongHorizontalAxis()
    //{
    //    Movement movement = new Movement(5.0f);
    //    Assert.AreEqual(5, movement.GetMovementVector(1, 0).x, 0.1f);
    //}
}
