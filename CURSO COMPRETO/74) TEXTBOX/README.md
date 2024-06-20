# TEXTBOX
O controle `TextBox` em Windows Forms é usado para permitir a entrada de texto pelo usuário. Ele é um dos controles mais comuns e versáteis, oferecendo várias propriedades e eventos para personalizar seu comportamento e aparência.

## Criação de um TextBox Simples
Aqui está um exemplo básico de como criar um `TextBox` em um formulário Windows Forms:

```csharp
using System;
using System.Windows.Forms;

public class TextBoxForm : Form
{
    public TextBoxForm()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        // Criação do TextBox
        TextBox textBox = new TextBox
        {
            Location = new System.Drawing.Point(20, 20),
            Width = 200
        };

        // Adição do TextBox ao formulário
        this.Controls.Add(textBox);

        // Configurações do formulário
        this.Text = "Exemplo de TextBox";
        this.Size = new System.Drawing.Size(300, 200);
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new TextBoxForm());
    }
}
```

## Propriedades Comuns do TextBox
- **Text**: Obtém ou define o texto exibido no `TextBox`.
- **Multiline**: Quando definido como `true`, permite múltiplas linhas de texto.
- **ReadOnly**: Quando definido como `true`, impede a edição do texto.
- **PasswordChar**: Define um caractere de máscara para entradas de senha.
- **MaxLength**: Define o número máximo de caracteres que podem ser inseridos.
- **ScrollBars**: Define se o controle deve exibir barras de rolagem (horizontal, vertical ou ambas).

## Exemplo Avançado
Aqui está um exemplo mais avançado que demonstra algumas dessas propriedades:

```csharp
using System;
using System.Windows.Forms;

public class AdvancedTextBoxForm : Form
{
    public AdvancedTextBoxForm()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        // Criação de um TextBox Multiline
        TextBox multilineTextBox = new TextBox
        {
            Location = new System.Drawing.Point(20, 20),
            Width = 200,
            Height = 100,
            Multiline = true,
            ScrollBars = ScrollBars.Vertical
        };

        // Criação de um TextBox ReadOnly
        TextBox readOnlyTextBox = new TextBox
        {
            Location = new System.Drawing.Point(20, 130),
            Width = 200,
            Text = "Texto somente leitura",
            ReadOnly = true
        };

        // Criação de um TextBox com PasswordChar
        TextBox passwordTextBox = new TextBox
        {
            Location = new System.Drawing.Point(20, 160),
            Width = 200,
            PasswordChar = '*'
        };

        // Adição dos TextBoxes ao formulário
        this.Controls.Add(multilineTextBox);
        this.Controls.Add(readOnlyTextBox);
        this.Controls.Add(passwordTextBox);

        // Configurações do formulário
        this.Text = "Exemplo Avançado de TextBox";
        this.Size = new System.Drawing.Size(300, 250);
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new AdvancedTextBoxForm());
    }
}
```

## Eventos Comuns do TextBox
- **TextChanged**: Ocorre quando o texto no controle é alterado.
- **KeyDown**: Ocorre quando uma tecla é pressionada enquanto o controle tem foco.
- **KeyPress**: Ocorre quando uma tecla é pressionada e liberada enquanto o controle tem foco.
- **KeyUp**: Ocorre quando uma tecla é liberada enquanto o controle tem foco.

## Exemplo de Uso de Eventos
Aqui está um exemplo de como usar eventos com o `TextBox`:

```csharp
using System;
using System.Windows.Forms;

public class TextBoxEventsForm : Form
{
    public TextBoxEventsForm()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        // Criação do TextBox
        TextBox textBox = new TextBox
        {
            Location = new System.Drawing.Point(20, 20),
            Width = 200
        };

        // Subscrição dos eventos
        textBox.TextChanged += new EventHandler(TextBox_TextChanged);
        textBox.KeyDown += new KeyEventHandler(TextBox_KeyDown);

        // Adição do TextBox ao formulário
        this.Controls.Add(textBox);

        // Configurações do formulário
        this.Text = "Exemplo de Eventos do TextBox";
        this.Size = new System.Drawing.Size(300, 200);
    }

    private void TextBox_TextChanged(object sender, EventArgs e)
    {
        TextBox textBox = sender as TextBox;
        Console.WriteLine("Texto alterado: " + textBox.Text);
    }

    private void TextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            MessageBox.Show("Enter pressionado!");
        }
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new TextBoxEventsForm());
    }
}
```

## Conclusão
O controle `TextBox` é essencial para coletar e manipular a entrada de texto do usuário. Com uma ampla variedade de propriedades e eventos, ele pode ser configurado para atender a diversas necessidades de entrada de dados em aplicativos Windows Forms.