# TOOLWINDOWS
Um `ToolWindow` no contexto do Windows Forms refere-se a uma janela que tem um estilo específico, geralmente usada para ferramentas auxiliares dentro de uma aplicação, como janelas de propriedades, janelas de ferramentas de desenho, ou outras janelas de apoio. Essas janelas são geralmente menores e têm um comportamento ligeiramente diferente das janelas principais, como não aparecer na barra de tarefas e ter uma aparência diferente.

Vamos criar um exemplo básico que demonstra como criar uma `ToolWindow` no Windows Forms.

## Exemplo de `ToolWindow`
Neste exemplo, vamos criar um formulário principal e uma janela de ferramentas que pode ser exibida e ocultada a partir do formulário principal.

```csharp
using System;
using System.Drawing;
using System.Windows.Forms;

public class MainForm : Form
{
    private Button showToolWindowButton;
    private ToolWindow toolWindow;

    public MainForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        // Inicializa o botão
        showToolWindowButton = new Button
        {
            Location = new Point(50, 50),
            Text = "Show Tool Window"
        };
        showToolWindowButton.Click += new EventHandler(ShowToolWindowButton_Click);

        // Adiciona o botão ao formulário principal
        this.Controls.Add(showToolWindowButton);

        // Configurações do formulário principal
        this.Text = "Main Form";
        this.Size = new Size(300, 200);
    }

    private void ShowToolWindowButton_Click(object sender, EventArgs e)
    {
        // Verifica se a janela de ferramentas já foi criada
        if (toolWindow == null || toolWindow.IsDisposed)
        {
            toolWindow = new ToolWindow();
        }

        // Exibe a janela de ferramentas
        toolWindow.Show();
        toolWindow.BringToFront();
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}

public class ToolWindow : Form
{
    public ToolWindow()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        // Configurações da janela de ferramentas
        this.Text = "Tool Window";
        this.Size = new Size(200, 150);
        this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
    }
}
```

## Explicação do Código
1. **MainForm**: 
    - Este é o formulário principal que contém um botão (`showToolWindowButton`) para exibir a `ToolWindow`.
    - Quando o botão é clicado, o método `ShowToolWindowButton_Click` é chamado. Este método verifica se a `ToolWindow` já foi criada e não está descartada. Se não, cria uma nova instância e a exibe.

2. **ToolWindow**: 
    - Esta é a janela de ferramentas que é exibida quando o botão no formulário principal é clicado.
    - Configurada para ter um estilo de borda `SizableToolWindow`, que dá a aparência típica de uma janela de ferramentas.

## Detalhes Adicionais
- **FormBorderStyle**: Configurar a propriedade `FormBorderStyle` para `FormBorderStyle.SizableToolWindow` faz com que a janela tenha um estilo específico, como uma borda mais fina e sem botões de maximizar ou minimizar. Isso é típico para janelas de ferramentas.
- **Mostrar a Janela de Ferramentas**: O método `Show` é usado em vez de `ShowDialog`, permitindo que a janela de ferramentas seja exibida como uma janela não modal, permitindo interação contínua com o formulário principal.
- **Verificação e Recriação**: O código verifica se a `ToolWindow` já foi criada e se ainda não foi descartada antes de tentar exibi-la novamente. Isso evita a criação de múltiplas instâncias desnecessárias da janela de ferramentas.

## Conclusão
Este exemplo demonstra como criar uma `ToolWindow` no Windows Forms, que pode ser usada para fornecer funcionalidades auxiliares em uma aplicação. A `ToolWindow` pode ser facilmente exibida e ocultada a partir do formulário principal, oferecendo uma maneira organizada de adicionar ferramentas e opções adicionais à interface do usuário.