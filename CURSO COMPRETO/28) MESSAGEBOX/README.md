# MESSAGEBOX
A `MessageBox` em Windows Forms é um diálogo pré-construído que permite exibir mensagens informativas, mensagens de erro, perguntas ao usuário e assim por diante. É uma maneira rápida e fácil de interagir com o usuário para fornecer informações ou receber entrada.

Aqui está um exemplo simples de como usar a `MessageBox` em um formulário Windows Forms:

```csharp
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        public MeuFormulario()
        {
            InitializeComponent();
        }

        private void ExibirMensagem_Click(object sender, EventArgs e)
        {
            // Exemplo de exibição de uma MessageBox informativa
            MessageBox.Show("Esta é uma mensagem informativa!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PerguntarUsuario_Click(object sender, EventArgs e)
        {
            // Exemplo de exibição de uma MessageBox com uma pergunta ao usuário
            DialogResult resultado = MessageBox.Show("Você deseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verificando a escolha do usuário
            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("Você escolheu continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Você escolheu não continuar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExibirErro_Click(object sender, EventArgs e)
        {
            // Exemplo de exibição de uma MessageBox de erro
            MessageBox.Show("Ocorreu um erro!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
```

Neste exemplo:

- `ExibirMensagem_Click` é um manipulador de eventos associado a um botão que exibe uma mensagem informativa.
- `PerguntarUsuario_Click` é um manipulador de eventos associado a outro botão que exibe uma mensagem com uma pergunta ao usuário.
- `ExibirErro_Click` é um manipulador de eventos associado a um terceiro botão que exibe uma mensagem de erro.

A `MessageBox` tem várias opções, como escolher entre botões "OK", "Cancelar", "Sim", "Não", entre outros. Você também pode especificar um ícone apropriado, como `Information`, `Question`, `Warning` ou `Error`. Adapte o código conforme necessário para atender às necessidades específicas do seu aplicativo.