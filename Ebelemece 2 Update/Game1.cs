using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Ebelemece_2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //DSpeed = Yorulmayan
        //DAcc = YarýAktif
        //ADHK = Enerjik
        //ASpeed = Atýlgan
        //SDHK = ZamanlaIsýnan
        //SAcc = Saldýrgan

        // genel
        bool baslangic = true;
        int menu = -1;
        SpriteFont font;
        SpriteFont baslik;
        Texture2D araclar;
        string[] isim = new string[24];
        string[] dosyakonumu = new string[24];
        Vector3 tablodegeri = new Vector3(0, 0, 0);
        string[] tur = new string[24];

        // menü
        Vector3[] tablo = new Vector3[24];
        int sýra = 0;
        Vector2 arackoordinat = new Vector2(0, 50);
        Texture2D tab;

        // oyun
        Texture2D zemin;
        Texture2D tahb;
        int[] hizsayar = { 0, 0, 0, 0, 0, 0, 0, 0 };
        string[] ad = new string[8];
        string[] dosya = new string[8];
        int sayac = 0;
        int bomba = 9;
        Vector2[] arabakoordinat = new Vector2[8];
        float[] hiz = new float[24];
        float[] oan = new float[8];
        float[] maximumhiz = new float[8];
        int sss = 0;
        float[] hizlanma = new float[8];
        float[] hizkazanci = new float[8];
        float[] acc = new float[24];
        float[] yon = new float[8];
        float[] donustehizkaybi = new float[24];
        int[] yariscisiram = new int[8];
        string text = "Oyun Basladi Bomba Bekleniyor";
        bool oyunbasladi = true;
        int[] seviye = new int[24];
        public static int veritabani = 1;
        bool ayna = false;
        bool dortkýsýlýk = false;
        bool random = false;
        int q = 0;
        int[] puan = new int[8];

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            veriler.arama();
            tahb = Content.Load<Texture2D>("Game");
            font = Content.Load<SpriteFont>("Courier New");
            baslik = Content.Load<SpriteFont>("SpriteFont1");
            tab = Content.Load<Texture2D>("gray");
            zemin = Content.Load<Texture2D>("land");

            //Oyundakiler
            arabakoordinat[0] = new Vector2(100, 100);
            arabakoordinat[1] = new Vector2(100, 500);
            arabakoordinat[2] = new Vector2(300, 100);
            arabakoordinat[3] = new Vector2(300, 500);
            arabakoordinat[4] = new Vector2(500, 100);
            arabakoordinat[5] = new Vector2(500, 500);
            arabakoordinat[6] = new Vector2(700, 100);
            arabakoordinat[7] = new Vector2(700, 500);

            //SC 2000
            isim[0] = "SC 2000";
            dosyakonumu[0] = "sc";
            tablo[0] = new Vector3(75, 16, 6);
            hiz[0] = 8.6f;
            acc[0] = 3;
            donustehizkaybi[0] = 0.15f;
            seviye[0] = 1;
            tur[0] = "Enerjik";

            //X
            isim[1] = "X";
            dosyakonumu[1] = "x";
            tablo[1] = new Vector3(105, 6, 8);
            hiz[1] = 9.2f;
            acc[1] = 20;
            donustehizkaybi[1] = 0.1f;
            seviye[1] = 1;
            tur[1] = "YarýAktif";

            //Cyan
            isim[2] = "Cyan";
            dosyakonumu[2] = "cyan";
            tablo[2] = new Vector3(100, 8, 7);
            hiz[2] = 9.1f;
            acc[2] = 16f;
            donustehizkaybi[2] = 0.12f;
            seviye[2] = 1;
            tur[2] = "Enerjik";

            //RGB
            isim[3] = "RGB";
            dosyakonumu[3] = "rgb";
            tablo[3] = new Vector3(125, 6, 7);
            hiz[3] = 9.6f;
            acc[3] = 20f;
            donustehizkaybi[3] = 0.12f;
            seviye[3] = 1;
            tur[3] = "YarýAktif";

            //Eagle
            isim[4] = "Eagle";
            dosyakonumu[4] = "eagle";
            tablo[4] = new Vector3(150, 8, 7);
            hiz[4] = 10.1f;
            acc[4] = 16f;
            donustehizkaybi[4] = 0.12f;
            seviye[4] = 2;
            tur[4] = "Enerjik";

            //Woody
            isim[5] = "Woody";
            dosyakonumu[5] = "woody";
            tablo[5] = new Vector3(175, 8, 6);
            hiz[5] = 10.6f;
            acc[5] = 16f;
            donustehizkaybi[5] = 0.15f;
            seviye[5] = 2;
            tur[5] = "Atýlgan";

            //Guide
            isim[6] = "Guide";
            dosyakonumu[6] = "guide";
            tablo[6] = new Vector3(210, 5, 7);
            hiz[6] = 11.3f;
            acc[6] = 22f;
            donustehizkaybi[6] = 0.12f;
            seviye[6] = 2;
            tur[6] = "ZamanlaIsýnan";

            //Golden
            isim[7] = "Golden";
            dosyakonumu[7] = "golden";
            tablo[7] = new Vector3(200, 9, 5);
            hiz[7] = 11.1f;
            acc[7] = 14f;
            donustehizkaybi[7] = 0.17f;
            seviye[7] = 2;
            tur[7] = "Atýlgan";

            //Sketch
            isim[8] = "Sketch";
            dosyakonumu[8] = "sketch";
            tablo[8] = new Vector3(205, 11, 8);
            hiz[8] = 11.2f;
            acc[8] = 10;
            donustehizkaybi[8] = 0.1f;
            seviye[8] = 3;
            tur[8] = "Enerjik";

            //Darker
            isim[9] = "Darker";
            dosyakonumu[9] = "darker";
            tablo[9] = new Vector3(225, 9, 8);
            hiz[9] = 11.6f;
            acc[9] = 14f;
            donustehizkaybi[9] = 0.1f;
            seviye[9] = 3;
            tur[9] = "Atýlgan";

            //Mafia
            isim[10] = "Mafia";
            dosyakonumu[10] = "mafia";
            tablo[10] = new Vector3(235, 5, 10);
            hiz[10] = 11.8f;
            acc[10] = 22;
            donustehizkaybi[10] = 0.05f;
            seviye[10] = 3;
            tur[10] = "Yorulmayan";

            //Mixer
            isim[11] = "Mixer";
            dosyakonumu[11] = "mixer";
            tablo[11] = new Vector3(230, 10, 6);
            hiz[11] = 11.7f;
            acc[11] = 12f;
            donustehizkaybi[11] = 0.15f;
            seviye[11] = 3;
            tur[11] = "Atýlgan";

            //Champion
            isim[12] = "Champion";
            dosyakonumu[12] = "champ";
            tablo[12] = new Vector3(250, 10, 8);
            hiz[12] = 12.1f;
            acc[12] = 12f;
            donustehizkaybi[12] = 0.1f;
            seviye[12] = 4;
            tur[12] = "Atýlgan";

            //Leader
            isim[13] = "Leader";
            dosyakonumu[13] = "leader";
            tablo[13] = new Vector3(275, 12, 5);
            hiz[13] = 12.6f;
            acc[13] = 8f;
            donustehizkaybi[13] = 0.17f;
            seviye[13] = 4;
            tur[13] = "Atýlgan";

            //Zr Lost
            isim[14] = "Zr Lost";
            dosyakonumu[14] = "zr";
            tablo[14] = new Vector3(300, 2, 13);
            hiz[14] = 13.1f;
            acc[14] = 40f;
            donustehizkaybi[14] = 0f;
            seviye[14] = 4;
            tur[14] = "Yorulmayan";

            //XNA'nýn açýlýmýný bilen var mý? Düþündüm, bir türlü bulamadým.

            //Snake
            isim[15] = "Snake";
            dosyakonumu[15] = "snake";
            tablo[15] = new Vector3(375, 8, 5);
            hiz[15] = 14.6f;
            acc[15] = 16f;
            donustehizkaybi[15] = 0.17f;
            seviye[15] = 4;
            tur[15] = "Saldýrgan";

            //Cobra
            isim[16] = "Cobra";
            dosyakonumu[16] = "cobra";
            tablo[16] = new Vector3(400, 9, 4);
            hiz[16] = 15.1f;
            acc[16] = 14f;
            donustehizkaybi[16] = 0.2f;
            seviye[16] = 0;
            tur[16] = "none";

            //Dark Sketch
            isim[17] = "Dark Sketch";
            dosyakonumu[17] = "dark sketch";
            tablo[17] = new Vector3(250, 13, 10);
            hiz[17] = 12.1f;
            acc[17] = 6f;
            donustehizkaybi[17] = 0.05f;
            seviye[17] = 0;
            tur[17] = "none";

            //SC 3000
            isim[18] = "SC 3000";
            dosyakonumu[18] = "sc 3000";
            tablo[18] = new Vector3(100, 20, 8);
            hiz[18] = 9.1f;
            acc[18] = 2f;
            donustehizkaybi[18] = 0.1f;
            seviye[18] = 0;
            tur[18] = "none";

            //Y
            isim[19] = "Y";
            dosyakonumu[19] = "y";
            tablo[19] = new Vector3(175, 9, 7);
            hiz[19] = 10.6f;
            acc[19] = 14f;
            donustehizkaybi[19] = 0.12f;
            seviye[19] = 0;
            tur[19] = "none";

            //Gangster
            isim[20] = "Gangster";
            dosyakonumu[20] = "gangster";
            tablo[20] = new Vector3(285, 5, 12);
            hiz[20] = 12.8f;
            acc[20] = 22f;
            donustehizkaybi[20] = 0.025f;
            seviye[20] = 0;
            tur[20] = "none";

            //WGB
            isim[21] = "WGB";
            dosyakonumu[21] = "wgb";
            tablo[21] = new Vector3(175, 9, 11);
            hiz[21] = 10.6f;
            acc[21] = 14f;
            donustehizkaybi[21] = 0.03f;
            seviye[21] = 0;
            tur[21] = "none";

            //Planor
            isim[22] = "Planor";
            dosyakonumu[22] = "planor";
            tablo[22] = new Vector3(305, 12, 6);
            hiz[22] = 13.2f;
            acc[22] = 8f;
            donustehizkaybi[22] = 0.15f;
            seviye[22] = 0;
            tur[22] = "none";

            //Locust
            isim[23] = "Locust";
            dosyakonumu[23] = "locust";
            tablo[23] = new Vector3(365, 4, 6);
            hiz[23] = 14.4f;
            acc[23] = 24f;
            donustehizkaybi[23] = 0.15f;
            seviye[23] = 0;
            tur[23] = "none";
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        bool basildi = false;
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        Vector2 iarackoordinat = new Vector2(0, 0);
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (iarackoordinat.X < arackoordinat.X)
            {
                iarackoordinat.X += 25;
            }
            else if (arackoordinat.X < iarackoordinat.X)
            {
                iarackoordinat.X -= 25;
            }
            if (iarackoordinat.Y < arackoordinat.Y)
            {
                iarackoordinat.Y += 25;
            }
            else if (arackoordinat.Y < iarackoordinat.Y)
            {
                iarackoordinat.Y -= 25;
            }
            KeyboardState klavye = Keyboard.GetState();
            if (klavye.IsKeyDown(Keys.S) && (menu == 10 || menu == 11))
            {
                menu = 0;
            }
            if (klavye.IsKeyDown(Keys.U) && menu != 2)
            {
                menu = 11;
            }
            if (klavye.IsKeyDown(Keys.Y) && menu != 2)
            {
                menu = 10;
            }
            if (klavye.IsKeyDown(Keys.R))
            {
                random = true;
            }
            else if (klavye.IsKeyDown(Keys.T))
            {
                random = false;
            }
            if (klavye.IsKeyDown(Keys.F5))
            {
                graphics.IsFullScreen = false;
                graphics.ApplyChanges();
            }
            else if (klavye.IsKeyDown(Keys.F6))
            {
                graphics.IsFullScreen = true;
                graphics.ApplyChanges();
            }
            if (klavye.IsKeyDown(Keys.N))
            {
                ayna = true;
            }
            else if (klavye.IsKeyDown(Keys.M))
            {
                ayna = false;
            }
            if (klavye.IsKeyDown(Keys.Q))
            {
                dortkýsýlýk = true;
            }
            else if (klavye.IsKeyDown(Keys.W))
            {
                dortkýsýlýk = false;
            }
            if (klavye.IsKeyDown(Keys.D))
            {
                veritabani = 1;
                veriler.guncellestirme();
            }
            if (klavye.IsKeyDown(Keys.Escape))
            {
                veriler.guncellestirme();
                this.Exit();
            }

            if (menu == -1 && klavye.IsKeyDown(Keys.Space))
            {
                menu = 0;
            }

            if (menu == 0)
            {
                float ef = tablo[sýra].X * 10 - tablodegeri.X;
                if (ef < 0.2f && ef > -0.2f)
                {
                    tablodegeri.X = tablo[sýra].X * 10;
                }
                else
                {
                    tablodegeri.X += ef / 10;
                }
                float ef1 = tablo[sýra].Y * 10 - tablodegeri.Y;
                if (ef1 < 0.05f && ef1 > -0.05f)
                {
                    tablodegeri.Y = tablo[sýra].Y * 10;
                }
                else
                {
                    tablodegeri.Y += ef1 / 10;
                }
                float ef2 = tablo[sýra].Z * 10 - tablodegeri.Z;
                if (ef2 < 0.1f && ef2 > -0.1f)
                {
                    tablodegeri.Z = tablo[sýra].Z * 10;
                }
                else
                {
                    tablodegeri.Z += ef2 / 10;
                }
                if (klavye.IsKeyDown(Keys.Left))
                {
                    if (sýra > 15)
                    {
                    }
                    else
                    {
                        if (!basildi)
                        {
                            basildi = true;
                            arackoordinat.X -= 375;
                            sýra--;
                        }
                    }
                }
                else if (klavye.IsKeyDown(Keys.Right))
                {
                    if (sýra > 15)
                    {
                    }
                    else
                    {
                        if (!basildi)
                        {
                            if (sýra == 15)
                            {
                                sýra = 14;
                                arackoordinat.X -= 375;
                            }
                            basildi = true;
                            arackoordinat.X += 375;
                            sýra++;
                        }
                    }
                }
                else
                {
                    basildi = false;
                }
                if (sýra == 0 && klavye.IsKeyDown(Keys.Up) && veritabani > 6)
                {
                    sýra = 18;
                }
                else if (sýra == 18 && klavye.IsKeyDown(Keys.Down))
                {
                    sýra = 0;
                }
                if (sýra == 15 && klavye.IsKeyDown(Keys.Up) && veritabani > 6)
                {
                    sýra = 16;
                }
                else if (sýra == 16 && klavye.IsKeyDown(Keys.Down))
                {
                    sýra = 15;
                }
                if (sýra == 8 && klavye.IsKeyDown(Keys.Up) && veritabani > 6)
                {
                    sýra = 17;
                }
                else if (sýra == 17 && klavye.IsKeyDown(Keys.Down))
                {
                    sýra = 8;
                }
                if (sýra == 10 && klavye.IsKeyDown(Keys.Up) && veritabani > 6)
                {
                    sýra = 20;
                }
                else if (sýra == 20 && klavye.IsKeyDown(Keys.Down))
                {
                    sýra = 10;
                }
                if (sýra == 3 && klavye.IsKeyDown(Keys.Up) && veritabani > 6)
                {
                    sýra = 21;
                }
                else if (sýra == 21 && klavye.IsKeyDown(Keys.Down))
                {
                    sýra = 3;
                }
                if (sýra == 1 && klavye.IsKeyDown(Keys.Up) && veritabani > 6)
                {
                    sýra = 19;
                }
                else if (sýra == 19 && klavye.IsKeyDown(Keys.Down))
                {
                    sýra = 1;
                }
                if (sýra == 6 && klavye.IsKeyDown(Keys.Up) && veritabani > 6)
                {
                    sýra = 23;
                }
                else if (sýra == 23 && klavye.IsKeyDown(Keys.Down))
                {
                    sýra = 6;
                }
                if (sýra == 12 && klavye.IsKeyDown(Keys.Up) && veritabani > 6)
                {
                    sýra = 22;
                }
                else if (sýra == 22 && klavye.IsKeyDown(Keys.Down))
                {
                    sýra = 12;
                }
                if (sýra < 0)
                {
                    sýra = 0;
                    arackoordinat.X = 0;
                }
                if (klavye.IsKeyDown(Keys.Enter))
                {
                    Random qnd = new Random();
                    q = qnd.Next(1,5);
                    if (seviye[sýra] <= veritabani)
                    {
                        menu = 1;
                        if (!random)
                        {
                            if (!ayna)
                            {
                            bas:
                                Random rnd = new Random();
                                yariscisiram[0] = sýra;
                                if (seviye[sýra] == 1)
                                {
                                    yariscisiram[1] = rnd.Next(0, 4);
                                    yariscisiram[2] = rnd.Next(0, 4);
                                    yariscisiram[3] = rnd.Next(0, 4);
                                    yariscisiram[4] = rnd.Next(4, 8);
                                    yariscisiram[5] = rnd.Next(4, 8);
                                    yariscisiram[6] = rnd.Next(4, 8);
                                    yariscisiram[7] = rnd.Next(4, 8);
                                }
                                else if (seviye[sýra] == 2)
                                {
                                    yariscisiram[1] = rnd.Next(0, 4);
                                    yariscisiram[2] = rnd.Next(0, 4);
                                    yariscisiram[3] = rnd.Next(4, 8);
                                    yariscisiram[4] = rnd.Next(4, 8);
                                    yariscisiram[5] = rnd.Next(4, 8);
                                    yariscisiram[6] = rnd.Next(8, 12);
                                    yariscisiram[7] = rnd.Next(8, 12);
                                }
                                else if (seviye[sýra] == 3)
                                {
                                    yariscisiram[1] = rnd.Next(8, 12);
                                    yariscisiram[2] = rnd.Next(0, 4);
                                    yariscisiram[3] = rnd.Next(4, 8);
                                    yariscisiram[4] = rnd.Next(4, 8);
                                    yariscisiram[5] = rnd.Next(0, 4);
                                    yariscisiram[6] = rnd.Next(12, 16);
                                    yariscisiram[7] = rnd.Next(12, 16);
                                }
                                else
                                {
                                    yariscisiram[1] = rnd.Next(8, 12);
                                    yariscisiram[2] = rnd.Next(4, 8);
                                    yariscisiram[3] = rnd.Next(0, 4);
                                    yariscisiram[4] = rnd.Next(8, 12);
                                    yariscisiram[5] = rnd.Next(8, 12);
                                    yariscisiram[6] = rnd.Next(12, 16);
                                    yariscisiram[7] = rnd.Next(12, 16);
                                }
                                if ((seviye[sýra] < 5) && (yariscisiram[0] == yariscisiram[1] || yariscisiram[0] == yariscisiram[2] || yariscisiram[0] == yariscisiram[3] || yariscisiram[0] == yariscisiram[4] || yariscisiram[0] == yariscisiram[5] || yariscisiram[0] == yariscisiram[6] || yariscisiram[0] == yariscisiram[7] || yariscisiram[1] == yariscisiram[2] || yariscisiram[1] == yariscisiram[3] || yariscisiram[1] == yariscisiram[4] || yariscisiram[1] == yariscisiram[5] || yariscisiram[1] == yariscisiram[6] || yariscisiram[1] == yariscisiram[7] || yariscisiram[2] == yariscisiram[3] || yariscisiram[2] == yariscisiram[4] || yariscisiram[2] == yariscisiram[5] || yariscisiram[2] == yariscisiram[6] || yariscisiram[2] == yariscisiram[7] || yariscisiram[3] == yariscisiram[4] || yariscisiram[3] == yariscisiram[5] || yariscisiram[3] == yariscisiram[6] || yariscisiram[3] == yariscisiram[7] || yariscisiram[4] == yariscisiram[5] || yariscisiram[4] == yariscisiram[6] || yariscisiram[4] == yariscisiram[7] || yariscisiram[5] == yariscisiram[6] || yariscisiram[5] == yariscisiram[7] || yariscisiram[6] == yariscisiram[7]))
                                {
                                    goto bas;
                                }
                            }
                            else
                            {
                                yariscisiram[0] = sýra;
                                yariscisiram[1] = sýra;
                                yariscisiram[2] = sýra;
                                yariscisiram[3] = sýra;
                                yariscisiram[4] = sýra;
                                yariscisiram[5] = sýra;
                                yariscisiram[6] = sýra;
                                yariscisiram[7] = sýra;
                            }
                        }
                        else
                        {
                            Random rnd = new Random();
                            yariscisiram[0] = sýra;
                            yariscisiram[1] = rnd.Next(0, 16);
                            yariscisiram[2] = rnd.Next(0, 16);
                            yariscisiram[3] = rnd.Next(0, 16);
                            yariscisiram[4] = rnd.Next(0, 16);
                            yariscisiram[5] = rnd.Next(0, 16);
                            yariscisiram[6] = rnd.Next(0, 16);
                            yariscisiram[7] = rnd.Next(0, 16);
                        }
                    }
                    else
                    {
                    }
                }
            }

            if (menu == 1)
            {
                if (klavye.IsKeyDown(Keys.Space))
                {
                    oyunbasladi = true;
                    menu = 2;
                    for (int i = 0; i < 8; i++)
                    {
                        int ii = yariscisiram[i];
                        maximumhiz[i] = hiz[ii];
                        hizlanma[i] = acc[ii];
                        hizkazanci[i] = donustehizkaybi[ii];
                        ad[i] = isim[ii];
                        dosya[i] = dosyakonumu[ii];
                        yon[i] = 0;
                        oan[i] = 0;
                    }
                    sayac = 3600;
                }
            }

            if (menu == 2)
            {
                if (klavye.IsKeyDown(Keys.Z))
                {
                    q = 0;
                    baslangic = true;
                    oan[0] = 0;
                    for (int i = 1; i < 8; i++)
                    {
                        oan[i] = 0;
                    }
                    oyunbasladi = true;
                    bomba = 9;
                    text = "Oyun Basladi Bomba Bekleniyor";
                    menu = -1;
                    arabakoordinat[0] = new Vector2(100, 100);
                    arabakoordinat[1] = new Vector2(100, 500);
                    arabakoordinat[2] = new Vector2(300, 100);
                    arabakoordinat[3] = new Vector2(300, 500);
                    arabakoordinat[4] = new Vector2(500, 100);
                    arabakoordinat[5] = new Vector2(500, 500);
                    arabakoordinat[6] = new Vector2(700, 100);
                    arabakoordinat[7] = new Vector2(700, 500);
                    puan[0] = 0;
                    puan[1] = 0;
                    puan[2] = 0;
                    puan[3] = 0;
                    puan[4] = 0;
                    puan[5] = 0;
                    puan[6] = 0;
                    puan[7] = 0;
                }
                if (dortkýsýlýk)
                {
                    arabakoordinat[2] = new Vector2(10000, 10000);
                    arabakoordinat[3] = new Vector2(-10000, 10000);
                    arabakoordinat[4] = new Vector2(-10000, -10000);
                    arabakoordinat[5] = new Vector2(10000, -10000);
                    if (bomba > 1 && bomba < 6)
                    {
                        bomba = 1;
                    }
                    if (sayac == 3300)
                    {
                        text = ad[1] + " Bomba Oldu";
                    }
                    else if (sayac < 3300)
                    {
                        text = "Bomba " + ad[1] + "'de/da";
                    }
                    else
                    {
                        text = "Oyun Basladi Bomba Bekleniyor";
                    }
                }
                if (sayac == 3300)
                {
                    Random rnd = new Random();
                    bomba = rnd.Next(0, 8);
                    text = ad[bomba] + " Bomba Oldu";
                }
                if (sss > 0)
                {
                    sss++;
                    if (sss > 30)
                    {
                        sss = 0;
                    }
                }
                sayac--;
                if (sayac == 0)
                {
                    sayac = -1;
                    if ((seviye[sýra] == veritabani && puan[0] > 600 && !dortkýsýlýk) || (seviye[sýra] == veritabani && puan[0] > 1200 && dortkýsýlýk))
                    {
                        veritabani++;
                    }
                    if (seviye[sýra] == 4)
                    {
                        veritabani = 1100000;
                    }
                    oyunbasladi = false;
                }

                if (oyunbasladi && menu == 2)
                {
                    //çarpýþma algoritmasý
                    if (sayac < 3300)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (bomba == i)
                            {
                                puan[i]++;
                            }
                            else if (arabakoordinat[bomba].X + 15 > arabakoordinat[i].X && arabakoordinat[bomba].X - 15 < arabakoordinat[i].X && arabakoordinat[bomba].Y + 15 > arabakoordinat[i].Y && arabakoordinat[bomba].Y - 15 < arabakoordinat[i].Y && sss == 0)
                            {
                                sss = 1;
                                bomba = i;
                                text = "Bomba " + ad[i] + "'de/da";
                            }
                        }
                    }

                    // oyuncu kontrolleri

                    if (klavye.IsKeyDown(Keys.Left) && sayac < 3300)
                    {
                        yon[0] -= 0.1f;
                        oan[0] -= hizkazanci[0];
                        if (oan[0] < 5 && oan[0] > 4 && hizkazanci[0] > 0)
                        {
                            oan[0] = 5;
                        }
                    }
                    if (klavye.IsKeyDown(Keys.Right) && sayac < 3300)
                    {
                        yon[0] += 0.1f;
                        oan[0] -= hizkazanci[0];
                        if (oan[0] < 5 && oan[0] > 4 && hizkazanci[0] > 0)
                        {
                            oan[0] = 5;
                        }
                    }
                    if (sayac < 3300)
                    {
                        if (klavye.IsKeyDown(Keys.Left) == false && klavye.IsKeyDown(Keys.Right) == false)
                        {
                            oan[0] += (maximumhiz[0] - oan[0]) / hizlanma[0];
                        }
                        if (oan[0] > maximumhiz[0] - 0.025f)
                        {
                            oan[0] = maximumhiz[0];
                        }
                    }
                    if (arabakoordinat[0].X < 0)
                    {
                        arabakoordinat[0].X = 0;
                        oan[0] = 1;
                    }
                    else if (arabakoordinat[0].X > 800)
                    {
                        arabakoordinat[0].X = 800;
                        oan[0] = 1;
                    }
                    if (arabakoordinat[0].Y < 0)
                    {
                        arabakoordinat[0].Y = 0;
                        oan[0] = 1;
                    }
                    else if (arabakoordinat[0].Y > 600)
                    {
                        arabakoordinat[0].Y = 600;
                        oan[0] = 1;
                    }
                    arabakoordinat[0].X += (float)(oan[0] * Math.Cos(yon[0]));
                    arabakoordinat[0].Y += (float)(oan[0] * Math.Sin(yon[0]));

                    //yapay zeka
                    if (sayac < 3300)
                    {
                        for (int i = 1; i < 8; i++)
                        {
                            if (bomba == i)
                            {
                                if (sayac < 5500 && menu == 2)
                                {
                                    Random rnd = new Random();
                                    int a = rnd.Next(1, 100);
                                    if (a < 24)
                                    {
                                        yon[i] -= 0.1f;
                                    }
                                    else if (a < 47)
                                    {
                                        yon[i] += 0.1f;
                                    }
                                    oan[i] += hizlanma[i];
                                    if (oan[i] > maximumhiz[i])
                                    {
                                        oan[i] = maximumhiz[i];
                                    }
                                    if (arabakoordinat[i].X < 50)
                                    {
                                        arabakoordinat[i].X = 50;
                                        yon[i] = 0f;
                                    }
                                    else if (arabakoordinat[i].X > 750)
                                    {
                                        arabakoordinat[i].X = 750;
                                        yon[i] = 3.14f;
                                    }
                                    if (arabakoordinat[i].Y < 50)
                                    {
                                        arabakoordinat[i].Y = 50;
                                        yon[i] = 1.57f;
                                    }
                                    else if (arabakoordinat[i].Y > 550)
                                    {
                                        arabakoordinat[i].Y = 550;
                                        yon[i] -= -1.57f;
                                    }
                                    if (arabakoordinat[i].Y >= 550 && arabakoordinat[i].X >= 750)
                                    {
                                        yon[i] = -2.25f;
                                    }
                                    if (arabakoordinat[i].Y <= 50 && arabakoordinat[i].X >= 750)
                                    {
                                        yon[i] = 2.25f;
                                    }
                                    if (arabakoordinat[i].Y >= 550 && arabakoordinat[i].X <= 50)
                                    {
                                        yon[i] = -0.75f;
                                    }
                                    if (arabakoordinat[i].Y <= 50 && arabakoordinat[i].X <= 50)
                                    {
                                        yon[i] = 0.75f;
                                    }
                                    arabakoordinat[i].X += (float)(oan[i] * Math.Cos(yon[i]));
                                    arabakoordinat[i].Y += (float)(oan[i] * Math.Sin(yon[i]));
                                }
                            }
                            else
                            {
                                oan[i] += (maximumhiz[i] - oan[i]) / hizlanma[i];
                                if (oan[i] > maximumhiz[i])
                                {
                                    oan[i] = maximumhiz[i];
                                }
                                if (sayac < 5500 && menu == 2)
                                {
                                    if (arabakoordinat[bomba].X >= arabakoordinat[i].X && arabakoordinat[bomba].Y >= arabakoordinat[i].Y && yon[i] < 0.75f)
                                    {
                                        yon[i] += 0.15f;
                                        hizsayar[i]++;
                                        if (hizsayar[i] > 20)
                                        {
                                            oan[i] -= hizkazanci[i];
                                            oan[i] -= (maximumhiz[i] - oan[i]) / hizlanma[i];
                                        }
                                        if (hizsayar[i] > 40)
                                        {
                                            hizsayar[i] = 0;
                                        }
                                        if (oan[i] < 5 && hizkazanci[i] > 0)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[bomba].X > arabakoordinat[i].X && arabakoordinat[bomba].Y > arabakoordinat[i].Y && yon[i] > 0.75f && yon[i] > 4f && yon[i] < 6.29f)
                                    {
                                        yon[i] += 0.15f;
                                        hizsayar[i]++;
                                        if (hizsayar[i] > 20)
                                        {
                                            oan[i] -= hizkazanci[i];
                                            oan[i] -= (maximumhiz[i] - oan[i]) / hizlanma[i];
                                        }
                                        if (hizsayar[i] > 40)
                                        {
                                            hizsayar[i] = 0;
                                        }
                                        if (oan[i] < 5 && hizkazanci[i] > 0)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[bomba].X > arabakoordinat[i].X && arabakoordinat[bomba].Y > arabakoordinat[i].Y && yon[i] > 0.75f)
                                    {
                                        yon[i] -= 0.15f;
                                        hizsayar[i]++;
                                        if (hizsayar[i] > 20)
                                        {
                                            oan[i] -= hizkazanci[i];
                                            oan[i] -= (maximumhiz[i] - oan[i]) / hizlanma[i];
                                        }
                                        if (hizsayar[i] > 40)
                                        {
                                            hizsayar[i] = 0;
                                        }
                                        if (oan[i] < 5 && hizkazanci[i] > 0)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[bomba].X <= arabakoordinat[i].X && arabakoordinat[bomba].Y >= arabakoordinat[i].Y && yon[i] < 2.25f)
                                    {
                                        yon[i] += 0.15f;
                                        hizsayar[i]++;
                                        if (hizsayar[i] > 20)
                                        {
                                            oan[i] -= hizkazanci[i];
                                            oan[i] -= (maximumhiz[i] - oan[i]) / hizlanma[i];
                                        }
                                        if (hizsayar[i] > 40)
                                        {
                                            hizsayar[i] = 0;
                                        }
                                        if (oan[i] < 5 && hizkazanci[i] > 0)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[bomba].X < arabakoordinat[i].X && arabakoordinat[bomba].Y > arabakoordinat[i].Y && yon[i] > 2.25f)
                                    {
                                        yon[i] -= 0.15f;
                                        hizsayar[i]++;
                                        if (hizsayar[i] > 20)
                                        {
                                            oan[i] -= hizkazanci[i];
                                            oan[i] -= (maximumhiz[i] - oan[i]) / hizlanma[i];
                                        }
                                        if (hizsayar[i] > 40)
                                        {
                                            hizsayar[i] = 0;
                                        }
                                        if (oan[i] < 5 && hizkazanci[i] > 0)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[bomba].X >= arabakoordinat[i].X && arabakoordinat[bomba].Y <= arabakoordinat[i].Y && yon[i] < 5.55f && yon[i] < 2f && yon[i] > 0f)
                                    {
                                        yon[i] -= 0.15f;
                                        hizsayar[i]++;
                                        if (hizsayar[i] > 20)
                                        {
                                            oan[i] -= hizkazanci[i];
                                            oan[i] -= (maximumhiz[i] - oan[i]) / hizlanma[i];
                                        }
                                        if (hizsayar[i] > 40)
                                        {
                                            hizsayar[i] = 0;
                                        }
                                        if (oan[i] < 5 && hizkazanci[i] > 0)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[bomba].X >= arabakoordinat[i].X && arabakoordinat[bomba].Y <= arabakoordinat[i].Y && yon[i] < 5.55f)
                                    {
                                        yon[i] += 0.15f;
                                        hizsayar[i]++;
                                        if (hizsayar[i] > 20)
                                        {
                                            oan[i] -= hizkazanci[i];
                                            oan[i] -= (maximumhiz[i] - oan[i]) / hizlanma[i];
                                        }
                                        if (hizsayar[i] > 40)
                                        {
                                            hizsayar[i] = 0;
                                        }
                                        if (oan[i] < 5 && hizkazanci[i] > 0)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[bomba].X > arabakoordinat[i].X && arabakoordinat[bomba].Y < arabakoordinat[i].Y && yon[i] > 5.55f)
                                    {
                                        yon[i] -= 0.15f;
                                        hizsayar[i]++;
                                        if (hizsayar[i] > 20)
                                        {
                                            oan[i] -= hizkazanci[i];
                                            oan[i] -= (maximumhiz[i] - oan[i]) / hizlanma[i];
                                        }
                                        if (hizsayar[i] > 40)
                                        {
                                            hizsayar[i] = 0;
                                        }
                                        if (oan[i] < 5 && hizkazanci[i] > 0)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[bomba].X <= arabakoordinat[i].X && arabakoordinat[bomba].Y <= arabakoordinat[i].Y && yon[i] < 4.05f)
                                    {
                                        yon[i] += 0.15f;
                                        hizsayar[i]++;
                                        if (hizsayar[i] > 20)
                                        {
                                            oan[i] -= hizkazanci[i];
                                            oan[i] -= (maximumhiz[i] - oan[i]) / hizlanma[i];
                                        }
                                        if (hizsayar[i] > 40)
                                        {
                                            hizsayar[i] = 0;
                                        }
                                        if (oan[i] < 5 && hizkazanci[i] > 0)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[bomba].X < arabakoordinat[i].X && arabakoordinat[bomba].Y < arabakoordinat[i].Y && yon[i] > 4.05f)
                                    {
                                        yon[i] -= 0.15f;
                                        hizsayar[i]++;
                                        if (hizsayar[i] > 20)
                                        {
                                            oan[i] -= hizkazanci[i];
                                            oan[i] -= (maximumhiz[i] - oan[i]) / hizlanma[i];
                                        }
                                        if (hizsayar[i] > 40)
                                        {
                                            hizsayar[i] = 0;
                                        }
                                        if (oan[i] < 5 && hizkazanci[i] > 0)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    arabakoordinat[i].X += (float)(oan[i] * Math.Cos(yon[i]));
                                    arabakoordinat[i].Y += (float)(oan[i] * Math.Sin(yon[i]));
                                    if (arabakoordinat[i].X < 0)
                                    {
                                        arabakoordinat[i].X = 0;
                                        yon[i] = 0f;
                                        Random rnd = new Random();
                                        int a = rnd.Next(0, 100);
                                        if (a < 40)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[i].X > 800)
                                    {
                                        arabakoordinat[i].X = 800;
                                        yon[i] = 3.14f;
                                        Random rnd = new Random();
                                        int a = rnd.Next(0, 100);
                                        if (a < 40)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    if (arabakoordinat[i].Y < 0)
                                    {
                                        arabakoordinat[i].Y = 0;
                                        yon[i] = 1.57f;
                                        Random rnd = new Random();
                                        int a = rnd.Next(0, 100);
                                        if (a < 40)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[i].Y > 600)
                                    {
                                        arabakoordinat[i].Y = 600;
                                        yon[i] = 3.75f;
                                        Random rnd = new Random();
                                        int a = rnd.Next(0, 100);
                                        if (a < 40)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (q == 0)
            {
                GraphicsDevice.Clear(Color.Gray);
            }
            else if (q == 1 || q == 2)
            {
                GraphicsDevice.Clear(Color.Green);
            }
            else if (q == 3)
            {
                GraphicsDevice.Clear(Color.ForestGreen);
            }
            else
            {
                GraphicsDevice.Clear(Color.DarkGray);
            }
            spriteBatch.Begin();
            if (menu == 0)
            {
                spriteBatch.Draw(tahb, new Rectangle(0, 0, 800, 600), new Rectangle(0, 0, 32, 32), Color.Gray);
                for (int i = 0; i < 16; i++)
                {
                    araclar = Content.Load<Texture2D>(dosyakonumu[i]);
                    if (sýra < 16)
                    {
                        spriteBatch.Draw(araclar, new Rectangle((int)(((i + 1) * 375) - iarackoordinat.X), 50, 50, 50), Color.White);
                    }
                    spriteBatch.DrawString(font, isim[sýra], new Vector2(375, 100), Color.Black);
                    if (seviye[sýra] <= veritabani)
                    {
                        spriteBatch.DrawString(font, "MAXÝMUM HIZ:", new Vector2(20, 200), Color.Red);
                        spriteBatch.DrawString(font, "HÝZLANMA HIZI:", new Vector2(20, 250), Color.Red);
                        spriteBatch.DrawString(font, "DÖNÜÞLERDE HIZ KAZANCI:", new Vector2(20, 300), Color.Red);
                        spriteBatch.DrawString(font, "SEVÝYE: " + seviye[sýra], new Vector2(20, 350), Color.Red);
                        spriteBatch.DrawString(font, "TUR: " + tur[sýra], new Vector2(20, 400), Color.Red);
                        tab = Content.Load<Texture2D>("Hýz Göstergeci");
                        spriteBatch.Draw(tab, new Rectangle(230, 200, (int)(tablodegeri.X) * 1 / 10, 30),new Rectangle(0,0,(int)((tablodegeri.X * 1 / 10)*5/3),30), Color.DarkGray);
                        spriteBatch.Draw(tab, new Rectangle(230, 250, (int)(tablodegeri.Y) * 25 / 10, 30),new Rectangle(0,0,(int)((tablodegeri.Y * 25 / 10)*5/3),30), Color.DarkGray);
                        spriteBatch.Draw(tab, new Rectangle(230, 300, (int)(tablodegeri.Z) * 25 / 10, 30),new Rectangle(0,0,(int)((tablodegeri.Z * 25 / 10)*5/3),30),Color.DarkGray);
                    }
                    else
                    {
                        spriteBatch.DrawString(baslik, "KÝLÝTLÝ", new Vector2(300, 200), Color.Red);
                    }
                }
                spriteBatch.DrawString(font, "YARDIM ÝÇÝN Y'YE BASIN", new Vector2(300, 550), Color.Red);
                spriteBatch.DrawString(font, isim[sýra] + "'I/U SEÇMEK ÝÇÝN ENTER'A BASIN", new Vector2(300, 500), Color.Red);
                araclar = Content.Load<Texture2D>(dosyakonumu[sýra]);
                if (sýra > 15)
                {
                    spriteBatch.Draw(araclar, new Rectangle(375, 50, 50, 50), Color.White);
                }
            }
            if (menu == 10)
            {
                spriteBatch.DrawString(font, "EBELEMECE 2'DE AMAÇ SÜRE BÝTTÝÐÝNDE BOMBANIN SAHÝBÝ OLMAKTIR", new Vector2(100, 0), Color.White);
                spriteBatch.DrawString(font, "BOMBA OLMAK ÝÇÝN BOMBA OLAN OYUNCUYA ÇARPMANIZ YETERLÝ", new Vector2(100, 40), Color.White);
                spriteBatch.DrawString(font, "OYUNCUNUZ OTOMATÝK HIZLANACAK SÝZ SADECE OK TUÞLARIYLA YÖN VERÝN", new Vector2(100, 80), Color.White);
                spriteBatch.DrawString(font, "KÝLÝTLÝ OYUNCULARI AÇMAK ÝÇÝN PUANINIZI 10 SANÝYEYÝ GEÇMELÝ (MODSUZ)", new Vector2(100, 120), Color.White);
                spriteBatch.DrawString(font, "AYNI ARAÇLAR MODUNU KAPATMAK ÝÇÝN M'YE BASIN", new Vector2(100, 160), Color.DarkBlue);
                spriteBatch.DrawString(font, "AYNI ARAÇLAR MODUNU AÇMAK ÝÇÝN N'YE BASIN", new Vector2(100, 200), Color.DarkBlue);
                spriteBatch.DrawString(font, "KAYITLARINIZI SIFIRLAMAK ÝÇÝN D'E BASIN", new Vector2(100, 240), Color.Green);
                spriteBatch.DrawString(font, "MÝNÝ OYUN ÝÇÝN Q'YA BASIN", new Vector2(100, 280), Color.YellowGreen);
                spriteBatch.DrawString(font, "MÝNÝ OYUNDAN ÇIKMAK ÝÇÝN W'YE BASIN", new Vector2(100, 320), Color.YellowGreen);
                spriteBatch.DrawString(font, "TAMEKRAN ÝÇÝN F6'YA BASIN", new Vector2(100, 360), Color.Aqua);
                spriteBatch.DrawString(font, "TAMEKRANDAN ÇIKMAK ÝÇÝN F5'E BASIN", new Vector2(100, 400), Color.Aqua);
                spriteBatch.DrawString(font, "RANDOM MOD ÝÇÝN R'YE BASIN", new Vector2(100, 440), Color.Black);
                spriteBatch.DrawString(font, "RANDOM MODDAN ÇIKMAK ÝÇÝN T'YE BASIN", new Vector2(100, 480), Color.Black);
                spriteBatch.DrawString(font, "OYUNCU SEÇÝMÝNE DÖNMEK ÝÇÝN S'YE BASIN", new Vector2(100, 520), Color.Red);
                spriteBatch.DrawString(font, "K.A.Y. STUDIOS 2013", new Vector2(100, 560), Color.GhostWhite);
            }
            if (menu == 11)
            {
                spriteBatch.DrawString(font, "  Atýlgan: En cok bulunan turdur. Diger turlere gore daha aktiftirler ve oyunun", new Vector2(100, 0), Color.White);
                spriteBatch.DrawString(font, "baslarinda iyi performans gosterirler. Ama oyun sonuna kadar performanslari duser.", new Vector2(100, 40), Color.White);
                spriteBatch.DrawString(font, "  Enerjik: Cok bulunan baska bir tur. Atýlganlar gibi aktiflerdir ama onlar kadar hizli", new Vector2(100, 100), Color.Black);
                spriteBatch.DrawString(font, "olmadiklarindan bombayi Atýlganlara kaptirabilirler. Ama performanslarini daha az kaybederler", new Vector2(100, 140), Color.Black);
                spriteBatch.DrawString(font, "  YarýAktif: Sadece 2 oyuncu bu turdedir. Enerjiklerden daha hizlidirlar ama onlar kadar", new Vector2(100, 200), Color.Red);
                spriteBatch.DrawString(font, "aktif degillerdir. Performanslarini cok kaybetmezler", new Vector2(100, 240), Color.Red);
                spriteBatch.DrawString(font, "  Yorulmayan: Cok avantajli bir turdur. Oyunun baslarinda etkileri olmaz ama", new Vector2(100, 300), Color.DarkGreen);
                spriteBatch.DrawString(font, "sonlarinda oyunu onlar yonetir", new Vector2(100, 340), Color.DarkGreen);
                spriteBatch.DrawString(font, "  Saldýrgan: Sadece Snake bu turdedir. Diger oyunculari yakalmada uzman olan bu tur", new Vector2(100, 400), Color.Cyan);
                spriteBatch.DrawString(font, "kacis konusunda pek yetenekli degildir", new Vector2(100, 440), Color.Cyan);
                spriteBatch.DrawString(font, "  ZamanlaIsýnan: Sadece Guide bu turdedir. Oyuna yorulmayanlardan cok az avantajli baslar", new Vector2(100, 500), Color.Orange);
                spriteBatch.DrawString(font, "onlardan cok az avantajsiz olarak bitirirler.", new Vector2(100, 540), Color.Orange);
                spriteBatch.DrawString(font, "GERI DONMEK ICIN S'YE BASIN", new Vector2(100, 580), Color.Olive);
            }
            if (menu == 1)
            {
                spriteBatch.Draw(tahb, new Rectangle(0, 0, 800, 600), new Rectangle(0, 0, 32, 32), Color.DarkGray);
                for (int i = 0; i < 8; i++)
                {
                    for (int ii = 0; ii < 24; ii++)
                    {
                        if (yariscisiram[i] == ii)
                        {
                            araclar = Content.Load<Texture2D>(dosyakonumu[ii]);
                            if (i == 0)
                            {
                                spriteBatch.Draw(araclar, new Rectangle(50, i * 50 + 100, 50, 50), Color.White);
                                spriteBatch.DrawString(font, isim[ii] + " (Oyuncu)", new Vector2(150, i * 50 + 100), Color.Black);
                            }
                            else
                            {
                                if (dortkýsýlýk && i > 1 && i < 6)
                                {
                                }
                                else
                                {
                                    if (dortkýsýlýk && i > 5)
                                    {
                                        spriteBatch.Draw(araclar, new Rectangle(50, (i - 4) * 50 + 100, 50, 50), Color.White);
                                        spriteBatch.DrawString(font, isim[ii] + " (Bilgisayar)", new Vector2(150, (i - 4) * 50 + 100), Color.Black);
                                    }
                                    else
                                    {
                                        spriteBatch.Draw(araclar, new Rectangle(50, i * 50 + 100, 50, 50), Color.White);
                                        spriteBatch.DrawString(font, isim[ii] + " (Bilgisayar)", new Vector2(150, i * 50 + 100), Color.Black);
                                    }
                                }
                            }
                        }
                    }
                }
                spriteBatch.DrawString(font, "EBELEMECEYE KATILANLAR", new Vector2(100, 50), Color.Red);
                spriteBatch.DrawString(font, "BAÞLAMAK ÝÇÝN BOÞLUÐA BASIN", new Vector2(100, 500), Color.Red);
            }
            if (menu == 2)
            {
                for (int i = 0; i < 8; i++)
                {
                    Color renk = Color.White;
                    if (bomba == i)
                    {
                        renk = Color.Black;
                        araclar = Content.Load<Texture2D>(dosya[i]);
                    }
                    else
                    {
                        araclar = Content.Load<Texture2D>(dosya[i]);
                    }
                    if (dortkýsýlýk && i > 1 && i < 6)
                    {
                    }
                    else
                    {
                        spriteBatch.Draw(araclar, new Rectangle((int)arabakoordinat[i].X, (int)arabakoordinat[i].Y, 50, 50), new Rectangle(0, 0, 50, 50),renk, yon[i], new Vector2(araclar.Width / 2, araclar.Height / 2), SpriteEffects.None, 0);
                    }
                    if (!oyunbasladi)
                    {
                        spriteBatch.DrawString(font, "PUANLAR", new Vector2(20, 100), Color.Red);
                        for (int ii = 0; ii < 8; ii++)
                        {
                            spriteBatch.DrawString(font, ad[ii] + ": " + (puan[ii] / 60) + " sn", new Vector2(20,50 * (ii + 3)), Color.Black); 
                        }
                        spriteBatch.DrawString(font, "YENÝ OYUN ÝÇÝN Z'YE BASIN", new Vector2(550, 20), Color.Red);
                    }
                }
                if (sayac < 0)
                {
                }
                else if (sayac < 600)
                {
                    spriteBatch.DrawString(font, "" + (int)(sayac / 60), new Vector2(750, 40), new Color(250, 0, 0));
                }
                else if (sayac < 1200)
                {
                    spriteBatch.DrawString(font, "" + (int)(sayac / 60), new Vector2(750, 40), new Color(250, 125, 0));
                }
                else if (sayac < 1800)
                {
                    spriteBatch.DrawString(font, "" + (int)(sayac / 60), new Vector2(750, 40), new Color(250, 220, 0));
                }
                else if (sayac < 2400)
                {
                    spriteBatch.DrawString(font, "" + (int)(sayac / 60), new Vector2(750, 40), new Color(220, 250, 0));
                }
                else if (sayac < 3000)
                {
                    spriteBatch.DrawString(font, "" + (int)(sayac / 60), new Vector2(750, 40), new Color(125, 250, 0));
                }
                else if (sayac < 3600)
                {
                    spriteBatch.DrawString(font, "" + (int)(sayac / 60), new Vector2(750, 40), new Color(0, 250, 0));
                }
                spriteBatch.DrawString(font, "HIZ: " + (int)(oan[0]), new Vector2(30, 550), Color.Black);
                spriteBatch.DrawString(font, text, new Vector2(30, 30), Color.Red);
            }
            if (menu == -1)
            {
                spriteBatch.Draw(tahb, new Rectangle(0, 0, 800, 600), new Rectangle(0, 0, 32, 32), Color.White);
                spriteBatch.DrawString(baslik, "EBELEMECE 2", new Vector2(240, 100), Color.Black);
                Random rnd = new Random();
                if (baslangic)
                {
                    int a = rnd.Next(0, 12);
                    if (a == 0 || a == 1 || a == 2)
                    {
                        araclar = Content.Load<Texture2D>("champ");
                    }
                    else if (a == 3 || a == 4 || a == 5)
                    {
                        araclar = Content.Load<Texture2D>("leader");
                    }
                    else if (a == 6)
                    {
                        araclar = Content.Load<Texture2D>("mafia");
                    }
                    else if (a == 7 || a == 8)
                    {
                        araclar = Content.Load<Texture2D>("sketch");
                    }
                    else if (a == 9 || a == 10)
                    {
                        araclar = Content.Load<Texture2D>("zr");
                    }
                    else
                    {
                        araclar = Content.Load<Texture2D>("snake");
                    }
                    baslangic = false;
                }
                spriteBatch.Draw(araclar, new Rectangle(300, 300, 200, 200), new Rectangle(0, 0, 50, 50), Color.White);
                spriteBatch.DrawString(font, "Baþlamak için boþluða basýn", new Vector2(300, 500), Color.Black);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
