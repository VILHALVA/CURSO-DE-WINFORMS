# PROPIEDAD NAME
A propriedade `Name` é uma propriedade comum em muitos controles no framework Windows Forms (e também em outros frameworks de interface gráfica). Essa propriedade permite que você atribua um nome único a um controle para referenciá-lo em seu código.

Aqui está um exemplo simples usando a propriedade `Name` em um controle `TextBox`:

```csharp
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private TextBox textBox1;

        public MeuFormulario()
        {
            InitializeComponent();

            // Criando um TextBox e atribuindo um nome
            textBox1 = new TextBox();
            textBox1.Name = "textBoxNome";
            textBox1.Location = new System.Drawing.Point(20, 20);
            textBox1.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(textBox1);

            // Criando um botão para demonstrar o acesso pelo nome
            Button btnMostrarTexto = new Button();
            btnMostrarTexto.Text = "Mostrar Texto";
            btnMostrarTexto.Location = new System.Drawing.Point(20, 50);
            btnMostrarTexto.Click += BtnMostrarTexto_Click;
            this.Controls.Add(btnMostrarTexto);
        }

        private void BtnMostrarTexto_Click(object sender, EventArgs e)
        {
            // Acessando o TextBox pelo nome e exibindo seu texto
            TextBox textBoxNome = this.Controls["textBoxNome"] as TextBox;

            if (textBoxNome != null)
            {
                MessageBox.Show("Texto do TextBox: " + textBoxNome.Text);
            }
        }
    }
}
```

Neste exemplo:

- Criamos um `TextBox` e atribuímos a ele o nome "textBoxNome".
- Em seguida, criamos um botão que, quando clicado, acessa o `TextBox` pelo nome e exibe seu texto em uma caixa de mensagem.

A propriedade `Name` pode ser útil ao referenciar controles em seu código, especialmente quando você tem muitos controles no formulário e deseja identificá-los de maneira única.

Porém, ao programar em C# com Windows Forms usando o Visual Studio, muitas vezes, você não precisa se preocupar diretamente com a propriedade `Name`, pois o Visual Studio gera automaticamente os campos de controle para você, e você pode referenciar os controles pelo nome que você deu no designer do Visual Studio.