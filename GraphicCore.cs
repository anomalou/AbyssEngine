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
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 1280;
            // graphics.IsFullScreen = true;
            
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
            foreach(string s in textures.textures.Keys){
                textures._textures.Add(s, Content.Load<Texture2D>(textures.textures[s]));
            }
            // TODO: use this.Content to load your game content here
            debugFont = Content.Load<SpriteFont>("baseFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
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
            GraphicsDevice.Clear(Color.Green);
            spriteBatch.Begin();
            
            
            for(int x = 0; x < Core.buffer.width; x++){
                for(int y = 0; y < Core.buffer.heigth; y++){
                    for(int l = 0; l < Core.buffer.layers; l++){
                        if(textures.textures.ContainsKey(Core.buffer.GetTexture(x,y,l))){
                            spriteBatch.Draw(textures._textures[Core.buffer.GetTexture(x,y,l)], new Vector2(x*30, y*30), Color.White);
                        }else{
                            spriteBatch.Draw(textures._textures["notexture"], new Vector2(x*30, y*30), Color.White);
                        }
                        //spriteBatch.Draw(textures.textures.(Core.buffer.Texture(new Vector(x,y), l)), new Vector2(x*30,y*30),Color.White);
                    }
                }
            }

            // spriteBatch.DrawString(debugFont, Control.action.ToString(), new Vector2(0,0), Color.Black);
            // //spriteBatch.DrawString(debugFont, Time.msc.ToString(), new Vector2(0,40), Color.White);
            // spriteBatch.DrawString(debugFont, Control.couldownTime.ToString(), new Vector2(0,40), Color.Black);
            // spriteBatch.DrawString(debugFont, Control.couldown.ToString(), new Vector2(0,60), Color.Black);
            // spriteBatch.DrawString(debugFont, Core.testWindow.selectedElement, new Vector2(0,20), Color.Black);

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
