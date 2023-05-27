using SplashKitSDK;
using System.Collections.Generic;

public class RobotDodge
{
    private Player _Player;
    private Window _GameWindow;
    private List<Robot> _Robots;

    public bool Quit
    {
        get { return _Player.Quit; }
    }

    public RobotDodge(Window gameWindow, Player player, Robot robot)
    {
        _Player = player;
        _GameWindow = gameWindow;
        _Robots = new List<Robot>();
        _Robots.Add(robot);
    }

    public void HandleInput()
    {
        _Player.HandleInput();
        _Player.StayOnWindow(_GameWindow, _Player);
    }

    public void Draw()
    {
        foreach (Robot robot in _Robots)
        {
            robot.Draw(_GameWindow);
        }
        _Player.Draw();
        _GameWindow.Refresh(60);
    }

    private void CheckCollisions()
    {
        List<Robot> robotsToRemove = new List<Robot>();

        foreach (Robot robot in _Robots)
        {
            if (_Player.CollidedWith(robot) || robot.IsOffScreen(_GameWindow))
            {
                robotsToRemove.Add(robot);
            }
        }

        foreach (Robot robotToRemove in robotsToRemove)
        {
            _Robots.Remove(robotToRemove);
        }
    }

    public void Update()
    {
        CheckCollisions();

        foreach (Robot robot in _Robots)
        {
            robot.Update();
        }
        if (SplashKit.Rnd() < 0.03) 
        {
            Robot randomRobot = RandomRobot();
            _Robots.Add(randomRobot);
        }
    }

    public Robot RandomRobot()
    {
        return new Robot(_GameWindow, _Player);
    }
}



