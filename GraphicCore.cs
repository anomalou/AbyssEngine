using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
            
            
            for(int x = 0; x < Core.buffer.width; x++){
                for(int y = 0; y < Core.buffer.height; y++){
                    for(int d = 0; d < Core.buffer.depth; d++){
                        if(textures.textures.ContainsKey(Core.buffer.Get(x,y,d).texture)){
                            spriteBatch.Draw(textures._textures[Core.buffer.Get(x,y,d).texture], new Vector2(x*30, y*30), new Color(Core.buffer.Get(x,y,d).color.color));
                        }else{
                            spriteBatch.Draw(textures._textures["notexture"], new Vector2(x*30, y*30), Color.White);
                        }
                    }
                }
            }

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
