# BEGININVOKE
## Objetivo
Aprender a usar o método `BeginInvoke` para atualizar a interface do usuário de um Windows Forms a partir de uma thread em background.

## Contexto
Em aplicações Windows Forms, apenas a thread que criou um controle pode acessar as propriedades do controle diretamente. Para atualizar a interface do usuário a partir de uma thread em background, utilizamos `BeginInvoke`, que permite que a atualização da UI ocorra na thread correta (a thread principal da UI).

## Exemplo: Atualizando um Label a partir de uma Thread em Background
Vamos criar um exemplo onde um botão inicia uma operação em background que atualiza um label na interface do usuário usando `BeginInvoke`.

## Passos
1. **Criar o Projeto**

   - Abra o Visual Studio.
   - Crie um novo projeto de `Windows Forms App (.NET Framework)` com o nome `AtualizacaoComBeginInvoke`.

2. **Adicionar Controles ao Formulário**

   - Na janela `Toolbox`, arraste os seguintes controles para o formulário (`Form1`):
     - Um `Label` (rótulo).
     - Um `Button` (botão).

3. **Configurar os Controles**

   - Selecione o `Label` e altere as seguintes propriedades no painel `Properties`:
     - `Name`: `labelStatus`
     - `Text`: `Pronto`
     - `AutoSize`: `True`
   
   - Selecione o `Button` e altere as seguintes propriedades:
     - `Name`: `buttonIniciar`
     - `Text`: `Iniciar Processo`

4. **Adicionar Evento de Clique ao Botão**

   - Dê um duplo clique no botão `buttonIniciar` para gerar o método do evento de clique no arquivo `Form1.cs`.

5. **Implementar a Lógica no Evento de Clique**

   - No arquivo `Form1.cs`, adicione o seguinte código no método `buttonIniciar_Click` para iniciar uma operação em background e atualizar o label usando `BeginInvoke`:

```csharp
using System;
using System.Threading;
using System.Windows.Forms;

namespace AtualizacaoComBeginInvoke
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            // Iniciar uma thread em background
            Thread backgroundThread = new Thread(new ThreadStart(ProcessoEmBackground));
            backgroundThread.Start();
        }

        private void ProcessoEmBackground()
        {
            // Simular um processo que leva algum tempo
            Thread.Sleep(3000); // Esperar por 3 segundos

            // Atualizar o label na thread da UI
            this.BeginInvoke(new Action(() =>
            {
                labelStatus.Text = "Processo concluído!";
            }));
        }
    }
}
```

## Código Completo
**Form1.cs:**

```csharp
using System;
using System.Threading;
using System.Windows.Forms;

namespace AtualizacaoComBeginInvoke
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            // Iniciar uma thread em background
            Thread backgroundThread = new Thread(new ThreadStart(ProcessoEmBackground));
            backgroundThread.Start();
        }

        private void ProcessoEmBackground()
        {
            // Simular um processo que leva algum tempo
            Thread.Sleep(3000); // Esperar por 3 segundos

            // Atualizar o label na thread da UI
            this.BeginInvoke(new Action(() =>
            {
                labelStatus.Text = "Processo concluído!";
            }));
        }
    }
}
```

**Form1.Designer.cs:**

```csharp
namespace AtualizacaoComBeginInvoke
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonIniciar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonIniciar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(100, 50);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(35, 13);
            this.labelStatus.TabIndex = 0;
            this.labelStatus.Text = "Pronto";

            // 
            // buttonIniciar
            // 
            this.buttonIniciar.Location = new System.Drawing.Point(100, 100);
            this.buttonIniciar.Name = "buttonIniciar";
            this.buttonIniciar.Size = new System.Drawing.Size(100, 23);
            this.buttonIniciar.TabIndex = 1;
            this.buttonIniciar.Text = "Iniciar Processo";
            this.buttonIniciar.UseVisualStyleBackColor = true;
            this.buttonIniciar.Click += new System.EventHandler(this.buttonIniciar_Click);

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonIniciar);
            this.Controls.Add(this.labelStatus);
            this.Name = "Form1";
            this.Text = "Atualização com BeginInvoke";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
```

#### Executando o Projeto

1. **Compilar e Executar**
   - Pressione `Ctrl + Shift + B` para compilar o projeto.
   - Pressione `Ctrl + F5` para executar o programa sem depuração.

2. **Interagir com a Aplicação**
   - Clique no botão "Iniciar Processo".
   - O label (`Label`) deve atualizar para "Processo concluído!" após 3 segundos.

## Resumo
Neste exemplo, criamos um projeto Windows Forms que demonstra como usar `BeginInvoke` para atualizar a interface do usuário a partir de uma thread em background. Isso é útil para manter a aplicação responsiva enquanto executa operações que podem demorar, garantindo que as atualizações na UI ocorram na thread correta.