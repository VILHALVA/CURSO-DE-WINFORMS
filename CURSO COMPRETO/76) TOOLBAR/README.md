# TOOLBAR
Toolbars são componentes comuns em aplicativos de desktop que fornecem aos usuários acesso rápido a uma coleção de comandos ou funções. No Windows Forms, a classe `ToolStrip` é frequentemente usada para criar toolbars. Abaixo, vou explicar como você pode criar e configurar uma toolbar básica usando `ToolStrip` no Windows Forms.

## Criando uma Toolbar Básica
Aqui está um exemplo de como criar e adicionar uma toolbar a um formulário no Windows Forms:

```csharp
using System;
using System.Windows.Forms;

public class ToolbarForm : Form
{
    private ToolStrip toolStrip;
    private ToolStripButton newButton;
    private ToolStripButton openButton;
    private ToolStripButton saveButton;

    public ToolbarForm()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        // Inicialização do ToolStrip
        toolStrip = new ToolStrip();

        // Inicialização dos botões da toolbar
        newButton = new ToolStripButton("New");
        openButton = new ToolStripButton("Open");
        saveButton = new ToolStripButton("Save");

        // Adicionando eventos aos botões
        newButton.Click += NewButton_Click;
        openButton.Click += OpenButton_Click;
        saveButton.Click += SaveButton_Click;

        // Adicionando botões ao ToolStrip
        toolStrip.Items.Add(newButton);
        toolStrip.Items.Add(openButton);
        toolStrip.Items.Add(saveButton);

        // Adicionando ToolStrip ao formulário
        this.Controls.Add(toolStrip);

        // Configurações do formulário
        this.Text = "Exemplo de Toolbar";
        this.Size = new System.Drawing.Size(400, 300);
    }

    // Métodos de evento dos botões
    private void NewButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Novo arquivo criado.");
    }

    private void OpenButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Abrir arquivo.");
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Arquivo salvo.");
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new ToolbarForm());
    }
}
```

## Explicação do Código
1. **Inicialização do ToolStrip**:
    - O `ToolStrip` é criado e instanciado.
  
2. **Inicialização dos Botões da Toolbar**:
    - Três botões (`newButton`, `openButton`, `saveButton`) são criados e instanciados.
  
3. **Associação de Eventos aos Botões**:
    - Eventos `Click` são associados a métodos específicos para cada botão (`NewButton_Click`, `OpenButton_Click`, `SaveButton_Click`).

4. **Adição de Botões ao ToolStrip**:
    - Os botões são adicionados ao `ToolStrip` através do método `Items.Add`.

5. **Adição do ToolStrip ao Formulário**:
    - O `ToolStrip` é adicionado ao controle de formulários.

6. **Métodos de Eventos dos Botões**:
    - Métodos para lidar com os cliques nos botões, mostrando uma mensagem de caixa de diálogo para cada ação.

## Personalização da Toolbar
Você pode personalizar ainda mais a toolbar adicionando ícones aos botões, separadores, drop-downs e outros controles. Aqui está um exemplo com ícones:

```csharp
private void InitializeComponents()
{
    toolStrip = new ToolStrip();

    // Inicialização dos botões com ícones
    newButton = new ToolStripButton
    {
        Image = Image.FromFile("path_to_new_icon.png"),
        Text = "New",
        DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
    };

    openButton = new ToolStripButton
    {
        Image = Image.FromFile("path_to_open_icon.png"),
        Text = "Open",
        DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
    };

    saveButton = new ToolStripButton
    {
        Image = Image.FromFile("path_to_save_icon.png"),
        Text = "Save",
        DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
    };

    newButton.Click += NewButton_Click;
    openButton.Click += OpenButton_Click;
    saveButton.Click += SaveButton_Click;

    toolStrip.Items.Add(newButton);
    toolStrip.Items.Add(openButton);
    toolStrip.Items.Add(saveButton);

    this.Controls.Add(toolStrip);
    this.Text = "Exemplo de Toolbar";
    this.Size = new System.Drawing.Size(400, 300);
}
```

## Usando Imagens Embutidas
Para incluir imagens como recursos embutidos, você pode adicionar as imagens ao projeto e configurar suas propriedades de compilação para `Embedded Resource`. Então, você pode carregar essas imagens do assembly:

```csharp
private void InitializeComponents()
{
    toolStrip = new ToolStrip();

    // Inicialização dos botões com ícones embutidos
    newButton = new ToolStripButton
    {
        Image = LoadImageResource("NamespaceDoSeuProjeto.Resources.new_icon.png"),
        Text = "New",
        DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
    };

    openButton = new ToolStripButton
    {
        Image = LoadImageResource("NamespaceDoSeuProjeto.Resources.open_icon.png"),
        Text = "Open",
        DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
    };

    saveButton = new ToolStripButton
    {
        Image = LoadImageResource("NamespaceDoSeuProjeto.Resources.save_icon.png"),
        Text = "Save",
        DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
    };

    newButton.Click += NewButton_Click;
    openButton.Click += OpenButton_Click;
    saveButton.Click += SaveButton_Click;

    toolStrip.Items.Add(newButton);
    toolStrip.Items.Add(openButton);
    toolStrip.Items.Add(saveButton);

    this.Controls.Add(toolStrip);
    this.Text = "Exemplo de Toolbar";
    this.Size = new System.Drawing.Size(400, 300);
}

private Image LoadImageResource(string resourcePath)
{
    var assembly = System.Reflection.Assembly.GetExecutingAssembly();
    using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
    {
        return Image.FromStream(stream);
    }
}
```

## Conclusão
Toolbars são uma parte essencial de muitos aplicativos de desktop, fornecendo acesso rápido e visualmente acessível a comandos e funções. Usando a classe `ToolStrip` do Windows Forms, você pode criar toolbars altamente configuráveis e fáceis de usar.