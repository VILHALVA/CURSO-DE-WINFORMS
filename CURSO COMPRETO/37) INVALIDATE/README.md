# INVALIDATE
O código é um exemplo em C# que demonstra o uso do método `Invalidate` para gerenciar o redesenho de uma janela (`Form`) no Windows Forms. 

## Explicação do Código:
1. **Namespaces Utilizados:**
   ```csharp
   using System;
   using System.Drawing;
   using System.Windows.Forms;
   ```
   - `System`: Namespace fundamental do .NET.
   - `System.Drawing`: Contém classes para manipulação de gráficos e desenhos.
   - `System.Windows.Forms`: Contém classes para criação de aplicações Windows Forms.

2. **Classe `InvalidateForm` Derivada de `Form`:**
   ```csharp
   public class InvalidateForm : Form {
   ```
   - `InvalidateForm` é uma classe que herda de `Form`, representando uma janela do Windows Forms.

3. **Campos da Classe:**
   ```csharp
   private Timer timer;
   private int width;
   private bool region;
   ```
   - `timer`: Um objeto `Timer` utilizado para disparar eventos em intervalos regulares.
   - `width`: Um inteiro usado para controlar a largura de uma região a ser invalidada/redesenhada.
   - `region`: Um booleano que alterna entre duas formas de invalidação (por retângulo ou por região circular).

4. **Construtor `InvalidateForm`:**
   ```csharp
   public InvalidateForm()
   {
       // Configuração do timer
       timer = new Timer();
       timer.Interval = 500; // Intervalo de 500 milissegundos (0.5 segundos)
       timer.Tick += new EventHandler(TimerTick); // Associa o evento Tick do timer ao método TimerTick
       timer.Enabled = true; // Habilita o timer

       BackColor = Color.Blue; // Define a cor de fundo da janela como Azul

       // Eventos da janela
       Paint += new PaintEventHandler(PaintHandler); // Associa o evento Paint ao método PaintHandler
       Click += new EventHandler(ClickHandler); // Associa o evento Click ao método ClickHandler
   }
   ```
   - O construtor inicializa o timer para disparar a cada 0.5 segundos (`Interval = 500`), define a cor de fundo da janela como azul (`BackColor = Color.Blue`) e associa métodos aos eventos `Paint` e `Click`.

5. **Método `TimerTick`:**
   ```csharp
   private void TimerTick(object sender, EventArgs e)
   {
       width += 10;
       if (width > Width + 11) {
           width = 0;
           Refresh();
           region = !region;
           return;
       }

       if (!region) {
           Invalidate(new Rectangle(0, 0, width, Height));
       } else {
           int half = width / 2;
           int xmiddle = Width / 2;
           int ymiddle = Height / 2;
           Rectangle rect = new Rectangle(xmiddle - half, ymiddle - half, width, width);
           Invalidate(new Region(rect));
       }
   }
   ```
   - `TimerTick` é chamado a cada intervalo do timer. Ele aumenta `width` em 10 unidades e decide entre duas formas de invalidação:
     - Se `region` for falso, invalida um retângulo na parte superior esquerda da janela.
     - Se `region` for verdadeiro, invalida uma região circular no centro da janela.

6. **Método `ClickHandler`:**
   ```csharp
   private void ClickHandler(object sender, EventArgs e)
   {
       timer.Enabled = !timer.Enabled; // Inverte o estado do timer (liga/desliga)
   }
   ```
   - `ClickHandler` é chamado quando ocorre um clique na janela. Ele inverte o estado do timer, alternando entre ligado e desligado.

7. **Método `PaintHandler`:**
   ```csharp
   private void PaintHandler(object sender, PaintEventArgs pe)
   {
       if (pe.ClipRectangle.Width == Width && pe.ClipRectangle.Height == Height) {
           Console.WriteLine("Clearing Form");
           pe.Graphics.FillRectangle(new SolidBrush(BackColor), pe.ClipRectangle);
           return;
       }
       
       Console.WriteLine("Filling: " + pe.ClipRectangle);
       pe.Graphics.FillRectangle(new SolidBrush(Color.Red), pe.ClipRectangle);
   }
   ```
   - `PaintHandler` é chamado sempre que a janela precisa ser redesenhada (por exemplo, após uma invalidação). Dependendo do tamanho da área a ser redesenhada (`ClipRectangle`), ele imprime mensagens no console e preenche a área com uma cor vermelha (`Color.Red`).

8. **Método `Main`:**
   ```csharp
   public static void Main()
   {
       Application.Run(new InvalidateForm());
   }
   ```
   - `Main` é o ponto de entrada do programa. Ele cria uma instância de `InvalidateForm` e a executa usando `Application.Run`, iniciando assim a aplicação Windows Forms.

## Funcionamento Geral:
O programa cria uma janela que periodicamente invalida diferentes regiões ou formas dentro dela, alternando entre um retângulo crescente na parte superior esquerda e um círculo crescente no centro. O timer controla esse processo, e o método `Invalidate` é usado para sinalizar ao sistema operacional que partes da janela precisam ser redesenhadas. O método `PaintHandler` é então chamado para desenhar as áreas inválidas com a cor vermelha.

Esse exemplo demonstra como gerenciar o redesenho dinâmico de uma janela em uma aplicação Windows Forms usando `Invalidate` e manipulando eventos como `Paint` e `Click`.