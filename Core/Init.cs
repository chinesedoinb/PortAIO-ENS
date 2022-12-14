using System;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;

namespace PortAIO
{
    public static class Init
    {
        public static bool loaded = false;
        public static int moduleNum = 1;

        public static void Initialize()
        {

            Console.WriteLine("[PortAIO] Core loading : Module " + moduleNum + " - Common Loaded");
            moduleNum++;

            Misc.Load();
            Console.WriteLine("[PortAIO] Core loading : Module " + moduleNum + " - Misc Loaded");
            moduleNum++;
            if (!Misc.menu.GetValue<MenuBool>("UtilityOnly").Enabled)
            {
                LoadChampion();
                Console.WriteLine("[PortAIO] Core loading : Module " + moduleNum + " - Champion Script Loaded");
                moduleNum++;
                Game.OnUpdate += Game_OnUpdate;
                moduleNum++;
            }

            if (!Misc.menu.GetValue<MenuBool>("ChampsOnly").Enabled)
            {
                LoadUtility();
                Console.WriteLine("[PortAIO] Core loading : Module " + moduleNum + " - Utilities Loaded");
                moduleNum++;
            }

            Console.WriteLine("[PortAIO] Core loaded.");
        }

        private static void Game_OnUpdate(EventArgs args)
        {
            Orbwalker.AttackEnabled = true;
            Orbwalker.MoveEnabled = true;
        }

        public static void PortAIOMsg(string msg)
        {
            Game.Print("<font color=\"#43ddaa\">[PortAIO] </font><font color=\"#ff9999\">" + msg + "</font>");
        }

        #region LOADUTILITY

        public static void LoadUtility()
        {
            if (Misc.menu["Utilitiesports"].GetValue<MenuBool>("enableTracker").Enabled)
            {
                switch (Misc.menu["Utilitiesports"].GetValue<MenuList>("Tracker").Index)
                {
                    case 0: //NabbTracker
                        NabbTracker.Program.Loads();
                        break;
                    case 1: // Tracker#
                        Tracker.Program.Loads();
                        break;
                    case 2: // Entropy.Awareness
                        //Entropy.Awareness.Program.Loads();
                        break;
                }
            }

            if (Misc.menu["enableEvade"].GetValue<MenuBool>().Enabled)
            {
                switch (Misc.menu["Evade"].GetValue<MenuList>().Index)
                {
                    case 0: // Evade# - Done
                        Evade.Program.Loads();
                        break;
                }
            }

            /*if (Misc.menu["Utilitiesports"].GetValue<MenuBool>("enablePredictioner").Enabled)
            {
                switch (Misc.menu["Utilitiesports"].GetValue<MenuList>("Predictioner").Index)
                {
                    case 0: // SPredictioner
                        //SPredictioner.SPredictioner.Initialize();
                        break;
                    case 1: // OKTW Predictioner
                        //OKTWPredictioner.OKTWPredictioner.Initialize();
                        break;
                }
            }*/

            if (Misc.menu["PortAIOuTILITIESS"].GetValue<MenuBool>("ShadowTracker").Enabled)
            {
                ShadowTracker.Program.Game_OnGameLoad();
            }

            if (Misc.menu["PortAIOuTILITIESS"].GetValue<MenuBool>("PerfectWardReborn").Enabled)
            {
                PerfectWardReborn.Program.Loads();
            }

            if (Misc.menu["PortAIOuTILITIESS"].GetValue<MenuBool>("UniversalGankAlerter").Enabled)
            {
                UniversalGankAlerter.Program.Loads();
            }

            if (Misc.menu["PortAIOuTILITIESS"].GetValue<MenuBool>("UniversalRecallTracker").Enabled)
            {
                UniversalRecallTracker.Program.Loads();
            }

            if (Misc.menu["PortAIOuTILITIESS"].GetValue<MenuBool>("UniversalMinimapHack").Enabled)
            {
                UniversalMinimapHack.Program.Loads();
            }

            if (Misc.menu["PortAIOuTILITIESS"].GetValue<MenuBool>("BaseUlt3").Enabled)
            {
                BaseUlt3.Program.Loads();
            }

            if (Misc.menu["PortAIOuTILITIESS"].GetValue<MenuBool>("BasicChatBlock").Enabled)
            {
                BasicChatBlock.Program.Loads();
            }

            if (Misc.menu["PortAIOuTILITIESS"].GetValue<MenuBool>("CSCounter").Enabled)
            {
                CS_Counter.CsCounter.Loads();
            }

            if (Misc.menu["PortAIOuTILITIESS"].GetValue<MenuBool>("DeveloperSharp").Enabled)
            {
                DeveloperSharp.Program.Loads();
            }
        }

        #endregion

        #region LOADCHAMPION

        public static void LoadChampion()
        {
            switch (ObjectManager.Player.CharacterName)
            {
                case "Aatrox":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // Entropy.AIO
                            Entropy.AIO.Program.Loads();
                            break;
                    }

                    break;
                case "Ahri":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                        case 1: // DZAhri
                            DZAhri.Program.Game_OnGameLoad();
                            break;
                        case 2: // EloFactory
                            EloFactory_Ahri.Program.Game_OnGameLoad();
                            break;
                        case 4: // xSalice
                            xSalice_Reworked.Program.LoadReligion();
                            break;
                        case 5: // BadaoSeries
                            BadaoSeries.Program.OnLoad();
                            break;
                        case 6: // AhriSharp
                            AhriSharp.Program.Game_OnGameLoad();
                            break;
                        case 7: // Flowers' Series
                            Flowers_Series.Program.Loads();
                            break;
                        case 8: // Babehri
                            Babehri.Program.Game_OnGameLoad();
                            break;
                        case 9: // Entropy.AIO
                            Entropy.AIO.Program.Loads();
                            break;
                    }

                    break;
                case "Akali":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // KDA Akali
                            KDA_Akali.Program.OnLoad();
                            break;
                        case 1: // MightyAIO
                            MightyAio.Program.Loads();
                            break;
                    }

                    break;
                case "Alistar":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // Easy_Sup
                            Easy_Sup.Program.Loads();
                            break;
                    }

                    break;
                case "Annie":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                        case 1: // Flower's Annie
                            Flowers__Annie.Program.Game_OnGameLoad();
                            break;
                    }

                    break;
                case "Ashe":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                        case 1: // SharpShooter
                            SharpShooter.MyLoader.Loads();
                            break;
                        case 2: // Flowers' Series
                            Flowers_Series.Program.Loads();
                            break;
                        case 3: // Flowers' ADC Series
                            Flowers_ADC_Series.Program.Loads();
                            break;
                    }

                    break;
                case "Blitzcrank":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // Z.Aio
                            Z.aio.Program.Loads();
                            break;
                        case 1: // Easy_Sup
                            Easy_Sup.Program.Loads();
                            break;
                    }

                    break;
                case "Brand":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 14: // LyrdumAIO
                            LyrdumAIO.Program.Loads();
                            break;
                    }

                    break;

                case "Caitlyn":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                        case 1: // SharpShooter
                            SharpShooter.MyLoader.Loads();
                            break;
                        case 2: // Slutty Caitlyn
                            Slutty_Caitlyn.Program.Loads();
                            break;
                        case 3: // Caitlyn Master Headshot
                            Caitlyn_Master_Headshot.Program.Loads();
                            break;
                        case 4: // ChallengerSeriesAIO
                            Challenger_Series.Program.Loads();
                            break;
                    }

                    break;
                case "Camille":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // hCamille
                            hCamille.Program.Loads();
                            break;
                        case 1: // Camille#
                            CamilleSharp.Program.Loads();
                            break;
                        case 2: // Lord's Camille
                            LordsCamille.Program.Loads();
                            break;
                    }

                    break;

                case "Cassiopeia":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // ExorAIO
                            ExorAIO.Program.Loads();
                            break;
                        case 1: // LyrdumAIO
                            LyrdumAIO.Program.Loads();
                            break;
                    }

                    break;
                case "Chogath":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 1: // MightyAIO
                            MightyAio.Program.Loads();
                            break;
                    }

                    break;
                case "Corki":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                        case 1: // SharpShooter 
                            SharpShooter.MyLoader.Loads();
                            break;
                    }

                    break;
                case "Darius":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                        case 1: // ExorAIO
                            ExorAIO.Program.Loads();
                            break;
                        case 2: // Flowers' Series
                            Flowers_Series.Program.Loads();
                            break;
                    }

                    break;
                case "Draven":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // SharpShooter
                            SharpShooter.MyLoader.Loads();
                            break;
                        case 1: // ExorAIO
                            ExorAIO.Program.Loads();
                            break;
                        case 2: // Tyler1
                            Tyler1.Program.Loads();
                            break;
                    }

                    break;
                case "Ekko":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                    }

                    break;
                case "Ezreal":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: //OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                        case 1: //EzAIO
                            EzAIO.Program.Loads();
                            break;
                        case 2: //Sharpshooter
                            SharpShooter.MyLoader.Loads();
                            break;
                        case 3: // MightyAIO
                            MightyAio.Program.Loads();
                            break;
                    }

                    break;
                case "Fizz":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // MightyAIO
                            MightyAio.Program.Loads();
                            break;
                    }

                    break;
                case "Gangplank":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // Badao Gangplank
                            BadaoGP.Program.Loads();
                            break;
                        case 1: // BangPlank
                            Bangplank.Program.Loads();
                            break;
                        case 2: // BePlank
                            BePlank.Program.Loads();
                            break;
                        case 3: // e.Motion Gangplank
                            e.Motion_Gangplank.Program.OnLoad();
                            break;
                        case 4: // GangplankBuddy
                            GangplankBuddy.Program.Loads();
                            break;
                        case 5: // Entropy.AIO
                            Entropy.AIO.Program.Loads();
                            break;
                    }

                    break;
                case "Graves":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                        case 1: // SharpShooter
                            SharpShooter.MyLoader.Loads();
                            break;
                        case 2: // ExorAIO
                            ExorAIO.Program.Loads();
                            break;
                    }

                    break;
                case "Illaoi":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // Tentacle Kitty
                            Illaoi_Tentacle_Kitty.Program.Game_OnGameLoad();
                            break;
                        case 1: // Flowers' Series
                            Flowers_Series.Program.Loads();
                            break;
                        case 2: // Kraken Priestess
                            Flowers__Illaoi.Program.Loads();
                            break;
                        case 3: // IllaoiSOH
                            IllaoiSOH.Program.Game_OnGameLoad();
                            break;
                    }

                    break;
                case "Jax":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // ExorAIO
                            ExorAIO.Program.Loads();
                            break;
                        case 1: // NoobAIO
                            NoobAIO.Program.Loads();
                            break;
                    }

                    break;
                case "Jayce":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                        case 1: // Shulepin's Jayce
                            Jayce.Load.Loads();
                            break;
                    }

                    break;
                case "Jhin":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                        case 1: // ExorAIO
                            ExorAIO.Program.Loads();
                            break;
                        case 2:
                            EzAIO.Program.Loads();
                            break;
                    }

                    break;
                case "Jinx":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: //OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                        case 1: // EzAIO
                            EzAIO.Program.Loads();
                            break;
                        case 2: // ADCPackage
                            ADCPackage.Program.Game_OnGameLoad();
                            break;
                        case 3: // GenesisJinx
                            Jinx_Genesis.Program.Game_OnGameLoad();
                            break;
                        case 4: // SharpShooter
                            SharpShooter.MyLoader.Loads();
                            break;
                        case 5: // xSalice
                            xSalice_Reworked.Program.LoadReligion();
                            break;
                        case 6: // ExorAIO
                            ExorAIO.Program.Loads();
                            break;
                        case 7: // MigthyAIO
                            MightyAio.Program.Loads();
                            break;
                    }

                    break;
                case "Kalista":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // HERMES Kalista
                            HERMES_Kalista.Program.Loads();
                            break;
                        case 1: // OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                        case 2: // SharpShooter
                            SharpShooter.MyLoader.Loads();
                            break;
                        case 3: // ExorAIO
                            ExorAIO.Program.Loads();
                            break;
                        case 4: // EzAIO
                            EzAIO.Program.Loads();
                            break;
                        case 5: // EnsoulSharp.Kalista
                            EnsoulSharp.Kalista.Program.Loads();
                            break;
                        case 6: // ChallengerSeriesAIO
                            Challenger_Series.Program.Loads();
                            break;
                    }

                    break;
                case "Karthus":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                        case 1: // KimbaengKarthus
                            Kimbaeng_KarThus.Program.Loads();
                            break;
                        case 2: // Flowers' Karthus
                            Flowers_Karthus.Program.Loads();
                            break;
                        case 3: // LyrdumAIO
                            LyrdumAIO.Program.Loads();
                            break;
                    }

                    break;
                case "Katarina":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // NoobAIO
                            NoobAIO.Program.Loads();
                            break;
                    }

                    break;
                case "Kayn":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // NoobAIO
                            NoobAIO.Program.Loads();
                            break;
                    }

                    break;
                case "Kindred":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                    }

                    break;
                case "Leblanc":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // Entropy.AIO
                            Entropy.AIO.Program.Loads();
                            break;
                    }

                    break;
                case "Leona":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // Z.Aio
                            Z.aio.Program.Loads();
                            break;
                    }

                    break;
                case "Lillia":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // MightyAIO
                            MightyAio.Program.Loads();
                            break;
                    }

                    break;
                case "Lucian":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                        case 1: // SharpShooter
                            SharpShooter.MyLoader.Loads();
                            break;
                        case 2: // ExorAIO
                            ExorAIO.Program.Loads();
                            break;
                        case 3: // Flowers' ADC Series
                            Flowers_ADC_Series.Program.Loads();
                            break;
                        case 4: // EzAIO
                            EzAIO.Program.Loads();
                            break;
                        case 5: // MightyAIO
                            MightyAio.Program.Loads();
                            break;
                    }

                    break;
                case "Lux":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                        case 1: // M00N Lux
                            MoonLux.Program.Loads();
                            break;
                        case 2: // LyrdumAIO
                            LyrdumAIO.Program.Loads();
                            break;
                        case 3: // Easy_Sup
                            Easy_Sup.Program.Loads();
                            break;
                    }

                    break;
                case "MasterYi":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // NoobAIO
                            NoobAIO.Program.Loads();
                            break;
                    }

                    break;
                case "Morgana":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // Easy_Sup
                            Easy_Sup.Program.Loads();
                            break;
                    }

                    break;
                case "Neeko":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // Entropy.AIO
                            Entropy.AIO.Program.Loads();
                            break;
                    }

                    break;
                case "Pyke":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // Easy_Sup
                            Easy_Sup.Program.Loads();
                            break;
                    }

                    break;
                case "Riven":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // MigthyAIO
                            MightyAio.Program.Loads();
                            break;
                    }

                    break;
                case "Senna":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // MightyAIO
                            MightyAio.Program.Loads();
                            break;
                    }

                    break;
                case "Shen":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // MightyAIO
                            MightyAio.Program.Loads();
                            break;
                    }

                    break;
                case "Shyvana":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // NoobAIO
                            NoobAIO.Program.Loads();
                            break;
                    }

                    break;
                case "Sivir":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                        case 1: // SharpShooter
                            SharpShooter.MyLoader.Loads();
                            break;
                        case 2: // Flowers' Series
                            Flowers_Series.Program.Loads();
                            break;
                    }

                    break;
                case "Skarner":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // MightyAIO
                            MightyAio.Program.Loads();
                            break;
                    }

                    break;
                case "Soraka":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // Easy_Sup
                            Easy_Sup.Program.Loads();
                            break;
                    }

                    break;
                case "Syndra":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // BadaoSeries
                            BadaoSeries.Program.OnLoad();
                            break;
                        case 1: // OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                    }

                    break;
                case "Taliyah":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // ExorAIO
                            ExorAIO.Program.Loads();
                            break;
                    }

                    break;
                case "Thresh":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                        case 1: // Slutty Thresh
                            Slutty_Thresh.Program.Loads();
                            break;
                        case 2: // LyrdumAIO
                            LyrdumAIO.Program.Loads();
                            break;
                        case 3: // Easy_Sup
                            Easy_Sup.Program.Loads();
                            break;
                    }

                    break;
                case "TwistedFate":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // SharpShooter
                            SharpShooter.MyLoader.Loads();
                            break;
                        case 1: // BadaoSeries
                            BadaoSeries.Program.OnLoad();
                            break;
                        case 2: // NoobAIO
                            NoobAIO.Program.Loads();
                            break;
                    }

                    break;
                case "Twitch":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 3: // SharpShooter
                            SharpShooter.MyLoader.Loads();
                            break;
                        case 5: // ExorAIO
                            ExorAIO.Program.Loads();
                            break;
                        case 15: // NoobAIO
                            NoobAIO.Program.Loads();
                            break;
                    }

                    break;
                case "Varus":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // ElVarus
                            ElVarus.Varus.Game_OnGameLoad();
                            break;
                        case 1: // OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                        case 2: // Sharpshooter
                            SharpShooter.MyLoader.Loads();
                            break;
                    }

                    break;
                case "Vayne":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // OKTW
                            OneKeyToWin_AIO_Sebby.Program.GameOnOnGameLoad();
                            break;
                        case 1: // SharpShooter
                            SharpShooter.MyLoader.Loads();
                            break;
                        case 2: // hi im gosu
                            hi_im_gosu.Vayne.Game_OnGameLoad();
                            break;
                        case 3: // ExorAIO
                            ExorAIO.Program.Loads();
                            break;
                        case 4: // Flowers' Series
                            Flowers_Series.Program.Loads();
                            break;
                        case 5: // EzAIO
                            EzAIO.Program.Loads();
                            break;
                    }

                    break;
                case "Viktor":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // Badao's Viktor
                            ViktorBadao.Program.Game_OnGameLoad();
                            break;
                        case 1: // Flowers' Series
                            Flowers_Series.Program.Loads();
                            break;
                        case 2: // Flowers' Viktor
                            Flowers_Viktor.Program.Loads();
                            break;
                    }

                    break;
                case "Xayah":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // SharpShooter
                            SharpShooter.MyLoader.Loads();
                            break;
                    }

                    break;
                case "Yasuo":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 11: // Flowers' Yasuo
                            Flowers_Yasuo.MyLoader.Loads();
                            break;
                    }

                    break;
                case "Yorick":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // MightyAIO
                            MightyAio.Program.Loads();
                            break;
                    }

                    break;
                case "Yuumi":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // MightyuAIO
                            MightyAio.Program.Loads();
                            break;
                    }

                    break;
                case "Zac":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: //MightyAIO
                            MightyAio.Program.Loads();
                            break;
                    }

                    break;
                case "Zed":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // Korean Zed
                            KoreanZed.Program.Game_OnGameLoad();
                            break;
                        case 1: // SharpyAIO
                            Sharpy_AIO.Program.Game_OnGameLoad();
                            break;
                        case 2: // Ze-D Is Back
                            zedisback.Program.Loads();
                            break;
                    }

                    break;
                case "Zoe":
                    switch (Misc.menu[ObjectManager.Player.CharacterName.ToString()].GetValue<MenuList>().Index)
                    {
                        case 0: // Korean Zed
                            MightyAio.Program.Loads();
                            break;
                    }

                    break;
            }
        }

        #endregion
    }
}