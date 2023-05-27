using SplashKitSDK;

public class Player {
    private Bitmap _playerBitmap;

    public double X {get; private set;}
    public double Y {get; private set;}
    public bool Quit {get; private set;}

    public int Width
    {
        get
        {
            return _playerBitmap.Width;
        }
    }

    public int Height
    {
        get
        {
            return _playerBitmap.Height;
        }
    }
    public Player(Window gameWindow)
    {
        _playerBitmap = new Bitmap("Player","Player.png");
        X = (gameWindow.Width - Width) / 2;
        Y = (gameWindow.Height - Height) / 2;
        Quit = false;
    }

    public void Draw()
    {
        _playerBitmap.Draw(X, Y);
    }

    public void HandleInput()
    {
        const int speed = 5;
        if( SplashKit.KeyDown(KeyCode.UpKey))
        {
            Y-=speed;
        }
        if( SplashKit.KeyDown(KeyCode.DownKey))
        {
            Y+=speed;
        }
        if( SplashKit.KeyDown(KeyCode.LeftKey))
        {
            X-=speed;
        }
        if( SplashKit.KeyDown(KeyCode.RightKey))
        {
            X+=speed;
        }
        if( SplashKit.KeyTyped(KeyCode.EscapeKey))
        {
            Quit = true;
        }
    }

    public void StayOnWindow(Window gameWindow, Player a)
    {
        const int GAP = 10;
        if(X<GAP)
        {
            X=GAP;
        }
        if(gameWindow.Width-a.Width-X<GAP)
        {
            X=gameWindow.Width-a.Width-GAP;
        }
        if(gameWindow.Height-a.Height-Y<GAP)
        {
            Y=gameWindow.Height-a.Height-GAP;
        }
        if(Y<GAP)
        {
            Y=GAP;
        }
    }

    public bool CollidedWith(Robot robot)
    {
        return _playerBitmap.CircleCollision(X,Y,robot.CollisionCircle);
    }


}