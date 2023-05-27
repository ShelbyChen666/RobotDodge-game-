using System;
using SplashKitSDK;

namespace RobotDodgeGame
{
    public class Program
    {
        public static void Main()
        {
            Window gameWindow = new Window("RobotDodge", 600, 600);
            Player player1 = new Player(gameWindow);
            Robot robot = new Robot(gameWindow, player1);
            RobotDodge robotDodge = new RobotDodge(gameWindow, player1, robot);
            

            while(!gameWindow.CloseRequested && !robotDodge.Quit)
            {
                SplashKit.ProcessEvents();
                gameWindow.Clear(Color.AliceBlue);
                robotDodge.HandleInput();
                robotDodge.Update();
                robotDodge.Draw();
            }
            gameWindow.Close();


        }
    }
}
