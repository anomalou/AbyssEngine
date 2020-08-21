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
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1980;
            graphics.IsFullScreen = false;
            
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
            // if (Keyboard.GetState().IsKeyDown(Keys.C))
            //     Exit();
            Control.Controlling(Keyboard.GetState().GetPressedKeys());
            Core.Update();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            
            
            for(int x = 0; x < ScreenBufferParam.width; x++){
                for(int y = 0; y < ScreenBufferParam.height; y++){
                    for(int l = 0; l < ScreenBufferParam.depth; l++){
                        if(textures.textures.ContainsKey(Core.buffer.Get(x,y,l).texture)){
                            spriteBatch.Draw(textures._textures[Core.buffer.Get(x,y,l).texture], new Vector2(x*30, y*30), new Color(Core.buffer.Get(x,y,l).color.color));
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
