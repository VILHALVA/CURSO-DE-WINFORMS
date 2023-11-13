# RICHTEXTBOX
O controle `RichTextBox` em Windows Forms é usado para exibir e editar texto com formatação em um aplicativo. Ele oferece funcionalidades avançadas, como a capacidade de exibir texto formatado (como negrito, itálico, sublinhado), inserir imagens e muito mais.

Aqui está um exemplo básico de como usar o `RichTextBox` em um formulário Windows Forms:

```csharp
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private RichTextBox richTextBox1;

        public MeuFormulario()
        {
            InitializeComponent();

            // Criando um RichTextBox
            richTextBox1 = new RichTextBox();
            richTextBox1.Location = new System.Drawing.Point(20, 20);
            richTextBox1.Size = new System.Drawing.Size(400, 300);
            this.Controls.Add(richTextBox1);

            // Adicionando texto formatado
            richTextBox1.AppendText("Este é um exemplo de texto formatado.\n");
            richTextBox1.SelectionFont = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            richTextBox1.AppendText("Negrito\n");
            richTextBox1.SelectionFont = new System.Drawing.Font("Times New Roman", 10, System.Drawing.FontStyle.Italic);
            richTextBox1.AppendText("Itálico\n");
            richTextBox1.SelectionFont = new System.Drawing.Font("Courier New", 8, System.Drawing.FontStyle.Underline);
            richTextBox1.AppendText("Sublinhado");

            // Habilitando a capacidade de edição
            richTextBox1.ReadOnly = false;
        }
    }
}
```

Neste exemplo:

- Criamos um `RichTextBox` chamado `richTextBox1`.
- Adicionamos texto formatado usando a propriedade `SelectionFont` para definir a fonte para diferentes partes do texto.
- Habilitamos a capacidade de edição configurando `ReadOnly` para `false`.

Principais propriedades do `RichTextBox`:

- **Text:** Obtém ou define o texto dentro do controle.
- **Rtf:** Obtém ou define o texto com formatação no formato Rich Text Format (RTF).
- **SelectionFont:** Obtém ou define a fonte do texto selecionado.
- **ReadOnly:** Obtém ou define se o controle é somente leitura.

O `RichTextBox` oferece uma ampla gama de funcionalidades, incluindo formatação de texto, inserção de imagens, detecção de links, etc. Adapte o código conforme necessário para atender às necessidades específicas do seu aplicativo.