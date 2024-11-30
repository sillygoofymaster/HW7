using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Examples
{
    // Mainapp test application 
    class MainApp
    {
        public static void Main()
        {
            Facade facade = new Facade();
            facade.ActivateNightMode();
            facade.ActivateMorningMode();
            // Wait for user 
            Console.Read();
        }
    }


    // "Subsystem ClassA" 
    class LightingSystem
    {
        public void TurnLightsOn()
        {
            Console.WriteLine(" LightingSystem TurnLightsOn");
        }
        public void TurnLightsOff()
        {
            Console.WriteLine(" LightingSystem TurnLightsOff");
        }
    }

    // Subsystem ClassB" 
    class SecuritySystem
    {
        public void LockDoors()
        {
            Console.WriteLine(" SecuritySystem LockDoors");
        }
    }


    // Subsystem ClassC" 
    class HeatingSystem
    {
        public void HeatOff()
        {
            Console.WriteLine(" HeatingSystem HeatOff");
        }
    }
    // Subsystem ClassD" 
    class SoundSystem
    {
        public void MusicOff()
        {
            Console.WriteLine(" SoundSystem MusicOff");
        }

        public void SetOffAlarmClock()
        {
            Console.WriteLine(" SoundSystem SetOffAlarmClock");
        }
    }
    // "Facade" 
    class Facade //house automation system
    {
        LightingSystem lightingSystem;
        SecuritySystem securitySystem;
        HeatingSystem heatingSystem;
        SoundSystem soundSystem;

        public Facade()
        {
            lightingSystem = new LightingSystem();
            securitySystem = new SecuritySystem();
            heatingSystem = new HeatingSystem();
            soundSystem = new SoundSystem();
        }

        public void ActivateNightMode()
        {
            Console.WriteLine("\nActivateNightMode() ---- ");
            lightingSystem.TurnLightsOff();
            securitySystem.LockDoors();
            soundSystem.MusicOff();
        }

        public void ActivateMorningMode()
        {
            Console.WriteLine("\nActivateMorningMode() ---- ");
            soundSystem.SetOffAlarmClock();
            heatingSystem.HeatOff();
        }
    }
}
