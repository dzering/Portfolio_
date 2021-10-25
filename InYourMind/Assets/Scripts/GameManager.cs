using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] SpriteRenderConfig playerAnimationsConfig;
    [SerializeField] SpriteRenderConfig coinsAnimationConfig;
    [SerializeField] SpriteRenderConfig waterAnimationConfig;

    [SerializeField] float animationSpeed;
    [SerializeField] ObjectView playerView;
    [SerializeField] ObjectView waterView;
    [SerializeField] CanonView canonView;
    [SerializeField] List<CoinView> coinsView;
    [SerializeField] ObjectView liftView;


    CameraController cameraController;
    PlayerController playerController;
    CannonController cannonController;
    WaterController waterController;
    BulletEmitterController bulletEmitterController;
    SpriteAnimatorController playerAnimator;
    SpriteAnimatorController coinsAnimator;
    SpriteAnimatorController waterAnimator;
    CoinsController coinsController;
    LiftController liftController;

    public Transform[] paralaxBG;

    private void Start()
    {
        cameraController = new CameraController(playerView.transform, Camera.main.transform);

        playerAnimationsConfig = Resources.Load<SpriteRenderConfig>("PlayerAnimationsCfg");
        coinsAnimationConfig = Resources.Load<SpriteRenderConfig>("CoinsAnimationCfg");
        waterAnimationConfig = Resources.Load<SpriteRenderConfig>("WaterAnimatorCfg");

        if(playerAnimationsConfig) playerAnimator = new SpriteAnimatorController(playerAnimationsConfig);
        if(coinsAnimationConfig) coinsAnimator = new SpriteAnimatorController(coinsAnimationConfig);
        if(waterAnimationConfig) waterAnimator = new SpriteAnimatorController(waterAnimationConfig);

        playerController = new PlayerController(playerView, playerAnimator);
        cannonController = new CannonController(canonView.muzzleTransform, playerView.transform);
        bulletEmitterController = new BulletEmitterController(canonView.bullets, canonView.emitterTransform);
        coinsController = new CoinsController(playerView, coinsAnimator, coinsView);
        waterController = new WaterController(waterView, waterAnimator);
        liftController = new LiftController(liftView);

    }

    private void Update()
    {
        playerController.Update();
        cameraController.Update();
        cannonController.Update();
        bulletEmitterController.Update();
        coinsAnimator.Update();
        waterAnimator.Update();
        liftController.Update();
    }

}
