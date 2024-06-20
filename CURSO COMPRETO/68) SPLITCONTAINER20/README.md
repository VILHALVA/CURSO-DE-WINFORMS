# SPLITCONTAINER20
O `SplitContainer` é um controle que divide a área do formulário em duas seções redimensionáveis, conhecidas como painéis, por meio de uma barra divisória ajustável. Isso permite que o usuário redimensione dinamicamente a proporção de espaço ocupado por cada painel.

## Características Principais do SplitContainer
1. **Divisão de Painéis**: O `SplitContainer` divide a área do formulário (ou do seu próprio contêiner) em dois painéis, chamados de `Panel1` e `Panel2`.

2. **Barra Divisória**: Uma barra divisória ajustável separa os dois painéis, permitindo ao usuário redimensionar a área ocupada por cada um deles.

3. **Orientação**: O controle suporta orientação horizontal (dividindo os painéis na vertical) ou vertical (dividindo os painéis na horizontal).

4. **Funcionalidade de Redimensionamento**: Quando o usuário move a barra divisória, o `SplitContainer` ajusta automaticamente o tamanho dos painéis para refletir a nova distribuição de espaço.

5. **Propriedades e Eventos**: O `SplitContainer` oferece várias propriedades e eventos que permitem configurar e personalizar o comportamento da divisão, como `Orientation` (para definir a orientação da divisão), `SplitterDistance` (para definir a posição inicial da barra divisória), `IsSplitterFixed` (para permitir ou impedir o redimensionamento) e eventos como `SplitterMoved` (acionado quando a barra divisória é movida).

## Exemplo de Uso Básico
Aqui está um exemplo simples de como você pode usar o `SplitContainer` em um formulário:

```csharp
using System;
using System.Windows.Forms;

public class MainForm : Form
{
    private SplitContainer splitContainer1;
    private TextBox textBox1;
    private TextBox textBox2;

    public MainForm()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        splitContainer1 = new SplitContainer();
        textBox1 = new TextBox();
        textBox2 = new TextBox();

        // Configuração do SplitContainer
        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.Orientation = Orientation.Horizontal; // Ou Vertical
        splitContainer1.SplitterDistance = 150; // Define a posição inicial da barra divisória

        // Configuração dos painéis
        splitContainer1.Panel1.Controls.Add(textBox1);
        splitContainer1.Panel2.Controls.Add(textBox2);

        // Configurações do formulário principal
        this.Controls.Add(splitContainer1);
        this.Text = "Exemplo de SplitContainer";
        this.Size = new System.Drawing.Size(400, 300); // Tamanho inicial do formulário
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
- **Inicialização**: O código cria um formulário `MainForm` que contém um `SplitContainer` (`splitContainer1`) preenchendo todo o formulário (`DockStyle.Fill`).

- **Configuração do SplitContainer**: Define a orientação (`Orientation`) como horizontal e a distância inicial da barra divisória (`SplitterDistance`) como 150 pixels.

- **Painéis**: Adiciona dois `TextBoxes` (`textBox1` e `textBox2`) aos painéis `Panel1` e `Panel2` do `SplitContainer`, respectivamente.

- **Execução do Aplicativo**: O método `Main()` inicia o formulário `MainForm` como o formulário principal da aplicação.

## Conclusão
O `SplitContainer` é uma ferramenta útil para criar interfaces de usuário flexíveis em aplicações Windows Forms, permitindo ao usuário ajustar dinamicamente a disposição e o tamanho de áreas de conteúdo, melhorando assim a experiência do usuário final.