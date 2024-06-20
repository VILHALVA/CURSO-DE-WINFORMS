# LABEL
Um `Label` é um controle usado para exibir texto estático na interface do usuário. Vamos modificar o exemplo anterior para incluir um `Label` que exibirá a largura atual da região sendo desenhada.

## Passos para adicionar um Label:
1. Adicione um campo para o `Label`.
2. Inicialize o `Label` no construtor.
3. Atualize o texto do `Label` dentro do método `TimerTick`.

## Código Modificado:
```csharp
using System;
using System.Drawing;
using System.Windows.Forms;

public class InvalidateForm : Form
{
    private Timer timer;
    private int width;
    private bool region;
    private Label widthLabel;

    public InvalidateForm()
    {
        timer = new Timer();
        timer.Interval = 500;
        timer.Tick += new EventHandler(TimerTick);
        timer.Enabled = true;

        BackColor = Color.Blue;

        Paint += new PaintEventHandler(PaintHandler);
        Click += new EventHandler(ClickHandler);

        // Inicialização do Label
        widthLabel = new Label();
        widthLabel.Location = new Point(10, 10);
        widthLabel.AutoSize = true;
        widthLabel.ForeColor = Color.White;
        Controls.Add(widthLabel);
    }

    private void TimerTick(object sender, EventArgs e)
    {
        width += 10;
        if (width > Width + 11)
        {
            width = 0;
            Refresh();
            region = !region;
            return;
        }

        // Atualização do texto do Label
        widthLabel.Text = "Largura atual: " + width.ToString();

        if (!region)
        {
            Invalidate(new Rectangle(0, 0, width, Height));
        }
        else
        {
            int half = width / 2;
            int xmiddle = Width / 2;
            int ymiddle = Height / 2;
            Rectangle rect = new Rectangle(xmiddle - half, ymiddle - half, width, width);
            Invalidate(new Region(rect));
        }
    }

    private void ClickHandler(object sender, EventArgs e)
    {
        timer.Enabled = !timer.Enabled;
    }

    private void PaintHandler(object sender, PaintEventArgs pe)
    {
        if (pe.ClipRectangle.Width == Width && pe.ClipRectangle.Height == Height)
        {
            Console.WriteLine("Clearing Form");
            pe.Graphics.FillRectangle(new SolidBrush(BackColor), pe.ClipRectangle);
            return;
        }

        Console.WriteLine("Filling:  " + pe.ClipRectangle);
        pe.Graphics.FillRectangle(new SolidBrush(Color.Red), pe.ClipRectangle);
    }

    public static void Main()
    {
        Application.Run(new InvalidateForm());
    }
}
```

## O que foi adicionado/modificado:
1. **Campo `Label`:**
   ```csharp
   private Label widthLabel;
   ```

2. **Inicialização do `Label` no Construtor:**
   ```csharp
   // Inicialização do Label
   widthLabel = new Label();
   widthLabel.Location = new Point(10, 10);
   widthLabel.AutoSize = true;
   widthLabel.ForeColor = Color.White;
   Controls.Add(widthLabel);
   ```

   - Cria um novo `Label`.
   - Define sua localização na janela.
   - Define `AutoSize` como `true` para ajustar automaticamente o tamanho do `Label` ao texto.
   - Define a cor do texto do `Label` como branca para contraste com o fundo azul.
   - Adiciona o `Label` aos controles da janela.

3. **Atualização do Texto do `Label` no Método `TimerTick`:**
   ```csharp
   widthLabel.Text = "Largura atual: " + width.ToString();
   ```

   - Atualiza o texto do `Label` a cada intervalo do timer para mostrar a largura atual da região sendo desenhada.

Com essas modificações, a janela agora inclui um `Label` que exibe a largura atual da região que está sendo desenhada, proporcionando uma interface mais informativa.