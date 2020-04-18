using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace AbyssBehavior
{
    public class GraphicRender : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        Textures textures;
        SpriteFont debugFont;

        public GraphicRender()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            
            
            textures = new Textures();
            Control.InitializateConfig();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            debugFont = Content.Load<SpriteFont>("baseFont");
        }

        protected override void Update(GameTime gameTime)
        {
            // if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //     Exit();
            Control.Controlling(Keyboard.GetState().GetPressedKeys());
            Time.msc = (long)(gameTime.TotalGameTime.TotalMilliseconds);
            Time.seconds = (int)gameTime.TotalGameTime.Seconds;
            Time.minutes = (int)gameTime.TotalGameTime.Minutes;
            Time.hours = (long)gameTime.TotalGameTime.Hours;
            Core.Update();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.DrawString(debugFont, Control.action.ToString(), new Vector2(0,0), Color.Black);
            spriteBatch.DrawString(debugFont, Time.msc.ToString(), new Vector2(0,40), Color.Black);
            spriteBatch.DrawString(debugFont, Control.couldownTime.ToString(), new Vector2(0,60), Color.Black);
            spriteBatch.DrawString(debugFont, Control.couldown.ToString(), new Vector2(0,80), Color.Black);
            spriteBatch.DrawString(debugFont, Core.testWindow.selectedElement, new Vector2(0,20), Color.Black);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
