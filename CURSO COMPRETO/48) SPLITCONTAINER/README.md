# SPLITCONTAINER
O `SplitContainer` em Windows Forms é um controle que fornece uma interface gráfica para dividir o formulário em duas áreas redimensionáveis. Ele geralmente é usado para criar layouts divididos, onde o usuário pode ajustar o tamanho relativo das duas áreas. Cada área do `SplitContainer` pode conter outros controles.

Aqui está um exemplo básico de como usar o `SplitContainer` em um formulário:

```csharp
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private SplitContainer splitContainer1;
        private Button button1;
        private Button button2;

        public MeuFormulario()
        {
            InitializeComponent();

            // Criando um SplitContainer
            splitContainer1 = new SplitContainer();
            splitContainer1.Dock = DockStyle.Fill;

            // Criando botões para cada painel
            button1 = new Button();
            button1.Text = "Botão 1";

            button2 = new Button();
            button2.Text = "Botão 2";

            // Adicionando os botões aos painéis do SplitContainer
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel2.Controls.Add(button2);

            // Adicionando o SplitContainer ao formulário
            this.Controls.Add(splitContainer1);
        }
    }
}
```

Neste exemplo:

- Criamos um `SplitContainer` chamado `splitContainer1`.
- Configuramos o `Dock` para preencher o formulário inteiro.
- Criamos dois botões, `button1` e `button2`.
- Adicionamos cada botão a um dos painéis do `SplitContainer`.

Os usuários podem ajustar o tamanho relativo dos painéis arrastando a barra de divisão central do `SplitContainer`. Isso é útil para criar layouts flexíveis, especialmente quando você deseja permitir que o usuário personalize a aparência da interface do usuário.

O `SplitContainer` oferece várias propriedades e eventos que permitem personalizar seu comportamento, como a orientação da divisão, a largura inicial dos painéis e muito mais. Isso facilita a criação de interfaces de usuário mais dinâmicas e adaptáveis.