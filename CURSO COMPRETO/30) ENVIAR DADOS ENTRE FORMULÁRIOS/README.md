# ENVIAR DADOS ENTRE FORMULÁRIOS
Existem várias maneiras de enviar dados entre formulários em um aplicativo Windows Forms. Vou fornecer um exemplo usando o conceito de propriedades e eventos. Suponha que você tenha dois formulários: `Formulario1` e `Formulario2`. O `Formulario1` contém um botão e o `Formulario2` exibe dados.

Aqui está um exemplo básico:

```csharp
// Em Formulario1
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class Formulario1 : Form
    {
        private Formulario2 formulario2;

        public Formulario1()
        {
            InitializeComponent();

            formulario2 = new Formulario2();

            // Associando um manipulador de eventos ao botão para abrir o segundo formulário
            buttonAbrirFormulario2.Click += ButtonAbrirFormulario2_Click;
        }

        private void ButtonAbrirFormulario2_Click(object sender, EventArgs e)
        {
            // Configurando os dados que serão enviados para o segundo formulário
            string dadosParaEnviar = "Estes são os dados que estou enviando!";

            // Chamando um método público no segundo formulário para passar os dados
            formulario2.ReceberDados(dadosParaEnviar);

            // Exibindo o segundo formulário
            formulario2.Show();
        }
    }
}

// Em Formulario2
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class Formulario2 : Form
    {
        public Formulario2()
        {
            InitializeComponent();
        }

        // Método público para receber dados do primeiro formulário
        public void ReceberDados(string dadosRecebidos)
        {
            // Faça algo com os dados recebidos
            labelDadosRecebidos.Text = dadosRecebidos;
        }
    }
}
```

Neste exemplo:

- `Formulario1` possui um botão que, quando clicado, abre `Formulario2`.
- `Formulario2` tem um método público `ReceberDados` que aceita dados e os exibe no formulário.

Ao clicar no botão em `Formulario1`, os dados são enviados para `Formulario2` e exibidos. Este é um método simples de enviar dados entre formulários, e você pode expandi-lo ou ajustá-lo de acordo com os requisitos específicos do seu aplicativo.

Note que este é apenas um exemplo e existem outras abordagens possíveis, como o uso de propriedades, eventos personalizados ou métodos públicos, dependendo da complexidade do seu aplicativo e dos requisitos de comunicação entre formulários.