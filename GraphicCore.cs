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
            GraphicsDevice.Clear(Color.DarkSlateGray);
            spriteBatch.Begin();
            
            
            if(Core.currentWindow != null){
                foreach(IWidget widget in Core.currentWindow.widgets){
                    if(widget.isVisible)
                    foreach(byte layer in widget.canvas.layersEmploy){
                        for(int x = 0; x < widget.transform.scale.x; x++){
                            for(int y = 0; y < widget.transform.scale.y; y++){
                                if(textures.textures.ContainsKey(widget.canvas.Get(x, y, layer).texture))
                                    spriteBatch.Draw(textures._textures[widget.canvas.Get(x, y, layer).texture], new Vector2(x * widget.canvas.cellSize.x + (int)widget.transform.position.x, y * widget.canvas.cellSize.y + (int)widget.transform.position.y), new Color(widget.canvas.Get(x, y, layer).color.color));
                                else
                                    spriteBatch.Draw(textures._textures["notexture"], new Vector2(x * widget.canvas.cellSize.x, y * widget.canvas.cellSize.y), Color.White);
                            }
                        }
                    }
                }
                if(Core.currentWindow.selectedElement != null){
                    spriteBatch.Draw(textures._textures["cursoreL"], new Vector2(Core.currentWindow.cursorePos.x, Core.currentWindow.cursorePos.y), Color.White);
                    spriteBatch.Draw(textures._textures["cursoreR"], new Vector2(Core.currentWindow.cursoreLength.x, Core.currentWindow.cursoreLength.y), Color.White);
                }
            }

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
