﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Helicopter
{
    public class BSpriteManager
    {
        private ContentManager Content;
        private BackgroundSpriteA[] bSpriteAs = new BackgroundSpriteA[9];
        private BackgroundSpriteA[] midBSpriteAs = new BackgroundSpriteA[2];
        private BRainbow bRainbow;
        private BigRainbow bigRainbow;
        private SausageRainbow sausageRainbowLarge;
        private SausageRainbow sausageRainbowSmall;
        private PirateBoat pirateBoat;
        private bool isSkullHead = false;

        public BSpriteManager(Game1 game)
        {
            this.Content = new ContentManager((IServiceProvider)game.Services, "Content//Graphics//BackgroundSprites");
            Global.backgroundSpritesTexture = this.Content.Load<Texture2D>("backgroundSpritesXbox");
            this.bRainbow = new BRainbow();
            this.bigRainbow = new BigRainbow();
            this.sausageRainbowLarge = new SausageRainbow(true);
            this.sausageRainbowSmall = new SausageRainbow(false);
            this.pirateBoat = new PirateBoat();
            for (int index = 0; index < this.midBSpriteAs.Length; ++index)
                this.midBSpriteAs[index] = new BackgroundSpriteA();
            for (int index = 0; index < this.bSpriteAs.Length; ++index)
                this.bSpriteAs[index] = new BackgroundSpriteA();
        }

        public void Update(float dt)
        {
            foreach (BackgroundSpriteA bSpriteA in this.bSpriteAs)
                bSpriteA.Update(dt);
            foreach (BackgroundSpriteA midBspriteA in this.midBSpriteAs)
                midBspriteA.Update(dt);
            this.bRainbow.Update(dt);
            this.bigRainbow.Update(dt);
            this.sausageRainbowLarge.Update(dt);
            this.sausageRainbowSmall.Update(dt);
            this.pirateBoat.Update(dt);
        }

        public void DrawBack(SpriteBatch spriteBatch)
        {
            this.sausageRainbowSmall.Draw(spriteBatch);
            if (!this.isSkullHead)
                return;
            foreach (BackgroundSpriteA midBspriteA in this.midBSpriteAs)
                midBspriteA.Draw(spriteBatch);
        }

        public void DrawMiddleBack(SpriteBatch spriteBatch) => this.sausageRainbowLarge.Draw(spriteBatch);

        public void DrawMiddle(SpriteBatch spriteBatch)
        {
            this.bRainbow.Draw(spriteBatch);
            this.bigRainbow.Draw(spriteBatch);
            if (this.isSkullHead)
                return;
            foreach (BackgroundSpriteA midBspriteA in this.midBSpriteAs)
                midBspriteA.Draw(spriteBatch);
        }

        public void DrawFore(SpriteBatch spriteBatch)
        {
            foreach (BackgroundSpriteA bSpriteA in this.bSpriteAs)
                bSpriteA.Draw(spriteBatch);
            this.pirateBoat.Draw(spriteBatch);
        }

        public void Reset()
        {
            this.bRainbow.TurnOff();
            this.bigRainbow.TurnOff();
            this.sausageRainbowSmall.TurnOff();
            this.sausageRainbowLarge.TurnOff();
            this.pirateBoat.TurnOff();
            foreach (BackgroundSpriteA bSpriteA in this.bSpriteAs)
                bSpriteA.Reset();
            foreach (BackgroundSpriteA midBspriteA in this.midBSpriteAs)
                midBspriteA.Reset();
        }

        public void SetBRainbow() => this.bRainbow.Reset();

        public void SetBigRainbow() => this.bigRainbow.Reset();

        public void SetSausageRainbowLarge() => this.sausageRainbowLarge.Reset();

        public void SetSausageRainbowSmall() => this.sausageRainbowSmall.Reset();

        public void setPirateBoat() => this.pirateBoat.Reset();

        public void LoadNewBackground(int backgroundIndex)
        {
            Global.backgroundSpritesTexture.Dispose();
            this.Content.Unload();
            switch (backgroundIndex)
            {
                case 0:
                    this.isSkullHead = false;
                    Global.backgroundSpritesTexture = this.Content.Load<Texture2D>("backgroundSpritesXbox");
                    this.midBSpriteAs[0].SetToUnicorn();
                    this.midBSpriteAs[1].SetToInactive();
                    this.bSpriteAs[0].SetToBird();
                    this.bSpriteAs[1].SetToBird();
                    this.bSpriteAs[2].SetToBird();
                    this.bSpriteAs[3].SetToPartyBoat();
                    this.bSpriteAs[4].SetToSpeedBoat();
                    this.bSpriteAs[5].SetToUFO();
                    this.bSpriteAs[6].SetToDolphin();
                    this.bSpriteAs[7].SetToNarwal();
                    this.bSpriteAs[8].SetToBlimp();
                    break;
                case 1:
                    this.isSkullHead = false;
                    Global.backgroundSpritesTexture = this.Content.Load<Texture2D>("backgroundSpritesXbox");
                    this.midBSpriteAs[0].SetToInactive();
                    this.midBSpriteAs[1].SetToInactive();
                    this.bSpriteAs[0].SetToAlligator();
                    this.bSpriteAs[1].SetToAngel();
                    this.bSpriteAs[2].SetToCupid();
                    this.bSpriteAs[3].SetToButterfly();
                    this.bSpriteAs[4].SetToHeart();
                    this.bSpriteAs[5].SetToInactive();
                    this.bSpriteAs[6].SetToPterodactyl();
                    this.bSpriteAs[7].SetToUFO();
                    this.bSpriteAs[8].SetToBlimp();
                    break;
                case 2:
                    this.isSkullHead = false;
                    Global.backgroundSpritesTexture = this.Content.Load<Texture2D>("backgroundSpritesXbox");
                    this.midBSpriteAs[0].SetToGiraffe();
                    this.midBSpriteAs[1].SetToDemon();
                    this.bSpriteAs[0].SetToDragon();
                    this.bSpriteAs[1].SetToDemonTwo();
                    this.bSpriteAs[2].SetToGargoyle();
                    this.bSpriteAs[3].SetToPheonix();
                    this.bSpriteAs[4].SetToPheonix();
                    this.bSpriteAs[5].SetToSubmarine();
                    this.bSpriteAs[6].SetToShark();
                    this.bSpriteAs[7].SetToInactive();
                    this.bSpriteAs[8].SetToInactive();
                    break;
                case 3:
                    this.isSkullHead = false;
                    Global.backgroundSpritesTexture = this.Content.Load<Texture2D>("MeatBackgroundSprites");
                    this.midBSpriteAs[0].SetToFish();
                    this.midBSpriteAs[1].SetToInactive();
                    this.bSpriteAs[0].SetToHotDog();
                    this.bSpriteAs[1].SetToInactive();
                    this.bSpriteAs[2].SetToDrumsticks();
                    this.bSpriteAs[3].SetToMeat();
                    this.bSpriteAs[4].SetToPig();
                    this.bSpriteAs[5].SetToBacon();
                    this.bSpriteAs[6].SetToChicken();
                    this.bSpriteAs[7].SetToDuck();
                    this.bSpriteAs[8].SetToSausage();
                    break;
                case 4:
                    this.isSkullHead = true;
                    Global.backgroundSpritesTexture = this.Content.Load<Texture2D>("RonBackgroundSprites");
                    this.midBSpriteAs[0].SetToSkull();
                    this.midBSpriteAs[1].SetToInactive();
                    this.bSpriteAs[0].SetToBusinessMan();
                    this.bSpriteAs[1].SetToSkate();
                    this.bSpriteAs[2].SetToDarkAlien();
                    this.bSpriteAs[3].SetToPurpleAlien();
                    this.bSpriteAs[4].SetToYangCircle();
                    this.bSpriteAs[5].SetToYangHeart();
                    this.bSpriteAs[6].SetToGun();
                    this.bSpriteAs[7].SetToPlane();
                    this.bSpriteAs[8].SetToTongue();
                    break;
            }
        }
    }
}
