# SPLITTER
O `Splitter` é um controle utilizado em aplicações Windows Forms que permite dividir visualmente uma área de formulário em duas seções redimensionáveis por meio de uma barra divisória. Esta barra pode ser movida pelo usuário para ajustar dinamicamente o tamanho das seções, proporcionando flexibilidade na interface gráfica.

## Características Principais do Splitter
1. **Divisão de Áreas**: O `Splitter` divide uma área de formulário em duas seções, geralmente chamadas de painéis ou áreas, através de uma barra divisória vertical ou horizontal.

2. **Movimento Ajustável**: O usuário pode arrastar a barra do `Splitter` para a esquerda/direita ou para cima/baixo, alterando assim o tamanho relativo das seções divididas.

3. **Orientação**: Pode ser configurado para dividir as seções verticalmente (orientação horizontal) ou horizontalmente (orientação vertical), dependendo das necessidades do layout da interface.

4. **Personalização**: O `Splitter` possui várias propriedades que permitem ajustar seu comportamento, como `Dock` (para definir a posição do controle pai), `BorderStyle` (para configurar o estilo da borda da barra divisória), `MinSize` (para especificar o tamanho mínimo de uma seção) e `FixedPanel` (para fixar uma das seções, impedindo que seja redimensionada).

5. **Interação com Outros Controles**: É comum combinar o uso do `Splitter` com controles como `Panel`, `GroupBox` ou `TabControl` para criar layouts complexos e organizados.

## Exemplo de Uso Básico
Aqui está um exemplo simples de como usar o `Splitter` em um formulário:

```csharp
using System;
using System.Windows.Forms;

public class MainForm : Form
{
    private Splitter splitter1;
    private Panel panel1;
    private Panel panel2;

    public MainForm()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        splitter1 = new Splitter();
        panel1 = new Panel();
        panel2 = new Panel();

        // Configuração do Splitter
        splitter1.Dock = DockStyle.Left;
        splitter1.BackColor = System.Drawing.Color.DarkGray;
        splitter1.BorderStyle = BorderStyle.FixedSingle;
        splitter1.MinSize = 50;

        // Configuração dos painéis
        panel1.Dock = DockStyle.Left;
        panel1.BackColor = System.Drawing.Color.LightBlue;
        panel1.Width = 200;

        panel2.Dock = DockStyle.Fill;
        panel2.BackColor = System.Drawing.Color.LightGreen;

        // Configuração do formulário principal
        this.Controls.Add(splitter1);
        this.Controls.Add(panel1);
        this.Controls.Add(panel2);
        this.Text = "Exemplo de Splitter";
        this.Size = new System.Drawing.Size(600, 400); // Tamanho inicial do formulário
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}
```

## Explicação do Código
- **Inicialização**: O código cria um formulário `MainForm` que contém um `Splitter` (`splitter1`) e dois painéis (`panel1` e `panel2`).

- **Configuração do Splitter**: Define o `DockStyle` como `DockStyle.Left`, indicando que ele será alinhado à esquerda do formulário. Configura a cor de fundo (`BackColor`), o estilo da borda (`BorderStyle`) e o tamanho mínimo permitido (`MinSize`).

- **Configuração dos Painéis**: Ambos os painéis (`panel1` e `panel2`) são configurados para ocupar o restante do espaço disponível após a posição do `Splitter`. O `panel1` tem um tamanho inicial fixo de 200 pixels.

- **Execução do Aplicativo**: O método `Main()` inicia o formulário `MainForm` como o formulário principal da aplicação.

## Conclusão
O `Splitter` é uma ferramenta valiosa para criar interfaces de usuário flexíveis em aplicações Windows Forms. Ele permite que os desenvolvedores organizem o layout da interface de forma eficiente, facilitando a interação do usuário ao ajustar dinamicamente o tamanho das áreas de conteúdo conforme necessário.