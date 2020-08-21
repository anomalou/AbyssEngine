namespace AbyssBehavior{
    public class TextBox:Widget{

        public string text;

        public TextBox(string text):base(){ this.text = text; SizeToText();}

        protected override void Render(){
            int height = (int)System.Math.Ceiling((double)((double)text.Length / (double)transform.scale.x));
            if(height > 0 && height < transform.maxScale.y && height > transform.scale.y)
                SetSize(new Vector(transform.scale.x, height));
            for(int x = 0, y = 0, l = 0; l < text.Length;){
                if(x < transform.scale.x && y < transform.scale.y){
                    canvas.Set(x, y, 0, Core.systemFont.GetTexture(text[l]), Core.systemFont.color);
                    x++;
                    l++;
                }else
                    if(y < transform.scale.y){
                        y++;
                        x = 0;
                    }else
                        break;
            }
        }

        public void SizeToText(){
            SetSize(new Vector(text.Length, 1));
        }
    }
}
