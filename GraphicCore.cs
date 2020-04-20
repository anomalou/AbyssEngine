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
            textures.textures.Add("notexture",Content.Load<Texture2D>("notexture"));
            
            textures.textures.Add("null", Content.Load<Texture2D>("null"));


            //цифры
            textures.textures.Add("word0",Content.Load<Texture2D>("words/word0"));
            textures.textures.Add("word1",Content.Load<Texture2D>("words/word1"));
            textures.textures.Add("word2",Content.Load<Texture2D>("words/word2"));
            textures.textures.Add("word3",Content.Load<Texture2D>("words/word3"));
            textures.textures.Add("word4",Content.Load<Texture2D>("words/word4"));
            textures.textures.Add("word5",Content.Load<Texture2D>("words/word5"));
            textures.textures.Add("word6",Content.Load<Texture2D>("words/word6"));
            textures.textures.Add("word7",Content.Load<Texture2D>("words/word7"));
            textures.textures.Add("word8",Content.Load<Texture2D>("words/word8"));
            textures.textures.Add("word9",Content.Load<Texture2D>("words/word9"));

            //курсор
            textures.textures.Add("cursoreL",Content.Load<Texture2D>("cursoreL"));
            textures.textures.Add("cursoreR",Content.Load<Texture2D>("cursoreR"));

            //буквы
            textures.textures.Add("worda",Content.Load<Texture2D>("words/worda"));
            textures.textures.Add("wordb",Content.Load<Texture2D>("words/wordb"));
            textures.textures.Add("wordc",Content.Load<Texture2D>("words/wordc"));
            textures.textures.Add("wordd",Content.Load<Texture2D>("words/wordd"));
            textures.textures.Add("worde",Content.Load<Texture2D>("words/worde"));
            textures.textures.Add("wordf",Content.Load<Texture2D>("words/wordf"));
            textures.textures.Add("wordg",Content.Load<Texture2D>("words/wordg"));
            textures.textures.Add("wordh",Content.Load<Texture2D>("words/wordh"));
            textures.textures.Add("wordi",Content.Load<Texture2D>("words/wordi"));
            textures.textures.Add("wordj",Content.Load<Texture2D>("words/wordj"));
            textures.textures.Add("wordk",Content.Load<Texture2D>("words/wordk"));
            textures.textures.Add("wordl",Content.Load<Texture2D>("words/wordl"));
            textures.textures.Add("wordm",Content.Load<Texture2D>("words/wordm"));
            textures.textures.Add("wordn",Content.Load<Texture2D>("words/wordn"));
            textures.textures.Add("wordo",Content.Load<Texture2D>("words/wordo"));
            textures.textures.Add("wordp",Content.Load<Texture2D>("words/wordp"));
            textures.textures.Add("wordq",Content.Load<Texture2D>("words/wordq"));
            textures.textures.Add("wordr",Content.Load<Texture2D>("words/wordr"));
            textures.textures.Add("words",Content.Load<Texture2D>("words/words"));
            textures.textures.Add("wordt",Content.Load<Texture2D>("words/wordt"));
            textures.textures.Add("wordu",Content.Load<Texture2D>("words/wordu"));
            textures.textures.Add("wordv",Content.Load<Texture2D>("words/wordv"));
            textures.textures.Add("wordw",Content.Load<Texture2D>("words/wordw"));
            textures.textures.Add("wordx",Content.Load<Texture2D>("words/wordx"));
            textures.textures.Add("wordy",Content.Load<Texture2D>("words/wordy"));
            textures.textures.Add("wordz",Content.Load<Texture2D>("words/wordz"));
            textures.textures.Add("word ",Content.Load<Texture2D>("words/word "));
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
                            spriteBatch.Draw(textures.textures[Core.buffer.GetTexture(x,y,l)], new Vector2(x*30, y*30), Color.White);
                        }else{
                            spriteBatch.Draw(textures.textures["notexture"], new Vector2(x*30, y*30), Color.White);
                        }
                        //spriteBatch.Draw(textures.textures.(Core.buffer.Texture(new Vector(x,y), l)), new Vector2(x*30,y*30),Color.White);
                    }
                }
            }

            spriteBatch.DrawString(debugFont, Control.action.ToString(), new Vector2(0,0), Color.Black);
            //spriteBatch.DrawString(debugFont, Time.msc.ToString(), new Vector2(0,40), Color.White);
            spriteBatch.DrawString(debugFont, Control.couldownTime.ToString(), new Vector2(0,40), Color.Black);
            spriteBatch.DrawString(debugFont, Control.couldown.ToString(), new Vector2(0,60), Color.Black);
            spriteBatch.DrawString(debugFont, Core.testWindow.selectedElement, new Vector2(0,20), Color.Black);

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
